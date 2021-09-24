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

    public class EWalletChargeTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void EWalletCharge_ShouldSuccess_GetByChargeId()
        {
            MockClient
                .Setup(client => client.Request<EWalletChargeResponse>(HttpMethod.Get, Constant.GetChargeUrl, null, null, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletChargeResponse actualEWalletCharge = await EWalletCharge.Get(Constant.ChargeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_GetByChargeId_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<EWalletChargeResponse>(HttpMethod.Get, Constant.GetChargeUrl, null, null, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletChargeResponse actualEWalletCharge = await EWalletCharge.Get(Constant.ChargeId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_Create()
        {
            MockClient
                .Setup(client => client.Request<EWalletChargeParameter, EWalletChargeResponse>(HttpMethod.Post, Constant.EWalletChargeUrl, null, null, Constant.EWalletBody, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletChargeResponse actualEWalletCharge = await EWalletCharge.Create(Constant.EWalletBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_Create_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<EWalletChargeParameter, EWalletChargeResponse>(HttpMethod.Post, Constant.EWalletChargeUrl, null, null, Constant.EWalletBody, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletChargeResponse actualEWalletCharge = await EWalletCharge.Create(Constant.EWalletBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }
    }
}
