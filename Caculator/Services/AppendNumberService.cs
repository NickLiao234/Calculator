using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 加入字元服務
    /// </summary>
    public class AppendNumberService : IAppendNumberService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public AppendNumberService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 加入方法
        /// </summary>
        /// <param name="appendString">欲加入字元</param>
        public void Append(string appendString)
        {
            if (viewModel.CurrentValue.Contains(".") && appendString == ".")
            {
                return;
            }
            viewModel.CurrentValue += appendString;
        }
    }
}
