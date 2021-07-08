using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 運算子按鈕
    /// </summary>
    public class ButtonOperand : ButtonBase
    {
        /// <summary>
        /// appendService
        /// </summary>
        private readonly IAppendNumberService appendNumberService;
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 按鈕字元
        /// </summary>
        private string value;

        /// <summary>
        /// 建構式注入appendService並初始化顯示值
        /// </summary>
        /// <param name="value">顯示值</param>
        /// <param name="appendNumberService">appendNumberService</param>
        public ButtonOperand(
            string value, 
            IAppendNumberService appendNumberService,
            IEditViewModelService editViewModelService)
        {
            this.value = value;
            this.appendNumberService = appendNumberService;
            this.editViewModelService = editViewModelService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            appendNumberService.Append(value);
            editViewModelService.SetHistoryValue();
        }
    }
}
