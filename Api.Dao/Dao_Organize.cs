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
        public DbSet<sys_organize_node> sys_organize_nodes { get; set; }
        public DbSet<sys_organize_detail> sys_organize_details { get; set; }
    }
}
