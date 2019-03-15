using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model
{
    public class sys_user
    {
        public int Id { get; set; }
        public string Login_Name { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public string Sex { get; set; }
        public int? Company_id { get; set; }
        public int? Department_Id { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public int? Province { get; set; }
        public int? City { get; set; }
        public int? District { get; set; }
        public string Address { get; set; }
        public DateTime? Add_Time { get; set; }
        public int Add_User { get; set; }
        public string Add_userName { get; set; }

        public List<site_menu> site_menus { get; set; }
        public List<site_role> site_roles { get; set; }
        public sys_organize_node organize_node { get; set; }
        public sys_organize_node department { get; set; }
    }
}
