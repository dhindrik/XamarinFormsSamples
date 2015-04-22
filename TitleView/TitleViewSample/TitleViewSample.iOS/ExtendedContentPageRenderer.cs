using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using TitleViewSample.iOS;
using TitleViewSample;

[assembly: ExportRenderer(typeof(ExtendedContentPage), typeof(ExtendedContentPageRenderer))]
namespace TitleViewSample.iOS
{
    public class ExtendedContentPageRenderer : PageRenderer
    {
        public ExtendedContentPageRenderer()
        {
           
        }


       public override void WillMoveToParentViewController(UIViewController parent)
       {
           base.WillMoveToParentViewController(parent);

           var page = (ExtendedContentPage)Element;

           var renderer = RendererFactory.GetRenderer(page.TitleView);
           var view = renderer.NativeView;
           view.SizeToFit();

           parent.NavigationItem.TitleView = view.Subviews[0];
       }
        
    }
}