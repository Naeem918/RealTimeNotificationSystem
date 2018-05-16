using Abp.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudBaseLine.Notification
{
    public class SendNotificationData:NotificationData
    {
        public string name { get; set; }
        public string message { get; set; }

        public SendNotificationData(string _name,string _message)
        {
            name = _name;
            message = _message;

        }
    }
}
