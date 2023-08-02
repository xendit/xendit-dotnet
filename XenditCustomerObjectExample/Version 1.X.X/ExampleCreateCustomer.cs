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

    class ExampleCreateCustomer
    {
        public async Task CreateCustomer20200519() {
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
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task CreateCustomer20201031WithIndividualDetail() {
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
                        GivenNames = "John",
                        Surname = "Pantau",
                        Gender = CustomerGender.Male,
                        Nationality = "ID",
                        PlaceOfBirth = "Jakarta",
                        DateOfBirth = "1900-01-01",
                        Employment = new Employment
                        {
                            EmployerName = "PT Murah",
                            NatureOfBusiness = "Retail",
                            RoleDescription = "Staff"
                        }
                    },
                    MobileNumber = "+628123456789",
                    Email = "john@test.com",
                    PhoneNumber = "+6221872772",
                    Addresses = new Address[] 
                    { 
                        new Address
                        {
                                Country = Country.Indonesia,
                                StreetLine1 = "Jalan Mujair No 5",
                                StreetLine2 = "Kelurahan Kramat",
                                City = "Jakarta",
                                ProvinceState = "-",
                                PostalCode = "100001",
                                Category = CustomerAddressCategory.Home,
                                IsPrimary = true
                        },
                        new Address
                        {
                                Country = Country.Indonesia,
                                StreetLine1 = "Jalan Koi No 1",
                                StreetLine2 = "Kelurahan Kramat",
                                City = "Jakarta",
                                ProvinceState = "-",
                                PostalCode = "100001",
                                Category = CustomerAddressCategory.Work,
                                IsPrimary = false
                        }
                    },
                    IdentityAccount = new IdentityAccount[]
                    {
                        new IdentityAccount
                        {
                            Country = Country.Indonesia,
                            Type = CustomerIdentityAccountType.BankAccount,
                            Company = "PT Murah",
                            Description = "No Description",
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
                            DocumentName = "KTP - John",
                            DocumentNumber = "JH652211",
                            ExpiresAt = "2050-12-31",
                            HolderName = "John Pantau",
                            DocumentImages = images
                        }
                    },
                    Metadata =  new Dictionary<string, string>()
                    {
                        {
                            "x", "y"
                        },
                    }
                };

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                Console.WriteLine(JsonSerializer.Serialize(individualParameter, options));
                CustomerResponse individualCustomerVersion20201031 = await Customer.Create(individualParameter, version: ApiVersion.Version20201031);
                Console.WriteLine(JsonSerializer.Serialize(individualCustomerVersion20201031, options));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task CreateCustomer20201031WithBusinessDetail() {
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
                CustomerParameter businessParameter = new CustomerParameter
                {
                    ReferenceId = referenceId,
                    Type = CustomerType.Business,
                    BusinessDetail = new BusinessDetail
                    {
                        BusinessName = "PT Jakarta",
                        BusinessType = CustomerBusinessType.Corporation,
                        NatureOfBusiness = "Travel",
                        BusinessDomicile = "ID",
                        DateOfRegistration = "2050-12-31",

                    },
                    MobileNumber = "+628123456789",
                    Email = "john@test.com",
                    PhoneNumber = "+6221872772",
                    Addresses = new Address[] 
                    { 
                        new Address
                        {
                                Country = Country.Indonesia,
                                StreetLine1 = "Jalan Mujair No 5",
                                StreetLine2 = "Kelurahan Kramat",
                                City = "Jakarta",
                                ProvinceState = "-",
                                PostalCode = "100001",
                                Category = CustomerAddressCategory.Home,
                                IsPrimary = true
                        },
                        new Address
                        {
                                Country = Country.Indonesia,
                                StreetLine1 = "Jalan Koi No 1",
                                StreetLine2 = "Kelurahan Kramat",
                                City = "Jakarta",
                                ProvinceState = "-",
                                PostalCode = "100001",
                                Category = CustomerAddressCategory.Work,
                                IsPrimary = false
                        }
                    },
                    IdentityAccount = new IdentityAccount[]
                    {
                        new IdentityAccount
                        {
                            Country = Country.Indonesia,
                            Type = CustomerIdentityAccountType.BankAccount,
                            Company = "PT Jakarta",
                            Description = "No Description",
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
                            DocumentName = "NPWP - PT Jakarta",
                            DocumentNumber = "JAKARTA001",
                            ExpiresAt = "2050-12-31",
                            HolderName = "PT Jakarta",
                            DocumentImages = images
                        }
                    },
                    Metadata =  new Dictionary<string, string>()
                    {
                        {
                            "x", "y"
                        },
                    }
                };

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                Console.WriteLine(JsonSerializer.Serialize(businessParameter, options));
                CustomerResponse businessCustomerVersion20201031 = await Customer.Create(businessParameter, version: ApiVersion.Version20201031);
                Console.WriteLine(JsonSerializer.Serialize(businessCustomerVersion20201031, options));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task CreateCustomer20201031WithMinimalInput() {
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
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    
}
