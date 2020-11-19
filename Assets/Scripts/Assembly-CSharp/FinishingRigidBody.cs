using UnityEngine;

public class FinishingRigidBody : MonoBehaviour
{
	private enum Conclusions
	{
		Disable = 0,
		Recycle = 1,
		Destroy = 2,
	}

	[SerializeField]
	private float waitDuration;
	[SerializeField]
	private float shrinkDuration;
	[SerializeField]
	private Conclusions conclusion;
	[SerializeField]
	private bool persistOffScreen;
}
