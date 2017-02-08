using System.Windows;
using Core.Markup;
using Material.Design;

namespace Material.Markup.Converters
{
	public class LengthDescriptorResolverConverter : XAMLConverter<LengthDescriptor, double, NULLPARAM, double>
	{
		public override double Convert(LengthDescriptor lengthDescriptor, double containerLength, NULLPARAM param)
		{
			if (lengthDescriptor == null)
				return 0;

			 return lengthDescriptor.ResolvePixelLengthWithinContainer(containerLength);
			//if (lengthDescriptor.LengthMode == LengthMode.Pixels)
			//	return lengthDescriptor.Value;

			//if (containerLength <= 0)
			//	return 0;

			//return containerLength * (lengthDescriptor.Value / 100d);
		}
	}
	//public class InvertedHalfLengthDescriptorResolverConverter : XAMLConverter<LengthDescriptor, double, NULLPARAM, double>
	//{
	//	public override double Convert(LengthDescriptor lengthDescriptor, double containerLength, NULLPARAM param)
	//	{
	//		var conv = new LengthDescriptorResolverConverter();
	//		var inner = conv.Convert(lengthDescriptor, containerLength, null);
	//		return (containerLength - inner) / 2 + 120;
	//	}
	//}
	public class LengthDescriptorToFlairMarginConverter : XAMLConverter<LengthDescriptor, double, NULLPARAM, Thickness>
	{
		public override Thickness Convert(LengthDescriptor lengthDescriptor, double containerLength, NULLPARAM param)
		{
			var conv = GetInstance<LengthDescriptorResolverConverter>();
			var inner = conv.Convert(lengthDescriptor, containerLength, null);
			
			var outer = (containerLength - inner) / 2;
			return new Thickness(outer + inner, 0, 0, 0);
		}
	}
}
