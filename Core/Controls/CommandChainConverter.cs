using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Markup;

namespace Core.Controls
{
	public class CommandChainConverter : XAMLConverter<ICommand, ICommand, NULLPARAM, CommandChain>
	{
		public override CommandChain Convert(ICommand arg1, ICommand arg2, NULLPARAM param)
		{
			return new CommandChain {Command1 = arg1, Command2 = arg2};
		}
	}
}
