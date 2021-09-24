namespace XenditTest.VirtualAccountTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Model.VirtualAccount;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class VirtualAccountClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_GetAvailableBanks()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<AvailableBank[]>(HttpMethod.Get, Constant.AvailableBankUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            AvailableBank[] actualAvailableBanks = await client.VirtualAccount.GetAvailableBanks();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_GetAvailableBanks_WithCustomHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<AvailableBank[]>(HttpMethod.Get, Constant.AvailableBankUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            AvailableBank[] actualAvailableBanks = await client.VirtualAccount.GetAvailableBanks(Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_GetVirtualAccountById()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<VirtualAccountResponse>(HttpMethod.Get, Constant.VAUrlWithId, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            VirtualAccountResponse actualVirtualAccount = await client.VirtualAccount.Get(Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_GetVirtualAccountById_WithCustomHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<VirtualAccountResponse>(HttpMethod.Get, Constant.VAUrlWithId, Constant.ApiKey, Constant.BaseUrl, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedVirtualAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            VirtualAccountResponse actualVirtualAccount = await client.VirtualAccount.Get(headers: Constant.CustomHeaders, id: Constant.VAId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccount), JsonSerializer.Serialize(actualVirtualAccount));
        }

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_WhenUpdate()
        {
            MockClient
            .Setup(mockClient => mockClient.Request<UpdateVirtualAccountParameter, VirtualAccountResponse>(XenditHttpMethod.Patch, Constant.VAUrlWithId, Constant.ApiKey, Constant.BaseUrl, Constant.UpdateVAbody, null))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            VirtualAccountResponse actualUpdatedVirtualAccount = await client.VirtualAccount.Update(id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_WhenUpdate_WithCustomHeaders()
        {
            MockClient
            .Setup(mockClient => mockClient.Request<UpdateVirtualAccountParameter, VirtualAccountResponse>(XenditHttpMethod.Patch, Constant.VAUrlWithId, Constant.ApiKey, Constant.BaseUrl, Constant.UpdateVAbody, Constant.CustomHeaders))
            .ReturnsAsync(Constant.ExpectedUpdatedVirtualAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            VirtualAccountResponse actualUpdatedVirtualAccount = await client.VirtualAccount.Update(headers: Constant.CustomHeaders, id: Constant.VAId, parameter: Constant.UpdateVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUpdatedVirtualAccount), JsonSerializer.Serialize(actualUpdatedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_WhenCreate()
        {
            MockClient
            .Setup(mockClient => mockClient.Request<CreateVirtualAccountParameter, VirtualAccountResponse>(HttpMethod.Post, Constant.VAUrl, Constant.ApiKey, Constant.BaseUrl, Constant.ClosedPostVAbody, null))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            VirtualAccountResponse actualCreatedClosedVirtualAccount = await client.VirtualAccount.Create(parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }

        [Fact]
        public async void VirtualAccountClient_ShouldSuccess_WhenCreate_WithCustomHeaders()
        {
            MockClient
            .Setup(mockClient => mockClient.Request<CreateVirtualAccountParameter, VirtualAccountResponse>(HttpMethod.Post, Constant.VAUrl, Constant.ApiKey, Constant.BaseUrl, Constant.ClosedPostVAbody, Constant.CustomHeaders))
            .ReturnsAsync(Constant.ExpectedCreatedClosedVirtualAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            VirtualAccountResponse actualCreatedClosedVirtualAccount = await client.VirtualAccount.Create(headers: Constant.CustomHeaders, parameter: Constant.ClosedPostVAbody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCreatedClosedVirtualAccount), JsonSerializer.Serialize(actualCreatedClosedVirtualAccount));
        }
    }
}
