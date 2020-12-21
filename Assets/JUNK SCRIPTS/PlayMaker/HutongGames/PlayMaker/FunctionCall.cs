using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FunctionCall
	{
		public string FunctionName;
		[SerializeField]
		private string parameterType;
		public FsmBool BoolParameter;
		public FsmFloat FloatParameter;
		public FsmInt IntParameter;
		public FsmGameObject GameObjectParameter;
		public FsmObject ObjectParameter;
		public FsmString StringParameter;
		public FsmVector2 Vector2Parameter;
		public FsmVector3 Vector3Parameter;
		public FsmRect RectParamater;
		public FsmQuaternion QuaternionParameter;
		public FsmMaterial MaterialParameter;
		public FsmTexture TextureParameter;
		public FsmColor ColorParameter;
		public FsmEnum EnumParameter;
		public FsmArray ArrayParameter;
	}
}
