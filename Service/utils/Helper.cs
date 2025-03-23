namespace TheBulbProject.Service.utils;

public class Helper
{
    public static string GenerateRandomTag()
    {
        Random random = new Random();
        int randomNumber = random.Next(10000, 99999); // Generate a 5-digit number
        return $"#{randomNumber}";
    }
    public static string GenerateUserId(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty or null");

        Random random = new Random();
        int randomDigits = random.Next(10000, 99999); // Generates a 5-digit number

        return $"{firstName}{randomDigits}";
    }

    public static string EncryptPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("Password can't be null or empty");
        }
        else
        {
            var hashPass = BCrypt.Net.BCrypt.HashPassword(password);
            return hashPass;
        }
    }

    public static bool DecryptPassword(string password, string hashpass)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("Password can't be null or empty");
        }
        return BCrypt.Net.BCrypt.Verify(password, hashpass);

    }
}
