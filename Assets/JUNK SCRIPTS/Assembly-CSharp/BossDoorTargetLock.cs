using UnityEngine;
using System;

public class BossDoorTargetLock : MonoBehaviour
{
	[Serializable]
	public class BossDoorTarget
	{
		public BossSequenceDoor door;
		public GameObject indicator;
	}

	public BossDoorTarget[] targets;
	public string playerData;
	public TriggerEnterEvent unlockTrigger;
	public string unlockAnimation;
	public string unlockedAnimation;
}
