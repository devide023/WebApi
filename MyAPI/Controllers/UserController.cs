using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Api.Model;
using Api.Model.Parm;
using Api.Service;
namespace MyAPI.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage user_list()
        {
            UserService us = new UserService();
            var list = us.Get_List();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
    }
}
