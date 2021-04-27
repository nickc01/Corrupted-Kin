using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeaverCore;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class SpecialMoves : CorruptedKinMove
{
	public enum SpecialMoveType
	{
		InfectionRain,
		BombRain,
		ParasiteHoard,
		WaveBarrage,
		BurrowMove
	}

	[Header("General Stuff")]
	[SerializeField]
	AudioClip RumbleSound;
	[SerializeField]
	AudioClip RoarSound;
	[SerializeField]
	[Tooltip("The height of the ceiling relative to Kin.FloorY")]
	float ceilingHeight = 12.8727f;
	[SerializeField]
	[Tooltip("THe height where objects will be activated, relative to Kin.FloorY")]
	float activationHeight = 7.5727f;
	[SerializeField]
	[Tooltip("The delay before the special attacks begin")]
	float startDelay = 0.2f;

	[Space]
	[Header("Infection Rain")]
	[SerializeField]
	float rainStartDelay = 1f;
	[SerializeField]
	float rainRoarDelay = 0.3f;
	[SerializeField]
	[Tooltip("An offset applied to the left-most bounds of the spawn area")]
	float rainLeftOffset;
	[SerializeField]
	[Tooltip("An offset applied to the right-most bounds of the spawn area")]
	float rainRightOffset;
	[SerializeField]
	[Tooltip("How many particles will spawn per second")]
	float rainParticlesPerSec;
	[SerializeField]
	[Tooltip("How long the particles will be spawning for")]
	float rainTime = 8f;
	[SerializeField]
	[Tooltip("How long of a delay before moving to the next special move")]
	float rainEndDelay = 2f;
	[SerializeField]
	[Tooltip("The prefab that will be instatiated during the move")]
	InfectionRainParticle rainPrefab;
	[SerializeField]
	[Tooltip("The rumble effect applied to the camera")]
	RumbleType rainRumbleType = RumbleType.RumblingMed;
	[SerializeField]
	[Tooltip("Determines how often a particle shot should target the player directly. For example, if the Player Shot Interval is set to 3, then every 3rd shot targets the player")]
	int rainPlayerShotInterval = 5;
	[SerializeField]
	ParticleSystem rainRoofDustPrefab;

	[Space]
	[Header("Bomb Rain")]
	[SerializeField]
	[Tooltip("The prefab used when spawning the bombs")]
	SpecialScutterBomb bombPrefab;
	[SerializeField]
	[Tooltip("How many bombs will spawn per second")]
	//float bombsPerSecond = 3.5f;
	Vector2 bombsPerSecondMinMax = new Vector2(1.1f,1.4f);
	[SerializeField]
	[Tooltip("How long the bombs will be spawning for")]
	float bombTime = 10f;
	[SerializeField]
	[Tooltip("How long of a delay before going to the next move")]
	float bombEndDelay = 2f;
	[SerializeField]
	float bombLeftSideAmount = 5f;
	[SerializeField]
	float bombRightSideAmount = 5f;
	[SerializeField]
	float bombLeftSideOffset = 0.7f;
	[SerializeField]
	float bombRightSideOffset = 0.7f;

	[Space]
	[Header("Parasite Hoard")]
	[SerializeField]
	//[Tooltip("How fast the parasites will spawn")]
	//float parasitesPerSecond = 2.9f;
	[Tooltip("The min and max spawnrate of the parasites. How many parasites spawn per second")]
	Vector2 parasitesPerSecond = new Vector2(1.4f, 4.4f);
	[SerializeField]
	[Tooltip("A range around the player where parasites cannot spawn. Used to prevent parasites from spawning right below the player")]
	float safetyRange = 2f;
	[SerializeField]
	[Tooltip("How long the parasite hoard will last")]
	float parasiteTime = 8f;
	[SerializeField]
	[Tooltip("A delay before moving on to the next move")]
	float endDelay = 3f;
	[SerializeField]
	[Tooltip("A multiplier applied to each parasite to increase their health")]
	float parasiteHealthMultiplier = 2.4f;
	[SerializeField]
	[Tooltip("The height where the parasites will spawn. This value is relative to Kin.FloorY")]
	float parasiteSpawnY = -3f;
	[SerializeField]
	[Tooltip("The z position of the parasites when they spawn")]
	float parasiteZ = 0.3f;
	[SerializeField]
	[Tooltip("The minimum vertical velocity that the parasites will play at when spawned")]
	float parasiteVerticalVelocityMin = 4f;
	[SerializeField]
	[Tooltip("The maximum vertical velocity that the parasites will play at when spawned")]
	float parasiteVerticalVelocityMax = 8f;
	[SerializeField]
	[Tooltip("The min and max speed of the spawned parasites")]
	Vector2 parasiteSpeedMinMax = new Vector2(3.5f,6.5f);
	[SerializeField]
	[Tooltip("The acceleration of the parasites")]
	float parasiteAcceleration = 10f;
	[SerializeField]
	float parasitePlayerStillSpeedIncrease = 2f;
	[SerializeField]
	float parasitePlayerStillRateIncrease = 1.5f;

	[Space]
	[Header("Wave Barrage")]
	[SerializeField]
	[Tooltip("How many waves per second should fire")]
	float wavesPerSecond = 2.5f;
	[SerializeField]
	[Tooltip("How long the wave barrage should last")]
	float barrageTime = 10f;
	[SerializeField]
	[Tooltip("The delay before the waves start coming")]
	float barrageStartDelay = 0.5f;
	[SerializeField]
	[Tooltip("The delay before the next move begins")]
	float barrageEndDelay = 1f;
	[SerializeField]
	[Tooltip("The minimum multiplier applied to the height of the waves")]
	float barrageWaveHeightMin = 0.5f;
	[SerializeField]
	[Tooltip("The maximum multiplier applied to the height of the waves")]
	float barrageWaveHeightMax = 1f;
	[SerializeField]
	[Tooltip("The type of camera rumble applied during the barrage")]
	RumbleType barrageRumbleType = RumbleType.RumblingMed;
	[SerializeField]
	[Tooltip("How far from the center of the screen should the offscreen wave spawn")]
	float barrageWaveSpawnX = 30f;
	[SerializeField]
	[Tooltip("A randomness applied to the spawning of the waves")]
	Vector2 barrageRandomTimeMinMax = new Vector2(-0.1f,0.1f);

	[Space]
	[Header("Burrow Move")]
	[SerializeField]
	[Tooltip("The delay before the move starts")]
	float burrowStartDelay = 0f;
	[SerializeField]
	[Tooltip("The delay before moving to the next move")]
	float burrowEndDelay = 0f;
	[SerializeField]
	[Tooltip("How many times Corrupted Kin should burrow and jump out of the wave system")]
	int burrowTimes = 3;
	[SerializeField]
	[Tooltip("The height where the boss will stay burrowed at. This value is relative to Kin.FloorY")]
	float burrowHeight = -5f;
	[SerializeField]
	[Tooltip("How long should the boss follow the player around during the burrowing state")]
	float burrowTrackPlayerTime = 1f;
	[SerializeField]
	Vector2 burrowTrackTimeRandomness = new Vector2(0f,0.4f);
	[SerializeField]
	[Tooltip("This is an extra delay applied to only the first time the boss burrows into the infection wave")]
	float burrowFirstTimeTrackDelay = 1f;
	[SerializeField]
	[Tooltip("After tracking the player, how long will the boss take before actually jumping out of the wave system")]
	float burrowJumpDelay = 0.35f;
	[SerializeField]
	bool burrowJumpApplyCameraShake = true;
	[SerializeField]
	ShakeType burrowJumpShakeType = ShakeType.AverageShake;
	[SerializeField]
	[Tooltip("How much velocity should the boss have when jumping out of the wave system")]
	float burrowJumpVelocity = 20f;
	[SerializeField]
	[Tooltip("How fast should the boss fall back down to the ground after jumping")]
	float burrowSlamVelocity = 20f;
	[SerializeField]
	[Tooltip("How long should the boss stay in the air after jumping, before falling back into the wave")]
	float airTime = 0.5f;
	[SerializeField]
	[Tooltip("The height the boss will reach before stopping. This value is relative to Kin.FloorY")]
	float burrowMaximumHeight = 20f;
	[SerializeField]
	float burrowAcceleration = 7.5f;
	[SerializeField]
	float burrowTerminalVelocity = 10f;
	[SerializeField]
	float burrowSlamWaveSpacing = 2.8f;
	[SerializeField]
	float burrowSlamWaveHeightMultiplier = 0.75f;
	[SerializeField]
	[Tooltip("The height multiplier for the waves that are created when the boss slams back into the waves")]
	float burrowAfterEffectWaveHeight = 0.2f;
	[SerializeField]
	float burrowJumpGravityScale = 0.1f;
	[SerializeField]
	bool burrowApplyGravity = false;
	[SerializeField]
	AudioClip BurrowSound;
	[SerializeField]
	float burrowSoundVolume = 0.65f;
	[SerializeField]
	AudioClip BurrowEmergeSound;


	/// <summary>
	/// The height where objects have their colliders activated. Note that this is relative to <see cref="CorruptedKin.FloorY"/>
	/// </summary>
	public float ActivationHeight
	{
		get
		{
			return activationHeight;
		}
	}

	float _leftWallX = float.NaN;
	public float LeftWallX
	{
		get
		{
			if (float.IsNaN(_leftWallX))
			{
				var hit = Physics2D.Raycast(new Vector2(Kin.MiddleX, ActivationHeight + Kin.FloorY), Vector2.left, 25, LayerMask.GetMask("Terrain"));
				if (hit.collider == null)
				{
					_leftWallX = Kin.LeftX;
				}
				else
				{
					_leftWallX = hit.point.x;
				}
			}
			return _leftWallX;
		}
	}

	float _rightWallX = float.NaN;
	public float RightWallX
	{
		get
		{
			if (float.IsNaN(_rightWallX))
			{
				var hit = Physics2D.Raycast(new Vector2(Kin.MiddleX, ActivationHeight + Kin.FloorY), Vector2.right, 25, LayerMask.GetMask("Terrain"));
				if (hit.collider == null)
				{
					_rightWallX = Kin.RightX;
				}
				else
				{
					_rightWallX = hit.point.x;
				}
			}
			return _rightWallX;
		}
	}

	IEnumerator<SpecialMoveType> MoveGenerator;
	int moveBatchCount = 3;

	public override IEnumerator DoMove()
	{
		var previousParasiteState = Kin.DoParasiteSpawning;
		Kin.DoParasiteSpawning = false;
		Kin.GuaranteedNextMove = null;
		Kin.HealthManager.Invincible = true;
		yield return JumpIntoCeiling();

		if (MoveGenerator == null)
		{
			MoveGenerator = GetMoveGenerator().GetEnumerator();
		}

		for (int i = 0; i < moveBatchCount; i++)
		{
			MoveGenerator.MoveNext();
			yield return RunSpecialMove(MoveGenerator.Current);
		}

		//yield return BurrowMove();

		//yield return BombRain();
		//yield return ParasiteHoard();

		/*yield return WaveBarrage();

		var movesList = EnumUtilities.GetAllEnumValues<SpecialMoveType>().ToList();
		movesList.RandomizeList();

		for (int i = 0; i < 3; i++)
		{
			yield return RunSpecialMove(movesList[i]);
		}*/


		Kin.HealthManager.Invincible = false;
		yield return JumpOutOfCeiling();
		Kin.DoParasiteSpawning = previousParasiteState;
	}

	IEnumerable<SpecialMoveType> GetMoveGenerator()
	{
		var randomList = EnumUtilities.GetAllEnumValues<SpecialMoveType>().ToList();
		randomList.RandomizeList();

		SpecialMoveType? lastMove = null;

		while (true)
		{
			if (randomList.Count < moveBatchCount)
			{
				var additionalElements = EnumUtilities.GetAllEnumValues<SpecialMoveType>().ToList();
				if (randomList.Contains(SpecialMoveType.BurrowMove))
				{
					additionalElements.RemoveAll(move => move == SpecialMoveType.BurrowMove);
				}
				additionalElements.RandomizeList();
				randomList.AddRange(additionalElements);
			}

			if (randomList[0] == SpecialMoveType.BurrowMove)
			{
				SwapElement(randomList, 0, 1);
			}

			if (randomList[moveBatchCount - 1] == SpecialMoveType.BurrowMove)
			{
				SwapElement(randomList, moveBatchCount - 1, moveBatchCount - 2);
			}

			if (lastMove != null && lastMove.Value == randomList[0])
			{
				SwapElement(randomList,0, moveBatchCount - 1);
			}

			for (int i = 0; i < moveBatchCount; i++)
			{
				var move = randomList[i];
				lastMove = move;
				yield return move;
			}
			randomList.RemoveRange(0, moveBatchCount);
		}

		//int batchIndex = 0;

		/*while (true)
		{
			if (batchIndex == 0)
			{

			}*/
			/*if (batchIndex == 0 && randomList[0] == SpecialMoveType.BurrowMove)
			{
				if (randomList.Count == 1)
				{
					var randomElements = EnumUtilities.GetAllEnumValues<SpecialMoveType>().ToList();
					randomElements.RemoveAll(move => move == SpecialMoveType.BurrowMove);
					randomElements.RandomizeList();
					randomList.AddRange(randomElements);
				}
				SwapElement(randomList, 0, 1);
			}
			else if (batchIndex == moveBatchCount - 1 && randomList[0] == SpecialMoveType.BurrowMove)
			{

			}*/
		//}
	}

	static void SwapElement<T>(List<T> list, int indexA, int indexB)
	{
		T temp = list[indexA];
		list[indexA] = list[indexB];
		list[indexB] = temp;
	}

	IEnumerator RunSpecialMove(SpecialMoveType type)
	{
		switch (type)
		{
			case SpecialMoveType.InfectionRain:
				return InfectionRain();
			case SpecialMoveType.BombRain:
				return BombRain();
			case SpecialMoveType.ParasiteHoard:
				return ParasiteHoard();
			case SpecialMoveType.WaveBarrage:
				return WaveBarrage();
			case SpecialMoveType.BurrowMove:
				return BurrowMove();
			default:
				return null;
		}
	}

	BurrowWave burrowWave;
	AudioPlayer rumbleSoundInstance;

	IEnumerator BurrowMove()
	{
		yield return new WaitForSeconds(burrowStartDelay);

		Kin.Collider.enabled = false;
		Kin.Rigidbody.isKinematic = true;
		Kin.Rigidbody.velocity = default(Vector2);

		var spawnPos = Kin.MiddleX;

		if (Player.Player1.transform.position.x >= Kin.MiddleX)
		{
			spawnPos = Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.75f);
		}
		else
		{
			spawnPos = Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.75f);
		}

		transform.position = new Vector3(spawnPos, burrowHeight + Kin.FloorY,Kin.transform.position.z);

		burrowWave = GameObject.Instantiate(WaveSlams.BurrowWave, transform.position, Quaternion.identity);
		InfectionWave.System.AddGenerator(burrowWave);

		float x_velocity = 0f;
		rumbleSoundInstance = Audio.PlayAtPointLooped(BurrowSound, transform.position, burrowSoundVolume);

		for (int i = 0; i < burrowTimes; i++)
		{
			//var targetPos = Player.Player1.transform.position.x;
			/*var targetPos = Kin.MiddleX;
			if (Player.Player1.transform.position.x >= Kin.MiddleX)
			{
				targetPos = Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.7f);
			}
			else
			{
				targetPos = Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.7f);
			}*/
			x_velocity = 0f;
			/*if (Player.Player1.transform.position.x >= transform.position.x)
			{
				x_velocity = -burrowTerminalVelocity;
			}
			else
			{
				x_velocity = burrowTerminalVelocity;
			}*/
			CameraShaker.Instance.SetRumble(RumbleType.RumblingMed);
			rumbleSoundInstance.Play();
			//TODO : Play Rumbling Sound
			burrowWave.FadeInWave();
			burrowWave.PlayParticles();
			bool canJump = false;

			var trackTime = burrowTrackPlayerTime + UnityEngine.Random.Range(burrowTrackTimeRandomness.x, burrowTrackTimeRandomness.y);

			yield return new WaitForSeconds(0.6f);

			if (i == 0)
			{
				trackTime += burrowFirstTimeTrackDelay;
			}

			for (float t = 0; t < trackTime || (t >= trackTime && !canJump); t += Time.deltaTime)
			{
				/*var targetPos = Kin.MiddleX;
				if (Player.Player1.transform.position.x >= Kin.MiddleX)
				{
					targetPos = Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.7f);
				}
				else
				{
					targetPos = Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.7f);
				}*/
				if (Player.Player1.transform.position.x >= transform.position.x)
				{
					x_velocity += burrowAcceleration * Time.deltaTime;
				}
				else
				{
					x_velocity -= burrowAcceleration * Time.deltaTime;
				}
				x_velocity = Mathf.Clamp(x_velocity, -burrowTerminalVelocity, burrowTerminalVelocity);

				transform.SetXPosition(transform.GetXPosition() + (x_velocity * Time.deltaTime));
				burrowWave.transform.SetXPosition(transform.GetXPosition());
				//transform.position = transform.position.With(x: transform.position.x + (x_velocity * Time.deltaTime));
				//burrowWave.transform.position = burrowWave.transform.position.With(

				canJump = transform.position.x >= Kin.LeftX && transform.position.x <= Kin.RightX;

				yield return null;
			}

			x_velocity = 0f;

			yield return new WaitForSeconds(burrowJumpDelay);
			rumbleSoundInstance.StopPlaying();
			//DO THE JUMP
			//Kin.Rigidbody.isKinematic = true;
			//Kin.Rigidbody.gravityScale = burrowJumpGravityScale;
			//Kin.Rigidbody.velocity = new Vector2(0f, burrowJumpVelocity);
			//TODO : Play Sound when jumping
			if (burrowJumpApplyCameraShake)
			{
				CameraShaker.Instance.Shake(burrowJumpShakeType);
			}
			CameraShaker.Instance.SetRumble(RumbleType.None);
			Renderer.flipX = !Renderer.flipX;
			Audio.PlayAtPoint(BurrowEmergeSound, transform.position);
			Animator.PlayAnimation("Jump");
			burrowWave.FadeOutWave();
			burrowWave.StopParticles();
			SlamWave leftWave, rightWave;
			WaveSlams.SpawnSlam(InfectionWave.System, transform.position,out leftWave, out rightWave, burrowSlamWaveSpacing);
			leftWave.SizeToSpeedRatio *= burrowSlamWaveHeightMultiplier;
			rightWave.SizeToSpeedRatio *= burrowSlamWaveHeightMultiplier;

			//yield return new WaitUntil(() => transform.position.y > Kin.FloorY + 0.1f);
			//Kin.Collider.enabled = true;
			//Kin.HealthManager.Invincible = false;
			//yield return new WaitUntil(() => transform.position.y >= burrowMaximumHeight + Kin.FloorY);

			var verticalVelocity = burrowJumpVelocity;

			while (transform.position.y <= Kin.FloorY + 0.1f)
			{
				transform.SetYPosition(transform.GetYPosition() + (verticalVelocity * Time.deltaTime));
				if (burrowApplyGravity)
				{
					verticalVelocity += Physics2D.gravity.y * burrowJumpGravityScale * Time.deltaTime;
				}
				yield return null;
			}
			Blood.SpawnBlood(transform.position, new Blood.BloodSpawnInfo(30, 30, 10f, 35f, 20f, 160f, null));
			Kin.Flasher.FlashInfected();
			Kin.Collider.enabled = true;
			Kin.HealthManager.Invincible = false;
			while (transform.position.y < burrowMaximumHeight + Kin.FloorY)
			{
				transform.SetYPosition(transform.GetYPosition() + (verticalVelocity * Time.deltaTime));
				if (burrowApplyGravity)
				{
					verticalVelocity += Physics2D.gravity.y * burrowJumpGravityScale * Time.deltaTime;
				}
				yield return null;
			}

			//Blood.SpawnDirectionalBlood(transform.position, CardinalDirection.Up);

			//Kin.Rigidbody.velocity = default(Vector2);
			//Kin.Rigidbody.isKinematic = true;
			//TODO : Play Blood Particles with no collision
			var downstabDuration = Animator.AnimationData.GetClipDuration("Downstab Antic Quick");

			//Debug.Log("Downstab Duration = " + downstabDuration);
			//Debug.Log("Air Time = " + airTime);
			//Debug.Log("PlayBack Speed = " + (downstabDuration / airTime));

			Animator.PlaybackSpeed = downstabDuration / airTime;
			yield return Animator.PlayAnimationTillDone("Downstab Antic Quick");
			Animator.PlaybackSpeed = 1f;
			//Kin.Rigidbody.isKinematic = false;

			var downstabMove = GetComponent<DownslashMove>();

			downstabMove.PlayDownslashEffects();
			/*Audio.PlayAtPoint(downstabMove.DownstabDashSound, transform.position);
			Animator.PlayAnimation("Downstab");
			//Kin.Rigidbody.velocity = new Vector2(0f,-burrowSlamVelocity);
			downstabMove.DownstabBurst.SetActive(true);*/

			verticalVelocity = burrowSlamVelocity;

			while (transform.position.y > Kin.FloorY)
			{
				transform.SetYPosition(transform.GetYPosition() + (verticalVelocity * Time.deltaTime));
				if (burrowApplyGravity)
				{
					verticalVelocity += Physics2D.gravity.y * burrowJumpGravityScale * Time.deltaTime;
				}
				yield return null;
			}
			//yield return new WaitUntil(() => transform.position.y <= Kin.FloorY + (burrowSlamVelocity * Time.fixedDeltaTime));
			Kin.Collider.enabled = false;
			Kin.HealthManager.Invincible = true;
			while (transform.position.y > burrowHeight + Kin.FloorY)
			{
				transform.SetYPosition(transform.GetYPosition() + (verticalVelocity * Time.deltaTime));
				if (burrowApplyGravity)
				{
					verticalVelocity += Physics2D.gravity.y * burrowJumpGravityScale * Time.deltaTime;
				}
				yield return null;
			}
			//yield return new WaitUntil(() => transform.position.y <= burrowHeight + Kin.FloorY);
			//Kin.Rigidbody.isKinematic = true;
			//Kin.Rigidbody.velocity = default(Vector2);
			//Kin.Rigidbody.gravityScale = Kin.GravityScale;

			transform.SetYPosition(burrowHeight + Kin.FloorY);
			//OPTIONAL : PLAY LANDING SOUND

			//SlamWave leftWave, rightWave;
			WaveSlams.SpawnSlam(Kin.InfectionWave.System, transform.position.x, out leftWave, out rightWave, burrowSlamWaveSpacing);
			leftWave.SizeToSpeedRatio *= burrowAfterEffectWaveHeight;
			rightWave.SizeToSpeedRatio *= burrowAfterEffectWaveHeight;
			Animator.PlayAnimation("Idle");
			yield return new WaitForSeconds(0.1f);
		}

		rumbleSoundInstance.Delete();
		rumbleSoundInstance = null;

		transform.position = new Vector3(Kin.MiddleX,ceilingHeight + Kin.FloorY, Kin.transform.position.z);

		burrowWave.DestroyWave();
		burrowWave = null;

		yield return new WaitForSeconds(burrowEndDelay);

		yield break;
	}

	public override void OnStun()
	{
		CameraShaker.Instance.SetRumble(RumbleType.None);
		if (rumbleSoundInstance != null)
		{
			rumbleSoundInstance.Delete();
			rumbleSoundInstance = null;
		}
		Kin.Rigidbody.gravityScale = Kin.GravityScale;
		Kin.HealthManager.Invincible = false;
		Animator.PlaybackSpeed = 1f;
		Kin.Collider.enabled = true;
		Kin.Rigidbody.isKinematic = false;
		if (burrowWave != null)
		{
			burrowWave.DestroyWave();
			burrowWave = null;
		}
		base.OnStun();
	}

	IEnumerator WaveBarrage()
	{
		CameraShaker.Instance.SetRumble(barrageRumbleType);
		var rumble = Audio.PlayAtPointLooped(RumbleSound, new Vector3(Kin.MiddleX, Kin.FloorY + 10f, 0f));

		bool leftSide = Player.Player1.transform.position.x < Kin.MiddleX;
		InfectionWave.BeginWaveRumble();
		/*if (leftSide)
		{
			InfectionWave.TiltTowardsLeft();
		}
		else
		{
			InfectionWave.TiltTowardsRight();
		}*/

		yield return new WaitForSeconds(barrageStartDelay);

		float secsPerWave = 1f / wavesPerSecond;

		float actualTime = secsPerWave + UnityEngine.Random.Range(barrageRandomTimeMinMax.x, barrageRandomTimeMinMax.y);
		float spawnTimer = actualTime;

		for (float t = 0; t < barrageTime; t += Time.deltaTime)
		{
			spawnTimer += Time.deltaTime;
			if (spawnTimer >= actualTime)
			{
				spawnTimer -= actualTime;
				actualTime = secsPerWave + UnityEngine.Random.Range(barrageRandomTimeMinMax.x, barrageRandomTimeMinMax.y);
				var scaleFactor = SpawnBarrageWave(leftSide);
				actualTime += scaleFactor / 2f;
			}
			yield return null;
		}

		CameraShaker.Instance.SetRumble(RumbleType.None);
		InfectionWave.EndWaveRumble();
		rumble.Delete();
		//InfectionWave.ResetTilt();

		yield return new WaitForSeconds(barrageEndDelay);

		yield break;
	}

	//Spawns a wave and returns the wave's scale factor
	float SpawnBarrageWave(bool leftSide)
	{
		SlamWave wave = null;
		if (leftSide)
		{
			//Kin.WaveSlams.SpawnSlam(Kin.InfectionWave.System, Kin.MiddleX - barrageWaveSpawnX);
			wave = Kin.WaveSlams.SpawnOffScreenWave(Kin.InfectionWave.System, Kin.MiddleX + barrageWaveSpawnX);
		}
		else
		{
			//Kin.WaveSlams.SpawnSlam(Kin.InfectionWave.System, Kin.MiddleX + barrageWaveSpawnX);
			wave = Kin.WaveSlams.SpawnOffScreenWave(Kin.InfectionWave.System, Kin.MiddleX - barrageWaveSpawnX);
		}
		var scaleFactor = UnityEngine.Random.Range(barrageWaveHeightMin, barrageWaveHeightMax);
		wave.SizeToSpeedRatio *= scaleFactor;
		return scaleFactor;
	}

	IEnumerator JumpIntoCeiling()
	{
		var jumpMove = GetComponent<JumpMove>();

		var jumpRoutine = Kin.StartBoundRoutine(jumpMove.Jump(transform.position.x, ceilingHeight + 2f));
		//StartCoroutine(jumpMove.Jump());

		yield return new WaitUntil(() => transform.position.y >= activationHeight + Kin.FloorY);

		Kin.Collider.enabled = false;

		yield return new WaitUntil(() => KinRigidbody.velocity.y <= 0f);

		KinRigidbody.velocity = default(Vector2);

		Kin.StopBoundRoutine(jumpRoutine);
		KinRigidbody.isKinematic = true;
		Audio.PlayAtPoint(Kin.HeavyLandSound, transform.position);

		yield return new WaitForSeconds(startDelay);

		yield break;
	}

	IEnumerator JumpOutOfCeiling()
	{
		if (Player.Player1.transform.position.x >= Kin.MiddleX)
		{
			transform.position = transform.position.With(x: Mathf.Lerp(Kin.MiddleX,Kin.LeftX,0.5f));
		}
		else
		{
			transform.position = transform.position.With(x: Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.5f));
		}
		Animator.PlayAnimation("Fall");
		Kin.AudioPlayer.Play(Kin.FallSound);
		KinRigidbody.isKinematic = false;

		yield return new WaitUntil(() => transform.position.y <= activationHeight + Kin.FloorY);
		Kin.Collider.enabled = true;

		yield return Kin.WaitTillTouchingGround();

		AudioPlayer.Play(Kin.HeavyLandSound);


		yield return Animator.PlayAnimationTillDone("Land");

		yield break;
	}

	/// <summary>
	/// How long the player has been standing still for
	/// </summary>
	float PlayerBeenStillFor = 0f;
	float playerPosition = 0f;

	IEnumerator PlayerStillChecker(float delay)
	{
		yield return new WaitForSeconds(delay);
		while (true)
		{
			if (Mathf.Abs(Player.Player1.transform.position.x - playerPosition) >= 1f)
			{
				playerPosition = Player.Player1.transform.position.x;
				PlayerBeenStillFor = 0f;
			}
			else
			{
				PlayerBeenStillFor += Time.deltaTime;
			}
			yield return null;
		}
	}

	IEnumerator ParasiteHoard()
	{
		float secsPerParasite = 1f / UnityEngine.Random.Range(parasitesPerSecond.x,parasitesPerSecond.y);
		float spawnTimer = 0f;

		var stillRoutine = StartCoroutine(PlayerStillChecker(1f));

		for (float t = 0; t < parasiteTime; t += Time.deltaTime)
		{
#if UNITY_EDITOR
			Debug.DrawLine(new Vector3(Kin.MiddleX - (safetyRange / 2f),Kin.FloorY), new Vector3(Kin.MiddleX + (safetyRange / 2f), Kin.FloorY),Color.green);
#endif	
			spawnTimer += Time.deltaTime;
			if (spawnTimer >= secsPerParasite)
			{
				spawnTimer -= secsPerParasite;
				var balloon = SpawnParasite(Kin.MiddleX - (safetyRange / 2f), Kin.MiddleX + (safetyRange / 2f));
				if (PlayerBeenStillFor > 1.5f)
				{
					//Debug.Log("Player Is Still!");
					balloon.Speed = parasiteSpeedMinMax + new Vector2(parasitePlayerStillSpeedIncrease, parasitePlayerStillSpeedIncrease);
					balloon.Acceleration = parasiteAcceleration;
					secsPerParasite = 1f / UnityEngine.Random.Range(parasitesPerSecond.x + parasitePlayerStillRateIncrease, parasitesPerSecond.y + parasitePlayerStillRateIncrease);
				}
				else
				{
					balloon.Speed = parasiteSpeedMinMax;
					balloon.Acceleration = parasiteAcceleration;
					secsPerParasite = 1f / UnityEngine.Random.Range(parasitesPerSecond.x, parasitesPerSecond.y);
				}
			}
			yield return null;
		}

		StopCoroutine(stillRoutine);

		yield return new WaitForSeconds(endDelay);

		yield break;
	}

	ParasiteBalloon SpawnParasite(float safeZoneLeft, float safeZoneRight)
	{
		var spawnX = UnityEngine.Random.Range(LeftWallX,RightWallX);
		if (spawnX >= safeZoneLeft && spawnX <= safeZoneRight)
		{
			if (spawnX >= Player.Player1.transform.position.x)
			{
				if (safeZoneRight < RightWallX)
				{
					spawnX = UnityEngine.Random.Range(safeZoneRight, RightWallX);
				}
				else
				{
					spawnX = UnityEngine.Random.Range(LeftWallX, safeZoneLeft);
				}
			}
			else
			{
				if (safeZoneLeft > LeftWallX)
				{
					spawnX = UnityEngine.Random.Range(LeftWallX, safeZoneLeft);
				}
				else
				{
					spawnX = UnityEngine.Random.Range(safeZoneRight,RightWallX);
				}
			}
		}

		var balloon = ParasiteBalloon.Spawn(new Vector3(spawnX, parasiteSpawnY + Kin.FloorY, parasiteZ), new Vector2(0f,UnityEngine.Random.Range(parasiteVerticalVelocityMin,parasiteVerticalVelocityMax)));
		balloon.Health.Health = Mathf.RoundToInt(balloon.Health.Health * parasiteHealthMultiplier);
		return balloon;
	}


	IEnumerator BombRain()
	{
		Debug.DrawLine(new Vector3(RightWallX - bombRightSideOffset, ceilingHeight + Kin.FloorY, 0f), new Vector3(RightWallX - bombRightSideOffset - bombRightSideAmount, ceilingHeight + Kin.FloorY, 0f), Color.red, bombTime);
		Debug.DrawLine(new Vector3(LeftWallX + bombLeftSideOffset, ceilingHeight + Kin.FloorY, 0f), new Vector3(LeftWallX + bombLeftSideOffset + bombLeftSideAmount, ceilingHeight + Kin.FloorY, 0f), Color.green, bombTime);

		float secsPerBomb = 1f / UnityEngine.Random.Range(bombsPerSecondMinMax.x, bombsPerSecondMinMax.y);
		float spawnTimer = 0f;

		bool firstBomb = true;

		for (float t = 0; t < bombTime; t += Time.deltaTime)
		{
			spawnTimer += Time.deltaTime;

			if (spawnTimer >= secsPerBomb)
			{
				spawnTimer -= secsPerBomb;
				SpawnBomb(firstBomb);
				firstBomb = false;
				secsPerBomb = 1f / UnityEngine.Random.Range(bombsPerSecondMinMax.x, bombsPerSecondMinMax.y);
			}

			yield return null;
		}

		yield return new WaitForSeconds(bombEndDelay);

		yield break;
	}

	void SpawnBomb(bool targetPlayer)
	{
		bool leftSide = UnityEngine.Random.value >= 0.5f;
		float x_position = 0f;

		bool foundPlayer = false;
		if (targetPlayer)
		{
			var playerX = Player.Player1.transform.position.x;
			if (playerX >= Kin.MiddleX)
			{
				playerX = Mathf.Clamp(playerX, LeftWallX + bombLeftSideOffset, LeftWallX + bombLeftSideOffset + bombLeftSideAmount);
			}
			else
			{
				playerX = Mathf.Clamp(playerX, RightWallX - bombRightSideOffset - bombRightSideAmount, RightWallX - bombRightSideOffset);
			}
			/*if (playerX >= LeftWallX + bombLeftSideOffset && playerX <= LeftWallX + bombLeftSideOffset + bombLeftSideAmount)
			{
				x_position = playerX;
				foundPlayer = true;
			}
			else if (playerX <= RightWallX - bombRightSideOffset && playerX >= RightWallX - bombRightSideOffset - bombRightSideAmount)
			{
				x_position = playerX;
				foundPlayer = true;
			}*/
		}
		if (!foundPlayer)
		{
			if (leftSide)
			{
				x_position = UnityEngine.Random.Range(LeftWallX + bombLeftSideOffset, LeftWallX + bombLeftSideOffset + bombLeftSideAmount);
			}
			else
			{
				x_position = UnityEngine.Random.Range(RightWallX - bombRightSideOffset, RightWallX - bombRightSideOffset - bombRightSideAmount);
			}
		}

		var bomb = Pooling.Instantiate(bombPrefab, new Vector3(x_position, ceilingHeight + Kin.FloorY, bombPrefab.transform.position.z), Quaternion.identity);
		bomb.SourceMove = this;
		bomb.SourceBoss = Kin;
	}

	IEnumerator InfectionRain()
	{
#if UNITY_EDITOR
		Debug.DrawLine(new Vector3(RightWallX, ActivationHeight + Kin.FloorY, 0f), new Vector3(RightWallX, ActivationHeight + Kin.FloorY + 1, 0f),Color.red,2f);
		Debug.DrawLine(new Vector3(LeftWallX, ActivationHeight + Kin.FloorY, 0f), new Vector3(LeftWallX, ActivationHeight + Kin.FloorY + 1, 0f), Color.red, 2f);
#endif

		var rumble = Audio.PlayAtPointLooped(RumbleSound, new Vector3(Kin.MiddleX, Kin.FloorY + 10f, 0f));
		CameraShaker.Instance.SetRumble(rainRumbleType);

		var roofParticles = GameObject.Instantiate(rainRoofDustPrefab, new Vector3(Kin.MiddleX, ceilingHeight + Kin.FloorY), rainRoofDustPrefab.transform.rotation);

		yield return new WaitForSeconds(rainStartDelay);
		StartCoroutine(PlayRoar(rainRoarDelay));

		float secsPerParticle = 1f / rainParticlesPerSec;
		float spawnTimer = 0f;

		long shotCount = 0;

		float playerPrevPos = Player.Player1.transform.position.x;
		float playerCurPos = Player.Player1.transform.position.x;

		for (float t = 0; t < rainTime; t += Time.deltaTime)
		{
			spawnTimer += Time.deltaTime;
			playerPrevPos = playerCurPos;
			playerCurPos = Player.Player1.transform.position.x;

			if (spawnTimer >= secsPerParticle)
			{
				spawnTimer -= secsPerParticle;
				SpawnInfectionRainParticle(shotCount % rainPlayerShotInterval == 0, (playerCurPos - playerPrevPos) / Time.deltaTime);
				shotCount++;
			}

			yield return null;
		}
		CameraShaker.Instance.SetRumble(RumbleType.None);
		rumble.Delete();
		roofParticles.Stop();

		yield return new WaitForSeconds(rainEndDelay);
	}

	void SpawnInfectionRainParticle(bool targetPlayer, float playerVelocity)
	{
		float x_position = 0f;
		if (targetPlayer)
		{
			const float FALL_TIME = 1.31578f;

			x_position = Player.Player1.transform.position.x + (playerVelocity * FALL_TIME / 4f);
		}
		else
		{
			x_position = UnityEngine.Random.Range(LeftWallX + rainLeftOffset, RightWallX + rainRightOffset);
		}

		//var x_position = UnityEngine.Random.Range(Kin.LeftX + rainLeftOffset,Kin.RightX + rainRightOffset);
		var particle = Pooling.Instantiate(rainPrefab, new Vector3(x_position, ceilingHeight + Kin.FloorY, rainPrefab.transform.position.z),Quaternion.identity);
		particle.SourceMove = this;
		particle.OnRainStart();

		//var colliderBounds = particle.RainCollider.bounds;

		//Debug.Log("Collider Width = " + particle.transform.localScale.y * 0.81f);

		if (particle.transform.position.x > RightWallX - (particle.transform.localScale.y * 0.81f))
		{
			particle.transform.position = particle.transform.position.With(x: RightWallX - (particle.transform.localScale.y * 0.81f));
		}

		if (particle.transform.position.x < LeftWallX + (particle.transform.localScale.y * 0.81f))
		{
			particle.transform.position = particle.transform.position.With(x: LeftWallX + (particle.transform.localScale.y * 0.81f));
		}
	}

	IEnumerator PlayRoar(float delay)
	{
		if (delay > 0f)
		{
			yield return new WaitForSeconds(delay);
		}
		Audio.PlayAtPoint(RoarSound, new Vector3(Kin.MiddleX, Kin.FloorY + 10f, 0f));
	}
}
