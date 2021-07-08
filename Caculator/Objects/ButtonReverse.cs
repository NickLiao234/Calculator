using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕+-
    /// </summary>
    public class ButtonReverse : ButtonBase
    {
        /// <summary>
        /// appendService
        /// </summary>
        private readonly IReverseService reverseService;
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 建構式注入appendService
        /// </summary>
        /// <param name="reverseService">reverseService</param>
        public ButtonReverse(
            IReverseService reverseService,
            IEditViewModelService editViewModelService)
        {
            this.reverseService = reverseService;
            this.editViewModelService = editViewModelService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            reverseService.Reverse();
            editViewModelService.SetHistoryValue();
        }
    }
}
