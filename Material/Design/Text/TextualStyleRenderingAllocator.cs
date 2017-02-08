using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Material.Design.Text
{
	public class TextualStyleRenderingAllocator
	{
		protected readonly IEnumerable<string> _labelTextSeries;
		protected readonly TextualStyle _textualStyle;
		protected readonly double _relativeToFontSize;

		private Size? predictedAllocation;

		public Size PredictedAllocation
		{
			get
			{
				if (predictedAllocation.HasValue)
					return predictedAllocation.Value;

				if (!_labelTextSeries.Any())
					return new Size(0, 0);

				var sizes = _labelTextSeries.Select(i =>
					_textualStyle.PredictRenderSizeAllocation(i, _relativeToFontSize)).ToArray();

				var maxWidth = sizes.Max(t => t.Width);
				var maxHeight = sizes.Max(t => t.Height);
				
				predictedAllocation = new Size(maxWidth, maxHeight);
				return predictedAllocation.Value;
			}
		}

		public TextualStyleRenderingAllocator(double relativeToFontSize, IEnumerable<string> labelTextSeries, TextualStyle textualStyle)
		{
			_relativeToFontSize = relativeToFontSize;
			_labelTextSeries = labelTextSeries;
			_textualStyle = textualStyle;
		}
	}
}
