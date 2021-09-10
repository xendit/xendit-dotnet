namespace XenditTest.DirectDebitPaymentTest
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

    public class DirectDebitPaymentTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void DirectDebitPayment_Create_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<DirectDebitPaymentParameter, DirectDebitPayment>(HttpMethod.Post, Constant.Headers, Constant.DirectDebitUrl, Constant.DirectDebitPaymentParameter))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPayment actualDirectDebitPayment = await DirectDebitPayment.Create(Constant.DirectDebitPaymentParameter, Constant.IdempotencyKey);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_Create_ShouldSuccess_WithCustomHeader()
        {
            MockClient
                .Setup(client => client.Request<DirectDebitPaymentParameter, DirectDebitPayment>(HttpMethod.Post, Constant.HeadersWithUserId, Constant.DirectDebitUrl, Constant.DirectDebitPaymentParameter))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPayment actualDirectDebitPayment = await DirectDebitPayment.Create(Constant.DirectDebitPaymentParameter, Constant.IdempotencyKey, Constant.InitialHeadersWithUserId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_ValidateOTP_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<ValidateDirectDebitPaymentParameter, DirectDebitPayment>(HttpMethod.Post, new Dictionary<string, string>(), Constant.DirectDebitUrlValidateOTP, Constant.ValidateDirectDebitPaymentParameter))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPayment actualDirectDebitPayment = await DirectDebitPayment.ValidateOTP(Constant.ValidateDirectDebitPaymentParameter, Constant.DirectDebitId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_GetById_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<DirectDebitPayment>(HttpMethod.Get, new Dictionary<string, string>(), Constant.DirectDebitUrlGetById))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPayment actualDirectDebitPayment = await DirectDebitPayment.GetById(Constant.DirectDebitId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_GetByReferenceId_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<DirectDebitPayment[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.DirectDebitUrlGetByReferenceId))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayments);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPayment[] actualDirectDebitPayments = await DirectDebitPayment.GetByReferenceId(Constant.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayments), JsonSerializer.Serialize(actualDirectDebitPayments));
        }
    }
}
