using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExtendedControls.Controls
{
    public class MyButton : Button
    {

        public MyButton()
        {
            BackgroundColor = Color.Blue;
            CornerRadius = 25;
            TextColor = Color.White;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }
    }
}
