using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrstructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string SiteUser = "2";
        public const string InventoryUser = "4";
        public const string ColleagueUser = "5";


        public static string GetRoleBy(Guid id)
        {
            var a = Guid.NewGuid();
            switch (id.ToString())
            {
                case "00870196-49b7-4892-aca1-4073f54d6bdf":
                    return "مدیرسیستم";
                case "00870196-49b7-4892-aca1-4073f54d6bdd":
                    return "کاربر سیستم";
                    case "00870196-49b7-4892-aca1-4073f54d6bds":
                    return "کاربر انبارداری";
                default:
                    return "";
            }
        }
    }
   
}
