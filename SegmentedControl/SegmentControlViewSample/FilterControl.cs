using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SegmentControlViewSample
{
	public class FilterControl : View
	{
		public event EventHandler SelectedIndexChanged;

		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create<FilterControl, List<string>>
		(p => p.Items, new List<string>());

		public List<string> Items {
			get {
				return GetValue (ItemsProperty) as List<string>;
			}
			set { 
				SetValue (ItemsProperty, value);
			}
		}

		public static readonly BindableProperty SelectedIndexProperty =
			BindableProperty.Create<FilterControl, int>
		(p => p.SelectedIndex, 0,BindingMode.TwoWay);

		public int SelectedIndex {
			get {
				return (int)GetValue (SelectedIndexProperty);
			}
			set { 
				SetValue (SelectedIndexProperty, value);
			}
		}

		public void OnSelectedIndexChanged(int newValue)
		{
			var args = new IndexChangedEventArgs () {
				NewValue = newValue,
				OldValue = SelectedIndex
			};

			SelectedIndex = newValue;

			if (SelectedIndexChanged != null) 
			{				
				SelectedIndexChanged (this, args);
			}
		}

		public static readonly BindableProperty TintColorProperty =
			BindableProperty.Create<FilterControl, Color>
		(p => p.TintColor, Color.Default,BindingMode.TwoWay);

		public Color TintColor {
			get {
				return (Color)GetValue (TintColorProperty);
			}
			set { 
				SetValue (TintColorProperty, value);
			}
		}
	
	}
}

