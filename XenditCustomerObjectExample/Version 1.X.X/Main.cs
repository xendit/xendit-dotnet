namespace XenditCustomerObjectExample
{
    using System;
    using System.Threading.Tasks;
    using Xendit.net.Exception;
    using XenditCustomerObjectExample;

    class MainEntry
    {
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            DotNetEnv.Env.Load();

            try {
                ExampleCreateCustomer exampleCreate = new ExampleCreateCustomer();
                ExampleGetCustomer exampleGet = new ExampleGetCustomer();
                ExampleUpdateCustomer exampleUpdate = new ExampleUpdateCustomer();
                await exampleCreate.CreateCustomer20200519();
                await exampleCreate.CreateCustomer20201031WithMinimalInput();
                await exampleCreate.CreateCustomer20201031WithIndividualDetail();
                await exampleCreate.CreateCustomer20201031WithBusinessDetail();
                await exampleGet.GetCustomerDefault();
                await exampleGet.GetCustomerCustomVersion20200519();
                await exampleUpdate.UpdateCustomer20200519();
                await exampleUpdate.UpdateCustomer20201031();
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
