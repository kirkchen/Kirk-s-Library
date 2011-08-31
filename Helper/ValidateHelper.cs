using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KirkChen.Library.Helper
{
    public static class ValidateHelper
    {
        public static Validation Begin()
        {
            return null;
        }
    }

    public sealed class Validation
    {
        public bool IsValid { get; set; }
    }

    public static class ValidationExtensions
    {
        private static Validation Check<T>(this Validation validation, Func<bool> filterMethod, T exception) where T : Exception
        {
            if (filterMethod())
            {
                return validation ?? new Validation() { IsValid = true };
            }
            else
            {
                throw exception;
            }
        }

        public static Validation Check(this Validation validation, Func<bool> filterMethod)
        {
            return Check<Exception>(validation, filterMethod, new Exception("Parameter InValid!"));
        }

        public static Validation NotNull(this Validation validation, Object obj)
        {
            return Check<ArgumentNullException>(
                validation,
                () => obj != null,
                new ArgumentNullException(string.Format("Parameter {0} can't be null", obj))
            );
        }

        public static Validation InRange(this Validation validation, double obj, double min, double max)
        {
            return Check<ArgumentOutOfRangeException>(
                validation,
                () =>
                {
                    double input = double.Parse(obj.ToString());
                    if (obj >= min && obj <= max)
                        return true;
                    else
                        return false;
                },
                new ArgumentOutOfRangeException(string.Format("Parameter should be between {0} and {1}", min, max))
            );
        }

        public static Validation RegexMatch(this Validation validation, string input, string pattern)
        {
            return Check<ArgumentException>(
                validation,
                () => Regex.IsMatch(input, pattern),
                new ArgumentException(string.Format("Parameter should match format {0}", pattern))
            );
        }

        public static Validation IsEmail(this Validation validation, string email)
        {
            return RegexMatch(validation, email, @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$");
        }
    }
}
