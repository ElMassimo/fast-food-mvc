using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace FoodExpress.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNick.Text) || txtNick.Text.Length < 3)
                return;
            if(String.IsNullOrEmpty(txtPassword.Password) || txtPassword.Password.Length < 6)
                return;
                       
            //DeliveryServices
            //var services = new DeliveryServices
            //client.GetCatastrophesCompleted += (s, ea) =>
            //{
            //    if (!ea.Cancelled)
            //        CatastropheComboBox.ItemsSource = ea.Result;
            //    else
            //        CatastropheComboBox.ItemsSource = new List<string>() { "Connection Unavailable" };

            //    CatastropheComboBox.SelectedIndex = 0;
            //};
            //client.GetCatastrophesAsync();

            //    (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Views/InfoPage.xaml", UriKind.Relative));
            //}
            //else
            //{
            //    lblSelectCastastrophe.Text = Assets.Resources.ApplicationStrings.SelectCatastropheValidationError;
            //    lblSelectCastastrophe.Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 0, 0));
            //}
        }
    }
}