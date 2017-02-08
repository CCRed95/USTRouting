using System.Windows;

namespace Core.Extensions
{
	public class StyleExtensions
	{
		public static string FindNameFromResource(object resourceItem)
		{
			foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
			{
				foreach (var key in dictionary.Keys)
				{
					if (dictionary[key] == resourceItem)
					{
						return key.ToString();
					}
				}
			}
			return null;
		}
	}
}
