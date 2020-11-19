using UnityEngine;
using System;

public class BossScene : ScriptableObject
{
	[Serializable]
	public class BossTest
	{
		[Serializable]
		public struct BoolTest
		{
			public string playerDataBool;
			public bool value;
		}

		[Serializable]
		public struct IntTest
		{
			public enum Comparison
			{
				Equal = 0,
				NotEqual = 1,
				MoreThan = 2,
				LessThan = 3,
			}

			public string playerDataInt;
			public int value;
			public Comparison comparison;
		}

		public enum SharedDataTest
		{
			GGUnlock = 0,
		}

		public PersistentBoolData persistentBool;
		public BoolTest[] boolTests;
		public IntTest[] intTests;
		public SharedDataTest[] sharedData;
	}

	public string sceneName;
	public BossTest[] bossTests;
	public BossScene baseBoss;
	public bool substituteBoss;
	[SerializeField]
	private Sprite displayIcon;
	public bool isHidden;
	[SerializeField]
	private bool forceAssetUnload;
	public bool requireUnlock;
	[SerializeField]
	private BossScene tier1Scene;
	[SerializeField]
	private BossScene tier2Scene;
	[SerializeField]
	private BossScene tier3Scene;
}
