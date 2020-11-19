using System;
using UnityEngine;
using System.Collections.Generic;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class Fsm
	{
		private enum EditorFlags
		{
			none = 0,
			nameIsExpanded = 1,
			controlsIsExpanded = 2,
			debugIsExpanded = 4,
			experimentalIsExpanded = 8,
		}

		[SerializeField]
		private int dataVersion;
		[SerializeField]
		private FsmTemplate usedInTemplate;
		[SerializeField]
		private string name;
		[SerializeField]
		private string startState;
		[SerializeField]
		private FsmState[] states;
		[SerializeField]
		private FsmEvent[] events;
		[SerializeField]
		private FsmTransition[] globalTransitions;
		[SerializeField]
		private FsmVariables variables;
		[SerializeField]
		private string description;
		[SerializeField]
		private string docUrl;
		[SerializeField]
		private bool showStateLabel;
		[SerializeField]
		private int maxLoopCount;
		[SerializeField]
		private string watermark;
		[SerializeField]
		private string password;
		[SerializeField]
		private bool locked;
		[SerializeField]
		private bool manualUpdate;
		[SerializeField]
		private bool keepDelayedEventsOnStateExit;
		[SerializeField]
		private bool preprocessed;
		public List<FsmEvent> ExposedEvents;
		public bool RestartOnEnable;
		public bool EnableDebugFlow;
		public bool EnableBreakpoints;
		[SerializeField]
		private EditorFlags editorFlags;
		[SerializeField]
		private string activeStateName;
		[SerializeField]
		private bool mouseEvents;
		[SerializeField]
		private bool handleLevelLoaded;
		[SerializeField]
		private bool handleTriggerEnter2D;
		[SerializeField]
		private bool handleTriggerExit2D;
		[SerializeField]
		private bool handleTriggerStay2D;
		[SerializeField]
		private bool handleCollisionEnter2D;
		[SerializeField]
		private bool handleCollisionExit2D;
		[SerializeField]
		private bool handleCollisionStay2D;
		[SerializeField]
		private bool handleTriggerEnter;
		[SerializeField]
		private bool handleTriggerExit;
		[SerializeField]
		private bool handleTriggerStay;
		[SerializeField]
		private bool handleCollisionEnter;
		[SerializeField]
		private bool handleCollisionExit;
		[SerializeField]
		private bool handleCollisionStay;
		[SerializeField]
		private bool handleParticleCollision;
		[SerializeField]
		private bool handleControllerColliderHit;
		[SerializeField]
		private bool handleJointBreak;
		[SerializeField]
		private bool handleJointBreak2D;
		[SerializeField]
		private bool handleOnGUI;
		[SerializeField]
		private bool handleFixedUpdate;
		[SerializeField]
		private bool handleApplicationEvents;
		[SerializeField]
		private bool handleAnimatorMove;
		[SerializeField]
		private bool handleAnimatorIK;
	}
}
