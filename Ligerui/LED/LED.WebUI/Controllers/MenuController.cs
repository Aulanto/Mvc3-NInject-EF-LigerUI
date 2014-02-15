using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LED.Domain.IRepository;
using LED.Domain.Entities;

namespace LED.WebUI.Controllers
{
   
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        private IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {

            this._menuRepository = menuRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult MenuDataSource()
        {

            var data = _menuRepository.GetMenuParentsNode().ToList();

            var list = new List<dynamic>();

            foreach (var item in data)
            {
                var children = _menuRepository.GetMenuChildrenNodeByParentId(item.rid).ToList();

                if (children == null || children.Count() == 0)
                {
                    list.Add(new
                    {
                        name = item.name, 
                        tindex = item.tindex,
                        url = item.url,
                        rid=item.rid,
                        parentrid = item.parentrid
                    });
                }
                else
                {
                    list.Add(new
                    {
                        name = item.name,
                        tindex = item.tindex,
                        url = item.url,
                        rid = item.rid,
                        parentrid = item.parentrid,
                        children = children.Select(m => new {
                            name = m.name,
                            tindex = m.tindex,
                            url = m.url,
                            rid = m.rid,
                            parentrid = m.parentrid
                        })
                    });
                }
            }

            return Json(new
            {
                Rows = list,
                Total = list.Count()
            }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ParentNode()
        {

            var data = _menuRepository.GetMenuParentsNode().ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddMenu(int? parentNode, string pageName, string url,int?index)
        {
            var check = _menuRepository.GetMenuByCondition(pageName, url);

            if (check.Count() > 1)
            {
                return Json(new { result = false, msg = "修改失败，已存在相同的菜单！" }, JsonRequestBehavior.AllowGet);
            }
            var menu = new t_resources()
            {
                name = pageName,
                url = url,
                parentrid = parentNode,
                tindex=index
            };

            try
            {
              var result= _menuRepository.AddMenu(menu);
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

        public JsonResult DeleteMenu(int rid)
        {
            var menu = new t_resources()
            {
                rid=rid
            };

            try
            {
                var result = _menuRepository.DeleteMenu(menu);
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

        public JsonResult ModifyMenu(string pageName, int? index, string url, int rid, int? parentrid)
        {
            var check = _menuRepository.GetMenuByCondition(pageName,url);

            if (check.Count() > 1) {
                return Json(new { result = false, msg = "修改失败，已存在相同的菜单！" }, JsonRequestBehavior.AllowGet);
            }

            var menu = new t_resources()
            {
                name=pageName,
                tindex=index,
                url=url,
                rid=rid,
                parentrid=parentrid
            };

            try
            {
                var result = _menuRepository.UpdateMenu(menu);
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
