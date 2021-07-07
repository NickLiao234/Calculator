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
        /// API取得結果服務
        /// </summary>
        private readonly IGetResultByWebAPIService getResultByWebAPIService;

        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="editViewModelService">editViewModelService</param>
        /// <param name="calculateExpressionService">calculateExpressionService</param>
        /// <param name="clearService">clearService</param>
        /// <param name="getResultByWebAPIService">API取得結果服務</param>
        public ButtonEqual(
            IEditViewModelService editViewModelService,
            ICalculateExpressionService calculateExpressionService,
            IClearService clearService,
            IGetResultByWebAPIService getResultByWebAPIService
            )
        {
            this.editViewModelService = editViewModelService;
            this.calculateExpressionService = calculateExpressionService;
            this.clearService = clearService;
            this.getResultByWebAPIService = getResultByWebAPIService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override async void Excute()
        {
            editViewModelService.AddOperand();
            //TODO Check if "(" count == ")" count true: getresult else add ")" count = "(" count

            //var result = calculateExpressionService.GetResult();
            var result = await getResultByWebAPIService.GetResultAsync();
            var postfix = await getResultByWebAPIService.GetPostfixAsync();
            var prefix = await getResultByWebAPIService.GetPrefixAsync();
            var infix = await getResultByWebAPIService.GetInfixAsync();
            clearService.Clear();
            editViewModelService.SetHistoryValue(result);
            editViewModelService.SetCurrentValue(result.ToString());
            editViewModelService.SetInfixValue(infix);
            editViewModelService.SetPrefixValue(prefix);
            editViewModelService.SetPostfixValue(postfix);
        }
    }
}
