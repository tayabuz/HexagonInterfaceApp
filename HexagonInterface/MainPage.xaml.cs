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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HexagonInterface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private bool firstMethodIsChecked = true;
        private bool secondMethodIsChecked = false;
        private void firstMethod_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            firstMethodIsChecked = true;
            secondMethodIsChecked = false;
        }
        private void secondMethod_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            firstMethodIsChecked = false;
            secondMethodIsChecked = true;
        }
        private void startMethodButton_Click(object sender, RoutedEventArgs e)
        {
            if ((firstMethodIsChecked == true) && (secondMethodIsChecked == false))
            {
                Frame.Navigate(typeof(FirstMethodCreateRectangle));
            }
            if ((secondMethodIsChecked == true) && (firstMethodIsChecked == false))
            {
                Frame.Navigate(typeof(SecondMethodCreateRectangle));
            }
        }
    }
}
