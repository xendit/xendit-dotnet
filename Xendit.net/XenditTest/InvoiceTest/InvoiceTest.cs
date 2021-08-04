namespace XenditTest.InvoiceTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xunit;

    public class InvoiceTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void Invoice_GetById_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Get, new Dictionary<string, string>(), Constant.InvoiceByIdUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.GetById(Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_GetById_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Get, Constant.CustomHeaders, Constant.InvoiceByIdUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.GetById(Constant.CustomHeaders, Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Expire_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Post, new Dictionary<string, string>(), Constant.InvoiceExpireUrl, new Dictionary<string, object>()))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.GetById(Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Expire_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Post, Constant.CustomHeaders, Constant.InvoiceExpireUrl, new Dictionary<string, object>()))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.GetById(Constant.CustomHeaders, Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Create_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Post, new Dictionary<string, string>(), Constant.InvoiceV2Url, Constant.InvoiceBody))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.Create(Constant.InvoiceBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Create_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Post, Constant.CustomHeaders, Constant.InvoiceV2Url, Constant.InvoiceBody))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.Create(Constant.CustomHeaders, Constant.InvoiceBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Create_RequiredParams_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Post, new Dictionary<string, string>(), Constant.InvoiceV2Url, Constant.InvoiceBody))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.Create(Constant.ExpectedInvoice.ExternalId, Constant.ExpectedInvoice.Amount);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Create_RequiredParams_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Invoice>(HttpMethod.Post, Constant.CustomHeaders, Constant.InvoiceV2Url, Constant.InvoiceBody))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice actualInvoice = await Invoice.Create(Constant.CustomHeaders, Constant.ExpectedInvoice.ExternalId, Constant.ExpectedInvoice.Amount);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_GetAll_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Invoice[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.InvoiceListUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice[] actualInvoiceArray = await Invoice.GetAll(new Dictionary<string, string>(), Constant.QueryParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }

        [Fact]
        public async void Invoice_GetAll_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Invoice[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.InvoiceListUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice[] actualInvoiceArray = await Invoice.GetAll(Constant.CustomHeaders, Constant.QueryParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }
    }
}
