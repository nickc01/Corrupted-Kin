using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Utilities;

public class ScuttlerBomb : MonoBehaviour 
{
	static WeaverCore.Utilities.ObjectPool ScuttlerBombPool;

	[SerializeField]
	[Tooltip("The angular velocity in degrees per second")]
	float angularVelocity = 45f;
	[SerializeField]
	LayerMask collisionMask;

	new Rigidbody2D rigidbody;
	new Collider2D collider;
	new SpriteRenderer renderer;
	ParticleSystem particles;
	PoolableObject poolComponent;

	float airTimeCounter = 0f;

	void Awake()
	{
		if (rigidbody == null)
		{
			rigidbody = GetComponent<Rigidbody2D>();
			collider = GetComponent<Collider2D>();
			particles = GetComponentInChildren<ParticleSystem>();
			renderer = GetComponentInChildren<SpriteRenderer>();
			poolComponent = GetComponent<PoolableObject>();
		}
		renderer.enabled = true;
		collider.enabled = true;
		rigidbody.isKinematic = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!rigidbody.isKinematic && ((1 << collision.gameObject.layer) & collisionMask.value) != 0)
		{
			renderer.enabled = false;
			rigidbody.isKinematic = true;
			collider.enabled = false;
			particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
			Debug.Log("Bomb Position = " + transform.position);
			Debug.Log("Actual Air Time = " + airTimeCounter);
			InfectedExplosion.Spawn(transform.position);
			poolComponent.ReturnToPool(1f);
		}
	}

	void Update()
	{
		airTimeCounter += Time.deltaTime;
	}


	public static ScuttlerBomb Spawn(Vector3 position, Vector2 velocity, float angularVelocity)
	{
		if (ScuttlerBombPool == null)
		{
			ScuttlerBombPool = new WeaverCore.Utilities.ObjectPool(CorruptedKinGlobals.Instance.ScuttlerBombPrefab);
		}

		var instance = ScuttlerBombPool.Instantiate<ScuttlerBomb>(position, Quaternion.identity);
		instance.rigidbody.velocity = velocity;
		instance.rigidbody.angularDrag = 0f;
		instance.rigidbody.angularVelocity = angularVelocity;

		return instance;
	}

	public static ScuttlerBomb Spawn(Vector3 position, Vector2 velocity)
	{
		return Spawn(position, velocity, CorruptedKinGlobals.Instance.ScuttlerBombPrefab.angularVelocity);
	}

	public static ScuttlerBomb Spawn(Vector3 position, Vector3 destination, float time, float angularVelocity)
	{
		var gravityScale = CorruptedKinGlobals.Instance.ScuttlerBombPrefab.GetComponent<Rigidbody2D>().gravityScale;
		var velocity = MathUtilties.CalculateVelocityToReachPointNEW(position, destination, time, gravityScale);

		Debug.Log("Start = " + position);
		Debug.Log("End = " + destination);
		Debug.Log("Velocity = " + velocity);
		Debug.Log("Time = " + time);

		return Spawn(position, velocity, angularVelocity);

		/*do
		{
			var velocity = MathUtilties.CalculateVelocityToReachPoint(position, destination, time, gravityScale);

			var peak = MathUtilties.CalculateMaximumOfCurve(position.y, destination.y, time, gravityScale);

			if (time > peak.x)
			{
				time /= 2f;
				continue;
			}
			return Spawn(position, velocity, angularVelocity);
		} while (true);*/
	}
}
