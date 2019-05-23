using System;

namespace Palladia.Core
{
    public static class Ensure
    {
        //[Conditional("DEBUG")]
        public static void ArgumentIsNotNull(object value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
