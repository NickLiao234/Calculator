using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕Divide
    /// </summary>
    public class ButtonDivide : ButtonBase
    {
        /// <summary>
        /// Divide服務
        /// </summary>
        private readonly IDivideService divideService;

        /// <summary>
        /// 建構式注入Divide服務
        /// </summary>
        /// <param name="divideService">divideService</param>
        public ButtonDivide(IDivideService divideService)
        {
            this.divideService = divideService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            divideService.Divide();
        }
    }
}
