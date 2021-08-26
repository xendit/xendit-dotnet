namespace XenditTest.CustomerTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
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
                .Setup(client => client.Request<CustomerBody, Customer>(HttpMethod.Post, Constant.NewApiVersionHeaders, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerData);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.CustomerBody);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerData), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_CreateDictionaryParameters_WithCustomHeadersAndDefaultVersion()
        {
            MockClient
                .Setup(client => client.Request<CustomerBody, Customer>(HttpMethod.Post, Constant.CustomHeaders, Constant.CustomerUrl, Constant.CustomerBody))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.Create(Constant.CustomerBody, Constant.UserIdHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_GetByReferenceId()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, Customer>(HttpMethod.Get, Constant.NewApiVersionHeaders, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.GetByReferenceId(Constant.ExpectedCustomerData.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }

        [Fact]
        public async void Customer_ShouldSuccess_GetByReferenceId_WithHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "for-user-id", "user-id" },
            };

            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, Customer>(HttpMethod.Get, Constant.CustomHeaders, Constant.CustomerIdUrl, null))
                .ReturnsAsync(Constant.ExpectedCustomerNewApiVersion);

            XenditConfiguration.RequestClient = MockClient.Object;

            Customer actualCustomer = await Customer.GetByReferenceId(Constant.ExpectedCustomerData.ReferenceId, headers);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedCustomerNewApiVersion), JsonSerializer.Serialize(actualCustomer));
        }
    }
}
