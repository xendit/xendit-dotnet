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
                .Setup(client => client.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, new Dictionary<string, string>(), Constant.RetailOutletUrl, Constant.CreateFixedPaymentCodeParameter))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.CreatePaymentCode(Constant.CreateFixedPaymentCodeParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_CreateWithHeader_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, Constant.Headers, Constant.RetailOutletUrl, Constant.CreateFixedPaymentCodeParameter))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.CreatePaymentCode(Constant.CreateFixedPaymentCodeParameter, Constant.Headers);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_Update_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<UpdateFixedPaymentCodeParameter, FixedPaymentCode>(XenditHttpMethod.Patch, new Dictionary<string, string>(), Constant.PaymentCodeIdUrl, Constant.UpdateFixedPaymentCodeParameter))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.UpdatePaymentCode(Constant.UpdateFixedPaymentCodeParameter, Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_GetPaymentCode_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, FixedPaymentCode>(HttpMethod.Get, new Dictionary<string, string>(), Constant.PaymentCodeIdUrl, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.GetPaymentCode(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_GetPayments_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, FixedPaymentCode[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.GetPaymentsUrl, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCodes);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode[] actualFixedPaymentCodes = await RetailOutlet.GetPayments(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCodes), JsonSerializer.Serialize(actualFixedPaymentCodes));
        }
    }
}
