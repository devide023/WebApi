using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Parm
{
    public class BaseParm
    {
        public string key { get; set; }
        public int id { get; set; }
        public string status { get; set; }
        public int pageindex { get; set; }
        public int pagesize { get; set; }

    }
}
