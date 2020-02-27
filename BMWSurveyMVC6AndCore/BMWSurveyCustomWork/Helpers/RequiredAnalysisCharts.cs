using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMWSurvey
{
    public class RequiredAnalysisCharts
    {
        public static void drawRequiredCharts(SurveyAnalysis surveyAnalysis) {
            AdolescentsUnlicensedFirstTimersTargetableAmounts(surveyAnalysis);
            AmountsBreakDownForEachModelGroup(surveyAnalysis);
            AdolescentsUnlicensedFirstTimersTargetablePercentageFromTotal(surveyAnalysis);
            DriftingDriveTrainPercentageFromTargetable(surveyAnalysis);
            BreakDownForEachModelGroupByPercent(surveyAnalysis);
            ModelDistributionOfAllBMWModelsEntered(surveyAnalysis);
        }

        #region Numbers - Bar charts
        private static void AdolescentsUnlicensedFirstTimersTargetableAmounts(SurveyAnalysis surveyAnalysis)
        {
            string title = "BMW Survey Analysis [Adolescents/Unlicensed/First Timers/Targetable Amounts]";
            string path = surveyAnalysis.SaveFolder + "AdolescentsUnlicensedFirstTimersTargetableAmounts.bmp";
            surveyAnalysis.DisplayPath1 = surveyAnalysis.DisplayFolder + "AdolescentsUnlicensedFirstTimersTargetableAmounts.bmp";

            ArrayList xValues = new ArrayList()
            {
                "Adolescents",
                "Unlicensed",
                "First Timers",
                "Targetable",
            };

            ArrayList yValues = new ArrayList()
            {
                surveyAnalysis.Adolescents ,
                surveyAnalysis.Unlicensed ,
                surveyAnalysis.FirstTimers ,
                surveyAnalysis.Targetable ,
            };

            ChartHelper.DrawBarChart(title, xValues, yValues, path);
        }

        private static void AmountsBreakDownForEachModelGroup(SurveyAnalysis surveyAnalysis)
        {
            string title = "BMW Survey Analysis [Amounts BreakDown For Each Model Group]";
            string path = surveyAnalysis.SaveFolder + "AmountsBreakDownForEachModelGroup.bmp";
            surveyAnalysis.DisplayPath2 = surveyAnalysis.DisplayFolder + "AmountsBreakDownForEachModelGroup.bmp";

            ArrayList xValues;
            ArrayList yValues;
            (xValues, yValues) = surveyAnalysis.ModelGroupsBreakdownNumber;
            ChartHelper.DrawBarChart(title, xValues, yValues, path);
        }
        #endregion
        
        #region Percentage - Pie Charts
        private static void AdolescentsUnlicensedFirstTimersTargetablePercentageFromTotal(SurveyAnalysis surveyAnalysis)
        {
            string title = "BMW Survey Analysis [Adolescents/Unlicensed/First Timers/Targetable Percentage From Total]";
            string path = surveyAnalysis.SaveFolder + "AdolescentsUnlicensedFirstTimersTargetablePercentageFromTotal.bmp";
            surveyAnalysis.DisplayPath3 = surveyAnalysis.DisplayFolder + "AdolescentsUnlicensedFirstTimersTargetablePercentageFromTotal.bmp";
            
            string xField = "Name";
            string yField = "Percentage";
            
            ArrayList xValues = new ArrayList()
            {
                "Adolescents:"+Math.Round(surveyAnalysis.AdolescentsPercent,2),
                "Unlicensed:"+Math.Round(surveyAnalysis.UnlicensedPercent,2),
                "First Timers:"+Math.Round(+surveyAnalysis.FirstTimersPercent,2),
                "Targetable:"+Math.Round(surveyAnalysis.TargetablePercent,2),
            };

            ArrayList yValues = new ArrayList()
            {
                surveyAnalysis.AdolescentsPercent ,
                surveyAnalysis.UnlicensedPercent ,
                surveyAnalysis.FirstTimersPercent ,
                surveyAnalysis.TargetablePercent ,
            };

            ChartHelper.DrawPieChart(title, xValues, yValues, path,xField,yField);
        }
        
        private static void DriftingDriveTrainPercentageFromTargetable(SurveyAnalysis surveyAnalysis)
        {
            string title = "BMW Survey Analysis[Drifting/DriveTrain(FWD /I Don't Know) Percentage From Targetable]";
            string path  = surveyAnalysis.SaveFolder + "DriftingDriveTrainPercentageFromTargetable.bmp";
            surveyAnalysis.DisplayPath4 = surveyAnalysis.DisplayFolder + "DriftingDriveTrainPercentageFromTargetable.bmp";
           
            ArrayList xValues = new ArrayList()
            {
                "Drifting "+Math.Round(surveyAnalysis.DriftingTargetablePercent, 2)+" %",
                "FWD /I Don't Know "+Math.Round(surveyAnalysis.FWDOrNOTargetablePercent, 2)+" %",
            };

            ArrayList yValues = new ArrayList()
            {
                surveyAnalysis.DriftingTargetablePercent ,
                surveyAnalysis.FWDOrNOTargetablePercent ,
            };

            ChartHelper.DrawBarChart(title, xValues, yValues, path);

        }

        private static void BreakDownForEachModelGroupByPercent(SurveyAnalysis surveyAnalysis)
        {
            string title = "BMW Survey Analysis [BreakDown For Each Model Group By Percent]";
            string path = surveyAnalysis.SaveFolder + "BreakDownForEachModelGroupByPercent.bmp";
            surveyAnalysis.DisplayPath5 = surveyAnalysis.DisplayFolder + "BreakDownForEachModelGroupByPercent.bmp";

            string xField = "Group Name";
            string yField = "Percentage";
            ArrayList xValues;
            ArrayList yValues;
            

            (xValues, yValues) = surveyAnalysis.ModelGroupsBreakdownPercentage;
            ChartHelper.DrawPieChart(title, xValues, yValues, path,xField,yField);
        }
        #endregion

        #region Line Charts
        private static void ModelDistributionOfAllBMWModelsEntered(SurveyAnalysis surveyAnalysis)
        {
            string title = "BMW Survey Analysis [Model Distribution Of All BMW Models Entered]";
            string path = surveyAnalysis.SaveFolder + "ModelDistributionOfAllBMWModelsEntered.bmp";
            surveyAnalysis.DisplayPath6 = surveyAnalysis.DisplayFolder + "ModelDistributionOfAllBMWModelsEntered.bmp";
            ArrayList xValues;
            ArrayList yValues;


            (xValues, yValues) = surveyAnalysis.ModelGroupsBreakdownNumber;
            ChartHelper.DrawLineChart(title, xValues, yValues, path);
        }
        #endregion






    }
}