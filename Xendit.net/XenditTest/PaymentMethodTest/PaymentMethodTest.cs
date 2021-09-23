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

    public class PaymentMethodTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void PaymentMethod_ShouldSuccess_CreatePaymentMethod()
        {
            MockClient
                .Setup(client => client.Request<PaymentMethodParameter, PaymentMethodResponse>(HttpMethod.Post, null, Constant.PaymentMethodUrl, null, null, Constant.PaymentMethodBody))
                .ReturnsAsync(Constant.ExpectedPaymentMethod);

            XenditConfiguration.RequestClient = MockClient.Object;

            PaymentMethodResponse actualPaymentMethod = await PaymentMethod.Create(Constant.PaymentMethodBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethod), JsonSerializer.Serialize(actualPaymentMethod));
        }

        [Fact]
        public async void PaymentMethod_ShouldSuccess_CreatePaymentMethod_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<PaymentMethodParameter, PaymentMethodResponse>(HttpMethod.Post, Constant.CustomHeaders, Constant.PaymentMethodUrl, null, null, Constant.PaymentMethodBody))
                .ReturnsAsync(Constant.ExpectedPaymentMethod);

            XenditConfiguration.RequestClient = MockClient.Object;

            PaymentMethodResponse actualPaymentMethod = await PaymentMethod.Create(Constant.PaymentMethodBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethod), JsonSerializer.Serialize(actualPaymentMethod));
        }

        [Fact]
        public async void PaymentMethod_ShouldSuccess_GetPaymentMethodByCustomerId()
        {
            MockClient
                .Setup(client => client.Request<PaymentMethodResponse[]>(HttpMethod.Get, null, Constant.GetPaymentMethodByCustomerIdUrl, null, null))
                .ReturnsAsync(Constant.ExpectedPaymentMethods);

            XenditConfiguration.RequestClient = MockClient.Object;

            PaymentMethodResponse[] actualPaymentMethods = await PaymentMethod.Get(Constant.CustomerId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethods), JsonSerializer.Serialize(actualPaymentMethods));
        }

        [Fact]
        public async void PaymentMethod_ShouldSuccess_GetPaymentMethodByCustomerId_WthHeaders()
        {
            MockClient
                .Setup(client => client.Request<PaymentMethodResponse[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.GetPaymentMethodByCustomerIdUrl, null, null))
                .ReturnsAsync(Constant.ExpectedPaymentMethods);

            XenditConfiguration.RequestClient = MockClient.Object;

            PaymentMethodResponse[] actualPaymentMethods = await PaymentMethod.Get(Constant.CustomerId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentMethods), JsonSerializer.Serialize(actualPaymentMethods));
        }
    }
}
