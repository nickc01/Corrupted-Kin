using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class TransformationBlob : MonoBehaviour 
{
	//static WeaverCore.ObjectPool TransBlobPool;
	static Sprite defaultSprite;

	WeaverAnimationPlayer animator;
	PoolableObject pool;
	SpriteFlasher flasher;
	new SpriteRenderer renderer;

	void Awake()
	{
		if (animator == null)
		{
			animator = GetComponent<WeaverAnimationPlayer>();
			pool = GetComponent<PoolableObject>();
			flasher = GetComponent<SpriteFlasher>();
			renderer = GetComponent<SpriteRenderer>();
		}

		flasher.flashInfected();
	}

	public static TransformationBlob Spawn(Vector3 position)
	{
		/*if (TransBlobPool == null)
		{
			TransBlobPool = new WeaverCore.ObjectPool(CorruptedKinGlobals.Instance.TransBlobPrefab);
			defaultSprite = CorruptedKinGlobals.Instance.TransBlobPrefab.GetComponent<SpriteRenderer>().sprite;
		}*/
		if (defaultSprite == null)
		{
			defaultSprite = CorruptedKinGlobals.Instance.TransBlobPrefab.GetComponent<SpriteRenderer>().sprite;
		}

		//var instance = TransBlobPool.Instantiate<TransformationBlob>(position, Quaternion.identity);
		var instance = Pooling.Instantiate(CorruptedKinGlobals.Instance.TransBlobPrefab, position, Quaternion.identity);
		instance.renderer.sprite = defaultSprite;
		return instance;
	}


	public void Expand(float sizeIncrease, float time, AnimationCurve curve)
	{
		StartCoroutine(ExpandRoutine(sizeIncrease, time, curve));
	}

	IEnumerator ExpandRoutine(float sizeIncrease, float time, AnimationCurve curve)
	{
		var oldSize = transform.localScale;
		var newSize = new Vector3(oldSize.x + sizeIncrease, oldSize.y + sizeIncrease,oldSize.y + sizeIncrease);
		for (float i = 0; i < time; i += Time.deltaTime)
		{
			transform.localScale = Vector3.Lerp(oldSize,newSize,curve.Evaluate(i / time));

			yield return null;
		}
	}

	public void Explode()
	{
		StartCoroutine(ExplodeRoutine());
	}

	IEnumerator ExplodeRoutine()
	{
		yield return animator.PlayAnimationTillDone("Death");
		if (pool != null)
		{
			pool.ReturnToPool();
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
