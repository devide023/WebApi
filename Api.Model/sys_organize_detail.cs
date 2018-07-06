using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model
{
    public class sys_organize_detail
    {
        public int Id { get; set; }
        public int Node_id { get; set; }
        public int Province { get; set; }
        public int City { get; set; }
        public int District { get; set; }
        public string Company_logo { get; set; }
        public int Lock_status { get; set; }
        public string Tel { get; set; }
        public string mobile { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
    }
}
