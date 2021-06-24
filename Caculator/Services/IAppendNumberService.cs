using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 加入字元服務
    /// </summary>
    public interface IAppendNumberService
    {
        /// <summary>
        /// 加入字元方法
        /// </summary>
        /// <param name="appendString">加入字元</param>
        public void Append(string appendString);
    }
}
