using System.Runtime.InteropServices;

namespace Core.Win32
{
	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int x;
		public int y;
	}
}