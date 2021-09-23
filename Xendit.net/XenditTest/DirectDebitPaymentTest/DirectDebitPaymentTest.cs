namespace XenditTest.DirectDebitPaymentTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model.DirectDebit;
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
                .Setup(client => client.Request<DirectDebitPaymentParameter, DirectDebitPaymentResponse>(HttpMethod.Post, Constant.Headers, Constant.DirectDebitUrl, null, null, Constant.DirectDebitPaymentParameter))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPaymentResponse actualDirectDebitPayment = await DirectDebitPayment.Create(Constant.DirectDebitPaymentParameter, Constant.IdempotencyKey);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_Create_ShouldSuccess_WithCustomHeader()
        {
            MockClient
                .Setup(client => client.Request<DirectDebitPaymentParameter, DirectDebitPaymentResponse>(HttpMethod.Post, Constant.HeadersWithUserId, Constant.DirectDebitUrl, null, null, Constant.DirectDebitPaymentParameter))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPaymentResponse actualDirectDebitPayment = await DirectDebitPayment.Create(Constant.DirectDebitPaymentParameter, Constant.IdempotencyKey, Constant.InitialHeadersWithUserId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_ValidateOtp_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, DirectDebitPaymentResponse>(HttpMethod.Post, null, Constant.DirectDebitUrlValidateOTP, null, null, Constant.ValidateDirectDebitPaymentParameter))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPaymentResponse actualDirectDebitPayment = await DirectDebitPayment.ValidateOtp(Constant.OtpCode, Constant.DirectDebitId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_GetById_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<DirectDebitPaymentResponse>(HttpMethod.Get, null, Constant.DirectDebitUrlGetById, null, null))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPaymentResponse actualDirectDebitPayment = await DirectDebitPayment.GetById(Constant.DirectDebitId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPayment_GetByReferenceId_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<DirectDebitPaymentResponse[]>(HttpMethod.Get, null, Constant.DirectDebitUrlGetByReferenceId, null, null))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayments);

            XenditConfiguration.RequestClient = MockClient.Object;

            DirectDebitPaymentResponse[] actualDirectDebitPayments = await DirectDebitPayment.GetByReferenceId(Constant.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayments), JsonSerializer.Serialize(actualDirectDebitPayments));
        }
    }
}
