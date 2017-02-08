using System.Windows;
using System.Windows.Media;
using Material.Design.Descriptors;
using Material.Design.Providers;

namespace Material.Design
{
	//TODO change this to a flexenum and use x:static or a converter
	public enum DocumentThemeBindingItem
	{
		IsPrinterFriendly,
		ViewportBackground,
		Background,
		Paper,
		Body,
		BodyLight,
		BodyBlue,
		BodyBlueLight,
		BodyGreen,
		BodyGreenLight,
		BodyRed,
		BodyRedLight,
		TooltipBackground,
		CardBackground,
		CardBorderBrush,
		MaterialProviderMain,
		SegmentSpaceBackground,
		SecondaryValueForeground,
		BarTotalForeground,
		XAxisForeground,
		YAxisForeground,
		LineStroke,
		DotFill,
		DotStroke,
		LuminosityInversion
	}
	public class DocumentTheme : Freezable
	{
		public bool IsPrinterFriendly { get; set; }
		public SolidColorBrush ViewportBackground { get; set; }
		public SolidColorBrush Background { get; set; }
		public SolidColorBrush Paper { get; set; }
		public SolidColorBrush Body { get; set; }
		public SolidColorBrush BodyLight { get; set; }
		public SolidColorBrush BodyBlue { get; set; }
		public SolidColorBrush BodyBlueLight { get; set; }
		public SolidColorBrush BodyGreen { get; set; }
		public SolidColorBrush BodyGreenLight { get; set; }
		public SolidColorBrush BodyRed { get; set; }
		public SolidColorBrush BodyRedLight { get; set; }
		public SolidColorBrush TooltipBackground { get; set; }
		public SolidColorBrush CardBackground { get; set; }
		public SolidColorBrush CardBorderBrush { get; set; }
		public IMaterialProvider MaterialProviderMain { get; set; }
		public AbstractMaterialDescriptor SegmentSpaceBackground { get; set; }
		public AbstractMaterialDescriptor SecondaryValueForeground { get; set; }
		public AbstractMaterialDescriptor BarTotalForeground { get; set; }
		public AbstractMaterialDescriptor XAxisForeground { get; set; }
		public AbstractMaterialDescriptor YAxisForeground { get; set; }
		public AbstractMaterialDescriptor LineStroke { get; set; }
		public AbstractMaterialDescriptor DotFill { get; set; }
		public AbstractMaterialDescriptor DotStroke { get; set; }
		public bool LuminosityInversion { get; set; }
		

		protected override Freezable CreateInstanceCore()
		{
			return new DocumentTheme();
		}

		public DocumentTheme()
		{

		}
	}
}