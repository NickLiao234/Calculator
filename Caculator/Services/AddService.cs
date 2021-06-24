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
    public class AddService : IAddService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public AddService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 加法
        /// </summary>
        public void Add()
        {
            if (!viewModel.IsCurrentEdited())
            {
                return;
            }

            var result = Convert.ToDecimal(viewModel.HistoryValue) + Convert.ToDecimal(viewModel.CurrentValue);
            viewModel.HistoryValue = result.ToString();
            viewModel.CurrentValue = "0";
        }
    }
}
