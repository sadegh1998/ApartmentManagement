using Domain.AccountAgg;

namespace Application.Persistance.Contracts
{
    public interface IAccountRepository : IAsyncRepository<Account>
    {
        //Task<Account> GetByAsync(string username);
        //Task<EditAccount> GetDetailsAsync(Guid id);
        //Task<List<AccountViewModel>> GetAccountsAsync();
        //Task<List<AccountViewModel>> SearchAsync(AccountSearchModel search);
        //Task<AccountViewModel> GetUserEmailByAsync(string email);
        //Task<AccountViewModel> GetUserMobileByAsync(string mobile);
    }
}
