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

            Invoice actualInvoice = await Invoice.GetById(Constant.InvoiceId, Constant.CustomHeaders);
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

            Invoice actualInvoice = await Invoice.GetById(Constant.InvoiceId, Constant.CustomHeaders);
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

            Invoice actualInvoice = await Invoice.Create(Constant.InvoiceBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_GetAll_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Invoice[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.InvoiceListUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice[] actualInvoiceArray = await Invoice.GetAll(Constant.QueryParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }

        [Fact]
        public async void Invoice_GetAll_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Invoice[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.InvoiceListUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditConfiguration.RequestClient = MockClient.Object;

            Invoice[] actualInvoiceArray = await Invoice.GetAll(Constant.QueryParams, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }
    }
}
