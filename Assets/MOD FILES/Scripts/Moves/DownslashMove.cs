using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using WeaverCore;
using WeaverCore.Utilities;

public struct DownstabProperties
{
	public float HorizontalOffset;
	public Func<int,float> GetNextPosition;
	public int AmountOfTimes;
	public float DelayBetweenTimes;
	public float JumpAnticSpeed;
	public float JumpHeight;
	public bool SpawnAspidShots;
	public int AspidShotCount;
	public bool SpawnWaves;
	public float firstSlamDelay;
}

public class DownslashMove : CorruptedKinMove
{
	[SerializeField] float MinDownstabHeight = 33.31f;
	//[SerializeField] float DownstabActivationRange = 1.5f;
	[SerializeField] float DownstabVelocity = -60f;
	[SerializeField] AudioClip DownstabPrepareSound;
	[FormerlySerializedAs("DownstabDashSound")]
	[SerializeField] AudioClip downstabDashSound;
	[SerializeField] AudioClip DownstabImpactSound;
	[FormerlySerializedAs("DownstabBurst")]
	[SerializeField] GameObject downstabBurst;
	[SerializeField] GameObject DownstabSlam;
	//[SerializeField]
	//float firstDownslashDelay = 0.1f;
	//[SerializeField] Vector3 KinProjectileOffset = new Vector3(0f, -0.5f, 0f);
	[Space]
	[Header("Slam Effects")]
	//[SerializeField]
	//int aspidShots = 6;
	[SerializeField]
	Vector3 aspidShotSpawnOffset;
	[SerializeField]
	[Range(0f,45f)]
	float angleFromGround = 0f;
	[SerializeField]
	float aspidShotVelocity = 5f;
	[SerializeField]
	float aspidShotGravityScale = 0.5f;
	[SerializeField]
	float downStabAnticSpeed = 0.80f;
	[SerializeField]
	float downStabAnticSpeedPhase2 = 0.8f;
	[SerializeField]
	float downstabHorizontalOffset = 0.5f;
	[SerializeField]
	float tripleStabHorizontalOffset = 1f;
	[SerializeField]
	Collider2D slamCollider;
	[SerializeField]
	float slamColliderTime = 0.25f;
	[SerializeField]
	PoolableObject SlamEffectsPrefab;
	[SerializeField]
	Vector3 SlamEffectsOffset;
	[SerializeField]
	float wavesOffset = 2f;
	[SerializeField]
	float waveHeightMultiplier = 0.9f;

	[SerializeField]
	[Tooltip("How large of a gap is created, in degrees")]
	float groundGapSize = 15f;

	[SerializeField]
	[Tooltip("A range of possible angles for the ground gap to spawn at, measured in degrees")]
	Vector2 groundGapVariance = new Vector2(15f / 2f,45f);
	[SerializeField]
	DownslashAspidShot aspidShotPrefab;

	[SerializeField]
	float topGapAngle = 25f;

	[SerializeField]
	int aspidShotAmount = 20;

	[SerializeField]
	ParticleSystem DownslashSplash;
	[SerializeField]
	ParticleSystem DownslashPillar;
	[SerializeField]
	float angleBetweenShots = 10f;
	//[SerializeField]
	//Vector3 bloodSpawnOffset = new Vector3(0.1f,0f,0f);

#if UNITY_EDITOR
	[Space]
	[Header("Debug")]
	[SerializeField]
	bool showDebugLines = true;
	[SerializeField]
	float debugLineDuration = 0.5f;

#endif



	JumpMove jump;
	bool downstabbing;
	//PoolableObject slamColliderInstance;

	void Awake()
	{
		jump = GetComponent<JumpMove>();
	}

