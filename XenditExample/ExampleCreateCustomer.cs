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
                CustomerParameter individualParameterVersion20200519 = new CustomerParameter
                {
                    ReferenceId = "demo_11212162",
                    Email = "john@email.com",
                    GivenNames = "John",
                    Addresses = new Address[] { new Address { Country = Country.Indonesia } }
                };

                Customer individualCustomerVersion20200519 = await Customer.Create(individualParameterVersion20200519, version: ApiVersion.Version20200519);
                Console.WriteLine(individualCustomerVersion20200519);

                CustomerParameter individualParameter = new CustomerParameter
                {
                    ReferenceId = "demo_11212163",
                    Type = CustomerType.Individual,
                    IndividualDetail = new IndividualDetail
                    {
                        GivenNames = "John",
                        Gender = CustomerGender.Male,
                    },
                    IdentityAccount = new IdentityAccount[]
                    {
                        new IdentityAccount
                        {
                            Country = Country.Indonesia,
                            Type = CustomerIdentityAccountType.BankAccount,
                            Properties = new IdentityAccountProperties { AccountNumber = "account_number" }
                        }
                    },
                    KycDocuments = new KycDocument[]
                    {
                        new KycDocument
                        {
                            Country = Country.Indonesia,
                            Type = CustomerKycDocumentType.IdentityCard,
                            SubType = CustomerKycDocumentSubType.NationalId,
                        }
                    },
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
