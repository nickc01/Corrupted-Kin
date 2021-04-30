using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using WeaverCore;
using WeaverCore.Assets.Components;
using WeaverCore.Components;
using WeaverCore.Enums;
using WeaverCore.Features;
using WeaverCore.Utilities;
using Random = UnityEngine.Random;

public class CorruptedKin : BossReplacement
{
	public static CorruptedKin Instance { get; private set; }
	public WeaverAnimationPlayer Animator { get; private set; }
	public SpriteRenderer Renderer { get; private set; }
	public Rigidbody2D Rigidbody { get; private set; }
	public AudioPlayer AudioPlayer { get; private set; }
	public CorruptedKinHealth HealthManager { get; private set; }
	public Collider2D Collider { get; private set; }
	public WeaverCore.Components.DamageHero Damager { get; private set; }
	public SpriteFlasher Flasher { get; private set; }
	public InfectionWave InfectionWave { get; set; }
	//public WaveSystem InfectionWave { get; set; }

	[Header("General Stuff")]
	[FormerlySerializedAs("JumpSound")]
	[SerializeField] AudioClip jumpSound;
	[FormerlySerializedAs("LandSound")]
	[SerializeField] AudioClip landSound;
	[FormerlySerializedAs("SwordSlashSound")]
	[SerializeField] AudioClip swordSlashSound;
	[FormerlySerializedAs("PrepareSound")]
	[SerializeField] AudioClip prepareSound;
	float leftX = 16.06f;
	float rightX = 35.83f;
	float floorY = 0f;
	public WaveSlams WaveSlams;
	//[SerializeField] float arenaHeight = 0f;
	[SerializeField] CorruptedKinGlobals Globals;
	[SerializeField] BoxCollider2D awakeRange;
	[SerializeField] MusicPack BossMusicPack;
	[Tooltip("The time the player must stay on the wall before the boss registers that the player is staying on the wall")]
	public float playerWallTestDuration = 0.5f;

	public AudioClip JumpSound { get { return jumpSound; } }
	public AudioClip LandSound { get { return landSound; } }
	public AudioClip SwordSlashSound { get { return swordSlashSound; } }
	public AudioClip PrepareSound { get { return prepareSound; } }
	public float LeftX { get { return leftX; } }
	public float RightX { get { return rightX; } }
	public float FloorY { get { return floorY; } }
	public float MiddleX { get { return Mathf.Lerp(LeftX, RightX, 0.5f); } }

	/*[Space]
	[Header("Moves")]
	public bool DownslashEnabled = true;
	public bool JumpEnabled = true;
	public bool EvadeEnabled = true;
	public bool DashEnabled = true;
	public bool AirDashEnabled = true;
	public bool OverheadSlashEnabled = true;
	public bool BombTossEnabled = true;*/

	[Space]
	[Header("Intro")]
	[SerializeField] float leftSpawnPoint = 20.59f;
	[SerializeField] float rightSpawnPoint = 33.58f;
	[SerializeField] float fallYPosition = 41.82f;
	[FormerlySerializedAs("FallSoundEffect")]
	[SerializeField] AudioClip fallSound;
	[FormerlySerializedAs("LandSoundEffect")]
	[SerializeField] AudioClip heavyLandSound;
	[FormerlySerializedAs("HollowKnightScream")]
	[SerializeField] AudioClip screamSound;
	[SerializeField] float fallDelay = 0.3f;

	[Space]
	[Header("Parasite Spawning")]
	[SerializeField]
	[Tooltip("How many seconds should elapse before a parasite should spawn")]
	float parasiteSpawnRate = 2.5f;
	[SerializeField]
	[Tooltip("How high should the parasites spawn, relative to Kin.FloorY")]
	Vector2 parasiteSpawnHeightMinMax = new Vector2(5f,15f);

	public AudioClip FallSound { get { return fallSound; } }
	public AudioClip HeavyLandSound { get { return heavyLandSound; } }
	public AudioClip ScreamSound { get { return screamSound; } }

