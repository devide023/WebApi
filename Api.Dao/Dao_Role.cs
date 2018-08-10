using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Api.Model;
using Api.Model.Parm;
namespace Api.Dao
{
    public partial class Db
    {
        public DbSet<site_role> site_roles { get; set; }
        public DbSet<site_role_menu> site_role_menus { get; set; }
    }
}
