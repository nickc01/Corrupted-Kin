using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SelectRandomVector3 : FsmStateAction
	{
		public FsmVector3[] vector3Array;
		public FsmFloat[] weights;
		public FsmVector3 storeVector3;
	}
}
