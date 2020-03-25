using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Globalization;

namespace TheSpacePort
{
    public class API
    {
        public string StarshipURL { get; set; }

        public static IRestResponse<SwapiPersonResponse> GetPersonData(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<SwapiPersonResponse>(request);
            return apiResponse;
        }

        public Person GetPerson(string name)
        {
            Person person = new Person();

            var response = GetPersonData(($"people/?search={name}"));
            foreach (var p in response.Data.Results)
            {
                if (p.Name == name)
                { 
                    return p;
                }
            }
            return null;
        }



        public static IRestResponse<SwapiStarshipResponse> GetStarshipData(string input)
        {
            var client = new RestClient(input);
            var request = new RestRequest("", DataFormat.Json);
            var apiResponse = client.Get<SwapiStarshipResponse>(request);
                       
            return apiResponse;
        }

        public Starship GetStarship(string starshipUrl)
        {
            Starship starship = new Starship();
            var response = GetStarshipData(starshipUrl);
            starship.Name = response.Data.Name;
            starship.Length = Convert.ToDecimal(starship.Length, CultureInfo.InvariantCulture);
            return starship;
        }




    }
}