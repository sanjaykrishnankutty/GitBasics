using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ActiveHoverAreaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Is the mouse inside the active area
        private bool isInsideActiveArea = false;
        // When has the mouse entered the active area
        private DateTime startOfActiveAreaHover;
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var currentPosition = e.GetCurrentPoint(null).Position;
            // If inside the area for the first time
            if(currentPosition.Y < 100 && !isInsideActiveArea)
            {
                startOfActiveAreaHover = DateTime.Now;
                isInsideActiveArea = true;
            }
            // If leaving the area after being in
            if(currentPosition.Y > 100 && isInsideActiveArea)
            {
                isInsideActiveArea = false;
                this.button.Visibility = Visibility.Collapsed;
            }
            // If still inside the area for at least 500 ms
            if(isInsideActiveArea && DateTime.Now > startOfActiveAreaHover.AddMilliseconds(500))
            {
                this.button.Visibility = Visibility.Visible;
            }
        }
    }
}
