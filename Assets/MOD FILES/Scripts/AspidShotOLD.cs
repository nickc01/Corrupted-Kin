using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Components;
using WeaverCore.Interfaces;
using WeaverCore.Utilities;


/*public class AspidShot : EnemyProjectile, IOnPool
{
	static WeaverCore.ObjectPool AspidShotPool;

	new SpriteRenderer light;
	[NonSerialized]
	WeaverAnimationPlayer anim;

	Color oldColor;


	Rigidbody2D _rigidbody;

	public Rigidbody2D Rigidbody
	{
		get
		{
			if (_rigidbody == null)
			{
				_rigidbody = GetComponent<Rigidbody2D>();
			}
			return _rigidbody;
		}
	}

	public WeaverAnimationPlayer Animator
	{
		get
		{
			if (anim == null)
			{
				anim = GetComponent<WeaverAnimationPlayer>();
			}
			return anim;
		}
	}


	protected override void Awake()
	{
		if (light == null)
		{
			anim = GetComponent<WeaverAnimationPlayer>();
			light = transform.Find("Light").GetComponent<SpriteRenderer>();
			oldColor = light.color;
		}
		light.color = oldColor;
		base.Awake();
	}

	protected override void OnProjectileDestroy()
	{
		base.OnProjectileDestroy();
		StartCoroutine(Fader());
	}

	protected override void OnDisable()
	{
		StopAllCoroutines();
		base.OnDisable();
	}

	IEnumerator Fader()
	{
		var oldColor = light.color;
		var newColor = new Color(oldColor.r,oldColor.g,oldColor.b,0f);


		var animationTime = anim.AnimationData.GetClipDuration(anim.PlayingClip);


		for (float i = 0; i < animationTime; i += Time.deltaTime)
		{
			light.color = Color.Lerp(oldColor,newColor,i / animationTime);
			yield return null;
		}
	}

	public static AspidShot Spawn(Vector3 position, Vector2 velocity)
	{
		if (AspidShotPool == null)
		{
			AspidShotPool = WeaverCore.ObjectPool.Create(CorruptedKinGlobals.Instance.AspidShotPrefab);
		}

		var instance = AspidShotPool.Instantiate<AspidShot>(position, Quaternion.identity);

		instance.Rigidbody.velocity = velocity;

		return instance;
	}

	public static AspidShot Spawn(Vector3 position, float angleDegrees, float velocity)
	{
		return Spawn(position, new Vector2(Mathf.Cos(angleDegrees * Mathf.Deg2Rad) * velocity,Mathf.Sin(angleDegrees * Mathf.Deg2Rad) * velocity));
	}

	public static AspidShot Spawn(Vector3 position, Vector3 target, float time)
	{
		return Spawn(position, target, time, CorruptedKinGlobals.Instance.AspidShotPrefab.Rigidbody.gravityScale);
	}

	public static AspidShot Spawn(Vector3 position, Vector3 target, float time, float gravityScale)
	{
		//float xVelocity = (target.x - position.x) / time;
		//MathUtilties.CalculateVelocityToReachPoint
		//float yVelocity = MathUtilties.CalculateVerticalVelocity(position.y, target.y, time, gravityScale);

		//return Spawn(position, new Vector2(xVelocity, yVelocity));

		return Spawn(position,MathUtilties.CalculateVelocityToReachPoint(position,target,time,gravityScale));
	}
}
*/