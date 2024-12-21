using _0_Framework.Domain;
using AccountManagement.Application.Contract.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<Guid,Account>
    {
        Task<Account> GetByAsync(string username);
        Task<EditAccount> GetDetailsAsync(Guid id);
        Task<List<AccountViewModel>> GetAccountsAsync();
        Task<List<AccountViewModel>> SearchAsync(AccountSearchModel search);
        Task<AccountViewModel> GetUserEmailByAsync(string email);
        Task<AccountViewModel> GetUserMobileByAsync(string mobile);
    }
}
