using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using Core.Extensions;
using Material.Extensions;
using Material.Static;

namespace Material.Design.Providers
{
	[ContentProperty(nameof(GradientStepData))]
	public class DataAwareGradientMaterialProvider : IDataAwareMaterialProvider
	{
		public List<GradientMaterialStop> GradientStepData { get; }


		public DataAwareGradientMaterialProvider()
		{
			GradientStepData = new List<GradientMaterialStop>();
		}

		public DataAwareGradientMaterialProvider(List<GradientMaterialStop> gradientStepData)
		{
			GradientStepData = gradientStepData;
		}


		public void Reset()
		{

		}

		public void Reset(ProviderContext context)
		{

		}


		public MaterialSet ProvideNext(ProviderContext context)
		{
			throw new NotSupportedException(
				"ProvideNext cannot be used on a IDataAwareMaterialProvider. Use ProvideNextDataAware.");
		}

		public IMaterialProvider Slice(double offsetPercentage, double lengthPercentage)
		{
			throw new NotSupportedException(
				"Slice cannot be used on a IDataAwareMaterialProvider.");
		}

		public IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode)
		{
			throw new NotSupportedException(
				"SliceSimple cannot be used on a IDataAwareMaterialProvider.");
		}

		public MaterialSet ProvideNextDataAware(DataAwareProviderContext context, double dataPoint)
		{
			var progression = dataPoint.Map(context.DataMin, context.DataMax, 0d, 1d);
			var materialSet = GetMaterialSetAtProgression(progression);
			return materialSet;
		}

		private MaterialSet GetMaterialSetAtProgression(double progression)
		{
			var totalGradientSpan = GradientStepData.Sum(t => t.Offset);

			if (progression <= 0)
			{
				return GradientStepData.First().MaterialSet;
			}
			if (progression >= 1)
			{
				return GradientStepData.Last().MaterialSet;
			}

			var currentOffset = 0d;
			for (var x = 0; x <= GradientStepData.Count - 2; x++)
			{
				var startGradientStep = GradientStepData[x];
				var endGradientStep = GradientStepData[x + 1];

				var stepSpanPercentage = startGradientStep.Offset / totalGradientSpan;
				var stepEndOffset = currentOffset + stepSpanPercentage;

				if (progression >= currentOffset && progression < stepEndOffset)
				{
					var progressionThroughStep = progression.Map(currentOffset, stepEndOffset, 0d, 1d);
					var materialSet = MediaExtensions.Interpolate(startGradientStep.MaterialSet,
						endGradientStep.MaterialSet, progressionThroughStep);
					return materialSet;
				}
				currentOffset = stepEndOffset;
			}
			throw new ArgumentOutOfRangeException();
		}



		public static DataAwareGradientMaterialProvider PY = new DataAwareGradientMaterialProvider
		(new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Pink),
				new GradientMaterialStop(Palette.Yellow, 0)
			});


		public static DataAwareGradientMaterialProvider MaterialRYG => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Red),
				new GradientMaterialStop(Palette.Yellow),
				new GradientMaterialStop(Palette.Green, 0)
			});

		public static DataAwareGradientMaterialProvider MaterialPR => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Pink),
				new GradientMaterialStop(Palette.Red, 0)
			});
		public static DataAwareGradientMaterialProvider MaterialTA => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Teal),
				new GradientMaterialStop(Palette.Amber, 0)
			});
		public static DataAwareGradientMaterialProvider MaterialTC => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Teal),
				new GradientMaterialStop(Palette.Amber, 0)
			});
		public static DataAwareGradientMaterialProvider MaterialHLbB => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Pink),
				new GradientMaterialStop(Palette.Purple ),
				new GradientMaterialStop(Palette.DeepPurple),
				new GradientMaterialStop(Palette.Blue),
				new GradientMaterialStop(Palette.LightBlue),
				new GradientMaterialStop(Palette.Teal, 0),
			});
		public static DataAwareGradientMaterialProvider MateriaLbLg => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.LightBlue),
				new GradientMaterialStop(Palette.LightGreen, 0),
			});
		public static DataAwareGradientMaterialProvider RainbowPaletteOrder => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Red),
				new GradientMaterialStop(Palette.Pink ),
				new GradientMaterialStop(Palette.Purple),
				new GradientMaterialStop(Palette.DeepPurple),
				new GradientMaterialStop(Palette.Indigo),
				new GradientMaterialStop(Palette.Blue),
				new GradientMaterialStop(Palette.LightBlue),
				new GradientMaterialStop(Palette.Cyan),
				new GradientMaterialStop(Palette.Teal),
				new GradientMaterialStop(Palette.Green),
				new GradientMaterialStop(Palette.LightGreen),
				new GradientMaterialStop(Palette.Lime),
				new GradientMaterialStop(Palette.Yellow),
				new GradientMaterialStop(Palette.Amber),
				new GradientMaterialStop(Palette.Orange),
				new GradientMaterialStop(Palette.DeepOrange, 0)
			});
		public static DataAwareGradientMaterialProvider RainbowRefractionOrder => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Red),
				new GradientMaterialStop(Palette.DeepOrange),
				new GradientMaterialStop(Palette.Orange),
				new GradientMaterialStop(Palette.Amber),
				new GradientMaterialStop(Palette.Lime),
				new GradientMaterialStop(Palette.Yellow),
				new GradientMaterialStop(Palette.LightGreen),
				new GradientMaterialStop(Palette.Green),
				new GradientMaterialStop(Palette.Teal),
				new GradientMaterialStop(Palette.Cyan),
				new GradientMaterialStop(Palette.LightBlue),
				new GradientMaterialStop(Palette.Blue),
				new GradientMaterialStop(Palette.Indigo),
				new GradientMaterialStop(Palette.DeepPurple),
				new GradientMaterialStop(Palette.Purple),
				new GradientMaterialStop(Palette.Pink, 0)
			});

		public static DataAwareGradientMaterialProvider CoolColors => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Purple),
				new GradientMaterialStop(Palette.DeepPurple),
				new GradientMaterialStop(Palette.Indigo),
				new GradientMaterialStop(Palette.Blue),
				new GradientMaterialStop(Palette.LightBlue),
				new GradientMaterialStop(Palette.Cyan),
				new GradientMaterialStop(Palette.Teal),
				new GradientMaterialStop(Palette.Green),
				new GradientMaterialStop(Palette.Purple, 0)
			});
		public static DataAwareGradientMaterialProvider CoolColorsNonCirc => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Purple),
				new GradientMaterialStop(Palette.DeepPurple),
				new GradientMaterialStop(Palette.Indigo),
				new GradientMaterialStop(Palette.Blue),
				new GradientMaterialStop(Palette.LightBlue),
				new GradientMaterialStop(Palette.Cyan),
				new GradientMaterialStop(Palette.Teal),
				new GradientMaterialStop(Palette.Green, 0)
			});

		public static DataAwareGradientMaterialProvider WarmColors => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Pink),
				new GradientMaterialStop(Palette.Red),
				new GradientMaterialStop(Palette.DeepOrange),
				new GradientMaterialStop(Palette.Orange),
				new GradientMaterialStop(Palette.Yellow),
				new GradientMaterialStop(Palette.Pink, 0),
			});
		public static DataAwareGradientMaterialProvider WarmColorsNonCirc => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(Palette.Pink),
				new GradientMaterialStop(Palette.Red),
				new GradientMaterialStop(Palette.DeepOrange),
				new GradientMaterialStop(Palette.Orange),
				new GradientMaterialStop(Palette.Yellow, 0),
			});
	}
}
