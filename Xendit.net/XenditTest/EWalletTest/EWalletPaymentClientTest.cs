namespace XenditTest.EWalletTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model.EWallet;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class EWalletPaymentClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void EWalletPaymentClient_Create_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<EWalletPaymentParameter, EWalletPaymentResponse>(HttpMethod.Post, Constant.PaymentApiVersionHeaders, Constant.EWalletPaymentUrl, Constant.ApiKey, Constant.BaseUrl, Constant.EWalletPaymentParameter))
                .ReturnsAsync(Constant.ExpectedEWalletPayment);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            EWalletPaymentResponse actualEWalletPayment = await client.EWalletPayment.Create(Constant.EWalletPaymentParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletPayment), JsonSerializer.Serialize(actualEWalletPayment));
        }

        [Fact]
        public async void EWalletPaymentClient_Get_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<EWalletPaymentResponse>(HttpMethod.Get, Constant.CustomHeaders, Constant.GetEWalletPaymentUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedEWalletPayment);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            EWalletPaymentResponse actualEWalletPayment = await client.EWalletPayment.Get(Constant.ExternalId, Constant.PaymentType, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletPayment), JsonSerializer.Serialize(actualEWalletPayment));
        }
    }
}
