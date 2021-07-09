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
    /// <summary>
    /// 取得結果服務實作
    /// </summary>
    public class GetResultByWebAPIService : IGetResultByWebAPIService
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly IHttpClientFactory httpClient;

        /// <summary>
        /// ViewModel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="viewModel">ViewModel</param>
        public GetResultByWebAPIService(IHttpClientFactory httpClient, CalculatorViewModel viewModel)
        {
            this.httpClient = httpClient;
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 取得運算結果
        /// </summary>
        /// <returns>運算結果</returns>
        public async Task<string> GetResultAsync()
        {
            var result = await SendPostAsync("result");

            return result;
        }

        /// <summary>
        /// 取得中序表達式
        /// </summary>
        /// <returns>表達式</returns>
        public async Task<string> GetInfixAsync()
        {
            var result = await SendPostAsync("infix");

            return result;
        }

        /// <summary>
        /// 取得前序表達式
        /// </summary>
        /// <returns>表達式</returns>
        public async Task<string> GetPrefixAsync()
        {
            var result = await SendPostAsync("prefix");

            return result;
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <returns>表達式</returns>
        public async Task<string> GetPostfixAsync()
        {
            var result = await SendPostAsync("postfix");

            return result;
        }

        /// <summary>
        /// 發出Post請求方法
        /// </summary>
        /// <param name="uri">route</param>
        /// <returns>字串</returns>
        private async Task<string> SendPostAsync(string uri)
        {
            var expression = viewModel.Expression;

            var requestBody = new StringContent(
                JsonSerializer.Serialize(expression),
                Encoding.UTF8,
                "application/json");

            var client = httpClient.CreateClient("CalculateService");

            var response = await client.PostAsync(uri, requestBody);

            string result;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result = "錯誤的運算子";
                }
                else
                {
                    result = "系統異常";
                }
            }

            return result;
        }
    }
}
