//using System.Windows;
//using System.Windows.Forms;

//namespace Core.Extensions
//{
//	public static class WindowExtentions
//	{
//		public static void MoveToMonitor(this Window i, int monitorId)
//		{
//			var screens = Screen.AllScreens;
//			var screenId = monitorId;
//			if (screens.Length <= 1 || screenId >= screens.Length)
//			{
//				i.WindowStyle = WindowStyle.None;
//				return;
//			}
//			var screen = screens[screenId];
//			var area = screen.WorkingArea;
//			i.Left = area.Left;
//			i.Top = area.Top;
//			i.Width = area.Width;
//			i.Height = area.Height;
//			i.WindowStyle = WindowStyle.None;
//		}
//	}
//}
