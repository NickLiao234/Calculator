using Caculator.Services;
using Calculator;
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
        /// clearService
        /// </summary>
        private readonly IClearService clearService;

        /// <summary>
        /// API取得結果服務
        /// </summary>
        private readonly IGetResultByWebAPIService getResultByWebAPIService;

        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="editViewModelService">editViewModelService</param>
        /// <param name="clearService">clearService</param>
        /// <param name="getResultByWebAPIService">API取得結果服務</param>
        /// <param name="viewModel">viewmodel</param>
        public ButtonEqual(
            IEditViewModelService editViewModelService,
            IClearService clearService,
            IGetResultByWebAPIService getResultByWebAPIService,
            CalculatorViewModel viewModel
            )
        {
            this.editViewModelService = editViewModelService;
            this.clearService = clearService;
            this.getResultByWebAPIService = getResultByWebAPIService;
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override async void Excute()
        {
            editViewModelService.AddOperand();
            editViewModelService.AddOperator("=");            
            var result = await getResultByWebAPIService.GetResultAsync();
            var expression = await getResultByWebAPIService.GetCurrentExpression();
            string historyValue = "";
            foreach (var item in expression)
            {
                historyValue += $"{item} ";
            }
            var postfix = await getResultByWebAPIService.GetPostfixAsync();
            var prefix = await getResultByWebAPIService.GetPrefixAsync();
            var infix = await getResultByWebAPIService.GetInfixAsync();
            clearService.Clear();
            editViewModelService.SetHistoryValue(historyValue);
            editViewModelService.SetCurrentValue(result);
            editViewModelService.SetInfixValue(infix);
            editViewModelService.SetPrefixValue(prefix);
            editViewModelService.SetPostfixValue(postfix);
        }
    }
}
