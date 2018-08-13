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
                return Json(new { state=1,msg="ok",resultcount=cnt,list=list});
            }
            catch (Exception e)
            {
                return Json(new { state = 0, msg=e.Message,resultcount = 0, list = new List<sys_user>() });
            }

        }

        [HttpGet]
        public IHttpActionResult deluser(int id)
        {
            try
            {
                UserService us = new UserService();
                sys_user obj = us.Remove(id);
                if (obj.Id > 0)
                {
                    return Json(new { state = 1, msg = "ok" });
                }
                else
                {
                    return Json(new { state = 0, msg = "error" });
                }
            }
            catch (Exception e)
            {
                return Json(new { state = 0, msg = e.Message});
            }
        }
    }
}
