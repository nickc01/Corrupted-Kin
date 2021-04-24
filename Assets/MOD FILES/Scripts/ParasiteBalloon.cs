using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Utilities;

public class ParasiteBalloon : MonoBehaviour 
{
	static WeaverCore.ObjectPool ParasitePool;

	static HashSet<ParasiteBalloon> spawnedBalloons = new HashSet<ParasiteBalloon>();
	public static IEnumerable<ParasiteBalloon> SpawnedParasites = spawnedBalloons;


	[SerializeField]
	float scaleMin = 1f;
	[SerializeField]
	float scaleMax = 1.25f;
	[SerializeField]
	AudioClip appearSoundEffect;
	[SerializeField]
	float speedMin = 3.5f;
	[SerializeField]
	float speedMax = 6.5f;

	public Vector2 SpawnVelocity;


	EntityHealth health;
	new SpriteRenderer renderer;
	new CircleCollider2D collider;
	CircleCollider2D tileDetector;
	new Rigidbody2D rigidbody;
	WeaverAnimationPlayer animator;
	AudioSource audioPlayer;
	PoolableObject pool;
	ParticleSystem deathParticles;

	bool modifyStorage = true;

	public EntityHealth Health
	{
		get
		{
			return health;
		}
	}

	void Awake()
	{
		modifyStorage = true;
		spawnedBalloons.Add(this);
		if (health == null)
		{
			health = GetComponent<EntityHealth>();
			pool = GetComponent<PoolableObject>();
			renderer = GetComponent<SpriteRenderer>();
			collider = GetComponent<CircleCollider2D>();
			audioPlayer = GetComponent<AudioSource>();
			animator = GetComponent<WeaverAnimationPlayer>();
			rigidbody = GetComponent<Rigidbody2D>();
			deathParticles = GetComponentInChildren<ParticleSystem>();

			tileDetector = transform.Find("TileDetector").GetComponent<CircleCollider2D>();

			health.OnDeathEvent += Health_OnDeathEvent;
		}

		var scale = Random.Range(scaleMin, scaleMax);
		renderer.enabled = false;
		collider.enabled = false;
		tileDetector.enabled = false;
		StartCoroutine(MainRoutine());
	}

	void OnEnable()
	{
		if (modifyStorage)
		{
			spawnedBalloons.Add(this);
		}
	}

	void OnDisable()
	{
		if (modifyStorage)
		{
			spawnedBalloons.Remove(this);
		}
	}

	void OnDestroy()
	{
		if (modifyStorage)
		{
			spawnedBalloons.Remove(this);
		}
	}

	IEnumerator MainRoutine()
	{
		yield return new WaitForSeconds(0.1f);
		//audioPlayer.volume = 1f;
		//audioPlayer.Play();
		//WeaverAudio.PlayAtPoint(appearSoundEffect, transform.position);
		audioPlayer.PlayOneShot(appearSoundEffect);
		renderer.enabled = true;
		//yield return animator.PlayAnimationTillDone("Spawn");
		animator.PlayAnimation("Spawn");
		var clipDuration = animator.AnimationData.GetClipDuration("Spawn");
		for (float i = 0; i < clipDuration; i += Time.deltaTime)
		{
			rigidbody.velocity = Vector2.Lerp(SpawnVelocity,default(Vector2),i / clipDuration);
			yield return null;
		}
		collider.enabled = true;
		tileDetector.enabled = true;
		audioPlayer.Play();

		animator.PlayAnimation("Chase");
		var speed = Random.Range(speedMin,speedMax);

		while (true)
		{
			Chase(Player.Player1.transform, speed, 10f);
			yield return FaceObjectRoutine(Player.Player1.transform, true);
			yield return null;
		}
	}

	private void Health_OnDeathEvent()
	{
		StopAllCoroutines();
		if (modifyStorage)
		{
			spawnedBalloons.Remove(this);
		}
		deathParticles.Play();
		rigidbody.velocity = default(Vector2);
		collider.enabled = false;
		tileDetector.enabled = false;
		audioPlayer.Stop();
		StartCoroutine(DeathRoutine());
	}

	IEnumerator DeathRoutine()
	{
		yield return animator.PlayAnimationTillDone("Death");
		renderer.enabled = false;
		yield return new WaitForSeconds(1.2f);
		pool.ReturnToPool();
	}


	void Chase(Transform target, float maxSpeed, float acceleration)
	{
		Vector2 force = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
		force = Vector2.ClampMagnitude(force, 1f);
		force = new Vector2(force.x * acceleration, force.y * acceleration);
		rigidbody.AddForce(force);


		rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity,maxSpeed);
	}

	public IEnumerator FaceObjectRoutine(Transform t, bool playAnimation = true)
	{
		//If the object is to the right
		if (t.position.x > transform.position.x)
		{
			if (renderer.flipX == true)
			{
				if (playAnimation)
				{
					yield return FlipDirection("TurnToChase");
				}
				else
				{
					renderer.flipX = !renderer.flipX;
				}
			}
		}
		//If the object is to the left
		else
		{
			if (renderer.flipX == false)
			{
				if (playAnimation)
				{
					yield return FlipDirection("TurnToChase");
				}
				else
				{
					renderer.flipX = !renderer.flipX;
				}
			}
		}
	}

	IEnumerator FlipDirection(string animation)
	{
		var previousAnimation = animator.PlayingClip;
		yield return animator.PlayAnimationTillDone(animation, true);
		renderer.flipX = !renderer.flipX;

		if (previousAnimation != null)
		{
			animator.PlayAnimation(previousAnimation);
		}
	}

	public static void DestroyAllParasites()
	{
		foreach (var parasite in SpawnedParasites)
		{
			parasite.modifyStorage = false;
			parasite.StartCoroutine(parasite.Leave());
		}
	}

	IEnumerator Leave()
	{
		if (modifyStorage)
		{
			spawnedBalloons.Remove(this);
		}
		collider.enabled = false;
		tileDetector.enabled = false;
		yield return animator.PlayAnimationTillDone("Leave");
		pool.ReturnToPool();
	}

	public static ParasiteBalloon Spawn(Vector3 position, Vector2 spawnVelocity)
	{
		if (ParasitePool == null)
		{
			ParasitePool = WeaverCore.ObjectPool.Create(CorruptedKinGlobals.Instance.BalloonPrefab);
		}
		var prefabZ = CorruptedKinGlobals.Instance.BalloonPrefab.transform.GetZLocalPosition();
		var instance = ParasitePool.Instantiate<ParasiteBalloon>(new Vector3(position.x,position.y,position.z + prefabZ), Quaternion.identity);
		instance.SpawnVelocity = spawnVelocity;
		return instance;
	}
}
