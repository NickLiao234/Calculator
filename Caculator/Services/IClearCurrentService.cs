using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 清除目前運算子服務介面
    /// </summary>
    public interface IClearCurrentService
    {
        /// <summary>
        /// 清除目前運算子方法
        /// </summary>
        public void ClearCurrent();
    }
}
