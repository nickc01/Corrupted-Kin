using System;
using UnityEngine;

[Serializable]
public class PrefabSwapper : MonoBehaviour
{
	public GameObject objToSwapout;
	public string[] ignoreList;
	public bool preserveZDepth;
	public bool ignorePrefabs;
}
