﻿using CraftsmanApp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CraftsmanApp.Services
{
    public class CraftsmanClient
    {
        private readonly HttpClient _httpClient;

        public CraftsmanClient(HttpClient client)
        {
            var host = AppConfig.GetServiceIP;
            var port = AppConfig.GetServicePort;
            var baseAdd = "http://" + host + ":" + port + "/";
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(baseAdd + "/api/craftsmen/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
             
        }

        public Models.Craftsman GetAll()
        {

        }
    }
}
