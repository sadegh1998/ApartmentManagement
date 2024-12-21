namespace AccountManagement.Application.Contract.Account
{
    public class EditAccount : CreateAccount
    {
        public Guid Id { get; set; }
        public string LastSendSms { get; set; }
    }
}
