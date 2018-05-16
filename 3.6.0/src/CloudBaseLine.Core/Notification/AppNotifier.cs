using Abp;
using Abp.Localization;
using Abp.Notifications;
using CloudBaseLine.Authorization.Users;
using CloudBaseLine.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudBaseLine.Notification
{
    public class AppNotifier: BaseLineDomainServiceBase, IAppNotifier
    {
        private readonly INotificationPublisher _notificationPublisher;

        public AppNotifier(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

   

        public async Task WelcomeToTheApplicationAsync(User user)
        {
            await _notificationPublisher.PublishAsync(
                AppNotificationName.WelcomeToTheApplication,
                new SendNotificationData("Naeem","Hello I have sended this notification to you"),
                severity: NotificationSeverity.Success,
                userIds: new[] { user.ToUserIdentifier() }
               
                );
        }

        //public async Task NewUserRegisteredAsync(User user)
        //{
        //    var notificationData = new LocalizableMessageNotificationData(
        //        new LocalizableString(
        //            "NewUserRegisteredNotificationMessage",
        //            "Pakistan"
        //            )
        //        );

        //    notificationData["userName"] = user.UserName;
        //    notificationData["emailAddress"] = user.EmailAddress;

        //    await _notificationPublisher.PublishAsync(AppNotificationName.NewUserRegistered, notificationData, tenantIds: new[] { user.TenantId });
        //}

        //public async Task NewTenantRegisteredAsync(Tenant tenant)
        //{
        //    var notificationData = new LocalizableMessageNotificationData(
        //        new LocalizableString(
        //            "NewTenantRegisteredNotificationMessage",
        //           "PakistanArmy"
        //            )
        //        );

        //    notificationData["tenancyName"] = tenant.TenancyName;
        //    await _notificationPublisher.PublishAsync(AppNotificationName.NewTenantRegistered, notificationData);
        //}

        ////This is for test purposes
        //public async Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info)
        //{
        //    await _notificationPublisher.PublishAsync(
        //        "App.SimpleMessage",
        //        new MessageNotificationData(message),
        //        severity: severity,
        //        userIds: new[] { user }
        //        );
        //}

    }
}
