namespace XenditTest.VirtualAccountTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model.VirtualAccount;
    using Xendit.net.Network;
    using Xunit;

    public class VirtualAccountPaymentTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void VirtualAccountPayment_ShouldSuccess_GetVirtualAccountPayment()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<VirtualAccountPaymentResponse>(HttpMethod.Get, null, Constant.VirtualAccountPaymentUrl, null, null))
                .ReturnsAsync(Constant.ExpectedVirtualAccountPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountPaymentResponse actualVirtualAccountPayment = await VirtualAccountPayment.Get(Constant.PaymentId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccountPayment), JsonSerializer.Serialize(actualVirtualAccountPayment));
        }

        [Fact]
        public async void VirtualAccountPaymentClient_ShouldSuccess_GetVirtualAccountPayment()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<VirtualAccountPaymentResponse>(HttpMethod.Get, null, Constant.VirtualAccountPaymentUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedVirtualAccountPayment);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            VirtualAccountPaymentResponse actualVirtualAccountPayment = await client.VirtualAccountPayment.Get(Constant.PaymentId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccountPayment), JsonSerializer.Serialize(actualVirtualAccountPayment));
        }
    }
}
