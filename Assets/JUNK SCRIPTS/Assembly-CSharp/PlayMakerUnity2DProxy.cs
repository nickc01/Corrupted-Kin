using UnityEngine;

public class PlayMakerUnity2DProxy : MonoBehaviour
{
	public bool debug;
	public bool HandleCollisionEnter2D;
	public bool HandleCollisionExit2D;
	public bool HandleCollisionStay2D;
	public bool HandleTriggerEnter2D;
	public bool HandleTriggerExit2D;
	public bool HandleTriggerStay2D;
	public Collider2D lastTrigger2DInfo;
}
