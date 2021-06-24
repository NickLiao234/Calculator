using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕Sub
    /// </summary>
    public class ButtonSub : ButtonBase
    {
        /// <summary>
        /// Sub服務
        /// </summary>
        private readonly ISubService subService;

        /// <summary>
        /// 建構式注入Sub服務
        /// </summary>
        /// <param name="subService">subService</param>
        public ButtonSub(ISubService subService)
        {
            this.subService = subService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            subService.Sub();
        }
    }
}
