using Abp;
using Abp.Notifications;
using CloudBaseLine.Authorization.Users;
using CloudBaseLine.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudBaseLine.Notification
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        //Task NewUserRegisteredAsync(User user);

        //Task NewTenantRegisteredAsync(Tenant tenant);

        //Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
