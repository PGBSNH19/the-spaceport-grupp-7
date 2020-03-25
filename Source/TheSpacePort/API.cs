using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TheSpacePort
{
    public class API
    {

        public static IRestResponse<SwapiResponse> GetPersonData(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<SwapiResponse>(request);
            return apiResponse;
        }

        public static bool IsValidPerson(string name)
        {
            var response = GetPersonData(($"people/?search={name}"));
            foreach (var p in response.Data.Results)
            {
                if (p.Name == name)
                {
                    return true;
                }
            }
            return false;

        }
    }
}