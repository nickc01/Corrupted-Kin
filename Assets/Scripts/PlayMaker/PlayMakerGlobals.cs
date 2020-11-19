using UnityEngine;
using HutongGames.PlayMaker;
using System.Collections.Generic;

public class PlayMakerGlobals : ScriptableObject
{
	[SerializeField]
	private FsmVariables variables;
	[SerializeField]
	private List<string> events;
}
