namespace XenditTest.EWalletChargeTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
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
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Get, Constant.ApiVersionHeaders, Constant.GetChargeUrl))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Get(Constant.ChargeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_GetByChargeId_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Get, Constant.CustomHeaders, Constant.GetChargeUrl))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Get(Constant.ChargeId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_Create()
        {
            MockClient
                .Setup(client => client.Request<EWalletChargeParameter, EWalletCharge>(HttpMethod.Post, Constant.ApiVersionHeaders, Constant.EWalletChargeUrl, Constant.EWalletBody))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Create(Constant.EWalletBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_Create_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<EWalletChargeParameter, EWalletCharge>(HttpMethod.Post, Constant.CustomHeaders, Constant.EWalletChargeUrl, Constant.EWalletBody))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Create(Constant.EWalletBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }
    }
}
