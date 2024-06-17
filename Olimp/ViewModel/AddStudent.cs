using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Olimp.ViewModel
{

    public class AddStudent
    {


        public bool IsChecked(
                    string FullName,
                    string BirthDate,
                    string Email,
                    string Login,
                    string Password,
                    string Institution,
                    string EducationLevel,
                    string Course,
                    string Specialty,
                    int UserType)
        {
            if (chek(FullName)
                && chek(BirthDate)
                && chek(Email)
                && chek(Login)
                && chek(Password)
                && chek(Institution)
                && chek(EducationLevel)
                && chek(Course)
                && chek(Specialty)
                && chek(UserType.ToString()))
            {
                return true;
            }
            else
            {
                throw new Exception("Не все поля заполнены");
            }
        }
        public bool chek(string qq)
        {
            return !string.IsNullOrEmpty(qq);
        }

    }
    public static class CheckPrikol{
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

        public static Core GetBd()
        {
            Core bd = new Core();
            return bd;
        }

        public static bool CheckAuth(string login, string password, Core db)
        {
            if (login != "" && password != "")
            {
                string vrem = HashPassword(password);
                int LegitCheck = db.context.Users.Where(x => x.Username == login && x.Password == vrem).Count();
                if (LegitCheck == 0)
                {
                    return true;
                }

                else return true;
                throw new Exception(" Абоба");
            }
            else
            {
                throw new Exception("Не все поля заполнены");
            }
        }

    }
}


