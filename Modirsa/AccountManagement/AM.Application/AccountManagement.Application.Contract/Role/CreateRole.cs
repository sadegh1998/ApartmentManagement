using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Role
{
    public class CreateRole
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }
}
