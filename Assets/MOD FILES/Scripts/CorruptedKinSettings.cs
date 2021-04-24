using WeaverCore.Configuration;
using UnityEngine;

[CreateAssetMenu(fileName = "Corrupted Kin Settings", menuName = "Corrupted Kin Settings")]
public class CorruptedKinSettings : GlobalWeaverSettings
{
	[Tooltip("If set to true, this will permanently enable access to the dream arena in the abyss")]
	public bool EnableInAbyss = false;
}

