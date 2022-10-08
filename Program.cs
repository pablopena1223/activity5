using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Activity5
{
    class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("classification")]
        public string Class { get; set; }
        [JsonProperty("eye_colors")]
        public string Eye { get; set; }
        [JsonProperty("hair_colors")]
        public string Hair { get; set; }
    }

    class Pablo
    {
        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Species ID. Press Enter without writing a name to quit the program. ");

                    var speciesID = Console.ReadLine();

                    if (string.IsNullOrEmpty(speciesID))
                    {
                        break;
                    }
                    var result = await client.GetAsync("https://ghibliapi.herokuapp.com/species/" + speciesID.ToLower());
                    var resultRead = await result.Content.ReadAsStringAsync();
                    var species = JsonConvert.DeserializeObject<Species>(resultRead);

                    Console.WriteLine("---");
                    Console.WriteLine("Name: " + species.Name);
                    Console.WriteLine("Classification: " + species.Class);
                    Console.WriteLine("Eye colors: " + species.Eye);
                    Console.WriteLine("Hair colors " + species.Hair);
                    Console.WriteLine("\n---");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Please enter a valid Anime ID!");
                }
            }
        }
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
    }
}


