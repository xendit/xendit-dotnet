using System.Net.Http;
using System.Text.Json;
using Moq;
using Xendit.net;
using Xendit.net.Model;
using Xendit.net.Model.VirtualAccount;
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
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, Constant.AvailableBankUrl, null, null, null))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await VirtualAccount.GetAvailableBanks();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetAvailableBanks_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, Constant.AvailableBankUrl, null, null, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await VirtualAccount.GetAvailableBanks(Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetVirtualAccountById()
        {
            MockClient
                .Setup(client => client.Request<VirtualAccountResponse>(HttpMethod.Get, Constant.VAUrlWithId, null, null, null))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountResponse actualVirtualAccount = await VirtualAccount.Get(Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_GetVirtualAccountById_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<VirtualAccountResponse>(HttpMethod.Get, Constant.VAUrlWithId, null, null, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountResponse actualVirtualAccount = await VirtualAccount.Get(headers: Constant.CustomHeaders, id: Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenUpdate()
        {
            MockClient
            .Setup(client => client.Request<UpdateVirtualAccountParameter, VirtualAccountResponse>(XenditHttpMethod.Patch, Constant.VAUrlWithId, null, null, Constant.UpdateVAbody, null))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountResponse actualUpdatedVirtualAccount = await VirtualAccount.Update(id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenUpdate_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<UpdateVirtualAccountParameter, VirtualAccountResponse>(XenditHttpMethod.Patch, Constant.VAUrlWithId, null, null, Constant.UpdateVAbody, Constant.CustomHeaders))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountResponse actualUpdatedVirtualAccount = await VirtualAccount.Update(headers: Constant.CustomHeaders, id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreate()
        {
            MockClient
            .Setup(client => client.Request<CreateVirtualAccountParameter, VirtualAccountResponse>(HttpMethod.Post, Constant.VAUrl, null, null, Constant.ClosedPostVAbody, null))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountResponse actualCreatedClosedVirtualAccount = await VirtualAccount.Create(parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccount_ShouldSuccess_WhenCreate_WithCustomHeaders()
        {
            MockClient
            .Setup(client => client.Request<CreateVirtualAccountParameter, VirtualAccountResponse>(HttpMethod.Post, Constant.VAUrl, null, null, Constant.ClosedPostVAbody, Constant.CustomHeaders))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountResponse actualCreatedClosedVirtualAccount = await VirtualAccount.Create(headers: Constant.CustomHeaders, parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }
    }
}
