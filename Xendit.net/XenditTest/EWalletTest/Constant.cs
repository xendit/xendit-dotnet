namespace XenditTest.EWalletTest
{
    using System.Collections.Generic;
    using Xendit.net.Enum;
    using Xendit.net.Model.EWallet;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly EWalletCharge ExpectedEWalletCharge = new EWalletCharge
        {
            Id = "charge-id",
            BusinessId = "5f218745736e619164dc8608",
            ReferenceId = "test-reference-id",
            Status = EWalletEnum.Status.Pending,
            Currency = Currency.IDR,
            ChargeAmount = 1000,
            CaptureAmount = 1000,
            CheckoutMethod = EWalletEnum.CheckoutMethod.OneTimePayment,
            ChannelCode = EWalletEnum.ChannelCode.IdShopeepay,
            ChannelProperties = new EWalletChargeProperties
            {
                SuccessRedirectUrl = "https://dashboard.xendit.co/register/1",
            },
            Actions = new Actions
            {
                DesktopWebCheckoutUrl = "https://dashboard.xendit.co/register/1",
                MobileDeeplinkCheckoutUrl = "https://deeplinkcheckout.this/",
                QrCheckoutString = "ID123XenditQRTest321DI",
            },
            IsRedirectRequired = true,
            CallbackUrl = "https://calling-back.com/xendit/shopeepay",
            Created = "2017-07-21T17:32:28Z",
            Updated = "2017-07-21T17:32:28Z",
            VoidedAt = null,
            CaptureNow = true,
            CustomerId = null,
            PaymentMethodId = null,
            FailureCode = null,
            Basket = null,
            Metadata = new Dictionary<string, object>()
            {
                { "branch_code", "tree_branch" },
            },
        };

        internal static readonly string ReferenceId = "test-reference-id";
        internal static readonly long Amount = 1000;
        internal static readonly EWalletChargeProperties ChannelProperties = new EWalletChargeProperties
        {
            SuccessRedirectUrl = "https://dashboard.xendit.co/register/1",
        };

        internal static readonly EWalletChargeParameter EWalletBody = new EWalletChargeParameter
        {
            ReferenceId = ReferenceId,
            Currency = Currency.IDR,
            Amount = Amount,
            CheckoutMethod = EWalletEnum.CheckoutMethod.OneTimePayment,
            ChannelCode = EWalletEnum.ChannelCode.IdShopeepay,
            ChannelProperties = ChannelProperties,
        };

        internal static readonly HeaderParameter ApiVersionHeaders = new HeaderParameter
        {
            XApiVersion = ApiVersion.Version20210125,
        };

        internal static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
            XApiVersion = ApiVersion.Version20210125,
        };

        internal static readonly HeaderParameter PaymentApiVersionHeaders = new HeaderParameter
        {
            XApiVersion = ApiVersion.Version20200201,
        };

        internal static readonly string ChargeId = "charge-id";
        internal static readonly string EWalletChargeUrl = "https://api.xendit.co/ewallets/charges";
        internal static readonly string GetChargeUrl = string.Format("{0}/{1}", EWalletChargeUrl, ChargeId);

        internal static readonly string ExternalId = "external-id";
        internal static readonly EWalletEnum.PaymentType PaymentType = EWalletEnum.PaymentType.Ovo;
        internal static readonly string EWalletPaymentUrl = "https://api.xendit.co/ewallets";
        internal static readonly string GetEWalletPaymentUrl = "https://api.xendit.co/ewallets?external_id=external-id&ewallet_type=OVO";

        internal static readonly EWalletPayment ExpectedEWalletPayment = new EWalletPayment
        {
            Amount = 1000,
            BusinessId = "business-id",
            ExternalId = "external-id",
            EWalletType = EWalletEnum.PaymentType.Ovo,
            Status = EWalletEnum.Status.Pending,
            TransactionDate = "2020-01-14T11:48:47.903Z",
        };

        internal static readonly EWalletPaymentParameter EWalletPaymentParameter = new EWalletPaymentParameter
        {
            ExternalId = "external-id",
            Amount = 1000,
            Phone = "08123123123",
            EWalletType = EWalletEnum.PaymentType.Ovo,
        };
    }
}
