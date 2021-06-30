using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕 =
    /// </summary>
    public class ButtonEqual : ButtonBase
    {
        /// <summary>
        /// editViewModelService
        /// </summary>
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// calculateExpressionService
        /// </summary>
        private readonly ICalculateExpressionService calculateExpressionService;

        /// <summary>
        /// clearService
        /// </summary>
        private readonly IClearService clearService;

        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="editViewModelService">editViewModelService</param>
        /// <param name="calculateExpressionService">calculateExpressionService</param>
        /// <param name="clearService">clearService</param>
        public ButtonEqual(
            IEditViewModelService editViewModelService,
            ICalculateExpressionService calculateExpressionService,
            IClearService clearService
            )
        {
            this.editViewModelService = editViewModelService;
            this.calculateExpressionService = calculateExpressionService;
            this.clearService = clearService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            editViewModelService.AddOperand();
            var result = calculateExpressionService.GetResult();
            clearService.Clear();
            editViewModelService.SetHistoryValue(result);
            editViewModelService.SetCurrentValue(result.ToString());
        }
    }
}
