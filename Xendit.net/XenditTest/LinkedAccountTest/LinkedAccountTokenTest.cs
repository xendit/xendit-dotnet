namespace XenditTest.LinkedAccountTest
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using Moq;
    using Xendit.net;
    using Xendit.net.Model.LinkedAccountToken;
    using Xendit.net.Network;
    using Xendit.net.Struct;
    using Xunit;

    public class LinkedAccountTokenTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void InitializedLinkedAccount_Initialize_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<InitializedLinkedAccountTokenParameter, InitializedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountAuthUrl, null, null, Constant.InitializedLinkedAccountParameter, null))
                .ReturnsAsync(Constant.ExpectedInitializedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            InitializedLinkedAccountToken actualInitializedLinkedAccount = await LinkedAccountToken.Initialize(Constant.InitializedLinkedAccountParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInitializedLinkedAccount), JsonSerializer.Serialize(actualInitializedLinkedAccount));
        }

        [Fact]
        public async void InitializedLinkedAccount_Initialize_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<InitializedLinkedAccountTokenParameter, InitializedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountAuthUrl, null, null, Constant.InitializedLinkedAccountParameter, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedInitializedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            InitializedLinkedAccountToken actualInitializedLinkedAccount = await LinkedAccountToken.Initialize(Constant.InitializedLinkedAccountParameter, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInitializedLinkedAccount), JsonSerializer.Serialize(actualInitializedLinkedAccount));
        }

        [Fact]
        public async void ValidatedLinkedAccount_ValidateOtp_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, ValidatedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountValidateUrl, null, null, Constant.ValidatedLinkedAccountParameter, null))
                .ReturnsAsync(Constant.ExpectedValidatedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            ValidatedLinkedAccountToken actualValidatedLinkedAccount = await LinkedAccountToken.ValidateOtp(Constant.OtpCode, Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedValidatedLinkedAccount), JsonSerializer.Serialize(actualValidatedLinkedAccount));
        }

        [Fact]
        public async void ValidatedLinkedAccount_ValidateOtp_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, ValidatedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountValidateUrl, null, null, Constant.ValidatedLinkedAccountParameter, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedValidatedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            ValidatedLinkedAccountToken actualValidatedLinkedAccount = await LinkedAccountToken.ValidateOtp(Constant.OtpCode, Constant.LinkedAccountId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedValidatedLinkedAccount), JsonSerializer.Serialize(actualValidatedLinkedAccount));
        }

        [Fact]
        public async void AccessibleLinkedAccount_Get_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<AccessibleLinkedAccountToken[]>(HttpMethod.Get, Constant.LinkedAccountAccessibleUrl, null, null, null))
                .ReturnsAsync(Constant.ExpectedAccessibleLinkedAccounts);

            XenditConfiguration.RequestClient = MockClient.Object;

            AccessibleLinkedAccountToken[] actualAccessibleLinkedAccounts = await LinkedAccountToken.Get(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAccessibleLinkedAccounts), JsonSerializer.Serialize(actualAccessibleLinkedAccounts));
        }

        [Fact]
        public async void AccessibleLinkedAccount_Get_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<AccessibleLinkedAccountToken[]>(HttpMethod.Get, Constant.LinkedAccountAccessibleUrl, null, null, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedAccessibleLinkedAccounts);

            XenditConfiguration.RequestClient = MockClient.Object;

            AccessibleLinkedAccountToken[] actualAccessibleLinkedAccounts = await LinkedAccountToken.Get(Constant.LinkedAccountId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAccessibleLinkedAccounts), JsonSerializer.Serialize(actualAccessibleLinkedAccounts));
        }

        [Fact]
        public async void UnbindedLinkedAccount_Unbind_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<UnbindedLinkedAccountToken>(HttpMethod.Delete, Constant.LinkedAccountIdUrl, null, null, null))
                .ReturnsAsync(Constant.ExpectedUnbindedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            UnbindedLinkedAccountToken actualUnbindedLinkedAccount = await LinkedAccountToken.Unbind(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUnbindedLinkedAccount), JsonSerializer.Serialize(actualUnbindedLinkedAccount));
        }

        [Fact]
        public async void UnbindedLinkedAccount_Unbind_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<UnbindedLinkedAccountToken>(HttpMethod.Delete, Constant.LinkedAccountIdUrl, null, null, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedUnbindedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            UnbindedLinkedAccountToken actualUnbindedLinkedAccount = await LinkedAccountToken.Unbind(Constant.LinkedAccountId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUnbindedLinkedAccount), JsonSerializer.Serialize(actualUnbindedLinkedAccount));
        }
    }
}
