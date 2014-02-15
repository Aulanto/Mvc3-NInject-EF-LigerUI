using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LED.Domain.IRepository;
using LED.Domain.Entities;

namespace LED.Domain.IRepository
{
  public interface IRoleRepository
    {
      IEnumerable<t_role> GetAll();

      IEnumerable<t_user> GetUserByRoleId(int roleId);

      IEnumerable<t_role> GetRoleByConditon(int roleId,string roleName);

      IEnumerable<t_resources> GetMenuByRoleId(int roleId);

      bool AddRole(t_role role);

      bool ModifyRole(t_role role);

      bool DeleteRole(t_role role);

      bool AttachRoleToMenu(int roleId, List<int> menus);

      bool DeleteUserFromRole(string userId,int roleId);
    }
}
