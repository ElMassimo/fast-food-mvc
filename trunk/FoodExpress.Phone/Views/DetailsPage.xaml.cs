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
            comboBoxStatus.ItemsSource = new List<string>(){ "New", "Assigned", "On its way", "Delivered", "Lost" };
            comboBoxStatus.SelectionChanged += (s, ea) => {
                btnSend.IsEnabled = comboBoxStatus.SelectedIndex > Orders.Detail.Status && Orders.Detail.Status < 3;
            };
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (Orders.Selected == null)
                NavigationService.GoBack();
            else
            {
                btnSend.IsEnabled = false;
                Orders.Detail = null;
                var services = new DeliveryServicesClient();
                services.GetOrderDetailCompleted += (s, ea) =>
                {
                    if (!ea.Cancelled)
                        Orders.Detail = ea.Result;
                    OrderDetail detail = Orders.Detail;
                    if (detail == null)
                        NavigationService.GoBack();
                    else
                    {
                        lblErrorMessage.Text = "Select the order's current status";
                        PageTitle.Text = String.Format("order {0}", detail.Id);
                        comboBoxStatus.SelectedIndex = detail.Status;
                        txtOrderDescription.Text = detail.Description;
                        txtDateOrdered.Text = detail.DateOrdered.ToString("dd/MM/yy hh:mm");
                        txtOrderPrice.Text = detail.Cost.ToString("C2");
                        txtAddress.Text = detail.Address;
                    }
                };
                lblErrorMessage.Text = "Loading...";
                lblErrorMessage.Foreground = new SolidColorBrush(Colors.White);
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
                    lblErrorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    comboBoxStatus.IsEnabled = false;
                    btnSend.Content = "Error!";
                }
                else if (!ea.Result)
                {
                    lblErrorMessage.Text = "Error. Incorrect order number or credentials";
                    lblErrorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    comboBoxStatus.IsEnabled = false;
                    btnSend.Content = "Error!";
                }
                else
                {
                    lblErrorMessage.Text = "The order status was succesfully updated";
                    lblErrorMessage.Foreground = new SolidColorBrush(Colors.White);
                    btnSend.Content = "OK!";
                }
            };
            btnSend.Content = "Sending";
            btnSend.IsEnabled = false;
            Orders.Detail.Status = comboBoxStatus.SelectedIndex;
            services.DeliverOrderAsync(User.Nick, User.Password, Orders.Selected.Id, comboBoxStatus.SelectedIndex);
        }
    }
}