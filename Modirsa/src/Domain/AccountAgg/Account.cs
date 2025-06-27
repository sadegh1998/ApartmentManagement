using Domain.RoleAgg;

namespace Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public string LastSendSms { get; private set; }
        public string Token { get; private set; }
        public Guid RoleId { get; private set; }
        public string ProfilePicture { get; private set; }
        public ICollection<UserRole?> UserRoles { get; set; }

        public Account(string fullName, string username, string password, string mobile, Guid roleId, string profilePicture)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            ProfilePicture = profilePicture;
        }
        public void Edit(string fullName, string username, string mobile, Guid roleId, string profilePicture)
        {
            FullName = fullName;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(profilePicture))
            {
                ProfilePicture = profilePicture;
            }
        }
        public void ChanagePassword(string password)
        {
            Password = password;
        }
        public void UpdateLastSendSms(string sms)
        {
            LastSendSms = sms;
        }
        public void UpdateToken(string token)
        {
            Token = token;
        }
    }
}
