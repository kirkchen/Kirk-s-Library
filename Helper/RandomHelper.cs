using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace KirkChen.Library.Helper
{
    public sealed class RandomHelper
    {
        private static Random m_random = new Random();

        public static void Do(int percent, Action successAction, Action errorAction)
        {
            double probability = Convert.ToDouble(percent) / 100;
            double random = m_random.NextDouble();

            if (random < probability)
            {
                successAction();
            }
            else
            {
                errorAction();
            }
        }

        public static TResult Do<TResult>(int percent, Func<TResult> successAction, Func<TResult> errorAction)
        {
            double probability = Convert.ToDouble(percent) / 100;
            double random = m_random.NextDouble();

            Console.WriteLine(random);

            if (random < probability)
            {
                return successAction();
            }
            else
            {
                return errorAction();
            }
        }
    }
}
