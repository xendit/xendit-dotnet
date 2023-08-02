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

    public class CustomerTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void Customer_ShouldSuccess_Create_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, null, null, Constant.CustomerBody, Constant.NewApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.Create(Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_CreateCustomParams_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, null, null, Constant.CustomerBody, Constant.NewApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.CreateCustomParams(Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Create_WithCustomHeaderAndDefaultVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, null, null, Constant.CustomerBody, Constant.NewApiVersionHeadersWithUserId))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.Create(Constant.CustomerBody, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_CreateCustomParams_WithCustomHeaderAndDefaultVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, null, null, Constant.CustomerBody, Constant.NewApiVersionHeadersWithUserId))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.CreateCustomParams(Constant.CustomerBody, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Create_WithVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, null, null, Constant.CustomerBody, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.Create(Constant.CustomerBody, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_CreateCustomParams_WithVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, Constant.CustomerUrl, null, null, Constant.CustomerBody, Constant.ApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.CreateCustomParams(Constant.CustomerBody, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Get_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerResponse>(HttpMethod.Get, Constant.CustomerIdUrl, null, null, Constant.NewApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.Get(Constant.ExpectedCustomerData.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Get_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<CustomerResponse>(HttpMethod.Get, Constant.CustomerIdUrl, null, null, Constant.NewApiVersionHeadersWithUserId))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.Get(Constant.ExpectedCustomerData.ReferenceId, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Get_WithVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerResponse[]>(HttpMethod.Get, Constant.CustomerIdUrl, null, null, Constant.ApiVersionHeaders))
                .ReturnsAsync(new CustomerResponse[] { Constant.ExpectedCustomerData });

            XenditConfiguration.RequestClient = MockClient.Object;

            CustomerResponse actualCustomer = await Customer.Get(Constant.ExpectedCustomerData.ReferenceId, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerOldApiVersion), JsonSerializer.Serialize(actualCustomer));
        }
    }
}
