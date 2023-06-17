using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class TransformationMove : CorruptedKinMove
{
	[SerializeField] InfectionWave InfectionWavePrefab;
	[SerializeField] float transScutterSpawnY = 27.86f;
	[SerializeField] float transScutterSpawnMinX = 3f;
	[SerializeField] float transScutterSpawnMaxX = 6f;
	[SerializeField] float transScutterSpawnDelayMin = 0.1f;
	[SerializeField] float transScutterSpawnDelayMax = 0.2f;
	[SerializeField] Transform TargetsChild;
	[SerializeField] Vector2 BlobScaleMin = new Vector2(1f, 1f);
	[SerializeField] Vector2 BlobScaleMax = new Vector2(1.4f, 1.4f);
	[SerializeField] float transExplosionWaitTime = 0.7f;
	[SerializeField] float transBlobSizeIncrease = 3f;
	[SerializeField] float transBlobExpansionTime = 0.4f;
	[SerializeField] float transSummonGrassZ = 0.5f;
	[SerializeField] AnimationCurve transBlobSizeCurve;

	[Space]
	[Header("Post Transformation")]
	[SerializeField] AudioClip transBlobExplodeSound;
	[SerializeField] float transBlobExplodeVolume = 1f;
	[SerializeField] float transEndDelay = 0.8f;
	[SerializeField] float transAspidShotMinSize = 0.7f;
	[SerializeField] float transAspidShotMaxSize = 1.3f;

	public int transTargetCount { get { return TargetsChild.childCount; } }
	public WallSplats TransformationSplats { get; private set; }

	int runningScuttlers = 0;

	List<TransformationBlob> Blobs;

	//float previousRecoil = 0f;

	public override IEnumerator DoMove()
	{
		HealthManager.HealthLocked = true;
		if (TransformationSplats == null)
		{
			TransformationSplats = WallSplats.Spawn(Kin.LeftX, Kin.FloorY);
		}

		var recoil = GetComponent<WeaverCore.Components.Recoiler>();

		//previousRecoil = recoil.GetRecoilSpeed();
		recoil.SetRecoilSpeed(0f);

		var jumpMove = GetComponent<JumpMove>();

		jumpMove.JumpAnticSpeed = 0.5f;

		if (transform.position.x >= Mathf.Lerp(Kin.MiddleX,Kin.RightX,0.7f) || transform.position.x <= Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.7f))
		{
			if (Player.Player1.transform.position.x >= Kin.MiddleX)
			{
				yield return jumpMove.Jump(Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.7f));
			}
			else
			{
				yield return jumpMove.Jump(Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.7f));
			}
		}
		else if (Vector3.Distance(Player.Player1.transform.position,transform.position) <= 4f && Player.Player1.transform.position.y >= transform.position.y + 2f)
		{
			if (Player.Player1.transform.position.x >= Kin.MiddleX)
			{
				yield return jumpMove.Jump(Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.7f));
			}
			else
			{
				yield return jumpMove.Jump(Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.7f));
			}
		}

		jumpMove.JumpAnticSpeed = 1f;
		/*if (Player.Player1.transform.position.x >= Kin.MiddleX)
		{
			yield return jumpMove.Jump(Mathf.Lerp(Kin.MiddleX, Kin.LeftX, 0.7f));
		}
		else
		{
			yield return jumpMove.Jump(Mathf.Lerp(Kin.MiddleX, Kin.RightX, 0.7f));
		}*/

		//recoil.SetRecoilSpeed(previousRecoil);
		recoil.ResetRecoilSpeed();

		yield return Animator.PlayAnimationTillDone("Roar Start");

		Kin.HealthComponent.Invincible = true;
		HealthManager.HealthLocked = false;
		Kin.DoParasiteSpawning = false;
		ParasiteBalloon.DestroyAllParasites();

		Animator.PlayAnimation("Roar Loop");

		WeaverAudio.PlayAtPoint(Kin.ScreamSound, transform.position);

		//Player.Player1.RoarLock = true;
		//Player.Player1.EnterRoarLock();

		//yield return Kin.Roar(2.4f, Kin.HollowKnightScream,false);
		//Enemy.Roar(gameObject,)

		var roarEmitter = RoarEmitter.Spawn(transform.position);
		roarEmitter.RoarLockPlayer();

		var summonGrass = Kin.transform.Find("Summon Grass");

		summonGrass.transform.SetParent(null);

		summonGrass.transform.position = new Vector3(Kin.LeftX + (26.33213f - 16.06f), Kin.FloorY + (27.10731f - 28.19727f), transSummonGrassZ);

		summonGrass.gameObject.SetActive(true);
//#if UNITY_EDITOR
		Kin.InfectionWave = GameObject.FindObjectOfType<InfectionWave>();
