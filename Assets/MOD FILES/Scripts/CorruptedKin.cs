using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Audio;
using WeaverCore;
using WeaverCore.Assets.Components;
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
	CorruptedKinHealth healthManager;
	new Collider2D collider;
	WeaverCore.Components.DamageHero damager;

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
	CorruptedKinGlobals Globals;
	[SerializeField]
	BoxCollider2D awakeRange;



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
	[SerializeField]
	float fallDelay = 0.3f;

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
	BoxCollider2D EvadeChecker;

	[Space]
	[Header("Overhead Slash")]
	[SerializeField]
	WeaverAnimationPlayer OverheadSlash;
	[SerializeField]
	BoxCollider2D OverheadSlashChecker;


	[Space]
	[Header("Downstab")]
	[SerializeField]
	float MinDownstabHeight = 33.31f;
	[SerializeField]
	BoxCollider2D DownstabChecker;
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
	[SerializeField]
	KinProjectile KinProjectilePrefab;
	[SerializeField]
	Vector3 KinProjectileOffset = new Vector3(0f,-0.5f,0f);

	[Space]
	[Header("Airdash")]
	[SerializeField]
	float AirDashHeight = 31.5f;
	[SerializeField]
	BoxCollider2D DashChecker;
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
	float StunPushAmount = 10f;
	[SerializeField]
	ParticleSystem ShakeGas;

	[Space]
	[Header("Death")]
	[SerializeField]
	AudioClip BossFinalHitSound;
	[SerializeField]
	GameObject InfectedDeathWavePrefab;
	[SerializeField]
	AudioClip BossGushingSound;
	[SerializeField]
	GameObject BossDeathPuffPrefab;
	[SerializeField]
	AudioClip DreamExitSound;


	[SerializeField]
	float bloodSpawnDelay = 0.1f;
	[SerializeField]
	AudioClip BossExplosionSound;
	[SerializeField]
	GameObject DeathExplosionPrefab;
	[SerializeField]
	ParticleSystem CorpseSteam;



	public float IdleCounter { get; set; }
	public float RanFloat { get; set; }
	public bool DownStabbing { get; set; }
	public bool InDownstabRange
	{
		get
		{
			//return true;
			//NORMAL
			//return DownstabChecker.IsTouchingPlayer;
			var playerX = Player.Player1.transform.GetXPosition();
			var selfX = transform.GetXPosition();

			float dStabRange = 1.42f;


			return playerX >= selfX - (dStabRange / 2f) && playerX <= selfX + (dStabRange / 2f);
		}
	}

	public bool WillEvade { get; set; }
	public bool InEvadeRange
	{
		get
		{
			return IsWithinBox(EvadeChecker, Player.Player1.transform);//EvadeChecker.IsTouchingPlayer;
		}
	}
	public bool EvadeCheck { get; set; }

	public bool WillOverhead { get; set; }
	public bool InOverHeadRange
	{
		get
		{
			//return true;
			//Normal
			//return OverheadSlashChecker.IsTouchingPlayer;
			return IsWithinBox(OverheadSlashChecker, Player.Player1.transform);
		}
	}

	public bool DidAirDash { get; set; }
	public bool WillAirDash { get; set; }
	public bool InDashRange
	{
		get
		{
			//return DashChecker.IsTouchingPlayer;
			return IsWithinBox(DashChecker, Player.Player1.transform);
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
		WeaverLog.Log("BOSS AWAKE!");

		CorruptedKinGlobals.Instance = Globals;

		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<WeaverAnimationPlayer>();
		renderer = GetComponent<SpriteRenderer>();
		audioPlayer = GetComponent<WeaverAudioPlayer>();
		healthManager = GetComponent<CorruptedKinHealth>();
		collider = GetComponent<Collider2D>();
		damager = GetComponent<WeaverCore.Components.DamageHero>();



		rigidbody.isKinematic = true;

		rigidbody.gravityScale = 3.25f;
		Shadow = GetChild("Shadow");
		animator.PlayAnimation("Idle");
		Shadow.SetActive(false);
		EntityHealth.Invincible = true;
		renderer.enabled = false;

		gravityScaleCache = rigidbody.gravityScale;
		rigidbody.velocity = default(Vector2);

		base.Awake();

		var quarterHealth = healthManager.Health / 4;

		AddStunMilestone(quarterHealth);
		AddStunMilestone(quarterHealth * 2);
		AddStunMilestone(quarterHealth * 3);

		if (CoreInfo.LoadState == WeaverCore.Enums.RunningState.Editor)
		{
			StartBossBattle();
		}
		else
		{
			WeaverLog.Log("WAITING FOR PLAYER!");
			WeaverLog.Log("ENABLED = " + gameObject.activeSelf);
			StartCoroutine(WaitForPlayer());
		}
	}

	IEnumerator WaitForPlayer()
	{
		var playerCollider = Player.Player1.GetComponent<Collider2D>();

		WeaverLog.Log("Waiting for player");


		while (true)
		{
			var pBounds = playerCollider.bounds;
			var awakeBounds = awakeRange.bounds;

			//if (pBounds.max.y < awakeBounds.max.y && pBounds.max.x >= awakeBounds.min.x && pBounds.min.x <= awakeBounds.max.x)
			if (Player.Player1.transform.position.y <= transform.position.y + 1f && pBounds.max.x >= leftX && pBounds.min.x <= rightX)
			{
				break;
			}
			yield return null;
		}

		awakeRange.gameObject.SetActive(false);

		/*while (!IsWithinBox(playerCollider,awakeRange))
		{
			WeaverLog.Log("Player not in box");
			WeaverLog.Log("Player Pos = " + playerCollider.transform.position);
			WeaverLog.Log("Awake Range = " + awakeRange.transform.position);
			yield return null;
		}*/

		WeaverLog.Log("Starting Battle!");
		StartBossBattle();
	}

	public void StartBossBattle()
	{
		StartBoundRoutine(StartBossBattleRoutine());
	}


	IEnumerator StartBossBattleRoutine()
	{
		WeaverEvents.BroadcastEvent("DREAM GATE CLOSE", gameObject);
		rigidbody.isKinematic = false;

		if (Boss.InGodHomeArena)
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

		/*if (Player.Player1 != null)
		{
			WeaverLog.Log("Player Location = " + Player.Player1.transform.position);
			WeaverLog.Log("Enemy Location = " + transform.position);
		}*/

		yield return new WaitForSeconds(fallDelay);

		yield return WaitTillTouchingGround();

		Debug.Log("Ground Touched!");

		audioPlayer.Play(LandSoundEffect);


		yield return animator.PlayAnimationTillDone("Land");


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

		WeaverCore.Assets.AreaTitle.Spawn("Corrupted", "Kin");

		yield return Roar(2.4f, HollowKnightScream);

		yield return animator.PlayAnimationTillDone("Roar End");


		EntityHealth.Invincible = false;

		IdleCounter = 0.75f;

		//OnDeath();
		yield return Idle();
	}


	public IEnumerator Idle()
	{
		while (true)
		{

			//WillEvade = true;
			//WillOverhead = true;
			//yield return Overhead();
			//yield return Attack_DownStab();



			//continue;
			//NORMAL STUFF
			Debug.Log("IDLING");
			DownStabbing = false;

			animator.PlayAnimation("Walk");

			FacePlayer();

			if (WillEvade && InEvadeRange)
			{
				Debug.Log("EVADING");
				yield return Evade();
				continue;
			}

			if (WillOverhead & InOverHeadRange)
			{
				Debug.Log("OVERHEADING");
				yield return Overhead();
				continue;
			}

			//Get random walkspeed
			var walkSpeed = Random.Range(idleMovementSpeedMin, idleMovementSpeedMax);

			//Flip at random
			walkSpeed = Random.value >= 0.5f ? walkSpeed : -walkSpeed;

			rigidbody.velocity = new Vector2(walkSpeed, 0f);
			Debug.Log("SETTING VELOCITY = " + rigidbody.velocity);

			var waitTime = Random.Range(idleTimeMin, idleTimeMax);
			if (IdleCounter < waitTime)
			{
				waitTime = IdleCounter;
			}
			Debug.Log("WAITING FOR = " + waitTime);
			yield return new WaitForSeconds(waitTime);
			IdleCounter -= waitTime;

			rigidbody.velocity = new Vector2(0f, 0f);

			Debug.Log("ATTACKING");
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

		WillEvade = false;

		rigidbody.velocity = default(Vector2);

		yield return FacePlayerRoutine();

		var xScale = transform.GetXLocalScale();

		var speed = evadeSpeed * xScale;

		if (IsFacingRight)
		{
			speed *= -1f;
		}

		yield return animator.PlayAnimationTillDone("Evade Antic");

		rigidbody.gravityScale = 0f;
		rigidbody.velocity = new Vector2(speed,0f);

		WeaverAudio.PlayAtPoint(JumpSound, transform.position);

		//yield return animator.PlayAnimationTillDone("Evade");

		animator.PlayAnimation("Evade");

		for (float timer = 0; timer < 0.19f; timer += Time.deltaTime)
		{
			if (animator.PlayingClip != "Evade")
			{
				break;
			}
			yield return null;
		}

		//yield return new WaitForSeconds(0.19f);

		rigidbody.velocity = default(Vector2);
		rigidbody.gravityScale = gravityScaleCache;
		WeaverAudio.PlayAtPoint(LandSound, transform.position);

		yield return animator.PlayAnimationTillDone("Evade Recover");

		//TODO : LOOK AT "To Attack?" event, that is where this continues
		//throw new NotImplementedException();
		yield return ToNextAttack();
	}

	//Overhead jump
	IEnumerator Overhead()
	{
		WillOverhead = false;

		animator.PlayAnimation("Overhead Antic");
		rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(0.65f);

		OverheadSlash.gameObject.SetActive(true);

		OverheadSlash.PlayAnimation("Overhead Slash");

		StartBoundRoutine(PlaySlashSounds());

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
		//else
		//{
		//	WillEvade = false;
		//}

		RanFloat = Random.Range(0f, 100f);

		if (RanFloat > 75f)
		{
			WillOverhead = true;
		}
		//else
		//{
		//	WillOverhead = false;
		//}
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
			Debug.Log("DASHING!!!");
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

		//Debug.Log("D_A");

		yield return FacePlayerRoutine(true);
		//Debug.Log("D_B");
		yield return animator.PlayAnimationTillDone("Jump Antic");
		//Debug.Log("D_C");
		float jumpX = 0f;

		if (DownStabbing)
		{
			var selfX = transform.GetXPosition();
			var heroX = Player.Player1.transform.GetXPosition();

			jumpX = Mathf.LerpUnclamped(selfX,heroX,2.5f) - selfX;
		}
		else
		{
			jumpX = Random.Range(leftX, rightX);
			var selfX = transform.GetXPosition();
			jumpX -= selfX;
			jumpX *= 1.25f;
		}
		//Debug.Log("D_D");

		WeaverAudio.PlayAtPoint(JumpSound, transform.position);

		animator.PlayAnimation("Jump");

		var jumpY = jumpHeight;

		rigidbody.velocity = new Vector2(jumpX,jumpY);

		//Debug.Log("D_E");
		yield return null;

		bool falling = false;

		while (true)
		{
			//Debug.Log("D_F");
			yield return null;

			bool aboveDownstabHeight = false;
			bool aboveAirDashHeight = false;

			if (transform.position.y > MinDownstabHeight)
			{
				//Debug.Log("Above Down stab height");
				aboveDownstabHeight = true;
			}
			if (transform.position.y > AirDashHeight)
			{
				//Debug.Log("Above Air Dash Height");
				aboveAirDashHeight = true;
			}

			if (!falling && rigidbody.velocity.y < 0f)
			{
				//Debug.Log("Falling");
				falling = true;
			}

			if (falling && IsGrounded)
			{
				//Debug.Log("IS GROUNDED!");
				//LAND logic
				WeaverAudio.PlayAtPoint(LandSound, transform.position);
				rigidbody.velocity = default(Vector2);
				//Debug.Log("A");
				yield return animator.PlayAnimationTillDone("Land");
				//Debug.Log("B");
				yield return ToNextAttack();
				//Debug.Log("C");
				yield break;
			}

			if (DownStabbing && InDownstabRange && aboveDownstabHeight)
			{
				//Debug.Log("DOWNSTABBING");
				WeaverAudio.PlayAtPoint(DownstabPrepareSound, transform.position);
				rigidbody.velocity = default(Vector2);
				rigidbody.gravityScale = 0f;
				//Debug.Log("D_G");
				yield return animator.PlayAnimationTillDone("Downstab Antic Quick");
				//Debug.Log("D_H");
				WeaverAudio.PlayAtPoint(DownstabDashSound, transform.position);
				animator.PlayAnimation("Downstab");

				rigidbody.velocity = new Vector2(0f, -60f);
				rigidbody.gravityScale = gravityScaleCache;

				DownstabBurst.SetActive(true);

				//Debug.Log("D_I");
				yield return WaitTillTouchingGround();

				WeaverAudio.PlayAtPoint(DownstabImpactSound, transform.position);
				rigidbody.velocity = default(Vector2);
				DownstabSlam.SetActive(true);

				WeaverCam.Instance.Shaker.Shake(WeaverCore.Enums.ShakeType.EnemyKillShake);

				//TODO - SPAWN PROJECTILES

				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(21, 0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(15, 0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(8,0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(-8,0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(-15,0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(-21,0));

				//Debug.Log("D_J");
				yield return animator.PlayAnimationTillDone("Downstab Land");

				animator.PlayAnimation("Idle");

				//Debug.Log("D_K");
				yield return new WaitForSeconds(0.35f);
				UpdateCounters();
				break;
			}
			if (aboveAirDashHeight && WillAirDash)
			{
				//Debug.Log("AIR DASHING");
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
				Debug.Log("DOWNSTABBING");
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
		if (!InDashRange)
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

				yield return FacePlayerRoutine(false);

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
		//If the object is to the left
		else if (t.position.x < transform.position.x)
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
	}

	public IEnumerator FaceObjectRoutine(Transform t, bool playAnimation = true)
	{
		Debug.Log("FACING OBJECT");
		Debug.Log("Self Position = " + transform.position);
		Debug.Log("Player Position = " + Player.Player1.transform.position);
		//If the object is to the right
		if (t.position.x > transform.position.x)
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
		//If the object is to the left
		else// if (t.position.x < transform.position.x)
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
	}

	IEnumerator FlipDirection(string animation)
	{
		var previousAnimation = animator.PlayingClip;
		//Debug.Log("FLIPPING_Before");
		//Debug.Log("Previous Animation = " + previousAnimation);
		//Debug.Log("Playing Animation = " + animation);
		yield return animator.PlayAnimationTillDone(animation,true);
		//Debug.Log("FLIPPING_AFTER");
		renderer.flipX = !renderer.flipX;

		if (previousAnimation != null)
		{
			animator.PlayAnimation(previousAnimation);
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

	IEnumerator PlaySlashSounds()
	{
		WeaverAudio.PlayAtPoint(SwordSlashSound, transform.position);

		yield return new WaitUntil(() => animator.PlayingFrame == 4);

		WeaverAudio.PlayAtPoint(SwordSlashSound, transform.position);

		yield return new WaitUntil(() => animator.PlayingFrame == 9);

		WeaverAudio.PlayAtPoint(SwordSlashSound, transform.position);

		yield return new WaitUntil(() => animator.PlayingFrame == 14);

		WeaverAudio.PlayAtPoint(SwordSlashSound, transform.position);
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

		StartBoundRoutine(DeathRoutine());
	}

	float emissionRate = 50f;
	float emissionSpeed = 5f;
	IEnumerator DeathRoutine()
	{
		//HERE IS WHERE A SetPlayerDataBool is located. It sets corn_abyssLeft to true

		Reset();

		damager.DamageDealt = 0;

		WeaverCam.Instance.Shaker.Shake(WeaverCore.Enums.ShakeType.AverageShake);

		WeaverAudio.PlayAtPoint(BossFinalHitSound, transform.position);

		DeactivateBattleScene();

		var deathWave = GameObject.Instantiate(InfectedDeathWavePrefab, transform.position, Quaternion.identity);

		deathWave.transform.localScale = new Vector3(3f,3f,0f);

		yield return WaitTillTouchingGround();

		if (!Boss.InGodHomeArena)
		{
			//STOP MUSIC
		}

		animator.PlayAnimation("Death Land");

		rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(1f);

		animator.PlayAnimation("Death");

		WeaverAudio.PlayAtPoint(BossGushingSound, transform.position);

		var deathPuff = GameObject.Instantiate(BossDeathPuffPrefab, transform.position + new Vector3(0f,0f,-5f), Quaternion.identity);
		var deathParticles = deathPuff.GetComponent<ParticleSystem>();


		WeaverCam.Instance.Shaker.Shake(WeaverCore.Enums.ShakeType.BigShake);
		WeaverCam.Instance.Shaker.SetRumble(WeaverCore.Enums.RumbleType.RumblingMed);

		float bloodTimer = 0f;

		for (float t = 0; t <= 3f; t += Time.deltaTime)
		{
			yield return null;
			bloodTimer += Time.deltaTime;
			if (bloodTimer >= bloodSpawnDelay)
			{
				bloodTimer -= bloodSpawnDelay;
				//SpawnBloodParticle();
				Blood.SpawnRandomBlood(transform.position);
			}


			emissionRate += (5f * 60f) * Time.deltaTime;
			emissionSpeed += (1f * 60f) * Time.deltaTime;
			if (emissionSpeed > 110f)
			{
				emissionSpeed = 110f;
			}
			var main = deathParticles.main;
			var emission = deathParticles.emission;

			main.startSpeed = emissionSpeed;
			emission.rateOverTime = emissionRate;
		}

		var previousSpeed = emissionSpeed;
		var previousRate = emissionRate;

		for (float t = 0; t < 0.5f; t += Time.deltaTime)
		{
			emissionSpeed = Mathf.Lerp(previousSpeed, 0f,t / 0.5f);
			emissionRate = Mathf.Lerp(previousSpeed,0f,t / 0.5f);
			yield return null;
		}
		if (!Boss.InGodHomeArena)
		{
			PlayerData.instance.SetBool("infectedKnightDreamDefeated", true);
		}

		yield return new WaitForSeconds(0.5f);

		if (CoreInfo.LoadState == WeaverCore.Enums.RunningState.Game)
		{
			GameManager.instance.AwardAchievement("DREAM_BROKEN_VESSEL");
		}

		WeaverCam.Instance.Shaker.SetRumble(WeaverCore.Enums.RumbleType.None);
		WeaverAudio.PlayAtPoint(BossExplosionSound, transform.position);

		GameObject.Instantiate(DeathExplosionPrefab, transform.position, Quaternion.identity);

		WeaverCam.Instance.Shaker.Shake(WeaverCore.Enums.ShakeType.BigShake);


		EndBattleScene();

		deathParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);

		CorpseSteam.Play();

		yield return animator.PlayAnimationTillDone("Death 2");

		//yield return new WaitForSeconds(5.25f);
		yield return new WaitForSeconds(0.5f);

		WeaverEvents.BroadcastEvent("IK GATE OPEN", gameObject);

		if (WeaverGame.CurrentMapZone == GlobalEnums.MapZone.DREAM_WORLD)
		{
			var essence = EssenceEffects.Spawn(transform.position);
			//Plays the essence effects and leaves the scene
			essence.PlayVanishBurstEffects();
			WeaverAudio.PlayAtPoint(DreamExitSound, Player.Player1.transform.position);
		}
		else
		{
			EndBossBattle();
		}
	}


	/*public void SpawnBloodParticle()
	{
		SpawnBlood(transform.position + bloodSpawnOffset, bloodSpawnMin, bloodSpawnMax, bloodSpeedMin, bloodSpeedMax, bloodAngleMin, bloodAngleMax, null);
	}

	private ParticleSystem.MinMaxGradient initialBloodColour;
	public void SpawnBlood(Vector3 position, short minCount, short maxCount, float minSpeed, float maxSpeed, float angleMin = 0f, float angleMax = 360f, Color? colorOverride = null)
	{
		if (this.bloodSplatterParticle)
		{
			var component = GameObject.Instantiate(bloodSplatterParticle, default(Vector3), Quaternion.identity).GetComponent<ParticleSystem>();
			//ParticleSystem component = this.bloodSplatterParticle.Spawn().GetComponent<ParticleSystem>();
			if (component)
			{
				component.Stop();
				component.emission.SetBursts(new ParticleSystem.Burst[]
				{
					new ParticleSystem.Burst(0f, (short)Mathf.RoundToInt((float)minCount * bloodAmountMultiplier), (short)Mathf.RoundToInt((float)maxCount * bloodAmountMultiplier))
				});
				ParticleSystem.MainModule main = component.main;
				main.maxParticles = Mathf.RoundToInt((float)maxCount * bloodAmountMultiplier);
				main.startSpeed = new ParticleSystem.MinMaxCurve(minSpeed * bloodSpeedMultiplier, maxSpeed * bloodSpeedMultiplier);
				if (colorOverride == null)
				{
					main.startColor = initialBloodColour;
				}
				else
				{
					main.startColor = new ParticleSystem.MinMaxGradient(colorOverride.Value);
				}
				ParticleSystem.ShapeModule shape = component.shape;
				float arc = angleMax - angleMin;
				shape.arc = arc;
				//component.transform.SetRotation2D(angleMin);
				component.transform.SetZRotation(angleMin);
				component.transform.position = position;
				component.Play();
			}
		}
	}*/

	protected override void OnStun()
	{
		//TODO
		base.OnStun();

		StartBoundRoutine(StunRoutine());
	}

	IEnumerator StunRoutine()
	{
		//GameObject.Instantiate(StunEffect, transform.position, Quaternion.identity);
		StunEffect.Spawn(transform.position);

		FacePlayer(false);

		/*var xScale = transform.GetXLocalScale();
		var movementAmount = xScale * StunPushAmount;

		if (IsFacingRight)
		{
			movementAmount = -movementAmount;
		}*/

		animator.PlayAnimation("Stun Air");

		Reset();

		//TODO - SET RECOIL SPEED

		//ShakeGas.Stop(false, ParticleSystemStopBehavior.StopEmitting);

		//rigidbody.gravityScale = gravityScaleCache;

		//rigidbody.velocity = new Vector2(movementAmount,20f);

		//DashSlashHit.SetActive(false);
		//DashSlash.SetActive(false);
		//OverheadSlash.gameObject.SetActive(false);

		yield return WaitTillTouchingGround();

		rigidbody.velocity = default(Vector2);

		animator.PlayAnimation("Stun");

		float timesHitBefore = healthManager.TimesHit;
		Debug.Log("Times Hit Before = " + timesHitBefore);

		for (float i = 0; i < 3f; i += Time.deltaTime)
		{
			Debug.Log("Times Hit = " + healthManager.TimesHit);
			if (healthManager.TimesHit > timesHitBefore)
			{
				break;
			}
			yield return null;
		}

		yield return animator.PlayAnimationTillDone("Stun Recover");


		StartBoundRoutine(Idle());
	}


	Component fsmCache = null;
	Type pmType = null;

	Component GetBattleControlFSM()
	{
		if (fsmCache == null)
		{
			var battleSceneObj = GameObject.FindGameObjectWithTag("Battle Scene");
			if (battleSceneObj != null)
			{
				var playMakerAssembly = Assembly.Load("PlayMaker");
				//var playMakerAssembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.FullName.Contains("PlayMaker"));

				pmType = playMakerAssembly.GetType("PlayMakerFSM");

				var actionHelperType = playMakerAssembly.GetType();

				var fsmGetter = actionHelperType.GetMethod("GetGameObjectFsm");


				fsmCache = (Component)fsmGetter.Invoke(null, new object[] { battleSceneObj, "Battle Control" });
			}
		}
		return fsmCache;
	}

	//Not sure if this is required for anything yet, but may remove it if it does nothing
	void DeactivateBattleScene()
	{
		if (CoreInfo.LoadState == WeaverCore.Enums.RunningState.Game)
		{
			var fsm = GetBattleControlFSM();

			if (fsm != null)
			{
				var fsmVariables = pmType.GetProperty("FsmVariables").GetValue(fsm, null);
				var fsmVarType = fsmVariables.GetType();

				var fsmBool = fsmVarType.GetMethod("FindFsmBool").Invoke(fsmVariables, new object[] { "Activated" });
				if (fsmBool != null)
				{
					var fsmBoolType = fsmBool.GetType();

					fsmBoolType.GetProperty("Value").SetValue(fsmBool, false, null);
				}
			}
		}
	}

	void EndBattleScene()
	{
		if (CoreInfo.LoadState == WeaverCore.Enums.RunningState.Game)
		{
			var fsm = GetBattleControlFSM();
			if (fsm != null)
			{
				WeaverEvents.SendEventToObject(fsm.gameObject, "END");
			}
		}
	}

	void Reset()
	{
		var xScale = transform.GetXLocalScale();
		var movementAmount = xScale * StunPushAmount;

		if (IsFacingRight)
		{
			movementAmount = -movementAmount;
		}

		rigidbody.gravityScale = gravityScaleCache;

		rigidbody.velocity = new Vector2(movementAmount, 20f);

		DashSlashHit.SetActive(false);
		DashSlash.SetActive(false);
		OverheadSlash.gameObject.SetActive(false);

		ShakeGas.Stop(false, ParticleSystemStopBehavior.StopEmitting);
	}



	public GameObject GetChild(string name)
	{
		return transform.Find(name).gameObject;
	}

	public T GetChild<T>(string name)
	{
		return transform.Find(name).GetComponent<T>();
	}

	public bool IsWithinBox(Collider2D box, Transform obj)
	{
		var bounds = box.bounds;

		var objX = obj.GetXPosition();
		var objY = obj.GetYPosition();

		return objX > bounds.min.x && objY > bounds.min.y && objX < bounds.max.x && objY < bounds.max.y;
	}

	public bool IsWithinBox(Collider2D box, Collider2D other)
	{
		var bounds = box.bounds;
		var otherBounds = other.bounds;

		return bounds.Intersects(otherBounds);

		/*var objX = obj.GetXPosition();
		var objY = obj.GetYPosition();

		return objX > bounds.min.x && objY > bounds.min.y && objX < bounds.max.x && objY < bounds.max.y;*/
	}
}
