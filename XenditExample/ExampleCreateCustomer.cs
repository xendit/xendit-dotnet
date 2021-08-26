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
                CustomerIndividualDetail individualDetail = new CustomerIndividualDetail
                {
                    GivenNames = "John",
                    Gender = CustomerGender.Male,
                };

                CustomerIdentityAccount identityAccount = new CustomerIdentityAccount
                {
                    Country = "ID",
                    Type = CustomerIdentityAccountType.BankAccount,
                    Properties = new CustomerIdentityAccountProperties { AccountNumber = "account_number" }
                };

                CustomerKycDocument document = new CustomerKycDocument
                {
                    Country = "ID",
                    Type = CustomerKycDocumentType.IdentityCard,
                    SubType = CustomerKycDocumentSubType.NationalId,
                };

                CustomerBody individualParameter = new CustomerBody
                {
                    ReferenceId = "demo_11212145",
                    Type = CustomerType.Individual,
                    IndividualDetail = individualDetail,
                    IdentityAccount = new CustomerIdentityAccount[] { identityAccount },
                    KycDocuments = new CustomerKycDocument[] { document },
                };

                Customer individualCustomerDefault = await Customer.Create(individualParameter);
                Console.WriteLine(individualCustomerDefault);

                CustomerBody individualParameterCustomVersion = new CustomerBody
                {
                    ReferenceId = "demo_11212144",
                    Email = "john@email.com",
                    GivenNames = "John",
                    Addresses = new CustomerAddress[] { new CustomerAddress { Country = "ID" } }
                };

                Customer individualCustomerCustomVersion = await Customer.Create(individualParameterCustomVersion, version: "2020-05-19");
                Console.WriteLine(individualCustomerCustomVersion);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
