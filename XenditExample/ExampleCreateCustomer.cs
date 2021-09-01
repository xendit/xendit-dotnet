namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Exception;
    using Xendit.net.Struct;
    using Xendit.net.Enum;

    class ExampleCreateCustomer
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                CustomerParameter individualParameterCustomVersion = new CustomerParameter
                {
                    ReferenceId = "demo_11212157",
                    Email = "john@email.com",
                    GivenNames = "John",
                    Addresses = new Address[] { new Address { Country = "ID" } }
                };

                Customer individualCustomerVersion20200519 = await Customer.Create(individualParameterCustomVersion, version: ApiVersion.Version20200519);
                Console.WriteLine(individualCustomerVersion20200519);

                IndividualDetail individualDetail = new IndividualDetail
                {
                    GivenNames = "John",
                    Gender = CustomerGender.Male,
                };

                IdentityAccount identityAccount = new IdentityAccount
                {
                    Country = "ID",
                    Type = CustomerIdentityAccountType.BankAccount,
                    Properties = new IdentityAccountProperties { AccountNumber = "account_number" }
                };

                KycDocument document = new KycDocument
                {
                    Country = "ID",
                    Type = CustomerKycDocumentType.IdentityCard,
                    SubType = CustomerKycDocumentSubType.NationalId,
                };

                CustomerParameter individualParameter = new CustomerParameter
                {
                    ReferenceId = "demo_11212158",
                    Type = CustomerType.Individual,
                    IndividualDetail = individualDetail,
                    IdentityAccount = new IdentityAccount[] { identityAccount },
                    KycDocuments = new KycDocument[] { document },
                };

                Customer individualCustomerVersion20201031 = await Customer.Create(individualParameter);
                Console.WriteLine(individualCustomerVersion20201031);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
