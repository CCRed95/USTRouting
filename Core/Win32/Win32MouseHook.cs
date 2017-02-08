using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace Core.Win32
{
	public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
	public delegate void Win32MouseCallback(Point p);

	public static class Win32MouseHook 
	{
		public static event Win32MouseCallback MouseDown;

		private static void raiseMouseDown(Point p) => MouseDown?.Invoke(p);

		private static readonly LowLevelMouseProc _proc = HookCallback;
		private static IntPtr _hookID = IntPtr.Zero;

		static Win32MouseHook()
		{
			_hookID = SetHook(_proc);
			//UnhookWindowsHookEx(_hookID);
		}

		private static IntPtr SetHook(LowLevelMouseProc proc)
		{
			using (var curProcess = Process.GetCurrentProcess())
			using (var curModule = curProcess.MainModule)
			{
				return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
			}
		}

		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0 && MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
			{
				var hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
				raiseMouseDown(new Point(hookStruct.pt.x, hookStruct.pt.y));
			}
			return CallNextHookEx(_hookID, nCode, wParam, lParam);
		}

		private const int WH_MOUSE_LL = 14;

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);
	}
}