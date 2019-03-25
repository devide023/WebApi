using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Model;
using Api.Model.Parm;
using Api.Service;
using MyAPI.ApiSecurity;
using Newtonsoft.Json;
using System.Text;

namespace MyAPI.Controllers
{
    public class MenuController : BaseApiSecurity
    {
        [HttpGet]
        public IEnumerable<site_menu> List(int userid)
        {
            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);
            List<site_menu> list = new List<site_menu>();
            try
            {
                UserService us = new UserService();
                list = us.Get_UserMenu(userid);
            }
            catch (Exception e)
            {
            }

            return list;
        }
    }
}
