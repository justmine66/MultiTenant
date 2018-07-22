using System;

namespace MultiTenant.Common.Domain.Model
{
    public static class Assertion
    {
        public static void ArgumentNotNull(string argumentName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
        public static void ArgumentNotNullOrEmpty(string argumentName, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"the {argumentName}'s value cannot be an empty string.", argumentName);
            }
        }
        public static void AssertArgumentLength(string argumentName, string value, int minimum, int maximum)
        {
            int length = value.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new ArgumentException($"the {argumentName}'s value must be greater than {minimum} less then {maximum}.");
            }
        }
    }
}
