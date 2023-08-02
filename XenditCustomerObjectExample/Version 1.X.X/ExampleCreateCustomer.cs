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

        public async Task CreateCustomer20201031() {
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
    
        public async Task CreateCustomer20201031WithCustomParams() {
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
                object individualParameter = new
                {
                    reference_id = referenceId,
                    type = CustomerType.Individual,
                    individual_detail = new IndividualDetail
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
                    mobile_number = "+628123456789",
                    email = "john@test.com",
                    phone_number = "+6221872772",
                    hashed_phone_number = "6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b",
                    addresses = new Address[] 
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
                    identity_accounts = new IdentityAccount[]
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
                    kyc_documents = new KycDocument[]
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
                    date_of_registration = "2023-01-01",
                    domicile_of_registration = "ID",
                    trading_name = "Murah & co",
                    metadata =  new Dictionary<string, string>()
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
                CustomerResponse individualCustomerVersion20201031 = await Customer.CreateCustomParams(individualParameter, version: ApiVersion.Version20201031);
                Console.WriteLine(JsonSerializer.Serialize(individualCustomerVersion20201031, options));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    
}
