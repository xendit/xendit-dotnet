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

    public class BalanceClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void BalanceClient_ShouldSuccess_IfNoGivenParam()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<BalanceResponse>(HttpMethod.Get, null, Constant.Url, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedBalance);

            XenditClient client = new XenditClient(Constant.ApiKey, Constant.BaseUrl, MockClient.Object);

            BalanceResponse actualBalance = await client.Balance.Get();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void BalanceClient_ShouldSuccess_IfGivenParam()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<BalanceResponse>(HttpMethod.Get, null, Constant.AccountTypeUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedBalance);

            XenditClient client = new XenditClient(Constant.ApiKey, Constant.BaseUrl, MockClient.Object);

            BalanceResponse actualBalance = await client.Balance.Get(BalanceAccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void BalanceClient_ShouldSuccess_IfGivenParam_WithCustomHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<BalanceResponse>(HttpMethod.Get, Constant.CustomHeaders, Constant.AccountTypeUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedBalance);

            XenditClient client = new XenditClient(Constant.ApiKey, Constant.BaseUrl, MockClient.Object);

            BalanceResponse actualBalance = await client.Balance.Get(BalanceAccountType.Holding, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }
    }
}
