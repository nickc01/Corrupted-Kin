using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Features;
using WeaverCore.Utilities;

using Random = UnityEngine.Random;

public class CorruptedKin : BossReplacement
{
	GameObject Shadow;
	WeaverAnimationPlayer animator;
	new SpriteRenderer renderer;
	new Rigidbody2D rigidbody;
	WeaverAudioPlayer audioPlayer;

	[Header("General Stuff")]
	[SerializeField]
	AudioClip JumpSound;
	[SerializeField]
	AudioClip LandSound;
	[SerializeField]
	AudioClip SwordSlashSound;
	[SerializeField]
	AudioClip PrepareSound;
	[SerializeField]
	float leftX = 16.06f;
	[SerializeField]
	float rightX = 36.53f;
	[SerializeField]
	float jumpHeight = 60f;
	[SerializeField]
	CorruptedKinHealth HealthManager;



	[Space]
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

	[Space]
	[Header("Idle Move")]
	[SerializeField]
	float idleMovementSpeedMin = 0.5f;
	[SerializeField]
	float idleMovementSpeedMax = 1.25f;

	[SerializeField]
	float idleTimeMin = 1f;
	[SerializeField]
	float idleTimeMax = 1.5f;

	[Space]
	[Header("Evade")]
	[SerializeField]
	float evadeSpeed = 25f;
	[SerializeField]
	TouchingPlayer EvadeChecker;

	[Space]
	[Header("Overhead Slash")]
	[SerializeField]
	WeaverAnimationPlayer OverheadSlash;
	[SerializeField]
	TouchingPlayer OverheadSlashChecker;


	[Space]
	[Header("Downstab")]
	[SerializeField]
	float MinDownstabHeight = 33.31f;
	[SerializeField]
	TouchingPlayer DownstabChecker;
	[SerializeField]
	AudioClip DownstabPrepareSound;
	[SerializeField]
	AudioClip DownstabDashSound;
	[SerializeField]
	AudioClip DownstabImpactSound;
	[SerializeField]
	GameObject DownstabBurst;
	[SerializeField]
	GameObject DownstabSlam;

	[Space]
	[Header("Airdash")]
	[SerializeField]
	float AirDashHeight = 31.5f;
	[SerializeField]
	TouchingPlayer DashChecker;
	[SerializeField]
	float dashSpeed = 32f;
	[SerializeField]
	float reverseDashSpeed = 20f;
	[SerializeField]
	AudioClip DashSoundEffect;
	[SerializeField]
	GameObject DashBurst;
	[SerializeField]
	GameObject DashSlash;
	[SerializeField]
	GameObject DashSlashHit;


	[Space]
	[Header("Stun")]
	[SerializeField]
	GameObject StunEffect;
	[SerializeField]
	float StunPushAmount = 10f;
	[SerializeField]
	ParticleSystem ShakeGas;



	public float IdleCounter { get; set; }
	public float RanFloat { get; set; }
	public bool DownStabbing { get; set; }
	public bool InDownstabRange
	{
		get
		{
			return DownstabChecker.IsTouchingPlayer;
		}
	}

	public bool WillEvade { get; set; }
	public bool InEvadeRange
	{
		get
		{
			return EvadeChecker.IsTouchingPlayer;
		}
	}
	public bool EvadeCheck { get; set; }

	public bool WillOverhead { get; set; }
	public bool InOverHeadRange
	{
		get
		{
			return OverheadSlashChecker.IsTouchingPlayer;
		}
	}

	public bool DidAirDash { get; set; }
	public bool WillAirDash { get; set; }
	public bool InDashRange
	{
		get
		{
			return DashChecker.IsTouchingPlayer;
		}
	}
	public bool Angry { get; set; }


	float jumpWeight = 1f;
	float downstabWeight = 0.5f;
	float dashWeight = 1f;

	float gravityScaleCache = 0f;


