using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PS.Data;

namespace PS.Repo
{
    public class SurveyRepository : Repository<Survey> , ISurveyRepository
    {
        #region Members
        public DbContext _context => context;
        #endregion

        #region Ctor
        public SurveyRepository(DbContext context) : base(context) 
        {
        }
        #endregion

        #region Interface Impl.
        public int GetTotal()
        {
            return entityDBSet.ToList().Count();
        }
        public int GetAdolescents()
        {
            return entityDBSet.Where(s => s.Age < 18).Count();
        }
        public double GetAdolescentsPercent()
        {
            int total       = GetTotal();
            int adolescents = GetAdolescents();
            double percent  = 0.00;
            
            if(total != 0)
                percent  = (adolescents * 100.00) / total;

            return percent;
        }
        public int GetUnlicensed()
        {
            return entityDBSet.Where(s => s.OwnLicence == OwnLicence.No).Count();
        }
        public double GetUnlicensedPercent()
        {
            int total      = GetTotal();
            int unlicensed = GetUnlicensed();
            double percent = 0.00;

            if (total != 0)
                percent = (unlicensed * 100.00) / total;

            return percent;
        }
        public int GetFirstTimers()
        {
            return entityDBSet.Where(s => (s.FirstCar == YesNo.Yes && (s.Age >= 18 && s.Age <= 25))).Count();
        }
        public double GetFirstTimersPercent()
        {
            int total       = GetTotal();
            int firstTimers = GetFirstTimers();
            double percent  = 0.00;

            if (total != 0)
                percent = (firstTimers * 100.00) / total;

            return percent;
        }

        //above 18 , Own Licence , and not his first Car regardeless the age
        public int GetTargetable()
        {
            return entityDBSet.Where(s => (s.Age >= 18 && s.OwnLicence == OwnLicence.Yes && s.FirstCar == YesNo.No)).Count();
        }
        public double GetTargetablePercent()
        {
            int total = GetTotal();
            int targetable = GetTargetable();
            double percent = 0.00;

            if (total != 0)
                percent = (targetable * 100.00) / total;

            return percent;
        }
        public double GetDriftingTargetablePercent()
        {
            double driftTargetablesPercentage = 0.00;
            int driftTargetables = entityDBSet.Where(s => (s.Age >= 18 && s.OwnLicence == OwnLicence.Yes && s.FirstCar == YesNo.No) && (s.Drifting > 0))
                                              .Count();
            int targetable       = entityDBSet.Where(s => (s.Age >= 18 && s.OwnLicence == OwnLicence.Yes && s.FirstCar == YesNo.No))
                                              .Count();
            
            if (targetable != 0)
                driftTargetablesPercentage = (driftTargetables * 100.00) / targetable;

            return driftTargetablesPercentage;

        }

        public double GetFWDOrNOTargetablePercent()
        {
            double FWDTargetablesPercentage = 0.00;
            int FWDTargetables = entityDBSet.Where(s => (s.Age >= 18 && s.OwnLicence == OwnLicence.Yes && s.FirstCar == YesNo.No) && (s.DriveTrain == DriveTrain.FDW || s.DriveTrain == DriveTrain.DoNotKnow))
                                             .Count();
            int targetable     = entityDBSet.Where(s => (s.Age >= 18 && s.OwnLicence == OwnLicence.Yes && s.FirstCar == YesNo.No)).Count();
            
            if (targetable != 0)
                FWDTargetablesPercentage = (FWDTargetables * 100.00) / targetable;

            return FWDTargetablesPercentage;
        }

        public double? GetBMWAvgAmountOwnedByTargetable()
        {
            return entityDBSet.Where(s => (s.Age >= 18 && s.OwnLicence == OwnLicence.Yes && s.FirstCar == YesNo.No) && s.NumberOfBMWs > 0)
                              .Average(s => s.NumberOfBMWs) ?? 0.00;
        }

        #endregion

        #region Private Functions - these functions will help reducing the amount of conditions in the lambda expression 
        //Code To Test the functions 
        //this code needs further testing and modification
        //combining 2 lambda expressions having the same parameters in 1
        //var isTargetableExpression = IsTargetable();
        //var isDraftingExpression = IsDrafting();
        //var isTargetableAndisDraftingExprBody = Expression.AndAlso(isTargetableExpression.Body, isDraftingExpression.Body);
        //var isTargetableAndisDraftingExpression = Expression.Lambda<Func<Survey, bool>>(isTargetableAndisDraftingExprBody, isTargetableExpression.Parameters);
        /**
        public Expression<Func<Survey,bool>> IsTargetable()
        {
            //above 18 , Own Licence , and not his first Car regardeless the age
            Expression<Func<Survey, bool>> isTargetableExpression = ( s => (s.Age >= 18 && s.OwnLicence == YesNo.No && s.FirstCar == YesNo.No));
            return isTargetableExpression;
        }

        public Expression<Func<Survey, bool>> IsDrafting()
        {
            //above 18 , Own Licence , and not his first Car regardeless the age
            Expression<Func<Survey, bool>> isDrafingExpression = (s => s.Drifting > 0);
            return isDrafingExpression;
        }

        public Expression<Func<Survey, bool>> IsFWDOrNO()
        {
            //above 18 , Own Licence , and not his first Car regardeless the age
            Expression<Func<Survey, bool>> isTargetableExpression = (s => (s.Age >= 18 && s.OwnLicence == YesNo.No && s.FirstCar == YesNo.No));
            return isTargetableExpression;
        }
        **/
        #endregion
    }
}