	public override IEnumerator DoMove()
	{
		switch (Kin.BossStage)
		{
			case 1:
				yield return DoDownstab(new DownstabProperties
				{
					AmountOfTimes = 1,
					DelayBetweenTimes = 0.2f,
					HorizontalOffset = downstabHorizontalOffset,
					JumpAnticSpeed = 1f,
					JumpHeight = jump.JumpHeight,
					SpawnAspidShots = true,
					AspidShotCount = 8
				});
				break;
			case 2:
				yield return DoDownstab(new DownstabProperties
				{
					AmountOfTimes = 3,
					DelayBetweenTimes = 0.2f,
					HorizontalOffset = tripleStabHorizontalOffset,
					JumpAnticSpeed = 0.75f,
					JumpHeight = jump.JumpHeight + 3f,
					SpawnAspidShots = true,
					AspidShotCount = 5
				});
				break;
			case 3:
				if (UnityEngine.Random.value > 0.5f)
				{
					yield return DoDownstab(new DownstabProperties
					{
						AmountOfTimes = 1,
						DelayBetweenTimes = 0.2f,
						HorizontalOffset = 0,
						JumpAnticSpeed = 0.75f,
						JumpHeight = jump.JumpHeight,
						SpawnWaves = true
					});
				}
				else
				{
					//var side = UnityEngine.Random.value > 0.5 ? Kin.LeftX : Kin.RightX;
					//float? previousPosition = null;
					float? side = null;
					yield return DoDownstab(new DownstabProperties
					{
						AmountOfTimes = 2,
						DelayBetweenTimes = 0.075f,
						HorizontalOffset = 0,
						JumpAnticSpeed = 0.75f,
						JumpHeight = jump.JumpHeight,
						SpawnWaves = true,
						GetNextPosition = (time) =>
						{
							if (time == 0)
							{
								return Player.Player1.transform.position.x;
							}
							else
							{
								if (side == null)
								{
									if (Player.Player1.transform.position.x > transform.position.x)
									{
										side = Kin.LeftX + 1f;
									}
									else
									{
										side = Kin.RightX - 1f;
									}
								}
								return side.Value;
								//return transform.position.x;
								/*if (previousPosition == null)
								{
									previousPosition = transform.position.x;
								}
								return previousPosition.Value;*/
							}
						}
					});
				}
				break;
			default:
				if (UnityEngine.Random.value > 0.5f)
				{
					bool positionSet = false;
					float position = 0f;
					yield return DoDownstab(new DownstabProperties
					{
						firstSlamDelay = 0.08f,
						AmountOfTimes = 3,
						DelayBetweenTimes = 0f,
						HorizontalOffset = tripleStabHorizontalOffset,
						JumpAnticSpeed = 0.8f,
						JumpHeight = jump.JumpHeight + 3f,
						SpawnWaves = true,
						GetNextPosition = (time) =>
						{
							if (!positionSet)
							{
								positionSet = true;
								position = Player.Player1.transform.position.x;
							}
							return position;
						}
					});
				}
				else
				{
					float? side = null;
					yield return DoDownstab(new DownstabProperties
					{
						AmountOfTimes = 3,
						DelayBetweenTimes = 0f,
						HorizontalOffset = 0,
						JumpAnticSpeed = 1f,
						JumpHeight = jump.JumpHeight,
						SpawnWaves = true,
						GetNextPosition = (time) =>
						{
							if (side == null)
							{
								if (Player.Player1.transform.position.x > transform.position.x)
								{
									side = Kin.LeftX + 1f;
								}
								else
								{
									side = Kin.RightX - 1f;
								}
							}
							return side.Value;
						}
					});
				}
				break;
		}
		/*if (Kin.BossStage == 1)
		{
			
		}
		else if ()
		{
			
		}*/
	}