	Coroutine parasiteSpawnRoutine;
	bool _doParasiteSpawning = false;
	public bool DoParasiteSpawning
	{
		get { return _doParasiteSpawning; }
		set
		{
			if (value != _doParasiteSpawning)
			{
				_doParasiteSpawning = value;
				if (_doParasiteSpawning)
				{
					parasiteSpawnRoutine = StartCoroutine(ParasiteSpawnRoutine());
				}
				else
				{
					StopCoroutine(parasiteSpawnRoutine);
				}
			}
		}
	}

	/// <summary>
	/// This move is guaranteed to be executed after the current move is done
	/// </summary>
	public CorruptedKinMove GuaranteedNextMove { get; set; }

	/*[Space]
	[Header("Idle Move")]
	public float idleMovementSpeedMin = 0.5f;
	public float idleMovementSpeedMax = 1.25f;
	public float idleTimeMin = 1f;
	public float idleTimeMax = 1.5f;

	[Space]
	[Header("Jump Move")]
	public float JumpHeight = 8.8f;

	[Space]
	[Header("Evade")]
	public float evadeSpeed = 25f;

	[Space]
	[Header("Overhead Slash")]
	public WeaverAnimationPlayer OverheadSlash;
	[Tooltip("The minimum distance between the boss and the player in order for the move to execute")]
	public float MinXDistance = 3.5f;


	[Space]
	[Header("Downstab")]
	public float MinDownstabHeight = 33.31f;
	public float DownstabActivationRange = 1.5f;
	public float DownstabVelocity = -60f;
	public AudioClip DownstabPrepareSound;
	public AudioClip DownstabDashSound;
	public AudioClip DownstabImpactSound;
	public GameObject DownstabBurst;
	public GameObject DownstabSlam;
	public KinProjectile KinProjectilePrefab;
	public Vector3 KinProjectileOffset = new Vector3(0f,-0.5f,0f);

	[Space]
	[Header("Airdash")]
	public float AirDashHeight = 31.5f;
	public float dashSpeed = 32f;
	public float reverseDashSpeed = 20f;
	public AudioClip DashSoundEffect;
	public GameObject DashBurst;
	public GameObject DashSlash;
	public GameObject DashSlashHit;

	[Space]
	[Header("Bomb Toss")]
	public AudioClip BombTossPrepareSound;
	public float TossPrepareDelay = 0.55f;
	public ParticleSystem TossParticles;
	public float TossParticlesSpeed = 7.5f;
	public float TossDeathWaveSize = 0.5f;
	public int TossTimes = 2;
	public float DelayBetweenTosses = 0.45f;
	public AudioClip TossSound;
	[Tooltip("The delay between starting the toss and actually tossing the bomb")]
	public float TossingDelay = 0.05f;
	public float TossBloodAngleMin = 15f;
	public float TossBloodAngleMax = 85f;
	public float BombAngularVelocity = 45f;
	public Vector3 TossBloodSpawnOffset;
	public Vector3 ScuttlerBombSpawnOffset;
	public float ScuttlerBombAirTime = 0.8f;

	[Space]
	[Header("Transformation")]
	public float transScutterSpawnY = 27.86f;
	public float transScutterSpawnMinX = 3f;
	public float transScutterSpawnMaxX = 6f;
	public float transScutterSpawnDelayMin = 0.1f;
	public float transScutterSpawnDelayMax = 0.2f;
	public Transform TargetsChild;
	public Vector2 BlobScaleMin = new Vector2(1f,1f);
	public Vector2 BlobScaleMax = new Vector2(1.4f,1.4f);
	public float transExplosionWaitTime = 0.7f;
	public float transBlobSizeIncrease = 3f;
	public float transBlobExpansionTime = 0.4f;
	public float transSummonGrassZ = 0.5f;
	public AnimationCurve transBlobSizeCurve;
	public int transTargetCount { get { return TargetsChild.childCount; } }
	public WallSplats TransformationSplats { get; private set; }

	[Space]
	[Header("Post Transformation")]
	public AudioClip transBlobExplodeSound;
	public float transBlobExplodeVolume = 1f;
	public float transEndDelay = 0.8f;
	public float transAspidShotMinSize = 0.7f;
	public float transAspidShotMaxSize = 1.3f;*/


