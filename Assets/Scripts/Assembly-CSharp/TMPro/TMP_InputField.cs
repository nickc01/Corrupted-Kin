using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine;

namespace TMPro
{
	public class TMP_InputField : Selectable
	{
		[Serializable]
		public class SubmitEvent : UnityEvent<string>
		{
		}

		[Serializable]
		public class OnChangeEvent : UnityEvent<string>
		{
		}

		public enum ContentType
		{
			Standard = 0,
			Autocorrected = 1,
			IntegerNumber = 2,
			DecimalNumber = 3,
			Alphanumeric = 4,
			Name = 5,
			EmailAddress = 6,
			Password = 7,
			Pin = 8,
			Custom = 9,
		}

		public enum InputType
		{
			Standard = 0,
			AutoCorrect = 1,
			Password = 2,
		}

		public enum LineType
		{
			SingleLine = 0,
			MultiLineSubmit = 1,
			MultiLineNewline = 2,
		}

		public enum CharacterValidation
		{
			None = 0,
			Integer = 1,
			Decimal = 2,
			Alphanumeric = 3,
			Name = 4,
			EmailAddress = 5,
		}

		[SerializeField]
		protected RectTransform m_TextViewport;
		[SerializeField]
		protected TMP_Text m_TextComponent;
		[SerializeField]
		protected Graphic m_Placeholder;
		[SerializeField]
		private ContentType m_ContentType;
		[SerializeField]
		private InputType m_InputType;
		[SerializeField]
		private char m_AsteriskChar;
		[SerializeField]
		private TouchScreenKeyboardType m_KeyboardType;
		[SerializeField]
		private LineType m_LineType;
		[SerializeField]
		private bool m_HideMobileInput;
		[SerializeField]
		private CharacterValidation m_CharacterValidation;
		[SerializeField]
		private int m_CharacterLimit;
		[SerializeField]
		private SubmitEvent m_OnEndEdit;
		[SerializeField]
		private SubmitEvent m_OnSubmit;
		[SerializeField]
		private SubmitEvent m_OnFocusLost;
		[SerializeField]
		private OnChangeEvent m_OnValueChanged;
		[SerializeField]
		private Color m_CaretColor;
		[SerializeField]
		private bool m_CustomCaretColor;
		[SerializeField]
		private Color m_SelectionColor;
		[SerializeField]
		protected string m_Text;
		[SerializeField]
		private float m_CaretBlinkRate;
		[SerializeField]
		private int m_CaretWidth;
		[SerializeField]
		private bool m_ReadOnly;
		[SerializeField]
		private bool m_RichText;
	}
}
