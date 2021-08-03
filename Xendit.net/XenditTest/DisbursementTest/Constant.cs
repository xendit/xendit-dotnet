namespace XenditTest.DisbursementTest
{
    using System.Collections.Generic;
    using System.Numerics;
    using Xendit.net.Model;

    internal static class Constant
    {
        internal static readonly AvailableBank[] ExpectedAvailableBanks =
        {
            new AvailableBank { Name = "Bank Negara Indonesia", Code = "BNI", CanDisburse = true, CanNameValidate = true },
            new AvailableBank { Name = "Bank Rakyat Indonesia", Code = "BRI", CanDisburse = true, CanNameValidate = true },
        };

        internal static readonly Disbursement ExpectedDisbursement = new Disbursement
        {
            Id = "57f1ce05bb1a631a65eee662",
            ExternalId = "disb-1475459775872",
            UserId = "5785e6334d7b410667d355c4",
            BankCode = "BCA",
            AccountHolderName = "MICHAEL CHEN",
            Amount = 90000,
            DisbursementDescription = "Reimbursement for shoes",
            Status = "PENDING",
            EmailTo = new string[] { "somebody@email.com" },
            EmailCC = new string[] { "somebody.else@gmail.com" },
            EmailBCC = new string[] { "someone@mail.com" },
        };

        internal static readonly Dictionary<string, object> DisbursementBody = new Dictionary<string, object>()
        {
            { "external_id", "disb-1475459775872" },
            { "bank_code", "BCA" },
            { "account_holder_name", "MICHAEL CHEN" },
            { "account_number", "1234567890" },
            { "description", "Reimbursement for shoes" },
            { "amount", new BigInteger(90000) },
        };

        internal static readonly Dictionary<string, object> AdditionalDisbursementBodyWithRequiredParams = new Dictionary<string, object>()
        {
            { "email_to", "somebody@email.com" },
            { "external_id", "disb-1475459775872" },
            { "bank_code", "BCA" },
            { "account_holder_name", "MICHAEL CHEN" },
            { "account_number", "1234567890" },
            { "description", "Reimbursement for shoes" },
            { "amount", new BigInteger(90000) },
        };

        internal static readonly Disbursement[] ExpectedDisbursements = new Disbursement[] { ExpectedDisbursement };

        internal static readonly string ExpectedDisbursementId = "57f1ce05bb1a631a65eee662";
        internal static readonly string ExpectedDisbursementExternalId = "disb-1475459775872";

        internal static readonly string DisbursementUrl = "https://api.xendit.co/disbursements";
        internal static readonly string DisbursementIdUrl = string.Format("{0}/{1}", DisbursementUrl, ExpectedDisbursementId);
        internal static readonly string DisbursementExternalIdUrl = string.Format("{0}?external_id={1}", DisbursementUrl, ExpectedDisbursementExternalId);

        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        internal static readonly string AvailableBankUrl = "https://api.xendit.co/available_disbursements_banks";
    }
}
