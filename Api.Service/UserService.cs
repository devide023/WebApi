using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Api.Dao;
using Api.Model.Parm;
using Webdiyer.WebControls.Mvc;
using Dapper;
using Z.Dapper.Plus;
using Z.BulkOperations;
namespace Api.Service
{
    public class UserService: BaseService<sys_user>
    {
        public UserService()
        {

        }

        public IEnumerable<sys_user> check_userlogin(string name,string pwd)
        {
            return DapperHelper.Conn.Query<sys_user>("SELECT * FROM dbo.Sys_User WHERE Login_Name=@name AND Pwd=@pwd ", new { name = name, pwd = pwd });
        }
        public List<sys_user> myusers()
        {
            
                var list = DapperHelper.Conn.Query<sys_user>("select * from sys_user where convert(date,add_time) between @rq1 and @rq2 ",new {rq1="2017-01-01",rq2="2017-12-31" });
                return list.ToList();
        }

        public List<sys_user> Dapper_Test(int user_id)
        {
            try
            {
                var userdic = new Dictionary<int, sys_user>();
                string sql = @"SELECT ta.*,te.*,tf.*,td.*,h.*
FROM   dbo.Sys_User ta,
       dbo.site_user_role tb,
	   dbo.site_role_menu tc,
	   dbo.site_menu td,
        sys_organize_node te,
sys_organize_node tf,
dbo.site_user_role g,
dbo.site_role h
WHERE  ta.id = tb.user_id
		AND tb.role_id = tc.role_id
		AND tc.menu_id = td.id
        and ta.company_id = te.id
        and ta.department_id = tf.id
AND ta.id = g.user_id
		AND g.role_id = h.id
       AND ta.id in @userid";
                var list = DapperHelper.Conn.Query<sys_user, sys_organize_node, sys_organize_node,site_menu,site_role, sys_user>(sql,(u,o,o1,m,r)=> {
                    sys_user userEntry;

                    if (!userdic.TryGetValue(u.Id, out userEntry))
                    {
                        userEntry = u;
                        userEntry.organize_node = o;
                        userEntry.department = o1;
                        userEntry.site_menus = new List<site_menu>();
                        userEntry.site_roles = new List<site_role>();
                        userdic.Add(userEntry.Id, userEntry);
                    }

                    userEntry.site_menus.Add(m);
                    userEntry.site_roles.Add(r);
                    return userEntry;
                }, new { userid = new[] { user_id } },splitOn:"id,Id,Id,id").Distinct().ToList();
                list.ForEach(t => { t.site_roles = t.site_roles.Distinct().ToList();t.site_menus = t.site_menus.Distinct().ToList(); });
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<site_menu> Get_UserMenu(int user_id)
        {
            try
            {
                string sql = @"SELECT tc.* FROM dbo.site_user_role ta,dbo.site_role_menu tb,dbo.site_menu tc WHERE ta.USER_ID = @userid
AND ta.role_id = tb.role_id
AND tc.id  =tb.menu_id";
                var list = DapperHelper.Conn.Query<site_menu>(sql, new { userid = user_id });
                return list.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<sys_user> Get_User_List(UserQueryParm parm, out int Result_Count)
        {
            try
            {
                using (Db db = new Db())
                {
                    var list = db.sys_users as IQueryable<sys_user>;
                    if (!string.IsNullOrEmpty(parm.key))
                    {
                        list = list.Where(t => t.Name.Contains(parm.key.Trim()));
                    }
                    if (!string.IsNullOrEmpty(parm.tel))
                    {
                        list = list.Where(t => t.Mobile.Contains(parm.tel.Trim()) || t.Tel.Contains(parm.tel.Trim()));
                    }
                    PagedList<sys_user> retlist = list.OrderByDescending(t => t.Id).ToPagedList(parm.pageindex, parm.pagesize);
                    Result_Count = retlist.TotalItemCount;
                    return retlist.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
