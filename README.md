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
      - [Closed Virtual Account](#closed-virtual-account)
      - [Open Virtual Account](#open-virtual-account)
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

The `accountType` parameter is optional. You can use `accountType` in enum or in string type (`"Cash"`, `"Holding"`, `"Tax"`)

```cs
await Balance.Get();

await Balance.Get(AccountType.Holding);

await Balance.Get("Tax");
```

```cs
Balance balance = await Balance.Get();
```

### Virtual Account Services

#### Create a Virtual Account

You can choose whether want to put the attributes as parameters or to put in inside a Dictionary object.

##### Closed Virtual Account

<table>
<tr>
<td>
<pre>
VirtualAccount.CreateClosed(
    string externalId,
    string bankCode,
    string name,
    long expectedAmount,
    Dictionary&lt;string, object&gt; parameter
);
</pre>
</td>
<td>
<pre>
VirtualAccount.CreateClosed(
    Dictionary&lt;string, object&gt; parameter
);
</pre>
</td>
</tr>
</table>

```cs
Dictionary<string, object> closedVABody = new Dictionary<string, object>();
closedVABody.Add("external_id", "my_external_id");
closedVABody.Add("bank_code", "BNI");
closedVABody.Add("name", "John Doe");
closedVABody.Add("expected_amount", 200000000L);

VirtualAccount virtualAccount = await VirtualAccount.CreateClosed(closedVABody);
```

##### Open Virtual Account

<table>
<tr>
<td>
<pre>
VirtualAccount.CreateOpen(
    string externalId,
    string bankCode,
    string name,
    Dictionary&lt;string, object&gt; parameter
);
</pre>
</td>
<td>
<pre>
VirtualAccount.CreateOpen(
    Dictionary&lt;string, object&gt; parameter
);
</pre>
</td>
</tr>
</table>

```cs
Dictionary<string, object> openVAbody = new Dictionary<string, object>();
openVAbody.Add("external_id", "my_external_id");
openVAbody.Add("bank_code", "BNI");
openVAbody.Add("name", "John Doe");

VirtualAccount virtualAccount = await VirtualAccount.CreateOpen(openVAbody);
```

#### Get a Virtual Account by ID

```cs
VirtualAccount virtualAccount = await VirtualAccount.Get("VIRTUAL_ACCOUNT_ID");
```

#### Update a Virtual Account

```cs
Dictionary<string, object> parameter = new Dictionary<string, object>();
parameter.Add("is_single_use", true);

VirtualAccount virtualAccount = await VirtualAccount.Update("VIRTUAL_ACCOUNT_ID", parameter);
```

#### Get banks with available virtual account service

```cs
List<AvailableBank> availableBanks = await VirtualAccount.GetAvailableBanks();
```

#### Get a virtual account payment by payment ID

```cs
VirtualAccountPayment virtualAccountPayment = await VirtualAccountPayment.Get("VIRTUAL_ACCOUNT_PAYMENT_ID");
```

### Disbursement Services

#### Create a disbursement

You can choose whether want to put the attributes as parameters or to put in inside a Dictionary object.

<table>
<tr>
<td>
<pre>
Disbursement.Create(
    string externalId, 
    string bankCode, 
    string accountHolderName, 
    string accountNumber, 
    string description, 
    long amount
);
</pre>
</td>
<td>
<pre>
Disbursement.Create(
    string externalId, 
    string bankCode, 
    string accountHolderName, 
    string accountNumber, 
    string description, 
    long amount,
    Dictionary&lt;string, object&gt; params
);
</pre>
</td>
<td>
<pre>
Disbursement.Create(
    Dictionary&lt;string, object&gt; params
);
</pre>
</td>
</tr>
</table>

```cs
Dictionary<string, object> parameter = new Dictionary<string, object>()
{
  { "external_id", "disb-1475459775872" },
  { "bank_code", "BCA" },
  { "account_holder_name", "MICHAEL CHEN" },
  { "account_number", "1234567890" },
  { "description", "Reimbursement for shoes" },
  { "amount", 1 },
};

Disbursement disbursement = await Disbursement.Create(parameter);
```

#### Get a disbursement by ID

```cs
Disbursement disbursement = await Disbursement.GetById("disbursement_id");
```

#### Get a disbursement by External ID

```cs
Disbursement disbursement = await Disbursement.GetByExternalId("external_id");
```

#### Get banks with available disbursement service

```cs
AvailableBank[] availableBanks = await Disbursement.GetAvailableBanks();
```

### Invoice services

#### Create an invoice

To create an invoice, please use struct `InvoiceBody` for parameter body. You may use these classes to construct `InvoiceBody`:

- `ItemInvoice` for `Items` property
- `Customer` for `Customer` property
- `CustomerAddress` for `Addresses` property in `Customer`
- `FeeInvoice` for `Fees` property
- `CustomerNotificationPreferenceInvoice` for `CustomerNotificationPreference` property

Here is the example:

```cs
CustomerAddress addresses = new CustomerAddress
{
    Country = "ID",
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
    Addresses = new CustomerAddress[] { addresses },
};

CustomerNotificationPreferenceInvoice preference = new CustomerNotificationPreferenceInvoice
{
    InvoicePaid = new string[] { "email" }
};

ItemInvoice item = new ItemInvoice
{
    Name = "shoes",
    Quantity = 1,
    Price = 100,
};

FeeInvoice fee = new FeeInvoice
{
    Type = "ADMIN",
    Value = 200,
};

InvoiceBody parameter = new InvoiceBody
{
    ExternalId = "external-id",
    Amount = 1000,
    Customer = customer,
    CustomerNotificationPreference = preference,
    Items = new ItemInvoice[] { item },
    Fees = new FeeInvoice[] { fee },
    InvoiceDuration = 86400,
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
  Status = "PENDING",
  MerchantName = "<MERCHANT_NAME>",
  MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
  Amount = 1000,
  ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
  InvoiceUrl = "<INVOICE_URL>",
  AvailableBanks = new AvailableBankInvoice[]
  {
    new AvailableBankInvoice
    {
      BankCode = "Mandiri",
      CollectionType = "Pool",
      BankAccountNumber = "8860810000525",
      TransferAmount = 50000,
      BankBranch = "Virtual Account",
      AccountHolderName = "LANSUR13",
    },
    // ...
  },
  AvailableEwallets = new AvailableEwalletInvoice[]
  {
    new AvailableEwalletInvoice { EwalletType = "OVO" },
    // ...
  },
  AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
  {
    new AvailableRetailOutletInvoice
    {
      RetailOutletName = "ALFAMART",
      PaymentCode = "ALFA123456",
      TransferAmount = 50000,
    },
    // ...
  }
  ShouldExcludeCreditCard = false,
  ShouldSendEmail = false,
  Created = "<CREATED_TIMESTAMP>",
  Updated = "<UPDATED_TIMESTAMP>",
  Currency = "IDR",
  Fees = new FeeInvoice[] { new FeeInvoice { Type = "ADMIN", Value = 200 } },
  Customer = new Customer {
    GivenNames = "John",
    Email = "john@email.com",
    MobileNumber = "+6287774441111",
    Addresses = new CustomerAddress[] {
      new CustomerAddress {
        Country = "ID",
        StreetLine1 = "Jalan Makan",
        StreetLine2 = "Kecamatan Kebayoran Baru",
        City = "Jakarta Selatan",
        Province = "Daerah Khusus Ibukota Jakarta",
        PostalCode = "12345"
      }
    },
  },
  CustomerNotificationPreference = new CustomerNotificationPreference { InvoicePaid = new string[] { "email" } },
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
  Status = "PENDING",
  MerchantName = "<MERCHANT_NAME>",
  MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
  Amount = 1000,
  ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
  InvoiceUrl = "<INVOICE_URL>",
  AvailableBanks = new AvailableBankInvoice[]
  {
    new AvailableBankInvoice
    {
      BankCode = "Mandiri",
      CollectionType = "Pool",
      BankAccountNumber = "8860810000525",
      TransferAmount = 50000,
      BankBranch = "Virtual Account",
      AccountHolderName = "LANSUR13",
    },
    // ...
  },
  AvailableEwallets = new AvailableEwalletInvoice[]
  {
    new AvailableEwalletInvoice { EwalletType = "OVO" },
    // ...
  },
  AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
  {
    new AvailableRetailOutletInvoice
    {
      RetailOutletName = "ALFAMART",
      PaymentCode = "ALFA123456",
      TransferAmount = 50000,
    },
    // ...
  }
  ShouldExcludeCreditCard = false,
  ShouldSendEmail = false,
  Created = "<CREATED_TIMESTAMP>",
  Updated = "<UPDATED_TIMESTAMP>",
  Currency = "IDR",
  Fees = new FeeInvoice[] { new FeeInvoice { Type = "ADMIN", Value = 200 } },
  Customer = new Customer {
    GivenNames = "John",
    Email = "john@email.com",
    MobileNumber = "+6287774441111",
    Addresses = new CustomerAddress[] {
      new CustomerAddress {
        Country = "ID",
        StreetLine1 = "Jalan Makan",
        StreetLine2 = "Kecamatan Kebayoran Baru",
        City = "Jakarta Selatan",
        Province = "Daerah Khusus Ibukota Jakarta",
        PostalCode = "12345"
      }
    },
  },
  CustomerNotificationPreference = new CustomerNotificationPreference { InvoicePaid = new string[] { "email" } },
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
  new Invoice
  {
    Id = "610a306ffe63418fdb6bd0b3",
    ExternalId = "external-id",
    UserId = "<USER_ID>",
    Status = "PENDING",
    MerchantName = "<MERCHANT_NAME>",
    MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
    Amount = 1000,
    ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
    InvoiceUrl = "<INVOICE_URL>",
    AvailableBanks = new AvailableBankInvoice[]
    {
      new AvailableBankInvoice
      {
        BankCode = "Mandiri",
        CollectionType = "Pool",
        BankAccountNumber = "8860810000525",
        TransferAmount = 50000,
        BankBranch = "Virtual Account",
        AccountHolderName = "LANSUR13",
      },
      // ...
    },
    AvailableEwallets = new AvailableEwalletInvoice[]
    {
      new AvailableEwalletInvoice { EwalletType = "OVO" },
      // ...
    },
    AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
    {
      new AvailableRetailOutletInvoice
      {
        RetailOutletName = "ALFAMART",
        PaymentCode = "ALFA123456",
        TransferAmount = 50000,
      },
      // ...
    }
    ShouldExcludeCreditCard = false,
    ShouldSendEmail = false,
    Created = "<CREATED_TIMESTAMP>",
    Updated = "<UPDATED_TIMESTAMP>",
    Currency = "IDR",
    Fees = new FeeInvoice[] { new FeeInvoice { Type = "ADMIN", Value = 200 } },
    Customer = new Customer {
      GivenNames = "John",
      Email = "john@email.com",
      MobileNumber = "+6287774441111",
      Addresses = new CustomerAddress[] {
        new CustomerAddress {
          Country = "ID",
          StreetLine1 = "Jalan Makan",
          StreetLine2 = "Kecamatan Kebayoran Baru",
          City = "Jakarta Selatan",
          Province = "Daerah Khusus Ibukota Jakarta",
          PostalCode = "12345"
        }
      },
    },
    CustomerNotificationPreference = new CustomerNotificationPreference { InvoicePaid = new string[] { "email" } },
  }
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
  Status = "EXPIRED",
  MerchantName = "<MERCHANT_NAME>",
  MerchantProfilePictureUrl = "<MERCHANT_PROFILE_PICTURE_URL>",
  Amount = 1000,
  ExpiryDate = "<CREATED_DATE + INVOICE_DURATION>",
  InvoiceUrl = "<INVOICE_URL>",
  AvailableBanks = new AvailableBankInvoice[]
  {
    new AvailableBankInvoice
    {
      BankCode = "Mandiri",
      CollectionType = "Pool",
      BankAccountNumber = "8860810000525",
      TransferAmount = 50000,
      BankBranch = "Virtual Account",
      AccountHolderName = "LANSUR13",
    },
    // ...
  },
  AvailableEwallets = new AvailableEwalletInvoice[]
  {
    new AvailableEwalletInvoice { EwalletType = "OVO" },
    // ...
  },
  AvailableRetailOutlets = new AvailableRetailOutletInvoice[]
  {
    new AvailableRetailOutletInvoice
    {
      RetailOutletName = "ALFAMART",
      PaymentCode = "ALFA123456",
      TransferAmount = 50000,
    },
    // ...
  }
  ShouldExcludeCreditCard = false,
  ShouldSendEmail = false,
  Created = "<CREATED_TIMESTAMP>",
  Updated = "<EXPIRED_UPDATED_TIMESTAMP>",
  Currency = "IDR",
  Fees = new FeeInvoice[] { new FeeInvoice { Type = "ADMIN", Value = 200 } },
  Customer = new Customer {
    GivenNames = "John",
    Email = "john@email.com",
    MobileNumber = "+6287774441111",
    Addresses = new CustomerAddress[] {
      new CustomerAddress {
        Country = "ID",
        StreetLine1 = "Jalan Makan",
        StreetLine2 = "Kecamatan Kebayoran Baru",
        City = "Jakarta Selatan",
        Province = "Daerah Khusus Ibukota Jakarta",
        PostalCode = "12345"
      }
    },
  },
  CustomerNotificationPreference = new CustomerNotificationPreference { InvoicePaid = new string[] { "email" } },
};
```
