using UnityEngine;
using System.Collections.Generic;

namespace InControl
{
	public class InControlManager : SingletonMonoBehavior<InControlManager, MonoBehaviour>
	{
		public bool logDebugInfo;
		public bool invertYAxis;
		public bool useFixedUpdate;
		public bool dontDestroyOnLoad;
		public bool suspendInBackground;
		public bool enableICade;
		public bool enableXInput;
		public bool xInputOverrideUpdateRate;
		public int xInputUpdateRate;
		public bool xInputOverrideBufferSize;
		public int xInputBufferSize;
		public bool enableNativeInput;
		public bool nativeInputEnableXInput;
		public bool nativeInputPreventSleep;
		public bool nativeInputOverrideUpdateRate;
		public int nativeInputUpdateRate;
		public List<string> customProfiles;
	}
}
