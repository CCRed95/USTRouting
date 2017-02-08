using System;
using System.Windows;
using System.Windows.Media;
using Core.Markup;
using Material.Design.Providers;

namespace Material.Markup.Converters
{
	public class MaterialProviderToGradientBrushConverter : XAMLConverter<IMaterialProvider, NULLPARAM, GradientBrush>
	{
		public override GradientBrush Convert(IMaterialProvider materialProvider, NULLPARAM param)
		{
			if (materialProvider == null)
				return null;

			var linearGradientBrush = new LinearGradientBrush()
			{
				StartPoint = new Point(0, 0),
				EndPoint = new Point(1, 1)
			};

			var gradientMaterialProvider = materialProvider as GradientMaterialProvider;
			var sequentialMaterialProvider = materialProvider as SequentialMaterialProvider;
			var alternatingMaterialProvider = materialProvider as AlternatingMaterialProvider;
			var literalMaterialProvider = materialProvider as LiteralMaterialProvider;

			if (gradientMaterialProvider != null)
			{
				var stepLength = 1d / (gradientMaterialProvider.GradientStepData.Count - 1);
				var stepPosition = 0d;
				foreach (var gradientStep in gradientMaterialProvider.GradientStepData)
				{
					linearGradientBrush.GradientStops.Add(new GradientStop
					{
						Color = gradientStep.MaterialSet.P500.Color,
						Offset = stepPosition
					});
					stepPosition += stepLength;
				}
				//var lastGradientStop = linearGradientBrush.GradientStops.Last();
				//lastGradientStop.Offset = 0;
				return linearGradientBrush;
			}
			if (sequentialMaterialProvider != null)
			{
				var stepLength = 1d / (sequentialMaterialProvider.MaterialSetSequence.Count - 1);
				var stepPosition = 0d;
				foreach (var materialSet in sequentialMaterialProvider.MaterialSetSequence)
				{
					linearGradientBrush.GradientStops.Add(new GradientStop
					{
						Color = materialSet.P500.Color,
						Offset = stepPosition
					});
					stepPosition += stepLength;
				}
				return linearGradientBrush;
			}
			if (alternatingMaterialProvider != null)
			{
				linearGradientBrush.GradientStops.Add(new GradientStop
				{
					Color = alternatingMaterialProvider.MaterialSet1.P500.Color,
					Offset = 0
				});
				linearGradientBrush.GradientStops.Add(new GradientStop
				{
					Color = alternatingMaterialProvider.MaterialSet2.P500.Color,
					Offset = 1
				});
				return linearGradientBrush;
			}
			if (literalMaterialProvider != null)
			{
				linearGradientBrush.GradientStops.Add(new GradientStop
				{
					Color = literalMaterialProvider.MaterialSet.P500.Color,
					Offset = 0
				});
				linearGradientBrush.GradientStops.Add(new GradientStop
				{
					Color = literalMaterialProvider.MaterialSet.P500.Color,
					Offset = 1
				});
				return linearGradientBrush;
			}
			throw new NotSupportedException();
		}
	}
}
