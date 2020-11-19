using System;
using UnityEngine;

[Serializable]
public class BuildMetadata
{
	[SerializeField]
	private string branchName;
	[SerializeField]
	private string revision;
	[SerializeField]
	private long commitTime;
	[SerializeField]
	private string machineName;
	[SerializeField]
	private long buildTime;
}
