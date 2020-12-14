using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Features;
using WeaverCore.Utilities;

public class CorruptedKin : BossReplacement
{
	GameObject Shadow;
	WeaverAnimationPlayer animator;
	new SpriteRenderer renderer;
	new Rigidbody2D rigidbody;
	WeaverAudioPlayer audioPlayer;

	[Header("Intro")]
	[SerializeField]
	float leftSpawnPoint = 20.59f;
	[SerializeField]
	float rightSpawnPoint = 33.58f;
	[SerializeField]
	float fallYPosition = 41.82f;
	[SerializeField]
	AudioClip FallSoundEffect;
	[SerializeField]
	AudioClip LandSoundEffect;
	[SerializeField]
	AudioClip HollowKnightScream;
	[SerializeField]
	GameObject RoarWavePrefab;

	public bool IsGrounded
	{
		get
		{
			return terrainCollisions.Count > 0;
		}
	}

	protected override void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<WeaverAnimationPlayer>();
		renderer = GetComponent<SpriteRenderer>();
		audioPlayer = GetComponent<WeaverAudioPlayer>();

		rigidbody.isKinematic = true;

		rigidbody.gravityScale = 3.25f;
		Shadow = GetChild("Shadow");
		animator.PlayAnimation("Idle");
		Shadow.SetActive(false);
		EntityHealth.Invincible = true;
		renderer.enabled = false;

		base.Awake();

		if (CoreInfo.LoadState == WeaverCore.Enums.RunningState.Editor)
		{
			StartBossBattle();
		}
	}

	public void StartBossBattle()
	{
		StartCoroutine(StartBossBattleRoutine());
	}


	IEnumerator StartBossBattleRoutine()
	{
		WeaverEvents.BroadcastEvent("DREAM GATE CLOSE", gameObject);
		rigidbody.isKinematic = false;

		if (Boss.InPantheon)
		{
			//TODO
			transform.SetXPosition(rightSpawnPoint);
			renderer.flipX = true;
		}
		else
		{
			float center = Mathf.Lerp(rightSpawnPoint,leftSpawnPoint,0.5f);

			if (Player.Player1 != null && Player.Player1.transform.position.x > center)
			{
				transform.SetXPosition(leftSpawnPoint);
			}
			else
			{
				transform.SetXPosition(rightSpawnPoint);
			}
		}



		animator.PlayAnimation("Fall");

		audioPlayer.Play(FallSoundEffect);

		transform.SetYPosition(fallYPosition);

		EntityHealth.Invincible = false;

		renderer.enabled = true;

		yield return WaitTillTouchingGround();

		Debug.Log("Ground Touched!");

		audioPlayer.Play(LandSoundEffect);

		Debug.Log("A");

		yield return animator.PlayAnimationTillDone("Land");

		Debug.Log("B");

		//SEND MESSAGE SOMETHING???

		yield return animator.PlayAnimationTillDone("Roar Start");

		//Debug.Log("C");

		if (!Boss.InPantheon)
		{
			//TODO - MUSIC CUE
#if !UNITY_EDITOR
			var snapshots = Resources.FindObjectsOfTypeAll<AudioMixerSnapshot>();
			foreach (var snapshot in snapshots)
			{
				if (snapshot.name == "Normal" && snapshot.audioMixer.name == "Music")
				{
					snapshot.TransitionTo(0f);
					break;
				}
			}
#endif
		}

		animator.PlayAnimation("Roar Loop");

		//TODO - AREA TITLE
		WeaverCore.Assets.AreaTitle.Spawn("Lost", "Kin");

		yield return Roar(2.4f, HollowKnightScream);

		//Debug.Log("F");

		yield return animator.PlayAnimationTillDone("Roar End");


		//Debug.Log("G");
		//TODO - START SPAWN EVENT (Possibbly the balloons that spawn throughout the battle)

		EntityHealth.Invincible = false;



		yield break;
	}





	IEnumerator WaitTillTouchingGround()
	{
		while (!IsGrounded)
		{
			yield return null;
		}
	}

	List<GameObject> terrainCollisions = new List<GameObject>();

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			terrainCollisions.Add(collision.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			terrainCollisions.Remove(collision.gameObject);
		}
	}


	protected override void OnDeath()
	{
		base.OnDeath();
	}

	protected override void OnStun()
	{
		base.OnStun();
	}



	GameObject GetChild(string name)
	{
		return transform.Find(name).gameObject;
	}

	T GetChild<T>(string name)
	{
		return transform.Find(name).GetComponent<T>();
	}
}
