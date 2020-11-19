using UnityEngine;
using System;
using HutongGames.PlayMaker;

public class PlayMakerUGuiComponentProxy : MonoBehaviour
{
	[Serializable]
	public struct FsmVariableSetup
	{
		public PlayMakerUGuiComponentProxy.PlayMakerProxyVariableTarget target;
		public GameObject gameObject;
		public PlayMakerFSM fsmComponent;
		public int fsmIndex;
		public int variableIndex;
		public VariableType variableType;
		public string variableName;
	}

	[Serializable]
	public struct FsmEventSetup
	{
		public PlayMakerUGuiComponentProxy.PlayMakerProxyEventTarget target;
		public GameObject gameObject;
		public PlayMakerFSM fsmComponent;
		public string customEventName;
		public string builtInEventName;
	}

	public enum ActionType
	{
		SendFsmEvent = 0,
		SetFsmVariable = 1,
	}

	public enum PlayMakerProxyVariableTarget
	{
		Owner = 0,
		GameObject = 1,
		GlobalVariable = 2,
		FsmComponent = 3,
	}

	public enum PlayMakerProxyEventTarget
	{
		Owner = 0,
		GameObject = 1,
		BroadCastAll = 2,
		FsmComponent = 3,
	}

	public bool debug;
	public OwnerDefaultOption UiTargetOption;
	public GameObject UiTarget;
	public ActionType action;
	public FsmVariableSetup fsmVariableSetup;
	public FsmEventSetup fsmEventSetup;
}
