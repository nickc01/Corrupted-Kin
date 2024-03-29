﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.Components;

[CreateAssetMenu(fileName = "CorruptedKinGlobals", menuName = "Corrupted Kin Globals")]
public class CorruptedKinGlobals : ScriptableObject
{
	/// <summary>
	/// The singleton for accessing the globals. Will be null until Corrupted Kin spawns
	/// </summary>
	public static CorruptedKinGlobals Instance;


	public KinProjectile KinProjectilePrefab;
	public ParasiteBalloon BalloonPrefab;
	public AspidShot AspidShotPrefab;
	public InfectedExplosion InfectedExplosionPrefab;
	public ScuttlerBomb ScuttlerBombPrefab;
	public Scuttler ScuttlerPrefab;
	public TransformationBlob TransBlobPrefab;
	public TransformationAspidShot TransAspidShotPrefab;
	public WallSplats WallSplatsPrefab;
}

