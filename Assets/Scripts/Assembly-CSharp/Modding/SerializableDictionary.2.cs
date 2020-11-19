using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modding
{
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		[SerializeField]
		private List<TKey> _keys;
		[SerializeField]
		private List<TValue> _values;
	}
}
