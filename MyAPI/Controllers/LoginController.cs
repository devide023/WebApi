using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Api.Model;
using Api.Model.Parm;
using Api.Service;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Security;
using MyAPI.ApiSecurity;

namespace MyAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage CheckLogin([FromBody]sys_user user)
        {
            string json = "";
            UserService us = new UserService();
            string pwd = Common.Tool.CfsEnCode(user.Pwd);
            var list = us.check_userlogin(user.Login_Name, pwd);
            if (list.Count() > 0)
            {
                string uid = list.ToList()[0].Id.ToString();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, uid, DateTime.Now,
                            DateTime.Now.AddHours(24), true, string.Format("{0}&{1}", user.Login_Name, pwd),
                            FormsAuthentication.FormsCookiePath);
                json = JsonConvert.SerializeObject(new { state = 1, msg = "ok", list = list, ticket = FormsAuthentication.Encrypt(ticket) });
            }
            else
            {
                json = JsonConvert.SerializeObject(new { state = 0, msg = "用户名密码错误！", list = "", ticket = "" });

            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
        [HttpGet]
        public HttpResponseMessage GetQrCode()
        {
            string imgPath = HostingEnvironment.MapPath("~/Images/yzlLogin_logo.gif");
            //从图片中读取byte  
            var imgByte = File.ReadAllBytes(imgPath);
            //从图片中读取流  
            var imgStream = new MemoryStream(File.ReadAllBytes(imgPath));
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(imgByte)
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return resp;
        }

    }
}
