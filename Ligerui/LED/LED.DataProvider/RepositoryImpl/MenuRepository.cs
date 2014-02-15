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
    public class MenuRepository : IMenuRepository
    {
        private ledContext dbContext;

        public MenuRepository(ledContext ledContext)
        {

            dbContext = ledContext;
        }
        public IEnumerable<t_resources> GetMenuParentsNode()
        {
            return dbContext.t_resources.Where(m => m.parentrid == null).OrderBy(m => m.tindex);
        }

        public IEnumerable<t_resources> GetMenuChildrenNodeByParentId(int? rid)
        {
            return dbContext.t_resources.Where(m => m.parentrid == rid).OrderBy(m => m.tindex);
        }


        public bool AddMenu(t_resources menu)
        {
            dbContext.Entry<t_resources>(menu).State = EntityState.Added;
            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteMenu(t_resources menu)
        {
            dbContext.Set<t_resources>().Attach(menu);

            dbContext.Entry<t_resources>(menu).State = EntityState.Deleted;

            return dbContext.SaveChanges() > 0;
        }


        public bool UpdateMenu(t_resources menu)
        {
            dbContext.Set<t_resources>().Attach(menu);

            dbContext.Entry<t_resources>(menu).State = EntityState.Modified;

            return dbContext.SaveChanges() > 0;
        }


        public IEnumerable<t_resources> GetMenuByCondition(string pageName, string url)
        {
            return dbContext.t_resources.Where(m => m.name == pageName && m.url == url);
        }


        public IEnumerable<t_resources> GetMenuAll()
        {
            return dbContext.t_resources;
        }
    }
}
