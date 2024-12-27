using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<Guid, Account>, IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext accountContext) : base(accountContext) 
        {
            _accountContext = accountContext;
        }

        public async Task<List<AccountViewModel>> GetAccountsAsync()
        {
            return await _accountContext.Accounts.Select(x => new AccountViewModel { Id = x.Id, FullName = x.FullName }).ToListAsync();

        }

        public async Task<Account> GetByAsync(string username)
        {
            return await _accountContext.Accounts.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<EditAccount> GetDetailsAsync(Guid id)
        {
            return await _accountContext.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username
            })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AccountViewModel> GetUserEmailByAsync(string email)
        {
            var result =await _accountContext.Accounts.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (result == null)
            {
                return new AccountViewModel();
            }
            else
            {
                return new AccountViewModel { Email = result.Email, Id = result.Id, Token = result.Token };
            }
        }

        public async Task<AccountViewModel> GetUserMobileByAsync(string mobile)
        {
            var result =await _accountContext.Accounts.Where(x => x.Mobile == mobile).FirstOrDefaultAsync();
            if (result == null)
            {
                return new AccountViewModel();
            }
            else
            {
                return new AccountViewModel { Mobile = result.Mobile, Id = result.Id, Token = result.Token };
            }
        }

        public async Task<List<AccountViewModel>> SearchAsync(AccountSearchModel search)
        {
            var query = _accountContext.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                Username = x.Username,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ProfilePicture = x.ProfilePicture,
                RoleId = x.RoleId,
                Role = x.Role.Name,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(search.Mobile))
            {
                query = query.Where(x => x.Mobile.Contains(search.Mobile));
            }
            if (!string.IsNullOrWhiteSpace(search.FullName))
            {
                query = query.Where(x => x.FullName.Contains(search.FullName));
            }
            if (!string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.Contains(search.Username));
            }
            if (search.RoleId != null)
            {
                query = query.Where(x => x.RoleId == search.RoleId);
            }

            var result =await query.OrderByDescending(x => x.Id).ToListAsync();
            return result;
        }
    }
}
