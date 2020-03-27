using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading.Tasks;

namespace TheSpacePort
{
    public class API
    {
        // Spy: @Group 1, the asynch Task methods
        public string StarshipURL { get; set; }

        private static readonly RestClient client = new RestClient("https://swapi.co/api/");

        public async Task<IRestResponse> GetPersonData(string name)
        {
            var request = new RestRequest("people/?search=" + name, DataFormat.Json);
            var response = client.ExecuteAsync<SwapiPersonResponse>(request);

            return await response;
        }

        public Person GetPerson(string name)
        {
            var dataResponse = GetPersonData(name);
            var data = JsonConvert.DeserializeObject<SwapiPersonResponse>(dataResponse.Result.Content);

            if (data.Results.Count == 0)
            {
                return null;
            }

            else if(data.Results[0].Name == name)
            {
                return data.Results[0];
            }
            
            else
            {
                return null;
            }
        }

        public async Task<IRestResponse> GetStarshipData(string URL)
        {
            var request = new RestRequest(URL, DataFormat.Json);
            var response = client.ExecuteAsync<SwapiStarshipResponse>(request);

            return await response;
        }
        public Starship GetStarship(string starShipURL)
        {
            Starship starship = new Starship();
            var response = GetStarshipData(starShipURL);
            var data = JsonConvert.DeserializeObject<SwapiStarshipResponse>(response.Result.Content);

            starship.Name = data.Name;
            starship.Length = Convert.ToDecimal(data.Length, CultureInfo.InvariantCulture);

            return starship;
        }
    }
}