//#endif
		if (Kin.InfectionWave == null)
		{
			Kin.InfectionWave = GameObject.Instantiate(InfectionWavePrefab, new Vector3(Kin.LeftX + (27f - 16.06f), Kin.FloorY + (InfectionWavePrefab.transform.position.y - 28.19727f), InfectionWavePrefab.transform.position.z), Quaternion.identity);
		}

		var summonParticles = summonGrass.GetComponent<ParticleSystem>();

		summonParticles.Play();

		List<Transform> targets = new List<Transform>();

		if (!Renderer.flipX)
		{
			TargetsChild.SetXLocalScale(-1f);
		}
		/*if (Player.Player1.transform.position.x > transform.position.x)
		{
			TargetsChild.SetXLocalScale(-1f);
		}*/

		for (int i = 0; i < TargetsChild.childCount; i++)
		{
			targets.Add(TargetsChild.GetChild(i));
		}

		targets.RandomizeList();
		Blobs = new List<TransformationBlob>();
		runningScuttlers = 0;

		//TransformationAspidShot.PreparePools(targets.Count);

		for (int i = 0; i < targets.Count; i++)
		{
			var target = targets[i];

			yield return new WaitForSeconds(UnityEngine.Random.Range(transScutterSpawnDelayMin, transScutterSpawnDelayMax));

			var direction = UnityEngine.Random.value >= 0.5f ? CardinalDirection.Right : CardinalDirection.Left;

			float spawnX = 0f;

			switch (direction)
			{
				case CardinalDirection.Left:
					spawnX = transform.position.x - UnityEngine.Random.Range(transScutterSpawnMinX, transScutterSpawnMaxX);
					if (spawnX <= Kin.LeftX)
					{
						yield return null;
						goto case CardinalDirection.Right;
					}
					break;
				case CardinalDirection.Right:
					spawnX = transform.position.x + UnityEngine.Random.Range(transScutterSpawnMinX, transScutterSpawnMaxX);
					if (spawnX >= Kin.RightX)
					{
						yield return null;
						goto case CardinalDirection.Left;
					}
					break;
			}
			runningScuttlers++;
			var scuttler = Scuttler.Spawn(new Vector3(spawnX, transScutterSpawnY, CorruptedKinGlobals.Instance.ScuttlerPrefab.transform.position.z), target.gameObject, Vector3.zero);
			scuttler.SplatEvent += OnScuttlerSplat;
		}


		//yield return new WaitForSeconds(6f);
		yield return new WaitUntil(() => runningScuttlers == 0);

		yield return new WaitForSeconds(0.1f);
		roarEmitter.StopRoaring();
		summonParticles.Stop();


		yield return new WaitForSeconds(transExplosionWaitTime);
		foreach (var blob in Blobs)
		{
			//blob.Expand()
			blob.Expand(transBlobSizeIncrease, transBlobExpansionTime, transBlobSizeCurve);
		}

		Kin.InterpolateGlow(0.65f, 0.75f);

		yield return new WaitForSeconds(transBlobExpansionTime);

		//var splatTargets = Kin.TransformationSplats.AllTargets.ToList();

		//splatTargets.RandomizeList();

		foreach (var blob in Blobs)
		{
			//blob.Expand()
			//blob.Expand(transBlobSizeIncrease, transBlobExpansionTime, transBlobSizeCurve);
			blob.Explode();
			//TransformationAspidShot.Spawn(blob.transform.position,)
		}

		SpawnAspidShots(Blobs);

		WeaverAudio.PlayAtPoint(transBlobExplodeSound, transform.position, transBlobExplodeVolume);

		roarEmitter = RoarEmitter.Spawn(transform.position);

		CameraShaker.Instance.Shake(ShakeType.BigShake);

		Kin.Flasher.flashInfected();

		//yield return new WaitForSeconds(0.05f);

		WeaverAudio.PlayAtPoint(Kin.ScreamSound, transform.position);

		yield return new WaitForSeconds(transEndDelay);



		roarEmitter.RoarUnlockPlayer();
		roarEmitter.StopRoaring();
		Kin.HealthComponent.Invincible = false;
		yield return Animator.PlayAnimationTillDone("Roar End");

		summonGrass.gameObject.SetActive(false);
		summonGrass.SetParent(transform);

		Kin.GuaranteedNextMove = null;

		yield break;
	}

	public override void OnStun()
	{
		HealthManager.HealthLocked = false;

		//GetComponent<WeaverCore.Components.Recoiler>().SetRecoilSpeed(previousRecoil);
		GetComponent<Recoiler>().ResetRecoilSpeed();
		GetComponent<JumpMove>().OnStun();
		Kin.HealthComponent.Invincible = false;
		base.OnStun();
	}

	void SpawnAspidShots(List<TransformationBlob> blobs)
	{
		var splatTargets = TransformationSplats.AllTargets.ToList();

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

		blob.transform.SetXLocalScale(UnityEngine.Random.Range(BlobScaleMin.x, BlobScaleMax.x));
		blob.transform.SetYLocalScale(UnityEngine.Random.Range(BlobScaleMin.y, BlobScaleMax.y));

		Blobs.Add(blob);
	}
}

