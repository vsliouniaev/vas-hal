using System;
using System.Linq;
using System.Threading.Tasks;
using HalKit;
using VAS.Hal.Client.Models;

namespace VAS.Hal.Client
{
    class Program
    {
        public static async Task PagingExample()
        {
            var client = new HalClient(new HalKitConfiguration("http://test.dev.local/api"));
            var api = await client.GetRootAsync<Api>();

            // These two will be the same
            var embeddedFirstApiVersion = api.ApiVersion.First();
            var linkedApiVersion = client.GetAsync<ApiVersion>(api.ApiVersionLink).Result;
        }

        public static async Task<Workflow> RealisticExample()
        {
            var client = new HalClient(new HalKitConfiguration("http://test.dev.local/api/apiversion/1"));
            var api = await client.GetRootAsync<ApiVersion>();
            return await client.GetAsync<Workflow>(api.WorkflowLink, new {id = 1});
        }

        static void Main(string[] args)
        {
            var workflow = RealisticExample().Result;

            Console.WriteLine(workflow.Name);
            Console.ReadLine();
        }
    }
}
