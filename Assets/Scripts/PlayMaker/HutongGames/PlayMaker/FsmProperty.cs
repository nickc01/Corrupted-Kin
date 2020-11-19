using System;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmProperty
	{
		public FsmObject TargetObject;
		public string TargetTypeName;
		public string PropertyName;
		public FsmBool BoolParameter;
		public FsmFloat FloatParameter;
		public FsmInt IntParameter;
		public FsmGameObject GameObjectParameter;
		public FsmString StringParameter;
		public FsmVector2 Vector2Parameter;
		public FsmVector3 Vector3Parameter;
		public FsmRect RectParamater;
		public FsmQuaternion QuaternionParameter;
		public FsmObject ObjectParameter;
		public FsmMaterial MaterialParameter;
		public FsmTexture TextureParameter;
		public FsmColor ColorParameter;
		public FsmEnum EnumParameter;
		public FsmArray ArrayParameter;
		public bool setProperty;
	}
}
