using UnityEngine;

public class RealtimeReflections : MonoBehaviour
{
	public int cubemapSize;
	public float nearClip;
	public float farClip;
	public bool oneFacePerFrame;
	public Material[] materials;
	public ReflectionProbe[] reflectionProbes;
	public LayerMask layerMask;
}
