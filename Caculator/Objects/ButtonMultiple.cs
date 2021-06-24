using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕Sub
    /// </summary>
    public class ButtonMultiple : ButtonBase
    {
        /// <summary>
        /// Multiple服務
        /// </summary>
        private readonly IMultipleService multipleService;

        /// <summary>
        /// 建構式注入Multiple服務
        /// </summary>
        /// <param name="multipleService">multipleService</param>
        public ButtonMultiple(IMultipleService multipleService)
        {
            this.multipleService = multipleService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            multipleService.Multiple();
        }
    }
}
