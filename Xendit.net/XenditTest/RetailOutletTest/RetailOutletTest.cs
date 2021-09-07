namespace XenditTest.RetailOutletTest
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

    public class RetailOutletTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void RetailOutlet_Create_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<CreateRetailOutletParameter, RetailOutlet>(HttpMethod.Post, new Dictionary<string, string>(), Constant.RetailOutletUrl, Constant.CreateRetailOutletParameter))
                .ReturnsAsync(Constant.ExpectedRetailOutlet);

            XenditConfiguration.RequestClient = MockClient.Object;

            RetailOutlet actualRetailOutlet = await RetailOutlet.Create(Constant.CreateRetailOutletParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedRetailOutlet), JsonSerializer.Serialize(actualRetailOutlet));
        }

        [Fact]
        public async void RetailOutlet_CreateWithHeader_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<CreateRetailOutletParameter, RetailOutlet>(HttpMethod.Post, Constant.Headers, Constant.RetailOutletUrl, Constant.CreateRetailOutletParameter))
                .ReturnsAsync(Constant.ExpectedRetailOutlet);

            XenditConfiguration.RequestClient = MockClient.Object;

            RetailOutlet actualRetailOutlet = await RetailOutlet.Create(Constant.CreateRetailOutletParameter, Constant.Headers);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedRetailOutlet), JsonSerializer.Serialize(actualRetailOutlet));
        }

        [Fact]
        public async void RetailOutlet_Update_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<UpdateRetailOutletParameter, RetailOutlet>(XenditHttpMethod.Patch, new Dictionary<string, string>(), Constant.PaymentCodeIdUrl, Constant.UpdateRetailOutletParameter))
                .ReturnsAsync(Constant.ExpectedRetailOutlet);

            XenditConfiguration.RequestClient = MockClient.Object;

            RetailOutlet actualRetailOutlet = await RetailOutlet.Update(Constant.UpdateRetailOutletParameter, Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedRetailOutlet), JsonSerializer.Serialize(actualRetailOutlet));
        }

        [Fact]
        public async void RetailOutlet_GetPaymentCode_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, RetailOutlet>(HttpMethod.Get, new Dictionary<string, string>(), Constant.PaymentCodeIdUrl, null))
                .ReturnsAsync(Constant.ExpectedRetailOutlet);

            XenditConfiguration.RequestClient = MockClient.Object;

            RetailOutlet actualRetailOutlet = await RetailOutlet.GetPaymentCode(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedRetailOutlet), JsonSerializer.Serialize(actualRetailOutlet));
        }

        [Fact]
        public async void RetailOutlet_GetPayments_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, RetailOutlet[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.GetPaymentsUrl, null))
                .ReturnsAsync(Constant.ExpectedRetailOutlets);

            XenditConfiguration.RequestClient = MockClient.Object;

            RetailOutlet[] actualRetailOutlet = await RetailOutlet.GetPayments(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedRetailOutlets), JsonSerializer.Serialize(actualRetailOutlet));
        }
    }
}
