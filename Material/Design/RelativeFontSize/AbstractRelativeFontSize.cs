using System.ComponentModel;
using System.Windows;
using Material.Markup.TypeConverters;

namespace Material.Design.RelativeFontSize
{
	[TypeConverter(typeof(RelativeFontSizeConverter))]
	public abstract class AbstractRelativeFontSize : DependencyObject
	{
		public abstract double GetActualFontSize(double referenceFontSize);
	}
}
