using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caculator.Services
{
    public interface IGetResultByWebAPIService
    {
        public Task<decimal> GetResultAsync();

        public Task<string> GetInfixAsync();

        public Task<string> GetPrefixAsync();

        public Task<string> GetPostfixAsync();
    }
}