﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CraftsmanApp.Configuration;
using CraftsmanApp.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CraftsmanApp.Services
{
    public class ToolClient
    {
        private readonly HttpClient _client;

        public ToolClient(HttpClient client)
        {
            var host = AppConfig.GetServiceIP;
            var port = AppConfig.GetServicePort;
            var baseAdd = "http://" + host + ":" + port + "/";
            _client = client;
            _client.BaseAddress = new Uri(baseAdd + "api/tool/");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");

        }

        public async Task<IEnumerable<Tool>> GetAll()
        {
            var result = await _client.GetAsync("", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            using var streamReader = new StreamReader(await result.Content.ReadAsStreamAsync());
            await using var contentStream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Tool>>(contentStream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            });
        }

        public async Task<Tool> Get(string id)
        {
            var result = await _client.GetAsync(id, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            using var streamReader = new StreamReader(await result.Content.ReadAsStreamAsync());
            await using var contentStream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Tool>(contentStream, new JsonSerializerOptions
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

        public async Task Insert(Tool tool)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new StringContent(JsonConvert.SerializeObject(tool), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(string id, Tool tool)
        {
            var content = new StringContent(JsonConvert.SerializeObject(tool), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
