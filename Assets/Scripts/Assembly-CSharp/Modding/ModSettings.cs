using System;
using UnityEngine;

namespace Modding
{
	[Serializable]
	public class ModSettings
	{
		[SerializeField]
		public SerializableBoolDictionary BoolValues;
		[SerializeField]
		public SerializableFloatDictionary FloatValues;
		[SerializeField]
		public SerializableIntDictionary IntValues;
		[SerializeField]
		public SerializableStringDictionary StringValues;
	}
}
