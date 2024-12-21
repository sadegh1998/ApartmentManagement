using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

       
        public async Task<OperationResult> ChangePasswordAsync(ChanagePassword command)
        {
            var operation = new OperationResult();
            var account =await _accountRepository.GetAsync(command.Id);
            if (account == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }

            if (command.Password != command.RePassword)
            {
                return operation.Failed(ApplicationMessages.PasswordNotMatch);
            }
            var password = _passwordHasher.Hash(command.Password);
            account.ChanagePassword(password);
            await _accountRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<OperationResult> CreateAsync(CreateAccount command)
        {
            var operation = new OperationResult();
            if (await _accountRepository.ExsitsAsync(x => x.Username == command.Username || x.Mobile == command.Mobile))
            {
                return operation.Failed(ApplicationMessages.UserIsRegisterd);
            }
            var password = _passwordHasher.Hash(command.Password);
            var path = $"ProfilePictures";
            var profilePicture = _fileUploader.Upload(command.ProfilePicture, path);
            var account = new Account(command.FullName, command.Username, password, command.Mobile, command.RoleId, profilePicture);
            await _accountRepository.CreateAsync(account);
            await _accountRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<OperationResult> EditAsync(EditAccount command)
        {
            var operation = new OperationResult();
            if (await _accountRepository.ExsitsAsync(x => (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.UserIsRegisterd);
            }
            var account =await _accountRepository.GetAsync(command.Id);

            if (account == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }
            var path = $"ProfilePictures";
            var profilePicture = _fileUploader.Upload(command.ProfilePicture, path);
            account.Edit(command.FullName, command.Username, command.Mobile, command.RoleId, profilePicture);
            await _accountRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<AccountViewModel> GetAccountByAsync(Guid id)
        {
            var account =await _accountRepository.GetAsync(id);
            return new AccountViewModel { FullName = account.FullName, Mobile = account.Mobile, LastSendSms = account.LastSendSms };
        }

        public async Task<List<AccountViewModel>> GetAccountsAsync()
        {
            return await _accountRepository.GetAccountsAsync();
        }

        public async Task<EditAccount> GetDetailsAsync(Guid id)
        {
            return await _accountRepository.GetDetailsAsync(id);
        }

        public async Task<AccountViewModel> GetUserEmailByAsync(string email)
        {
            return await _accountRepository.GetUserEmailByAsync(email);
        }

        public async Task<AccountViewModel> GetUserMobileByAsync(string mobile)
        {
            return await _accountRepository.GetUserMobileByAsync(mobile);
        }

        public async Task<OperationResult> LoginAsync(Login command)
        {
            var operation = new OperationResult();
            var account =await _accountRepository.GetByAsync(command.Username);
            if (account == null)
            {
                return operation.Failed(ApplicationMessages.WrongUserPass);
            }

            (bool Verified, bool NeedsUpgrade) = _passwordHasher.Check(account.Password, command.Password);
            if (!Verified)
            {
                return operation.Failed(ApplicationMessages.WrongUserPass);

            }
            var result = await _roleRepository.GetAsync(account.RoleId);
            var accountPermissions =result.Permissions.Select(x => x.Code).ToList();
            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Username, account.FullName, accountPermissions);
            _authHelper.SignIn(authViewModel);
            return operation.Success();
        }

        public void LogoutAsync()
        {
           _authHelper.SignOut();
        }

        public async Task<List<AccountViewModel>> SearchAsync(AccountSearchModel search)
        {
            return await _accountRepository.SearchAsync(search);
        }

        public async Task<OperationResult> SetTokenAsync(string token, Guid id)
        {
            var operation = new OperationResult();
            var account =await _accountRepository.GetAsync(id);
            if (account == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }
            account.UpdateToken(token);
            await _accountRepository.SaveChangesAsync();
            return operation.Success();
        }
    }
}
