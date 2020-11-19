using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmVar
	{
		public string variableName;
		public string objectType;
		public bool useVariable;
		[SerializeField]
		private VariableType type;
		public float floatValue;
		public int intValue;
		public bool boolValue;
		public string stringValue;
		public Vector4 vector4Value;
		public UnityEngine.Object objectReference;
		public FsmArray arrayValue;
	}
}
