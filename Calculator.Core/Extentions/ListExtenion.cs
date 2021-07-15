using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Extentions
{
    /// <summary>
    /// List擴充方法
    /// </summary>
    public static class ListExtenion
    {
        /// <summary>
        /// 找出List從start index元素到最後一個元素符合 predicate條件的元素, 第幾個(targetCount)元素的index值 
        /// </summary>
        /// <typeparam name="T">型別</typeparam>
        /// <param name="ts">list</param>
        /// <param name="start">起始元素index值</param>
        /// <param name="targetCount">欲搜尋符合條件的第幾個元素</param>
        /// <param name="predicate">條件</param>
        /// <returns>int</returns>
        public static int FindIndexByTargetCount<T>(this List<T> ts, int start, int targetCount, Predicate<T> predicate)
        {
            int targetOpenBracketIndex = 0;
            for (int i = 0; i < targetCount; i++)
            {
                if (i == 0)
                {
                    targetOpenBracketIndex = ts.FindIndex(start, predicate);
                }
                else
                {
                    targetOpenBracketIndex = ts.FindIndex(targetOpenBracketIndex + 1, predicate);
                }
            }

            return targetOpenBracketIndex;
        }

        /// <summary>
        /// 找出List中從start index至end index所有符合predicate條件的元素數量
        /// </summary>
        /// <typeparam name="T">型別</typeparam>
        /// <param name="ts">list</param>
        /// <param name="start">起始元素index值</param>
        /// <param name="end">結束元素index值</param>
        /// <param name="predicate">條件</param>
        /// <returns>int</returns>
        public static int CountByCondition<T>(this List<T> ts, int start, int end, Func<T, bool> predicate)
        {
            List<T> tempList = new List<T>();

            for (int i = start; i < end; i++)
            {
                tempList.Add(ts[i]);
            }

            return tempList.Where(predicate).Count();
        }
    }
}
