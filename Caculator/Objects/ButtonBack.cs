using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕倒退
    /// </summary>
    public class ButtonBack : ButtonBase
    {
        /// <summary>
        /// 倒退服務
        /// </summary>
        private readonly IBackService backService;

        /// <summary>
        /// editViewModelService
        /// </summary>
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 建構式注入倒退服務
        /// </summary>
        /// <param name="backService">backService</param>
        /// <param name="editViewModelService">editViewModelService</param>
        public ButtonBack(
            IBackService backService,
            IEditViewModelService editViewModelService)
        {
            this.backService = backService;
            this.editViewModelService = editViewModelService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            backService.Back();
            editViewModelService.SetHistoryValue();
        }
    }
}
