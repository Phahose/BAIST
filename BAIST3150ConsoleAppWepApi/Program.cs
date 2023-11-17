using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BAIST3150ConsoleAppWepApi.Domain;
namespace BAIST3150ConsoleAppWepApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
             using (HttpClient WebApiClient = new HttpClient())
             {
                MediaTypeWithQualityHeaderValue ContentType = new("application/json");
                WebApiClient.DefaultRequestHeaders.Accept.Add(ContentType);
                WebApiClient.BaseAddress = new Uri("https://localhost:44395/"); // Check the localhost Address Of Your Other Project 

                HttpResponseMessage WebApiResponseMessage;
                string WebAPiGetContent = string.Empty;
                string SerializedJson = string.Empty;
                StringContent WebApiPostPutContent;
                JsonSerializerOptions Options = new()
                {
                    PropertyNameCaseInsensitive = true, // default = false

                };

                // [HTTPGet]
              
                Console.WriteLine("----------------------");
                Console.WriteLine("HttpGet");
                Console.WriteLine("-----------------------");

                WebApiResponseMessage = await WebApiClient.GetAsync("/api/Items");
                WebAPiGetContent  = await WebApiResponseMessage.Content.ReadAsStringAsync();

                List<Item> ExampleItemsObjectCollection = JsonSerializer.Deserialize<List<Item>>(WebAPiGetContent,Options)!;

                foreach (Item exampleItem in ExampleItemsObjectCollection)
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine($"Item Number: {exampleItem.ItemNumber}");
                    Console.WriteLine($"Item Description: {exampleItem.Description}");
                    Console.WriteLine($"Item Unit Price: {exampleItem.UnitPrice}");
                    Console.WriteLine();
                }

                //[HTTPGet("{ItemNumber}")]
                Console.WriteLine("------------------------");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("[HTTPGet({ItemNumber})]");
                Console.WriteLine("------------------------");

                string? ItemNumber;
                Console.WriteLine("Enter The Item Number");
                ItemNumber = Console.ReadLine();
                
                WebApiResponseMessage = await WebApiClient.GetAsync($"/api/Items/{ItemNumber}");
                WebAPiGetContent = await WebApiResponseMessage.Content.ReadAsStringAsync();
                Item ExampleItem = JsonSerializer.Deserialize<Item>(WebAPiGetContent, Options)!;

                Console.WriteLine("---------------------");
                Console.WriteLine($"Item Number: {ExampleItem.ItemNumber}");
                Console.WriteLine($"Item Description: {ExampleItem.Description}");
                Console.WriteLine($"Item Unit Price: {ExampleItem.UnitPrice}");
                Console.WriteLine();

                //[HTTPPost]

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("---------------------");
                Console.WriteLine("HttpPost");
                Console.WriteLine("---------------------");

                ExampleItem.ItemNumber = 999;
                ExampleItem.Description = "HttpPost New Description";
                ExampleItem.UnitPrice = (decimal)1.11;


                SerializedJson = JsonSerializer.Serialize(ExampleItem);
                WebApiPostPutContent = new StringContent(SerializedJson, System.Text.Encoding.UTF8,"application/json");

                WebApiResponseMessage = await WebApiClient.PostAsync("api/Items", WebApiPostPutContent);

                if (WebApiResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebApiResponseMessage.StatusCode + " Insert Successful");
                }
                else
                {
                    Console.WriteLine(WebApiResponseMessage.StatusCode + " Insert Unsuccessful");
                }


                // [HTTpPut("{ItemNumber}"]
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("------------------");
                Console.WriteLine("HttpPut");
                Console.WriteLine("------------------");
                int updateNo;
                Console.WriteLine("What do You want to Update");
                updateNo = int.Parse(Console.ReadLine()!);   
                ExampleItem.ItemNumber = 4;
                ExampleItem.Description = "Update description From HTTP Put";
                ExampleItem.UnitPrice = (decimal)4.44;

                SerializedJson = JsonSerializer.Serialize(ExampleItem);

                WebApiPostPutContent = new StringContent(SerializedJson,System.Text.Encoding.UTF8,"application/json");

                WebApiResponseMessage = await WebApiClient.PutAsync($"/api/Items/{updateNo}", WebApiPostPutContent);

                if (WebApiResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebApiResponseMessage.StatusCode + " Update Successful");
                }
                else
                {
                    Console.WriteLine(WebApiResponseMessage.StatusCode + " Update Unsuccessful");
                }

                //[HTTpDelete"{ItemNumber}"]

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------");
                Console.WriteLine("HttpDelete");
                Console.WriteLine("------------------");
                Console.WriteLine("What do you Want to Delete {Enter Item Number}");
                int delNo;
                delNo = int.Parse(Console.ReadLine()!);

                WebApiResponseMessage = await WebApiClient.DeleteAsync($"/api/Items/{delNo}");

                if (WebApiResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebApiResponseMessage.StatusCode + " Delete Successful");
                }
                else
                {
                    Console.WriteLine(WebApiResponseMessage.StatusCode + " Delete Unsuccessful");
                }
            }
            
        }
    }
}
