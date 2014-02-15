using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LED.Domain.Entities;
using LED.Domain.IRepository;
using System.Data;

namespace LED.DataProvider.RepositoryImpl
{
    public class OrgRepository : IOrgRepository
    {
        private ledContext dbContext;

        public OrgRepository(ledContext ledContext)
        {
            dbContext = ledContext;
        }

        public IEnumerable<t_org> GetOrgParentsNode()
        {
            return dbContext.t_org.Where(m => m.parentCode == null || m.parentCode == string.Empty);
        }

        public IEnumerable<t_org> GetOrgChildrenNodeByParentCode(string orgCode)
        {
            return dbContext.t_org.Where(m => m.parentCode == orgCode);
        }

        public IEnumerable<t_org> GetOrgAll()
        {
            return dbContext.t_org.Distinct();
        }

        public bool AddOrg(t_org org)
        {

            dbContext.Entry<t_org>(org).State = EntityState.Added;

            return dbContext.SaveChanges() > 0;
        }

        public bool ModifyOrg(t_org org)
        {

            dbContext.Set<t_org>().Attach(org);

            dbContext.Entry<t_org>(org).State = EntityState.Modified;

            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteOrg(t_org org)
        {

            dbContext.Set<t_org>().Attach(org);

            dbContext.Entry<t_org>(org).State = EntityState.Deleted;

            return dbContext.SaveChanges() > 0;

        }

        public IEnumerable<t_org> GetOrgBySpecifiedCondition(string orgCode)
        {
            //bool filterForParentCode = string.IsNullOrWhiteSpace(parentCode) ? true : false;

            return dbContext.t_org.Where(m => m.orgcode == orgCode);
        }
    }
}
