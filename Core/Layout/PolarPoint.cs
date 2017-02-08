using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows;
using Core.Extensions;

namespace Core.Layout
{
	[DebuggerDisplay("r={Radius} φ={Angle}°")]
	public class PolarPoint
	{
		public double Angle { get; set; }
		public double Radius { get; set; }

		public PolarPoint(double angle, double radius)
		{
			Angle = angle;
			Radius = radius;
		}

		public override string ToString()
		{
			return $"r={Math.Round(Radius, 1)} φ={Math.Round(Angle, 1)}°";
		}

		public Point ToCartesian()
		{
			var angleRadian = CoordinateHelpers.ToRadian(Angle);
			var x = Radius * Math.Cos(angleRadian);
			var y = Radius * Math.Sin(angleRadian);
			return new Point(x, y);
		}

		public static PolarPoint FromCartesian(Point point)
		{
			var angle = Math.Atan2(point.Y, point.X);
			var angleDegrees = CoordinateHelpers.ToDegree(angle);
			var radius = (point.X.Squared() + point.Y.Squared()).Root();
			return new PolarPoint(angleDegrees, radius);
		}

		public PolarPoint AddVector(PolarPoint polarPoint)
		{
			var currentCartesian = this.ToCartesian();
			var addCartesian = polarPoint.ToCartesian();
			var cartesianResult = currentCartesian.Add(addCartesian);
			var polar = cartesianResult.ToPolar();
			return polar;
		}
	}
}
