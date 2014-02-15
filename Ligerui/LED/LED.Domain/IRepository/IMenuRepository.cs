using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LED.Domain.Entities;

namespace LED.Domain.IRepository
{
   public interface IMenuRepository
   {
       #region 查询

       /// <summary>
       /// 获取所有菜单的父节点
       /// </summary>
       /// <returns></returns>
       IEnumerable<t_resources> GetMenuParentsNode();

       /// <summary>
       /// 根据选择的父节点，获取该父节点下的子节点
       /// </summary>
       /// <param name="parentId">父节点ID</param>
       /// <returns></returns>
       IEnumerable<t_resources> GetMenuChildrenNodeByParentId(int? rid);

       /// <summary>
       /// 根据条件获取菜单
       /// </summary>
       /// <param name="pageName"></param>
       /// <param name="url"></param>
       /// <returns></returns>
       IEnumerable<t_resources> GetMenuByCondition(string pageName,string url);

       /// <summary>
       /// 获取所有的页面
       /// </summary>
       /// <returns></returns>
       IEnumerable<t_resources> GetMenuAll();

       #endregion

       #region 添加

       /// <summary>
       /// 添加菜单
       /// </summary>
       /// <param name="menu"></param>
       /// <returns></returns>
       bool AddMenu(t_resources menu);

       #endregion


       #region 删除

       /// <summary>
       /// 删除菜单
       /// </summary>
       /// <param name="rid"></param>
       /// <returns></returns>
       bool DeleteMenu(t_resources menu);

       #endregion

       #region 更新

       /// <summary>
       /// 更新菜单
       /// </summary>
       /// <param name="rid"></param>
       /// <returns></returns>
       bool UpdateMenu(t_resources menu);

       #endregion
   }
}
