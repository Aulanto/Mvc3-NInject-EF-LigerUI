using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LED.Domain.IRepository;
using LED.Domain.Entities;

namespace LED.Domain.IRepository
{
   public interface IOrgRepository
    {
        #region 查询
 
       /// <summary>
       /// 获取所有的org对象
       /// </summary>
       /// <returns></returns>
        IEnumerable<t_org> GetOrgAll();

        /// <summary>
        /// 获取所有菜单的父节点
        /// </summary>
        /// <returns></returns>
        IEnumerable<t_org> GetOrgParentsNode();

        /// <summary>
        /// 根据选择的父节点，获取该父节点下的子节点
        /// </summary>
        /// <param name="parentId">父节点ID</param>
        /// <returns></returns>
        IEnumerable<t_org> GetOrgChildrenNodeByParentCode(string orgCode);

       /// <summary>
       /// 根据指定的条件获取org对象
       /// </summary>
       /// <param name="orgCode"></param>
       /// <param name="name"></param>
       /// <param name="parentCode"></param>
       /// <returns></returns>
        IEnumerable<t_org> GetOrgBySpecifiedCondition(string orgCode);

        #endregion

        #region 添加

       /// <summary>
       /// 添加组织结构
       /// </summary>
       /// <param name="org"></param>
       /// <returns></returns>
        bool AddOrg(t_org org);

        #endregion


        #region 删除

        /// <summary>
        /// 删除组织结构
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        bool DeleteOrg(t_org org);

        #endregion

        #region 修改

        /// <summary>
        /// 修改组织结构
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        bool ModifyOrg(t_org org);

        #endregion
    }
}
