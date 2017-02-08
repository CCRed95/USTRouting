using System.Windows;
using System.Windows.Media;
using Core.Extensions;
using Core.Markup;

namespace Material.Markup.Converters
{
	public class SlantedCardHeaderConverter : XAMLConverter<double, double, double, Geometry>
	{
		public override Geometry Convert(double width, double height, double slantOffset)
		{
			var upperLeftCorner = new Point(0, 0);
			var upperRightCorner = upperLeftCorner.PushHorizontal(width);
			var bottomRightCorner = upperRightCorner.PushVertical(height);
			var bottomLeftCorner = upperLeftCorner.PushVertical(height - slantOffset);

			return new PathGeometry
			{
				Figures = new PathFigureCollection
				{
					new PathFigure
					{
						StartPoint = upperLeftCorner,
						Segments = new PathSegmentCollection
						{
							new LineSegment(upperRightCorner, true),
							new LineSegment(bottomRightCorner, true),
							new LineSegment(bottomLeftCorner, true)
						}
					}
				}
			};
		}
	}
}
