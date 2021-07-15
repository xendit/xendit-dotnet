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

        [Fact]
        public async void Balance_ShouldSuccess_IfNoGivenParam()
        {
            Balance expectedBalance = new Balance();
            expectedBalance.Value = 10000;

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
            Balance expectedBalance = new Balance();
            expectedBalance.Value = 10000;

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
