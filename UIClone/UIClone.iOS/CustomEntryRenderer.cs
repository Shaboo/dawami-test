using UIClone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(myEntry), typeof(UIClone.iOS.CustomEntryRenderer))]
namespace UIClone.iOS
{
    class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            this.Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}
