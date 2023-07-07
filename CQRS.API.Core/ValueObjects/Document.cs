using CQRS.API.Core.Enums;

namespace CQRS.API.Core.ValueObjects
{
    public record Document
    {
        public Document(string documentNumber, EDocumentType documentType)
        {
            DocumentNumber = documentNumber;
            DocumentType = documentType;
        }

        public string DocumentNumber { get; init; }
        public EDocumentType DocumentType { get; init; }
    }
}
