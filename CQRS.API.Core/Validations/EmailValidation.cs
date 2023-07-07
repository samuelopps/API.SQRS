using CQRS.API.Core.Notifications;
using System.Text.RegularExpressions;

namespace CQRS.API.Core.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> EmailIsValid(string email, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$"))
                AddNotification(new Notification(message, propertyName));

            return this;

        }
    }
}
