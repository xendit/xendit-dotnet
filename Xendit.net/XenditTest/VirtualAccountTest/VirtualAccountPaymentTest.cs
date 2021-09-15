namespace XenditTest.VirtualAccountTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xunit;

    public class VirtualAccountPaymentTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void VirtualAccountPayment_ShouldSuccess_GetVirtualAccountPayment()
        {
            MockClient
                .Setup(client => client.Request<VirtualAccountPayment>(HttpMethod.Get, null, Constant.VirtualAccountPaymentUrl))
                .ReturnsAsync(Constant.ExpectedVirtualAccountPayment);

            XenditConfiguration.RequestClient = MockClient.Object;

            VirtualAccountPayment actualVirtualAccountPayment = await VirtualAccountPayment.Get(Constant.PaymentId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccountPayment), JsonSerializer.Serialize(actualVirtualAccountPayment));
        }
    }
}
