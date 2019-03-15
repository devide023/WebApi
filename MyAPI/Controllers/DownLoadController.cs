using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;
using MyAPI.ApiSecurity;

namespace MyAPI.Controllers
{
    public class DownLoadController : BaseApiSecurity
    {
        [HttpGet]
        public HttpResponseMessage File(string name)
        {
            try
            {
                var FilePath =HostingEnvironment.MapPath("~/Files/"+name);
                var stream = new FileStream(FilePath, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = name
                };
                return response;
            }
            catch(Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }
    }
}
