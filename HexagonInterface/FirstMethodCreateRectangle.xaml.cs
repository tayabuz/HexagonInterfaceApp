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
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HexagonInterface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstMethodCreateRectangle : Page
    {
        public static int userAnswer;
        public Point firstPoint;
        public Point secondPoint;
        public Hexagon hexagon;
        public Point checkPoint;
        public FirstMethodCreateRectangle()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
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
        private void createWithFirstMethod_Click(object sender, RoutedEventArgs e)
        {
            if (EnterRectangleValue(SetUpFirstXValue.Text) && EnterRectangleValue(SetUpFirstYValue.Text) &&
                EnterRectangleValue(SetUpSecondXValue.Text) && EnterRectangleValue(SetUpSecondYValue.Text))
            {
                int firstPointX = Point.returnUserCoordinatesOrLength(SetUpFirstXValue.Text);
                int firstPointY = Point.returnUserCoordinatesOrLength(SetUpFirstYValue.Text);
                int secondPointX = Point.returnUserCoordinatesOrLength(SetUpSecondXValue.Text);
                int secondPointY = Point.returnUserCoordinatesOrLength(SetUpSecondYValue.Text);
                int checkPointX = Point.returnUserCoordinatesOrLength(SetCheckPointX.Text);
                int checkPointY = Point.returnUserCoordinatesOrLength(SetCheckPointY.Text);
                firstPoint = new Point(firstPointX, firstPointY);
                secondPoint = new Point(secondPointX, secondPointY);
                hexagon = new Hexagon(firstPoint, secondPoint);
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
                SetUpSecondXValue.Text = "";
                SetUpSecondYValue.Text = "";
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

