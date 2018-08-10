using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Api.Model;
using Api.Model.Parm;
using Api.Service;
using Newtonsoft.Json;
namespace MyAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult get_userlist()
        {
            try
            {
                UserService us = new UserService();
                List<sys_user> list = us.Get_List().ToList();
                return Json(list);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IHttpActionResult userlist([FromBody] UserQueryParm parm)
        {
            try
            {
                int cnt = 0;
                UserService us = new UserService();
                var list = us.Get_User_List(parm, out cnt);
                return Json(new { resultcount=cnt,list=list});
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
