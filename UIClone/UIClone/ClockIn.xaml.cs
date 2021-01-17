using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClockIn : ContentPage
    {
        public ClockIn()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            double end = mainDisplayInfo.Height > mainDisplayInfo.Width ? mainDisplayInfo.Height : mainDisplayInfo.Width;
            double endHeight = end / 3;

            if (DeviceInfo.Idiom == DeviceIdiom.Phone)
            {
                endHeight = end / 5;
            }

            if (MyDraggableView.Height == 0)
            {
                Action<double> callback = input => MyDraggableView.HeightRequest = input;
                double startHeight = 0;
                uint rate = 32;
                uint length = 500;
                Easing easing = Easing.CubicOut;
                MyDraggableView.Animate("anim", callback, startHeight, endHeight, rate, length, easing);
            }
            else
            {
                Action<double> callback = input => MyDraggableView.HeightRequest = input;
                double startHeight = endHeight;
                uint rate = 32;
                uint length = 500;
                Easing easing = Easing.SinOut;
                MyDraggableView.Animate("anim", callback, startHeight, 0, rate, length, easing);
            }
        }
    }
}