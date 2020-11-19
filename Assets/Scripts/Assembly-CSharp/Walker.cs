using UnityEngine;

public class Walker : MonoBehaviour
{
	[SerializeField]
	private LineOfSightDetector lineOfSightDetector;
	[SerializeField]
	private AlertRange alertRange;
	[SerializeField]
	private bool ambush;
	[SerializeField]
	private string idleClip;
	[SerializeField]
	private string turnClip;
	[SerializeField]
	private string walkClip;
	[SerializeField]
	private float edgeXAdjuster;
	[SerializeField]
	private bool preventScaleChange;
	[SerializeField]
	private bool preventTurn;
	[SerializeField]
	private float pauseTimeMin;
	[SerializeField]
	private float pauseTimeMax;
	[SerializeField]
	private float pauseWaitMin;
	[SerializeField]
	private float pauseWaitMax;
	[SerializeField]
	private bool pauses;
	[SerializeField]
	private float rightScale;
	[SerializeField]
	public bool startInactive;
	[SerializeField]
	private int turnAfterIdlePercentage;
	[SerializeField]
	private float turnPause;
	[SerializeField]
	private bool waitForHeroX;
	[SerializeField]
	private float waitHeroX;
	[SerializeField]
	public float walkSpeedL;
	[SerializeField]
	public float walkSpeedR;
	[SerializeField]
	public bool ignoreHoles;
	[SerializeField]
	private bool preventTurningToFaceHero;
}
