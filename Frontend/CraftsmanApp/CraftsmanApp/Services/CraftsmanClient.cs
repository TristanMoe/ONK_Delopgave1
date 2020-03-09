using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            var host = Environment.GetEnvironmentVariable("host");
            var port = Environment.GetEnvironmentVariable("port");
            var baseAdd = "http://" + host + ":" + port + "/";
            _client = client;
            _client.BaseAddress = new Uri(baseAdd + "/api/craftsmen/");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
             
        }

        public async Task<IEnumerable<Models.Craftsman>> GetAll()
        {
            var response = await _client.GetAsync("");
            response.EnsureSuccessStatusCode();
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Models.Craftsman>>(responseStream);
        }

        public async Task<Models.Craftsman> Get(string id)
        {
            var response = await _client.GetAsync(id);
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Models.Craftsman>(responseStream);
        }

        public async Task Delete(string id)
        {
            var response = await _client.DeleteAsync(id);
            response.EnsureSuccessStatusCode();
        }

        public async Task Insert(Craftsman craftsman)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/craftsmen/");
            var content = new StringContent(JsonConvert.SerializeObject(craftsman), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(string id, Craftsman craftsman)
        {
            var content = new StringContent(JsonConvert.SerializeObject(craftsman), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(id, content);
            response.EnsureSuccessStatusCode();
        } 
    }
}
