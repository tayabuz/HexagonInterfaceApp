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
using Windows.UI.Core;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HexagonInterface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondMethodCreateRectangle : Page
    {
        public SecondMethodCreateRectangle()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        public Point firstPoint;
        public Point secondPoint;
        public Hexagon hexagon;
        public Point checkPoint;

        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame.CanGoBack)
            {
                frame.Navigate(typeof(MainPage));
                e.Handled = true; // указываем, что событие обработано
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Frame frame = Window.Current.Content as Frame;
            if (frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
        private void createWithSecondMethod_Click(object sender, RoutedEventArgs e)
        {
            if (EnterRectangleValue(SetUpFirstXValue.Text) && EnterRectangleValue(SetUpFirstYValue.Text) &&
                EnterRectangleValue(SetRectangleWidth.Text) && EnterRectangleValue(SetRectangleHeight.Text))
            {
                int firstPointX = Point.returnUserCoordinatesOrLength(SetUpFirstXValue.Text);
                int firstPointY = Point.returnUserCoordinatesOrLength(SetUpFirstYValue.Text);
                int height = Point.returnUserCoordinatesOrLength(SetRectangleHeight.Text);
                int width = Point.returnUserCoordinatesOrLength(SetRectangleWidth.Text);
                int checkPointX = Point.returnUserCoordinatesOrLength(SetCheckPointX.Text);
                int checkPointY = Point.returnUserCoordinatesOrLength(SetCheckPointY.Text);
                firstPoint = new Point(firstPointX, firstPointY);
                hexagon = new Hexagon(firstPoint, height, width);
                checkPoint = new Point(checkPointX, checkPointY);
                Payload payload = new Payload();
                payload.hex = hexagon;
                payload.point = checkPoint;
                this.Frame.Navigate(typeof(DrawHexagon), payload);
            }
            else
            {
                SetUpFirstXValue.Text = "";
                SetUpFirstYValue.Text = "";
                SetRectangleHeight.Text = "";
                SetRectangleWidth.Text = "";
                SetCheckPointX.Text = "";
                SetCheckPointY.Text = "";
            }
        }

        private bool EnterRectangleValue(string TextBoxString)
        {
            var tempString = TextBoxString;
            if (Point.checkOutput(tempString) == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
