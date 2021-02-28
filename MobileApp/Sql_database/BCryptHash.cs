using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_database
{
    class BCryptHash
    {
        private static string GetSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(8);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool ValidatePassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
