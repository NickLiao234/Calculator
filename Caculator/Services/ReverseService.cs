﻿using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 修改正負值服務
    /// </summary>
    public class ReverseService : IReverseService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        public ReverseService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 修改正負值方法
        /// </summary>
        public void Reverse()
        {
            var CurentValueToDecimal = Convert.ToDecimal(viewModel.CurrentValue);
            viewModel.CurrentValue = (0 - CurentValueToDecimal).ToString();
        }
    }
}
