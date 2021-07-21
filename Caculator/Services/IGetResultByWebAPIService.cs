using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 取得結果服務介面
    /// </summary>
    public interface IGetResultByWebAPIService
    {
        /// <summary>
        /// 取得運算結果
        /// </summary>
        /// <returns>decimal</returns>
        public Task<string> GetResultAsync();

        /// <summary>
        /// 取得目前合法表達式
        /// </summary>
        /// <returns>表達式字串</returns>
        public Task<List<string>> GetCurrentExpression();

        /// <summary>
        /// 取得中序表達式
        /// </summary>
        /// <returns>表達式</returns>
        public Task<string> GetInfixAsync();

        /// <summary>
        /// 取得前序表達式
        /// </summary>
        /// <returns>表達式</returns>
        public Task<string> GetPrefixAsync();

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <returns>表達式</returns>
        public Task<string> GetPostfixAsync();
    }
}