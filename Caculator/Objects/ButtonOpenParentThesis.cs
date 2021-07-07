using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 左括號類別
    /// </summary>
    public class ButtonOpenParentThesis : ButtonBase
    {
        /// <summary>
        /// 修改ViewModel服務
        /// </summary>
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 初始化注入修改ViewModel服務
        /// </summary>
        /// <param name="editViewModelService">ViewModel服務</param>
        public ButtonOpenParentThesis(IEditViewModelService editViewModelService)
        {
            this.editViewModelService = editViewModelService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            editViewModelService.AddOperand();
            editViewModelService.ClearCurrentValue();
            editViewModelService.AddOpenParentthesis();
        }
    }
}
