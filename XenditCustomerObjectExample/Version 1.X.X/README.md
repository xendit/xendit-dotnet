# Xendit Customer Object Example - Version 1.X.X

For Legacy Frameworks (.NET Core 3.1, 2.1 and .NET Framework 4.8)
using [Xendit.net 1.1.0](https://www.nuget.org/packages/Xendit.net/1.1.0) **.NET 5.0 or newer not supported**

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [Xendit Customer Object Example - Version 1.X.X](#xendit-customer-object-example---version-1xx)
  - [Table of Contents](#table-of-contents)
  - [Examples](#examples)
    - [Create Customer](#create-customer)
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

```cs
IndividualDetail individualDetail = new IndividualDetail
{
  GivenNames = "John",
  Gender = CustomerGender.Male,
};

IdentityAccount identityAccount = new IdentityAccount
{
  Country = Country.Indonesia,
  Type = CustomerIdentityAccountType.BankAccount,
  Properties = new IdentityAccountProperties { AccountNumber = "account_number" }
};

KycDocument document = new KycDocument
{
  Country = Country.Indonesia,
  Type = CustomerKycDocumentType.IdentityCard,
  SubType = CustomerKycDocumentSubType.NationalId,
};

CustomerParameter individualParameter = new CustomerParameter
{
  ReferenceId = "demo_11212145",
  Type = CustomerType.Individual,
  IndividualDetail = individualDetail,
  IdentityAccount = new IdentityAccount[] { identityAccount },
  KycDocuments = new KycDocument[] { document },
};

CustomerResponse customerDefault = await Customer.Create(individualParameter);
Console.WriteLine(customerDefault);

// or you can define with the API version
CustomerResponse customer = await Customer.Create(individualParameter, version: ApiVersion.Version20201031);
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
