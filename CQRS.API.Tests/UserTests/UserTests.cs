using CQRS.API.Core.Entities;
using CQRS.API.Core.Enums;
using CQRS.API.Core.ValueObjects;

namespace CQRS.API.Tests.UserTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Dado_Nome_Invalid_Deve_Passar()
        {
            var name = new Name("", "Lopes");
            var document = new Document("281.845.680-02", EDocumentType.CPF);

            var user = new UserEntity(name: name, email: "samuel@samuel.com", document: document);

            Assert.IsFalse(user.Validate());
            Assert.AreEqual(user.Notifications.First().PropertyName, "FirstName");
            Assert.AreEqual(user.Notifications.First().Message, "O primeiro nome deve ter entre 1 caracteres e 20 caracteres");
        }

        [TestMethod]
        public void Dado_SobreNome_Invalid_Deve_Passar()
        {
            var name = new Name("Samuel", "");
            var document = new Document("281.845.680-02", EDocumentType.CPF);

            var user = new UserEntity(name: name, email: "samuel@samuel.com", document: document);

            Assert.IsFalse(user.Validate());
            Assert.AreEqual(user.Notifications.First().PropertyName, "LastName");
            Assert.AreEqual(user.Notifications.First().Message, "O segundo nome deve ter entre 1 caracteres e 50 caracteres");
        }


        [TestMethod]
        public void Dado_Email_Invalid_Deve_Passar()
        {
            var name = new Name("Samuel", "Lopes");
            var document = new Document("281.845.680-02", EDocumentType.CPF);

            var user = new UserEntity(name: name, email: "email", document: document);

            Assert.IsFalse(user.Validate());
            Assert.AreEqual(user.Notifications.First().PropertyName, "Email");
            Assert.AreEqual(user.Notifications.First().Message, "O e-mail não é válido");
        }

        [TestMethod]
        public void Dado_Document_CPF_Invalid_Deve_Passar()
        {
            var name = new Name("Samuel", "Lopes");
            var document = new Document("12345", EDocumentType.CPF);

            var user = new UserEntity(name: name, email: "samuel@samuel.com", document: document);

            Assert.IsFalse(user.Validate());
            Assert.AreEqual(user.Notifications.First().PropertyName, "Document CPF");
            Assert.AreEqual(user.Notifications.First().Message, "O documento não é válido");
        }

        [TestMethod]
        public void Dado_Document_CNPJ_Invalid_Deve_Passar()
        {
            var name = new Name("Samuel", "Lopes");
            var document = new Document("12345", EDocumentType.CNPJ);

            var user = new UserEntity(name: name, email: "samuel@samuel.com", document: document);

            Assert.IsFalse(user.Validate());
            Assert.AreEqual(user.Notifications.First().PropertyName, "Document CNPJ");
            Assert.AreEqual(user.Notifications.First().Message, "O documento não é válido");
        }
    }
}