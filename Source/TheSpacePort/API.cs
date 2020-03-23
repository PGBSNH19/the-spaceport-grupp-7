using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TheSpacePort
{
    public class API
    {

        static void GetTraveler()
        {

            var client = new RestClient("https://swapi.co/api/%22");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = client.Get<SwAPIreponse>(request);

            Console.WriteLine(peopleResponse.Data.Count);
            foreach (var p in peopleResponse.Data.Results)
            {
                Console.WriteLine(p.Name);
            }

        }


    }
}
