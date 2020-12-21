using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshSetAnchor : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public TextAnchor textAnchor;
		public FsmString OrTextAnchorString;
		public FsmBool commit;
	}
}
