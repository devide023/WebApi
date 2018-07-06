using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model
{
    public class sys_organize_node
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public string Node_code { get; set; }
        public string Title { get; set; }
        public string Short_title { get; set; }
        public int Use_status { get; set; }
        public DateTime Add_Time { get; set; }
        public int Add_User { get; set; }
        public string Add_userName { get; set; }
    }
}
