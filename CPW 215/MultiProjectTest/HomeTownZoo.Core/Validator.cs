using System;
using System.Text.RegularExpressions;

namespace HomeTownZoo.Core
{
    /// <summary>
    /// Contains generic validation helper methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates a given zip code for a US format
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        public static bool IsValidUSZipCode(string zip)
        {
            Regex pattern = new Regex(@"^\d{5}-?(\d{4})?$");

            return pattern.IsMatch(zip);
        }
    }
}
