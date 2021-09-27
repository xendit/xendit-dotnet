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

    public class EWalletChargeClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void EWalletChargeClient_ShouldSuccess_GetByChargeId()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<EWalletChargeResponse>(HttpMethod.Get, Constant.GetChargeUrl, Constant.ApiKey, Constant.BaseUrl, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            EWalletChargeResponse actualEWalletCharge = await client.EWalletCharge.Get(Constant.ChargeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletChargeClient_ShouldSuccess_GetByChargeId_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<EWalletChargeResponse>(HttpMethod.Get, Constant.GetChargeUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            EWalletChargeResponse actualEWalletCharge = await client.EWalletCharge.Get(Constant.ChargeId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletChargeClient_ShouldSuccess_Create()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<EWalletChargeParameter, EWalletChargeResponse>(HttpMethod.Post, Constant.EWalletChargeUrl, Constant.ApiKey, Constant.BaseUrl, Constant.EWalletBody, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            EWalletChargeResponse actualEWalletCharge = await client.EWalletCharge.Create(Constant.EWalletBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletChargeClient_ShouldSuccess_Create_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<EWalletChargeParameter, EWalletChargeResponse>(HttpMethod.Post, Constant.EWalletChargeUrl, Constant.ApiKey, Constant.BaseUrl, Constant.EWalletBody, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            EWalletChargeResponse actualEWalletCharge = await client.EWalletCharge.Create(Constant.EWalletBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }
    }
}
