using System;
using JetBrains.Annotations;

namespace Core.Controls
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class AutoTemplatePartAttribute : Attribute
	{
	}
}
