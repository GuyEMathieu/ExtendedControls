using ExtendedControls.Controls;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ExtendedControls
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MySwitch_OnToggle(object sender, EventArgs e)
        {
            var control = (MySwitch)sender;
        }
    }
}
