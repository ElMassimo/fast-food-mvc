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
    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            lblErrorMessage.Text = String.Empty;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (Orders.Selected == null)
                NavigationService.GoBack();
            else
            {
                Orders.Detail = null;
                var services = new DeliveryServicesClient();
                services.GetOrderDetailCompleted += (s, ea) =>
                {
                    if (!ea.Cancelled)
                        Orders.Detail = ea.Result;
                    if (Orders.Detail == null)
                        NavigationService.GoBack();
                    else
                    {
                        txtOrderIdentifier.Text = Orders.Detail.Id.ToString();
                        txtOrderDescription.Text = Orders.Detail.Description;
                        txtDateOrdered.Text = Orders.Detail.DateOrdered.ToString("dd/MM/yy hh:mm");
                        txtOrderPrice.Text = Orders.Detail.Cost.ToString("C2");
                        txtAddress.Text = Orders.Detail.Address;
                    }
                };
                services.GetOrderDetailAsync(Orders.Selected.Id);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnDelivered_Click(object sender, RoutedEventArgs e)
        {
            var services = new DeliveryServicesClient();
            services.DeliverOrderCompleted += (s, ea) =>
            {
                if (ea.Cancelled)
                {
                    lblErrorMessage.Text = "Connection error. Please try again later";                    
                    btnDelivered.Content = "Error!";
                }
                else if(!ea.Result)
                {
                    lblErrorMessage.Text = "Error. Incorrect order number or credentials";                    
                    btnDelivered.Content = "Error!";
                }
                else
                    btnDelivered.Content = "Delivered!";
            };
            btnDelivered.Content = "Delivering";
            btnDelivered.IsEnabled = false;
            services.DeliverOrderAsync(User.Nick, User.Password, Orders.Selected.Id);
        }
    }
}