using UnityEngine;
using System;
using UnityEngine.Audio;

public class MusicCue : ScriptableObject
{
	[Serializable]
	public class MusicChannelInfo
	{
		[SerializeField]
		private AudioClip clip;
		[SerializeField]
		private MusicChannelSync sync;
	}

	[Serializable]
	public struct Alternative
	{
		public string PlayerDataBoolKey;
		public MusicCue Cue;
	}

	[SerializeField]
	private string originalMusicEventName;
	[SerializeField]
	private int originalMusicTrackNumber;
	[SerializeField]
	private AudioMixerSnapshot snapshot;
	[SerializeField]
	private MusicChannelInfo[] channelInfos;
	[SerializeField]
	private Alternative[] alternatives;
}
