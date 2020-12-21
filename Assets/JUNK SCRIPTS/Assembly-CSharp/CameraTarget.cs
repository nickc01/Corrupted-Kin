using UnityEngine;

public class CameraTarget : MonoBehaviour
{
	public enum TargetMode
	{
		FOLLOW_HERO = 0,
		LOCK_ZONE = 1,
		BOSS = 2,
		FREE = 3,
	}

	public GameManager gm;
	public HeroController hero_ctrl;
	public CameraController cameraCtrl;
	public TargetMode mode;
	public Vector3 destination;
	public float xOffset;
	public float dashOffset;
	public float fallOffset;
	public float fallOffset_multiplier;
	public float xLockMin;
	public float xLockMax;
	public float yLockMin;
	public float yLockMax;
	public bool enteredLeft;
	public bool enteredRight;
	public bool enteredTop;
	public bool enteredBot;
	public bool exitedLeft;
	public bool exitedRight;
	public bool exitedTop;
	public bool exitedBot;
	public bool superDashing;
	public bool quaking;
	public float slowTime;
	public float dampTimeNormal;
	public float dampTimeSlow;
	public float xLookAhead;
	public float dashLookAhead;
	public float superDashLookAhead;
	public float fallCatcher;
	public bool stickToHeroX;
	public bool stickToHeroY;
	public bool enteredFromLockZone;
	public bool fallStick;
}
