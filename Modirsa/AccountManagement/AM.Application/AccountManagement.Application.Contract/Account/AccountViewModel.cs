namespace AccountManagement.Application.Contract.Account
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string ProfilePicture { get; set; }
        public string CreationDate { get; set; }
        public string LastSendSms { get; set; }
        public string Token { get; set; }
    }
}
