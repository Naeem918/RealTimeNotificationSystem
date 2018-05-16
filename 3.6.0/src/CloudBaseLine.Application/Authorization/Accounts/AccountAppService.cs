using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Notifications;
using Abp.Zero.Configuration;
using CloudBaseLine.Authorization.Accounts.Dto;
using CloudBaseLine.Authorization.Users;
using CloudBaseLine.Notification;

namespace CloudBaseLine.Authorization.Accounts
{
    public class AccountAppService : CloudBaseLineAppServiceBase, IAccountAppService
    {
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly IAppNotifier _appNotifier;
        private readonly IRealTimeNotifier _realTimeNotifier;
        private readonly IUserNotificationManager _userNotificationManager;

        public AccountAppService(
            UserRegistrationManager userRegistrationManager,
              INotificationSubscriptionManager notificationSubscriptionManager,
            IAppNotifier appNotifier,
          
            IRealTimeNotifier realTimeNotifier,
            IUserNotificationManager userNotificationManager)
        {
            _userRegistrationManager = userRegistrationManager;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _appNotifier = appNotifier;

            _userNotificationManager = userNotificationManager;
            _realTimeNotifier = realTimeNotifier;
        }

        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            var tenant = await TenantManager.FindByTenancyNameAsync(input.TenancyName);
            if (tenant == null)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.NotFound);
            }

            if (!tenant.IsActive)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.InActive);
            }

            return new IsTenantAvailableOutput(TenantAvailabilityState.Available, tenant.Id);
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                input.Name,
                input.Surname,
                input.EmailAddress,
                input.UserName,
                input.Password,
                true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
            );

            _notificationSubscriptionManager.SubscribeToAllAvailableNotifications(user.ToUserIdentifier());
            await _appNotifier.WelcomeToTheApplicationAsync(user);
    

            var notification = _userNotificationManager.GetUserNotifications(user.ToUserIdentifier());

            await _realTimeNotifier.SendNotificationsAsync(notification.ToArray());

            var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }
    }
}
