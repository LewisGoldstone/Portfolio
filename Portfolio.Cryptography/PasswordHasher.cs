namespace Portfolio.Cryptography
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string submittedPwd, string hashedPwd)
        {
            return BCrypt.Net.BCrypt.Verify(submittedPwd, hashedPwd);
        }
    }
}
