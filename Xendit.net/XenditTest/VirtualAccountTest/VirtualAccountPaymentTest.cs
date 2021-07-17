using System.Collections.Generic;
using Xunit;
using Moq;
using Xendit.net;
using Xendit.net.Network;
using Xendit.net.Model;
using System.Text.Json;
using System.Net.Http;

namespace XenditTest.VirtualAccountTest
{
    public class VirtualAccountPaymentTest
    {
        private readonly Mock<INetworkClient> mockClient = new Mock<INetworkClient>();

        [Fact]
        public async void VirtualAccountPayment_ShouldSuccess_GetVirtualAccountPayment()
        {
            mockClient
                .Setup(client => client.Request<VirtualAccountPayment>(HttpMethod.Get, new Dictionary<string, string>(), Constant.VirtualAccountPaymentUrl, null))
                .ReturnsAsync(Constant.ExpectedVirtualAccountPayment);

            XenditConfiguration.RequestClient = mockClient.Object;

            VirtualAccountPayment actualVirtualAccountPayment = await VirtualAccountPayment.Get(Constant.PaymentId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedVirtualAccountPayment), JsonSerializer.Serialize(actualVirtualAccountPayment));
        }
    }
}
