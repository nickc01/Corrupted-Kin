using UnityEngine;

public class BossSceneController : MonoBehaviour
{
	public Transform heroSpawn;
	public GameObject transitionPrefab;
	public EventRegister endTransitionEvent;
	public bool doTransitionIn;
	public float transitionInHoldTime;
	public bool doTransitionOut;
	public float transitionOutHoldTime;
	public HealthManager[] bosses;
	public float bossesDeadWaitTime;
	public TransitionPoint customExitPoint;
}
