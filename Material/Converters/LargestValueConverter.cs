using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Core.Extensions;
using Core.Markup;

namespace Material.Converters
{
	public class LargestValueConverter : XAMLConverter<double, double, NULLPARAM, double>
	{
		public override double Convert(double val1, double val2, NULLPARAM param)
		{
			return val1.Largest(val2);
		}
	}


	public class CircleRadiusFitConverter : XAMLConverter<double, double, NULLPARAM, double>
	{
		public override double Convert(double a, double b, NULLPARAM param)
		{
			var hypotenuse = (a.Squared() + b.Squared()).Root();
			return hypotenuse;
		}
	}
}
