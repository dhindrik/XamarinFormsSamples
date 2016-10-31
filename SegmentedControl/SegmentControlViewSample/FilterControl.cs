using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SegmentControlViewSample
{
	public class FilterControl : View
	{
    public event EventHandler SelectedIndexChanged;

    public static BindableProperty ItemsSourceProperty = BindableProperty.Create<FilterControl, IEnumerable<string>> (x => x.ItemsSource, default (IEnumerable<string>), BindingMode.OneWay, null, OnItemsSourceChanged);

    public List<string> Items
    {
      get
      {
        return ItemsAsObject;
      }
    }

    public List<string> ItemsAsObject = new List<string> ();

    public IEnumerable<string> ItemsSource
    {
      get { return (IEnumerable<string>)GetValue (ItemsSourceProperty); }
      set { SetValue (ItemsSourceProperty, value); }
    }

    private static void OnItemsSourceChanged (BindableObject bindableobject, IEnumerable<string> oldvalue, IEnumerable<string> newvalue)
    {
      var filtercontrol = bindableobject as FilterControl;
      if (filtercontrol == null) return;
      filtercontrol.Items.Clear ();
      filtercontrol.ItemsAsObject.Clear ();      //This is the bound List with the Objects
      if (newvalue != null)
      {
        foreach (var item in newvalue)
        {
          filtercontrol.ItemsAsObject.Add (item);
          filtercontrol.Items.Add (item.ToString ());
        }
      }
    }

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create<FilterControl, int> (p => p.SelectedIndex, 0, BindingMode.TwoWay);

    public int SelectedIndex
    {
      get
      {
        return (int)GetValue (SelectedIndexProperty);
      }
      set
      {
        SetValue (SelectedIndexProperty, value);
      }
    }

    public void OnSelectedIndexChanged (int newValue)
    {
      var args = new IndexChangedEventArgs ()
      {
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
    (p => p.TintColor, Color.Default, BindingMode.TwoWay);

    public Color TintColor
    {
      get
      {
        return (Color)GetValue (TintColorProperty);
      }
      set
      {
        SetValue (TintColorProperty, value);
      }
    }
  }
}