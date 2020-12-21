using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SceneData
{
	[SerializeField]
	public List<GeoRockData> geoRocks;
	[SerializeField]
	public List<PersistentBoolData> persistentBoolItems;
	[SerializeField]
	public List<PersistentIntData> persistentIntItems;
}
