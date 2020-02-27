using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Data;

namespace PS.Repo
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        int GetTotal();
        int GetAdolescents();
        double GetAdolescentsPercent();
        int GetUnlicensed();
        double GetUnlicensedPercent();
        int GetFirstTimers();
        double GetFirstTimersPercent();
        int GetTargetable();
        double GetTargetablePercent();
        double GetDriftingTargetablePercent();
        double GetFWDOrNOTargetablePercent();
        double? GetBMWAvgAmountOwnedByTargetable();
    }
}
