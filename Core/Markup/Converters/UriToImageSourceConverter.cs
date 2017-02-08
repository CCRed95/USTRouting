using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Core.Helpers.DependencyHelpers;

namespace Core.Markup.Converters
{
	public class UriToImageSourceAssist : DependencyObject
	{
		public static readonly DependencyProperty SourceUriProperty =
			DP.Attach<Uri>(typeof(UriToImageSourceAssist), new FrameworkPropertyMetadata(onSourceUriChanged));

		public static Uri GetSourceUri(DependencyObject i) => i.Get<Uri>(SourceUriProperty);
		public static void SetSourceUri(DependencyObject i, Uri v) => i.Set(SourceUriProperty, v);

		public Uri SourceUri
		{
			get { return (Uri)GetValue(SourceUriProperty); }
			set { SetValue(SourceUriProperty, value); }
		}

		private static void onSourceUriChanged(DependencyObject i, DependencyPropertyChangedEventArgs e)
		{
			var targetImage = i as Image;
			if (targetImage == null)
				throw new ArgumentException("\'UriToImageSourceAssist\' can only be used on an Image control.");

			var binding = new Binding("VerifiedUri")
			{
				Source = new UriToImageSourceAssist { GivenUri = (Uri)e.NewValue },
				IsAsync = true
			};
			targetImage.SetBinding(Image.SourceProperty, binding);

		}


		private Uri GivenUri;
		public Uri VerifiedUri
		{
			get
			{
				try
				{
					Dns.GetHostEntry(GivenUri.DnsSafeHost);
					return GivenUri;
				}
				catch (Exception)
				{
					return null;
				}

			}
		}
	}
	//public class UriToImageSourceConverter : DependencyObject
	//{
	//	public static readonly DependencyProperty SourceUriProperty = DependencyProperty.RegisterAttached("SourceUri",
	//		typeof(Uri), typeof(UriToImageSourceConverter), new PropertyMetadata
	//		{
	//			PropertyChangedCallback = (obj, e) => ((Image)obj).SetBinding(Image.SourceProperty,
	//				new Binding("VerifiedUri")
	//				{
	//					Source = new UriToImageSourceConverter { GivenUri = (Uri)e.NewValue },
	//					IsAsync = true,
	//				})
	//		});


	//	public static Uri GetSourceUri(DependencyObject obj)
	//	{
	//		return (Uri)obj.GetValue(SourceUriProperty);
	//	}
	//	public static void SetSourceUri(DependencyObject obj, Uri value)
	//	{
	//		obj.SetValue(SourceUriProperty, value);
	//	}


	//	Uri GivenUri;
	//	public Uri VerifiedUri
	//	{
	//		get
	//		{
	//			try
	//			{
	//				Dns.GetHostEntry(GivenUri.DnsSafeHost);
	//				return GivenUri;
	//			}
	//			catch (Exception)
	//			{
	//				return null;
	//			}

	//		}
	//	}
	//}
}