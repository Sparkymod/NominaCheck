using System.Text.RegularExpressions;

namespace NominaCheck.Data.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Find and remove any special char, only letting numbers and letters in.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Same <see langword="string"/> without any special char.</returns>
        public static string RemoveSpecialChars(this string input) => string.IsNullOrEmpty(input) ? "-" : Regex.Replace(input, @"[^0-9a-zA-Z]", "");
    }
}