	public IEnumerator DoDownstab(DownstabProperties properties)
	{
		//slamColliderInstance = null;
		float targetOffset = 0;

		if (properties.GetNextPosition == null)
		{
			properties.GetNextPosition = (time) =>
			{
				return Player.Player1.transform.position.x;
			};
		}
		/*var previousPlayerPosition = Player.Player1.transform.position;
		yield return null;
		var currentPlayerPosition = Player.Player1.transform.position;

		var playerVelocity = (currentPlayerPosition - previousPlayerPosition) / Time.deltaTime;

		if (playerVelocity.x > 0f)
		{
			targetOffset += downstabHorizontalOffset;
		}
		else if (playerVelocity.x < 0f)
		{
			targetOffset -= downstabHorizontalOffset;
		}*/

		for (int j = 0; j < properties.AmountOfTimes; j++)
		{
			/*var previousPlayerPosition = Player.Player1.transform.position;
			yield return null;
			var currentPlayerPosition = Player.Player1.transform.position;*/

			//var travelDirection = (currentPlayerPosition - previousPlayerPosition) / Time.deltaTime;

			bool fromLeft = true;

			var targetPosition = properties.GetNextPosition(j);

			if (targetPosition > transform.position.x)
			{
				//Debug.Log("FROM LEFT");
				fromLeft = true;
				targetOffset = properties.HorizontalOffset;// + (travelDirection.x * 0.5f);
			}
			else
			{
				//Debug.Log("FROM RIGHT");
				fromLeft = false;
				targetOffset = -properties.HorizontalOffset;// + (travelDirection.x * 0.5f));
			}

			if (targetPosition + targetOffset > Kin.RightX)
			{
				//Debug.Log("Right Side Clamp");
				targetOffset = Kin.RightX - targetPosition;
			}
			else if (targetPosition + targetOffset < Kin.LeftX)
			{
				//Debug.Log("Left Side Clamp");
				targetOffset = Kin.LeftX - targetPosition;
			}

			//Debug.Log("Target Position = " + targetPosition);
			//Debug.Log("Target Offset = " + targetOffset);

			var destX = Mathf.LerpUnclamped(transform.position.x, targetPosition + targetOffset, 2f);

			downstabbing = false;
			jump.JumpAnticSpeed = properties.JumpAnticSpeed;
			var jumpRoutine = Kin.StartBoundRoutine(jump.Jump(destX));

			var groundPosition = transform.position.y;

			while (Kin.IsBoundRoutineRunning(jumpRoutine))
			{
				var targetPos = properties.GetNextPosition(j);

				if (fromLeft)
				{
					if (transform.position.y >= MinDownstabHeight && transform.position.x >= targetPos + targetOffset && transform.position.x <= Kin.RightX)
					{
						downstabbing = true;
						transform.SetXPosition(properties.GetNextPosition(j) + targetOffset);
						Kin.StopBoundRoutine(jumpRoutine);
						break;
					}
					if (transform.position.y >= MinDownstabHeight && transform.position.x >= Kin.RightX - 5f && Kin.BossInCorner && Kin.PlayerInCorner)
					{
						downstabbing = true;
						Kin.StopBoundRoutine(jumpRoutine);
					}
				}
				else
				{
					if (transform.position.y >= MinDownstabHeight && transform.position.x <= targetPos + targetOffset && transform.position.x >= Kin.LeftX)
					{
						downstabbing = true;
						transform.SetXPosition(properties.GetNextPosition(j) + targetOffset);
						Kin.StopBoundRoutine(jumpRoutine);
						break;
					}
					if (transform.position.y >= MinDownstabHeight && transform.position.x <= Kin.LeftX + 5f && Kin.BossInCorner && Kin.PlayerInCorner)
					{
						downstabbing = true;
						Kin.StopBoundRoutine(jumpRoutine);
					}
				}

				/*if (transform.position.y >= MinDownstabHeight && Mathf.Abs(transform.position.x - (playerPos.x + targetOffset)) <= DownstabActivationRange)
				{
					downstabbing = true;
					Kin.StopBoundRoutine(jumpRoutine);
					break;
				}*/

				yield return null;
			}

			if (!downstabbing)
			{
				break;
			}

			if (downstabbing)
			{
				float delay = 0f;
				if (j == 0)
				{
					delay = properties.firstSlamDelay;
				}
				yield return SlamDownwards(properties.SpawnAspidShots, properties.SpawnWaves, delay, properties.AspidShotCount);
				/*Audio.PlayAtPoint(DownstabPrepareSound, transform.position);
				KinRigidbody.velocity = default(Vector2);
				KinRigidbody.gravityScale = 0f;
				Animator.PlaybackSpeed = downStabAnticSpeed;
				yield return Animator.PlayAnimationTillDone("Downstab Antic Quick");
				Animator.PlaybackSpeed = 1f;

				PlayDownslashEffects();

				KinRigidbody.velocity = new Vector2(0f, DownstabVelocity);
				KinRigidbody.gravityScale = Kin.GravityScale;

				yield return Kin.WaitTillTouchingGround();

				Audio.PlayAtPoint(DownstabImpactSound, transform.position);
				KinRigidbody.velocity = default(Vector2);
				DownstabSlam.SetActive(true);

				Pooling.Instantiate(SlamEffectsPrefab, transform.position + SlamEffectsOffset, Quaternion.identity);
				if (slamCollider != null)
				{
					slamCollider.enabled = true;
				}
				Kin.StartBoundRoutine(SlamColliderDisabler(slamColliderTime));


				CameraShaker.Instance.Shake(WeaverCore.Enums.ShakeType.EnemyKillShake);

				//TODO - SPAWN PROJECTILES

				if (properties.SpawnAspidShots)
				{

					for (int i = 0; i < aspidShots; i++)
					{
						var minAngle = ((i / (float)(aspidShots)) * (180f - (angleFromGround * 2f)));// - (180f - angleFromGround);
						var maxAngle = (((i + 1) / (float)(aspidShots)) * (180f - (angleFromGround * 2f)));// - (180f - angleFromGround);

						var shootAngle = UnityEngine.Random.Range(minAngle, maxAngle);
#if UNITY_EDITOR

						if (showDebugLines)
						{
							//var vectorAngle = new Vector2(Mathf.Cos());


							//Debug.DrawLine(transform.position)
							Debug_DrawAngle(transform.position + aspidShotSpawnOffset, minAngle, 2f, Color.red);
							Debug_DrawAngle(transform.position + aspidShotSpawnOffset, maxAngle, 2f, Color.red);

							Debug_DrawAngle(transform.position + aspidShotSpawnOffset, shootAngle, 2f, Color.green);
						}


#endif

						var aspidShot = AspidShot.Spawn(transform.position + aspidShotSpawnOffset, shootAngle, aspidShotVelocity);

						aspidShot.Rigidbody.gravityScale = aspidShotGravityScale;
					}
				}
				if (properties.SpawnWaves)
				{
					WaveSlams.SpawnSlam(InfectionWave.System, transform.position, wavesOffset);
				}*/


				//If we are on the last jump
				if (j == properties.AmountOfTimes - 1)
				{
					yield return PlayDownslashLanding();

					GetComponent<IdleMove>().DoingStreak = false;
				}
				else
				{
					yield return new WaitForSeconds(properties.DelayBetweenTimes);
				}
			}

		}
	}

