using CQRS.API.Core.Notifications;
using CQRS.API.Core.Validations;
using CQRS.API.Core.Validations.Interfaces;
using CQRS.API.Core.ValueObjects;

namespace CQRS.API.Core.Entities
{
    public class UserEntity : BaseEntity, IContract
    {
        public UserEntity(Name name, string email, Document document)
        {
            Name = name;
            Email = email;
            Document = document;
        }

        public Name Name { get; private set; }
        public string Email { get; private set; }
        public Document Document { get; private set; }

        public override bool Validate()
        {
            var contracts =
            new ContractValidations<UserEntity>()
                .StringIsOk(this.Name.FirstName, 20, 1, "O primeiro nome deve ter entre 1 caracteres e 20 caracteres", "FirstName")
                .StringIsOk(this.Name.LastName, 50, 1, "O segundo nome deve ter entre 1 caracteres e 50 caracteres", "LastName")
                .EmailIsValid(this.Email, "O e-mail não é válido", "Email")
                .DocumentIsValid(this.Document, "O documento não é válido", "Document");


            this.SetNotificationList(contracts.Notifications as List<Notification>);

            return (contracts.IsValid());
        }
    }
}
