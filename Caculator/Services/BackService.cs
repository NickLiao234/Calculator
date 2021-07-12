using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 倒退服務
    /// </summary>
    public class BackService : IBackService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// editViewModelService
        /// </summary>
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 建構式注入viewmodel
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        /// <param name="editViewModelService">editViewModelService</param>
        public BackService(
            CalculatorViewModel viewModel,
            IEditViewModelService editViewModelService)
        {
            this.viewModel = viewModel;
            this.editViewModelService = editViewModelService;
        }

        /// <summary>
        /// 倒退方法
        /// </summary>
        public void Back()
        {
            if (viewModel.CurrentValue.Length == 1)
            {
                viewModel.CurrentValue = "0";
                return;
            }

            editViewModelService.SetCurrentValue(viewModel.CurrentValue.Remove(viewModel.CurrentValue.Length - 1));
        }
    }
}
