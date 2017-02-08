using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Material.Controls
{
	public class OpaqueClickableImage : Image
	{
		protected override HitTestResult HitTestCore(PointHitTestParameters e)
		{
			var src = (BitmapSource)Source;
			var x = (int)(e.HitPoint.X / ActualWidth * src.PixelWidth);
			var y = (int)(e.HitPoint.Y / ActualHeight * src.PixelHeight);
			if (x == src.PixelWidth)
				x--;
			if (y == src.PixelHeight)
				y--;
			var pixel = new byte[4];
			src.CopyPixels(new Int32Rect(x, y, 1, 1), pixel, 4, 0);
			if (pixel[3] < 1)
				return null;
			return new PointHitTestResult(this, e.HitPoint);
		}
	}
}
