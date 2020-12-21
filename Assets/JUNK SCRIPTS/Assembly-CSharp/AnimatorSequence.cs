using UnityEngine;

public class AnimatorSequence : SkippableSequence
{
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private string animatorStateName;
	[SerializeField]
	private float normalizedFinishTime;
}
