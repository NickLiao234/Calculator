using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕清除所有運算式
    /// </summary>
    public class ButtonClear : ButtonBase
    {
        /// <summary>
        /// 清除所有運算式服務
        /// </summary>
        private readonly IClearService clearService;

        /// <summary>
        /// 建構式注入清除所有運算式服務
        /// </summary>
        /// <param name="clearService">clearService</param>
        public ButtonClear(IClearService clearService)
        {
            this.clearService = clearService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            clearService.Clear();
        }
    }
}
