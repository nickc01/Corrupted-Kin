using System;

public class BossSequenceController
{
	[Serializable]
	public class BossSequenceData
	{
		public BossSequenceController.ChallengeBindings bindings;
		public float timer;
		public bool knightDamaged;
		public string playerData;
		public BossSequenceDoor.Completion previousCompletion;
		public int[] previousEquippedCharms;
		public bool wasOvercharmed;
		public string bossSequenceName;
	}

	public enum ChallengeBindings
	{
		None = 0,
		Nail = 1,
		Shell = 2,
		Charms = 4,
		Soul = 8,
	}

}
