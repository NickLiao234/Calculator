using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕清除目前運算子
    /// </summary>
    public class ButtonClearCurrent : ButtonBase
    {
        /// <summary>
        /// 清除目前運算子服務
        /// </summary>
        private readonly IClearCurrentService clearCurrentService;

        /// <summary>
        /// 建構式注入清除目前運算子服務
        /// </summary>
        /// <param name="clearCurrentService">clearCurrentService</param>
        public ButtonClearCurrent(IClearCurrentService clearCurrentService)
        {
            this.clearCurrentService = clearCurrentService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            clearCurrentService.ClearCurrent();
        }
    }
}
