using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Material.Design.RelativeFontSize
{
	public enum Operation
	{
		Add,
		Subtract,
		Multiply,
		Divide
	}
	public class MathRelativeFontSize : AbstractRelativeFontSize
	{
		public static readonly DependencyProperty OperationProperty = DP.Register(
			new Meta<MathRelativeFontSize, Operation>(Operation.Multiply));

		public static readonly DependencyProperty ParameterProperty = DP.Register(
			new Meta<MathRelativeFontSize, double>(1d));


		public Operation Operation
		{
			get { return (Operation) GetValue(OperationProperty); }
			set { SetValue(OperationProperty, value); }
		}
		public double Parameter
		{
			get { return (double) GetValue(ParameterProperty); }
			set { SetValue(ParameterProperty, value); }
		}

		public override double GetActualFontSize(double referenceFontSize)
		{
			return referenceFontSize*Parameter;
		}
	}
}
