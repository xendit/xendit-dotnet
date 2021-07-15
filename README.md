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
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Xendit.net.Model;
using Xendit.net;
using Xendit.net.Network;

namespace XenditExample
{
    class ExampleGetBalance
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            Balance balance = await Balance.Get();
            Console.WriteLine(balance.Value);
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
