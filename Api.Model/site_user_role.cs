using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model
{
    public class site_user_role
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int role_id { get; set; }
    }
}
