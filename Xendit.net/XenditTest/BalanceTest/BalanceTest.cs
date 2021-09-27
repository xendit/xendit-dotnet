namespace XenditTest.BalanceTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Model.Balance;
    using Xendit.net.Network;
    using Xunit;

    public class BalanceTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void Balance_ShouldSuccess_IfNoGivenParam()
        {
            MockClient
                .Setup(client => client.Request<BalanceResponse>(HttpMethod.Get, Constant.Url, null, null, null))
                .ReturnsAsync(Constant.ExpectedBalance);

            XenditConfiguration.RequestClient = MockClient.Object;

            BalanceResponse actualBalance = await Balance.Get();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam()
        {
            MockClient
                .Setup(client => client.Request<BalanceResponse>(HttpMethod.Get, Constant.AccountTypeUrl, null, null, null))
                .ReturnsAsync(Constant.ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            BalanceResponse actualBalance = await Balance.Get(BalanceAccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<BalanceResponse>(HttpMethod.Get, Constant.AccountTypeUrl, null, null, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            BalanceResponse actualBalance = await Balance.Get(BalanceAccountType.Holding, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }
    }
}
