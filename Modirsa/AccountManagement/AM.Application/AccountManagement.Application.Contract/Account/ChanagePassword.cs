namespace AccountManagement.Application.Contract.Account
{
    public class ChanagePassword
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
