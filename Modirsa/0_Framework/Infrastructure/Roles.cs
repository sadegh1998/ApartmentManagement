using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrstructure
{
    public static class Roles
    {
        public const string Administrator = "00870196-49b7-4892-aca1-4073f54d6bdf";
        public const string SiteUser = "00870196-49b7-4892-aca1-4073f54d6bdd";
        public const string BuildingManager = "00870196-49b7-4892-aca1-4073f54d6bds";


        public static string GetRoleBy(Guid id)
        {
          
            switch (id.ToString())
            {
                case "00870196-49b7-4892-aca1-4073f54d6bdf":
                    return "ادمین سامانه";
                case "00870196-49b7-4892-aca1-4073f54d6bdd":
                    return "مدیر ساختمان";
                    case "00870196-49b7-4892-aca1-4073f54d6bds":
                    return "ساکن ساختمان";
                default:
                    return "";
            }
        }
    }
   
}
