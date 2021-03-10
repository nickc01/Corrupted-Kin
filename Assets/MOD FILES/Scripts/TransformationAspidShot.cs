using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class TransformationAspidShot : AspidShot
{
	//static WeaverCore.Utilities.ObjectPool WallBlockerPool;
	//static WeaverCore.ObjectPool TransAspidShotPool;

	[SerializeField]
	protected Vector2 shotTimeMinMax = new Vector2(0.05f,0.1f);


	public Transform Destination { get; private set; }
	//public CardinalDirection DestinationWall { get; private set; }

	CircleCollider2D circleCollider;


	protected override void Awake()
	{
		base.Awake();
		circleCollider = GetComponent<CircleCollider2D>();
		circleCollider.enabled = false;

	}

	protected override void Update()
	{
		base.Update();
		if (Vector3.Distance(transform.position,Destination.position) <= 0.5f)
		{
			circleCollider.enabled = true;
			//Debug.Log("IN RANGE");
			//Destroy();
		}
	}

	//public static void PreparePools(int prepAmounts)
	//{
		/*if (TransAspidShotPool == null)
		{
			//TransAspidShotPool = new WeaverCore.ObjectPool(CorruptedKinGlobals.Instance.TransAspidShotPrefab);
			TransAspidShotPool.FillPoolAsync(prepAmounts);
		}*/

		/*if (WallBlockerPool == null)
		{
			WallBlockerPool = new WeaverCore.Utilities.ObjectPool(CorruptedKinGlobals.Instance.WallBlockerPrefab);
			WallBlockerPool.FillPoolAsync(prepAmounts);
		}*/
	//}

	protected override void OnProjectileDestroy()
	{
		base.OnProjectileDestroy();
		if (Destination.gameObject.name == "Splat")
		{
			Destination.gameObject.SetActive(true);
		}
	}

	public static TransformationAspidShot SpawnTransformationShot(Vector3 start, Transform destination)
	{
		/*if (TransAspidShotPool == null)
		{
			PreparePools(0);
		}*/
		//var instance = TransAspidShotPool.Instantiate<TransformationAspidShot>(start, Quaternion.identity);
		var instance = Pooling.Instantiate(CorruptedKinGlobals.Instance.TransAspidShotPrefab,start,Quaternion.identity);
		instance.Destination = destination;
		//instance.DestinationWall = destinationWallSide;

		var distanceToTarget = Vector3.Distance(destination.position, start);

		instance.Rigidbody.velocity = MathUtilties.CalculateVelocityToReachPoint(start, destination.position,UnityEngine.Random.Range(instance.shotTimeMinMax.x * distanceToTarget / 100f,instance.shotTimeMinMax.y * distanceToTarget / 100f),instance.Rigidbody.gravityScale);

		return instance;
	}

}
