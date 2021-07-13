using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Xendit.net.Model
{
    public class VirtualAccount
    {
        public static Task<List<AvailableBank>> GetAvailableBanks()
        {
            return GetAvailableBanks(new Dictionary<string, string>());
        }

        public static async Task<List<AvailableBank>> GetAvailableBanks(Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/available_virtual_account_banks");

            var result = await XenditConfiguration.requestClient.Request(headers, url);
            var availableBanks = await JsonSerializer.DeserializeAsync<List<AvailableBank>>(result);
            return availableBanks;
        }
    }
}
