# Xendit Customer Object Example - Xendit.net Version 2.X.X

Breaking Changes:

- .NET 5.0 or newer use the  `await Customer.Create(individualParameter);` method
- or can use the `await Customer.CreateCustomParams(individualParameter);` method

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [Xendit Customer Object Example - Xendit.net Version 2.X.X](#xendit-customer-object-example---xenditnet-version-2xx)
  - [Table of Contents](#table-of-contents)
  - [Examples](#examples)
    - [Create Customer](#create-customer)
      - [Customer.Create()](#customercreate)
      - [Customer.CreateCustomParams()](#customercreatecustomparams)
    - [Get Customer by Reference ID](#get-customer-by-reference-id)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Examples

### Create Customer

The library supports get customer operation for API version `2020-10-31` (recommended) and `2020-05-19`.

Method `Create` has three parameters: parameter or request body using struct `CustomerParameter`, optional headers, and optional API version with default value of `ApiVersion.Version20201031` enum (represents `2020-10-31` version).

To construct struct `CustomerParameter`, you may use these classes and enums (applicable for API version of `2020-10-31`):

- Class: `IndividualDetail`, `BusinessDetail`, `IdentityAccount`, `KycDocument`, `IdentityAccountProperties`, and `Address` (applicable for both API versions).
- Enum: `CustomerType`, `CustomerKycDocumentType`, `CustomerKycDocumentSubType`, `CustomerIdentityAccountType`, `CustomerGender`, `CustomerBusinessType`, and `CustomerAddressCategory`.

Here is the example of invoking method `Create` with API version of `2020-10-31`:

#### Customer.Create()

```cs
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
    HashedPhoneNumber = "6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b",
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
    DateOfRegistration = "2023-01-01",
    DomicileOfRegistration = "ID",
    Metadata =  new Dictionary<string, string>()
    {
        {
            "x", "y"
        },
    }
};

CustomerResponse customerDefault = await Customer.Create(individualParameter);
Console.WriteLine(customerDefault);

// or you can define with the API version
CustomerResponse customer = await Customer.Create(individualParameter, version: ApiVersion.Version20201031);
Console.WriteLine(customer);
```

#### Customer.CreateCustomParams()

or Using CustomParameters

```cs
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
    metadata =  new Dictionary<string, string>()
    {
        {
            "x", "y"
        },
    }
};

CustomerResponse customerDefault = await Customer.CreateCustomParams(individualParameter);
Console.WriteLine(customerDefault);

// or you can define with the API version
CustomerResponse customer = await Customer.CreateCustomParams(individualParameter, version: ApiVersion.Version20201031);
Console.WriteLine(customer);
```

It will return:

```cs
CustomerResponse customerDefault = new CustomerResponse
{
  ReferenceId = "demo_11212145",
  Type = CustomerType.Individual,
  IndividualDetail = new IndividualDetail { GivenNames = "John", Gender = CustomerGender.Male },
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
    { Country = Country.Indonesia,
      Type = CustomerKycDocumentType.IdentityCard,
      SubType = CustomerKycDocumentSubType.NationalId,
    }
  }
};
```

For API version of `2020-05-19`, here is the example:

```cs
CustomerParameter parameter = new CustomerParameter
{
    ReferenceId = "demo_11212144",
    Email = "john@email.com",
    GivenNames = "John",
    Addresses = new Address[] { new Address { Country = Country.Indonesia } }
};

CustomerResponse customerWithVersion = await Customer.Create(parameter, version: ApiVersion.Version20200519);
```

It will return:

```cs
CustomerResponse customerWithVersion = new Customer
{
    ReferenceId = "demo_11212144",
    Email = "john@email.com",
    GivenNames = "John",
    Addresses = new Address[] { new Address { Country = Country.Indonesia } }
};
```

### Get Customer by Reference ID

The library supports get customer operation for API version `2020-10-31` (recommended) and `2020-05-19`.

Method `Get` has three parameters: reference ID (required), optional headers, and optional API version with default value of `ApiVersion.Version20201031` enum (represents `2020-10-31` version).

Here is the example of invoking method `Get` with API version of `2020-10-31`:

```cs
CustomerResponse customerDefault = await Customer.Get("example_reference_id");

CustomerResponse customerWithVersion20201031 = await Customer.Get("example_reference_id", version: ApiVersion.Version20201031);
```

It will return:

```cs
CustomerResponse customerDefault = new CustomerResponse
{
  Data = new CustomerResponse[]
  {
    new CustomerResponse
    {
      ReferenceId = "example_reference_id",
      Type = CustomerType.Individual,
      IndividualDetail = new IndividualDetail { GivenNames = "John", Gender = CustomerGender.Male },
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
        { Country = Country.Indonesia,
          Type = CustomerKycDocumentType.IdentityCard,
          SubType = CustomerKycDocumentSubType.NationalId,
        }
      }
    }
  },
  HasMore = false,
};
```

For API version of `2020-05-19`, here is the example:

```cs
CustomerResponse customerWithVersion = await Customer.Get("example_reference_id", version: ApiVersion.Version20200519);
```

It will return:

```cs
CustomerResponse customerWithVersion = new CustomerResponse
{
  Data = new CustomerResponse[]
  {
    new CustomerResponse
    {
      ReferenceId = "example_reference_id",
      Email = "john@email.com",
      GivenNames = "John",
      Addresses = new Address[] { new Address { Country = Country.Indonesia } }
    }
  },
};
```
