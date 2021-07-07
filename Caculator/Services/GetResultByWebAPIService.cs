using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Caculator.Services
{
    public class GetResultByWebAPIService : IGetResultByWebAPIService
    {
        private readonly IHttpClientFactory httpClient;
        private readonly CalculatorViewModel viewModel;

        public GetResultByWebAPIService(IHttpClientFactory httpClient, CalculatorViewModel viewModel)
        {
            this.httpClient = httpClient;
            this.viewModel = viewModel;
        }

        public async Task<decimal> GetResultAsync()
        {
            var result = await SendPostAsync("result");

            return Convert.ToDecimal(result);
        }

        public async Task<string> GetInfixAsync()
        {
            var result = await SendPostAsync("infix");

            return result;
        }

        public async Task<string> GetPrefixAsync()
        {
            var result = await SendPostAsync("prefix");

            return result;
        }

        public async Task<string> GetPostfixAsync()
        {
            var result = await SendPostAsync("postfix");

            return result;
        }



        private async Task<string> SendPostAsync(string uri)
        {
            var expression = viewModel.Expression;

            var requestBody = new StringContent(
                JsonSerializer.Serialize(expression),
                Encoding.UTF8,
                "application/json");

            var client = httpClient.CreateClient("CalculateService");

            using var response = await client.PostAsync(uri, requestBody);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
