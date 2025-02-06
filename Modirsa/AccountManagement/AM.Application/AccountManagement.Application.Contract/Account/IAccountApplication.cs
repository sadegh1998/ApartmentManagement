namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication 
    {
        Task<OperationResult> CreateAsync(CreateAccount command);
        Task<OperationResult> EditAsync(EditAccount command);
        Task<OperationResult> LoginAsync(Login command);
        void LogoutAsync();
        Task<EditAccount> GetDetailsAsync(Guid id);
        Task<List<AccountViewModel>> GetAccountsAsync();

        Task<List<AccountViewModel>> SearchAsync(AccountSearchModel search);
        Task<OperationResult> ChangePasswordAsync(ChanagePassword command);
        Task<AccountViewModel> GetAccountByAsync(Guid id);
        Task<AccountViewModel> GetUserEmailByAsync(string email);
        Task<AccountViewModel> GetUserMobileByAsync(string mobile);
        Task<OperationResult> SetTokenAsync(string token,Guid id);
    }
}
