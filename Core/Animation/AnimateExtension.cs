using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Core.Parsers;

namespace Core.Animation
{
	public class AnimateExtension : MarkupExtension
	{
		public string Expression { get; set; }
		
		public AnimateExtension() { }
		public AnimateExtension(string animationExpression)
		{
			Expression = animationExpression;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var aep = new AnimationExpressionParser(Expression);
			var timeline = aep.Parse();
			return timeline;
		}
	}
}