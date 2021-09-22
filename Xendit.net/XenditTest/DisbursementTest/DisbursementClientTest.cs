namespace XenditTest.DisbursementTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Model.Disbursement;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class DisbursementClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void DisbursementClient_ShouldSuccess_GetAvailableBanks()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<AvailableBank[]>(HttpMethod.Get, null, Constant.AvailableBankUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            AvailableBank[] actualAvailableBanks = await client.Disbursement.GetAvailableBanks();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void DisbursementClient_ShouldSuccess_GetAvailableBanks_WithCustomHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<AvailableBank[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.AvailableBankUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            AvailableBank[] actualAvailableBanks = await client.Disbursement.GetAvailableBanks(Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void DisbursementClient_ShouldSuccess_GetById()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DisbursementResponse>(HttpMethod.Get, null, Constant.DisbursementIdUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DisbursementResponse actualDisbursement = await client.Disbursement.GetById(Constant.ExpectedDisbursementId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void DisbursementClient_ShouldSuccess_GetById_WithCustomHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DisbursementResponse>(HttpMethod.Get, Constant.CustomHeaders, Constant.DisbursementIdUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DisbursementResponse actualDisbursement = await client.Disbursement.GetById(Constant.ExpectedDisbursementId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void DisbursementClient_ShouldSuccess_GetByExternalId()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DisbursementResponse[]>(HttpMethod.Get, null, Constant.DisbursementExternalIdUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedDisbursements);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DisbursementResponse[] actualDisbursements = await client.Disbursement.GetByExternalId(Constant.ExpectedDisbursementExternalId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursements), JsonSerializer.Serialize(actualDisbursements));
        }

        [Fact]
        public async void DisbursementClient_ShouldSuccess_GetByExternalId_WithCustomHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DisbursementResponse[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.DisbursementExternalIdUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedDisbursements);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DisbursementResponse[] actualDisbursements = await client.Disbursement.GetByExternalId(Constant.ExpectedDisbursementExternalId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursements), JsonSerializer.Serialize(actualDisbursements));
        }

        [Fact]
        public async void DisbursementClient_ShouldSuccess_WhenCreate()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DisbursementParameter, DisbursementResponse>(HttpMethod.Post, null, Constant.DisbursementUrl, Constant.ApiKey, Constant.BaseUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DisbursementResponse actualDisbursement = await client.Disbursement.Create(Constant.DisbursementBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void DisbursementClient_ShouldSuccess_WhenCreate_WithCustomHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DisbursementParameter, DisbursementResponse>(HttpMethod.Post, Constant.CustomHeaders, Constant.DisbursementUrl, Constant.ApiKey, Constant.BaseUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DisbursementResponse actualDisbursement = await client.Disbursement.Create(Constant.DisbursementBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }
    }
}