	public void PlayDownslashEffects()
	{
		WeaverAudio.PlayAtPoint(downstabDashSound, transform.position);
		Animator.PlayAnimation("Downstab");
		downstabBurst.SetActive(true);
	}

	public IEnumerator PlayDownslashLanding()
	{
		yield return Animator.PlayAnimationTillDone("Downstab Land");

		Animator.PlayAnimation("Idle");

		yield return Kin.WaitUnlessAttacked(0.35f,true);
		//yield return new WaitForSeconds(0.35f);
	}

	class AngleRangeSorter : IComparer<Vector2>
	{
		static AngleRangeSorter _sorter;
		public static AngleRangeSorter Sorter
		{
			get
			{
				if (_sorter == null)
				{
					_sorter = new AngleRangeSorter();
				}
				return _sorter;
			}
		}
		Comparer<float> FloatComparer;

		public int Compare(Vector2 x, Vector2 y)
		{
			if (FloatComparer == null)
			{
				FloatComparer = Comparer<float>.Default;
			}

			return FloatComparer.Compare(x.x, y.x);
		}
	}

	struct ExcludedAngle
	{
		public float Angle;
		public float Length;
	}

	class AngleRandomizerData
	{
		public List<ExcludedAngle> ExcludedAngles;
		public float MinAngle;
		public float MaxAngle;

		public float ExcludedAngleSum;
	}

