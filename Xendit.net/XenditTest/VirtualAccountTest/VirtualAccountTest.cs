using System.Net.Http;
using System.Text.Json;
using Moq;
using Xendit.net;
using Xendit.net.Model;
using Xendit.net.Network;
using Xendit.net.Struct;
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
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, null, Constant.AvailableBankUrl))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await VirtualAccount.GetAvailableBanks();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetAvailableBanks_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.AvailableBankUrl))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await VirtualAccount.GetAvailableBanks(Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetVirtualAccountById()
        {
            MockClient
                .Setup(client => client.Request<VirtualAccount>(HttpMethod.Get, null, Constant.VAUrlWithId))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualVirtualAccount = await VirtualAccount.Get(Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetVirtualAccountById_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<VirtualAccount>(HttpMethod.Get, Constant.CustomHeaders, Constant.VAUrlWithId))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualVirtualAccount = await VirtualAccount.Get(headers: Constant.CustomHeaders, id: Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenUpdate()
        {
            MockClient
            .Setup(client => client.Request<UpdateVirtualAccountParameter, VirtualAccount>(XenditHttpMethod.Patch, null, Constant.VAUrlWithId, Constant.UpdateVAbody))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualUpdatedVirtualAccount = await VirtualAccount.Update(id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenUpdate_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<UpdateVirtualAccountParameter, VirtualAccount>(XenditHttpMethod.Patch, Constant.CustomHeaders, Constant.VAUrlWithId, Constant.UpdateVAbody))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualUpdatedVirtualAccount = await VirtualAccount.Update(headers: Constant.CustomHeaders, id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreate()
        {
            MockClient
            .Setup(client => client.Request<CreateVirtualAccountParameter, VirtualAccount>(HttpMethod.Post, null, Constant.VAUrl, Constant.ClosedPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.Create(parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreate_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<CreateVirtualAccountParameter, VirtualAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.VAUrl, Constant.ClosedPostVAbody))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccount actualCreatedClosedVirtualAccount = await VirtualAccount.Create(headers: Constant.CustomHeaders, parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }
    }
}