	[Space]
	[Header("Stun")]
	public float StunPushAmount = 10f;
	public ParticleSystem ShakeGas;
	[SerializeField]
	float stunTime = 2f;

	[Space]
	[Header("Death")]
	public AudioClip BossFinalHitSound;
	//public GameObject InfectedDeathWavePrefab;
	public AudioClip BossGushingSound;
	public GameObject BossDeathPuffPrefab;
	public AudioClip DreamExitSound;
	public float bloodSpawnDelay = 0.1f;
	public AudioClip BossExplosionSound;
	public GameObject DeathExplosionPrefab;
	public ParticleSystem CorpseSteam;


	public float GravityScale { get; private set; }
	public bool PlayerIsOnWall { get; private set; }
	public float ArenaWidth
	{
		get
		{
			return rightX - leftX;
		}
	}
	List<CorruptedKinMove> _moves;
	public IEnumerable<CorruptedKinMove> Moves
	{
		get
		{
			return _moves;
		}
	}

	/// <summary>
	/// Gets the percentage distance to boss. 0% means they are at the same position, 100% means they are at polar opposite ends of the arena
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public float GetPercentageToBoss(Transform obj)
	{
		return GetDistanceToBoss(obj) / ArenaWidth;
	}

	/// <summary>
	/// Gets the distance to the boss
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public float GetDistanceToBoss(Transform obj)
	{
		return Mathf.Abs(transform.GetXPosition() - obj.transform.GetXPosition());
	}

	public void DrawPercentageLine(float percentageToBoss, Transform target)
	{
		var distance = percentageToBoss * ArenaWidth;



		if (target.transform.position.x < transform.position.x)
		{
			distance = -distance;
		}
		Debug.DrawLine(transform.position, new Vector3(transform.position.x + distance, transform.position.y, transform.position.z),Color.red,0.5f);
	}


	/*/// <summary>
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
	public int TimesDashed { get; private set; }*/

	public bool IsGrounded
	{
		get
		{
			return terrainCollisions.Count > 0;
		}
	}
	/*public ArenaZone CurrentZone
	{
		get
		{
		}
	}*/

	/*public DistanceZone PlayerZone
	{
		get
		{
			return GetZoneOfObject(Player.Player1.gameObject);
		}
	}*/

	/*DistanceZone GetZoneOfObject(GameObject obj)
	{
		var x = obj.transform.GetXPosition();
		var leftEdge = transform.position.x - (CenterZoneSize / 2f);
		var rightEdge = transform.position.x + (CenterZoneSize / 2f);

		if (x < leftEdge)
		{
			return DistanceZone.LeftZone;
		}
		else if (x < rightEdge)
		{
			return DistanceZone.CenterZone;
		}
		else
		{
			return DistanceZone.RightZone;
		}
	}*/

	/*public bool InAdjacentZone(DistanceZone a, DistanceZone b)
	{
		return a != b && (a == DistanceZone.CenterZone || b == DistanceZone.CenterZone);
	}

	public bool InFarCorners(DistanceZone a, DistanceZone b)
	{
		return (a == DistanceZone.LeftZone && b == DistanceZone.RightZone) || (a == DistanceZone.RightZone && b == DistanceZone.LeftZone);
	}*/

	/// <summary>
	/// Gets the positional percentage of the boss. 0% means the boss is at the left side of the arena, and 100% means it's at the right side
	/// </summary>
	public float BossPositionPercentage
	{
		get
		{
			return Mathf.InverseLerp(leftX,rightX,transform.position.x);
		}
	}

	public bool IsFacingRight
	{
		get
		{
			return !Renderer.flipX;
		}
	}

	public bool IsFacingPlayer
	{
		get
		{
			//If facing left
			if (Renderer.flipX)
			{
				return Player.Player1.transform.position.x < transform.position.x;
			}
			//If facing right
			else
			{
				return Player.Player1.transform.position.x >= transform.position.x;
			}
		}
	}

	/*public T GetMove<T>() where T : CorruptedKinMoveOLD
	{
		return Moves.First(m => m is T) as T;
	}*/

