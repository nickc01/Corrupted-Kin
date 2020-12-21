using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CreatePoolObjects : RigidBody2dActionBase
	{
		public FsmGameObject gameObject;
		public FsmGameObject pool;
		public FsmVector3 position;
		public FsmInt amount;
		public FsmFloat originVariationX;
		public FsmFloat originVariationY;
		public bool deactivate;
	}
}
