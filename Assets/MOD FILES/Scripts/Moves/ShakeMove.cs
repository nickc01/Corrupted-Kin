using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Utilities;

public class ShakeMove : CorruptedKinMove
{
	public enum ShakeDirection
	{
		Left,
		Right
	}

	[SerializeField]
	[Range(1,100)]
	[Tooltip("How rare this move should occur. For example, if the value is set to 2, then it happens 1/2 as much as other moves")]
	int moveChance = 2;
	[SerializeField]
	float startDelay = 0.5f;
	[SerializeField]
	Vector2 ShakeTimeMinMax = new Vector2(4f,4f);
	[SerializeField]
	float endDelay = 1.4f;
	[SerializeField]
	AudioClip ShakeAudio;
	[SerializeField]
	ParticleSystem ShakeGas;
	[SerializeField]
	float shakeAnimationSpeed = 1f;
	[SerializeField]
	float ShakeSoundDelay;

	[Header("Shots")]
	[Space]
	[SerializeField]
	[Tooltip("The delay before the shots start firing")]
	float shotBeginDelay = 0.1f;
	[SerializeField]
	[Tooltip("The angle from the vertical the shots will start at")]
	float shotAngleStart = 20f;
	[SerializeField]
	[Tooltip("The angle from the vertical the shots will end at")]
	float shotAngleEnd = 80f;
	[SerializeField]
	int amountOfShots = 5;
	[SerializeField]
	float shotTime = 0.4f;
	[SerializeField]
	[Tooltip("If set to true, then one of the shots will aim directly at the player")]
	bool aimShotAtPlayer = true;
	[SerializeField]
	[Tooltip("Represents the range of randomness the shot angles can have")]
	Vector2 shotAngleRandomness = new Vector2(0f,5f);
	[SerializeField]
	float shotVelocity = 10f;
	[SerializeField]
	float shotGravityScale = 0.1f;
	[SerializeField]
	float shotZ = 0.01f;
	[SerializeField]
	float playerDistanceThreshold = 3f;
	[SerializeField]
	[Tooltip("How much faster will higher shots be travelling compared to lower shots")]
	float highShotSpeed = 4f;


	int _chanceCounter = -1;
	AudioPlayer shakeSound;

	float previousRecoilSpeed = 0f;

	public override bool MoveEnabled
	{
		get
		{
			if (Kin.BossStage == 2 || Kin.BossStage > 4)
			{
				_chanceCounter = (_chanceCounter + 1) % moveChance;
				return base.MoveEnabled && (_chanceCounter % moveChance == 0);
			}
			else
			{
				return false;
			}
		}
	}

