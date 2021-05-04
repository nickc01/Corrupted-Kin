using System.Collections;
using UnityEngine;
using WeaverCore;
using WeaverCore.Assets.Components;
using WeaverCore.Components;
using WeaverCore.Utilities;

public class BombTossMove : CorruptedKinMove
{
	[SerializeField] AudioClip BombTossPrepareSound;
	[SerializeField] float TossPrepareDelay = 0.55f;
	[SerializeField] float TossPrepareDelaySecondStage = 0.01f;
	[SerializeField] ParticleSystem TossParticles;
	[SerializeField] float TossParticlesSpeed = 7.5f;
	[SerializeField] float TossDeathWaveSize = 0.5f;
	[SerializeField] int TossTimesFirstStage = 2;
	[SerializeField] float DelayBetweenTossesFirstStage = 0.45f;
	[SerializeField] int TossTimesSecondStage = 3;
	[SerializeField] float DelayBetweenTossesSecondStage = 0.3f;
	[SerializeField] AudioClip TossSound;
	[Tooltip("The delay between starting the toss and actually tossing the bomb")]
	[SerializeField] float TossingDelay = 0.05f;
	[SerializeField] float TossBloodAngleMin = 15f;
	[SerializeField] float TossBloodAngleMax = 85f;
	[SerializeField] float BombAngularVelocity = 45f;
	[SerializeField] Vector3 TossBloodSpawnOffset;
	[SerializeField] Vector3 ScuttlerBombSpawnOffset;
	[SerializeField] float ScuttlerBombAirTime = 0.8f;
	[SerializeField] float minDistanceForSpeedAdjustments = 6f;
	[SerializeField] float minimumBombAirTime = 0.35f;

	public override IEnumerator DoMove()
	{
		yield return Kin.TurnTowardsPlayer();

		var localX = TossParticles.transform.localPosition.x;
		if (Kin.Renderer.flipX)
		{
			if (localX < 0f)
			{
				TossParticles.transform.SetXLocalPosition(-localX);
			}
		}
		else
		{
			if (localX > 0f)
			{
				TossParticles.transform.SetXLocalPosition(-localX);
			}
		}


		yield return Animator.PlayAnimationTillDone("Bomb Antic");

		Animator.PlayAnimation("Bomb Prepare New");

		WeaverAudio.PlayAtPoint(BombTossPrepareSound, transform.position);

		//BombTossPrepareSound.length;
		var main = TossParticles.main;
		main.startSpeed = new ParticleSystem.MinMaxCurve(0f, 0f);
		//TossParticles.gameObject.SetActive(true);
		TossParticles.Play();

		float time = BombTossPrepareSound.length;

		int previousHealth = HealthManager.Health;

		for (float i = 0; i < time; i += Time.deltaTime)
		{
			main.startSpeed = new ParticleSystem.MinMaxCurve(0f, TossParticlesSpeed * (i / time));
			if (HealthManager.Health < previousHealth)
			{
				break;
			}
			yield return null;
		}

		main.startSpeed = new ParticleSystem.MinMaxCurve(0f, TossParticlesSpeed);
		var deathWave = DeathWave.Spawn(TossParticles.transform.position, TossDeathWaveSize);
		//deathWave.transform.localScale = new Vector3(TossDeathWaveSize, TossDeathWaveSize, 1f);

		var startDelay = TossPrepareDelay;
		if (Kin.BossStage == 2 || Kin.BossStage >= 4)
		{
			startDelay = TossPrepareDelaySecondStage;
		}

		if (HealthManager.Health == previousHealth)
		{
			yield return Kin.WaitUnlessAttacked(startDelay, false);
		}
		//yield return new WaitForSeconds(TossPrepareDelay);

		var tossTimes = TossTimesFirstStage;

		if (Kin.BossStage == 2)
		{
			tossTimes = TossTimesSecondStage;
		}


		for (int i = 0; i < tossTimes; i++)
		{
			TossParticles.Stop();

			//TODO : Play THROW ANIMATION AND THROW BOMBS

			Animator.PlayAnimation("Bomb Toss");

			var guid = Animator.PlayingGUID;

			yield return new WaitForSeconds(TossingDelay);

			WeaverAudio.PlayAtPoint(TossSound, transform.position);

			var bombRotation = -BombAngularVelocity;
			var bloodSpawnOffset = TossBloodSpawnOffset;
			var scuttlerOffset = ScuttlerBombSpawnOffset;

			var angleMin = TossBloodAngleMin;
			var angleMax = TossBloodAngleMax;

			if (!Kin.IsFacingRight)
			{
				bombRotation = -bombRotation;
				bloodSpawnOffset.x *= -1f;
				scuttlerOffset.x *= -1f;

				var min = 180f - angleMax;
				var max = 180 - angleMin;

				angleMin = min;
				angleMax = max;

				//angleMin += 90f;
				//angleMax += 90f;
			}

			Blood.SpawnBlood(transform.position + TossBloodSpawnOffset, new Blood.BloodSpawnInfo(12, 15, 24f, 30f, angleMin, angleMax));

			var airTime = ScuttlerBombAirTime;

			var playerDistance = Vector2.Distance(transform.position, Player.Player1.transform.position);

			if (playerDistance < minDistanceForSpeedAdjustments)
			{
				airTime = Mathf.InverseLerp(0.3f, minDistanceForSpeedAdjustments, playerDistance);
			}

			if (Kin.BossStage >= 4)
			{
				airTime *= 0.85f;
			}

			airTime /= 1f + ((previousHealth - HealthManager.Health) / 120f);

			if (airTime < minimumBombAirTime)
			{
				airTime = minimumBombAirTime;
			}

			var bomb = ScuttlerBomb.Spawn(transform.position + scuttlerOffset, Player.Player1.transform.position, airTime, bombRotation,Kin);

			var bombFlasher = bomb.GetComponent<SpriteFlasher>();

			//bombFlasher.DoFlash()
			bombFlasher.DoFlash(0.01f, 0.25f, 0.9f, bombFlasher.FlashColor, 0.01f);

			while (Animator.PlayingGUID == guid)
			{
				yield return null;
			}


			//If on last turn
			if (i == tossTimes - 1)
			{
				//TODO : SWITCH BACK TO PREPARE ANIMATION

				yield return Animator.PlayAnimationTillDone("Bomb Recover");


				if (Kin.BossStage >= 3)
				{
					GetComponent<IdleMove>().DoingStreak = false;

					Animator.PlayAnimation("Idle");

					//yield return new WaitForSeconds(1.35f);
					yield return new WaitForSeconds(0.25f);
					yield return Kin.WaitUnlessAttacked(1.1f,true);
				}
				else if (Kin.BossStage == 2 && Vector3.Distance(transform.position,Player.Player1.transform.position) <= 6f)
				{
					Animator.PlayAnimation("Idle");

					yield return new WaitForSeconds(0.1f);
					yield return Kin.WaitUnlessAttacked(0.35f,true);
					//yield return new WaitForSeconds(0.45f);
				}
			}
			else
			{
				TossParticles.Play();
				Animator.PlayAnimation("Bomb Prepare New");

				var tossDelay = DelayBetweenTossesFirstStage;

				if (Kin.BossStage == 2 || Kin.BossStage >= 4)
				{
					tossDelay = DelayBetweenTossesSecondStage;
				}
					
				yield return new WaitForSeconds(tossDelay);

				Kin.TurnTowardsPlayerInstant();
			}

		}

	}

	public override void OnStun()
	{
		TossParticles.Stop();
		base.OnStun();
	}
}
