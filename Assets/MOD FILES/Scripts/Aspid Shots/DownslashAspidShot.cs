using System.Collections;
using UnityEngine;
using WeaverCore;

public class DownslashAspidShot : AspidShotBase
{
	[Space]
	[Header("Downslash Specific Properties")]
	[SerializeField]
	float deaccelerationRate = 1f;
	[SerializeField]
	float velocityDestructionThreshold = 1f;
	[SerializeField]
	float fadeTime = 0.5f;
	[SerializeField]
	AnimationCurve fadeOutCurve;

	ParticleSystem paintParticles;

	bool alive = true;
	Coroutine fadeCoroutine;

	protected override void Awake()
	{
		if (paintParticles == null)
		{
			paintParticles = GetComponentInChildren<ParticleSystem>();
		}
		paintParticles.Play();
		base.Awake();
	}

	protected override void Update()
	{
		if (alive)
		{
			var velocity = Rigidbody.velocity;
			velocity = velocity.normalized * (velocity.magnitude - (deaccelerationRate * Time.deltaTime));
			Rigidbody.velocity = velocity;
			if (velocity.magnitude <= velocityDestructionThreshold)
			{
				alive = false;
				paintParticles.Stop();
				fadeCoroutine = StartCoroutine(FadeOutRoutine());
			}
		}
		base.Update();
	}

	IEnumerator FadeOutRoutine()
	{
		for (float i = 0f; i < fadeTime; i += Time.deltaTime)
		{
			ScaleFactor = Mathf.Lerp(1f, 0f, fadeOutCurve.Evaluate(i / fadeTime));
			yield return null;
		}
		ScaleFactor = 0f;
		Pooling.Destroy(this);
	}

	protected override void OnImpact()
	{
		alive = false;
		if (fadeCoroutine != null)
		{
			StopCoroutine(fadeCoroutine);
			fadeCoroutine = null;
		}
		paintParticles.Stop();
		base.OnImpact();
	}
}
