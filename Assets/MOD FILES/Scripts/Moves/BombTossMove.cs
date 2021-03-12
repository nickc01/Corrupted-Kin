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
	[SerializeField] ParticleSystem TossParticles;
	[SerializeField] float TossParticlesSpeed = 7.5f;
	[SerializeField] float TossDeathWaveSize = 0.5f;
	[SerializeField] int TossTimes = 2;
	[SerializeField] float DelayBetweenTosses = 0.45f;
	[SerializeField] AudioClip TossSound;
	[Tooltip("The delay between starting the toss and actually tossing the bomb")]
	[SerializeField] float TossingDelay = 0.05f;
	[SerializeField] float TossBloodAngleMin = 15f;
	[SerializeField] float TossBloodAngleMax = 85f;
	[SerializeField] float BombAngularVelocity = 45f;
	[SerializeField] Vector3 TossBloodSpawnOffset;
	[SerializeField] Vector3 ScuttlerBombSpawnOffset;
	[SerializeField] float ScuttlerBombAirTime = 0.8f;

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

		Audio.PlayAtPoint(BombTossPrepareSound, transform.position);

		//BombTossPrepareSound.length;
		var main = TossParticles.main;
		main.startSpeed = new ParticleSystem.MinMaxCurve(0f, 0f);
		TossParticles.gameObject.SetActive(true);
		TossParticles.Play();

		float time = BombTossPrepareSound.length;

		for (float i = 0; i < time; i += Time.deltaTime)
		{
			main.startSpeed = new ParticleSystem.MinMaxCurve(0f, TossParticlesSpeed * (i / time));
			yield return null;
		}

		var deathWave = DeathWave.Spawn(TossParticles.transform.position, TossDeathWaveSize);
		//deathWave.transform.localScale = new Vector3(TossDeathWaveSize, TossDeathWaveSize, 1f);

		yield return new WaitForSeconds(TossPrepareDelay);


		for (int i = 0; i < TossTimes; i++)
		{
			TossParticles.Stop(false, ParticleSystemStopBehavior.StopEmitting);

			//TODO : Play THROW ANIMATION AND THROW BOMBS

			Animator.PlayAnimation("Bomb Toss");

			var guid = Animator.PlayingGUID;

			yield return new WaitForSeconds(TossingDelay);

			Audio.PlayAtPoint(TossSound, transform.position);

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

			var bomb = ScuttlerBomb.Spawn(transform.position + scuttlerOffset, Player.Player1.transform.position, ScuttlerBombAirTime, bombRotation);

			var bombFlasher = bomb.GetComponent<SpriteFlasher>();

			//bombFlasher.DoFlash()
			bombFlasher.DoFlash(0.01f, 0.25f, 0.9f, bombFlasher.FlashColor, 0.01f);

			while (Animator.PlayingGUID == guid)
			{
				yield return null;
			}


			//If on last turn
			if (i == TossTimes - 1)
			{
				//TODO : SWITCH BACK TO PREPARE ANIMATION

				yield return Animator.PlayAnimationTillDone("Bomb Recover");
			}
			else
			{
				TossParticles.Play();
				Animator.PlayAnimation("Bomb Prepare New");
				yield return new WaitForSeconds(DelayBetweenTosses);
			}

		}

	}

	public override void OnStun()
	{
		TossParticles.gameObject.SetActive(false);
		base.OnStun();
	}
}
