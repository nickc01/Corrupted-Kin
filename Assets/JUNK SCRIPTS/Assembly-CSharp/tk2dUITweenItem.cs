using UnityEngine;

public class tk2dUITweenItem : tk2dUIBaseItemControl
{
	public Vector3 onDownScale;
	public float tweenDuration;
	public bool canButtonBeHeldDown;
	[SerializeField]
	private bool useOnReleaseInsteadOfOnUp;
}
