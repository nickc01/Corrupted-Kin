using System.Collections;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Utilities;

[RequireComponent(typeof(PoolableObject))]
public abstract class AspidShotBase : EnemyProjectile
{
	[Header("Aspid Shot Info")]
	[SerializeField]
	string startAnimation = "Idle";
	[SerializeField]
	string deathAnimation = "Impact";
	[SerializeField]
	AudioClip ImpactClip;
	[SerializeField]
	float lifeTime = 5f;


	new SpriteRenderer light;
	WeaverAnimationPlayer anim;
	PoolableObject poolComponent;

	Color oldColor;

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
			poolComponent = GetComponent<PoolableObject>();
			light = transform.Find("Light").GetComponent<SpriteRenderer>();
			oldColor = light.color;
		}
		light.color = oldColor;
		poolComponent.ReturnToPool(lifeTime);
		if (!string.IsNullOrEmpty(startAnimation))
		{
			anim.PlayAnimation(startAnimation);
		}
		base.Awake();
	}

	protected override void OnHit(GameObject collision)
	{
		base.OnHit(collision);
		AspidImpact();
	}

	public void AspidImpact()
	{
		if (!string.IsNullOrEmpty(deathAnimation))
		{
			anim.PlayAnimation(deathAnimation);
		}
		Audio.PlayAtPoint(ImpactClip, transform.position);
		StartCoroutine(Fader());
	}

	IEnumerator Fader()
	{
		var oldColor = light.color;
		var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 0f);


		var animationTime = anim.AnimationData.GetClipDuration(anim.PlayingClip);


		for (float i = 0; i < animationTime; i += Time.deltaTime)
		{
			light.color = Color.Lerp(oldColor, newColor, i / animationTime);
			yield return null;
		}

		yield return anim.WaitforClipToFinish();

		poolComponent.ReturnToPool();
	}
}
