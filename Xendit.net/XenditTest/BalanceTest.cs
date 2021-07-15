using Xunit;
using Moq;
using Xendit.net.Model;
using Xendit.net.Network;
using Xendit.net;
using System.Net.Http;
using System.Collections.Generic;

namespace XenditTest
{
    public class BalanceTest
    {
        private readonly Mock<INetworkClient> mockClient = new Mock<INetworkClient>();
        private readonly string url = "https://api.xendit.co/balance";
        private readonly Balance expectedBalance = new Balance { Value = 10000 };

        [Fact]
        public async void Balance_ShouldSuccess_IfNoGivenParam()
        {
            mockClient
                .Setup(client => client.Request<Balance>(HttpMethod.Get, new Dictionary<string, string>(), url, null))
                .ReturnsAsync(expectedBalance);

            XenditConfiguration.RequestClient = mockClient.Object;

            Balance actualBalance = await Balance.Get();
            Assert.Equal(expectedBalance, actualBalance);
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
            Assert.Equal(expectedBalance, actualBalance);
        }
    }
}
