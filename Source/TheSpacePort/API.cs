using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TheSpacePort
{
    public class API
    {

        public static void GetTraveler()
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = client.Get<SwapiResponse>(request);

            //Console.WriteLine(peopleResponse.Data.Count);
            foreach (var p in peopleResponse.Data.Results)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}