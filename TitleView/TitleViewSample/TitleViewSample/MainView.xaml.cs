using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TitleViewSample
{
    public partial class MainView : ExtendedContentPage
    {
        public MainView()
        {
            InitializeComponent();

            TestButton.Clicked += TestButton_Clicked;
        }

        void TestButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hi!","Button clicked","OK");
        }
    }
}
