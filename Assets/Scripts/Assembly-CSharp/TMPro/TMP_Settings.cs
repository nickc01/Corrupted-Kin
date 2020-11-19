using System;
using UnityEngine;
using System.Collections.Generic;

namespace TMPro
{
	[Serializable]
	public class TMP_Settings : ScriptableObject
	{
		[SerializeField]
		private bool m_enableWordWrapping;
		[SerializeField]
		private bool m_enableKerning;
		[SerializeField]
		private bool m_enableExtraPadding;
		[SerializeField]
		private bool m_enableTintAllSprites;
		[SerializeField]
		private bool m_enableParseEscapeCharacters;
		[SerializeField]
		private int m_missingGlyphCharacter;
		[SerializeField]
		private bool m_warningsDisabled;
		[SerializeField]
		private TMP_FontAsset m_defaultFontAsset;
		[SerializeField]
		private string m_defaultFontAssetPath;
		[SerializeField]
		private float m_defaultFontSize;
		[SerializeField]
		private float m_defaultTextContainerWidth;
		[SerializeField]
		private float m_defaultTextContainerHeight;
		[SerializeField]
		private List<TMP_FontAsset> m_fallbackFontAssets;
		[SerializeField]
		private bool m_matchMaterialPreset;
		[SerializeField]
		private TMP_SpriteAsset m_defaultSpriteAsset;
		[SerializeField]
		private string m_defaultSpriteAssetPath;
		[SerializeField]
		private TMP_StyleSheet m_defaultStyleSheet;
		[SerializeField]
		private TextAsset m_leadingCharacters;
		[SerializeField]
		private TextAsset m_followingCharacters;
	}
}