	void MoveSceneryBack()
	{
		var scenery = GameObject.FindObjectsOfType<SpriteRenderer>();
		foreach (var obj in scenery)
		{
			if (GameManager.instance.sm.mapZone == GlobalEnums.MapZone.GODS_GLORY)
			{
				WeaverLog.Log("CHANGING SCENERY!!!");
				if (obj.transform.position.z < 0f && (obj.name.Contains("GG_scenery") || obj.name.Contains("fg_stones") || obj.name.Contains("black_grass")))
				{
					var oldPosition = obj.transform.position;
					obj.transform.position = oldPosition.With(oldPosition.z / 2f);
				}
			}
		}
	}

	int GetHealthPercent(float percent)
	{
		return GetHealthPercent(HealthManager.Health, percent);
	}

	int GetHealthPercent(int value, float percent)
	{
		return Mathf.RoundToInt(Mathf.Lerp(0f, value, percent));
	}

	protected override void Awake()
	{
		//var prefab1 = WeaverAssets.LoadWeaverAsset<GameObject>("Blood Particles");
		//var prefab2 = WeaverAssets.LoadWeaverAsset<GameObject>("Blood Particles");

		//WeaverLog.Log("Prefab 1 = " + prefab1.GetInstanceID());
		//WeaverLog.Log("Prefab 2 = " + prefab1.GetInstanceID());

		//WeaverLog.Log("Equal = " + (prefab1 == prefab2));


		Instance = this;
		//WeaverLog.Log("Corrupted Kin has Awoken");
		//MoveSceneryBack();

		//Find all corrupted kin moves
		//var moveTypes = typeof(CorruptedKin).Assembly.GetTypes().Where(t => !t.IsAbstract && typeof(CorruptedKinMove).IsAssignableFrom(t));

		//Moves = new List<CorruptedKinMove>();

		//foreach (var moveType in moveTypes)
		//{
		//var move = (CorruptedKinMove)Activator.CreateInstance(moveType);
		//move.Kin = this;
		//_moves.Add(move);
		//AddMove(move);
		//Moves.Add(move);
		//}

		_moves = new List<CorruptedKinMove>(GetComponents<CorruptedKinMove>());

		CorruptedKinGlobals.Instance = Globals;

		Rigidbody = GetComponent<Rigidbody2D>();
		Animator = GetComponent<WeaverAnimationPlayer>();
		Renderer = GetComponent<SpriteRenderer>();
		AudioPlayer = GetComponent<AudioPlayer>();
		HealthManager = GetComponent<CorruptedKinHealth>();
		Collider = GetComponent<Collider2D>();
		Damager = GetComponent<WeaverCore.Components.DamageHero>();
		Flasher = GetComponent<SpriteFlasher>();

#if UNITY_EDITOR
		InfectionWave = GameObject.FindObjectOfType<InfectionWave>();
#endif



		Rigidbody.isKinematic = true;

		Rigidbody.gravityScale = 3.25f;
		//Shadow = GetChild("Shadow");
		Animator.PlayAnimation("Idle");
		//Shadow.SetActive(false);
		EntityHealth.Invincible = true;
		Renderer.enabled = false;

		GravityScale = Rigidbody.gravityScale;
		Rigidbody.velocity = default(Vector2);

		base.Awake();

		//var quarterHealth = HealthManager.Health / 4;

		var shakeMove = GetComponent<ShakeMove>();
		var transMove = GetComponent<TransformationMove>();
		var specialMoves = GetComponent<SpecialMoves>();

		//EntityHealth.AddHealthMilestone(quarterHealth * 3, () => DoParasiteSpawning = true);
		//EntityHealth.AddHealthMilestone(quarterHealth * 3, () => GuaranteedNextMove = GetComponent<ShakeMove>());
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.8f), () => DoParasiteSpawning = true);
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.8f), () => shakeMove.EnableMove(true));

		//EntityHealth.AddHealthMilestone(quarterHealth * 2, () => DoParasiteSpawning = false);
		//EntityHealth.AddHealthMilestone(quarterHealth * 2, () => GuaranteedNextMove = GetComponent<TransformationMove>());
		//EntityHealth.AddHealthMilestone(GetHealthPercent(0.5f), () => DoParasiteSpawning = false);
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.6f), () => shakeMove.EnableMove(false));
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.6f), () => GuaranteedNextMove = transMove);

		//EntityHealth.AddHealthMilestone(quarterHealth, () => DoParasiteSpawning = true);
		//EntityHealth.AddHealthMilestone(quarterHealth, () => GuaranteedNextMove = GetComponent<ShakeMove>());
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.35f), () => DoParasiteSpawning = true);
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.35f), () => shakeMove.EnableMove(true));

		//EntityHealth.AddHealthMilestone(Mathf.RoundToInt(quarterHealth * 0.5f), () => GuaranteedNextMove = GetComponent<SpecialMoves>());
		//EntityHealth.AddHealthMilestone(Mathf.RoundToInt(quarterHealth * 1.5f), () => GuaranteedNextMove = GetComponent<SpecialMoves>());
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.475f), () => GuaranteedNextMove = specialMoves);
		EntityHealth.AddHealthMilestone(GetHealthPercent(0.175f), () => GuaranteedNextMove = specialMoves);

		AddStunMilestone(GetHealthPercent(0.8f));
		AddStunMilestone(GetHealthPercent(0.6f));
		AddStunMilestone(GetHealthPercent(0.35f));

		/*foreach (var move in Moves)
		{
			move.OnMoveAwake();
		}*/

		if (Initialization.Environment == WeaverCore.Enums.RunningState.Editor)
		{
			StartBossBattle();
		}
		else
		{
			StartCoroutine(WaitForPlayer());
		}
	}

	void Update()
	{
		/*if (DebugShowZones)
		{
			var leftEdge = transform.position.x - (CenterZoneSize / 2f);
			var rightEdge = transform.position.x + (CenterZoneSize / 2f);

			//Debug.DrawLine(new Vector3(leftX, transform.position.y, transform.position.z), new Vector3(CenterZoneLeft, transform.position.y, transform.position.z), Color.red);
			Debug.DrawLine(new Vector3(leftX, transform.position.y, transform.position.z), new Vector3(leftEdge, transform.position.y, transform.position.z), Color.red);
			Debug.DrawLine(new Vector3(leftEdge, transform.position.y, transform.position.z), new Vector3(rightEdge, transform.position.y, transform.position.z), Color.green);
			Debug.DrawLine(new Vector3(rightEdge, transform.position.y, transform.position.z), new Vector3(rightX, transform.position.y, transform.position.z), Color.blue);
		}*/
	}

	IEnumerator WaitForPlayer()
	{
		var playerCollider = Player.Player1.GetComponent<Collider2D>();

		while (true)
		{
			var pBounds = playerCollider.bounds;
			var awakeBounds = awakeRange.bounds;

			if (Player.Player1.transform.position.y <= transform.position.y + 1f && pBounds.max.x >= leftX && pBounds.min.x <= rightX)
			{
				break;
			}
			yield return null;
		}

		awakeRange.gameObject.SetActive(false);


		StartBossBattle();
	}

	public void StartBossBattle()
	{
		StartBoundRoutine(StartBossBattleRoutine());
	}


	IEnumerator StartBossBattleRoutine()
	{
		WeaverEvents.BroadcastEvent("DREAM GATE CLOSE", gameObject);
		Rigidbody.isKinematic = false;

		if (Boss.InGodHomeArena)
		{
			//TODO
			transform.SetXPosition(rightSpawnPoint);
			Renderer.flipX = true;
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
				Renderer.flipX = true;
			}
		}

		Animator.PlayAnimation("Fall");


		AudioPlayer.Play(fallSound);

		transform.SetYPosition(fallYPosition);

		EntityHealth.Invincible = false;

		Renderer.enabled = true;

		yield return new WaitForSeconds(fallDelay);

		yield return WaitTillTouchingGround();

		floorY = transform.position.y;

		AudioPlayer.Play(heavyLandSound);


		yield return Animator.PlayAnimationTillDone("Land");

		yield return Animator.PlayAnimationTillDone("Roar Start");

		if (!Boss.InPantheon)
		{
			Music.PlayMusicPack(BossMusicPack,0f,0f,false);
			Music.ApplyMusicSnapshot(Music.SnapshotType.Normal, 0f, 0f);
		}

		Animator.PlayAnimation("Roar Loop");

		WeaverCore.Assets.AreaTitle.Spawn("Corrupted", "Kin");

		yield return Roar(2.4f, screamSound);

		yield return Animator.PlayAnimationTillDone("Roar End");


		EntityHealth.Invincible = false;

		//IdleCounter = 0.75f;

		StartCoroutine(PlayerWallDetector());

		yield return BossController();
	}

	public IEnumerator BossController()
	{
		if (BossStage >= 3 && InfectionWave == null)
		{
			var transformationMove = GetComponent<TransformationMove>();
			yield return RunMove(transformationMove);
		}
		//var idleMove = GetMove<IdleMoveOLD>();
		//var overheadMove = GetMove<OverheadSlashMoveOLD>();
		var idleMove = GetComponent<IdleMove>();
		var overheadMove = GetComponent<OverheadSlashMove>();
		var evadeMove = GetComponent<EvadeMove>();
		var bombMove = GetComponent<BombTossMove>();
		while (true)
		{
			if (GuaranteedNextMove != null)
			{
				yield return RunMove(GuaranteedNextMove);
				continue;
			}
			if (idleMove.MoveEnabled)
			{
				//Debug.Log("Idling");
				yield return RunMove(idleMove);
			}
			if (evadeMove.MoveEnabled && evadeMove.IsWithinEvadeRange(Player.Player1.transform.position) && evadeMove.HasRoomToEvade(Player.Player1.transform.position.x < transform.position.x ? CardinalDirection.Right : CardinalDirection.Left))
			{
				yield return RunMove(evadeMove);
			}
			if (PlayerIsOnWall && bombMove.MoveEnabled)
			{
				//TODO - Make Aspid Move here

				//TODO - Make bomb toss move here
				//Debug.Log("Player On Wall");
				yield return RunMove(bombMove);
			}
			else
			{
				if (overheadMove.MoveEnabled && overheadMove.InSlashRange(Player.Player1.transform.position))
				{
					yield return RunMove(overheadMove);
				}
				else
				{
					for (int i = 0; i < _moves.Count; i++)
					{
						var move = GetRandomMove();
						if (move != null && move.MoveEnabled)
						{
							yield return RunMove(move);
							break;
						}
						/*else
						{
							yield return null;
						}*/
					}
					/*bool didMove = false;
					foreach (var randomMove in GetRandomMoveList())
					{
						CorruptedKinMove kinMove = randomMove;
						if (kinMove.MoveEnabled)
						{
							didMove = true;
							yield return RunMove(kinMove);
							break;
						}
					}
					if (!didMove)
					{
						var move = GetRandomMove();
						if (move.MoveEnabled)
						{
							yield return RunMove(move);
						}
					}*/
				}
			}
		}
	}

	List<CorruptedKinMove> storedRandomMoves = new List<CorruptedKinMove>();
	CorruptedKinMove GetRandomMove()
	{
		if (storedRandomMoves.Count == 0)
		{
			storedRandomMoves.AddRange(Moves.Where(m => m.DoMoveInRandomizer));
			storedRandomMoves.RandomizeList();
		}
		if (storedRandomMoves.Count == 0)
		{
			return null;
		}
		var move = storedRandomMoves[storedRandomMoves.Count - 1];
		storedRandomMoves.RemoveAt(storedRandomMoves.Count - 1);
		return move;
	}

	/*IEnumerable<CorruptedKinMove> GetRandomMoveList()
	{
		List<CorruptedKinMove> moves = new List<CorruptedKinMove>(Moves.Where(m => m.DoMoveInRandomizer));

		moves.Sort(Randomizer<CorruptedKinMove>.Instance);

		return moves;
	}

	CorruptedKinMove GetRandomMove()
	{
		List<CorruptedKinMove> moves = new List<CorruptedKinMove>(Moves.Where(m => m.DoMoveInRandomizer));

		return moves[Random.Range(0,moves.Count)];
	}*/

	public IEnumerator TurnTowardsPlayer()
	{
		if (!IsFacingPlayer)
		{
			Animator.PlayAnimation("Turn Quick");
			var playingGUID = Animator.PlayingGUID;
			var frameTime = 1f / Animator.AnimationData.GetClipFPS("Turn Quick");

			yield return new WaitForSeconds(frameTime);

			Renderer.flipX = !Renderer.flipX;

			while (playingGUID == Animator.PlayingGUID)
			{
				yield return null;
			}
		}
	}

	public void TurnTowardsPlayerInstant()
	{
		if (!IsFacingPlayer)
		{
			Renderer.flipX = !Renderer.flipX;
		}
	}
	public IEnumerator WaitTillTouchingGround()
	{
		while (!IsGrounded)
		{
			yield return null;
		}
	}

	List<GameObject> terrainCollisions = new List<GameObject>();

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			terrainCollisions.Add(collision.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			terrainCollisions.Remove(collision.gameObject);
		}
	}


	protected override void OnDeath()
	{
		//TODO
		base.OnDeath();

		StartBoundRoutine(DeathRoutine());
	}

	public IEnumerator WaitUnlessAttacked(float time,bool skipIdleIfAttacked)
	{
		int previousHealth = HealthManager.Health;
		for (float t = 0; t < time; t += Time.deltaTime)
		{
			if (HealthManager.Health < previousHealth)
			{
				if (skipIdleIfAttacked)
				{
					GetComponent<IdleMove>().SkipNextIdle = true;
				}
				yield break;
			}
			yield return null;
		}
	}

	IEnumerator DeathRoutine()
	{
		DoParasiteSpawning = false;
		float emissionRate = 50f;
		float emissionSpeed = 5f;
		//HERE IS WHERE A SetPlayerDataBool is located. It sets corn_abyssLeft to true

		DeathState();

		Damager.DamageDealt = 0;


		CameraShaker.Instance.Shake(WeaverCore.Enums.ShakeType.AverageShake);

		WeaverAudio.PlayAtPoint(BossFinalHitSound, transform.position);

		DeactivateBattleScene();

		//var deathWave = GameObject.Instantiate(InfectedDeathWavePrefab, transform.position, Quaternion.identity);
		var deathWave = DeathWave.Spawn(transform.position,1f);

		deathWave.transform.localScale = new Vector3(3f,3f,0f);

		yield return WaitTillTouchingGround();

		if (!Boss.InGodHomeArena)
		{
			//STOP MUSIC
			Music.ApplyMusicSnapshot(Music.SnapshotType.Silent, 0f,2f);
		}

		Animator.PlayAnimation("Death Land");

		Rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(1f);

		Animator.PlayAnimation("Death");

		WeaverAudio.PlayAtPoint(BossGushingSound, transform.position);

		var deathPuff = GameObject.Instantiate(BossDeathPuffPrefab, transform.position + new Vector3(0f,0f,-5f), Quaternion.identity);
		var deathParticles = deathPuff.GetComponent<ParticleSystem>();


		CameraShaker.Instance.Shake(WeaverCore.Enums.ShakeType.BigShake);
		CameraShaker.Instance.SetRumble(WeaverCore.Enums.RumbleType.RumblingMed);

		float bloodTimer = 0f;

		for (float t = 0; t <= 3f; t += Time.deltaTime)
		{
			yield return null;
			bloodTimer += Time.deltaTime;
			if (bloodTimer >= bloodSpawnDelay)
			{
				bloodTimer -= bloodSpawnDelay;
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

		if (Initialization.Environment == WeaverCore.Enums.RunningState.Game)
		{
			GameManager.instance.AwardAchievement("DREAM_BROKEN_VESSEL");
		}

		CameraShaker.Instance.SetRumble(WeaverCore.Enums.RumbleType.None);
		WeaverAudio.PlayAtPoint(BossExplosionSound, transform.position);

		GameObject.Instantiate(DeathExplosionPrefab, transform.position, Quaternion.identity);

		CameraShaker.Instance.Shake(WeaverCore.Enums.ShakeType.BigShake);


		EndBattleScene();

		deathParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);

		CorpseSteam.Play();

		yield return Animator.PlayAnimationTillDone("Death 2");

		yield return new WaitForSeconds(0.5f);

		WeaverEvents.BroadcastEvent("IK GATE OPEN", gameObject);

		if (WeaverGameManager.CurrentMapZone == GlobalEnums.MapZone.DREAM_WORLD)
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

	protected override void OnStun()
	{
		//TODO
		base.OnStun();

		StartBoundRoutine(StunRoutine());
	}

	IEnumerator StunRoutine()
	{
		//ParasiteBalloon.DestroyAllParasites();
		StunEffect.Spawn(transform.position);

		//FacePlayer(false);
		TurnTowardsPlayerInstant();

		Animator.PlayAnimation("Stun Air");

		ResetState();

		//TODO - SET RECOIL SPEED

		yield return WaitTillTouchingGround();

		Rigidbody.velocity = default(Vector2);

		Animator.PlayAnimation("Stun");

		float timesHitBefore = HealthManager.TimesHit;

		for (float i = 0; i < stunTime; i += Time.deltaTime)
		{
			if (HealthManager.TimesHit > timesHitBefore)
			{
				break;
			}
			yield return null;
		}

		yield return Animator.PlayAnimationTillDone("Stun Recover");


		StartBoundRoutine(BossController());
	}

	GameObject GetBattleSceneObject()
	{
		return GameObject.FindGameObjectWithTag("Battle Scene");
	}

	//Not sure if this is required for anything yet, but may remove it if it does nothing
	void DeactivateBattleScene()
	{
		var battleSceneObject = GetBattleSceneObject();
		if (battleSceneObject != null)
		{
			PlayMakerUtilities.SetFsmBool(battleSceneObject, "Battle Control", "Activated", false);
		}
	}

	void EndBattleScene()
	{
		var battleSceneObject = GetBattleSceneObject();
		if (battleSceneObject != null)
		{
			WeaverEvents.SendEventToObject(battleSceneObject, "END");
		}
	}

	void DeathState()
	{
		var xScale = transform.GetXLocalScale();
		var movementAmount = xScale * StunPushAmount;

		if (transform.position.x >= MiddleX)
		{
			Renderer.flipX = true;
		}
		else
		{
			Renderer.flipX = false;
		}

		if (!IsFacingRight)
		{
			movementAmount = -movementAmount;
		}

		Rigidbody.gravityScale = GravityScale;

		Rigidbody.velocity = new Vector2(movementAmount, 20f);

		//DashSlashHit.SetActive(false);
		//DashSlash.SetActive(false);
		//OverheadSlash.gameObject.SetActive(false);

		ShakeGas.Stop(false, ParticleSystemStopBehavior.StopEmitting);
	}

	void ResetState()
	{
		var xScale = transform.GetXLocalScale();
		var movementAmount = xScale * StunPushAmount;

		if (IsFacingRight)
		{
			movementAmount = -movementAmount;
		}

		Rigidbody.gravityScale = GravityScale;

		Rigidbody.velocity = new Vector2(movementAmount, 20f);

		//DashSlashHit.SetActive(false);
		//DashSlash.SetActive(false);
		//OverheadSlash.gameObject.SetActive(false);

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

	IEnumerator PlayerWallDetector()
	{
		while (true)
		{
			PlayerIsOnWall = false;

			var playerX = Player.Player1.transform.GetXPosition();

			float timer = 0f;

			//If the x position of the player hasn't changed and the player is above the floor
			while (playerX == Player.Player1.transform.GetXPosition() && Player.Player1.transform.GetYPosition() > (floorY + 2f))
			{
				yield return null;
				timer += Time.deltaTime;
				//If the player has been on the wall for a specified amount of time
				if (timer >= playerWallTestDuration)
				{
					PlayerIsOnWall = true;
				}
			}
			PlayerIsOnWall = false;


			yield return null;
		}
	}

	IEnumerator ParasiteSpawnRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(parasiteSpawnRate);
			ParasiteBalloon.Spawn(new Vector3(UnityEngine.Random.Range(LeftX, RightX), UnityEngine.Random.Range(parasiteSpawnHeightMinMax.x, parasiteSpawnHeightMinMax.y) + FloorY), default(Vector2));
		}

	}
}
