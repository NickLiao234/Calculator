using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 清除所有運算介面
    /// </summary>
    public class ClearService : IClearService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public ClearService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 清除方法
        /// </summary>
        public void Clear()
        {
            viewModel.HistoryValue = "0";
            viewModel.CurrentValue = "0";
            viewModel.ExpressionStack.Clear();
            viewModel.Expression.Clear();
            viewModel.Infix = "";
            viewModel.Prefix = "";
            viewModel.Postfix = "";
        }
    }
}
