namespace XenditTest.LinkedAccountTest
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

    public class LinkedAccountTest
    {
        private static readonly Mock<INetworkClient> MockClient = new Mock<INetworkClient>();

        [Fact]
        public async void InitializedLinkedAccount_Initialize_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<InitializedLinkedAccountParameter, InitializedLinkedAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.LinkedAccountAuthUrl, Constant.InitializedLinkedAccountParameter))
                .ReturnsAsync(Constant.ExpectedInitializedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            InitializedLinkedAccount actualInitializedLinkedAccount = await InitializedLinkedAccount.Initialize(Constant.InitializedLinkedAccountParameter);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInitializedLinkedAccount), JsonSerializer.Serialize(actualInitializedLinkedAccount));
        }

        [Fact]
        public async void InitializedLinkedAccount_Initialize_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<InitializedLinkedAccountParameter, InitializedLinkedAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.LinkedAccountAuthUrl, Constant.InitializedLinkedAccountParameter))
                .ReturnsAsync(Constant.ExpectedInitializedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            InitializedLinkedAccount actualInitializedLinkedAccount = await InitializedLinkedAccount.Initialize(Constant.InitializedLinkedAccountParameter, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedInitializedLinkedAccount), JsonSerializer.Serialize(actualInitializedLinkedAccount));
        }

        [Fact]
        public async void ValidatedLinkedAccount_ValidateOTP_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<ValidatedLinkedAccountParameter, ValidatedLinkedAccount>(HttpMethod.Post, new Dictionary<string, string>(), Constant.LinkedAccountValidateUrl, Constant.ValidatedLinkedAccountParameter))
                .ReturnsAsync(Constant.ExpectedValidatedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            ValidatedLinkedAccount actualValidatedLinkedAccount = await ValidatedLinkedAccount.ValidateOTP(Constant.ValidatedLinkedAccountParameter, Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedValidatedLinkedAccount), JsonSerializer.Serialize(actualValidatedLinkedAccount));
        }

        [Fact]
        public async void ValidatedLinkedAccount_ValidateOTP_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<ValidatedLinkedAccountParameter, ValidatedLinkedAccount>(HttpMethod.Post, Constant.CustomHeaders, Constant.LinkedAccountValidateUrl, Constant.ValidatedLinkedAccountParameter))
                .ReturnsAsync(Constant.ExpectedValidatedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            ValidatedLinkedAccount actualValidatedLinkedAccount = await ValidatedLinkedAccount.ValidateOTP(Constant.ValidatedLinkedAccountParameter, Constant.LinkedAccountId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedValidatedLinkedAccount), JsonSerializer.Serialize(actualValidatedLinkedAccount));
        }

        [Fact]
        public async void AccessibleLinkedAccount_Get_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, AccessibleLinkedAccount[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.LinkedAccountAccessibleUrl, null))
                .ReturnsAsync(Constant.ExpectedAccessibleLinkedAccounts);

            XenditConfiguration.RequestClient = MockClient.Object;

            AccessibleLinkedAccount[] actualAccessibleLinkedAccounts = await AccessibleLinkedAccount.Get(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAccessibleLinkedAccounts), JsonSerializer.Serialize(actualAccessibleLinkedAccounts));
        }

        [Fact]
        public async void AccessibleLinkedAccount_Get_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, AccessibleLinkedAccount[]>(HttpMethod.Get, new Dictionary<string, string>(), Constant.LinkedAccountAccessibleUrl, null))
                .ReturnsAsync(Constant.ExpectedAccessibleLinkedAccounts);

            XenditConfiguration.RequestClient = MockClient.Object;

            AccessibleLinkedAccount[] actualAccessibleLinkedAccounts = await AccessibleLinkedAccount.Get(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedAccessibleLinkedAccounts), JsonSerializer.Serialize(actualAccessibleLinkedAccounts));
        }

        [Fact]
        public async void UnbindedLinkedAccount_Unbind_ShouldSuccess()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, UnbindedLinkedAccount>(HttpMethod.Delete, new Dictionary<string, string>(), Constant.LinkedAccountIdUrl, null))
                .ReturnsAsync(Constant.ExpectedUnbindedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            UnbindedLinkedAccount actualUnbindedLinkedAccount = await UnbindedLinkedAccount.Unbind(Constant.LinkedAccountId);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUnbindedLinkedAccount), JsonSerializer.Serialize(actualUnbindedLinkedAccount));
        }

        [Fact]
        public async void UnbindedLinkedAccount_Unbind_ShouldSuccess_WithHeaders()
        {
            MockClient
                .Setup(client => client.Request<Dictionary<string, string>, UnbindedLinkedAccount>(HttpMethod.Delete, Constant.CustomHeaders, Constant.LinkedAccountIdUrl, null))
                .ReturnsAsync(Constant.ExpectedUnbindedLinkedAccount);

            XenditConfiguration.RequestClient = MockClient.Object;

            UnbindedLinkedAccount actualUnbindedLinkedAccount = await UnbindedLinkedAccount.Unbind(Constant.LinkedAccountId, Constant.CustomHeaders);
            Assert.Equal(JsonSerializer.Serialize(Constant.ExpectedUnbindedLinkedAccount), JsonSerializer.Serialize(actualUnbindedLinkedAccount));
        }
    }
}
