using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LED.Domain.IRepository;
using LED.Domain.Entities;

namespace LED.WebUI.Controllers
{
   
    public class OrganizationController : Controller
    {
        //
        // GET: /Organization/

        private IOrgRepository _orgRepository;

        public OrganizationController(IOrgRepository orgRepository)
        {
            this._orgRepository = orgRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult OrgDataSource()
        {
            var data = _orgRepository.GetOrgParentsNode().ToList();
            var result = GetOrgs(data);
            return Json(new { Rows = result, Total = result.Count() }, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public List<dynamic> GetOrgs(IEnumerable<t_org> orgs)
        {
            var result = new List<dynamic>();
             
            foreach (var item in orgs)
            {
                var children = _orgRepository.GetOrgChildrenNodeByParentCode(item.orgcode).ToList();
                if (children == null || children.Count() == 0)
                {
                    result.Add(new
                    {
                        name = item.name,
                        orgcode = item.orgcode,
                        parentCode = item.parentCode
                    });
                }
                else
                {

                    result.Add(new
                    {
                        name = item.name,
                        orgcode = item.orgcode,
                        parentCode = item.parentCode,
                        children = GetOrgs(children)
                    });
                }
            }
            return result;
        }

        public JsonResult ParentNode()
        {
            var data = _orgRepository.GetOrgAll().ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddOrg(string parentNode, string orgName, string orgCode)
        {

            var check = _orgRepository.GetOrgBySpecifiedCondition(orgCode);

            if (check.Count() > 1)
            {
                return Json(new { result = false, msg = "添加失败，已存在相同的组织结构名称或组织机构编码！" }, JsonRequestBehavior.AllowGet);
            }

            var org = new t_org()
            {
                parentCode = parentNode,
                name = orgName,
                orgcode = orgCode
            };

            try
            {
                var result = _orgRepository.AddOrg(org);
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

        public JsonResult ModifyOrg(string orgName, string orgCode) {

            var check = _orgRepository.GetOrgBySpecifiedCondition(orgCode);

            if (check.Count() > 1)
            {
                return Json(new { result = false, msg = "修改失败，已存在相同的组织结构名称或组织机构编码！" }, JsonRequestBehavior.AllowGet);
            }

            var org = new t_org()
            {
                name = orgName,
                orgcode = orgCode
            };

            try
            {
                var result = _orgRepository.ModifyOrg(org);
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

        public JsonResult DeleteOrg(string orgCode) {

            var org = new t_org()
            {
                orgcode = orgCode
            };

            try
            {
                var result = _orgRepository.DeleteOrg(org);
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
