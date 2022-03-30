namespace XenditTest.RetailOutletTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model.RetailOutlet;
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
                .Setup(client => client.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, Constant.RetailOutletUrl, null, null, Constant.CreateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.CreatePaymentCode(Constant.CreateFixedPaymentCodeParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_CreateWithOtherThanPhilippines_ThrowsParamException()
        {
            MockClient
                .Setup(client => client.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, Constant.RetailOutletUrl, null, null, Constant.InvalidCreateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            ParamException exception = await Assert.ThrowsAsync<ParamException>(async () => await RetailOutlet.CreatePaymentCode(Constant.InvalidCreateFixedPaymentCodeParameter));
            Assert.Equal("Create Payment Code can only accept Currency.PHP and Country.Philippines", exception.Message);
        }

        [Fact]
        public async void RetailOutlet_CreateWithHeader_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, Constant.RetailOutletUrl, null, null, Constant.CreateFixedPaymentCodeParameter, Constant.Headers))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.CreatePaymentCode(Constant.CreateFixedPaymentCodeParameter, Constant.Headers);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_Update_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<UpdateFixedPaymentCodeParameter, FixedPaymentCode>(XenditHttpMethod.Patch, Constant.PaymentCodeIdUrl, null, null, Constant.UpdateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.UpdatePaymentCode(Constant.UpdateFixedPaymentCodeParameter, Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_UpdateWithOtherThanPhilippinesCurrency_ThrowsParamException()
        {
            MockClient
                .Setup(client => client.Request<UpdateFixedPaymentCodeParameter, FixedPaymentCode>(XenditHttpMethod.Patch, Constant.PaymentCodeIdUrl, null, null, Constant.UpdateFixedPaymentCodeParameter, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            ParamException exception = await Assert.ThrowsAsync<ParamException>(async () => await RetailOutlet.UpdatePaymentCode(Constant.InvalidUpdateFixedPaymentCodeParameter, Constant.PaymentCodeId));
            Assert.Equal("Update Payment Code can only accept Currency.PHP", exception.Message);
        }

        [Fact]
        public async void RetailOutlet_GetPaymentCode_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<FixedPaymentCode>(HttpMethod.Get, Constant.PaymentCodeIdUrl, null, null, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCode);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode actualFixedPaymentCode = await RetailOutlet.GetPaymentCode(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCode), JsonSerializer.Serialize(actualFixedPaymentCode));
        }

        [Fact]
        public async void RetailOutlet_GetPayments_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<FixedPaymentCode[]>(HttpMethod.Get, Constant.GetPaymentsUrl, null, null, null))
                .ReturnsAsync(Constant.ExpectedFixedPaymentCodes);

            XenditConfiguration.RequestClient = MockClient.Object;

            FixedPaymentCode[] actualFixedPaymentCodes = await RetailOutlet.GetPayments(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedFixedPaymentCodes), JsonSerializer.Serialize(actualFixedPaymentCodes));
        }

        [Fact]
        public async void RetailOutlet_GetPaymentsByFixedPaymentCode_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<PaymentsResponse>(HttpMethod.Get, Constant.GetPaymentsByFixedPaymentCodeUrl, null, null, null))
                .ReturnsAsync(Constant.ExpectedPaymentsResponse);

            XenditConfiguration.RequestClient = MockClient.Object;

            PaymentsResponse actualPaymentsResponse = await RetailOutlet.GetPaymentsByFixedPaymentCode(Constant.PaymentCodeId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedPaymentsResponse), JsonSerializer.Serialize(actualPaymentsResponse));
        }
    }
}
