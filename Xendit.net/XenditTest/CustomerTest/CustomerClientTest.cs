namespace XenditTest.CustomerTest
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Model.Customer;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class CustomerClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void CustomerClient_ShouldSuccess_Create_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody, Constant.NewApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Create(Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Create_WithCustomHeaderAndDefaultVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody, Constant.NewApiVersionHeadersWithUserId))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Create(Constant.CustomerBody, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Create_WithVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Create(Constant.CustomerBody, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Get_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerResponse>(HttpMethod.Get, Constant.CustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.NewApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Get(Constant.ExpectedCustomerData.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Get_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerResponse>(HttpMethod.Get, Constant.CustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.NewApiVersionHeadersWithUserId))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Get(Constant.ExpectedCustomerData.ReferenceId, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Get_WithVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerResponse[]>(HttpMethod.Get, Constant.CustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.ApiVersionHeaders))
                .ReturnsAsync(new CustomerResponse[] { Constant.ExpectedCustomerData });

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Get(Constant.ExpectedCustomerData.ReferenceId, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerOldApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Update_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(XenditHttpMethod.Patch, Constant.UpdatedCustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody, Constant.NewApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Update(Constant.CustomerBody, Constant.ExpectedCustomerData.Id);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Update_WithCustomHeaderAndDefaultVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(XenditHttpMethod.Patch, Constant.UpdatedCustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody, Constant.NewApiVersionHeadersWithUserId))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Update(Constant.CustomerBody, Constant.ExpectedCustomerData.Id, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Update_WithVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(XenditHttpMethod.Patch, Constant.UpdatedCustomerIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Update(Constant.CustomerBody, Constant.ExpectedCustomerData.Id, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }
    }
}
