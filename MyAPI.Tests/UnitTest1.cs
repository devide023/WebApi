using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Api.Model;
using Api.Model.Parm;
using Api.Dao;
using Api.Service;

namespace MyAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int zs = 0;
            UserService us = new UserService();
            string pwd = Common.Tool.CfsEnCode("850909");
            var list = us.Get_List().Where(t => t.Login_Name == "yy" && t.Pwd == pwd);
            Console.WriteLine(list.Count());
        }
    }
}
