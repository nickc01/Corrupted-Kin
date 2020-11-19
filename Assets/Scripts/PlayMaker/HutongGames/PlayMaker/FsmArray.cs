using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmArray : NamedVariable
	{
		[SerializeField]
		private VariableType type;
		[SerializeField]
		private string objectTypeName;
		public float[] floatValues;
		public int[] intValues;
		public bool[] boolValues;
		public string[] stringValues;
		public Vector4[] vector4Values;
		public UnityEngine.Object[] objectReferences;
	}
}
