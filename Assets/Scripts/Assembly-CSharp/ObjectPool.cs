using UnityEngine;
using System;

public class ObjectPool : MonoBehaviour
{
	[Serializable]
	public class StartupPool
	{
		public int size;
		public GameObject prefab;
	}

	public StartupPool[] startupPools;
}
