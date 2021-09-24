# Xendit API .NET Library

This library is the abstraction of Xendit API for access from applications written with C# .NET.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [API Documentation](#api-documentation)
- [Installation](#installation)
- [Usage](#usage)
  - [API Key](#api-key)
    - [Global Variable](#global-variable)
    - [`XenditClient` instance or Individual `Client` instance](#xenditclient-instance-or-individual-client-instance)
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
  - [Retail Outlet Services](#retail-outlet-services)
    - [Create Fixed Payment Code](#create-fixed-payment-code)
    - [Update Fixed Payment Code](#update-fixed-payment-code)
    - [Get Payment Code](#get-payment-code)
    - [Get Payments By Payment Code ID](#get-payments-by-payment-code-id)
  - [E-Wallet Service](#e-wallet-service)
    - [Create E-Wallet Charge (API version `2020-01-25`)](#create-e-wallet-charge-api-version-2020-01-25)
    - [Get E-Wallet Charge (API version `2020-01-25`)](#get-e-wallet-charge-api-version-2020-01-25)
    - [Create E-Wallet Payment (API version `2020-02-01`)](#create-e-wallet-payment-api-version-2020-02-01)
    - [Create E-Wallet Payment (API version `2019-02-04`)](#create-e-wallet-payment-api-version-2019-02-04)
    - [Get E-Wallet Payment](#get-e-wallet-payment)

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

### API Key

You need to use secret API key in order to use functionality in this library. The key can be obtained from your [Xendit Dashboard](https://dashboard.xendit.co/settings/developers#api-keys).

To add API Key, you have 2 options: Use global variable or use `XenditClient` or Individual `Client` instance.

#### Global Variable

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
            try
            {
                HttpClient httpClient = new HttpClient();
                NetworkClient requestClient = new NetworkClient(httpClient);
                XenditConfiguration.RequestClient = requestClient;
                XenditConfiguration.ApiKey = "xnd_development_...";

                BalanceResponse balanceResponse = await Balance.Get();
                Console.WriteLine(balanceResponse.Balance);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
```

#### `XenditClient` instance or Individual `Client` instance

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
            try
            {
                // define API key
                string apiKey = "xnd_development_...";

                // define base URL (optional, default is `https://api.xendit.co`)
                string baseUrl = "https://api.xendit.co";

                // define network client
                HttpClient httpClient = new HttpClient();
                NetworkClient requestClient = new NetworkClient(httpClient);
      
                // define XenditClient, request client and base url is optional
                XenditClient client = new XenditClient(apiKey, requestClient, baseUrl);
                BalanceResponse balanceResponse = await client.Balance.Get();
                Console.WriteLine(balanceResponse.Balance);

                // not using request client and base URL
                XenditClient client2 = new XenditClient(apiKey);
                BalanceResponse balanceResponse2 = await client2.Balance.Get();
                Console.WriteLine(balanceResponse2.Balance);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
```

You also can use individual instance (e.g: `BalanceClient`, `VirtualAccountClient`, etc.)

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
            try
            {
                // define API key (optional, default using XenditConfiguration API key)
                string apiKey = "xnd_development_...";

                // define base URL (optional, default using XenditConfiguration base URL)
                string baseUrl = "https://api.xendit.co";

                // define network client (optional, default using XenditConfiguration network client)
                HttpClient httpClient = new HttpClient();
                NetworkClient requestClient = new NetworkClient(httpClient);
      
                // define BalanceClient, all of the parameters are optional (default: using global variable)
                BalanceClient balanceClient = new BalanceClient(apiKey, requestClient, baseUrl)
                BalanceResponse balanceResponse = balanceClient.Get();
                Console.WriteLine(balanceResponse.Balance);

                // using only API key as constructor parameter
                BalanceClient balance = new BalanceClient(apiKey);
                BalanceResponse balanceResponse2 = balance.Get();
                Console.WriteLine(balanceResponse2.Balance);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
```

Note that since constructor parameters of individual client are optional and it will use global variable, you need to define `XenditConfiguration` API key if you don't pass any value to the constructor parameters.

### Balance Service

#### Get Balance

The `accountType` parameter is optional. You can use `accountType` in enum (`"Cash"`, `"Holding"`, `"Tax"`)

```cs
BalanceResponse balance = await Balance.Get();

BalanceResponse holdingBalance = await Balance.Get(BalanceAccountType.Holding);
```

It will return:

```cs
BalanceResponse balance = new BalanceResponse
{
  Balance = 100000,
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

VirtualAccountResponse virtualAccount = await VirtualAccount.Create(parameter);
```

It will return:

```cs
VirtualAccountResponse virtualAccount = new VirtualAccountResponse
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
VirtualAccountResponse virtualAccount = await VirtualAccount.Get("VIRTUAL_ACCOUNT_ID");
```

It will return:

```cs
VirtualAccountResponse virtualAccount = new VirtualAccountResponse
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

VirtualAccountResponse virtualAccount = await VirtualAccount.Update(parameter, "virtual_account_id");
```

It will return:
```cs
VirtualAccountResponse virtualAccount = new VirtualAccountResponse
{
  Id = "VIRTUAL_ACCOUNT_ID",
  ExternalId = "my_external_id",
  OwnerId = "owner-id",
  BankCode = VirtualAccountEnum.BankCode.Bni,
  MerchantCode = "8888",
  Name = "John Doe",
  ExpectedAmount = 20000,
  IsSingleUse = true,
  IsClosed = false,
  ExpirationDate = "2021-09-27T17:00:00.000Z",
  Status = VirtualAccountEnum.Status.Pending,
  Currency = Currency.IDR,
};
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
VirtualAccountPaymentResponse virtualAccountPayment = await VirtualAccountPayment.Get("VIRTUAL_ACCOUNT_PAYMENT_ID");
```

It will return:

```cs
VirtualAccountPaymentResponse virtualAccountPayment = new VirtualAccountPaymentResponse
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

DisbursementResponse disbursement = await Disbursement.Create(parameter);
```

It will return:

```cs
DisbursementResponse disbursement = new DisbursementResponse
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
DisbursementResponse disbursement = await Disbursement.GetById("disbursement_id");
```

It will return:

```cs
DisbursementResponse disbursement = new DisbursementResponse
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
DisbursementResponse[] disbursements = await Disbursement.GetByExternalId("external_id");
```

It will return:

```cs
DisbursementResponse[] disbursements = new DisbursementResponse[]
{
  new DisbursementResponse
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
- `NotificationPreference` for `NotificationPreference` property

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
  NotificationPreference = preference,
  Items = new ItemInvoice[] { item },
  Fees = new FeeInvoice[] { fee },
  Currency = Currency.IDR,
};

InvoiceResponse invoice = await Invoice.Create(parameter);
Console.WriteLine(invoice);
```

It will return:

```cs
InvoiceResponse invoice = new InvoiceResponse
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
  NotificationPreference = new NotificationPreference
  {
    InvoicePaid = new NotificationType[] { NotificationType.Email }
  },
};
```

#### Get invoice by ID

```cs
InvoiceResponse invoice = await Invoice.GetById("EXAMPLE_ID");
```

It will return:

```cs
InvoiceResponse invoice = new InvoiceResponse
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
  NotificationPreference = new NotificationPreference
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
InvoiceResponse[] invoicesWithoutParams = await Invoice.GetAll(null);

// specify parameter using ListInvoiceParameter
ListInvoiceParameter parameter = new ListInvoiceParameter
{
    Limit = 1,
    ClientTypes = new InvoiceClientType[] { InvoiceClientType.ApiGateway, InvoiceClientType.Dashboard },
    PaymentChannels = new InvoicePaymentChannelType[] { },
};

InvoiceResponse[] invoiceArray = await Invoice.GetAll(parameter);
```

It will return:

```cs
InvoiceResponse[] invoices = new InvoiceResponse[]
{
  new InvoiceResponse
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
    NotificationPreference = new NotificationPreference
    {
      InvoicePaid = new NotificationType[] { NotificationType.Email }
    },
  },
};
```

#### Expire an invoice

```cs
InvoiceResponse invoice = await Invoice.Expire("EXAMPLE_ID");
```

It will return:

```cs
InvoiceResponse invoice = new InvoiceResponse
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
  NotificationPreference = new NotificationPreference
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

#### Get Customer by Reference ID

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

DirectDebitPaymentResponse directDebitPayment = await DirectDebitPayment.Create(directDebitPaymentParameter, idempotencyKey);
Console.WriteLine(directDebitPayment);
```

It will return:

```cs
DirectDebitPaymentResponse directDebitPayment = new DirectDebitPaymentResponse
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

DirectDebitPaymentResponse directDebitPayment = await DirectDebitPayment.ValidateOtp(otpCode, "ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14");
Console.WriteLine(directDebitPayment);
```

It will return:

```cs
DirectDebitPaymentResponse directDebitPayment = new DirectDebitPaymentResponse
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
DirectDebitPaymentResponse directDebitPayment = await DirectDebitPayment.GetById("ddpy-623dca10-5dad-4916-b14d-81aaa76b5d14");
Console.WriteLine(directDebitPayment);
```

It will return:

```cs
DirectDebitPaymentResponse directDebitPayment = new DirectDebitPaymentResponse
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
DirectDebitPaymentResponse[] directDebitPayments = await DirectDebitPayment.GetByReferenceId("reference-id");
Console.WriteLine(directDebitPayments);
```

It will return:

```cs
DirectDebitPaymentResponse[] directDebitPayments = new DirectDebitPaymentResponse[]
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

To initialize linked account tokenization, use struct `InitializedLinkedAccountTokenParameter`. You may use these enum and class to construct `InitializedLinkedAccountTokenParameter`:

- Enum `LinkedAccountEnum.ChannelCode` for `ChannelCode` property
- `LinkedAccountTokenProperties` for `Properties` property

Here is the example:

```cs
InitializedLinkedAccountTokenParameter parameter = new InitializedLinkedAccountTokenParameter
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

InitializedLinkedAccountToken initializedLinkedAccount = await LinkedAccountToken.Initialize(parameter);
```

It will return:

```cs
InitializedLinkedAccountToken initializedLinkedAccount = new InitializedLinkedAccountToken
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

ValidatedLinkedAccountToken validatedLinkedAccount = await ValidatedLinkedAccount.ValidateOtp(otpCode,linkedAccountTokenId);
```

It will return:

```cs
ValidatedLinkedAccountToken validatedLinkedAccount = new ValidatedLinkedAccountToken
{
  Id = "linked-account-token-id",
  CustomerId = "customer-id",
  ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
  Status = LinkedAccountEnum.Status.Success,
};
```

#### Get Accessible Accounts by Linked Account Token

```cs
AccessibleLinkedAccountToken[] accessibleLinkedAccounts = await LinkedAccountToken.Get("linked-account-token-id");
```

It will return:

```cs
AccessibleLinkedAccountToken[] accessibleLinkedAccounts = new AccessibleLinkedAccountToken[]
{
  new AccessibleLinkedAccountToken
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
UnbindedLinkedAccountToken unbindedLinkedAccount = await LinkedAccount.Unbind("linked-account-token-id");
```

It will return:

```cs
UnbindedLinkedAccountToken unbindedLinkedAccount = new UnbindedLinkedAccountToken
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
PaymentMethodResponse paymentMethod = await PaymentMethod.Create(parameter);
Console.WriteLine(paymentMethod);
```

It will return:

```cs
PaymentMethodResponse paymentMethod = new PaymentMethodResponse
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
PaymentMethodResponse[] paymentMethods = await PaymentMethod.Get("4b7b6050-0830-440a-903b-37d527dbbaa9");
```

It will return

```cs
PaymentMethodResponse[] paymentMethods = new PaymentMethodResponse[]
{
  new PaymentMethodResponse
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

### Retail Outlet Services

This library supports Retail Outlet API for Philippines (PH).

#### Create Fixed Payment Code

To create a payment code, please use struct `CreateFixedPaymentCodeParameter` for parameter body. You may use these enums to construct `CreateFixedPaymentCodeParameter`:

- `RetailOutletEnum.ChannelCode` for `ChannelCode` property
- `Currency` for `Currency` property with enum value of `Currency.PHP`
- `Country` for `Market` property with enum value of `Country.Philippines`

Here is the example:

```cs
CreateFixedPaymentCodeParameter parameter = new CreateFixedPaymentCodeParameter
{
  ReferenceId = "demo_payment_code_id",
  ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
  CustomerName = "Rika Sutanto",
  Amount = 50,
  Currency = Currency.PHP,
  Market = Country.Philippines,
  PaymentCode = "12345678",
  Description = "Example payment code",
};

FixedPaymentCode fixedPaymentCode = await RetailOutlet.CreatePaymentCode(parameter);
```

It will return:

```cs
FixedPaymentCode fixedPaymentCode = new FixedPaymentCode
{
  Id = "<GENERATED_ID>",
  BusinessId = "<BUSINESS_ID>"
  ReferenceId = "demo_payment_code_id",
  ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
  CustomerName = "Rika Sutanto",
  Amount = 50,
  Currency = Currency.PHP,
  Market = Country.Philippines,
  PaymentCode = "12345678",
  Description = "Example payment code",
  IsSingleUse = true,
  Status = RetailOutletEnum.Status.Active,
  Metadata = null,
  CreatedAt = "2021-01-01T02:38:01.385383888Z",
  UpdatedAt = "2021-01-01T02:38:01.385383888Z",
  ExpiresAt = "2021-05-30T02:38:01.327283048Z",
}
```

#### Update Fixed Payment Code

To update payment code, please use struct `UpdateFixedPaymentCodeParameter` for parameter body. You may use these enums to construct `UpdateFixedPaymentCodeParameter`:

- `Currency` for `Currency` property with enum value of `Currency.PHP`.

Here is the example:

```cs
UpdateFixedPaymentCodeParameter parameter = new UpdateFixedPaymentCodeParameter
{
    CustomerName = "Rika Sutanto",
    Amount = 100,
    Currency = Currency.PHP,
    Description = "Example updated payment code",
};

FixedPaymentCode fixedPaymentCode = await RetailOutlet.UpdatePaymentCode(parameter, "example_payment_code_id");
```

It will return:

```cs
FixedPaymentCode fixedPaymentCode = new FixedPaymentCode
{
  Id = "<GENERATED_ID>",
  BusinessId = "<BUSINESS_ID>"
  ReferenceId = "demo_payment_code_id",
  ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
  CustomerName = "Rika Sutanto",
  Amount = 100,
  Currency = Currency.PHP,
  Market = Country.Philippines,
  PaymentCode = "12345678",
  Description = "Example updated payment code",
  IsSingleUse = true,
  Status = RetailOutletEnum.Status.Active,
  Metadata = null,
  CreatedAt = "2021-01-01T02:38:01.385383888Z",
  UpdatedAt = "2021-01-01T02:38:01.385383888Z",
  ExpiresAt = "2021-05-30T02:38:01.327283048Z",
}
```

#### Get Payment Code

```cs
FixedPaymentCode fixedPaymentCode = await RetailOutlet.GetPaymentCode("example_payment_code_id");
```

It will return:

```cs
FixedPaymentCode fixedPaymentCode = new FixedPaymentCode
{
  Id = "<GENERATED_ID>",
  BusinessId = "<BUSINESS_ID>"
  ReferenceId = "demo_payment_code_id",
  ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
  CustomerName = "Rika Sutanto",
  Amount = 50,
  Currency = Currency.PHP,
  Market = Country.Philippines,
  PaymentCode = "12345678",
  Description = "Example payment code",
  IsSingleUse = true,
  Status = RetailOutletEnum.Status.Active,
  Metadata = null,
  CreatedAt = "2021-01-01T02:38:01.385383888Z",
  UpdatedAt = "2021-01-01T02:38:01.385383888Z",
  ExpiresAt = "2021-05-30T02:38:01.327283048Z",
}
```

#### Get Payments By Payment Code ID

```cs
FixedPaymentCode[] fixedPaymentCodes = await RetailOutlet.GetPayments("example_payment_code_id");
```

It will return:

```cs
FixedPaymentCode[] fixedPaymentCodes = new FixedPaymentCode[]
{
  new FixedPaymentCode
  {
    Id = "<GENERATED_ID>",
    PaymentCodeId = "<PAYMENT_CODE_ID>"
    ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
    Amount = 50,
    Currency = Currency.PHP,
    PaymentCode = "12345678",
    Remarks = "<REMARKS>",
    Status = RetailOutletEnum.Status.Completed,
    CreatedAt = "2021-01-01T02:38:01.385383888Z",
    UpdatedAt = "2021-01-01T02:38:01.385383888Z",
  },
  // ...
}
```

### E-Wallet Service

#### Create E-Wallet Charge (API version `2020-01-25`)

To create an e-wallet charge, use struct `EWalletChargeParameter`. You may use these enums and classes to construct `EWalletChargeParameter`:

- Enum `Currency` for `Currency` property
- Enum `EWalletEnum.CheckoutMethod` for `CheckoutMethod` property
- Enum `EWalletEnum.ChannelCode` for `ChannelCode` property
- `EWalletChargeProperties` for `ChannelProperties` property
- `BasketItem` for `Basket` property

Here is the example of invoking `Create` method:

```cs
EWalletChargeParameter parameter = new EWalletChargeParameter
{
  ReferenceId = "demo-reference-id",
  Currency = Currency.IDR,
  Amount = 1000,
  CheckoutMethod = EWalletEnum.CheckoutMethod.OneTimePayment,
  ChannelCode = EWalletEnum.ChannelCode.IdOvo,
  ChannelProperties = new EWalletChargeProperties
  {
    MobileNumber = "+628123123123",
  },
};

EWalletChargeResponse eWalletCharge = await EWalletCharge.Create(parameter);

// define API version
EWalletChargeResponse eWalletCharge = await EWalletCharge.Create(parameter, apiVersion: ApiVersion.Version20210125);
```

It will return:

```cs
EWalletChargeResponse eWalletCharge = new EWalletChargeResponse
{
  Id = "<GENERATED_ID>",
  BusinessId = "<MERCHANT_BUSINESS_ID>",
  ReferenceId = "demo-reference-id",
  Status = EWalletEnum.Status.Pending,
  Currency = Currency.IDR,
  ChargeAmount = 1000,
  CaptureAmount = 1000,
  CheckoutMethod = EWalletEnum.CheckoutMethod.OneTimePayment,
  ChannelCode = EWalletEnum.ChannelCode.IdOvo,
  ChannelProperties = new EWalletChargeProperties
  {
    MobileNumber = "+628123123123",
  },
  Actions = null,
  IsRedirectRequired = false,
  CallbackUrl = "<CALLBACK_URL",
  Created = "2017-07-21T17:32:28Z",
  Updated = "2017-07-21T17:32:28Z",
  Voided = null,
  customerId = null,
  PaymentMethodId = null,
  FailureCode = null,
  Basket = null,
  Metadata = null,
};
```

#### Get E-Wallet Charge (API version `2020-01-25`)

```cs
EWalletChargeResponse eWalletCharge = await EWalletCharge.Get("CHARGE_ID");
```

It will return:

```cs
EWalletChargeResponse eWalletCharge = new EWalletChargeResponse
{
  Id = "<GENERATED_ID>",
  BusinessId = "<MERCHANT_BUSINESS_ID>",
  ReferenceId = "demo-reference-id",
  Status = EWalletEnum.Status.Pending,
  Currency = Currency.IDR,
  ChargeAmount = 1000,
  CaptureAmount = 1000,
  CheckoutMethod = EWalletEnum.CheckoutMethod.OneTimePayment,
  ChannelCode = EWalletEnum.ChannelCode.IdOvo,
  ChannelProperties = new EWalletChargeProperties
  {
    MobileNumber = "+628123123123",
  },
  Actions = null,
  IsRedirectRequired = false,
  CallbackUrl = "<CALLBACK_URL",
  Created = "2017-07-21T17:32:28Z",
  Updated = "2017-07-21T17:32:28Z",
  Voided = null,
  customerId = null,
  PaymentMethodId = null,
  FailureCode = null,
  Basket = null,
  Metadata = null,
};
```

#### Create E-Wallet Payment (API version `2020-02-01`)

To create an e-wallet Payment, use struct `EWalletPaymentParameter`. You may use these enum and class to construct `EWalletPaymentParameter`:

- Enum `EWalletEnum.PaymentType` for `EWalletType` property
- `Item` for `Items` property

Here is the example of invoking `Create` method:

```cs
EWalletPaymentParameter parameter = new EWalletPaymentParameter
{
  ExternalId = "example-external-id",
  Amount = 100000,
  Phone = "08123123123",
  EWalletType = EWalletEnum.PaymentType.Ovo,
};

// if we don't pass API version parameter, it uses default value of API version 2020-02-01
EWalletPaymentResponse eWalletPayment = await EWalletPayment.Create(parameter);

// define API version
EWalletPaymentResponse eWalletPayment = await EWalletPayment.Create(parameter, apiVersion: ApiVersion.Version20200201);
```

It will return:

```cs
EWalletPaymentResponse eWalletPayment = new EWalletPaymentResponse
{
  BusinessId = "<MERCHANT_BUSINESS_ID>",
  ExternalId = "example-external-id",
  Amount = 100000,
  Phone = "08123123123",
  EWalletType = EWalletEnum.PaymentType.Ovo,
  Status = EWalletEnum.Status.Pending,
  Created = "2020-02-20T00:00:00.000Z",
};
```

#### Create E-Wallet Payment (API version `2019-02-04`)

To create an e-wallet Payment, use struct `EWalletPaymentParameter`. You may use these enum and class to construct `EWalletPaymentParameter`:

- Enum `EWalletEnum.PaymentType` for `EWalletType` property
- `Item` for `Items` property

Here is the example of invoking `Create` method of API version `2019-02-04`:

```cs
EWalletPaymentParameter parameter = new EWalletPaymentParameter
{
  ExternalId = "example-external-id",
  Amount = 100000,
  Phone = "08123123123",
  EWalletType = EWalletEnum.PaymentType.Ovo,
};

// define API version
EWalletPaymentResponse eWalletPayment = await EWalletPayment.Create(parameter, apiVersion: ApiVersion.Version20190204);
```

It will return:

```cs
EWalletPaymentResponse eWalletPayment = new EWalletPaymentResponse
{
  BusinessId = "<MERCHANT_BUSINESS_ID>",
  ExternalId = "example-external-id",
  Amount = 100000,
  Phone = "08123123123",
  EWalletType = EWalletEnum.PaymentType.Ovo,
  Status = EWalletEnum.Status.Pending,
  Created = "2020-02-20T00:00:00.000Z",
};
```

#### Get E-Wallet Payment

```cs
EWalletPaymentResponse eWalletPayment = await EWalletPayment.Get("example-external-id", EWalletEnum.PaymentType.Ovo);
```

It will return:

```cs
EWalletPaymentResponse eWalletPayment = new EWalletPaymentResponse
{
  BusinessId = "<MERCHANT_BUSINESS_ID>",
  ExternalId = "example-external-id",
  Amount = 100000,
  Phone = "08123123123",
  EWalletType = EWalletEnum.PaymentType.Ovo,
  Status = EWalletEnum.Status.Completed,
  TransactionDate = "2020-02-20T00:00:00.000Z",
};
```
