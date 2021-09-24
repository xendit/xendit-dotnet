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

    public class LinkedAccountTokenClientTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void InitializedLinkedAccount_Initialize_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InitializedLinkedAccountTokenParameter, InitializedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountAuthUrl, Constant.ApiKey, Constant.BaseUrl, Constant.InitializedLinkedAccountParameter, null))
                .ReturnsAsync(Constant.ExpectedInitializedLinkedAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InitializedLinkedAccountToken actualInitializedLinkedAccount = await client.LinkedAccountToken.Initialize(Constant.InitializedLinkedAccountParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInitializedLinkedAccount), JsonSerializer.Serialize(actualInitializedLinkedAccount));
        }

        [Fact]
        public async void InitializedLinkedAccount_Initialize_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<InitializedLinkedAccountTokenParameter, InitializedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountAuthUrl, Constant.ApiKey, Constant.BaseUrl, Constant.InitializedLinkedAccountParameter, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedInitializedLinkedAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            InitializedLinkedAccountToken actualInitializedLinkedAccount = await client.LinkedAccountToken.Initialize(Constant.InitializedLinkedAccountParameter, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInitializedLinkedAccount), JsonSerializer.Serialize(actualInitializedLinkedAccount));
        }

        [Fact]
        public async void ValidatedLinkedAccount_ValidateOtp_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<Dictionary<string, string>, ValidatedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountValidateUrl, Constant.ApiKey, Constant.BaseUrl, Constant.ValidatedLinkedAccountParameter, null))
                .ReturnsAsync(Constant.ExpectedValidatedLinkedAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            ValidatedLinkedAccountToken actualValidatedLinkedAccount = await client.LinkedAccountToken.ValidateOtp(Constant.OtpCode, Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedValidatedLinkedAccount), JsonSerializer.Serialize(actualValidatedLinkedAccount));
        }

        [Fact]
        public async void ValidatedLinkedAccount_ValidateOtp_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<Dictionary<string, string>, ValidatedLinkedAccountToken>(HttpMethod.Post, Constant.LinkedAccountValidateUrl, Constant.ApiKey, Constant.BaseUrl, Constant.ValidatedLinkedAccountParameter, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedValidatedLinkedAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            ValidatedLinkedAccountToken actualValidatedLinkedAccount = await client.LinkedAccountToken.ValidateOtp(Constant.OtpCode, Constant.LinkedAccountId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedValidatedLinkedAccount), JsonSerializer.Serialize(actualValidatedLinkedAccount));
        }

        [Fact]
        public async void AccessibleLinkedAccount_Get_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<AccessibleLinkedAccountToken[]>(HttpMethod.Get, Constant.LinkedAccountAccessibleUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedAccessibleLinkedAccounts);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            AccessibleLinkedAccountToken[] actualAccessibleLinkedAccounts = await client.LinkedAccountToken.Get(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAccessibleLinkedAccounts), JsonSerializer.Serialize(actualAccessibleLinkedAccounts));
        }

        [Fact]
        public async void AccessibleLinkedAccount_Get_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<AccessibleLinkedAccountToken[]>(HttpMethod.Get, Constant.LinkedAccountAccessibleUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedAccessibleLinkedAccounts);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            AccessibleLinkedAccountToken[] actualAccessibleLinkedAccounts = await client.LinkedAccountToken.Get(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAccessibleLinkedAccounts), JsonSerializer.Serialize(actualAccessibleLinkedAccounts));
        }

        [Fact]
        public async void UnbindedLinkedAccount_Unbind_ShouldSuccess()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<UnbindedLinkedAccountToken>(HttpMethod.Delete, Constant.LinkedAccountIdUrl, Constant.ApiKey, Constant.BaseUrl, null))
                .ReturnsAsync(Constant.ExpectedUnbindedLinkedAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            UnbindedLinkedAccountToken actualUnbindedLinkedAccount = await client.LinkedAccountToken.Unbind(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUnbindedLinkedAccount), JsonSerializer.Serialize(actualUnbindedLinkedAccount));
        }

        [Fact]
        public async void UnbindedLinkedAccount_Unbind_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(mockClient => mockClient.Request<UnbindedLinkedAccountToken>(HttpMethod.Delete, Constant.LinkedAccountIdUrl, Constant.ApiKey, Constant.BaseUrl, Constant.CustomHeaders))
                .ReturnsAsync(Constant.ExpectedUnbindedLinkedAccount);

            XenditClient client = new XenditClient(Constant.ApiKey, MockClient.Object, Constant.BaseUrl);

            UnbindedLinkedAccountToken actualUnbindedLinkedAccount = await client.LinkedAccountToken.Unbind(Constant.LinkedAccountId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUnbindedLinkedAccount), JsonSerializer.Serialize(actualUnbindedLinkedAccount));
        }
    }
}
