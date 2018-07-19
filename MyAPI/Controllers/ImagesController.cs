using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;

namespace MyAPI.Controllers
{
    public class ImagesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Logo()
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
