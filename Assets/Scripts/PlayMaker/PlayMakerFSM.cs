using UnityEngine;
using HutongGames.PlayMaker;

public class PlayMakerFSM : MonoBehaviour
{
	[SerializeField]
	private Fsm fsm;
	[SerializeField]
	private FsmTemplate fsmTemplate;
	[SerializeField]
	private bool eventHandlerComponentsAdded;
}
