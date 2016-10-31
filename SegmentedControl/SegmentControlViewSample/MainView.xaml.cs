using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.ComponentModel;

namespace SegmentControlViewSample
{
	public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();

			BindingContext = new ViewModel () { Filter = 1 };

			var items = new List<string> (){ "All", "New", "Old" };

			Filter.ItemsSource = items;
		}

		public class ViewModel : INotifyPropertyChanged
		{
			#region INotifyPropertyChanged implementation

			public event PropertyChangedEventHandler PropertyChanged;

			#endregion

			private int _filter;
			public int Filter
			{ 
				get
				{ 
					return _filter; 
				} 
				set
				{
					_filter = value; 
					NotifyPropertyChanged ("Filter"); 
				}
			}

			private void NotifyPropertyChanged(string propertyName)
			{
				if (PropertyChanged != null) 
				{
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}
	}
}

