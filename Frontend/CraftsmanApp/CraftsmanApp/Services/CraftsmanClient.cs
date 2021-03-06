﻿using CraftsmanApp.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CraftsmanApp.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CraftsmanApp.Services
{
    public class CraftsmanClient
    {
        private readonly HttpClient _client;

        public CraftsmanClient(HttpClient client)
        {
            var host = AppConfig.GetServiceIP;
            var port = AppConfig.GetServicePort;
            var baseAdd = "http://" + host + ":" + port + "/";
            _client = client;
            _client.BaseAddress = new Uri(baseAdd + "api/craftsmen/");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
             
        }

        public async Task<IEnumerable<Models.Craftsman>> GetAll()
        {
            var result = await _client.GetAsync("", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            using var streamReader = new StreamReader(await result.Content.ReadAsStreamAsync());
            await using var contentStream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Models.Craftsman>>(contentStream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            }); 
        }

        public async Task<Models.Craftsman> Get(string id)
        {
            var result = await _client.GetAsync(id, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            using var streamReader = new StreamReader(await result.Content.ReadAsStreamAsync());
            await using var contentStream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Models.Craftsman>(contentStream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            });
        }

        public async Task Delete(string id)
        { 
            var response = await _client.DeleteAsync(id);
            response.EnsureSuccessStatusCode();
        }

        public async Task Insert(Craftsman craftsman)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new StringContent(JsonConvert.SerializeObject(craftsman), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(string id, Craftsman craftsman)
        {
            var content = new StringContent(JsonConvert.SerializeObject(craftsman), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("", content);
            response.EnsureSuccessStatusCode();
        } 
    }
}
