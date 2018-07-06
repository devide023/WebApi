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
            UserService us = new UserService();            
            sys_user t = us.Find(406);
            Console.WriteLine(t.Id);
            Console.WriteLine(t.Name);
        }
    }
}
