using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects
{
    /// <summary>
    /// 按鈕倒退
    /// </summary>
    public class ButtonBack : ButtonBase
    {
        /// <summary>
        /// 倒退服務
        /// </summary>
        private readonly IBackService backService;

        /// <summary>
        /// 建構式注入倒退服務
        /// </summary>
        /// <param name="backService">backService</param>
        public ButtonBack(IBackService backService)
        {
            this.backService = backService;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        public override void Excute()
        {
            backService.Back();
        }
    }
}
