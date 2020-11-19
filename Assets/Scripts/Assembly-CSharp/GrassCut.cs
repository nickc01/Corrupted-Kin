using UnityEngine;

public class GrassCut : MonoBehaviour
{
	public SpriteRenderer[] disable;
	public SpriteRenderer[] enable;
	public Collider2D[] disableColliders;
	public Collider2D[] enableColliders;
	public GameObject particles;
	public GameObject cutEffectPrefab;
}
