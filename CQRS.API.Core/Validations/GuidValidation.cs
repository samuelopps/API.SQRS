using CQRS.API.Core.Notifications;

namespace CQRS.API.Core.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> IsGuid(object guid, string message, string propertyName)
        {
            if (guid! is Guid)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
