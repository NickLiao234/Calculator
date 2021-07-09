using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 處理viewModel服務介面
    /// </summary>
    public interface IEditViewModelService
    {
        /// <summary>
        /// 運算子插入堆疊
        /// </summary>
        public void AddOperand();

        /// <summary>
        /// 運算元插入堆疊
        /// </summary>
        /// <param name="value">顯示值</param>
        public void AddOperator(string value);

        /// <summary>
        /// 表達式加入左括號
        /// </summary>
        public void AddOpenParentthesis();

        /// <summary>
        /// 表達式加入右括號
        /// </summary>
        public void AddCloseParentthesis();

        /// <summary>
        /// 設定運算表達式
        /// </summary>
        public void SetHistoryValue();

        /// <summary>
        /// 設定運算結果值
        /// </summary>
        /// <param name="value">顯示值</param>
        public void SetHistoryValue(string value);

        /// <summary>
        /// 設定目前運算子值
        /// </summary>
        /// <param name="value">目前運算子值</param>
        public void SetCurrentValue(string value);

        /// <summary>
        /// 清除目前運算子
        /// </summary>
        public void ClearCurrentValue();

        /// <summary>
        /// 設定後序表達式
        /// </summary>
        /// <param name="value">表達式字串</param>
        public void SetPostfixValue(string value);

        /// <summary>
        /// 設定前序表達式
        /// </summary>
        /// <param name="value">表達式字串</param>
        public void SetPrefixValue(string value);

        /// <summary>
        /// 設定中序表達式
        /// </summary>
        /// <param name="value">表達式字串</param>
        public void SetInfixValue(string value);
    }
}
