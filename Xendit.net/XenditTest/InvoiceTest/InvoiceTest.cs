namespace XenditTest.InvoiceTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model.Invoice;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class InvoiceTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void Invoice_GetById_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<InvoiceResponse>(HttpMethod.Get, null, Constant.InvoiceByIdUrl, null, null))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse actualInvoice = await Invoice.GetById(Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_GetById_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<InvoiceResponse>(HttpMethod.Get, Constant.CustomHeaders, Constant.InvoiceByIdUrl, null, null))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse actualInvoice = await Invoice.GetById(Constant.InvoiceId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Expire_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, InvoiceResponse>(HttpMethod.Post, null, Constant.InvoiceExpireUrl, null, null, new Dictionary<string, string>()))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse actualInvoice = await Invoice.Expire(Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Expire_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, InvoiceResponse>(HttpMethod.Post, Constant.CustomHeaders, Constant.InvoiceExpireUrl, null, null, new Dictionary<string, string>()))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse actualInvoice = await Invoice.Expire(Constant.InvoiceId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Create_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<InvoiceParameter, InvoiceResponse>(HttpMethod.Post, null, Constant.InvoiceV2Url, null, null, Constant.InvoiceBody))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse actualInvoice = await Invoice.Create(Constant.InvoiceBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_Create_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<InvoiceParameter, InvoiceResponse>(HttpMethod.Post, Constant.CustomHeaders, Constant.InvoiceV2Url, null, null, Constant.InvoiceBody))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse actualInvoice = await Invoice.Create(Constant.InvoiceBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void Invoice_GetAll_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<InvoiceResponse[]>(HttpMethod.Get, null, Constant.InvoiceListUrl, null, null))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse[] actualInvoiceArray = await Invoice.GetAll(Constant.QueryParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }

        [Fact]
        public async void Invoice_GetAll_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<InvoiceResponse[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.InvoiceListUrl, null, null))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditConfiguration.RequestClient = MockClient.Object;

            InvoiceResponse[] actualInvoiceArray = await Invoice.GetAll(Constant.QueryParams, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }
    }
}
