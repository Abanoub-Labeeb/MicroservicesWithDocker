using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PS.Data;

namespace PS.Repo
{
    public class ModelRepository : Repository<Model> , IModelRepository
    {
        #region Members
        public DbContext _context => context;
        #endregion

        #region Ctor
        public ModelRepository(DbContext context) : base(context) 
        {
        }
        #endregion

        #region Interface Fn. Impl.
        public int GetTotal()
        {
            return entityDBSet.ToList().Count();
        }

        public (ArrayList, ArrayList) GetModelGroupsBreakdownNumbers()
        {
            ArrayList modelGroups      = new ArrayList();
            ArrayList breakDownNumbers = new ArrayList();

            var groupedModels = entityDBSet.GroupBy(c => c.ModelName).Select(g => new
            {
                Model = g.Key,
                BreakDownNumber = g.Count()
            }).ToList(); 
            
            groupedModels.ForEach(r =>
            {
                modelGroups.Add(r.Model);
                breakDownNumbers.Add(r.BreakDownNumber);
            });

            return (modelGroups,breakDownNumbers);
        }

        public (ArrayList, ArrayList) GetModelGroupsBreakdownPercentage()
        {
            int total = GetTotal();
            ArrayList modelGroups = new ArrayList();
            ArrayList breakDownPercentage = new ArrayList();
            
            var groupedModels = entityDBSet.GroupBy(c => c.ModelName).Select(g => new
            {
                Model = g.Key,
                BreakDownNumber = (g.Count()*100.00)/total
            }).ToList();

            groupedModels.ForEach(r =>
            {
                modelGroups.Add(r.Model+" "+ Math.Round(r.BreakDownNumber, 2)+" %");
                breakDownPercentage.Add(r.BreakDownNumber);
            });

            return (modelGroups, breakDownPercentage);
        }
        #endregion
    }
}
