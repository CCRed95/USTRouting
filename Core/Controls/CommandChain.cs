using System;
using System.Windows;
using System.Windows.Input;

namespace Core.Controls
{
	public class CommandChain : DependencyObject, ICommand
	{

		public ICommand Command1 { get; set; }
		public ICommand Command2 { get; set; }

		public bool CanExecute(object parameter)
		{
			return 
				(Command1 == null || Command1.CanExecute(parameter)) && 
				(Command2 == null || Command2.CanExecute(parameter));
		}

		public void Execute(object parameter)
		{
			Command1?.Execute(parameter);
			Command2?.Execute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		public void Refresh()
		{
			CommandManager.InvalidateRequerySuggested();
		}

	}

}
		//public static readonly DependencyProperty Command1Property = DP.Register(
		//	new Meta<CommandChain, ICommand>(null, Command1Changed));

		//public static readonly DependencyProperty Command2Property = DP.Register(
		//	new Meta<CommandChain, ICommand>(null, Command2Changed));
		
		//public ICommand Command1
		//{
		//	get { return (ICommand) GetValue(Command1Property); }
		//	set { SetValue(Command1Property, value); }
		//}
		//public ICommand Command2
		//{
		//	get { return (ICommand) GetValue(Command2Property); }
		//	set { SetValue(Command2Property, value); }
		//}

		

		//private static void Command1Changed(CommandChain i, DPChangedEventArgs<ICommand> e)
		//{
		//}

		//private static void Command2Changed(CommandChain i, DPChangedEventArgs<ICommand> e)
		//{
		//}