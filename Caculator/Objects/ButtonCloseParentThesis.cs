using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    public class ButtonCloseParentThesis : ButtonBase
    {
        private readonly IEditViewModelService editViewModelService;

        public ButtonCloseParentThesis(IEditViewModelService editViewModelService)
        {
            this.editViewModelService = editViewModelService;
        }

        public override void Excute()
        {
            editViewModelService.AddOperand();
            editViewModelService.ClearCurrentValue();
            editViewModelService.AddCloseParentthesis();
        }
    }
}
