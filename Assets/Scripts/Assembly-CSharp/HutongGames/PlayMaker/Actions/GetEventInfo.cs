using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetEventInfo : FsmStateAction
	{
		public FsmGameObject sentByGameObject;
		public FsmString fsmName;
		public FsmBool getBoolData;
		public FsmInt getIntData;
		public FsmFloat getFloatData;
		public FsmVector2 getVector2Data;
		public FsmVector3 getVector3Data;
		public FsmString getStringData;
		public FsmGameObject getGameObjectData;
		public FsmRect getRectData;
		public FsmQuaternion getQuaternionData;
		public FsmMaterial getMaterialData;
		public FsmTexture getTextureData;
		public FsmColor getColorData;
		public FsmObject getObjectData;
	}
}
