namespace XenditTest.PaymentMethodTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model.PaymentMethod;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class PaymentMethodClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void PaymentMethodClient_ShouldSuccess_CreatePaymentMethod()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<PaymentMethodParameter, PaymentMethodResponse>(HttpMethod.Post, Constant.PaymentMethodUrl, Constant.ApiKey, Constant.BaseUrl, Constant.PaymentMethodBody, null))
                .ReturnsAsync(Constant.ExpectedPaymentMethod);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            PaymentMethodResponse actualPaymentMethod = await client.PaymentMethod.Create(Constant.PaymentMethodBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethod), JsonSerializer.Serialize(actualPaymentMethod));
        }

        [Fact]
        public async void PaymentMethodClient_ShouldSuccess_CreatePaymentMethod_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<PaymentMethodParameter, PaymentMethodResponse>(HttpMethod.Post, Constant.PaymentMethodUrl, Constant.ApiKey, Constant.BaseUrl, Constant.PaymentMethodBody, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedPaymentMethod);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            PaymentMethodResponse actualPaymentMethod = await client.PaymentMethod.Create(Constant.PaymentMethodBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethod), JsonSerializer.Serialize(actualPaymentMethod));
        }

        [Fact]
        public async void PaymentMethodClient_ShouldSuccess_GetPaymentMethodByCustomerId()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<PaymentMethodResponse[]>(HttpMethod.Get, Constant.GetPaymentMethodByCustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedPaymentMethods);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            PaymentMethodResponse[] actualPaymentMethods = await client.PaymentMethod.Get(Constant.CustomerId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethods), JsonSerializer.Serialize(actualPaymentMethods));
        }

        [Fact]
        public async void PaymentMethodClient_ShouldSuccess_GetPaymentMethodByCustomerId_WthHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<PaymentMethodResponse[]>(HttpMethod.Get, Constant.GetPaymentMethodByCustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedPaymentMethods);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            PaymentMethodResponse[] actualPaymentMethods = await client.PaymentMethod.Get(Constant.CustomerId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethods), JsonSerializer.Serialize(actualPaymentMethods));
        }
    }
}
