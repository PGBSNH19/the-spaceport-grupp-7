using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace TheSpacePort
{
    public class API
    {
        public string VehicleURL { get; set; }

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



        public static IRestResponse<SwapiVehicleResponse> GetVehicleData(string input)
        {
            var client = new RestClient(input);
            var request = new RestRequest("", DataFormat.Json);
            var apiResponse = client.Get<SwapiVehicleResponse>(request);
            var starship = JsonConvert.DeserializeObject<Vehicle>(apiResponse.Content);
            return apiResponse;
        }

        public Vehicle GetVehicle(string vehicleUrl)
        {
            Vehicle vehicle = new Vehicle();
            var response = GetVehicleData(vehicleUrl);
            foreach (var p in response.Data.vehicles)
            {

                    return vehicle;
                
            }
            return null;
        }




    }
}