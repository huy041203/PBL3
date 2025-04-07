// Helpers/PasswordHasher.cs
public static class PasswordHasher
{
    // Hàm mã hóa mật khẩu
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Hàm kiểm tra mật khẩu 
    public static bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}