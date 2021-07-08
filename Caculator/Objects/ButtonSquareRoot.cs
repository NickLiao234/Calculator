using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 開根號類別
    /// </summary>
    public class ButtonSquareRoot : ButtonBase
    {
        /// <summary>
        /// 開根號服務
        /// </summary>
        private readonly ISquareRootService squareRootService;
        private readonly IEditViewModelService editViewModelService;
        private readonly IClearService clearService;

        /// <summary>
        /// 初始化開根號服務
        /// </summary>
        /// <param name="squareRootService">開根號服務</param>
        public ButtonSquareRoot(
            ISquareRootService squareRootService, 
            IEditViewModelService editViewModelService, 
            IClearService clearService)
        {
            this.squareRootService = squareRootService;
            this.editViewModelService = editViewModelService;
            this.clearService = clearService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            try
            {
                squareRootService.SquareRoot();
            }
            catch (Exception ex)
            {
                clearService.Clear();
                editViewModelService.SetCurrentValue(ex.Message);
            }

            editViewModelService.SetHistoryValue();
        }
    }
}
