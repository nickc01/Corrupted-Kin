using System;
using UnityEngine;

public class BreakableWithExternalDebris : Breakable
{
	[Serializable]
	public struct ExternalDebris
	{
		public GameObject Prefab;
		public int Count;
	}

	[Serializable]
	public class WeightedExternalDebrisItem : WeightedItem
	{
		public BreakableWithExternalDebris.ExternalDebris Value;
	}

	[SerializeField]
	private float debrisPrefabPositionVariance;
	[SerializeField]
	private ExternalDebris[] externalDebris;
	[SerializeField]
	private WeightedExternalDebrisItem[] externalDebrisVariants;
}
