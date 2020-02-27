using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMWSurvey
{
    public class SurveyAnalysis
    {
        public int Adolescents { get; set; }
        public double AdolescentsPercent { get; set; }
        public int Unlicensed { get; set; }
        public double UnlicensedPercent { get; set; }
        public int FirstTimers { get; set; }
        public double FirstTimersPercent { get; set; }
        public int Targetable { get; set; }
        public double TargetablePercent { get; set; }
        public double DriftingTargetablePercent { get; set; }
        public double FWDOrNOTargetablePercent { get; set; }
        public double BMWAvgAmountOwnedByTargetable { get; set; }
        public (string[] , string[]) ModelGroupsBreakdownPercentage { get; set; }
        public (string[] , string[]) ModelGroupsBreakdownNumber { get; set; }
    }
}