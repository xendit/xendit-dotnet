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

    public class InvoiceClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void InvoiceClientTest_GetById_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InvoiceResponse>(HttpMethod.Get, Constant.InvoiceByIdUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse actualInvoice = await client.Invoice.GetById(Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void InvoiceClientTest_GetById_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InvoiceResponse>(HttpMethod.Get, Constant.InvoiceByIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse actualInvoice = await client.Invoice.GetById(Constant.InvoiceId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void InvoiceClientTest_Expire_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<Dictionary<string, string>, InvoiceResponse>(HttpMethod.Post, Constant.InvoiceExpireUrl, Constant.ApiKey, Constant.BaseUrl, new Dictionary<string, string>(), null))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse actualInvoice = await client.Invoice.Expire(Constant.InvoiceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void InvoiceClientTest_Expire_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<Dictionary<string, string>, InvoiceResponse>(HttpMethod.Post, Constant.InvoiceExpireUrl, Constant.ApiKey, Constant.BaseUrl, new Dictionary<string, string>(), Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse actualInvoice = await client.Invoice.Expire(Constant.InvoiceId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void InvoiceClientTest_Create_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InvoiceParameter, InvoiceResponse>(HttpMethod.Post, Constant.InvoiceV2Url, Constant.ApiKey, Constant.BaseUrl, Constant.InvoiceBody, null))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse actualInvoice = await client.Invoice.Create(Constant.InvoiceBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void InvoiceClientTest_Create_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InvoiceParameter, InvoiceResponse>(HttpMethod.Post, Constant.InvoiceV2Url, Constant.ApiKey, Constant.BaseUrl, Constant.InvoiceBody, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedInvoice);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse actualInvoice = await client.Invoice.Create(Constant.InvoiceBody, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoice), JsonSerializer.Serialize(actualInvoice));
        }

        [Fact]
        public async void InvoiceClientTest_GetAll_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InvoiceResponse[]>(HttpMethod.Get, Constant.InvoiceListUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse[] actualInvoiceArray = await client.Invoice.GetAll(Constant.QueryParams);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }

        [Fact]
        public async void InvoiceClientTest_GetAll_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InvoiceResponse[]>(HttpMethod.Get, Constant.InvoiceListUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedInvoiceArray);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InvoiceResponse[] actualInvoiceArray = await client.Invoice.GetAll(Constant.QueryParams, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInvoiceArray), JsonSerializer.Serialize(actualInvoiceArray));
        }
    }
}
