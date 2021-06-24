using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 除法服務
    /// </summary>
    public class DivideService : IDivideService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public DivideService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 除法
        /// </summary>
        public void Divide()
        {
            if (viewModel.IsCurrentEdited())
            {
                return;
            }

            decimal result;
            try
            {
                result = Convert.ToDecimal(viewModel.HistoryValue) / Convert.ToDecimal(viewModel.CurrentValue);
            }
            catch (Exception)
            {
                throw new Exception("無法執行除法");
            }
            
            viewModel.HistoryValue = result.ToString();
            viewModel.CurrentValue = "0";
        }
    }
}
