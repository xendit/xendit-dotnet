namespace XenditTest.DisbursementTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Numerics;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xunit;

    public class DisbursementTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void Disbursement_ShouldSuccess_GetAvailableBanks()
        {
            MockClient
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.AvailableBankUrl, null))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await Disbursement.GetAvailableBanks();
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetAvailableBanks_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<AvailableBank[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.AvailableBankUrl, null))
                .ReturnsAsync(Constant.ExpectedAvailableBanks);

            XenditConfiguration.RequestClient = MockClient.Object;

            AvailableBank[] actualAvailableBanks = await Disbursement.GetAvailableBanks(Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAvailableBanks), JsonSerializer.Serialize(actualAvailableBanks));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetById()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Get, new Dictionary<string, string>(), Constant.DisbursementIdUrl, null))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.GetById(Constant.ExpectedDisbursementId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetById_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Get, Constant.CustomHeaders, Constant.DisbursementIdUrl, null))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.GetById(Constant.CustomHeaders, Constant.ExpectedDisbursementId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetByExternalId()
        {
            MockClient
                .Setup(client => client.Request<Disbursement[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.DisbursementExternalIdUrl, null))
                .ReturnsAsync(Constant.ExpectedDisbursements);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement[] actualDisbursements = await Disbursement.GetByExternalId(Constant.ExpectedDisbursementExternalId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursements), JsonSerializer.Serialize(actualDisbursements));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_GetByExternalId_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<Disbursement[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.DisbursementExternalIdUrl, null))
                .ReturnsAsync(Constant.ExpectedDisbursements);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement[] actualDisbursements = await Disbursement.GetByExternalId(Constant.CustomHeaders, Constant.ExpectedDisbursementExternalId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursements), JsonSerializer.Serialize(actualDisbursements));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Post, new Dictionary<string, string>(), Constant.DisbursementUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(Constant.DisbursementBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Post, Constant.CustomHeaders, Constant.DisbursementUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(Constant.CustomHeaders, Constant.DisbursementBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate_RequiredParams()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Post, new Dictionary<string, string>(), Constant.DisbursementUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(externalId: Constant.ExpectedDisbursement.ExternalId, bankCode: Constant.ExpectedDisbursement.BankCode, accountHolderName: Constant.ExpectedDisbursement.AccountHolderName, accountNumber: "1234567890", description: Constant.ExpectedDisbursement.DisbursementDescription, amount: new BigInteger(90000));
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate_RequiredParams_WithCustomHeaders()
        {
            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Post, Constant.CustomHeaders, Constant.DisbursementUrl, Constant.DisbursementBody))
                .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(headers: Constant.CustomHeaders, externalId: (string)Constant.DisbursementBody["external_id"], bankCode: (string)Constant.DisbursementBody["bank_code"], accountHolderName: (string)Constant.DisbursementBody["account_holder_name"], accountNumber: (string)Constant.DisbursementBody["account_number"], description: (string)Constant.DisbursementBody["description"], amount: new BigInteger(90000));
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate_AdditionalParams()
        {
            var additionalParams = new Dictionary<string, object>()
            {
                { "email_to",  "somebody@email.com" },
            };

            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Post, new Dictionary<string, string>(), Constant.DisbursementUrl, Constant.AdditionalDisbursementBodyWithRequiredParams))
                    .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(externalId: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["external_id"], bankCode: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["bank_code"], accountHolderName: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["account_holder_name"], accountNumber: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["account_number"], description: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["description"], amount: new BigInteger(90000), parameter: additionalParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }

        [Fact]
        public async void Disbursement_ShouldSuccess_WhenCreate_AdditionalParams_CustomHeaders()
        {
            var additionalParams = new Dictionary<string, object>()
            {
                { "email_to",  "somebody@email.com" },
            };

            MockClient
                .Setup(client => client.Request<Disbursement>(HttpMethod.Post, Constant.CustomHeaders, Constant.DisbursementUrl, Constant.AdditionalDisbursementBodyWithRequiredParams))
                    .ReturnsAsync(Constant.ExpectedDisbursement);

            XenditConfiguration.RequestClient = MockClient.Object;

            Disbursement actualDisbursement = await Disbursement.Create(headers: Constant.CustomHeaders, externalId: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["external_id"], bankCode: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["bank_code"], accountHolderName: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["account_holder_name"], accountNumber: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["account_number"], description: (string)Constant.AdditionalDisbursementBodyWithRequiredParams["description"], amount: new BigInteger(90000), parameter: additionalParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDisbursement), JsonSerializer.Serialize(actualDisbursement));
        }
    }
}
