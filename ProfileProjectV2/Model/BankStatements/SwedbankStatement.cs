using CsvHelper.Configuration.Attributes;
using ProfileProjectV2.Model;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace CSVParser
{
    [Index(nameof(AccountNumber))]
    public class SwedbankStatement : IEntity
    {
        [Name("Account No")]
        public string AccountNumber { get; set; }
        // TODO WTF is here? Category enum ?
        [Name("")]
        public int SomeProperty { get; set; }
        [Name("Date")]
        public DateTime Date { get; set; }
        [Name("Beneficiary")]
        public string Beneficiary { get; set; }
        [Name("Details")]
        public string Details { get; set; }
        [Name("Amount")]
        public decimal Amount { get; set; }
        [Name("Currency")]
        public string Currency { get; set; }
        [Name("D/K")]
        public string DK { get; set; }
        [Name("Record ID")]
        public string RecordId { get; set; }
        [Name("Code")]
        public string Code { get; set; }
        [Name("Reference No")]
        public string ReferenceNumber { get; set; }
        [Name("Doc. No")]
        public string DocumentNumber { get; set; }
        [Name("Code in payer IS")]
        public string CodeInIS { get; set; }
        [Name("Client code")]
        public string ClientCode { get; set; }
        [Name("Originator")]
        public string Originator { get; set; }
        [Name("Beneficiary party")]
        public string BeneficiaryParty { get; set; }
        [Ignore]
        public int Id {get;set;}
        [Ignore]
        public DateTime CreatedAt { get; set;}
        [Ignore]
        public DateTime? UpdatedAt { get; set;}
        [Ignore]
        public bool IsDeleted { get; set;}
    }
}
