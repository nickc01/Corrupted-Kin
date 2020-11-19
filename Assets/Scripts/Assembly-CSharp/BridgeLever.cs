using UnityEngine;

public class BridgeLever : MonoBehaviour
{
	public string playerDataBool;
	public Collider2D bridgeCollider;
	public BridgeSection[] sections;
	public AudioSource audioPlayerPrefab;
	public AudioEvent switchSound;
	public GameObject strikeNailPrefab;
	public Transform hitOrigin;
}
