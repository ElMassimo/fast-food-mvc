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
using FoodExpress.Phone.Models;
using FoodExpress.Phone.FastFoodServices;

namespace FoodExpress.Phone.Views
{
    public partial class OrdersPage : PhoneApplicationPage
    {
        public OrdersPage()
        {
            InitializeComponent();
        }

        private void UpdateState()
        {
            if (orderList.Items.Count == 0)
            {
                lblSelectOrder.Text = "Congratulations!\nYou have no undelivered orders left...";
                lblSelectOrder.Height = 100;
                btnNext.Visibility = orderList.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblSelectOrder.Text = "Select an order:";
                lblSelectOrder.Height = 40;
                btnNext.Visibility = orderList.Visibility = Visibility.Visible;
            }
            lblSelectOrder.Foreground = new SolidColorBrush(Colors.White);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (Orders.Undelivered == null)
            {
                var services = new DeliveryServicesClient();
                services.GetUndeliveredOrdersCompleted += (s, ea) =>
                {
                    if (!ea.Cancelled)
                        orderList.ItemsSource = Orders.Undelivered = ea.Result;
                    if (Orders.Undelivered == null)
                        NavigationService.GoBack();
                    else
                        UpdateState();
                };
                services.GetUndeliveredOrdersAsync(User.Nick, User.Password);
            }
            else
                orderList.ItemsSource = Orders.Undelivered;
            
            UpdateState();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (orderList.SelectedItem != null)
            {
                Orders.Selected = orderList.SelectedItem as OrderHeader;
                Orders.Undelivered = null;
                (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Views/DetailsPage.xaml", UriKind.Relative));
            }
            else
            {
                lblSelectOrder.Text = "You must select an order to continue";
                lblSelectOrder.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}