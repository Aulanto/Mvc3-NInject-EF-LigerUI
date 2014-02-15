using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LED.Domain.IRepository;
using LED.Domain.Entities;

namespace LED.WebUI.Controllers
{
 
    public class RoleController : Controller
    {
        //
        // GET: /Role/ 

        private IRoleRepository _roleRepository;
        private IOrgRepository _orgRepository;
        private IMenuRepository _menuRepository;

        public RoleController(IRoleRepository roleRepository, IOrgRepository orgRepository, IMenuRepository menuRepository)
        {

            this._roleRepository = roleRepository;
            this._orgRepository = orgRepository;
            this._menuRepository = menuRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RoleDataSource()
        {
            var data = _roleRepository.GetAll().ToList();

            return Json(new
            {
                Rows = data.Select(m => new
                {
                    roleid = m.roleid,
                    rolename = m.rolename

                }),
                Total = data.Count()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RoleDetail(int roleId)
        {
            var data = _roleRepository.GetUserByRoleId(roleId).ToList();

            return Json(new
            {
                Rows = data.Select(m => new
                {
                    userid = m.userid,
                    name = m.name,
                    roleid = roleId
                }),
                Total = data.Count()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddRole(int roleId, string roleName)
        {
            var check = _roleRepository.GetRoleByConditon(roleId, roleName);

            if (check.Count() > 1)
            {
                return Json(new { result = false, msg = "添加失败，不能重复添加相同的角色！" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var role = new t_role
                {
                    roleid = roleId,
                    rolename = roleName
                };
                var result = _roleRepository.AddRole(role);
                if (result)
                {
                    return Json(new { result = true, msg = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, msg = "操作失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ModifyRole(int roleId, string roleName)
        {
            var check = _roleRepository.GetRoleByConditon(roleId, roleName);

            if (check.Count() > 1)
            {
                return Json(new { result = false, msg = "添加失败，不能修改为相同的角色！" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var role = new t_role
                {
                    roleid = roleId,
                    rolename = roleName
                };
                var result = _roleRepository.ModifyRole(role);
                if (result)
                {
                    return Json(new { result = true, msg = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, msg = "操作失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteRole(int roleId)
        {
            var role = new t_role
            {
                roleid = roleId

            };

            try
            {
                var result = _roleRepository.DeleteRole(role);
                if (result)
                {
                    return Json(new { result = true, msg = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, msg = "操作失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult MenuDataSource()
        {

            var data = _menuRepository.GetMenuAll().ToList();

            return Json(new { Rows = data.Select(m => new { name = m.name, rid = m.rid }), Total = data.Count() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AttachRoleToMenu(int roleId, List<int> menus)
        {
            try
            {
                var result = _roleRepository.AttachRoleToMenu(roleId, menus);
                if (result)
                {
                    return Json(new { result = true, msg = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, msg = "操作失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetMenuByRoleId(int roleId)
        {
            var data = _roleRepository.GetMenuByRoleId(roleId).Select(m=>m.rid).ToArray();

            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUserFromRole(string userId,int roleId) {

            try
            {
                var result = _roleRepository.DeleteUserFromRole(userId,roleId);
                if (result)
                {
                    return Json(new { result = true, msg = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, msg = "操作失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
