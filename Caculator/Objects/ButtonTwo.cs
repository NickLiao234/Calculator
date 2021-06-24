using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕2
    /// </summary>
    public class ButtonTwo : ButtonBase
    {
        /// <summary>
        /// appendService
        /// </summary>
        private readonly IAppendNumberService appendNumberService;

        /// <summary>
        /// 按鈕字元
        /// </summary>
        private const string value = "2";

        /// <summary>
        /// 建構式注入appendService
        /// </summary>
        /// <param name="appendNumberService">appendNumberService</param>
        public ButtonTwo(IAppendNumberService appendNumberService)
        {
            this.appendNumberService = appendNumberService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            appendNumberService.Append(value);
        }
    }
}