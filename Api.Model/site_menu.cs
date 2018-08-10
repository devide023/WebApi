using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model
{
    public class site_menu
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int status { get; set; }
        public string title { get; set; }        
        public string control { get; set; }
        public string action { get; set; }
        public int seq { get; set; }
        public DateTime add_time { get; set; }
        public int add_user { get; set; }
        public string icon { get; set; }
    }
}
