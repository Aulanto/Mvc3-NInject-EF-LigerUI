using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LED.Domain.IRepository;
using LED.Domain.Entities;

namespace LED.WebUI.Controllers
{

    public class UserController : Controller
    {
        //
        // GET: /User/

        private IUserRepository _userRepository;
        private IOrgRepository _orgRepository;
        private IRoleRepository _roleRepository;

        public UserController(IUserRepository userRepository, IOrgRepository orgRepository, IRoleRepository roleRepository)
        {
            this._userRepository = userRepository;
            this._orgRepository = orgRepository;
            this._roleRepository = roleRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult TreeDataSource()
        {
            var data = _orgRepository.GetOrgAll().ToList().Select(m => new
            {

                orgCode = m.orgcode,
                name = m.name,
                parentCode = m.parentCode
            });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UserDataSource(string orgCode)
        {
            var data = _userRepository.GetUserByOrgCode(orgCode).ToList();
            return Json(new
            {
                Rows = data.Select(m => new
                {
                    userid = m.userid,
                    name = m.name,
                    rolename = string.Join(",", m.role == null ? new string[] { "" } : m.role.ToList().Select(r => r.rolename).Distinct())
                }),
                Total = data.Count()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddUser(string orgCode, string userId, string userName, string password)
        {
            var check = _userRepository.GetUserBySpecifiedCondition(userId);

            if (check.Count() > 1)
            {
                return Json(new { result = false, msg = "添加失败，已存在相同的用户账号！" }, JsonRequestBehavior.AllowGet);
            }

            var org = new t_user()
            {
                orgcode = orgCode,
                userid = userId,
                name = userName,
                password = password

            };

            try
            {
                var result = _userRepository.AddUser(org);
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

        public JsonResult ModifyUser(string userId, string userName, string password)
        {

            var org = new t_user()
            {
                userid = userId,
                name = userName,
                password = password

            };

            try
            {
                var result = _userRepository.ModifyUser(org);
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

        public JsonResult DeleteUser(string userId)
        {
            try
            {
                var result = _userRepository.DeleteUser(userId);
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

        public JsonResult AddRole(string userId, string userName, string roleName)
        {
            var check = _userRepository.GetUserRoleByCondition(userName, roleName);

            if (check.Count() > 1)
            {
                return Json(new { result = false, msg = "添加失败，不能重复添加相同的角色！" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var result = _userRepository.AddRole(userId, userName, roleName);
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

        public JsonResult GetRole()
        {

            var data = _roleRepository
                .GetAll()
                .ToList()
                .Select(m => new
                {
                    roleid = m.roleid,
                    rolename = m.rolename
                });

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
