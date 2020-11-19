using UnityEngine;

public class BossSequence : ScriptableObject
{
	[SerializeField]
	private BossScene[] bossScenes;
	public bool useSceneUnlocks;
	public BossScene.BossTest[] tests;
	public string achievementKey;
	public string customEndScene;
	public string customEndScenePlayerData;
	public int nailDamage;
	public float lowerNailDamagePercentage;
	public int maxHealth;
}
