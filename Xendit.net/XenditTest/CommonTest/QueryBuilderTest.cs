namespace XenditTest.CommonTest
{
    using Xendit.net.Common;
    using Xendit.net.Enum;
    using Xendit.net.Struct;
    using Xunit;

    public class QueryBuilderTest
    {
        [Fact]
        public void QueryBuilder_Build_WithExistingListParameter()
        {
            ListInvoiceParameter parameter = new ListInvoiceParameter
            {
                Statuses = new InvoiceStatus[] { InvoiceStatus.Expired, InvoiceStatus.Paid },
                Limit = 2,
                ClientTypes = new InvoiceClientType[] { InvoiceClientType.ApiGateway, InvoiceClientType.Dashboard },
                RecurringPaymentId = "recurring-payment-id",
            };

            string expectedResult = "&statuses=[\"EXPIRED\",\"PAID\"]&limit=2&client_types=[\"API_GATEWAY\",\"DASHBOARD\"]&recurring_payment_id=\"recurring-payment-id\"";
            Assert.Equal(expectedResult, QueryParamsBuilder.Build(parameter));
        }

        [Fact]
        public void QueryBuilder_Build_WithParameterOtherThanList()
        {
            InvoiceParameter parameter = new InvoiceParameter
            {
                ExternalId = "external-id",
                Amount = 2000,
                PaymentMethods = new InvoicePaymentChannelType[] { InvoicePaymentChannelType.Bca, InvoicePaymentChannelType.CreditCard },
            };

            string expectedResult = "&external_id=\"external-id\"&amount=2000&payment_methods=[\"BCA\",\"CREDIT_CARD\"]";
            Assert.Equal(expectedResult, QueryParamsBuilder.Build(parameter));
        }

        [Fact]
        public void QueryBuilder_Build_WithEmptyParameter()
        {
            ListInvoiceParameter parameter = new ListInvoiceParameter { };
            string expectedResult = string.Empty;
            Assert.Equal(expectedResult, QueryParamsBuilder.Build(parameter));
        }
    }
}
