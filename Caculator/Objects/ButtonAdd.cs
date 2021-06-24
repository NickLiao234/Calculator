using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕Add
    /// </summary>
    public class ButtonAdd : ButtonBase
    {
        /// <summary>
        /// Add服務
        /// </summary>
        private readonly IAddService addService;

        /// <summary>
        /// 建構式注入Add服務
        /// </summary>
        /// <param name="addService">addService</param>
        public ButtonAdd(IAddService addService)
        {
            this.addService = addService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            addService.Add();
        }
    }
}
