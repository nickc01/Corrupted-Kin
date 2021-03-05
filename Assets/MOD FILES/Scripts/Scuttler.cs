using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class Scuttler : MonoBehaviour 
{
	public event Action<Scuttler> SplatEvent;

	static WeaverCore.Utilities.ObjectPool ScuttlerPool;

	protected WeaverAnimationPlayer animator;
	protected new Rigidbody2D rigidbody;
	protected AudioSource audioSource;
	protected new SpriteRenderer renderer;
	protected new Collider2D collider;

	[SerializeField]
	protected float scaleMin = 1.35f;
	[SerializeField]
	protected float scaleMax = 1.5f;

	[SerializeField]
	protected float minAcceleration = 1f;
	[SerializeField]
	protected float maxAcceleration = 1.5f;
	[SerializeField]
	protected float terminalVelocityMin = 4f;
	[SerializeField]
	protected float terminalVelocityMax = 5.5f;
	//[SerializeField]
	//[Tooltip("The object that is spawned when the scuttler splats")]
//	GameObject SpawnOnSplat;

	[SerializeField]
	[Tooltip("The minimum distance to the target required for the scuttler to stop running and jump into the target")]
	protected float minDistanceToTarget = 3f;

	[SerializeField]
	[Tooltip("The minimum delay the scuttler will take before jumping into the target")]
	protected float jumpDelayMin = 0f;
	[SerializeField]
	[Tooltip("The maximum delay the scuttler will take before jumping into the target")]
	protected float jumpDelayMax = 0.25f;
	[SerializeField]
	protected float jumpTime = 22f / 30f;
	[SerializeField]
	protected Vector2 startingVelocity = new Vector2(0f,1f);
	[SerializeField]
	[Tooltip("If set to true, the Scutter will jump right to a specific point. If false, then it will jump somewhere within a set range")]
	protected bool targetSpecificPoint = false;

	[Tooltip("The point to jump to, RELATIVE to the position of the target. This is used if Target Specific Point is set to true")]
	protected Vector2 specificJumpPoint = Vector2.zero;


	
	[SerializeField]
	[Tooltip("The minimum range to jump to, RELATIVE to the position of the target")]
	protected Vector2 targetRangeMin;
	[SerializeField]
	[Tooltip("The maximum range to jump to, RELATIVE to the position of the target")]
	protected Vector2 targetRangeMax;

	[SerializeField]
	protected AudioClip splatSound;
	[SerializeField]
	protected float splatPitchMin = 0.85f;
	[SerializeField]
	protected float splatPitchMax = 1.15f;
	[SerializeField]
	protected float splatRotationMin = -30f;
	[SerializeField]
	protected float splatRotationMax = 30f;
	[SerializeField]
	protected OnDoneBehaviour whenDone = OnDoneBehaviour.DestroyOrPool;

	[SerializeField]
	protected Vector3 spawnOffset;

	public GameObject TargetObject { get; private set; }
	public Vector3 TargetOffset { get; set; }


	WeaverAnimationPlayer splatEffect;

	float terminalVelocity;
	float acceleration;
	float scale;
	float jumpDelay;

	public bool OnGround
	{
		get
		{
			return collisions.Count > 0;
		}
	}

	public IEnumerator WaitTillOnGround()
	{
		while (!OnGround)
		{
			yield return null;
		}
	}

	void Awake()
	{
		SplatEvent = null;
		if (animator == null)
		{
			animator = GetComponent<WeaverAnimationPlayer>();
			rigidbody = GetComponent<Rigidbody2D>();
			audioSource = GetComponent<AudioSource>();
			renderer = GetComponent<SpriteRenderer>();
			splatEffect = transform.Find("Splat").GetComponent<WeaverAnimationPlayer>();
			collider = GetComponent<Collider2D>();
		}
		collisions.Clear();
		splatEffect.gameObject.SetActive(false);
		renderer.flipX = false;
		renderer.enabled = true;
		audioSource.enabled = false;
		splatEffect.gameObject.SetActive(false);
		rigidbody.isKinematic = false;
		transform.rotation = Quaternion.identity;
		terminalVelocity = UnityEngine.Random.Range(terminalVelocityMin,terminalVelocityMax);
		acceleration = UnityEngine.Random.Range(minAcceleration,maxAcceleration);
		scale = UnityEngine.Random.Range(scaleMin,scaleMax);
		jumpDelay = UnityEngine.Random.Range(jumpDelayMin, jumpDelayMax);
		transform.localScale = new Vector3(scale, scale, transform.GetZLocalScale());
		rigidbody.velocity = startingVelocity;
		//transform.position += spawnOffset;
		transform.SetZPosition(CorruptedKinGlobals.Instance.ScuttlerPrefab.transform.position.z);
		if (startingVelocity.y > 0f)
		{
			collider.enabled = false;
		}
		StopAllCoroutines();

		StartCoroutine(SpawnFromGround());
	}

	/*void Start()
	{
		var newScale = Random.Range(scaleMin, scaleMax);
		
	}*/


	IEnumerator WaitTillFalling()
	{
		while (!IsFalling)
		{
			yield return null;
		}
	}

	bool IsFalling
	{
		get
		{
			return rigidbody.velocity.y <= 0f;
		}
	}

	IEnumerator SpawnFromGround()
	{
		//yield return animator.PlayAnimationTillDone("Spawn");
		animator.PlayAnimation("Spawn");

		//yield return new WaitUntil(() => rigidbody.velocity.y <= 0f);
		//yield return WaitTillFalling();

		float originalZPos = transform.GetZPosition();
		float newZPos = spawnOffset.z;

		while (!IsFalling)
		{
			//Debug.Log("Value = " + Mathf.Lerp(newZPos, originalZPos, rigidbody.velocity.y));
			//Debug.Log("V = " + rigidbody.velocity.y);
			//Debug.Log("Original Pos = " + originalZPos);
			//Debug.Log("New Z Pos = " + newZPos);
			transform.SetZPosition(Mathf.Lerp(newZPos, originalZPos,rigidbody.velocity.y));
			yield return null;
		}

		transform.SetZPosition(newZPos);

		collider.enabled = true;

		yield return WaitTillOnGround();
		yield return animator.PlayAnimationTillDone("Land");

		if (TargetObject == null)
		{
			throw new System.Exception("Error: Target not set");
		}

		renderer.flipX = transform.position.x <= TargetObject.transform.position.x + TargetOffset.x;
		audioSource.enabled = true;
		animator.PlayAnimation("Run");

		float directionalAcceleration;
		//If we are to the right of the target
		if (transform.position.x > TargetObject.transform.position.x + TargetOffset.x)
		{
			directionalAcceleration = -acceleration;
		}
		else
		{
			directionalAcceleration = acceleration;
		}
		while (Mathf.Abs(transform.position.x - (TargetObject.transform.position.x + TargetOffset.x)) >= minDistanceToTarget)
		{
			var newXVelocity = rigidbody.velocity.x + (directionalAcceleration * Time.deltaTime);
			if (newXVelocity > terminalVelocity)
			{
				newXVelocity = terminalVelocity;
			}
			rigidbody.velocity = new Vector2(newXVelocity, rigidbody.velocity.y);

			yield return null;
		}

		Debug.Log("Done Moving!");

		yield return new WaitForSeconds(jumpDelay);

		rigidbody.velocity = Vector2.zero;

		animator.PlayAnimation("Spawn");

		var heightDifference = (TargetObject.transform.position.y + TargetOffset.y) - transform.position.y;


		if (targetSpecificPoint)
		{
			rigidbody.velocity = MathUtilties.CalculateVelocityToReachPoint(transform.position - new Vector3(0f, 0.311f), ((Vector2)TargetObject.transform.position + (Vector2)TargetOffset) + specificJumpPoint, jumpTime - (heightDifference * 0.05f),rigidbody.gravityScale);
		}
		else
		{
			var jumpPoint = new Vector2(UnityEngine.Random.Range(targetRangeMin.x,targetRangeMax.x), UnityEngine.Random.Range(targetRangeMin.y,targetRangeMax.y));
			rigidbody.velocity = MathUtilties.CalculateVelocityToReachPoint(transform.position - new Vector3(0f, 0.311f), ((Vector2)TargetObject.transform.position + (Vector2)TargetOffset) + jumpPoint, jumpTime - (heightDifference * 0.05f), rigidbody.gravityScale);
		}

		yield return new WaitForSeconds(jumpTime);
		//yield return new WaitForSeconds(transfo)
		rigidbody.velocity = default(Vector2);
		rigidbody.isKinematic = true;
		renderer.enabled = false;
		yield return OnSplat();


	}

	public void Destroy()
	{
		switch (whenDone)
		{
			case OnDoneBehaviour.Nothing:
				break;
			case OnDoneBehaviour.Disable:
				gameObject.SetActive(false);
				break;
			case OnDoneBehaviour.Destroy:
				Destroy(gameObject);
				break;
			case OnDoneBehaviour.DestroyOrPool:
				var poolable = GetComponent<PoolableObject>();
				if (poolable != null)
				{
					poolable.ReturnToPool();
				}
				else
				{
					Destroy(gameObject);
				}
				break;
			default:
				break;
		}
	}

	List<GameObject> collisions = new List<GameObject>();

	void OnCollisionEnter2D(Collision2D collision)
	{
		collisions.Add(collision.gameObject);
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		collisions.Remove(collision.gameObject);
	}

	protected virtual IEnumerator OnSplat()
	{
		var splatSource = WeaverAudio.PlayAtPoint(splatSound, transform.position);
		splatSource.AudioSource.pitch = UnityEngine.Random.Range(splatPitchMin,splatPitchMax);
		splatEffect.gameObject.SetActive(true);
		transform.rotation = Quaternion.Euler(0f, 0f, transform.GetZRotation() + UnityEngine.Random.Range(splatRotationMin,splatRotationMax));

		/*if (SpawnOnSplat != null)
		{
			GameObject.Instantiate(SpawnOnSplat, transform.position, Quaternion.identity);
		}*/
		if (SplatEvent != null)
		{
			SplatEvent(this);
		}

		//splatEffect.PlayAnimation
		yield return splatEffect.PlayAnimationTillDone("Enemy Shot");
		Destroy();
	}

	public static Scuttler Spawn(Vector3 position, GameObject target, Vector3 targetOffset)
	{
		if (ScuttlerPool == null)
		{
			ScuttlerPool = new WeaverCore.Utilities.ObjectPool(CorruptedKinGlobals.Instance.ScuttlerPrefab);
		}

		var instance = ScuttlerPool.Instantiate<Scuttler>(position + CorruptedKinGlobals.Instance.ScuttlerPrefab.spawnOffset, Quaternion.identity);
		instance.TargetObject = target;
		instance.TargetOffset = targetOffset;
		//instance.transform.position += instance.spawnOffset;
		instance.transform.SetZPosition(CorruptedKinGlobals.Instance.ScuttlerPrefab.transform.position.z);

		return instance;
	}
}
