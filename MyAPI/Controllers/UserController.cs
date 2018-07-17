using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using Api.Model;
using Api.Model.Parm;
using Api.Service;
using Newtonsoft.Json;
namespace MyAPI.Controllers
{
    public class UserController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage userlist()
        {
            UserService us = new UserService();
            var list = us.Get_List();
            list = list.Where(t => t.Id <= 406).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, list, "application/json");
        }
    }
}
