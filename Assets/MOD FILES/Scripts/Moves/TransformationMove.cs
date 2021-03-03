using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeaverCore;
using WeaverCore.Enums;
using WeaverCore.Features;
using WeaverCore.Utilities;

public class TransformationMove : CorruptedKinMove
{
	int runningScuttlers = 0;

	List<TransformationBlob> Blobs;

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
		yield return Animator.PlayAnimationTillDone("Roar Start");

		Kin.EntityHealth.Invincible = true;

		Animator.PlayAnimation("Roar Loop");

		WeaverAudio.PlayAtPoint(Kin.HollowKnightScream, transform.position);

		//Player.Player1.RoarLock = true;
		//Player.Player1.EnterRoarLock();

		//yield return Kin.Roar(2.4f, Kin.HollowKnightScream,false);
		//Enemy.Roar(gameObject,)

		var roarEmitter = RoarEmitter.Spawn(transform.position);
		roarEmitter.RoarLockPlayer();

		var summonGrass = Kin.transform.Find("Summon Grass");

		summonGrass.transform.SetParent(null);

		summonGrass.transform.position = new Vector3(Kin.leftX + (26.33213f - 16.06f), Kin.floorY + (27.10731f - 28.19727f), Kin.transSummonGrassZ);

		summonGrass.gameObject.SetActive(true);

		var summonParticles = summonGrass.GetComponent<ParticleSystem>();

		summonParticles.Play();

		List<Transform> targets = new List<Transform>();

		if (Player.Player1.transform.position.x > transform.position.x)
		{
			Kin.TargetsChild.SetXLocalScale(-1f);
		}

		for (int i = 0; i < Kin.TargetsChild.childCount; i++)
		{
			targets.Add(Kin.TargetsChild.GetChild(i));
		}

		targets.RandomizeList();
		Blobs = new List<TransformationBlob>();
		runningScuttlers = 0;

		TransformationAspidShot.PreparePools(targets.Count);

		for (int i = 0; i < targets.Count; i++)
		{
			var target = targets[i];

			yield return new WaitForSeconds(UnityEngine.Random.Range(Kin.transScutterSpawnDelayMin,Kin.transScutterSpawnDelayMax));

			var direction = UnityEngine.Random.value >= 0.5f ? CardinalDirection.Right : CardinalDirection.Left;

			float spawnX = 0f;

			switch (direction)
			{
				case CardinalDirection.Left:
					spawnX = transform.position.x - UnityEngine.Random.Range(Kin.transScutterSpawnMinX,Kin.transScutterSpawnMaxX);
					if (spawnX <= Kin.leftX)
					{
						yield return null;
						goto case CardinalDirection.Right;
					}
					break;
				case CardinalDirection.Right:
					spawnX = transform.position.x + UnityEngine.Random.Range(Kin.transScutterSpawnMinX, Kin.transScutterSpawnMaxX);
					if (spawnX >= Kin.rightX)
					{
						yield return null;
						goto case CardinalDirection.Left;
					}
					break;
			}
			runningScuttlers++;
			var scuttler = Scuttler.Spawn(new Vector3(spawnX, Kin.transScutterSpawnY, CorruptedKinGlobals.Instance.ScuttlerPrefab.transform.position.z), target.gameObject,Vector3.zero);
			scuttler.SplatEvent += OnScuttlerSplat;
		}


		//yield return new WaitForSeconds(6f);
		yield return new WaitUntil(() => runningScuttlers == 0);

		yield return new WaitForSeconds(0.1f);
		roarEmitter.StopRoaring();
		summonParticles.Stop();


		yield return new WaitForSeconds(Kin.transExplosionWaitTime);
		foreach (var blob in Blobs)
		{
			//blob.Expand()
			blob.Expand(Kin.transBlobSizeIncrease, Kin.transBlobExpansionTime, Kin.transBlobSizeCurve);
		}

		yield return new WaitForSeconds(Kin.transBlobExpansionTime);

		//var splatTargets = Kin.TransformationSplats.AllTargets.ToList();

		//splatTargets.RandomizeList();

		foreach (var blob in Blobs)
		{
			//blob.Expand()
			//blob.Expand(Kin.transBlobSizeIncrease, Kin.transBlobExpansionTime, Kin.transBlobSizeCurve);
			blob.Explode();
			//TransformationAspidShot.Spawn(blob.transform.position,)
		}

		SpawnAspidShots(Blobs);

		WeaverAudio.PlayAtPoint(Kin.transBlobExplodeSound, transform.position, Kin.transBlobExplodeVolume);

		roarEmitter = RoarEmitter.Spawn(transform.position);

		WeaverCam.Instance.Shaker.Shake(ShakeType.BigShake);

		Kin.Flasher.FlashInfected();

		//yield return new WaitForSeconds(0.05f);

		WeaverAudio.PlayAtPoint(Kin.HollowKnightScream, transform.position);

		yield return new WaitForSeconds(Kin.transEndDelay);



		roarEmitter.RoarUnlockPlayer();
		roarEmitter.StopRoaring();
		Kin.EntityHealth.Invincible = false;
		yield return Animator.PlayAnimationTillDone("Roar End");

		summonGrass.gameObject.SetActive(false);
		summonGrass.SetParent(transform);



		yield break;
	}

	void SpawnAspidShots(List<TransformationBlob> blobs)
	{
		var splatTargets = Kin.TransformationSplats.AllTargets.ToList();

		splatTargets.RandomizeList();

		for (int i = 0; i < splatTargets.Count; i++)
		{
			var blob = blobs[i % blobs.Count];

			TransformationAspidShot.SpawnTransformationShot(blob.transform.position, splatTargets[i]);
		}

		Blood.SpawnRandomBlood(transform.position);
	}


	void OnScuttlerSplat(Scuttler scuttler)
	{
		runningScuttlers--;

		var blob = TransformationBlob.Spawn(scuttler.TargetObject.transform.position);

		scuttler.transform.position = scuttler.TargetObject.transform.position;

		blob.transform.SetXLocalScale(UnityEngine.Random.Range(Kin.BlobScaleMin.x,Kin.BlobScaleMax.x));
		blob.transform.SetYLocalScale(UnityEngine.Random.Range(Kin.BlobScaleMin.y,Kin.BlobScaleMax.y));

		Blobs.Add(blob);
	}
}

