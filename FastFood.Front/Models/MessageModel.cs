using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFood.Front.Models
{
    public class MessageModel
    {
        public string Title { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }        
        public string Controller { get; set; }

        public MessageModel(string title, string header, string message)
            :this(title, header, message, "Index", "Home")
        {
        }

        public MessageModel(string title, string header, string message, string action, string controller)
        {
            Title = title;
            Header = header;
            Message = message;
            Action = action;
            Controller = controller;
        }
    }
}