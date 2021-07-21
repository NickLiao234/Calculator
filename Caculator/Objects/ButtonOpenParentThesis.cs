using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 左括號類別
    /// </summary>
    public class ButtonOpenParentThesis : ButtonBase
    {
        /// <summary>
        /// 修改ViewModel服務
        /// </summary>
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 透過API取得結果服務
        /// </summary>
        private readonly IGetResultByWebAPIService getResultByWebAPIService;

        /// <summary>
        /// 初始化注入修改ViewModel服務
        /// </summary>
        /// <param name="editViewModelService">ViewModel服務</param>
        /// <param name="getResultByWebAPIService">透過API取得結果服務</param>
        public ButtonOpenParentThesis(
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
            editViewModelService.ClearCurrentValue();
            editViewModelService.AddOpenParentthesis();
            var result = await getResultByWebAPIService.GetResultAsync();
            var expression = await getResultByWebAPIService.GetCurrentExpression();
            editViewModelService.SetExpressionList(expression);
            editViewModelService.SetCurrentValue(result);
            editViewModelService.ClearCurrentValue();
            editViewModelService.SetHistoryValue();
        }
    }
}
