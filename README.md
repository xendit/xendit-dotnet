# Xendit API .NET Library

This library is the abstraction of Xendit API for access from applications written with C# .NET.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [API Documentation](#api-documentation)
- [Installation](#installation)
- [Usage](#usage)
  - [Balance Service](#balance-service)
    - [Get Balance](#get-balance)
  - [Virtual Account Services](#virtual-account-services)
    - [Create a Virtual Account](#create-a-virtual-account)
    - [Get a Virtual Account by ID](#get-a-virtual-account-by-id)
    - [Update a Virtual Account](#update-a-virtual-account)
    - [Get banks with available virtual account service](#get-banks-with-available-virtual-account-service)
    - [Get a virtual account payment by payment ID](#get-a-virtual-account-payment-by-payment-id)
  - [Disbursement Services](#disbursement-services)
    - [Create a disbursement](#create-a-disbursement)
    - [Get a disbursement by ID](#get-a-disbursement-by-id)
    - [Get a disbursement by External ID](#get-a-disbursement-by-external-id)
    - [Get banks with available disbursement service](#get-banks-with-available-disbursement-service)
  - [Invoice services](#invoice-services)
    - [Create an invoice](#create-an-invoice)
    - [Get invoice by ID](#get-invoice-by-id)
    - [Get all invoices](#get-all-invoices)
    - [Expire an invoice](#expire-an-invoice)
  - [Customer services](#customer-services)
    - [Create Customer](#create-customer)
    - [Get Customer by Reference ID](#get-customer-by-reference-id)
  - [Direct Debit Payment Services](#direct-debit-payment-services)
    - [Create Direct Debit Payment](#create-direct-debit-payment)
    - [Validate OTP for Direct Debit Payment](#validate-otp-for-direct-debit-payment)
    - [Get Direct Debit Payment by ID](#get-direct-debit-payment-by-id)
    - [Get Direct Debit Payments by Reference ID](#get-direct-debit-payments-by-reference-id)
  - [Linked Account Services](#linked-account-services)
    - [Initialize Linked Account Tokenization](#initialize-linked-account-tokenization)
    - [Validate OTP for Linked Account Token](#validate-otp-for-linked-account-token)
    - [Get Accessible Accounts by Linked Account Token](#get-accessible-accounts-by-linked-account-token)
    - [Unbind Linked Account Token](#unbind-linked-account-token)
  - [Payment Methods Services](#payment-methods-services)
    - [Create Payment Methods](#create-payment-methods)
    - [Get Payment Methods by Customer ID](#get-payment-methods-by-customer-id)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## API Documentation

Please check [Xendit API Reference](https://developers.xendit.co/api-reference/)

## Installation

- Add project reference manually.

  Copy this line into your project's `csproj` file. Change the reference to Xendit.net directory if needed.

  ```
  <ItemGroup>
    <ProjectReference Include="..\Xendit.net\Xendit.net\Xendit.net.csproj" />
  </ItemGroup>
  ```

- Add project reference through `.NET CLI`.
  Run this command:

  ```bash
  dotnet add your_project.csproj reference <Xendit.net.csproj_Directory>
  ```

## Usage

You need to use secret API key in order to use functionality in this library. The key can be obtained from your [Xendit Dashboard](https://dashboard.xendit.co/settings/developers#api-keys).

Example: Get Balance

```cs
namespace XenditExample
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;

    class ExampleGetBalance
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                Balance balance = await Balance.Get();
                Console.WriteLine(balance.Value);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
```

### Balance Service

#### Get Balance

The `accountType` parameter is optional. You can use `accountType` in enum (`"Cash"`, `"Holding"`, `"Tax"`)

```cs
Balance balance = await Balance.Get();

Balance holdingBalance = await Balance.Get(AccountType.Holding);
```

It will return:

```cs
Balance balance = new Balance
{
  Value = 100000,
};
```

### Virtual Account Services

#### Create a Virtual Account

To create a virtual account, use struct `CreateVirtualAccountParameter`. You may use `VirtualAccountEnum.BankCode` for `BankCode` property.

```cs
VirtualAccountParameter parameter = new VirtualAccountParameter
{ 
  ExternalId = "my_external_id",
  BankCode = VirtualAccountEnum.BankCode.Bni,
  Name = "John Doe",
  ExpectedAmount = 200000,
};

VirtualAccount virtualAccount = await VirtualAccount.Create(parameter);
```

It will return:
```cs
VirtualAccount virtualAccount = new VirtualAccount
{
  ExternalId = "my_external_id",
  BankCode = VirtualAccountEnum.BankCode.Bni,
  Name = "John Doe",
  ExpectedAmount = 200000,
  IsSingleUse = false,
  IsClosed = false,
  ExpirationDate = "2021-09-27T17:00:00.000Z",
};
```

#### Get a Virtual Account by ID

```cs
VirtualAccount virtualAccount = await VirtualAccount.Get("VIRTUAL_ACCOUNT_ID");
```

It will return:
```cs
VirtualAccount virtualAccount = new VirtualAccount
{
  Id = "VIRTUAL_ACCOUNT_ID",
  ExternalId = "my_external_id",
  OwnerId = "owner-id",
  BankCode = VirtualAccountEnum.BankCode.Bni,
  MerchantCode = "8888",
  Name = "John Doe",
  ExpectedAmount = 200000,
  IsSingleUse = false,
  IsClosed = false,
  ExpirationDate = "2021-09-27T17:00:00.000Z",
  Status = VirtualAccountEnum.Status.Pending,
  Currency = Currency.IDR,
};
```

#### Update a Virtual Account

To update a virtual account, use struct `UpdateVirtualAccountParameter`. 

```cs
UpdateVirtualAccountParameter parameter = new UpdateVirtualAccountParameter
{
    IsSingleUse = true,
    ExpectedAmount = 20000,
};

VirtualAccount virtualAccount = await VirtualAccount.Update(parameter, "virtual_account_id");
```

#### Get banks with available virtual account service

```cs
AvailableBank[] availableBanks = await VirtualAccount.GetAvailableBanks();
```

It will return:

```cs
AvailableBank[] availableBanks = new AvailableBank[]
{
  new AvailableBank
  {
    Name = "Bank Mandiri",
    Code = DisbursementChannelCode.Mandiri,
    IsActivated = true,
  },
  // ...
};
```

#### Get a virtual account payment by payment ID

```cs
VirtualAccountPayment virtualAccountPayment = await VirtualAccountPayment.Get("VIRTUAL_ACCOUNT_PAYMENT_ID");
```

It will return:

```cs
VirtualAccountPayment virtualAccountPayment = new VirtualAccountPayment
{
  Id = "598d91b1191029596846047f",
  PaymentId = "5f218745736e619164dc8608",
  CallbackVirtualAccountId = "598d5f71bf64853820c49a18",
  ExternalId = "demo-1502437214715",
  BankCode = VirtualAccountEnum.BankCode.Bni,
  MerchantCode = "8888",
  SenderName = "John Doe",
  Amount = 200000,
  AccountNumber = "8808999939380502",
  TransactionTimestamp = "2021-07-24T05:22:55.115Z",
};
```

### Disbursement Services

#### Create a disbursement

To create a disbursement, use struct `DisbursementParameter`. You may use `DisbursementChannelCode` for `BankCode` property.

Here is the example of `Create`:

```cs
DisbursementParameter parameter = new DisbursementParameter
{
  ExternalId = "disb-1475459775872",
  BankCode = DisbursementChannelCode.Bca,
  AccountHolderName = "MICHAEL CHEN",
  AccountNumber = "1234567890",
  Description = "Reimbursement for shoes",
  Amount = 1000,
};

Disbursement disbursement = await Disbursement.Create(parameter);
```

It will return:

```cs
Disbursement disbursement = new Disbursement
{
  Id = "generated-id",
  ExternalId = "disb-1475459775872",
  UserId = "user-id",
  BankCode = DisbursementChannelCode.Bca,
  AccountHolderName = "MICHAEL CHEN",
  DisbursementDescription = "Reimbursement for shoes",
  Amount = 1000,
  Status = DisbursementStatus.Pending,
};
```

#### Get a disbursement by ID

```cs
Disbursement disbursement = await Disbursement.GetById("disbursement_id");
```

It will return:

```cs
Disbursement disbursement = new Disbursement
{
  Id = "disbursement_id",
  ExternalId = "disb-1475459775872",
  UserId = "user-id",
  BankCode = DisbursementChannelCode.Bca,
  AccountHolderName = "MICHAEL CHEN",
  DisbursementDescription = "Reimbursement for shoes",
  Amount = 1000,
  Status = DisbursementStatus.Pending,
};
```

#### Get a disbursement by External ID

```cs
Disbursement[] disbursements = await Disbursement.GetByExternalId("external_id");
```

It will return:

```cs
Disbursement[] disbursements = new Disbursement[]
{
  new Disbursement
  {
    Id = "disbursement_id",
    ExternalId = "disb-1475459775872",
    UserId = "user-id",
    BankCode = DisbursementChannelCode.Bca,
    AccountHolderName = "MICHAEL CHEN",
    DisbursementDescription = "Reimbursement for shoes",
    Amount = 1000,
    Status = DisbursementStatus.Pending,
  }
};
```

#### Get banks with available disbursement service

```cs
AvailableBank[] availableBanks = await Disbursement.GetAvailableBanks();
```

It will return:

```cs
AvailableBank[] availableBanks = new AvailableBank[]
{
  new AvailableBank
  {
    Name = "Bank Mandiri",
    Code = DisbursementChannelCode.Mandiri,
    CanDisburse = true,
    CanNameValidate = true,
  },
  // ...
};
```

### Invoice services

#### Create an invoice

To create an invoice, please use struct `InvoiceParameter` for parameter body. You may use these classes to construct `InvoiceParameter`:

- `ItemInvoice` for `Items` property
- `Customer` for `Customer` property
- `Address` for `Addresses` property in `Customer`
- `FeeInvoice` for `Fees` property
- `NotificationPreference` for `CustomerNotificationPreference` property

Here is the example:

```cs
Address addresses = new Address
{
  Country = Country.Indonesia,
  StreetLine1 = "Jalan Makan",
  StreetLine2 = "Kecamatan Kebayoran Baru",
  City = "Jakarta Selatan",
  Province = "Daerah Khusus Ibukota Jakarta",
  PostalCode = "12345",
};

Customer customer = new Customer
{
  GivenNames = "John",
  Email = "john@email.com",
  MobileNumber = "+6287774441111",
  Addresses = new Address[] { addresses },
};

NotificationPreference preference = new NotificationPreference
{
  InvoicePaid = new NotificationType[] { NotificationType.Email }
};

ItemInvoice item = new ItemInvoice
{
  Name = "shoes",
  Quantity = 1,
  Price = 100,
};

FeeInvoice fee = new FeeInvoice
{
  Type = "name_of_fee_for_internal_reference",
  Value = 200,
};

InvoiceParameter parameter = new InvoiceParameter
{
  ExternalId = "external-id",
  Amount = 1000,
  Customer = customer,
  CustomerNotificationPreference = preference,
  Items = new ItemInvoice[] { item },
  Fees = new FeeInvoice[] { fee },
  Currency = Currency.IDR,
};

Invoice invoice = await Invoice.Create(parameter);
Console.WriteLine(invoice);
```

It will return:

```cs
Invoice invoice = new Invoice
{
  Id = "610a306ffe63418fdb6bd0b3",
  ExternalId = "external-id",
  UserId = "<USER_ID>",
  Status = InvoiceStatus.Pending,
  MerchantName = "<MERCHANT_NAME>",
  MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
  Amount = 1000,
  ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
  InvoiceUrl = "<INVOICE_URL>",
  AvailableBanks = new AvailableBankInvoice[]
  {
    new AvailableBankInvoice
    {
      BankCode = BankCode.Mandiri,
      CollectionType = "POOL",
      BankAccountNumber = "8860810000525",
      TransferAmount = 50000,
      BankBranch = "Virtual Account",
      AccountHolderName = "LANSUR13",
    },
    // ...
  },
  AvailableEwallets = new AvailableEwalletInvoice[]
  {
    new AvailableEwalletInvoice { EwalletType = EwalletType.OVO },
    // ...
  },
  AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
  {
    new AvailableRetailOutletInvoice
    {
      RetailOutletName = RetailOutlet.Alfamart,
      PaymentCode = "ALFA123456",
      TransferAmount = 50000,
    },
    // ...
  }
  ShouldExcludeCreditCard = false,
  ShouldSendEmail = false,
  Created = "<CREATED_TIMESTAMP>",
  Updated = "<UPDATED_TIMESTAMP>",
  Currency = Currency.IDR,
  Fees = new FeeInvoice[] { new FeeInvoice { Type = "name_of_fee_for_internal_reference", Value = 200 } },
  Customer = new Customer {
    GivenNames = "John",
    Email = "john@email.com",
    MobileNumber = "+6287774441111",
    Addresses = new Address[]
    {
      new Address
      {
        Country = Country.Indonesia,
        StreetLine1 = "Jalan Makan",
        StreetLine2 = "Kecamatan Kebayoran Baru",
        City = "Jakarta Selatan",
        Province = "Daerah Khusus Ibukota Jakarta",
        PostalCode = "12345"
      }
    },
  },
  CustomerNotificationPreference = new CustomerNotificationPreference
  {
    InvoicePaid = new NotificationType[] { NotificationType.Email }
  },
};
```

#### Get invoice by ID

```cs
Invoice invoice = await Invoice.GetById("EXAMPLE_ID");
```

It will return:

```cs
Invoice invoice = new Invoice
{
  Id = "610a306ffe63418fdb6bd0b3",
  ExternalId = "external-id",
  UserId = "<USER_ID>",
  Status = InvoiceStatus.Pending,
  MerchantName = "<MERCHANT_NAME>",
  MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
  Amount = 1000,
  ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
  InvoiceUrl = "<INVOICE_URL>",
  AvailableBanks = new AvailableBankInvoice[]
  {
    new AvailableBankInvoice
    {
      BankCode = BankCode.Mandiri,
      CollectionType = "POOL",
      BankAccountNumber = "8860810000525",
      TransferAmount = 50000,
      BankBranch = "Virtual Account",
      AccountHolderName = "LANSUR13",
    },
    // ...
  },
  AvailableEwallets = new AvailableEwalletInvoice[]
  {
    new AvailableEwalletInvoice { EwalletType = EwalletType.OVO },
    // ...
  },
  AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
  {
    new AvailableRetailOutletInvoice
    {
      RetailOutletName = RetailOutlet.Alfamart,
      PaymentCode = "ALFA123456",
      TransferAmount = 50000,
    },
    // ...
  }
  ShouldExcludeCreditCard = false,
  ShouldSendEmail = false,
  Created = "<CREATED_TIMESTAMP>",
  Updated = "<UPDATED_TIMESTAMP>",
  Currency = Currency.IDR,
  Fees = new FeeInvoice[] { new FeeInvoice { Type = "name_of_fee_for_internal_reference", Value = 200 } },
  Customer = new Customer
  {
    GivenNames = "John",
    Email = "john@email.com",
    MobileNumber = "+6287774441111",
    Addresses = new Address[]
    {
      new Address
      {
        Country = Country.Indonesia,
        StreetLine1 = "Jalan Makan",
        StreetLine2 = "Kecamatan Kebayoran Baru",
        City = "Jakarta Selatan",
        Province = "Daerah Khusus Ibukota Jakarta",
        PostalCode = "12345"
      }
    },
  },
  CustomerNotificationPreference = new CustomerNotificationPreference
  {
    InvoicePaid = new NotificationType[] { NotificationType.Email }
  },
};
```

#### Get all invoices

To get all invoices, please use struct `ListInvoiceParameter` for defining which request parameters that you want to use. You may use these enums to construct `ListInvoiceParameter`:

- `InvoiceStatus` for `Statuses` property
- `InvoiceClientType` for `ClientType` property
- `InvoicePaymentChannelType` for `PaymentChannels` property

```cs
// Invoke GetAll without specifying parameter
Invoice[] invoicesWithoutParams = await Invoice.GetAll(null);

// specify parameter using ListInvoiceParameter
ListInvoiceParameter parameter = new ListInvoiceParameter
{
    Limit = 1,
    ClientTypes = new InvoiceClientType[] { InvoiceClientType.ApiGateway, InvoiceClientType.Dashboard },
    PaymentChannels = new InvoicePaymentChannelType[] { },
};

Invoice[] invoiceArray = await Invoice.GetAll(parameter);
```

It will return:

```cs
Invoice[] invoices = new Invoice[]
{
  Invoice invoice = new Invoice
  {
    Id = "610a306ffe63418fdb6bd0b3",
    ExternalId = "external-id",
    UserId = "<USER_ID>",
    Status = InvoiceStatus.Expired,
    MerchantName = "<MERCHANT_NAME>",
    MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
    Amount = 1000,
    ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
    InvoiceUrl = "<INVOICE_URL>",
    AvailableBanks = new AvailableBankInvoice[]
    {
      new AvailableBankInvoice
      {
        BankCode = BankCode.Mandiri,
        CollectionType = "POOL",
        BankAccountNumber = "8860810000525",
        TransferAmount = 50000,
        BankBranch = "Virtual Account",
        AccountHolderName = "LANSUR13",
      },
      // ...
    },
    AvailableEwallets = new AvailableEwalletInvoice[]
    {
      new AvailableEwalletInvoice { EwalletType = EwalletType.OVO },
      // ...
    },
    AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
    {
      new AvailableRetailOutletInvoice
      {
        RetailOutletName = RetailOutlet.Alfamart,
        PaymentCode = "ALFA123456",
        TransferAmount = 50000,
      },
      // ...
    }
    ShouldExcludeCreditCard = false,
    ShouldSendEmail = false,
    Created = "<CREATED_TIMESTAMP>",
    Updated = "<UPDATED_TIMESTAMP>",
    Currency = Currency.IDR,
    Fees = new FeeInvoice[] { new FeeInvoice { Type = "name_of_fee_for_internal_reference", Value = 200 } },
    Customer = new Customer
    {
      GivenNames = "John",
      Email = "john@email.com",
      MobileNumber = "+6287774441111",
      Addresses = new Address[]
      {
        new Address
        {
          Country = Country.Indonesia,
          StreetLine1 = "Jalan Makan",
          StreetLine2 = "Kecamatan Kebayoran Baru",
          City = "Jakarta Selatan",
          Province = "Daerah Khusus Ibukota Jakarta",
          PostalCode = "12345"
        }
      },
    },
    CustomerNotificationPreference = new CustomerNotificationPreference
    {
      InvoicePaid = new NotificationType[] { NotificationType.Email }
    },
  },
};
```

#### Expire an invoice

```cs
Invoice invoice = await Invoice.Expire("EXAMPLE_ID");
```

It will return:

```cs
Invoice invoice = new Invoice
{
  Id = "610a306ffe63418fdb6bd0b3",
  ExternalId = "external-id",
  UserId = "<USER_ID>",
  Status = InvoiceStatus.Expired,
  MerchantName = "<MERCHANT_NAME>",
  MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
  Amount = 1000,
  ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
  InvoiceUrl = "<INVOICE_URL>",
  AvailableBanks = new AvailableBankInvoice[]
  {
    new AvailableBankInvoice
    {
      BankCode = BankCode.Mandiri,
      CollectionType = "POOL",
      BankAccountNumber = "8860810000525",
      TransferAmount = 50000,
      BankBranch = "Virtual Account",
      AccountHolderName = "LANSUR13",
    },
    // ...
  },
  AvailableEwallets = new AvailableEwalletInvoice[]
  {
    new AvailableEwalletInvoice { EwalletType = EwalletType.OVO },
    // ...
  },
  AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
  {
    new AvailableRetailOutletInvoice
    {
      RetailOutletName = RetailOutlet.Alfamart,
      PaymentCode = "ALFA123456",
      TransferAmount = 50000,
    },
    // ...
  }
  ShouldExcludeCreditCard = false,
  ShouldSendEmail = false,
  Created = "<CREATED_TIMESTAMP>",
  Updated = "<UPDATED_TIMESTAMP>",
  Currency = Currency.IDR,
  Fees = new FeeInvoice[] { new FeeInvoice { Type = "name_of_fee_for_internal_reference", Value = 200 } },
  Customer = new Customer
  {
    GivenNames = "John",
    Email = "john@email.com",
    MobileNumber = "+6287774441111",
    Addresses = new Addresses[]
    {
      new Addresses
      {
        Country = Country.Indonesia,
        StreetLine1 = "Jalan Makan",
        StreetLine2 = "Kecamatan Kebayoran Baru",
        City = "Jakarta Selatan",
        Province = "Daerah Khusus Ibukota Jakarta",
        PostalCode = "12345"
      }
    },
  },
  CustomerNotificationPreference = new CustomerNotificationPreference
  {
    InvoicePaid = new NotificationType[] { NotificationType.Email }
  },
};
```

### Customer services

#### Create Customer

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

Customer customerDefault = await Customer.Create(individualParameter);
Console.WriteLine(customerDefault);

// or you can define with the API version
Customer customer = await Customer.Create(individualParameter, version: ApiVersion.Version20201031);
Console.WriteLine(customer);
```

It will return:

```cs
Customer customerDefault = new Customer
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

Customer customerWithVersion = await Customer.Create(parameter, version: ApiVersion.Version20200519);
```

It will return:

```cs
Customer customerWithVersion = new Customer
{
    ReferenceId = "demo_11212144",
    Email = "john@email.com",
    GivenNames = "John",
    Addresses = new Address[] { new Address { Country = Country.Indonesia } }
};
```

#### Get Customer by Reference ID

The library supports get customer operation for API version `2020-10-31` (recommended) and `2020-05-19`.

Method `Get` has three parameters: reference ID (required), optional headers, and optional API version with default value of `ApiVersion.Version20201031` enum (represents `2020-10-31` version).

Here is the example of invoking method `Get` with API version of `2020-10-31`:

```cs
Customer customerDefault = await Customer.Get("example_reference_id");

Customer customerWithVersion20201031 = await Customer.Get("example_reference_id", version: ApiVersion.Version20201031);
```

It will return:

```cs
Customer customerDefault = new Customer
{
  Data = new Customer[]
  {
    new Customer
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
Customer customerWithVersion = await Customer.Get("example_reference_id", version: ApiVersion.Version20200519);
```

It will return:

```cs
Customer customerWithVersion = new Customer
{
  Data = new Customer[]
  {
    new Customer
    {
      ReferenceId = "example_reference_id",
      Email = "john@email.com",
      GivenNames = "John",
      Addresses = new Address[] { new Address { Country = Country.Indonesia } }
    }
  },
};
```

### Direct Debit Payment Services

#### Create Direct Debit Payment

Method `Create` has three parameters: parameter or request body using `DirectDebitPaymentParameter`, idempotency key (required), and optional headers.

To create direct debit payment, please use struct `DirectDebitPaymentParameter` for parameter body. You may use these enum and classes to construct `DirectDebitPaymentParameter`:

- Enum `Currency` for `Currency` property
- `LinkedAccountDevice` for `Device` property
- `BasketItem` for `Basket` property

Here is the example of invoking `Create`:

```cs
DirectDebitPaymentParameter directDebitPaymentParameter = new DirectDebitPaymentParameter
{
  ReferenceId = "reference-id",
  PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
  Currency = Currency.IDR,
  Amount = 10000,
  CallbackUrl = "https://callback-url.com/",
  EnableOtp = true,
  Description = "Example Description",
  SuccessRedirectUrl = "https://success-url.com/",
  FailureRedirectUrl = "https://failure-url.com/",
  Device = new LinkedAccountDevice
  {
    Id = "device-id",
    IpAddress = "255.255.255.255",
    UserAgent = "App",
    Imei = "imei-example",
    AdId = "ad-id",
  },
  Metadata = null,
  Basket = new BasketItem[]
  {
    new BasketItem { Name = "Black shoes", Type = "goods", Price = 2000, Quantity = 1 },
    new BasketItem { Name = "Blue shirt", Type = "apparel", Price = 2000, Quantity = 1 },
  },
};

string idempotencyKey = "fa9b53a1-f81a-47ff-8fde-b2eec3546b66";

DirectDebitPayment directDebitPayment = await DirectDebitPayment.Create(directDebitPaymentParameter, idempotencyKey);
Console.WriteLine(directDebitPayment);
```

It will return:

```cs
DirectDebitPayment directDebitPayment = new DirectDebitPayment
{
  Id = "ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14",
  ReferenceId = "reference-id",
  ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
  PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
  Currency = Currency.IDR,
  Amount = 10000,
  Description = "Example Description",
  Status = DirectDebitStatus.Pending,
  FailureCode = null,
  IsOtpRequired = true,
  OtpMobileNumber = "+6287774441111",
  OtpExpirationTimestamp = "2020-03-26T05:44:26+0800",
  RequiredAction = DirectDebitRequiredAction.ValidateOtp,
  SuccessRedirectUrl = null,
  FailureRedirectUrl = null,
  Created = "2020-03-26T05:44:26+0800",
  Updated = null,
  Metadata = null,
  Basket = new BasketItem[]
  {
    new BasketItem { Name = "Black shoes", Type = "goods", Price = 2000, Quantity = 1 },
    new BasketItem { Name = "Blue shirt", Type = "apparel", Price = 2000, Quantity = 1 },
  },
};
```

#### Validate OTP for Direct Debit Payment

Here is the example of invoking `ValidateOtp`:

```cs
string otpCode = "123456";

DirectDebitPayment directDebitPayment = await DirectDebitPayment.ValidateOtp(otpCode, "ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14");
Console.WriteLine(directDebitPayment);
```

It will return:

```cs
DirectDebitPayment directDebitPayment = new DirectDebitPayment
{
  Id = "ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14",
  ReferenceId = "reference-id",
  ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
  PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
  Currency = Currency.IDR,
  Amount = 10000,
  Description = "Example Description",
  Status = DirectDebitStatus.Pending,
  FailureCode = null,
  IsOtpRequired = true,
  OtpMobileNumber = "+6287774441111",
  OtpExpirationTimestamp = "2020-03-26T05:44:26+0800",
  RequiredAction = DirectDebitRequiredAction.ValidateOtp,
  SuccessRedirectUrl = null,
  FailureRedirectUrl = null,
  Created = "2020-03-26T05:44:26+0800",
  Updated = null,
  Metadata = null,
  Basket = new BasketItem[]
  {
    new BasketItem { Name = "Black shoes", Type = "goods", Price = 2000, Quantity = 1 },
    new BasketItem { Name = "Blue shirt", Type = "apparel", Price = 2000, Quantity = 1 },
  },
};
```

#### Get Direct Debit Payment by ID

```cs
DirectDebitPayment directDebitPayment = await DirectDebitPayment.GetById("ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14");
Console.WriteLine(directDebitPayment);
```

It will return:

```cs
DirectDebitPayment directDebitPayment = new DirectDebitPayment
{
  Id = "ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14",
  ReferenceId = "reference-id",
  ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
  PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
  Currency = Currency.IDR,
  Amount = 10000,
  Description = "Example Description",
  Status = DirectDebitStatus.Pending,
  FailureCode = null,
  IsOtpRequired = true,
  OtpMobileNumber = "+6287774441111",
  OtpExpirationTimestamp = "2020-03-26T05:44:26+0800",
  RequiredAction = DirectDebitRequiredAction.ValidateOtp,
  SuccessRedirectUrl = null,
  FailureRedirectUrl = null,
  Created = "2020-03-26T05:44:26+0800",
  Updated = null,
  Metadata = null,
  Basket = new BasketItem[]
  {
    new BasketItem { Name = "Black shoes", Type = "goods", Price = 2000, Quantity = 1 },
    new BasketItem { Name = "Blue shirt", Type = "apparel", Price = 2000, Quantity = 1 },
  },
};
```

#### Get Direct Debit Payments by Reference ID

```cs
DirectDebitPayment[] directDebitPayments = await DirectDebitPayment.GetByReferenceId("reference-id");
Console.WriteLine(directDebitPayments);
```

It will return:

```cs
DirectDebitPayment[] directDebitPayments = new DirectDebitPayment[]
{
  {
    Id = "ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14",
    ReferenceId = "reference-id",
    ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
    PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
    Currency = Currency.IDR,
    Amount = 10000,
    Description = "Example Description",
    Status = DirectDebitStatus.Pending,
    FailureCode = null,
    IsOtpRequired = true,
    OtpMobileNumber = "+6287774441111",
    OtpExpirationTimestamp = "2020-03-26T05:44:26+0800",
    RequiredAction = DirectDebitRequiredAction.ValidateOtp,
    SuccessRedirectUrl = null,
    FailureRedirectUrl = null,
    Created = "2020-03-26T05:44:26+0800",
    Updated = null,
    Metadata = null,
    Basket = new BasketItem[]
    {
      new BasketItem { Name = "Black shoes", Type = "goods", Price = 2000, Quantity = 1 },
      new BasketItem { Name = "Blue shirt", Type = "apparel", Price = 2000, Quantity = 1 },
    },
  }
};
```

### Linked Account Services

#### Initialize Linked Account Tokenization

To initialize linked account tokenization, use struct `InitializedLinkedAccountParameter`. You may use these enum and class to construct `InitializedLinkedAccountParameter`:

- Enum `LinkedAccountEnum.ChannelCode` for `ChannelCode` property
- `LinkedAccountProperties` for `Properties` property

Here is the example:

```cs
InitializedLinkedAccountParameter parameter = new InitializedLinkedAccountParameter
{
  CustomerId = "customer-id",
  ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
  Properties = new LinkedAccountProperties
  {
    AccountMobileNumber = "+62818555988",
    CardLastFour = "4444",
    CardExpiry = "06/24",
    AccountEmail = "test@email.com",
  },
  Metadata = new Dictionary<string, object>()
  {
    { "example-metadata", "here is the example" },
  },
};

InitializedLinkedAccount initializedLinkedAccount = await InitializedLinkedAccount.Initialize(parameter);
```

It will return:

```cs
InitializedLinkedAccount initializedLinkedAccount = new InitializedLinkedAccount
{
  Id = "linked-account-token-id",
  CustomerId = "customer-id",
  ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
  AuthorizerUrl = "https://example.com/",
  Status = LinkedAccountEnum.Status.Pending,
  Metadata = new Dictionary<string, object>()
  {
    { "example-metadata", "here is the example" },
  },
};
```

#### Validate OTP for Linked Account Token

```cs
string otpCode = "123456";
string linkedAccountTokenId = "linked-account-token-id";

ValidatedLinkedAccount validatedLinkedAccount = await ValidatedLinkedAccount.ValidateOtp(otpCode,linkedAccountTokenId);
```

It will return:

```cs
ValidatedLinkedAccount validatedLinkedAccount = new ValidatedLinkedAccount
{
  Id = "linked-account-token-id",
  CustomerId = "customer-id",
  ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
  Status = LinkedAccountEnum.Status.Success,
};
```

#### Get Accessible Accounts by Linked Account Token

```cs
AccessibleLinkedAccount[] accessibleLinkedAccounts = await AccessibleLinkedAccount.Get("linked-account-token-id");
```

It will return:

```cs
AccessibleLinkedAccount[] accessibleLinkedAccounts = new AccessibleLinkedAccount[]
{
  new AccessibleLinkedAccount
  {
    Id = "linked-account-token-id",
    ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
    Type = LinkedAccountEnum.Type.DebitCard,
    Properties = new LinkedAccountProperties
    {
      AccountMobileNumber = "+62818555988",
      CardLastFour = "4444",
      CardExpiry = "06/24",
      AccountEmail = "test@email.com",
    },
  },
};
```

#### Unbind Linked Account Token

```cs
UnbindedLinkedAccount unbindedLinkedAccount = await UnbindedLinkedAccount.Unbind("linked-account-token-id");
```

It will return:

```cs
UnbindedLinkedAccount unbindedLinkedAccount = new UnbindedLinkedAccount
{
  Id = "linked-account-token-id",
  IsDeleted = true,
};
```

### Payment Methods Services

#### Create Payment Methods

To create payment methods, please use struct `PaymentMethodParameter` for parameter body. You may use these enum and classes to construct `PaymentMethodParameter`:

- Enum `PaymentMethodEnum.AccountType` for `Type` property
- `PaymentMethodProperties` for `Properties` property

Here is the example:

```cs
PaymentMethodParameter parameter = new PaymentMethodParameter
{
  Type = PaymentMethodEnum.AccountType.DebitCard,
  Properties = new PaymentMethodProperties
  {
    Id = "la-052d3e2d-bc4d-4c98-8072-8d232a552299",
    ChannelCode = PaymentMethodEnum.ChannelCode.DcBri,
    Currency = Currency.IDR,
    CardLastFour = "1234",
    CardExpiry = "06/24",
    Description = "Payment Debit Card",
  },
  CustomerId = "4b7b6050-0830-440a-903b-37d527dbbaa9",
};
PaymentMethod paymentMethod = await PaymentMethod.Create(parameter);
Console.WriteLine(paymentMethod);
```

It will return:

```cs
PaymentMethod paymentMethod = new PaymentMethod
{
  Id = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
  Type = PaymentMethodEnum.AccountType.DebitCard,
  Properties = new PaymentMethodProperties
  {
    Id = "la-052d3e2d-bc4d-4c98-8072-8d232a552299",
    ChannelCode = PaymentMethodEnum.ChannelCode.DcBri,
    Currency = Currency.IDR,
    CardLastFour = "1234",
    CardExpiry = "06/24",
    Description = "Payment Debit Card",
  },
  CustomerId = "4b7b6050-0830-440a-903b-37d527dbbaa9",
  Status = PaymentMethodEnum.Status.Active,
  Created = "2020-03-19T05:34:55+0800",
  Updated = "2020-03-19T05:34:55+0800",
  Metadata = null,
};
```

#### Get Payment Methods by Customer ID

```cs
PaymentMethod[] paymentMethods = await PaymentMethod.Get("4b7b6050-0830-440a-903b-37d527dbbaa9");
```

It will return

```cs
PaymentMethod[] paymentMethods = new PaymentMethods[]
{
  new PaymentMethod
  {
    Id = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
    Type = PaymentMethodEnum.AccountType.DebitCard,
    Properties = new PaymentMethodProperties
    {
      Id = "la-052d3e2d-bc4d-4c98-8072-8d232a552299",
      ChannelCode = PaymentMethodEnum.ChannelCode.DcBri,
      Currency = Currency.IDR,
      CardLastFour = "1234",
      CardExpiry = "06/24",
      Description = "Payment Debit Card",
    },
    CustomerId = "4b7b6050-0830-440a-903b-37d527dbbaa9",
    Status = PaymentMethodEnum.Status.Active,
    Created = "2020-03-19T05:34:55+0800",
    Updated = "2020-03-19T05:34:55+0800",
    Metadata = null,
  }
};
```
