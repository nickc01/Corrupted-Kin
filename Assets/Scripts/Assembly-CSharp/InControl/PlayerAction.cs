namespace InControl
{
	public class PlayerAction : OneAxisInputControl
	{
		public BindingSourceType LastInputType;
		public ulong LastInputTypeChangedTick;
		public InputDeviceClass LastDeviceClass;
		public InputDeviceStyle LastDeviceStyle;
	}
}
