using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verify(string submittedPwd, string hashedPwd)
        {
            return BCrypt.Net.BCrypt.Verify(submittedPwd, hashedPwd);
        }
    }
}
