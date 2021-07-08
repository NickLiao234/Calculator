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
        /// calculateExpressionService
        /// </summary>
        private readonly ICalculateExpressionService calculateExpressionService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="value">顯示值</param>
        /// <param name="modelService">EditViewModelService</param>
        /// <param name="calculateExpressionService">calculateExpressionService</param>
        public ButtonOperators(
            string value,  
            IEditViewModelService modelService,
            ICalculateExpressionService calculateExpressionService)
        {
            this.value = value;
            this.modelService = modelService;
            this.calculateExpressionService = calculateExpressionService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            modelService.AddOperand();
            //TODO Check if "(" count == ")" count true: getresult else pass

            //var result = calculateExpressionService.GetResult();
            //modelService.SetHistoryValue(result);
            modelService.AddOperator(value);
            modelService.ClearCurrentValue();
            modelService.SetHistoryValue();
        }
    }
}
