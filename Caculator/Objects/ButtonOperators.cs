using Caculator.Objects.Operators;
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
    /// 運算元類別
    /// </summary>
    public class ButtonOperators : ButtonBase
    {
        /// <summary>
        /// 顯示值
        /// </summary>
        private readonly string value;

        /// <summary>
        /// EditViewModelService
        /// </summary>
        private readonly IEditViewModelService modelService;

        /// <summary>
        /// getResultByWebAPIService
        /// </summary>
        private readonly IGetResultByWebAPIService getResultByWebAPIService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="value">顯示值</param>
        /// <param name="modelService">EditViewModelService</param>
        /// <param name="getResultByWebAPIService">getResultByWebAPIService</param>
        public ButtonOperators(
            string value,  
            IEditViewModelService modelService,
            IGetResultByWebAPIService getResultByWebAPIService)
        {
            this.value = value;
            this.modelService = modelService;
            this.getResultByWebAPIService = getResultByWebAPIService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override async void Excute()
        {
            modelService.AddOperand();
            var result = await getResultByWebAPIService.GetResultAsync();
            modelService.SetCurrentValue(result);
            modelService.AddOperator(value);
            modelService.ClearCurrentValue();
            modelService.SetHistoryValue();
        }
    }
}
