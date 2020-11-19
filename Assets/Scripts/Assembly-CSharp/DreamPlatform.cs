using UnityEngine;

public class DreamPlatform : MonoBehaviour
{
	public TriggerEnterEvent outerCollider;
	public TriggerEnterEvent innerCollider;
	public Animator animator;
	public AudioClip activateSound;
	public AudioClip deactivateSound;
	public bool showOnEnable;
}
