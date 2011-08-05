using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FoodExpress.Phone.FastFoodServices;
using System.Collections.Generic;

namespace FoodExpress.Phone.Models
{
    public static class Orders
    {
        public static IList<OrderHeader> Undelivered { get; set; }
        public static OrderHeader Selected { get; set; }
        public static OrderDetail Detail { get; set; }
    }
}
