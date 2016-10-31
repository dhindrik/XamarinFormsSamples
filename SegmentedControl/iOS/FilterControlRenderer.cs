using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using SegmentControlViewSample;
using SegmentControlViewSample.iOS;

[assembly: ExportRenderer(typeof(FilterControl), typeof(FilterControlRenderer))]
namespace SegmentControlViewSample.iOS
{
	public class FilterControlRenderer : ViewRenderer<FilterControl, UISegmentedControl>
	{
		public FilterControlRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<FilterControl> e)
		{
			base.OnElementChanged (e);

			var segmentControl = new UISegmentedControl ();


			SetNativeControl (segmentControl);

			UpdateSegments ();

			segmentControl.SelectedSegment = Element.SelectedIndex;
			segmentControl.SizeToFit ();

			segmentControl.ValueChanged += (object sender, EventArgs args) => 
			{
				if(segmentControl.SelectedSegment != Element.SelectedIndex)
				{
					Element.OnSelectedIndexChanged((int)segmentControl.SelectedSegment);
				}
			};
		}
		private void UpdateSegments()
		{
			Control.RemoveAllSegments ();

			for (int i = 0; i < Element.Items.Count; i++) 
			{
				Control.InsertSegment (Element.Items [i],i,true);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == FilterControl.SelectedIndexProperty.PropertyName) 
			{
				if (Control.SelectedSegment != Element.SelectedIndex) 
				{
					Control.SelectedSegment = Element.SelectedIndex;
				}
			}

			if (e.PropertyName == FilterControl.ItemsSourceProperty.PropertyName) 
			{
				UpdateSegments ();
			}

			if (e.PropertyName == "Renderer" || e.PropertyName == FilterControl.TintColorProperty.PropertyName) 
			{
				if (Element.TintColor != Color.Default) 
				{
					Control.TintColor = Element.TintColor.ToUIColor ();
				}
			}

		}
	}
}

