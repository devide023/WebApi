using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.Parm;
namespace Api.Model
{
    public class site_role
    {
        public int id { get;set;}
      public int status{get;set;}
      public string title{get;set;}
      public int add_user{get;set;}
      public DateTime add_time{get;set;}
    }
}