	AngleRandomizerData GetExclusions(List<Vector2> ExcludedAngleRanges,float minAngle = 0f, float maxAngle = 180f)
	{
		var totalSubtraction = 0f;
		ExcludedAngleRanges.Sort(AngleRangeSorter.Sorter);

		List<ExcludedAngle> exclusions = new List<ExcludedAngle>();

		for (int i = 0; i < ExcludedAngleRanges.Count; i++)
		{
			var min = ExcludedAngleRanges[i].x;
			var max = ExcludedAngleRanges[i].y;

			if (max <= min)
			{
				continue;
			}

			if (max <= minAngle)
			{
				continue;
			}

			if (min >= maxAngle)
			{
				continue;
			}

			if (min < minAngle)
			{
				min = minAngle;
			}

			if (max > maxAngle)
			{
				max = maxAngle;
			}

			if (exclusions.Count > 0)
			{
				var last = exclusions[exclusions.Count - 1];
				if (min >= last.Angle && min <= (last.Angle + last.Length))
				{
					if (max <= (last.Angle + last.Length))
					{
						continue;
					}
					else
					{
						totalSubtraction += max - (last.Angle + last.Length);
						last.Length += max - (last.Angle + last.Length);
						exclusions[exclusions.Count - 1] = last;
						continue;
					}
				}
			}

			/*if (i != 0 && min < ExcludedAngleRanges[i - 1].y)
			{
				min = ExcludedAngleRanges[i - 1].y;
				if (max < ExcludedAngleRanges[i - 1].y)
				{
					continue;
				}
			}*/
			totalSubtraction += max - min;
			exclusions.Add(new ExcludedAngle { Angle = min, Length = max - min });
		}

		return new AngleRandomizerData
		{
			ExcludedAngles = exclusions,
			ExcludedAngleSum = totalSubtraction,
			MaxAngle = maxAngle,
			MinAngle = minAngle
		};
	}

	float GetRandomAngle(AngleRandomizerData angleData)
	{
		if (angleData.ExcludedAngles.Count == 0)
		{
			return UnityEngine.Random.Range(angleData.MinAngle, angleData.MaxAngle);
		}

		var randMaxValue = angleData.MaxAngle - angleData.ExcludedAngleSum;

		if (randMaxValue <= angleData.MinAngle)
		{
			return float.NaN;
		}

		var randomNumber = UnityEngine.Random.Range(angleData.MinAngle, randMaxValue);

		foreach (var exclusion in angleData.ExcludedAngles)
		{
			if (randomNumber >= exclusion.Angle)
			{
				randomNumber += exclusion.Length;
			}
			else
			{
				break;
			}
		}
		return randomNumber;
	}

	float GetRandomAngle(List<Vector2> ExcludedAngleRanges, float minAngle = 0f,float maxAngle = 180f)
	{
		return GetRandomAngle(GetExclusions(ExcludedAngleRanges, minAngle, maxAngle));
		/*if (ExcludedAngleRanges == null)
		{
			return UnityEngine.Random.Range(minAngle, maxAngle);
		}
		else
		{
			var totalSubtraction = 0f;
			ExcludedAngleRanges.Sort(AngleRangeSorter.Sorter);

			List<ExcludedAngle> exclusions = new List<ExcludedAngle>();

			for (int i = 0; i < ExcludedAngleRanges.Count; i++)
			{
				var min = ExcludedAngleRanges[i].x;
				var max = ExcludedAngleRanges[i].y;

				if (max <= min)
				{
					continue;
				}

				if (max <= minAngle)
				{
					continue;
				}

				if (min >= maxAngle)
				{
					continue;
				}

				if (min < minAngle)
				{
					min = minAngle;
				}

				if (max > maxAngle)
				{
					max = maxAngle;
				}

				if (exclusions.Count > 0)
				{
					var last = exclusions[exclusions.Count - 1];
					if (min >= last.Angle && min <= (last.Angle + last.Length))
					{
						if (max <= (last.Angle + last.Length))
						{
							continue;
						}
						else
						{
							totalSubtraction += max - (last.Angle + last.Length);
							last.Length += max - (last.Angle + last.Length);
							exclusions[exclusions.Count - 1] = last;
							continue;
						}
					}
				}
				totalSubtraction += max - min;
				exclusions.Add(new ExcludedAngle { Angle = min,Length = max - min });
			}

			var randMaxValue = maxAngle - totalSubtraction;

			if (randMaxValue <= minAngle)
			{
				return float.NaN;
			}

			var randomNumber = UnityEngine.Random.Range(minAngle, randMaxValue);

			foreach (var exclusion in exclusions)
			{
				if (randomNumber >= exclusion.Angle)
				{
					randomNumber += exclusion.Length;
				}
				else
				{
					break;
				}
			}
			return randomNumber;
		}*/
	}

