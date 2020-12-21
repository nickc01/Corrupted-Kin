using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float spawnChance;
	public iTween.EaseType easeType;
	public Vector3 moveBy;
	public float easeTime;
	public Color startColor;
	public Color endColor;
	public EventRegister killEvent;
}
