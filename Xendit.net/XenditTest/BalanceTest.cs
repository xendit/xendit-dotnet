namespace XenditTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Moq;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xunit;

    public class BalanceTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();
        private static readonly string Url = "https://api.xendit.co/balance";
        private static readonly Balance ExpectedBalance = new Balance { Value = 10000 };
        private static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        [Fact]
        public async void Balance_ShouldSuccess_IfNoGivenParam()
        {
            MockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), Url, null))
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
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), accountTypeUrl, null))
                .ReturnsAsync(ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            Balance actualBalance = await Balance.Get(accountType: Balance.AccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam_WithCustomHeaders()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", Url, "HOLDING");

            MockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, CustomHeaders, accountTypeUrl, null))
                .ReturnsAsync(ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            Balance actualBalance = await Balance.Get(headers: CustomHeaders, accountType: Balance.AccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParamAccountTypeString()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", Url, "HOLDING");

            MockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), accountTypeUrl, null))
                .ReturnsAsync(ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            Balance actualBalance = await Balance.Get(accountTypeValue: "Holding");
            Assert.Equal(JsonSerializer.Serialize(ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async Task Balance_ShouldFail_IfAccountTypeStringDoesntExist()
        {
            await Assert.ThrowsAsync<ParamException>(() => Balance.Get(accountTypeValue: "Wallet"));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParamAccountTypeString_WithCustomHeaders()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", Url, "HOLDING");

            MockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, CustomHeaders, accountTypeUrl, null))
                .ReturnsAsync(ExpectedBalance);
            XenditConfiguration.RequestClient = MockClient.Object;

            Balance actualBalance = await Balance.Get(headers: CustomHeaders, accountTypeValue: "Holding");
            Assert.Equal(JsonSerializer.Serialize(ExpectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async Task Balance_ShouldFail_IfAccountTypeStringDoesntExist_WithCustomHeaders()
        {
            await Assert.ThrowsAsync<ParamException>(() => Balance.Get(headers: CustomHeaders, accountTypeValue: "Wallet"));
        }
    }
}
