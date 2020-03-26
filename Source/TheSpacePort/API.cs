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

            if(data.Results[0].Name == name)
                return data.Results[0];

            return null;
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


        //public static IRestResponse<SwapiStarshipResponse> GetStarshipData(string input)
        //{
        //    var client = new RestClient(input);
        //    var request = new RestRequest("", DataFormat.Json);
        //    var apiResponse = client.Get<SwapiStarshipResponse>(request);

        //    return apiResponse;
        //}

        //public Starship GetStarship(string starshipUrl)
        //{
        //    Starship starship = new Starship();
        //    var response = GetStarshipData(starshipUrl);
        //    starship.Name = response.Data.Name;
        //    starship.Length = Convert.ToDecimal(response.Data.Length, CultureInfo.InvariantCulture);
        //    return starship;
        //}

        //public static IRestResponse<SwapiPersonResponse> GetPersonData(string input)
        //{
        //    var client = new RestClient("https://swapi.co/api/");
        //    var request = new RestRequest(input, DataFormat.Json);
        //    var apiResponse = client.Get<SwapiPersonResponse>(request);
        //    return apiResponse;
        //}

        //public Person GetPerson(string name)
        //{
        //    Person person = new Person();

        //    var response = GetPersonData(($"people/?search={name}"));
        //    foreach (var p in response.Data.Results)
        //    {
        //        if (p.Name == name)
        //        { 
        //            return p;
        //        }
        //    }
        //    return null;
        //}

    }
}