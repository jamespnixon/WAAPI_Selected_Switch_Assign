using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WAAPI_Selected_Switch_Assign
{
    class Program
    {
        public static void Main(string[] args)
        {
            _Main().Wait();
        }

        static async Task _Main()
        {

            var client = CreateConnection().Result;


            await GetSelectedSwitchContainer(client);
            await client.Close();

          
        }

        private static async Task GetSelectedSwitchContainer(AK.Wwise.Waapi.JsonClient client)
        {
            SelectedSwitchContainer selectedSwitchContainer = new SelectedSwitchContainer();

            var options = new JObject
                (
                    new JProperty("return", new string[] { "name", "id", "type"})
                );    

            try
            {
                var results = await client.Call(
                    ak.wwise.ui.getSelectedObjects,
                    null,
                    options);

                Console.WriteLine(results);
                Console.WriteLine();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static async Task<AK.Wwise.Waapi.JsonClient> CreateConnection()
        {

            AK.Wwise.Waapi.JsonClient client = new AK.Wwise.Waapi.JsonClient();

            await client.Connect();

            client.Disconnected += () =>
            {
                System.Console.WriteLine("We lost connection!");
            };

            return client;
        }
    }
}