	public IEnumerator SlamDownwards(bool spawnAspidShots, bool spawnWaves, float extraAnticDelay, int aspidShots = 7)
	{
		WeaverAudio.PlayAtPoint(DownstabPrepareSound, transform.position);
		KinRigidbody.velocity = default(Vector2);
		KinRigidbody.gravityScale = 0f;
		var anticTime = Animator.AnimationData.GetClipDuration("Downstab Antic Quick");
		Animator.PlaybackSpeed = downStabAnticSpeed;
		if (Kin.BossStage >= 3)
		{
			Animator.PlaybackSpeed = downStabAnticSpeedPhase2;
		}
		if ((Kin.BossInLeftCorner && Kin.PlayerInLeftCorner) || (Kin.BossInRightCorner && Kin.PlayerInRightCorner))
		{
			Animator.PlaybackSpeed -= 0.12f;
		}

		Animator.PlaybackSpeed -= extraAnticDelay;
		yield return Animator.PlayAnimationTillDone("Downstab Antic Quick");
		Animator.PlaybackSpeed = 1f;

		PlayDownslashEffects();

		KinRigidbody.velocity = new Vector2(0f, DownstabVelocity);
		KinRigidbody.gravityScale = Kin.GravityScale;

		yield return Kin.WaitTillTouchingGround();

		WeaverAudio.PlayAtPoint(DownstabImpactSound, transform.position);
		KinRigidbody.velocity = default(Vector2);
		DownstabSlam.SetActive(true);

		Pooling.Instantiate(SlamEffectsPrefab, transform.position + SlamEffectsOffset, Quaternion.identity);
		if (slamCollider != null)
		{
			slamCollider.enabled = true;
		}
		Kin.StartBoundRoutine(SlamColliderDisabler(slamColliderTime));


		CameraShaker.Instance.Shake(WeaverCore.Enums.ShakeType.EnemyKillShake);

		//TODO - SPAWN PROJECTILES

		if (spawnAspidShots)
		{
			var maxAngleLeft = 180f - groundGapVariance.x;
			var minAngleLeft = 180f - groundGapVariance.y;

			var minAngleRight = groundGapVariance.x;
			var maxAngleRight = groundGapVariance.y;

			var leftGroundAngle = UnityEngine.Random.Range(maxAngleLeft, minAngleLeft);
			var rightGroundAngle = UnityEngine.Random.Range(maxAngleRight, minAngleRight);
			/*var leftGroundAngleMin = leftGroundAngle - groundGapSize / 2f;
			var leftGroundAngleMax = leftGroundAngle + groundGapSize / 2f;*/

			List<Vector2> ExcludedAngles = new List<Vector2>
			{
				new Vector2(rightGroundAngle - groundGapSize / 2f, rightGroundAngle + groundGapSize / 2f),
				new Vector2(90f - (topGapAngle / 2f),90f + (topGapAngle / 2f)),
				new Vector2(leftGroundAngle - groundGapSize / 2f, leftGroundAngle + groundGapSize / 2f)
			};
#if UNITY_EDITOR
			foreach (var exclusion in ExcludedAngles)
			{
				Debug_DrawAngle(transform.position + aspidShotSpawnOffset, exclusion.x, 2f, Color.red);
				Debug_DrawAngle(transform.position + aspidShotSpawnOffset, exclusion.y, 2f, Color.red);
			}
#endif

			var angleData = GetExclusions(ExcludedAngles, 0f, 180f);


			float currentAngle = 0f;
			int currentExclusionIndex = 0;

			while (currentAngle < 180f)
			{
				if (currentExclusionIndex < ExcludedAngles.Count && currentAngle >= ExcludedAngles[currentExclusionIndex].x)
				{
					currentAngle = ExcludedAngles[currentExclusionIndex].x;
					SpawnAspidShot(transform.position + aspidShotSpawnOffset, currentAngle, aspidShotVelocity);
					currentAngle = ExcludedAngles[currentExclusionIndex].y;
					SpawnAspidShot(transform.position + aspidShotSpawnOffset, currentAngle, aspidShotVelocity);
					currentExclusionIndex++;
					currentAngle += angleBetweenShots;
				}
				else
				{
					SpawnAspidShot(transform.position + aspidShotSpawnOffset, currentAngle, aspidShotVelocity);
					currentAngle += angleBetweenShots;
				}
			}

			/*for (int i = 0; i < aspidShotAmount; i++)
			{
				SpawnAspidShot(transform.position + aspidShotSpawnOffset, GetRandomAngle(angleData), aspidShotVelocity);
			}*/

			DownslashSplash.Play();
			DownslashPillar.Play();


			/*Vector2 excludedLeftSide = new Vector2(leftGroundAngle - groundGapSize / 2f, leftGroundAngle + groundGapSize / 2f);
			Vector2 excludedRightSide = new Vector2(leftGroundAngle - groundGapSize / 2f, leftGroundAngle + groundGapSize / 2f);*/
		}

		/*if (spawnAspidShots)
		{
			for (int i = 0; i < aspidShots; i++)
			{
				var minAngle = ((i / (float)(aspidShots)) * (180f - (angleFromGround * 2f)));// - (180f - angleFromGround);
				var maxAngle = (((i + 1) / (float)(aspidShots)) * (180f - (angleFromGround * 2f)));// - (180f - angleFromGround);

				var shootAngle = UnityEngine.Random.Range(minAngle, maxAngle);
#if UNITY_EDITOR

				if (showDebugLines)
				{
					//var vectorAngle = new Vector2(Mathf.Cos());


					//Debug.DrawLine(transform.position)
					Debug_DrawAngle(transform.position + aspidShotSpawnOffset, minAngle, 2f, Color.red);
					Debug_DrawAngle(transform.position + aspidShotSpawnOffset, maxAngle, 2f, Color.red);

					Debug_DrawAngle(transform.position + aspidShotSpawnOffset, shootAngle, 2f, Color.green);
				}


#endif

				var aspidShot = AspidShot.Spawn(transform.position + aspidShotSpawnOffset, shootAngle, aspidShotVelocity);

				aspidShot.Rigidbody.gravityScale = aspidShotGravityScale;
			}
		}*/
		if (spawnWaves)
		{
			SlamWave left, right;
			WaveSlams.SpawnSlam(InfectionWave.System, transform.position, out left,out right, wavesOffset);
			left.SizeToSpeedRatio *= waveHeightMultiplier;
			right.SizeToSpeedRatio *= waveHeightMultiplier;
		}

		/*yield return Animator.PlayAnimationTillDone("Downstab Land");

		Animator.PlayAnimation("Idle");

		yield return new WaitForSeconds(0.35f);

		GetComponent<IdleMove>().DoingStreak = false;*/
	}

