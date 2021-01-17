using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Svg;

namespace UIClone.Controls
{
    public partial class CustomEntry : ContentView
    {
        public string PlaceHolder
        {
            get
            {
                return (string)GetValue(PlaceHolderProperty);
            }

            set
            {
                SetValue(PlaceHolderProperty, value);
            }
        }
        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create("PlaceHolder", typeof(string), typeof(CustomEntry), defaultValue: "", BindingMode.TwoWay, propertyChanged: PlaceHolderPropertyChanged);
        private static void PlaceHolderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomEntry)bindable).SetPlaceHolder((string)newValue);
        }

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }

            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }
        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create("IsPassword", typeof(bool), typeof(CustomEntry), defaultValue: false, BindingMode.TwoWay, propertyChanged: IsPasswordPropertyChanged);
        private static void IsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomEntry)bindable).SetIsPassword((bool)newValue);
        }

        public ImageSource Source
        {
            get
            {
                return (ImageSource)GetValue(SourceProperty);
            }

            set
            {
                SetValue(SourceProperty, value);
            }
        }
        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create("IsPassword", typeof(ImageSource), typeof(CustomEntry), defaultValue: null, BindingMode.TwoWay, propertyChanged: SourcePropertyChanged);
        private static void SourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomEntry)bindable).SetSource((ImageSource)newValue);
        }

        public CustomEntry()
        {
            InitializeComponent();

            ent.Focused += FancyEntry_Focused;
            ent.Unfocused += FancyEntry_Unfocused;
        }

        public void SetPlaceHolder(string s)
        {
            this.lblEntry.Text = s;
        }

        public void SetIsPassword(bool b)
        {
            this.ent.IsPassword = b;
        }

        public void SetSource(ImageSource s)
        {
            this.imgIcon.Source = s;
        }

        private void FancyEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(ent.Text))
            {
                lblEntry.ScaleXTo(1);
                lblEntry.ScaleYTo(1);
                lblEntry.TranslateTo(0, 0);
                lblEntry.BackgroundColor = Color.Transparent;
            }
        }

        private void FancyEntry_Focused(object sender, FocusEventArgs e)
        {
            lblEntry.ScaleYTo(0.8);
            lblEntry.ScaleXTo(0.8);
            if (DeviceInfo.Idiom == DeviceIdiom.Phone)
            {
                lblEntry.TranslateTo(0, -(lblEntry.Height));
            }
            else
            {
                lblEntry.TranslateTo(0, -(lblEntry.Height + 18));
            }
            lblEntry.BackgroundColor = Color.FromHex("#248faa");
        }
    }
}
