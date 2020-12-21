using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Enums;
using WeaverCore.Utilities;

using WeaverObjectPool = WeaverCore.Utilities.ObjectPool;

public class KinProjectile : MonoBehaviour 
{
	static WeaverObjectPool KinProjectilePool;

	new Collider2D collider;
	ParticleSystem particles;
	new Rigidbody2D rigidbody;

	[SerializeField]
	float lifeTime = 8f;
	[SerializeField]
	float stretchFactor = 2f;
	[SerializeField]
	float xStretchMin = 1f;
	[SerializeField]
	float yStretchMax = 2f;
	[SerializeField]
	float scaleMultiplier = 2f;
	[SerializeField]
	OnDoneBehaviour whenDone = OnDoneBehaviour.DestroyOrPool;

	bool running = false;

	public Rigidbody2D Rigidbody
	{
		get
		{
			if (rigidbody == null)
			{
				rigidbody = GetComponent<Rigidbody2D>();
			}
			return rigidbody;
		}
	}

	void Start()
	{
		running = true;
		if (collider == null)
		{
			collider = GetComponent<Collider2D>();
			particles = GetComponentInChildren<ParticleSystem>();
			rigidbody = GetComponent<Rigidbody2D>();
		}
		transform.localScale = new Vector3(2f,2f,2f);
		collider.enabled = true;
		particles.Play();
		rigidbody.velocity = new Vector2(rigidbody.velocity.x,-12f);
		StartCoroutine(Waiter());
	}

	void FixedUpdate()
	{
		if (running)
		{
			FaceTowardsVelocity();
			Squash();
			rigidbody.AddForce(new Vector2(0f,22f));
			//rigidbody.velocity = new Vector2(rigidbody.velocity.x,rigidbody.velocity.y + (22f * Time.fixedDeltaTime));
		}
	}

	IEnumerator Waiter()
	{
		yield return new WaitForSeconds(5f);
		running = false;
		collider.enabled = false;
		particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
		yield return new WaitForSeconds(0.4f);
		switch (whenDone)
		{
			case OnDoneBehaviour.Disable:
				gameObject.SetActive(false);
				break;
			case OnDoneBehaviour.DestroyOrPool:
				var poolObject = GetComponent<PoolableObject>();
				if (poolObject != null)
				{
					poolObject.ReturnToPool();
				}
				else
				{
					goto case OnDoneBehaviour.Destroy;
				}
				break;
			case OnDoneBehaviour.Destroy:
				Destroy(gameObject);
				break;
		}
	}


	void OnDisable()
	{
		StopAllCoroutines();
	}




	void FaceTowardsVelocity()
	{
		var v = rigidbody.velocity;
		transform.rotation = Quaternion.Euler(0f,0f,Mathf.Atan2(v.y,v.x) * Mathf.Rad2Deg);
	}

	void Squash()
	{
		var stretchY = 1f - rigidbody.velocity.magnitude * stretchFactor * 0.01f;
		var stretchX = 1f + rigidbody.velocity.magnitude * stretchFactor * 0.01f;
		if (stretchX < xStretchMin)
		{
			stretchX = xStretchMin;
		}
		if (stretchY > yStretchMax)
		{
			stretchY = yStretchMax;
		}
		stretchY *= scaleMultiplier;
		stretchX *= scaleMultiplier;
		transform.localScale = new Vector3(stretchX, stretchY, transform.localScale.z);
	}

	public static void InitializePool(KinProjectile Prefab)
	{
		if (KinProjectilePool == null)
		{
			KinProjectilePool = new WeaverObjectPool(Prefab);
		}
	}

	public static KinProjectile Spawn(Vector3 position, Vector2 velocity)
	{
		var projectile = KinProjectilePool.Instantiate(position, Quaternion.identity).GetComponent<KinProjectile>();
		projectile.Rigidbody.velocity = velocity;
		return projectile;
	}
}
