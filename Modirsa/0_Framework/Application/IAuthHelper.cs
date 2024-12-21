using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        void SignIn(AuthViewModel auth);
        void SignOut();
        bool IsAuthenticated();
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
        long CurrentAccountId();
    }
}
