using Xunit;
using Moq;
using Xendit.net.Model;
using Xendit.net.Network;
using Xendit.net;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.Json;
using Xendit.net.Exception;
using System.Threading.Tasks;

namespace XenditTest
{
    public class BalanceTest
    {
        private readonly Mock<INetworkClient> mockClient = new Mock<INetworkClient>();
        private readonly string url = "https://api.xendit.co/balance";
        private readonly Balance expectedBalance = new Balance { Value = 10000 };
        private readonly Dictionary<string, string> customHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" }
        };

        [Fact]
        public async void Balance_ShouldSuccess_IfNoGivenParam()
        {
            mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), url, null))
                .ReturnsAsync(expectedBalance);

            XenditConfiguration.RequestClient = mockClient.Object;

            Balance actualBalance = await Balance.Get();
            Assert.Equal(JsonSerializer.Serialize(expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", url, "HOLDING");

            mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), accountTypeUrl, null))
                .ReturnsAsync(expectedBalance);
            XenditConfiguration.RequestClient = mockClient.Object;

            Balance actualBalance = await Balance.Get(accountType: Balance.AccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParam_WithCustomHeaders()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", url, "HOLDING");

            mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, customHeaders, accountTypeUrl, null))
                .ReturnsAsync(expectedBalance);
            XenditConfiguration.RequestClient = mockClient.Object;

            Balance actualBalance = await Balance.Get(headers: customHeaders, accountType: Balance.AccountType.Holding);
            Assert.Equal(JsonSerializer.Serialize(expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParamAccountTypeString()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", url, "HOLDING");

            mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), accountTypeUrl, null))
                .ReturnsAsync(expectedBalance);
            XenditConfiguration.RequestClient = mockClient.Object;

            Balance actualBalance = await Balance.Get(accountTypeValue: "Holding");
            Assert.Equal(JsonSerializer.Serialize(expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async Task Balance_ShouldFail_IfAccountTypeStringDoesntExist()
        {
            await Assert.ThrowsAsync<ParamException>(() => Balance.Get(accountTypeValue: "Wallet"));
        }

        [Fact]
        public async void Balance_ShouldSuccess_IfGivenParamAccountTypeString_WithCustomHeaders()
        {
            string accountTypeUrl = string.Format("{0}?account_type={1}", url, "HOLDING");

            mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, customHeaders, accountTypeUrl, null))
                .ReturnsAsync(expectedBalance);
            XenditConfiguration.RequestClient = mockClient.Object;

            Balance actualBalance = await Balance.Get(headers: customHeaders, accountTypeValue: "Holding");
            Assert.Equal(JsonSerializer.Serialize(expectedBalance), JsonSerializer.Serialize(actualBalance));
        }

        [Fact]
        public async Task Balance_ShouldFail_IfAccountTypeStringDoesntExist_WithCustomHeaders()
        {
            await Assert.ThrowsAsync<ParamException>(() => Balance.Get(headers: customHeaders, accountTypeValue: "Wallet"));
        }
    }
}
