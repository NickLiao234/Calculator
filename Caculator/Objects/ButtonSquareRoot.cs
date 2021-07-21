using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 開根號類別
    /// </summary>
    public class ButtonSquareRoot : ButtonBase
    {
        /// <summary>
        /// 開根號服務
        /// </summary>
        private readonly ISquareRootService squareRootService;

        /// <summary>
        /// editViewModelService
        /// </summary>
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 清除服務
        /// </summary>
        private readonly IClearService clearService;

        /// <summary>
        /// 透過API取得結果服務
        /// </summary>
        private readonly IGetResultByWebAPIService getResultByWebAPIService;

        /// <summary>
        /// 初始化開根號服務
        /// </summary>
        /// <param name="squareRootService">開根號服務</param>
        /// <param name="editViewModelService">editViewModelService</param>
        /// <param name="clearService">清除服務</param>
        /// <param name="getResultByWebAPIService">透過API取得結果服務</param>
        public ButtonSquareRoot(
            ISquareRootService squareRootService, 
            IEditViewModelService editViewModelService, 
            IClearService clearService,
            IGetResultByWebAPIService getResultByWebAPIService)
        {
            this.squareRootService = squareRootService;
            this.editViewModelService = editViewModelService;
            this.clearService = clearService;
            this.getResultByWebAPIService = getResultByWebAPIService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override async void Excute()
        {
            //try
            //{
            //    squareRootService.SquareRoot();
            //}
            //catch (Exception ex)
            //{
            //    clearService.Clear();
            //    editViewModelService.SetCurrentValue(ex.Message);
            //}
            editViewModelService.AddOperand();
            editViewModelService.AddOperator("²√");
            var result = await getResultByWebAPIService.GetResultAsync();
            var expression = await getResultByWebAPIService.GetCurrentExpression();
            editViewModelService.SetExpressionList(expression);
            editViewModelService.SetCurrentValue(result);
            editViewModelService.ClearCurrentValue();
            editViewModelService.SetHistoryValue();
        }
    }
}
