using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore;
using WeaverCore.Assets.Components;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class InfectedExplosion : MonoBehaviour 
{
	[SerializeField]
	AudioClip ExplosionSound;

	[SerializeField]
	float explosionPitchMin = 0.85f;
	[SerializeField]
	float explosionPitchMax = 1.1f;

	/*[SerializeField]
	GameObject DeathWavePrefab;*/
	[SerializeField]
	float deathWaveScale = 3f;
	[SerializeField]
	OnDoneBehaviour whenDone = OnDoneBehaviour.DestroyOrPool;

	//static WeaverCore.Utilities.ObjectPool DeathWavePool;
	static WeaverCore.ObjectPool ExplosionPool;

	new Collider2D collider;

	void OnEnable()
	{
		if (collider == null)
		{
			collider = GetComponent<Collider2D>();
		}
		collider.enabled = true;
		var audio = WeaverAudio.PlayAtPoint(ExplosionSound, transform.position);
		audio.AudioSource.pitch = Random.Range(explosionPitchMin,explosionPitchMax);

		CameraShaker.Instance.Shake(WeaverCore.Enums.ShakeType.AverageShake);

		/*if (DeathWavePool == null)
		{
			DeathWavePool = new WeaverCore.Utilities.ObjectPool(DeathWavePrefab);
		}*/

		//var deathWave = DeathWavePool.Instantiate(transform.position, Quaternion.identity);
		var deathWave = DeathWave.Spawn(transform.position,0.5f);
		//Debug.Log("Position = " + transform.position);
		//Debug.Log("Death Wave Position = " + deathWave.transform.position);
		//deathWave.transform.localScale = new Vector3(deathWaveScale, deathWaveScale, 1f);

		StartCoroutine(Waiter());
	}

	IEnumerator Waiter()
	{
		yield return new WaitForSeconds(0.5f);
		collider.enabled = false;

		yield return new WaitForSeconds(1f);
		whenDone.DoneWithObject(this);
		/*switch (whenDone)
		{
			case OnDoneBehaviour.Nothing:
				break;
			case OnDoneBehaviour.Disable:
				gameObject.SetActive(false);
				break;
			case OnDoneBehaviour.Destroy:
				Destroy(gameObject);
				break;
			case OnDoneBehaviour.DestroyOrPool:
				var poolable = GetComponent<PoolableObject>();
				if (poolable != null)
				{
					poolable.ReturnToPool();
				}
				else
				{
					Destroy(gameObject);
				}
				break;
			default:
				break;
		}*/
	}

	public static InfectedExplosion Spawn(Vector3 position)
	{
		if (ExplosionPool == null)
		{
			ExplosionPool = WeaverCore.ObjectPool.Create(CorruptedKinGlobals.Instance.InfectedExplosionPrefab);
		}
		return ExplosionPool.Instantiate<InfectedExplosion>(position, Quaternion.identity);
	}
}
