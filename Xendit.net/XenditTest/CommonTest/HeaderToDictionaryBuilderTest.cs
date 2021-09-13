namespace XenditTest.CommonTest
{
    using System.Collections.Generic;
    using Xendit.net.Common;
    using Xendit.net.Enum;
    using Xendit.net.Struct;
    using Xunit;

    public class HeaderToDictionaryBuilderTest
    {
        [Fact]
        public void HeaderToDictionaryBuilder_Build()
        {
            HeaderParameter parameter = new HeaderParameter
            {
                ForUserId = "example-user-id",
                Idempotencykey = "example-idempotency-key",
                ApiVersion = ApiVersion.Version20200519,
            };

            Dictionary<string, string> expectedHeaders = new Dictionary<string, string>()
            {
                { "for-user-id", "example-user-id" },
                { "Idempotency-key",  "example-idempotency-key" },
                { "API-VERSION", "2020-05-19" },
            };

            Assert.Equal(expectedHeaders, HeaderToDictionaryBuilder.Build(parameter));
        }

        [Fact]
        public void HeaderToDictionaryBuilder_Build_EmptyDictionary()
        {
            HeaderParameter parameter = new HeaderParameter { };

            Dictionary<string, string> expectedHeaders = new Dictionary<string, string>() { };

            Assert.Equal(expectedHeaders, HeaderToDictionaryBuilder.Build(parameter));
        }

        [Fact]
        public void HeaderToDictionaryBuilder_Build_NullParameter()
        {
            Dictionary<string, string> expectedHeaders = new Dictionary<string, string>() { };

            Assert.Equal(expectedHeaders, HeaderToDictionaryBuilder.Build(null));
        }
    }
}
