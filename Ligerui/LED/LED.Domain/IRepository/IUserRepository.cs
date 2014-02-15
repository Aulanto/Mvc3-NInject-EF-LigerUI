using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LED.Domain.IRepository;
using LED.Domain.Entities;

namespace LED.Domain.IRepository
{
   public interface IUserRepository
    {
       IEnumerable<t_user> GetUserByOrgCode(string orgCode);

       IEnumerable<t_user> GetUserBySpecifiedCondition(string userId);

       IEnumerable<t_user> GetUserBySpecifiedCondition(string userId,string password);

       IEnumerable<t_user> GetUserRoleByCondition(string userName,string roleName);

       IEnumerable<t_resources> GetMenusByUserId(string userId);

       bool AddUser(t_user user);

       bool ModifyUser(t_user user);

       bool DeleteUser(string userId);

       bool AddRole(string userId, string userName, string roleName);
    }
}
