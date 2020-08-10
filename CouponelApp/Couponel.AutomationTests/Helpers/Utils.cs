
using System;
using System.Linq;

namespace Couponel.AutomationTests.Helpers
{
    public static class Utils
    {
        private static readonly Random randomGenerator = new Random();

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(
                Enumerable.Repeat(chars, length).Select(s => s[randomGenerator.Next(s.Length)]).ToArray());
        }
        public static string GetRandomPhoneNumber(int length)
        {
            const string chars = "0123456789";
            return new string(
                Enumerable.Repeat(chars, length).Select(s => s[randomGenerator.Next(s.Length)]).ToArray());
        }
    }
}
