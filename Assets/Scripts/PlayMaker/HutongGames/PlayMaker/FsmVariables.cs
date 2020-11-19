using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmVariables
	{
		[SerializeField]
		private FsmFloat[] floatVariables;
		[SerializeField]
		private FsmInt[] intVariables;
		[SerializeField]
		private FsmBool[] boolVariables;
		[SerializeField]
		private FsmString[] stringVariables;
		[SerializeField]
		private FsmVector2[] vector2Variables;
		[SerializeField]
		private FsmVector3[] vector3Variables;
		[SerializeField]
		private FsmColor[] colorVariables;
		[SerializeField]
		private FsmRect[] rectVariables;
		[SerializeField]
		private FsmQuaternion[] quaternionVariables;
		[SerializeField]
		private FsmGameObject[] gameObjectVariables;
		[SerializeField]
		private FsmObject[] objectVariables;
		[SerializeField]
		private FsmMaterial[] materialVariables;
		[SerializeField]
		private FsmTexture[] textureVariables;
		[SerializeField]
		private FsmArray[] arrayVariables;
		[SerializeField]
		private FsmEnum[] enumVariables;
		[SerializeField]
		private string[] categories;
		[SerializeField]
		private int[] variableCategoryIDs;
	}
}
