using System;
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
using Windows.UI;
using Windows.UI.Xaml.Media.Animation;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HexagonInterface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DrawHexagon : Page
    {
        public DrawHexagon()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true; 
            }
        }
        private Hexagon hex;
        private Point point;
        private Payload payload;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Frame frame = Window.Current.Content as Frame;
            if (frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
            
            if (e.Parameter.ToString() != "")
            {
                payload = (Payload) e.Parameter;
            }

        }

        void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasPathBuilder p = new CanvasPathBuilder(device.Device);
            args.DrawingSession.Clear(Colors.LawnGreen);
            hex = payload.hex;
            point = payload.point;
            p.BeginFigure(hex.P1.X, hex.P1.Y);
            p.AddLine(hex.P2.X, hex.P2.Y);
            p.AddLine(hex.P3.X, hex.P3.Y);
            p.AddLine(hex.P4.X, hex.P4.Y);
            p.AddLine(hex.P5.X, hex.P5.Y);
            p.AddLine(hex.P6.X, hex.P6.Y);
            p.AddLine(hex.P1.X, hex.P1.Y);
            p.EndFigure(CanvasFigureLoop.Closed);
            CanvasGeometry geometry = CanvasGeometry.CreatePath(p);
            args.DrawingSession.FillGeometry(geometry, Colors.Red);
            string point1 = hex.P1.X + ";" + hex.P1.Y;
            string point2 = hex.P2.X + ";" + hex.P2.Y;
            string point3 = hex.P3.X + ";" + hex.P3.Y;
            string point4 = hex.P4.X + ";" + hex.P4.Y;
            string point5 = hex.P5.X + ";" + hex.P5.Y;
            string point6 = hex.P6.X + ";" + hex.P6.Y;
            args.DrawingSession.DrawText(point1, hex.P1.X, hex.P1.Y, Colors.Black);
            args.DrawingSession.DrawText(point2, hex.P2.X, hex.P2.Y, Colors.Black);
            args.DrawingSession.DrawText(point3, hex.P3.X, hex.P3.Y, Colors.Black);
            args.DrawingSession.DrawText(point4, hex.P4.X, hex.P4.Y, Colors.Black);
            args.DrawingSession.DrawText(point5, hex.P5.X, hex.P5.Y, Colors.Black);
            args.DrawingSession.DrawText(point6, hex.P6.X, hex.P6.Y, Colors.Black);
            string check = hex.IsPointInside(point).ToString();
            args.DrawingSession.DrawText(check, point.X, point.Y, Colors.Black);
            args.DrawingSession.Flush();
            

        }
    }
}
