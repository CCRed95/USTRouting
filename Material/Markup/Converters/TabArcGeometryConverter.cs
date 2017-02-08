using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Core.Extensions;
using Core.Layout;
using Core.Markup;
using Material.Controls.Behaviors;

namespace Material.Markup.Converters
{
	public class TabArcGeometryConverter : XAMLConverter<double, double, TabIndex, NULLPARAM, PathGeometry>
	{
		private const double tabLineHeight = 5;

		public override PathGeometry Convert(double width, double height, TabIndex tabIndex, NULLPARAM param)
		{
			var renderSpace = new Size(width, height);

			switch (tabIndex)
			{
				case TabIndex.LeftOfSelected:
					return LeftOfSelectedGeometry(renderSpace);
				case TabIndex.RightOfSelected:
					return RightOfSelectedGeometry(renderSpace);
				case TabIndex.Selected:
					return SelectedGeometry(renderSpace);
				case TabIndex.Unselected:
					return UnselectedGeometry(renderSpace);
				default:
					throw new InvalidEnumArgumentException();
			}
		}


		private static PathGeometry LeftOfSelectedGeometry(Size renderSpace)
		{
			var leftBaseAnchor = new Point(0, 0);
			var rightBaseAnchor = leftBaseAnchor.PushHorizontal(renderSpace.Width);

			var rightSlopeVerticalPosition = renderSpace.Height / 2;

			var rightTopAnchor = rightBaseAnchor.PushVertical(rightSlopeVerticalPosition);
			var leftTopAnchor = leftBaseAnchor.PushVertical(tabLineHeight);

			var rightTopAnchorControlVector = new PolarPoint(235, 30);
			var rightTopAnchorControlPoint = rightTopAnchor.Add(rightTopAnchorControlVector.ToCartesian());

			return new PathGeometry
			{
				Figures = new PathFigureCollection
				{
					new PathFigure
					{
						StartPoint = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace),
						Segments = new PathSegmentCollection
						{
							new LineSegment {Point = rightBaseAnchor.LocalizeInCartesianSpace(renderSpace)},
							new LineSegment {Point = rightTopAnchor.LocalizeInCartesianSpace(renderSpace)},
							new QuadraticBezierSegment
							{
								Point1 = rightTopAnchorControlPoint.LocalizeInCartesianSpace(renderSpace),
								Point2 = leftTopAnchor.LocalizeInCartesianSpace(renderSpace)
							},
							new LineSegment {Point = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace)}
						}
					}
				}
			};
		}

		private static PathGeometry SelectedGeometry(Size renderSpace)
		{
			var leftBaseAnchor = new Point(0, 0);
			var rightBaseAnchor = leftBaseAnchor.PushHorizontal(renderSpace.Width);

			var slopeVerticalPosition = renderSpace.Height / 2;

			var rightTopAnchor = rightBaseAnchor.PushVertical(slopeVerticalPosition);
			var leftTopAnchor = leftBaseAnchor.PushVertical(slopeVerticalPosition);

			var leftTopAnchorControlVector = new PolarPoint(45, 30);
			var rightTopAnchorControlVector = new PolarPoint(135, 30);

			var leftTopAnchorControlPoint = leftTopAnchor.Add(leftTopAnchorControlVector.ToCartesian());
			var rightTopAnchorControlPoint = rightTopAnchor.Add(rightTopAnchorControlVector.ToCartesian());

			var topCenterAnchor = new Point(renderSpace.Width / 2, renderSpace.Height);

			return new PathGeometry
			{
				Figures = new PathFigureCollection
				{
					new PathFigure
					{
						StartPoint = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace),
						Segments = new PathSegmentCollection
						{
							new LineSegment {Point = rightBaseAnchor.LocalizeInCartesianSpace(renderSpace)},
							new LineSegment {Point = rightTopAnchor.LocalizeInCartesianSpace(renderSpace)},
							new QuadraticBezierSegment
							{
								Point1 = rightTopAnchorControlPoint.LocalizeInCartesianSpace(renderSpace),
								Point2 = topCenterAnchor.LocalizeInCartesianSpace(renderSpace)
							},
							new QuadraticBezierSegment
							{
								Point1 = leftTopAnchorControlPoint.LocalizeInCartesianSpace(renderSpace),
								Point2 = leftTopAnchor.LocalizeInCartesianSpace(renderSpace)
							},
							new LineSegment {Point = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace)}
						}
					}
				}
			};
		}

		private static PathGeometry RightOfSelectedGeometry(Size renderSpace)
		{
			var leftBaseAnchor = new Point(0, 0);
			var rightBaseAnchor = leftBaseAnchor.PushHorizontal(renderSpace.Width);

			var leftSlopeVerticalPosition = renderSpace.Height / 2;

			var rightTopAnchor = rightBaseAnchor.PushVertical(tabLineHeight);
			var leftTopAnchor = leftBaseAnchor.PushVertical(leftSlopeVerticalPosition);

			var leftTopAnchorControlVector = new PolarPoint(315, 30);
			var leftTopAnchorControlPoint = leftTopAnchor.Add(leftTopAnchorControlVector.ToCartesian());

			return new PathGeometry
			{
				Figures = new PathFigureCollection
				{
					new PathFigure
					{
						StartPoint = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace),
						Segments = new PathSegmentCollection
						{
							new LineSegment {Point = rightBaseAnchor.LocalizeInCartesianSpace(renderSpace)},
							new LineSegment {Point = rightTopAnchor.LocalizeInCartesianSpace(renderSpace)},
							new QuadraticBezierSegment
							{
								Point1 = leftTopAnchorControlPoint.LocalizeInCartesianSpace(renderSpace),
								Point2 = leftTopAnchor.LocalizeInCartesianSpace(renderSpace)
							},
							new LineSegment {Point = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace)}
						}
					}
				}
			};
		}

		private static PathGeometry UnselectedGeometry(Size renderSpace)
		{
			var leftBaseAnchor = new Point(0, 0);
			var rightBaseAnchor = leftBaseAnchor.PushHorizontal(renderSpace.Width);

			var rightTopAnchor = rightBaseAnchor.PushVertical(tabLineHeight);
			var leftTopAnchor = leftBaseAnchor.PushVertical(tabLineHeight);


			return new PathGeometry
			{
				Figures = new PathFigureCollection
				{
					new PathFigure
					{
						StartPoint = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace),
						Segments = new PathSegmentCollection
						{
							new LineSegment {Point = rightBaseAnchor.LocalizeInCartesianSpace(renderSpace)},
							new LineSegment {Point = rightTopAnchor.LocalizeInCartesianSpace(renderSpace)},
							new LineSegment {Point = leftTopAnchor.LocalizeInCartesianSpace(renderSpace)},
							new LineSegment {Point = leftBaseAnchor.LocalizeInCartesianSpace(renderSpace)}
						}
					}
				}
			};
			//var leftBaseAnchor = new Point(0, 0).LocalizeInCartesianSpace(renderSpace);
			//var rightBaseAnchor = new Point(width, 0).LocalizeInCartesianSpace(renderSpace);

			//var rightTopAnchor = rightBaseAnchor.PushVertical(-5);
			//var leftTopAnchor = leftBaseAnchor.PushVertical(-5);

			//return new PathGeometry
			//{
			//	Figures = new PathFigureCollection
			//		{
			//			new PathFigure
			//			{
			//				StartPoint = leftBaseAnchor,
			//				Segments = new PathSegmentCollection
			//				{
			//					new LineSegment {Point = rightBaseAnchor},
			//					new LineSegment {Point = rightTopAnchor},
			//					new LineSegment {Point = leftTopAnchor},
			//					new LineSegment {Point = leftBaseAnchor}
			//				}
			//			}
			//		}
			//};
		}
	}
}