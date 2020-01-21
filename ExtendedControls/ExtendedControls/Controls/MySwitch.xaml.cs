using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExtendedControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySwitch : ContentView
    {
        public MySwitch()
        {
            HeightRequest = 30.0;

            InitializeComponent();

            BindingContext = this;

            var tapGestureRecognizer = new TapGestureRecognizer();

            tapGestureRecognizer.Tapped += (s, e) =>
            {
                IsSelected = !IsSelected;
                OnToggle?.Invoke(this, e);
            };

            _image.GestureRecognizers.Add(tapGestureRecognizer);
        }

        public event EventHandler OnToggle;

        #region Label Fields Methods and Properties
        private static BindableProperty LabelProperty = BindableProperty.Create(
            nameof(Label), typeof(string), typeof(MySwitch), string.Empty,
            BindingMode.OneWay, propertyChanged: labelPropertyChanged);

        private static void labelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MySwitch)bindable;
            control._label.Text = (string)newValue;
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
        #endregion


        #region IsSelected Region

        private static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected), typeof(bool), typeof(MySwitch), false,
            BindingMode.TwoWay, propertyChanged: IsSelectedPropertyChanged);

        private static void IsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MySwitch)bindable;
            
            if (control != null)
            {
                control.IsSelected = (bool)newValue;
                control._image.Source = control.IsSelected ? control.OnImage : (ImageSource)control.OffImage;
            }
        }

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        #endregion


        #region Image Section

        public string OnImage
        {
            get => (string)GetValue(OnImageProperty);
            set => SetValue(OnImageProperty, value);
        }

        public string OffImage
        {
            get => (string)GetValue(OffImageProperty);
            set => SetValue(OffImageProperty, value);
        }

        private static readonly BindableProperty OnImageProperty = BindableProperty.Create(
            nameof(OnImage), typeof(string), typeof(MySwitch), string.Empty,
            BindingMode.OneWay, propertyChanged: ImagePropertyChanged);

        private static readonly BindableProperty OffImageProperty = BindableProperty.Create(
            nameof(OffImage), typeof(string), typeof(MySwitch), string.Empty,
            BindingMode.OneWay, propertyChanged: ImagePropertyChanged);

        private static void ImagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MySwitch)bindable;

            if(control != null)
            {
                control._image.Source = control.IsSelected ? control.OnImage : (ImageSource)control.OffImage;
            }
        }
        #endregion



    }
}