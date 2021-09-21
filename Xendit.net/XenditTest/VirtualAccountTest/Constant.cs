namespace XenditTest.VirtualAccountTest
{
    using Xendit.net.Enum;
    using Xendit.net.Model;
    using Xendit.net.Model.VirtualAccount;
    using Xendit.net.Struct;

    internal static class Constant
    {
        internal static readonly AvailableBank[] ExpectedAvailableBanks = new AvailableBank[]
        {
            new AvailableBank { Name = "Bank Negara Indonesia", Code = DisbursementChannelCode.Bni },
            new AvailableBank { Name = "Bank Rakyat Indonesia", Code = DisbursementChannelCode.Bri },
        };

        internal static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static readonly VirtualAccountResponse ExpectedVirtualAccount = new VirtualAccountResponse
        {
            IsClosed = false,
            Status = VirtualAccountEnum.Status.Active,
            BankCode = VirtualAccountEnum.BankCode.Bni,
            Currency = Currency.IDR,
            OwnerId = "owner-id",
            MerchantCode = "1",
            Name = "Rika",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2052-07-12T17:00:00.000Z",
            Id = "virtual-account-id",
        };

        internal static readonly VirtualAccountResponse ExpectedUpdatedVirtualAccount = new VirtualAccountResponse
        {
            IsClosed = false,
            Status = VirtualAccountEnum.Status.Active,
            BankCode = VirtualAccountEnum.BankCode.Bni,
            Currency = Currency.IDR,
            OwnerId = "owner-id",
            MerchantCode = "1",
            Name = "Rika",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2019-11-12T23:46:00.000Z",
            Id = "virtual-account-id",
            ExpectedAmount = 6000,
        };

        internal static readonly UpdateVirtualAccountParameter UpdateVAbody = new UpdateVirtualAccountParameter
        {
            ExpirationDate = "2019-11-12T23:46:00.000Z",
        };

        internal static readonly CreateVirtualAccountParameter ClosedPostVAbody = new CreateVirtualAccountParameter
        {
            ExternalId = "demo-1475804036622",
            BankCode = VirtualAccountEnum.BankCode.Bni,
            Name = "Rika Sutanto",
            ExpectedAmount = 8000,
            IsClosed = true,
        };

        internal static readonly VirtualAccountResponse ExpectedCreatedClosedVirtualAccount = new VirtualAccountResponse
        {
            IsClosed = true,
            Status = VirtualAccountEnum.Status.Active,
            Currency = Currency.IDR,
            OwnerId = "owner-id",
            MerchantCode = "1",
            Name = "Rika Sutanto",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2019-11-12T23:46:00.000Z",
            Id = "virtual-account-id",
            ExpectedAmount = 6000L,
            ExternalId = "demo-1475804036622",
        };

        internal static readonly VirtualAccountResponse ExpectedCreatedOpenVirtualAccount = new VirtualAccountResponse
        {
            IsClosed = false,
            Status = VirtualAccountEnum.Status.Active,
            Currency = Currency.IDR,
            OwnerId = "owner-id",
            BankCode = VirtualAccountEnum.BankCode.Bni,
            MerchantCode = "1",
            Name = "Rika Sutanto",
            AccountNumber = "8808999992622802",
            IsSingleUse = false,
            ExpirationDate = "2019-11-12T23:46:00.000Z",
            Id = "virtual-account-id",
            ExternalId = "demo-1475804036622",
        };

        internal static readonly string VAId = "virtual-account-id";
        internal static readonly string VAUrl = "/callback_virtual_accounts";
        internal static readonly string VAUrlWithId = string.Format("{0}/{1}", VAUrl, VAId);
        internal static readonly string AvailableBankUrl = "/available_virtual_account_banks";

        internal static readonly string PaymentId = "1502450097080";
        internal static readonly string VirtualAccountPaymentUrl = string.Format("/callback_virtual_account_payments/payment_id={0}", PaymentId);
        internal static readonly VirtualAccountPaymentResponse ExpectedVirtualAccountPayment = new VirtualAccountPaymentResponse
        {
            Id = "598d91b1191029596846047f",
            PaymentId = "1502450097080",
            CallbackVirtualAccountId = "598d5f71bf64853820c49a18",
            ExternalId = "demo-1502437214715",
            MerchantCode = "77517",
            BankCode = VirtualAccountEnum.BankCode.Bni,
            Amount = 5000,
            SenderName = "JOHN DOE",
            TransactionTimestamp = "2017-08-11T11:14:57.080Z",
        };

        internal static readonly string ApiKey = "api-key";
        internal static readonly string BaseUrl = "https://api.xendit.co";
    }
}
