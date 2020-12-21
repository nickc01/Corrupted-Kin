using UnityEngine;
using System;

public class GeoControl : MonoBehaviour
{
	[Serializable]
	public struct Size
	{
		public string idleAnim;
		public string airAnim;
		public int value;
	}

	public Size[] sizes;
	public int type;
	public AudioClip[] pickupSounds;
	public VibrationData pickupVibration;
	public ParticleSystem acidEffect;
	public GameObject getterBug;
}
