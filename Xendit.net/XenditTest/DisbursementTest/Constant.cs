namespace XenditTest.DisbursementTest
{
    using Xendit.net.Enum;
    using Xendit.net.Model;
    using Xendit.net.Struct;

    internal static class Constant
    {
        internal static readonly AvailableBank[] ExpectedAvailableBanks =
        {
            new AvailableBank { Name = "Bank Negara Indonesia", Code = DisbursementChannelCode.Bni, CanDisburse = true, CanNameValidate = true },
            new AvailableBank { Name = "Bank Rakyat Indonesia", Code = DisbursementChannelCode.Bri, CanDisburse = true, CanNameValidate = true },
        };

        internal static readonly Disbursement ExpectedDisbursement = new Disbursement
        {
            Id = "57f1ce05bb1a631a65eee662",
            ExternalId = "disb-1475459775872",
            UserId = "5785e6334d7b410667d355c4",
            BankCode = DisbursementChannelCode.Bca,
            AccountHolderName = "MICHAEL CHEN",
            Amount = 90000,
            DisbursementDescription = "Reimbursement for shoes",
            Status = DisbursementStatus.Pending,
            EmailTo = new string[] { "somebody@email.com" },
            EmailCC = new string[] { "somebody.else@gmail.com" },
            EmailBCC = new string[] { "someone@mail.com" },
        };

        internal static readonly DisbursementParameter DisbursementBody = new DisbursementParameter
        {
            ExternalId = "disb-1475459775872",
            BankCode = DisbursementChannelCode.Bca,
            AccountHolderName = "MICHAEL CHEN",
            AccountNumber = "1234567890",
            Description = "Reimbursement for shoes",
            Amount = 90000,
        };

        internal static readonly Disbursement[] ExpectedDisbursements = new Disbursement[] { ExpectedDisbursement };

        internal static readonly string ExpectedDisbursementId = "57f1ce05bb1a631a65eee662";
        internal static readonly string ExpectedDisbursementExternalId = "disb-1475459775872";

        internal static readonly string DisbursementUrl = "https://api.xendit.co/disbursements";
        internal static readonly string DisbursementIdUrl = string.Format("{0}/{1}", DisbursementUrl, ExpectedDisbursementId);
        internal static readonly string DisbursementExternalIdUrl = string.Format("{0}?external_id={1}", DisbursementUrl, ExpectedDisbursementExternalId);

        internal static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static readonly string AvailableBankUrl = "https://api.xendit.co/available_disbursements_banks";
    }
}
