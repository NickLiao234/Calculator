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
        private readonly CalculatorViewModel _viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public AddService(CalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// 加法
        /// </summary>
        public void Add()
        {
            var result = Convert.ToDecimal(_viewModel.HistoryValue) + Convert.ToDecimal(_viewModel.CurrentValue);
            _viewModel.HistoryValue = result.ToString();
            _viewModel.CurrentValue = "0";
        }
    }
}
