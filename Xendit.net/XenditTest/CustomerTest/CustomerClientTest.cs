namespace XenditTest.CustomerTest
{
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
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.NewApiVersionHeaders, Constant.CustomerUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Create(Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Create_WithCustomHeaderAndDefaultVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.NewApiVersionHeadersWithUserId, Constant.CustomerUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Create(Constant.CustomerBody, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Create_WithVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.ApiVersionHeaders, Constant.CustomerUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Create(Constant.CustomerBody, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Get_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerResponse>(HttpMethod.Get, Constant.NewApiVersionHeaders, Constant.CustomerIdUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Get(Constant.ExpectedCustomerData.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Get_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerResponse>(HttpMethod.Get, Constant.NewApiVersionHeadersWithUserId, Constant.CustomerIdUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Get(Constant.ExpectedCustomerData.ReferenceId, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void CustomerClient_ShouldSuccess_Get_WithVersion()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<CustomerResponse[]>(HttpMethod.Get, Constant.ApiVersionHeaders, Constant.CustomerIdUrl, Constant.ApiKey, Constant.BaseUrl))
                .ReturnsAsync(new CustomerResponse[] { Constant.ExpectedCustomerData });

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            CustomerResponse actualCustomer = await client.Customer.Get(Constant.ExpectedCustomerData.ReferenceId, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerOldApiVersion), JsonSerializer.Serialize(actualCustomer));
        }
    }
}
