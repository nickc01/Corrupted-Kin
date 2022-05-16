using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public sealed class TransformationAspidShot : AspidShotBase
{
	[SerializeField]
	Vector2 shotTimeMinMax = new Vector2(1f, 5f);

	public Vector3 SpawnPosition { get; private set; }
	public Transform Destination { get; private set; }

	[SerializeField]
	float targetOffset = 0f;

	[SerializeField]
	float wallHeight = 9.80269f;

	bool hit;

	protected override void Awake()
	{
		hit = false;
		SpawnPosition = transform.position;
		base.Awake();
	}

	protected override void Update()
	{
		if (!hit)
		{
			base.Update();
			if (Destination.position.y - CorruptedKin.Instance.FloorY >= wallHeight)
			{
				if (transform.position.y >= Destination.transform.position.y)
				{
					OnHit(Destination.gameObject);
					PointAwayFrom(transform.position + new Vector3(0f, 1f));
				}
			}
			else
			{
				if (Destination.position.x > CorruptedKin.Instance.MiddleX)
				{
					if (transform.position.x >= Destination.position.x + targetOffset)
					{
						OnHit(Destination.gameObject);
						if (transform.position.y < CorruptedKin.Instance.FloorY)
						{
							PointAwayFrom(transform.position + new Vector3(0f, -1f));
						}
						else
						{
							PointAwayFrom(transform.position + new Vector3(1f, 0f));
						}
					}
				}
				else
				{
					if (transform.position.x <= Destination.position.x - targetOffset)
					{
						OnHit(Destination.gameObject);
						if (transform.position.y < CorruptedKin.Instance.FloorY)
						{
							PointAwayFrom(transform.position + new Vector3(0f, -1f));
						}
						else
						{
							PointAwayFrom(transform.position + new Vector3(-1f, 0f));
						}
					}
				}
			}
		}
	}

	protected override void OnHit(GameObject collision)
	{
		hit = true;
		if(Destination.gameObject.name == "Splat")
		{
			Destination.gameObject.SetActive(true);
		}
		base.OnHit(collision);
	}

	public static TransformationAspidShot SpawnTransformationShot(Vector3 start, Transform destination)
	{
		var instance = Pooling.Instantiate(CorruptedKinGlobals.Instance.TransAspidShotPrefab, start, Quaternion.identity);
		instance.Destination = destination;

		var distanceToTarget = Vector3.Distance(destination.position, start);

		instance.Rigidbody.velocity = MathUtilities.CalculateVelocityToReachPoint(start, destination.position, UnityEngine.Random.Range(instance.shotTimeMinMax.x * distanceToTarget / 100f, instance.shotTimeMinMax.y * distanceToTarget / 100f), instance.Rigidbody.gravityScale);

		return instance;
	}
}
