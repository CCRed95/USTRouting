using System.Collections.Generic;
using System.Windows;
using Core.Data.CachedObjects;
using Core.Helpers.DependencyHelpers;

namespace Core.Controls
{
	//Todo add WSXGA (not plus)
	//Todo make sure these all make sense
	public enum Viewport
	{
		NONE,
		VGA,
		PAL,
		WVGA,
		WSVGA,
		XGA,
		SVGA,
		HD720,
		WXGA,
		WXGAPLUS,
		WSXGAPLUS,
		HD1080,
		SXGA,
		SXGAPLUS,
		UXGA,
		HD2K,
		QXGA,
		WUXGA,
		UWHD,
		WQHD,
		WQXGA,
		UWQHD,
		UHD1,
		UHD4K,
		UHD8K,
		iPhone
	}
	public enum PageOrientation
	{
		Landscape,
		Portrait
	}
	public class Designer
	{
		//TODO this probably isnt const in windows.... make it dynamic per res?
		private const double ToolbarSize = 60;

		//TODO add subdivisions. Designer.DesktopViewport, Designer.MobileViewport, OR Designer.ViewPort=Any
		//TODO maybe make 2 classes for subdivisions? or inherit class and check type at assign logic?
		//TODO add mobile display sizes
		//TODO throw if more than 1 viewport subdivision property is set

		private static readonly Dictionary<Viewport, Size> ViewportMap = new Dictionary<Viewport, Size>
		{
			[Viewport.VGA] = new Size(640, 480),
			[Viewport.PAL] = new Size(768, 576),
			[Viewport.WVGA] = new Size(854, 480),
			[Viewport.WSVGA] = new Size(1024, 600),
			[Viewport.XGA] = new Size(1024, 768),
			[Viewport.SVGA] = new Size(800, 600),
			[Viewport.HD720] = new Size(1280, 720),
			[Viewport.WXGA] = new Size(1280, 800),
			[Viewport.WXGAPLUS] = new Size(1440, 900),
			[Viewport.WSXGAPLUS] = new Size(1680, 1050),
			[Viewport.HD1080] = new Size(1920, 1080),
			[Viewport.SXGA] = new Size(1280, 1024),
			[Viewport.SXGAPLUS] = new Size(1400, 1050),
			[Viewport.UXGA] = new Size(1600, 1200),
			[Viewport.HD2K] = new Size(2048, 1080),
			[Viewport.QXGA] = new Size(2048, 1536),
			[Viewport.WUXGA] = new Size(1920, 1200),
			[Viewport.UWHD] = new Size(2560, 1080),
			[Viewport.WQHD] = new Size(2560, 1440),
			[Viewport.WQXGA] = new Size(2560, 1600),
			[Viewport.UWQHD] = new Size(3440, 1440),
			[Viewport.UHD1] = new Size(3840, 2160),
			[Viewport.UHD4K] = new Size(4096, 2160),
			[Viewport.UHD8K] = new Size(7680, 4320),
			//TODO which iphone rev? 
			[Viewport.iPhone] = new Size(1334, 750)
		};
		
		public static readonly DependencyProperty ViewportProperty =
			DP.Attach<Viewport>(typeof(Designer), new FrameworkPropertyMetadata(onDesignerPageLayoutChanged));

		public static readonly DependencyProperty OrientationProperty =
			DP.Attach<PageOrientation>(typeof(Designer), new FrameworkPropertyMetadata(onDesignerPageLayoutChanged));

		public static readonly DependencyProperty CompensateForWindowsToolbarProperty =
			DP.Attach<bool>(typeof(Designer), new FrameworkPropertyMetadata(onDesignerPageLayoutChanged));


		public static Viewport GetViewport(DependencyObject i) => i.Get<Viewport>(ViewportProperty);
		public static void SetViewport(DependencyObject i, Viewport v) => i.Set(ViewportProperty, v);

		public static bool GetCompensateForWindowsToolbar(DependencyObject i) => i.Get<bool>(CompensateForWindowsToolbarProperty);
		public static void SetCompensateForWindowsToolbar(DependencyObject i, bool v) => i.Set(CompensateForWindowsToolbarProperty, v);

		public static PageOrientation GetOrientation(DependencyObject i) => i.Get<PageOrientation>(OrientationProperty);
		public static void SetOrientation(DependencyObject i, PageOrientation v) => i.Set(OrientationProperty, v);


		private static void onDesignerPageLayoutChanged(DependencyObject i, DependencyPropertyChangedEventArgs e)
		{
			var frameworkElement = i as FrameworkElement;
			if (frameworkElement == null)
				return;
			if (!LinqEntityViewModel.IsInDesignModeStatic)
				return;
			var viewport = GetViewport(i);
			if (viewport == Viewport.NONE)
			{
				frameworkElement.SetValue(FrameworkElement.WidthProperty, DependencyProperty.UnsetValue);
				frameworkElement.SetValue(FrameworkElement.HeightProperty, DependencyProperty.UnsetValue);
				return;
			}
			var associatedSize = ViewportMap[viewport];
			var orientation = GetOrientation(i);
			var compensateForWindowsToolbar = GetCompensateForWindowsToolbar(i);

			var subtractHeight = compensateForWindowsToolbar ? ToolbarSize : 0;

			if (orientation == PageOrientation.Landscape)
			{
				frameworkElement.Width = associatedSize.Width;
				frameworkElement.Height = getValidLength(associatedSize.Height - subtractHeight);
			}
			else
			{
				frameworkElement.Width = associatedSize.Height;
				frameworkElement.Height = getValidLength(associatedSize.Width - subtractHeight);
			}
		}

		private static double getValidLength(double targetLength)
		{
			return targetLength < 0 ? 0 : targetLength;
		}
	}
}
