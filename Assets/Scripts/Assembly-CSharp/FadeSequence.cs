using UnityEngine;

public class FadeSequence : SkippableSequence
{
	[SerializeField]
	private SkippableSequence childSequence;
	[SerializeField]
	private float fadeDelay;
	[SerializeField]
	private float fadeRate;
}
