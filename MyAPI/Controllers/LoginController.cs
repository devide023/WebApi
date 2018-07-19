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

namespace MyAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage CheckLogin(string username,string userpwd)
        {
            string json = "";
            UserService us = new UserService();
            string pwd = Common.Tool.CfsEnCode(userpwd);
            var list = us.Get_List().Where(t => t.Login_Name == username && t.Pwd == pwd);
            if (list.Count() > 0)
            {
                json = JsonConvert.SerializeObject(new { state = 1, msg = "ok", list = list });
            }
            else
            {
                json = JsonConvert.SerializeObject(new { state = 0, msg = "用户名密码错误！",list=""});
                
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
