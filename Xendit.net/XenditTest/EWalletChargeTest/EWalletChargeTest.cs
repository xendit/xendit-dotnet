namespace XenditTest.EWalletChargeTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xunit;

    public class EWalletChargeTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void EWalletCharge_ShouldSuccess_GetByChargeId()
        {
            MockClient
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Get, new Dictionary<string, string>(), Constant.GetChargeUrl, null))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Get(Constant.ChargeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_GetByChargeId_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Get, Constant.CustomHeaders, Constant.GetChargeUrl, null))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Get(Constant.CustomHeaders, Constant.ChargeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_Create()
        {
            MockClient
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Post, new Dictionary<string, string>(), Constant.EWalletChargeUrl, Constant.EWalletBody))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Create(Constant.EWalletBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_Create_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Post, Constant.CustomHeaders, Constant.EWalletChargeUrl, Constant.EWalletBody))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Create(Constant.CustomHeaders, Constant.EWalletBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_CreateParameters()
        {
            MockClient
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Post, new Dictionary<string, string>(), Constant.EWalletChargeUrl, Constant.EWalletBody))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Create(Constant.ReferenceId, Constant.Currency, Constant.Amount, Constant.CheckoutMethod, Constant.ChannelCode, Constant.ChannelProperties, null, null, null, null);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }

        [Fact]
        public async void EWalletCharge_ShouldSuccess_CreateParameters_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<EWalletCharge>(HttpMethod.Post, Constant.CustomHeaders, Constant.EWalletChargeUrl, Constant.EWalletBody))
                .ReturnsAsync(Constant.ExpectedEWalletCharge);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletCharge actualEWalletCharge = await EWalletCharge.Create(Constant.CustomHeaders, Constant.ReferenceId, Constant.Currency, Constant.Amount, Constant.CheckoutMethod, Constant.ChannelCode, Constant.ChannelProperties, null, null, null, null);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletCharge), JsonSerializer.Serialize(actualEWalletCharge));
        }
    }
}
