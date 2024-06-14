using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.Design;
using Olimp.ViewModel;
using Olimp.Model;
using Olimp;
using Olimp.View;
using Olimp.View.Prepodovatiel;

namespace olimp_test
{

    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Тест направлен на соответствие веденного логина и пароля в соответствии существующей записи в базе
        /// </summary>
        [TestMethod]
        public void AuthMethodExistingUser_TrueReturned()
        {
            string login = "popa";
            string password = "popa";
            bool result = UserVM.CheckAuth(login, password);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AuthMethodNotExistingUser_Exception()
        {
            string login = "123";
            string password = "321";
            Assert.ThrowsException<Exception>(() => UserVM.CheckAuth(login, password));
        }
        [TestMethod]
        public void AuthMethodOnlyLogin_Exception()
        {
            string login = "admin";
            string password = "";
            // bool result = UserVM.CheckAuth(login, password);
            Assert.ThrowsException<Exception>(() => UserVM.CheckAuth(login, password));
        }
        [TestMethod]
        public void AuthMethodOnlyPassword_Exception()
        {
            string login = "";
            string password = "admin";
            // bool result = UserVM.CheckAuth(login, password);
            Assert.ThrowsException<Exception>(() => UserVM.CheckAuth(login, password));
        }
        [TestMethod]
        public void AuthMethodSpaceCheck_Exception()
        {
            string login = "admin";
            string password = " admin";
            Assert.ThrowsException<Exception>(() => UserVM.CheckAuth(login, password));
        }
        [TestMethod]
        public void UserAddRightInfo_Exceprion()
        {
            string FullName = " ";
            string BirthDate = DateTime.Now.ToString();
            string Email = " ";
            string Login = " ";
            string Password = " ";
            string Institution = " ";
            string EducationLevel = " ";
            string Course = " ";
            string Specialty = "";
            int UserType = 0;
            Olimp.ViewModel.AddStudent obj = new Olimp.ViewModel.AddStudent();
            Assert.ThrowsException<Exception>(() => obj.IsChecked(FullName, BirthDate, Email, Login, Password, Institution, EducationLevel, Course, Specialty, UserType));
        }
        [TestMethod]

        public void UserAddRightInfo_TrueReturn()
        {
            string FullName = "adfLol";
            string BirthDate = DateTime.Now.ToString();
            string Email = "sdfg ";
            string Login = "sfdg";
            string Password = "sdfg";
            string Institution = "sdfg";
            string EducationLevel = "adfg";
            string Course = "1";
            string Specialty = "sdfas";
            int UserType = 1;
            Olimp.ViewModel.AddStudent obj = new Olimp.ViewModel.AddStudent();
            bool text = obj.IsChecked(FullName, BirthDate, Email, Login, Password, Institution, EducationLevel, Course, Specialty, UserType);
            Assert.IsTrue(text);
        }
        [TestMethod]

        public void CorrectInput_TrueReturn()
        {
            string FullName = "Lol";
            string BirthDate = DateTime.Now.ToString();
            string Email = "Lol ";
            string Login = "Lol";
            string Password = "Lol";
            string Institution = "Lol";
            string EducationLevel = "Lol";
            string Course = "1";
            string Specialty = "Lol";
            int UserType = 1;
            Olimp.ViewModel.AddStudent obj = new Olimp.ViewModel.AddStudent();
            Assert.IsTrue(obj.IsChecked(FullName, BirthDate, Email, Login, Password, Institution, EducationLevel, Course, Specialty, UserType));
        }
        [TestMethod]

        public void UnCorrectInput_TrueReturn()
        {
            string FullName = "Lol";
            string BirthDate = DateTime.Now.ToString();
            string Email = "Lol ";
            string Login = null;
            string Password = "Lol";
            string Institution = "Lol";
            string EducationLevel = "Lol";
            string Course = "1";
            string Specialty = "Lol";
            int UserType = 0;
            Olimp.ViewModel.AddStudent obj = new Olimp.ViewModel.AddStudent();
            Assert.ThrowsException<Exception>(() => obj.IsChecked(FullName, BirthDate, Email, Login, Password, Institution, EducationLevel, Course, Specialty, UserType));
        }
    }
}
