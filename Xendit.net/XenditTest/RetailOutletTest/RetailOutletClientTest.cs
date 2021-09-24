namespace XenditTest.RetailOutletTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model.RetailOutlet;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class RetailOutletClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void RetailOutletClient_Create_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, Constant.RetailOutletUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CreateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            FixedPaymentCode actualFixedPaymentCode = await client.RetailOutlet.CreatePaymentCode(Constant.CreateFixedPaymentCodeParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutletClient_CreateWithOtherThanPhilippines_ThrowsParamException()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, Constant.RetailOutletUrl, Constant.ApiKey, Constant.BaseUrl, Constant.InvalidCreateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            ParamException exception = await Assert.ThrowsAsync<ParamException>(async () => await client.RetailOutlet.CreatePaymentCode(Constant.InvalidCreateFixedPaymentCodeParameter));
            Assert.Equal("Create Payment Code can only accept Currency.PHP and Country.Philippines", exception.Message);
        }

        [Fact]
        public async void RetailOutletClient_CreateWithHeader_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, Constant.RetailOutletUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CreateFixedPaymentCodeParameter, Constant.Headers))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            FixedPaymentCode actualFixedPaymentCode = await client.RetailOutlet.CreatePaymentCode(Constant.CreateFixedPaymentCodeParameter, Constant.Headers);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutletClient_Update_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<UpdateFixedPaymentCodeParameter, FixedPaymentCode>(XenditHttpMethod.Patch, Constant.PaymentCodeIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.UpdateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            FixedPaymentCode actualFixedPaymentCode = await client.RetailOutlet.UpdatePaymentCode(Constant.UpdateFixedPaymentCodeParameter, Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutletClient_UpdateWithOtherThanPhilippinesCurrency_ThrowsParamException()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<UpdateFixedPaymentCodeParameter, FixedPaymentCode>(XenditHttpMethod.Patch, Constant.PaymentCodeIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.UpdateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            ParamException exception = await Assert.ThrowsAsync<ParamException>(async () => await client.RetailOutlet.UpdatePaymentCode(Constant.InvalidUpdateFixedPaymentCodeParameter, Constant.PaymentCodeId));
            Assert.Equal("Update Payment Code can only accept Currency.PHP", exception.Message);
        }

        [Fact]
        public async void RetailOutletClient_GetPaymentCode_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<FixedPaymentCode>(HttpMethod.Get, Constant.PaymentCodeIdUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            FixedPaymentCode actualFixedPaymentCode = await client.RetailOutlet.GetPaymentCode(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutletClient_GetPayments_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<FixedPaymentCode[]>(HttpMethod.Get, Constant.GetPaymentsUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCodes);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            FixedPaymentCode[] actualFixedPaymentCodes = await client.RetailOutlet.GetPayments(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCodes), JsonSerializer.Serialize(actualFixedPaymentCodes));
        }
    }
}
