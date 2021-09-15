namespace XenditTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class BalanceTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();
        private static readonly string Url = "https://api.xendit.co/balance";
        private static readonly Balance ExpectedBalance = new Balance { Value = 10000 };
        private static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        [Fact]
        public async void Balance_ShouldSuccess_IfNoGivenParam()
        {
            MockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, null, Url))
                .ReturnsAsync(ExpectedBalance);

            XenditConfiguration.RequestClient = MockClient.Object;

            Balance actualBalance = await Balance.Get();
            Assert.Equal(JsonSerializer.Serialize(ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", Url, "HOLDING");

            MockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, null, accountTypeUrl))
                .ReturnsAsync(ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            Balance actualBalance = await Balance.Get(BalanceAccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam_WithCustomHeaders()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", Url, "HOLDING");

            MockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, CustomHeaders, accountTypeUrl))
                .ReturnsAsync(ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            Balance actualBalance = await Balance.Get(BalanceAccountType.Holding, CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }
    }
}
