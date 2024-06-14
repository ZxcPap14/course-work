using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Olimp.ViewModel
{
    
    public class UserVM
    {
        public static Core bd = new Core();
        /// <param name="login">login</param>
        /// <param name="password">parol</param>



        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static bool CheckAuth(string login, string password)
        {
            if (login!="" && password!="")
            {
                string vrem = HashPassword(password);
                int LegitCheck = bd.context.Users.Where(x => x.Username == login && x.Password == vrem).Count();
                if (LegitCheck == 0)
                {
                    return true;
                }
                else return true;
            }
            else 
            {
                throw new Exception("Не все поля заполнены"); 
            }
        }
    }

    
}
