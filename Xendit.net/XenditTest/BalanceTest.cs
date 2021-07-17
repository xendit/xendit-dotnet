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
        private readonly Mock<INetworkClient> mockClient = new Mock<INetworkClient>();
        private readonly string url = "https://api.xendit.co/balance";
        private readonly Balance expectedBalance = new Balance { Value = 10000 };
        private readonly Dictionary<string, string> customHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        [Fact]
        public async void Balance_ShouldSuccess_IfNoGivenParam()
        {
            this.mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), this.url, null))
                .ReturnsAsync(this.expectedBalance);

            XenditConfiguration.RequestClient = this.mockClient.Object;

            Balance actualBalance = await Balance.Get();
            Assert.Equal(JsonSerializer.Serialize(this.expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", this.url, "HOLDING");

            this.mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), accountTypeUrl, null))
                .ReturnsAsync(this.expectedBalance);
            XenditConfiguration.RequestClient = this.mockClient.Object;

            Balance actualBalance = await Balance.Get(accountType: Balance.AccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(this.expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam_WithCustomHeaders()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", this.url, "HOLDING");

            this.mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, this.customHeaders, accountTypeUrl, null))
                .ReturnsAsync(this.expectedBalance);
            XenditConfiguration.RequestClient = this.mockClient.Object;

            Balance actualBalance = await Balance.Get(headers: this.customHeaders, accountType: Balance.AccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(this.expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParamAccountTypeString()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", this.url, "HOLDING");

            this.mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), accountTypeUrl, null))
                .ReturnsAsync(this.expectedBalance);
            XenditConfiguration.RequestClient = this.mockClient.Object;

            Balance actualBalance = await Balance.Get(accountTypeValue: "Holding");
            Assert.Equal(JsonSerializer.Serialize(this.expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async Task Balance_ShouldFail_IfAccountTypeStringDoesntExist()
        {
            await Assert.ThrowsAsync<ParamException>(() => Balance.Get(accountTypeValue: "Wallet"));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParamAccountTypeString_WithCustomHeaders()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", this.url, "HOLDING");

            this.mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, this.customHeaders, accountTypeUrl, null))
                .ReturnsAsync(this.expectedBalance);
            XenditConfiguration.RequestClient = this.mockClient.Object;

            Balance actualBalance = await Balance.Get(headers: this.customHeaders, accountTypeValue: "Holding");
            Assert.Equal(JsonSerializer.Serialize(this.expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async Task Balance_ShouldFail_IfAccountTypeStringDoesntExist_WithCustomHeaders()
        {
            await Assert.ThrowsAsync<ParamException>(() => Balance.Get(headers: this.customHeaders, accountTypeValue: "Wallet"));
        }
    }
}
