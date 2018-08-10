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
        public DbSet<sys_user> sys_users { get; set; }
        public DbSet<site_user_role> site_user_roles { get; set; }
    }
}
