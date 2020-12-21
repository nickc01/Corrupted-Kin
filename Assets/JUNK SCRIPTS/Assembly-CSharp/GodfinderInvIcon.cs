using UnityEngine;
using System;

public class GodfinderInvIcon : MonoBehaviour
{
	[Serializable]
	public class BossSceneExtra
	{
		public BossScene bossScene;
		public BossScene.BossTest[] extraTests;
	}

	public Sprite normalSprite;
	public Sprite newBossSprite;
	public Sprite allBossesSprite;
	public BossScene[] bosses;
	public BossSceneExtra[] extraBosses;
}
