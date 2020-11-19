using UnityEngine;

namespace ToJ
{
	public class Mask : MonoBehaviour
	{
		public enum MappingAxis
		{
			X = 0,
			Y = 1,
			Z = 2,
		}

		[SerializeField]
		private MappingAxis _maskMappingWorldAxis;
		[SerializeField]
		private bool _invertAxis;
		[SerializeField]
		private bool _clampAlphaHorizontally;
		[SerializeField]
		private bool _clampAlphaVertically;
		[SerializeField]
		private float _clampingBorder;
		[SerializeField]
		private bool _useMaskAlphaChannel;
	}
}
