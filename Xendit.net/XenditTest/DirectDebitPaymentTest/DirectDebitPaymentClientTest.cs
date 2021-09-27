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

    public class DirectDebitPaymentClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void DirectDebitPaymentClient_Create_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DirectDebitPaymentParameter, DirectDebitPaymentResponse>(HttpMethod.Post, Constant.DirectDebitUrl, Constant.ApiKey, Constant.BaseUrl, Constant.DirectDebitPaymentParameter, Constant.Headers))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DirectDebitPaymentResponse actualDirectDebitPayment = await client.DirectDebitPayment.Create(Constant.DirectDebitPaymentParameter, Constant.IdempotencyKey);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPaymentClient_Create_ShouldSuccess_WithCustomHeader()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DirectDebitPaymentParameter, DirectDebitPaymentResponse>(HttpMethod.Post, Constant.DirectDebitUrl, Constant.ApiKey, Constant.BaseUrl, Constant.DirectDebitPaymentParameter, Constant.HeadersWithUserId))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DirectDebitPaymentResponse actualDirectDebitPayment = await client.DirectDebitPayment.Create(Constant.DirectDebitPaymentParameter, Constant.IdempotencyKey, Constant.InitialHeadersWithUserId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPaymentClient_ValidateOtp_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<Dictionary<string, string>, DirectDebitPaymentResponse>(HttpMethod.Post, Constant.DirectDebitUrlValidateOTP, Constant.ApiKey, Constant.BaseUrl, Constant.ValidateDirectDebitPaymentParameter, null))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DirectDebitPaymentResponse actualDirectDebitPayment = await client.DirectDebitPayment.ValidateOtp(Constant.OtpCode, Constant.DirectDebitId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPaymentClient_GetById_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DirectDebitPaymentResponse>(HttpMethod.Get, Constant.DirectDebitUrlGetById, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayment);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DirectDebitPaymentResponse actualDirectDebitPayment = await client.DirectDebitPayment.GetById(Constant.DirectDebitId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayment), JsonSerializer.Serialize(actualDirectDebitPayment));
        }

        [Fact]
        public async void DirectDebitPaymentClient_GetByReferenceId_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<DirectDebitPaymentResponse[]>(HttpMethod.Get, Constant.DirectDebitUrlGetByReferenceId, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedDirectDebitPayments);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            DirectDebitPaymentResponse[] actualDirectDebitPayments = await client.DirectDebitPayment.GetByReferenceId(Constant.ReferenceId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedDirectDebitPayments), JsonSerializer.Serialize(actualDirectDebitPayments));
        }
    }
}
