namespace XenditCustomerObjectExample
{
    using System;
    using System.Collections.Generic; 
    using System.Text.Json;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Model.Customer;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    class ExampleUpdateCustomer
    {
        public async Task UpdateCustomer20200519() {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = System.Environment.GetEnvironmentVariable("XENDIT_API_KEY");
            Guid myUUId = Guid.NewGuid();
            string referenceId = myUUId.ToString();
            Console.WriteLine(referenceId);

            try
            {
                CustomerParameter individualParameterVersion20200519 = new CustomerParameter
                {
                    ReferenceId = referenceId,
                    Email = "john@email.com",
                    GivenNames = "John",
                    Addresses = new Address[] { new Address { Country = Country.Indonesia } }
                };

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                Console.WriteLine(JsonSerializer.Serialize(individualParameterVersion20200519, options));
                CustomerResponse individualCustomerVersion20200519 = await Customer.Create(individualParameterVersion20200519, version: ApiVersion.Version20200519);
                Console.WriteLine(JsonSerializer.Serialize(individualCustomerVersion20200519, options));

                CustomerParameter updatedIndividualParameterVersion20200519 = new CustomerParameter
                {
                    Email = "updated.john@email.com",
                    GivenNames = "Updated John",
                    Addresses = new Address[] { new Address { Country = Country.Indonesia } }
                };
                
                Console.WriteLine(JsonSerializer.Serialize(updatedIndividualParameterVersion20200519, options));
                CustomerResponse updatedIndividualCustomerVersion20200519 = await Customer.Update(updatedIndividualParameterVersion20200519, individualCustomerVersion20200519.Id, version: ApiVersion.Version20200519);
                Console.WriteLine(JsonSerializer.Serialize(updatedIndividualCustomerVersion20200519, options));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task UpdateCustomer20201031() {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = System.Environment.GetEnvironmentVariable("XENDIT_API_KEY");
            Guid myUUId = Guid.NewGuid();
            string referenceId = myUUId.ToString();
            Console.WriteLine(referenceId);

            try
            {
                string[] images = {
                    "text/png;24123123",
                    "text/png;24123125"
                };
                CustomerParameter individualParameter = new CustomerParameter
                {
                    ReferenceId = referenceId,
                    Type = CustomerType.Individual,
                    IndividualDetail = new IndividualDetail
                    {
                        GivenNames = "John Pantau",
                    },
                };

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                Console.WriteLine(JsonSerializer.Serialize(individualParameter, options));
                CustomerResponse individualCustomerVersion20201031 = await Customer.Create(individualParameter, version: ApiVersion.Version20201031);
                Console.WriteLine(JsonSerializer.Serialize(individualCustomerVersion20201031, options));

                CustomerParameter updatedIndividualParameter = new CustomerParameter
                {
                    IndividualDetail = new IndividualDetail
                    {
                        GivenNames = "Updated John Pantau",
                    },
                };

                Console.WriteLine(JsonSerializer.Serialize(updatedIndividualParameter, options));
                CustomerResponse updatedIndividualCustomerVersion20201031 = await Customer.Update(updatedIndividualParameter, individualCustomerVersion20201031.Id, version: ApiVersion.Version20201031);
                Console.WriteLine(JsonSerializer.Serialize(updatedIndividualCustomerVersion20201031, options));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    
}
