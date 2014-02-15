using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LED.Domain.IRepository;
using LED.Domain.Entities;
using System.Data;

namespace LED.DataProvider.RepositoryImpl
{
    public class RoleRepository : IRoleRepository
    {
        private ledContext dbContext;

        public RoleRepository(ledContext ledContext)
        {
            this.dbContext = ledContext;
        }

        public IEnumerable<t_role> GetAll()
        {
            return dbContext.t_role;
        }


        public IEnumerable<t_user> GetUserByRoleId(int roleId)
        {
            return dbContext.t_user.Where(m => m.role.Any(n => n.roleid == roleId));
        }

        //public List<string> GetRoleNameByUserId(string userId)
        //{
        //    return dbContext.t_role.Where(m=>m.t_user.Any(n=>n.userid==userId)).sele;
        //}

        public bool AddRole(t_role role)
        {
            dbContext.Entry<t_role>(role).State = EntityState.Added;
            return dbContext.SaveChanges() > 0;
        }


        public IEnumerable<t_role> GetRoleByConditon(int roleId, string roleName)
        {
            return dbContext.t_role.Where(m => m.roleid == roleId && m.rolename == roleName);
        }


        public bool ModifyRole(t_role role)
        {
            dbContext.Set<t_role>().Attach(role);

            dbContext.Entry<t_role>(role).State = EntityState.Modified;

            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteRole(t_role role)
        {
            dbContext.Set<t_role>().Attach(role);

            dbContext.Entry<t_role>(role).State = EntityState.Deleted;

            return dbContext.SaveChanges() > 0;
        }


        public bool AttachRoleToMenu(int roleId, List<int> menus)
        {
            var role = dbContext.t_role.FirstOrDefault(m => m.roleid == roleId);

            var rids = dbContext.t_resources.Where(m => m.role.Any(t => t.roleid == roleId)).Select(p => p.rid);

            if (rids != null && rids.Count() > 0)
            {
                rids.ToList().ForEach(m => role.t_resources.Remove(dbContext.t_resources.FirstOrDefault(t => t.rid == m)));
            }

            menus.ForEach(m => role.t_resources.Add(dbContext.t_resources.FirstOrDefault(t => t.rid == m)));
           
            return dbContext.SaveChanges() > 0;

        }


        public IEnumerable<t_resources> GetMenuByRoleId(int roleId)
        {
            return dbContext.t_resources.Where(m => m.role.Any(t => t.roleid == roleId));
        }


        public bool DeleteUserFromRole(string userId, int roleId)
        {
            var role = dbContext.t_role.FirstOrDefault(m => m.roleid == roleId);

            role.t_user.Remove(dbContext.t_user.FirstOrDefault(t=>t.userid==userId));

            return dbContext.SaveChanges() > 0;
        }
    }
}
