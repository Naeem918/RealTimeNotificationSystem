using Abp.Authorization;
using Abp.Domain.Services;
using Abp.Localization;
using Abp.Notifications;
using CloudBaseLine.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudBaseLine.Notification
{
   public  class AppNotificationProvider: NotificationProvider
    {
        public override void SetNotifications(INotificationDefinitionContext context)
        {
            context.Manager.Add(
                new NotificationDefinition(
                    AppNotificationName.WelcomeToTheApplication,
                    displayName: L("NewUserRegisteredNotificationDefinition"),
                    description: L("This notification is for registering new User")
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CloudBaseLineConsts.LocalizationSourceName);
        }
    }
}
