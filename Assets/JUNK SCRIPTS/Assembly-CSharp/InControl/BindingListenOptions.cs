namespace InControl
{
	public class BindingListenOptions
	{
		public bool IncludeControllers;
		public bool IncludeUnknownControllers;
		public bool IncludeNonStandardControls;
		public bool IncludeMouseButtons;
		public bool IncludeMouseScrollWheel;
		public bool IncludeKeys;
		public bool IncludeModifiersAsFirstClassKeys;
		public uint MaxAllowedBindings;
		public uint MaxAllowedBindingsPerType;
		public bool AllowDuplicateBindingsPerSet;
		public bool UnsetDuplicateBindingsOnSet;
		public bool RejectRedundantBindings;
	}
}