	/// <summary>
	/// The amount of times corrupted kin has jump attacked
	/// </summary>
	public int TimesJumped { get; private set; }
	/// <summary>
	/// The amount of times corrupted kin has downstabbed
	/// </summary>
	public int TimesDownstabbing { get; private set; }
	/// <summary>
	/// The amount of times corrupted kin has Dash attacked
	/// </summary>
	public int TimesDashed { get; private set; }

	public bool IsGrounded
	{
		get
		{
			return terrainCollisions.Count > 0;
		}
	}

	public bool IsFacingRight
	{
		get
		{
			return !renderer.flipX;
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

		gravityScaleCache = rigidbody.gravityScale;

		base.Awake();

		if (CoreInfo.LoadState == WeaverCore.Enums.RunningState.Editor)
		{
			StartBossBattle();
		}
	}

	public void StartBossBattle()
	{
		StartBoundRoutine(StartBossBattleRoutine());
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
				renderer.flipX = true;
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

		WeaverCore.Assets.AreaTitle.Spawn("Lost", "Kin");

		yield return Roar(2.4f, HollowKnightScream);

		yield return animator.PlayAnimationTillDone("Roar End");


		EntityHealth.Invincible = false;

		IdleCounter = 0.75f;

		yield return Idle();
	}


	public IEnumerator Idle()
	{
		while (true)
		{
			DownStabbing = false;

			animator.PlayAnimation("Walk");

			FacePlayer();

			//Get random walkspeed
			var walkSpeed = Random.Range(idleMovementSpeedMin, idleMovementSpeedMax);

			//Flip at random
			walkSpeed = Random.value >= 0.5f ? walkSpeed : -walkSpeed;


			rigidbody.velocity = new Vector2(walkSpeed, 0f);

			if (WillEvade && InEvadeRange)
			{
				yield return Evade();
				continue;
			}

			if (WillOverhead & InOverHeadRange)
			{
				yield return Overhead();
				continue;
			}

			var waitTime = Random.Range(idleTimeMin, idleTimeMax);
			if (IdleCounter < waitTime)
			{
				waitTime = IdleCounter;
			}
			yield return new WaitForSeconds(waitTime);
			IdleCounter -= waitTime;

			yield return DoAttack();
		}
	}

	//Sideways evade
	IEnumerator Evade()
	{
		if (EvadeCheck == true)
		{
			yield return Attack_Jump();
			yield break;
		}
		rigidbody.velocity = default(Vector2);

		FacePlayer(false);

		var xScale = transform.GetXLocalScale();

		var speed = evadeSpeed * xScale;

		if (!IsFacingRight)
		{
			speed *= -1f;
		}

		yield return animator.PlayAnimationTillDone("Evade Antic");

		rigidbody.velocity = new Vector2(speed,0f);

		WeaverAudio.PlayAtPoint(JumpSound, transform.position);

		yield return new WaitForSeconds(0.19f);

		rigidbody.velocity = default(Vector2);
		WeaverAudio.PlayAtPoint(LandSound, transform.position);

		yield return animator.PlayAnimationTillDone("Evade Recover");

		//TODO : LOOK AT "To Attack?" event, that is where this continues
		throw new NotImplementedException();
	}

	//Overhead jump
	IEnumerator Overhead()
	{
		WillOverhead = false;

		animator.PlayAnimation("Overhead Antic");
		rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(0.65f);

		StartBoundRoutine(PlaySlashSounds(4,0.25f));

		OverheadSlash.gameObject.SetActive(true);

		OverheadSlash.PlayAnimation("Overhead Slash");

		yield return animator.PlayAnimationTillDone("Overhead Slashing");

		OverheadSlash.gameObject.SetActive(false);

		UpdateCounters();
	}

	void UpdateCounters()
	{
		IdleCounter = Random.Range(0.5f,0.75f);

		RanFloat = Random.Range(0f, 100f);

		if (RanFloat > 55f)
		{
			WillEvade = true;
		}
		else
		{
			WillEvade = false;
		}

		RanFloat = Random.Range(0f, 100f);

		if (RanFloat > 75f)
		{
			WillOverhead = true;
		}
		else
		{
			WillOverhead = false;
		}
	}

	//Picks an attack to do

	//ALSO: The original version has a "miss" system, where it keeps track of how many times an attack
	//wasn't executed, and will force it to run after a set amount of times
	IEnumerator DoAttack()
	{
		float totalWeight = jumpWeight + downstabWeight + dashWeight;

		var randomValue = Random.Range(0, totalWeight);

		if (randomValue <= jumpWeight)
		{
			yield return Attack_Jump();
			TimesJumped++;
			yield break;
		}
		randomValue -= jumpWeight;
		if (randomValue <= downstabWeight)
		{
			yield return Attack_DownStab();
			TimesDownstabbing++;
			yield break;
		}
		else
		{
			yield return Attack_Dash();
			TimesDashed++;
			yield break;
		}
	}

	IEnumerator Attack_DownStab()
	{
		DownStabbing = true;
		yield return Attack_Jump();
	}

	IEnumerator Attack_Jump()
	{
		rigidbody.velocity = default(Vector2);
		DidAirDash = false;

		yield return FacePlayerRoutine();

		yield return animator.PlayAnimationTillDone("Jump Antic");

		float jumpX = 0f;

		if (DownStabbing)
		{
			var selfX = transform.GetXPosition();
			var heroX = transform.GetXPosition();

			jumpX = (selfX - heroX) * 2.5f;
		}
		else
		{
			jumpX = Random.Range(leftX, rightX);
			var selfX = transform.GetXPosition();
			jumpX -= selfX;
			jumpX *= 1.25f;
		}

		WeaverAudio.PlayAtPoint(JumpSound, transform.position);

		animator.PlayAnimation("Jump");

		var jumpY = jumpHeight;

		rigidbody.velocity = new Vector2(jumpX,jumpY);

		yield return null;

		bool falling = false;

		while (true)
		{
			yield return null;

			bool aboveDownstabHeight = false;
			bool aboveAirDashHeight = false;

			if (transform.position.y > MinDownstabHeight)
			{
				Debug.Log("Above Down stab height");
				aboveDownstabHeight = true;
			}
			if (transform.position.y > AirDashHeight)
			{
				Debug.Log("Above Air Dash Height");
				aboveAirDashHeight = true;
			}

			if (!falling && rigidbody.velocity.y < 0f)
			{
				Debug.Log("Falling");
				falling = true;
			}

			if (falling && IsGrounded)
			{
				Debug.Log("IS GROUNDED!");
				//LAND logic
				WeaverAudio.PlayAtPoint(LandSound, transform.position);
				rigidbody.velocity = default(Vector2);
				yield return animator.PlayAnimationTillDone("Land");
				yield return ToNextAttack();
				yield break;
			}

			if (DownStabbing && InDownstabRange && aboveDownstabHeight)
			{
				Debug.Log("DOWNSTABBING");
				WeaverAudio.PlayAtPoint(DownstabPrepareSound, transform.position);
				rigidbody.velocity = default(Vector2);
				rigidbody.gravityScale = 0f;
				yield return animator.PlayAnimationTillDone("Downstab Antic Quick");

				WeaverAudio.PlayAtPoint(DownstabDashSound, transform.position);
				animator.PlayAnimation("Downstab");

				rigidbody.velocity = new Vector2(0f, -60f);
				rigidbody.gravityScale = gravityScaleCache;

				DownstabBurst.SetActive(true);

				yield return WaitTillTouchingGround();

				WeaverAudio.PlayAtPoint(DownstabImpactSound, transform.position);
				rigidbody.velocity = default(Vector2);
				DownstabSlam.SetActive(true);

				WeaverCam.Instance.Shaker.Shake(WeaverCore.Enums.ShakeType.EnemyKillShake);

				//TODO - SPAWN PROJECTILES

				yield return animator.PlayAnimationTillDone("Downstab Land");

				animator.PlayAnimation("Idle");

				yield return new WaitForSeconds(0.35f);

				UpdateCounters();
				break;
			}
			if (aboveAirDashHeight && WillAirDash)
			{
				Debug.Log("AIR DASHING");
				transform.SetYPosition(AirDashHeight);
				rigidbody.gravityScale = 0f;

				FacePlayer(false);

				rigidbody.velocity = default(Vector2);

				yield return animator.PlayAnimationTillDone("Dash Antic 1");

				yield return DashPart2();
				break;
			}
		}
	}

	IEnumerator ToNextAttack()
	{
		if (Angry)
		{
			UpdateCounters();
		}
		else if (DidAirDash)
		{
			UpdateCounters();
		}
		else
		{
			var randVal = Random.Range(0f, 1f);

			if (randVal < 0.33f)
			{
				yield return Attack_DownStab();
			}
			else
			{
				UpdateCounters();
			}
		}
	}

	IEnumerator Attack_Dash()
	{
		//TODO
		//throw new NotImplementedException();
		if (InDashRange)
		{
			//THERE IS A COUNTER HERE IN THE ORIGINAL
			yield return Attack_DownStab();
		}
		else
		{
			WillAirDash = false;
			if (Random.value <= 0.7f)
			{
				//DASH
				WeaverAudio.PlayAtPoint(PrepareSound, transform.position);
				rigidbody.gravityScale = 0f;

				FacePlayer(false);

				var scale = transform.GetXLocalScale();

				var reverseSpeed = reverseDashSpeed * scale;

				if (IsFacingRight)
				{
					reverseSpeed = -reverseSpeed;
				}

				rigidbody.velocity = new Vector2(reverseSpeed,0f);

				yield return animator.PlayAnimationTillDone("Dash Antic 1");

				yield return DashPart2();
			}
			else
			{
				WillAirDash = true;
			}
		}
	}

	IEnumerator DashPart2()
	{
		var scale = transform.GetXLocalScale();

		var speed = dashSpeed * scale;

		if (!IsFacingRight)
		{
			speed = -speed;
		}

		animator.PlayAnimation("Dash Antic 2");

		rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(0.4f);

		animator.PlayAnimation("Dash Antic 3");

		WeaverAudio.PlayAtPoint(DashSoundEffect, transform.position);

		DashBurst.SetActive(true);

		rigidbody.velocity = new Vector2(speed,0f);

		yield return animator.PlayAnimationTillDone("Dash Attack 1");

		WeaverAudio.PlayAtPoint(DashSoundEffect, transform.position);

		DashSlash.SetActive(true);
		DashSlashHit.SetActive(true);

		yield return animator.PlayAnimationTillDone("Dash Attack 2");

		DashSlashHit.SetActive(false);

		yield return animator.PlayAnimationTillDone("Dash Attack 3");

		rigidbody.velocity = default(Vector2);

		rigidbody.gravityScale = gravityScaleCache;

		if (WillAirDash)
		{
			//FALL LOGIC
			animator.PlayAnimation("Fall");
			WillAirDash = false;
			DidAirDash = true;

			yield return WaitTillTouchingGround();

			yield return ToNextAttack();
		}
		else
		{
			yield return animator.PlayAnimationTillDone("Dash Recover");
			UpdateCounters();
		}
	}


	public void FaceObject(Transform t, bool playAnimation = true)
	{
		//If the object is to the right
		if (t.position.x > transform.position.x)
		{
			if (renderer.flipX == false)
			{
				if (playAnimation)
				{
					StartCoroutine(FlipDirection("TurnToWalk"));
				}
				else
				{
					renderer.flipX = !renderer.flipX;
				}
			}
		}
		//If the object is to the left
		else if (t.position.x < transform.position.x)
		{
			if (renderer.flipX == true)
			{
				if (playAnimation)
				{
					StartCoroutine(FlipDirection("TurnToWalk"));
				}
				else
				{
					renderer.flipX = !renderer.flipX;
				}
			}
		}
	}

	public IEnumerator FaceObjectRoutine(Transform t, bool playAnimation = true)
	{
		//If the object is to the right
		if (t.position.x > transform.position.x)
		{
			if (renderer.flipX == false)
			{
				if (playAnimation)
				{
					yield return FlipDirection("TurnToWalk");
				}
				else
				{
					renderer.flipX = !renderer.flipX;
				}
			}
		}
		//If the object is to the left
		else if (t.position.x < transform.position.x)
		{
			if (renderer.flipX == true)
			{
				if (playAnimation)
				{
					yield return FlipDirection("TurnToWalk");
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

		yield return animator.PlayAnimationTillDone(animation);

		renderer.flipX = !renderer.flipX;

		if (previousAnimation != null)
		{
			animator.PlayAnimation(animation);
		}
	}

	public void FacePlayer(bool playAnimation = true)
	{
		FaceObject(Player.Player1.transform,playAnimation);
	}

	public IEnumerator FacePlayerRoutine(bool playAnimation = true)
	{
		yield return FaceObjectRoutine(Player.Player1.transform,playAnimation);
	}

	IEnumerator WaitTillTouchingGround()
	{
		while (!IsGrounded)
		{
			yield return null;
		}
	}

	IEnumerator PlaySlashSounds(int times, float delayBetweenSounds = 0.25f)
	{
		for (int i = 0; i < times; i++)
		{
			WeaverAudio.PlayAtPoint(SwordSlashSound, transform.position);
			yield return new WaitForSeconds(delayBetweenSounds);
		}
	}

	List<GameObject> terrainCollisions = new List<GameObject>();

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			Debug.Log("Touching Ground Tile");
			terrainCollisions.Add(collision.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			Debug.Log("Stopped touching Ground Tile");
			terrainCollisions.Remove(collision.gameObject);
		}
	}


	protected override void OnDeath()
	{
		//TODO
		base.OnDeath();

		StartCoroutine(DeathRoutine());
	}

	IEnumerator DeathRoutine()
	{
		throw new NotImplementedException();
	}

	protected override void OnStun()
	{
		//TODO
		base.OnStun();

		StartCoroutine(StunRoutine());
	}

	IEnumerator StunRoutine()
	{
		GameObject.Instantiate(StunEffect, transform.position, Quaternion.identity);

		FacePlayer(false);

		var xScale = transform.GetXLocalScale();
		var movementAmount = xScale * StunPushAmount;

		if (IsFacingRight)
		{
			movementAmount = -movementAmount;
		}

		animator.PlayAnimation("Stun Air");

		//TODO - SET RECOIL SPEED

		ShakeGas.Stop(false, ParticleSystemStopBehavior.StopEmitting);

		rigidbody.gravityScale = gravityScaleCache;

		rigidbody.velocity = new Vector2(movementAmount,20f);

		DashSlashHit.SetActive(false);
		DashSlash.SetActive(false);
		OverheadSlash.gameObject.SetActive(false);

		yield return WaitTillTouchingGround();

		rigidbody.velocity = default(Vector2);

		animator.PlayAnimation("Stun");

		float timesHitBefore = HealthManager.TimesHit;

		for (float i = 0; i < 3f; i += Time.deltaTime)
		{
			if (HealthManager.TimesHit > timesHitBefore)
			{
				break;
			}
		}

		yield return animator.PlayAnimationTillDone("Stun Recover");


		StartBoundRoutine(Idle());
	}



	public GameObject GetChild(string name)
	{
		return transform.Find(name).gameObject;
	}

	public T GetChild<T>(string name)
	{
		return transform.Find(name).GetComponent<T>();
	}
}
