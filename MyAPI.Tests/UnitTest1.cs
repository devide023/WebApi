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
            UserQueryParm parm = new UserQueryParm();
            parm.pageindex = 1;
            parm.pagesize = 20;
            var list = us.Get_List(parm,t=>t.Id,out zs);
            Console.WriteLine(list.FirstOrDefault().Id);
            Console.WriteLine(list.Count());
            Console.WriteLine(zs);
        }
    }
}
