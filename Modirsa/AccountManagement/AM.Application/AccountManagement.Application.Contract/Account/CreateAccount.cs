using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Account
{
    public class CreateAccount
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public Guid RoleId { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public IFormFile ProfilePicture { get; set; }
    }
}
