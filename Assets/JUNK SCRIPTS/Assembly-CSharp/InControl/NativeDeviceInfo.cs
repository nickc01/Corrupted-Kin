using System;

namespace InControl
{
	public struct NativeDeviceInfo
	{
		public string name;
		public string location;
		public string serialNumber;
		public ushort vendorID;
		public ushort productID;
		public uint versionNumber;
		public NativeDeviceDriverType driverType;
		public NativeDeviceTransportType transportType;
		public uint numButtons;
		public uint numAnalogs;
	}
}
