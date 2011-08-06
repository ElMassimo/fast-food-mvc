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
using FoodExpress.Phone.FastFoodServices;
using FoodExpress.Phone.Models;

namespace FoodExpress.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            txtErrorMessage.Text = "Please enter your username and password to log in";
            txtErrorMessage.Foreground = new SolidColorBrush(Colors.White);
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User.Nick = txtNick.Text == null ? null : txtNick.Text.Trim();
            User.Password = txtPassword.Password == null ? null : txtPassword.Password.Trim();
            
            txtErrorMessage.Foreground = new SolidColorBrush(Colors.Red);

            if (String.IsNullOrEmpty(User.Nick) || String.IsNullOrEmpty(User.Password))
            {
                txtErrorMessage.Text = "Please enter your username and password";
                return;
            }

            if (User.Nick.Length < 3 || User.Password.Length < 6)
            {
                txtErrorMessage.Text = "Username minimum length is 3.\nPassword minimum length is 6";
                return;
            }

            var services = new DeliveryServicesClient();
            services.GetUndeliveredOrdersCompleted += (s, ea) =>
                {
                    txtErrorMessage.Text = String.Empty;
                    if (ea.Cancelled)
                        txtErrorMessage.Text = "Connection error: Please try again later";
                    else
                    {
                        Orders.Undelivered = ea.Result;
                        if (Orders.Undelivered == null)
                            txtErrorMessage.Text = "Incorrect username or password";
                        else
                            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Views/OrdersPage.xaml", UriKind.Relative));
                    }
                };

            txtErrorMessage.Text = "Logging in...";
            txtErrorMessage.Foreground = new SolidColorBrush(Colors.White);
            services.GetUndeliveredOrdersAsync(User.Nick, User.Password);
        }
    }
}