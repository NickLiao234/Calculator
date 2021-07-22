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
        /// editViewModelService
        /// </summary>
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// API取得結果服務
        /// </summary>
        private readonly IGetResultByWebAPIService getResultByWebAPIService;

        /// <summary>
        /// 建構式注入服務
        /// </summary>
        /// <param name="editViewModelService">editViewModelService</param>
        /// <param name="getResultByWebAPIService">API取得結果服務</param>
        public ButtonReverse(
            IEditViewModelService editViewModelService,
            IGetResultByWebAPIService getResultByWebAPIService)
        {
            this.editViewModelService = editViewModelService;
            this.getResultByWebAPIService = getResultByWebAPIService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override async void Excute()
        {
            editViewModelService.AddOperand();
            editViewModelService.AddOperator("negate");
            var result = await getResultByWebAPIService.GetResultAsync();
            var expression = await getResultByWebAPIService.GetCurrentExpression();
            editViewModelService.SetExpressionList(expression);
            editViewModelService.SetCurrentValue(result);
            editViewModelService.ClearCurrentValue();
            editViewModelService.SetHistoryValue();
        }
    }
}
