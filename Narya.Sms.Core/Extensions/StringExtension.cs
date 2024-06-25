using System.Text.RegularExpressions;

namespace Narya.Sms.Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            string pattern = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }
    }
}
