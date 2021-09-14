namespace XenditTest.CustomerTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Model;
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
                .Setup(client => client.Request<CustomerParameter, Customer>(HttpMethod.Post, Constant.NewApiVersionHeaders, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Create_WithCustomHeaderAndDefaultVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, Customer>(HttpMethod.Post, Constant.NewApiVersionHeadersWithUserId, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.CustomerBody, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Create_WithVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerParameter, Customer>(HttpMethod.Post, Constant.ApiVersionHeaders, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.CustomerBody, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Get_WithDefaultHeaderAndVersion()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, Customer>(HttpMethod.Get, Constant.NewApiVersionHeaders, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Get(Constant.ExpectedCustomerData.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Get_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, Customer>(HttpMethod.Get, Constant.NewApiVersionHeadersWithUserId, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Get(Constant.ExpectedCustomerData.ReferenceId, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_Get_WithVersion()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, Customer[]>(HttpMethod.Get, Constant.ApiVersionHeaders, Constant.CustomerIdUrl, null))
                .ReturnsAsync(new Customer[] { Constant.ExpectedCustomerData });

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Get(Constant.ExpectedCustomerData.ReferenceId, version: ApiVersion.Version20200519);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerOldApiVersion), JsonSerializer.Serialize(actualCustomer));
        }
    }
}
