using UnityEngine;
using System;

public class SceneAdditiveLoadConditional : MonoBehaviour
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
		public enum TestType
		{
			Equal = 0,
			Less = 1,
			More = 2,
			NotEqual = 3,
			LessOrEqual = 4,
			MoreOrEqual = 5,
		}

		public string playerDataInt;
		public string otherPlayerDataInt;
		public int value;
		public TestType testType;
	}

	public string sceneNameToLoad;
	public string altSceneNameToLoad;
	public string needsPlayerDataBool;
	public bool playerDataBoolValue;
	public string needsPlayerDataInt;
	public int playerDataIntValue;
	public bool isIntValue;
	public BoolTest[] extraBoolTests;
	public IntTest[] extraIntTests;
	public bool usePersistentBoolItem;
	public PersistentBoolData persistentBoolData;
	public string doorTrigger;
	public PersistentBoolData saveStateData;
}
