using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;
using WeaverCore.Assets.Components;
using WeaverCore.Components;
using WeaverCore.Utilities;

public class BombTossMove : CorruptedKinMove
{
	public override bool MoveEnabled
	{
		get
		{
			return true;
		}
	}

	public override bool ShowsUpInRandomizer
	{
		get
		{
			return true;
		}
	}

	public override bool CanDoAttack()
	{
		return true;
	}

	public override IEnumerator DoMove()
	{
		yield return Kin.TurnTowardsPlayer();

		var localX = Kin.TossParticles.transform.localPosition.x;
		if (Kin.Renderer.flipX)
		{
			if (localX < 0f)
			{
				Kin.TossParticles.transform.SetXLocalPosition(-localX);
			}
		}
		else
		{
			if (localX > 0f)
			{
				Kin.TossParticles.transform.SetXLocalPosition(-localX);
			}
		}


		yield return Animator.PlayAnimationTillDone("Bomb Antic");

		Animator.PlayAnimation("Bomb Prepare New");

		WeaverAudio.PlayAtPoint(Kin.BombTossPrepareSound,transform.position);

		//Kin.BombTossPrepareSound.length;
		var main = Kin.TossParticles.main;
		main.startSpeed = new ParticleSystem.MinMaxCurve(0f, 0f);
		Kin.TossParticles.gameObject.SetActive(true);
		Kin.TossParticles.Play();

		float time = Kin.BombTossPrepareSound.length;

		for (float i = 0; i < time; i += Time.deltaTime)
		{
			main.startSpeed = new ParticleSystem.MinMaxCurve(0f, Kin.TossParticlesSpeed * (i / time));
			yield return null;
		}

		var deathWave = DeathWave.Spawn(Kin.TossParticles.transform.position,Kin.TossDeathWaveSize);
		//deathWave.transform.localScale = new Vector3(Kin.TossDeathWaveSize, Kin.TossDeathWaveSize, 1f);

		yield return new WaitForSeconds(Kin.TossPrepareDelay);


		for (int i = 0; i < Kin.TossTimes; i++)
		{
			Kin.TossParticles.Stop(false, ParticleSystemStopBehavior.StopEmitting);

			//TODO : Play THROW ANIMATION AND THROW BOMBS

			Animator.PlayAnimation("Bomb Toss");

			var guid = Animator.PlayingGUID;

			yield return new WaitForSeconds(Kin.TossingDelay);

			WeaverAudio.PlayAtPoint(Kin.TossSound, transform.position);

			var bombRotation = -Kin.BombAngularVelocity;
			var bloodSpawnOffset = Kin.TossBloodSpawnOffset;
			var scuttlerOffset = Kin.ScuttlerBombSpawnOffset;

			var angleMin = Kin.TossBloodAngleMin;
			var angleMax = Kin.TossBloodAngleMax;

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

			Blood.SpawnBlood(transform.position + Kin.TossBloodSpawnOffset, new Blood.BloodSpawnInfo(12, 15, 24f, 30f, angleMin, angleMax));

			var bomb = ScuttlerBomb.Spawn(transform.position + scuttlerOffset, Player.Player1.transform.position, Kin.ScuttlerBombAirTime, bombRotation);

			var bombFlasher = bomb.GetComponent<SpriteFlasher>();

			//bombFlasher.DoFlash()
			bombFlasher.DoFlash(0.01f, 0.25f, 0.9f, bombFlasher.FlashColor, 0.01f);

			while (Animator.PlayingGUID == guid)
			{
				yield return null;
			}


			//If on last turn
			if (i == Kin.TossTimes - 1)
			{
				//TODO : SWITCH BACK TO PREPARE ANIMATION

				yield return Animator.PlayAnimationTillDone("Bomb Recover");
			}
			else
			{
				Kin.TossParticles.Play();
				Animator.PlayAnimation("Bomb Prepare New");
				yield return new WaitForSeconds(Kin.DelayBetweenTosses);
			}

		}

	}

	public override void OnStun()
	{
		Kin.TossParticles.gameObject.SetActive(false);
		base.OnStun();
	}
}
