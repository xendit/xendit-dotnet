# Xendit API .NET Library

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