	public override IEnumerator DoMove()
	{
		Kin.DoParasiteSpawning = false;
		var recoiler = GetComponent<WeaverCore.Components.Recoil>();
		var jumpMove = GetComponent<JumpMove>();

		previousRecoilSpeed = recoiler.GetRecoilSpeed();
		recoiler.SetRecoilSpeed(0f);

		float jumpX = 0f;

		if (Player.Player1.transform.position.x >= Kin.MiddleX)
		{
			jumpX = Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.5f);
		}
		else
		{
			jumpX = Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.5f);
		}

		var jumpRoutine = Kin.StartBoundRoutine(jumpMove.Jump(jumpX));

		yield return new WaitForSeconds(0.1f);

		yield return new WaitUntil(() => !jumpMove.Jumping);

		Debug.Log("DOING SHAKE MOVE");
		KinRigidbody.velocity = default(Vector2);

		yield return Animator.PlayAnimationTillDone("Shake Antic");

		Kin.StartBoundRoutine(PlayShakeSound());
		Animator.PlaybackSpeed = shakeAnimationSpeed;
		Animator.PlayAnimation("Shake Loop");
		ShakeGas.Play();

		yield return new WaitForSeconds(startDelay);

		//TEMP
		var waitTime = UnityEngine.Random.Range(ShakeTimeMinMax.x, ShakeTimeMinMax.y);

		int previousFrame = -100;

		for (float t = 0; t < waitTime; t += Time.deltaTime)
		{
			var currentFrame = Animator.PlayingFrame;
			if (previousFrame >= 0 && currentFrame != previousFrame)
			{
				//shakeattack_14 - Back
				if (currentFrame == 9 || currentFrame == 3)
				{
					Kin.StartBoundRoutine(FireShots(Kin.Renderer.flipX ? ShakeDirection.Right : ShakeDirection.Left));
				}

				//shakeattack_5 - Forth
				if (currentFrame == 0 || currentFrame == 6)
				{
					Kin.StartBoundRoutine(FireShots(Kin.Renderer.flipX ? ShakeDirection.Left : ShakeDirection.Right));
				}
			}

#if UNITY_EDITOR
			var firePos = transform.position + (Vector3)GetFirePosition();
			Debug.DrawLine(firePos, firePos + Vector3.up, Color.blue);
#endif

			previousFrame = currentFrame;
			yield return null;
		}

		//yield return new WaitForSeconds();
		Animator.PlaybackSpeed = 1f;
		Animator.PlayAnimation("Shake End");
		recoiler.SetRecoilSpeed(previousRecoilSpeed);
		Kin.DoParasiteSpawning = true;
		shakeSound.Delete();
		ShakeGas.Stop();
		shakeSound = null;

		yield return new WaitForSeconds(endDelay);

		if (Kin.GuaranteedNextMove == this)
		{
			Kin.GuaranteedNextMove = null;
		}

	}

	IEnumerator PlayShakeSound()
	{
		if (ShakeSoundDelay > 0f)
		{
			yield return new WaitForSeconds(ShakeSoundDelay);
		}

		shakeSound = Audio.PlayAtPointLooped(ShakeAudio, transform.position);
	}

	class Shot
	{
		public float Angle;
		public float Velocity;
	}

	IEnumerator FireShots(ShakeDirection direction)
	{

		Shot[] Shots = new Shot[amountOfShots];

		var middleAngle = Mathf.Lerp(shotAngleStart, shotAngleEnd,0.5f);

		for (int i = 0; i < amountOfShots; i++)
		{
			var baseAngle = Mathf.Lerp(shotAngleStart,shotAngleEnd,i / (float)(amountOfShots - 1));
			float angle = 0f;

			if (direction == ShakeDirection.Left)
			{
				angle = 90f + baseAngle;
			}
			else
			{
				angle = 90f - baseAngle;
			}

			Shots[i] = new Shot
			{
				Angle = angle + UnityEngine.Random.Range(shotAngleRandomness.x, shotAngleRandomness.y),
				Velocity = shotVelocity
			};

			if (baseAngle < middleAngle)
			{
				Shots[i].Velocity += Mathf.Lerp(0f, highShotSpeed, Mathf.InverseLerp(middleAngle,shotAngleStart,baseAngle));
			}
		}

		yield return new WaitForSeconds(shotBeginDelay);

		var distanceToPlayer = Vector3.Distance(Player.Player1.transform.position, transform.position);

		if ((Player.Player1.transform.position.x > Kin.transform.position.x && direction == ShakeDirection.Right) || (Player.Player1.transform.position.x <= Kin.transform.position.x && direction == ShakeDirection.Left))
		{
			var toPlayerVelocity = MathUtilties.CalculateVelocityToReachPoint(transform.position, Player.Player1.transform.position, (1f / shotVelocity) * distanceToPlayer, shotGravityScale);

			int closest = -1;
			float closestVelocity = float.PositiveInfinity;
			for (int i = 0; i < amountOfShots; i++)
			{
				if (closest < 0)
				{
					closest = i;
					closestVelocity = Vector2.Distance(toPlayerVelocity, MathUtilties.PolarToCartesian(Shots[i].Angle, Shots[i].Velocity));
				}
				else
				{
					var velocityDifference = Vector2.Distance(toPlayerVelocity, MathUtilties.PolarToCartesian(Shots[i].Angle, Shots[i].Velocity));
					if (velocityDifference < closestVelocity)
					{
						closest = i;
						closestVelocity = velocityDifference;
					}
				}
			}

			if (closest != -1 && aimShotAtPlayer)
			{
				var playerShotAngle = MathUtilties.CartesianToPolar(toPlayerVelocity);
				Shots[closest].Angle = playerShotAngle.x;
				Shots[closest].Velocity = playerShotAngle.y;
			}
		}


		if (aimShotAtPlayer && Mathf.Abs(transform.position.x - Player.Player1.transform.position.x) < playerDistanceThreshold)
		{
			var secondsPerUnit = 1f / shotVelocity;
			AspidShot.Spawn(transform.position, Player.Player1.transform.position, secondsPerUnit * distanceToPlayer,shotGravityScale);
		}

		for (int i = 0; i < amountOfShots; i++)
		{
			if (Animator.PlayingClip != "Shake Loop")
			{
				yield break;
			}
			var shot = AspidShot.Spawn(transform.position + (Vector3)GetFirePosition(), Shots[i].Angle, Shots[i].Velocity);
			shot.transform.SetZPosition(shotZ);
			shot.Rigidbody.gravityScale = shotGravityScale;
			yield return new WaitForSeconds(shotTime / amountOfShots);
		}

		//MathUtilties.CalculateVelocityToReachPoint(transform.position,Player.Player1.transform.position,)

		yield break;
	}

	public Vector2 GetFirePosition()
	{
		if (Animator.PlayingClip != "Shake Loop")
		{
			throw new Exception("The Shake Clip is not playing");
		}

		Vector2 result = default(Vector2);

		Vector2[] framePositions = new Vector2[]
		{
			new Vector2(-1.11f, -0.41f),
			new Vector2(-1.11f, 0.04f),
			new Vector2(0.69f, 0f),
			new Vector2(0.99f, -0.43f),
			new Vector2(0.8f, 0.51f),
			new Vector2(-0.77f, 0.06f),
			new Vector2(-1.12f, -0.5f),
			new Vector2(-0.8f, 0.25f),
			new Vector2(0.85f, -0.2f),
			new Vector2(1.04f, -0.48f),
			new Vector2(0.83f, 0.12f)
		};

		var secsPerFrame = 1f / Animator.AnimationData.GetClipFPS(Animator.PlayingClip);
		var frameTime = Animator.FrameTime;
		var currentFrame = Animator.PlayingFrame;
		var totalFrames = Animator.AnimationData.GetClipFrameCount(Animator.PlayingClip);

		var firstPosition = framePositions[currentFrame];
		var secondPosition = framePositions[(currentFrame + 1) % totalFrames];

		result = Vector2.Lerp(firstPosition, secondPosition, frameTime / secsPerFrame);

		/*switch (Animator.PlayingFrame)
		{
			case 0:
				result = new Vector2(-1.11f, -0.41f);
				break;
			case 1:
				result = new Vector2(-1.11f, 0.04f);
				break;
			case 2:
				result = new Vector2(0.69f, 0f);
				break;
			case 3:
				result = new Vector2(0.99f, -0.43f);
				break;
			case 4:
				result = new Vector2(0.8f, 0.51f);
				break;
			case 5:
				result = new Vector2(-0.77f, 0.06f);
				break;
			case 6:
				result = new Vector2(-1.12f, -0.5f);
				break;
			case 7:
				result = new Vector2(-0.8f, 0.25f);
				break;
			case 8:
				result = new Vector2(0.85f, -0.2f);
				break;
			case 9:
				result = new Vector2(1.04f, -0.48f);
				break;
			case 10:
				result = new Vector2(0.83f, 0.12f);
				break;
			default:
				throw new Exception("Frame not accounted for: " + Animator.PlayingFrame);
		}*/
		if (Kin.Renderer.flipX)
		{
			result.x = -result.x;
		}
		return result;
	}

	public override void OnStun()
	{
		Animator.PlaybackSpeed = 1f;
		GetComponent<Recoil>().SetRecoilSpeed(previousRecoilSpeed);
		GetComponent<JumpMove>().OnStun();
		if (Kin.BossStage == 2 || Kin.BossStage >= 4)
		{
			Kin.DoParasiteSpawning = true;
		}

		if (shakeSound != null)
		{
			shakeSound.Delete();
			shakeSound = null;
		}

		ShakeGas.Stop();
		base.OnStun();
	}
}

