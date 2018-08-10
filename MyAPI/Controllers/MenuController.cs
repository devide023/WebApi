using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Model;
using Api.Model.Parm;
using Api.Service;
namespace MyAPI.Controllers
{
    public class MenuController : ApiController
    {
        [HttpGet]
        public IHttpActionResult List(int userid)
        {
            List<site_menu> list = new List<site_menu>();
            try
            {
                UserService us = new UserService();
                list = us.Get_UserMenu(userid);
            }
            catch (Exception)
            {

                throw;
            }
            return Json(list);
        }
    }
}
