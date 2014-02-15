using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LED.Domain.IRepository;
using LED.Domain.Entities;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace LED.DataProvider.RepositoryImpl
{
    public class UserRepository : IUserRepository
    {
        private ledContext dbContext;

        public UserRepository(ledContext ledContext)
        {
            this.dbContext = ledContext;
        }

        public IEnumerable<t_user> GetUserByOrgCode(string orgCode)
        {
            return dbContext.t_user.Where(m => m.org.orgcode == orgCode);
        }


        public IEnumerable<t_user> GetUserBySpecifiedCondition(string userId)
        {
            return dbContext.t_user.Where(m => m.loginuser == userId);
        }


        public bool AddUser(t_user user)
        {
            dbContext.Entry<t_user>(user).State = EntityState.Added;

            return dbContext.SaveChanges() > 0;
        }


        public bool ModifyUser(t_user user)
        {
            dbContext.t_user.Attach(user);

            var stateEntry = ((IObjectContextAdapter)dbContext).ObjectContext.
           ObjectStateManager.GetObjectStateEntry(user);

            stateEntry.SetModifiedProperty("name");
            stateEntry.SetModifiedProperty("password");

            // dbContext.Entry<t_user>(user).State = EntityState.Modified;

            return dbContext.SaveChanges() > 0;
        }


        public bool DeleteUser(string userId)
        {
            var user = dbContext.t_user.FirstOrDefault(m=>m.userid==userId);

            dbContext.t_role
                .Where(m => m.t_user.Any(t => t.userid == userId))
                .ToList()
                .ForEach(p=>user.role.Remove(p));

            dbContext.Entry<t_user>(user).State = EntityState.Deleted;

            return dbContext.SaveChanges() > 0;
        }


        public bool AddRole(string userId,string userName, string roleName)
        {
           
            var user = dbContext.t_user.SingleOrDefault(m=>m.userid==userId);

            var role = dbContext.t_role.SingleOrDefault(m=>m.rolename==roleName);
            
            role.t_user.Add(user);

            return dbContext.SaveChanges() > 0;
        }


        public IEnumerable<t_user> GetUserRoleByCondition( string userName, string roleName)
        {
            return dbContext.t_user.Where(m => m.name == userName && m.role.Any(p => p.rolename == roleName)).Distinct();
        }


        public IEnumerable<t_user> GetUserBySpecifiedCondition(string userId, string password)
        {
            return dbContext.t_user.Where(m=>m.userid==userId&&m.password==password);
        }


        public IEnumerable<t_resources> GetMenusByUserId(string userId)
        {
            var query = from role in dbContext.t_role
                        from menu in dbContext.t_resources
                        where role.t_resources.Any(m => m.rid == menu.rid)
                        && role.t_user.Any(t => t.userid == userId)
                        select menu;

            return query.Distinct().AsEnumerable();
        }
    }
}
