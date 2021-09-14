namespace XenditTest.DisbursementTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class DisbursementTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void Disbursement_ShouldSuccess_GetAvailableBanks()
        {
            MockClient
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, null, Constant.AvailableBankUrl))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await Disbursement.GetAvailableBanks();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetAvailableBanks_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.AvailableBankUrl))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await Disbursement.GetAvailableBanks(Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetById()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Get, null, Constant.DisbursementIdUrl))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.GetById(Constant.ExpectedDisbursementId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetById_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Get, Constant.CustomHeaders, Constant.DisbursementIdUrl))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.GetById(Constant.ExpectedDisbursementId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetByExternalId()
        {
            MockClient
                .Setup(client => client.Request<Disbursement[]>(HttpMethod.Get, null, Constant.DisbursementExternalIdUrl))
                .ReturnsAsync(Constant.ExpectedDisbursements);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement[] actualDisbursements = await Disbursement.GetByExternalId(Constant.ExpectedDisbursementExternalId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursements), JsonSerializer.Serialize(actualDisbursements));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetByExternalId_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<Disbursement[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.DisbursementExternalIdUrl))
                .ReturnsAsync(Constant.ExpectedDisbursements);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement[] actualDisbursements = await Disbursement.GetByExternalId(Constant.ExpectedDisbursementExternalId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursements), JsonSerializer.Serialize(actualDisbursements));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate()
        {
            MockClient
                .Setup(client => client.Request<DisbursementParameter, Disbursement>(HttpMethod.Post, null, Constant.DisbursementUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(Constant.DisbursementBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<DisbursementParameter, Disbursement>(HttpMethod.Post, Constant.CustomHeaders, Constant.DisbursementUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(Constant.DisbursementBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }
    }
}
