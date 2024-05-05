using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimp.ViewModel
{
    
    public class UserVM
    {
        public static Core bd = new Core();
        /// <param name="login">login</param>
        /// <param name="password">parol</param>




        public static bool CheckAuth(string login, string password)
        {

            int LegitCheck = bd.context.Users.Where(x => x.Username == login && x.Password== password).Count();
            if (LegitCheck == 0)
            {
                return false;
            }
            else return true;
        }
    }

    
}
