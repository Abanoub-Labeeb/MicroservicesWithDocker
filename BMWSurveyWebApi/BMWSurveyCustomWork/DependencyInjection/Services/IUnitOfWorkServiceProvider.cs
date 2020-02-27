using PS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMWSurvey
{
    public interface IUnitOfWorkServiceProvider
    {
        //just a dummy function 
        UnitOfWork GetUnitOfWork();
        int GetInstanceUniqueID();

    }
}
