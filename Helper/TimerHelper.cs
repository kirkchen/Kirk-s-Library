using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KirkChen.Library.Helper
{
    public class TimerHelper
    {        
        /// <summary>
        /// 在指定時間過後執行指定的表達式
        /// </summary>
        /// <param name="interval">事件之間經過的時間（以毫秒為單位）</param>
        /// <param name="action">要執行的表達式</param>
        public static void SetTimeout(double interval, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e)
           {
               timer.Enabled = false;
               action();
           };
            timer.Enabled = true;
        }
        /// <summary>
        /// 在指定時間週期重複執行指定的表達式
        /// </summary>
        /// <param name="interval">事件之間經過的時間（以毫秒為單位）</param>
        /// <param name="action">要執行的表達式</param>
        public static void SetInterval(double interval, Action<System.Timers.ElapsedEventArgs> action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e)
            {
                action(e);
            };
            timer.Enabled = true;
        }

    }
}
