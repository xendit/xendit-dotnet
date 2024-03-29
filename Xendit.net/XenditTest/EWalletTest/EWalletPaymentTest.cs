﻿namespace XenditTest.EWalletTest
{
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model.EWallet;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class EWalletPaymentTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void EWalletPayment_Create_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<EWalletPaymentParameter, EWalletPaymentResponse>(HttpMethod.Post, Constant.EWalletPaymentUrl, null, null, Constant.EWalletPaymentParameter, Constant.PaymentApiVersionHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletPaymentResponse actualEWalletPayment = await EWalletPayment.Create(Constant.EWalletPaymentParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletPayment), JsonSerializer.Serialize(actualEWalletPayment));
        }

        [Fact]
        public async void EWalletPayment_Get_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<EWalletPaymentResponse>(HttpMethod.Get, Constant.GetEWalletPaymentUrl, null, null, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedEWalletPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            EWalletPaymentResponse actualEWalletPayment = await EWalletPayment.Get(Constant.ExternalId, Constant.PaymentType, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedEWalletPayment), JsonSerializer.Serialize(actualEWalletPayment));
        }
    }
}
