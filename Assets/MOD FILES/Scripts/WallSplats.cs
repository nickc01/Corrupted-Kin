using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallSplats : MonoBehaviour 
{
	static WallSplats instance;

	List<Transform> splats;
	List<Transform> otherTargets;

	public IEnumerable<Transform> Splats { get { return splats; } }
	public IEnumerable<Transform> OtherTargets { get { return otherTargets; } }

	public IEnumerable<Transform> AllTargets { get { return otherTargets.Concat(Splats); } }

	void Awake()
	{
		var extras = transform.Find("Extra");
		if (GameManager.instance.sm.mapZone == GlobalEnums.MapZone.DREAM_WORLD)
		{
			extras.gameObject.SetActive(false);
		}
		else
		{
			extras.gameObject.SetActive(true);
		}
		splats = new List<Transform>();
		otherTargets = new List<Transform>();
		foreach (var splat in transform.GetComponentsInChildren<SpriteRenderer>())
		{
			if (splat.gameObject.name == "Splat" && splat.gameObject.activeInHierarchy)
			{
				splat.gameObject.SetActive(false);
				splats.Add(splat.transform);
			}
		}

		var otherTargetParent = transform.Find("Other Targets");
		for (int i = 0; i < otherTargetParent.childCount; i++)
		{
			otherTargets.Add(otherTargetParent.GetChild(i));
		}
		/*for (int i = 0; i < transform.childCount; i++)
		{
			var child = transform.GetChild(i);
			if (child.name == "Splat" && child.gameObject.activeInHierarchy)
			{

			}
		}*/
	}


	public static WallSplats Spawn(float leftX, float floorY)
	{
		if (instance != null)
		{
			return instance;
		}

		return GameObject.Instantiate(CorruptedKinGlobals.Instance.WallSplatsPrefab, new Vector3(leftX, floorY), Quaternion.identity);
	}
}
