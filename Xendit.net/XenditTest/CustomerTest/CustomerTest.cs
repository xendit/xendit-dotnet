namespace XenditTest.CustomerTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xunit;

    public class CustomerTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void Customer_ShouldSuccess_CreateDictionaryParameters()
        {
            MockClient
                .Setup(client => client.Request<Customer>(HttpMethod.Post, new Dictionary<string, string>(), Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomer);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomer), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_CreateDictionaryParameters_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Customer>(HttpMethod.Post, Constant.CustomHeaders, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomer);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.CustomHeaders, Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomer), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_CreateRequiredParams()
        {
            MockClient
                .Setup(client => client.Request<Customer>(HttpMethod.Post, Constant.ApiVersionHeaders, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomer);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.ExpectedCustomer.ReferenceId, Constant.ExpectedCustomer.GivenNames, Constant.ExpectedCustomer.MobileNumber, Constant.ExpectedCustomer.Email);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomer), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_CreateRequiredParams_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Customer>(HttpMethod.Post, Constant.CustomHeaders, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomer);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.UserIdHeaders, Constant.ExpectedCustomer.ReferenceId, Constant.ExpectedCustomer.GivenNames, Constant.ExpectedCustomer.MobileNumber, Constant.ExpectedCustomer.Email);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomer), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_GetByReferenceId()
        {
            MockClient
                .Setup(client => client.Request<Customer[]>(HttpMethod.Get, Constant.ApiVersionHeaders, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomers);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer[] actualCustomers = await Customer.GetByReferenceId(Constant.ExpectedCustomer.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomers), JsonSerializer.Serialize(actualCustomers));
        }

        [Fact]
        public async void Customer_ShouldSuccess_GetByReferenceId_WithHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "for-user-id", "user-id" },
            };

            MockClient
                .Setup(client => client.Request<Customer[]>(HttpMethod.Get, Constant.CustomHeaders, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomers);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer[] actualCustomers = await Customer.GetByReferenceId(headers, Constant.ExpectedCustomer.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomers), JsonSerializer.Serialize(actualCustomers));
        }

        [Fact]
        public async void Customer_ShouldSuccess_GetByReferenceIdNew()
        {
            MockClient
                .Setup(client => client.Request<Customer>(HttpMethod.Get, Constant.NewApiVersionHeaders, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.GetByReferenceIdNew(Constant.ExpectedCustomer.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_GetByReferenceIdNew_WithHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "for-user-id", "user-id" },
            };

            MockClient
                .Setup(client => client.Request<Customer>(HttpMethod.Get, Constant.NewApiVersionHeadersWithUserId, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.GetByReferenceIdNew(headers, Constant.ExpectedCustomer.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }
    }
}
