using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 加法服務
    /// </summary>
    public class SubService : ISubService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public SubService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 減法
        /// </summary>
        public void Sub()
        {
            if (!viewModel.IsCurrentEdited())
            {
                return;
            }

            var result = Convert.ToDecimal(viewModel.HistoryValue) - Convert.ToDecimal(viewModel.CurrentValue);
            viewModel.HistoryValue = result.ToString();
            viewModel.CurrentValue = "0";
        }
    }
}
