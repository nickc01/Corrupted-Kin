using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetProceduralVector3 : FsmStateAction
	{
		public FsmMaterial substanceMaterial;
		public FsmString vector3Property;
		public FsmVector3 vector3Value;
		public bool everyFrame;
	}
}
