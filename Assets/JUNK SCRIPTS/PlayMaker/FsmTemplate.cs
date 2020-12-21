using System;
using UnityEngine;
using HutongGames.PlayMaker;

[Serializable]
public class FsmTemplate : ScriptableObject
{
	[SerializeField]
	private string category;
	public Fsm fsm;
}
