using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Moq;
using Xendit.net;
using Xendit.net.Model;
using Xendit.net.Network;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace XenditTest.VirtualAccountTest
{
    public class VirtualAccountTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetAvailableBanks()
        {
            MockClient
                .Setup(client => client.Request<List<AvailableBank>>(HttpMethod.Get, new Dictionary<string, string>(), Constant.AvailableBankUrl, null))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            List<AvailableBank> actualAvailableBanks = await VirtualAccount.GetAvailableBanks();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetAvailableBanks_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<List<AvailableBank>>(HttpMethod.Get, Constant.CustomHeaders, Constant.AvailableBankUrl, null))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            List<AvailableBank> actualAvailableBanks = await VirtualAccount.GetAvailableBanks(Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetVirtualAccountById()
        {
            MockClient
                .Setup(client => client.Request<VirtualAccount>(HttpMethod.Get, new Dictionary<string, string>(), Constant.VAUrlWithId, null))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualVirtualAccount = await VirtualAccount.Get(Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetVirtualAccountById_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<VirtualAccount>(HttpMethod.Get, Constant.CustomHeaders, Constant.VAUrlWithId, null))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualVirtualAccount = await VirtualAccount.Get(headers: Constant.CustomHeaders, id: Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenUpdate()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(XenditHttpMethod.Patch, new Dictionary<string, string>(), Constant.VAUrlWithId, Constant.UpdateVAbody))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualUpdatedVirtualAccount = await VirtualAccount.Update(id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenUpdate_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(XenditHttpMethod.Patch, Constant.CustomHeaders, Constant.VAUrlWithId, Constant.UpdateVAbody))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualUpdatedVirtualAccount = await VirtualAccount.Update(headers: Constant.CustomHeaders, id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateClosedVA()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.VAUrl, Constant.ClosedPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.CreateClosed(parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateClosedVA_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.VAUrl, Constant.ClosedPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.CreateClosed(headers: Constant.CustomHeaders, parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateClosedVa_RequiredParams()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.VAUrl, Constant.ClosedPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.CreateClosed(externalId: Constant.ExpectedCreatedClosedVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedClosedVirtualAccount.BankCode, name: Constant.ExpectedCreatedClosedVirtualAccount.Name, expectedAmount: Constant.ExpectedCreatedClosedVirtualAccount.ExpectedAmount);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateClosedVa_RequiredParams_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.VAUrl, Constant.ClosedPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.CreateClosed(headers: Constant.CustomHeaders, externalId: Constant.ExpectedCreatedClosedVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedClosedVirtualAccount.BankCode, name: Constant.ExpectedCreatedClosedVirtualAccount.Name, expectedAmount: Constant.ExpectedCreatedClosedVirtualAccount.ExpectedAmount);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateClosedVa_AdditionalParams()
        {
            Dictionary<string, object> additionalParams = new Dictionary<string, object>()
            {
                { "expiration_date", "2019-11-12T23:46:00.000Z" },
            };

            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.VAUrl, Constant.ClosedPostVAbodyWithAdditionalParams))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.CreateClosed(externalId: Constant.ExpectedCreatedClosedVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedClosedVirtualAccount.BankCode, name: Constant.ExpectedCreatedClosedVirtualAccount.Name, expectedAmount: Constant.ExpectedCreatedClosedVirtualAccount.ExpectedAmount, parameter: additionalParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateClosedVa_AdditionalParams_WithCustomHeaders()
        {
            Dictionary<string, object> additionalParams = new Dictionary<string, object>()
            {
                { "expiration_date", "2019-11-12T23:46:00.000Z" },
            };

            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.VAUrl, Constant.ClosedPostVAbodyWithAdditionalParams))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.CreateClosed(headers: Constant.CustomHeaders, externalId: Constant.ExpectedCreatedClosedVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedClosedVirtualAccount.BankCode, name: Constant.ExpectedCreatedClosedVirtualAccount.Name, expectedAmount: Constant.ExpectedCreatedClosedVirtualAccount.ExpectedAmount, parameter: additionalParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateOpenVA()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.VAUrl, Constant.OpenPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedOpenVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedOpenVirtualAccount = await VirtualAccount.CreateOpen(parameter: Constant.OpenPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedOpenVirtualAccount), JsonSerializer.Serialize(actualCreatedOpenVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateOpenVA_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.VAUrl, Constant.OpenPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedOpenVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedOpenVirtualAccount = await VirtualAccount.CreateOpen(headers: Constant.CustomHeaders, parameter: Constant.OpenPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedOpenVirtualAccount), JsonSerializer.Serialize(actualCreatedOpenVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateOpenVA_RequiredParams()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.VAUrl, Constant.OpenPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedOpenVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedOpenVirtualAccount = await VirtualAccount.CreateOpen(externalId: Constant.ExpectedCreatedOpenVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedOpenVirtualAccount.BankCode, name: Constant.ExpectedCreatedOpenVirtualAccount.Name);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedOpenVirtualAccount), JsonSerializer.Serialize(actualCreatedOpenVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateOpenVA_RequiredParams_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.VAUrl, Constant.OpenPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedOpenVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedOpenVirtualAccount = await VirtualAccount.CreateOpen(headers: Constant.CustomHeaders, externalId: Constant.ExpectedCreatedOpenVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedOpenVirtualAccount.BankCode, name: Constant.ExpectedCreatedOpenVirtualAccount.Name);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedOpenVirtualAccount), JsonSerializer.Serialize(actualCreatedOpenVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateOpenVA_AdditionalParams()
        {
            Dictionary<string, object> additionalParams = new Dictionary<string, object>()
            {
                { "expiration_date", "2019-11-12T23:46:00.000Z" },
            };

            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.VAUrl, Constant.OpenPostVAbodyWithAdditionalParams))
            .ReturnsAsync(Constant.ExpectedCreatedOpenVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedOpenVirtualAccount = await VirtualAccount.CreateOpen(externalId: Constant.ExpectedCreatedOpenVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedOpenVirtualAccount.BankCode, name: Constant.ExpectedCreatedOpenVirtualAccount.Name, parameter: additionalParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedOpenVirtualAccount), JsonSerializer.Serialize(actualCreatedOpenVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreateOpenVA_AdditionalParams_WithCustomHeaders()
        {
            Dictionary<string, object> additionalParams = new Dictionary<string, object>()
            {
                { "expiration_date", "2019-11-12T23:46:00.000Z" },
            };

            MockClient
            .Setup(client => client.Request<VirtualAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.VAUrl, Constant.OpenPostVAbodyWithAdditionalParams))
            .ReturnsAsync(Constant.ExpectedCreatedOpenVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedOpenVirtualAccount = await VirtualAccount.CreateOpen(headers: Constant.CustomHeaders, externalId: Constant.ExpectedCreatedOpenVirtualAccount.ExternalId, bankCode: Constant.ExpectedCreatedOpenVirtualAccount.BankCode, name: Constant.ExpectedCreatedOpenVirtualAccount.Name, parameter: additionalParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedOpenVirtualAccount), JsonSerializer.Serialize(actualCreatedOpenVirtualAccount));
        }
    }
}
