using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 清除目前運算子服務
    /// </summary>
    public class ClearCurrentService : IClearCurrentService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public ClearCurrentService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 清除目前運算子方法
        /// </summary>
        public void ClearCurrent()
        {
            viewModel.CurrentValue = "0";
        }
    }
}
