using System.Collections.Generic;
using Xendit.net.Model;

namespace XenditTest.VirtualAccountTest
{
    internal static class Constant
    {
        internal static readonly List<AvailableBank> ExpectedAvailableBanks = new List<AvailableBank>()
        {
            new AvailableBank{ Name = "Bank Negara Indonesia", Code = "BNI" },
            new AvailableBank{ Name = "Bank Rakyat Indonesia", Code = "BRI" }
        };

        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" }
        };

        internal static readonly VirtualAccount ExpectedVirtualAccount = new VirtualAccount
        {
            IsClosed = false,
            Status = "ACTIVE",
            Currency = "IDR",
            OwnerId = "owner-id",
            BankCode = "BNI",
            MerchantCode = "1",
            Name = "Rika",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2052-07-12T17:00:00.000Z",
            Id = "virtual-account-id"
        };

        internal static readonly VirtualAccount ExpectedUpdatedVirtualAccount = new VirtualAccount
        {
            IsClosed = false,
            Status = "ACTIVE",
            Currency = "IDR",
            OwnerId = "owner-id",
            BankCode = "BNI",
            MerchantCode = "1",
            Name = "Rika",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2019-11-12T23:46:00.000Z",
            Id = "virtual-account-id",
            ExpectedAmount = 6000,
        };

        internal static readonly Dictionary<string, object> UpdateVAbody = new Dictionary<string, object>()
        {
            { "expiration_date", "2019-11-12T23:46:00.000Z" },
            { "expected_amount", 6000 }
        };

        internal static readonly Dictionary<string, object> ClosedPostVAbody = new Dictionary<string, object>()
        {
            { "external_id", "demo-1475804036622" },
            { "bank_code", "BNI" },
            { "name", "Rika Sutanto" },
            { "is_closed", true },
        };

        internal static readonly Dictionary<string, object> OpenPostVAbody = new Dictionary<string, object>()
        {
            { "external_id", "demo-1475804036622" },
            { "bank_code", "BNI" },
            { "name", "Rika Sutanto" },
            { "is_closed", false },
        };

        internal static readonly Dictionary<string, object> ClosedPostVAbodyWithAdditionalParams = new Dictionary<string, object>()
        {
            { "expiration_date", "2019-11-12T23:46:00.000Z" },
            { "external_id", "demo-1475804036622" },
            { "bank_code", "BNI" },
            { "name", "Rika Sutanto" },
            { "is_closed", true },
        };

        internal static readonly Dictionary<string, object> OpenPostVAbodyWithAdditionalParams = new Dictionary<string, object>()
        {
            { "expiration_date", "2019-11-12T23:46:00.000Z" },
            { "external_id", "demo-1475804036622" },
            { "bank_code", "BNI" },
            { "name", "Rika Sutanto" },
            { "is_closed", false },
        };

        internal static readonly VirtualAccount ExpectedCreatedClosedVirtualAccount = new VirtualAccount
        {
            IsClosed = true,
            Status = "ACTIVE",
            Currency = "IDR",
            OwnerId = "owner-id",
            BankCode = "BNI",
            MerchantCode = "1",
            Name = "Rika Sutanto",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2019-11-12T23:46:00.000Z",
            Id = "virtual-account-id",
            ExpectedAmount = 6000,
            ExternalId = "demo-1475804036622"
        };

        internal static readonly VirtualAccount ExpectedCreatedOpenVirtualAccount = new VirtualAccount
        {
            IsClosed = false,
            Status = "ACTIVE",
            Currency = "IDR",
            OwnerId = "owner-id",
            BankCode = "BNI",
            MerchantCode = "1",
            Name = "Rika Sutanto",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2019-11-12T23:46:00.000Z",
            Id = "virtual-account-id",
            ExternalId = "demo-1475804036622"
        };

        internal static readonly string VAId = "virtual-account-id";
        internal static readonly string VAUrl = "https://api.xendit.co/callback_virtual_accounts";
        internal static readonly string VAUrlWithId = string.Format("{0}/{1}", VAUrl, VAId);
        internal static readonly string AvailableBankUrl = "https://api.xendit.co/available_virtual_account_banks";

        internal static readonly string PaymentId = "1502450097080";
        internal static readonly string VirtualAccountPaymentUrl = string.Format("https://api.xendit.co/callback_virtual_account_payments/payment_id={0}", PaymentId);
        internal static readonly VirtualAccountPayment ExpectedVirtualAccountPayment = new VirtualAccountPayment
        {
            Id = "598d91b1191029596846047f",
            PaymentId = "1502450097080",
            CallbackVirtualAccountId = "598d5f71bf64853820c49a18",
            ExternalId = "demo-1502437214715",
            MerchantCode = "77517",
            BankCode = "BNI",
            Amount = 5000,
            SenderName = "JOHN DOE",
            TransactionTimestamp = "2017-08-11T11:14:57.080Z"
        };
    }
}
