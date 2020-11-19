using UnityEngine;

public class PlanarRealtimeReflection : MonoBehaviour
{
	public bool m_DisablePixelLights;
	public int m_TextureResolution;
	public float m_clipPlaneOffset;
	public bool m_NormalsFromMesh;
	public bool m_BaseClipOffsetFromMesh;
	public bool m_BaseClipOffsetFromMeshInverted;
	public LayerMask m_ReflectLayers;
}
