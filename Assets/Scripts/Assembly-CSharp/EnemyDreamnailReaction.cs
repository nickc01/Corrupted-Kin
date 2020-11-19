using UnityEngine;

public class EnemyDreamnailReaction : MonoBehaviour
{
	[SerializeField]
	private int convoAmount;
	[SerializeField]
	private string convoTitle;
	[SerializeField]
	private bool startSuppressed;
	[SerializeField]
	private bool noSoul;
	[SerializeField]
	private GameObject dreamImpactPrefab;
	public bool allowUseChildColliders;
}
