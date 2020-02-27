using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Data;

namespace PS.Repo
{
    public interface IModelRepository : IRepository<Model>
    {
        int GetTotal();
        (ArrayList, ArrayList) GetModelGroupsBreakdownNumbers();
        (ArrayList, ArrayList) GetModelGroupsBreakdownPercentage();
    }
}
