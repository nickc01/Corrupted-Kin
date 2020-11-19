using UnityEngine;
using System;
using Language;

public class ActivatePerLanguage : MonoBehaviour
{
	[Serializable]
	public struct LangBoolPair
	{
		public LanguageCode language;
		public bool activate;
	}

	public GameObject target;
	public GameObject alt;
	public LangBoolPair[] languages;
	public bool defaultActivation;
}