	DownslashAspidShot SpawnAspidShot(Vector3 position, Vector2 velocity)
	{
		var instance = Pooling.Instantiate(aspidShotPrefab, position, Quaternion.identity);

		instance.Rigidbody.velocity = velocity;

		instance.GetComponent<SpriteRenderer>().sprite = aspidShotPrefab.GetComponent<SpriteRenderer>().sprite;

		return instance;
	}

	DownslashAspidShot SpawnAspidShot(Vector3 position, float angleDegrees, float velocity)
	{
		return SpawnAspidShot(position, new Vector2(Mathf.Cos(angleDegrees * Mathf.Deg2Rad) * velocity, Mathf.Sin(angleDegrees * Mathf.Deg2Rad) * velocity));
	}

	IEnumerator SlamColliderDisabler(float time)
	{
		yield return new WaitForSeconds(time);
		if (slamCollider != null)
		{
			slamCollider.enabled = false;
		}
	}

#if UNITY_EDITOR
	void Debug_DrawAngle(Vector3 position, float angle, float length, Color color)
	{
		var vectorAngle = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * length,Mathf.Sin(angle * Mathf.Deg2Rad) * length);

		Debug.DrawLine(position, position + (Vector3)vectorAngle, color, debugLineDuration);
	}
#endif

	public override void OnStun()
	{
		Animator.PlaybackSpeed = 1f;

		if (slamCollider != null)
		{
			slamCollider.enabled = false;
		}

		if (!downstabbing)
		{
			jump.OnStun();
		}
		KinRigidbody.velocity = default(Vector2);
		base.OnStun();
	}
}
