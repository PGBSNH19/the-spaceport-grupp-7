﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TheSpacePort
{
    public class API
    {
        public string VehicleURL { get; set; }

        public static IRestResponse<SwapiResponse> GetPersonData(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<SwapiResponse>(request);
            return apiResponse;
        }

        public bool IsValidPerson(string name)
        {
            var response = GetPersonData(($"people/?search={name}"));
            foreach (var p in response.Data.Results)
            {
                if (p.Name == name)
                {
                    VehicleURL = p.Vehicles[0];
                    GetShipData(VehicleURL);
                    return true;
                }
            }
            return false;
        }



        public static IRestResponse<SwapiResponse> GetShipData(string input)
        {
            var client = new RestClient(input);
            var request = new RestRequest("", DataFormat.Json);
            var apiResponse = client.Get<SwapiResponse>(request);
            return apiResponse;
        }

        public static bool IsValidShip(string starships)
        {
            var response = GetPersonData(($"people/?search={starships}"));
            foreach (var p in response.Data.Results)
            {
                if (p.Name == starships)
                {
                    return true;
                }
            }
            return false;
        }




    }
}