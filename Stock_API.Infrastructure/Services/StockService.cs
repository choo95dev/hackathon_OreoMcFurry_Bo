using Microsoft.Extensions.Configuration;
using Stock_API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Stock_API.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        private string ApiKey;
        private string Host;

        public StockService(HttpClient client, IConfiguration configuration)
        {
            _configuration = configuration;

            client.BaseAddress = new Uri(_configuration["Integration:URI"]);

            _client = client;  
        }


        public async Task<string> GetStockValue(string symbol,string interval,int outputsize =30,string format="json")
        {
            var endpoint = "";
            using var httpResponse = await _client.GetAsync(endpoint);
            httpResponse.EnsureSuccessStatusCode();

            var body = await httpResponse.Content.ReadAsStringAsync();

            return body;

        }
    }
}
