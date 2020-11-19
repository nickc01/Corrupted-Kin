using System;

namespace InControl
{
	public struct UnknownDeviceControl
	{
		public InputControlType Control;
		public InputRangeType SourceRange;
		public bool IsButton;
		public bool IsAnalog;
	}
}
