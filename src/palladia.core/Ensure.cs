using System;
using System.Diagnostics;

namespace Palladia.Core
{
    public static class Ensure
    {
        [Conditional("DEBUG")]
        public static void ArgumentIsNotNull(object value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
        [Conditional("DEBUG")]
        public static void ArgumentIsNotNullOrWhitespace(string value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(paramName);
            }
        }
    }
}
