using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimp.ViewModel
{
    
    public class AddStudent
    {
        public bool IsChecked(
                    string FullName,
                    string BirthDate,
                    string Email ,
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

}
