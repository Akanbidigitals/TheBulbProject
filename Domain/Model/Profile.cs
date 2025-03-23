namespace TheBulbProject.Domain.Model
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
