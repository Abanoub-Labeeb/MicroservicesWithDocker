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
        public (ArrayList , ArrayList) ModelGroupsBreakdownPercentage { get; set; }
        public (ArrayList , ArrayList) ModelGroupsBreakdownNumber { get; set; }
        public string SaveFolder { get; set; } = "~/_ChartFiles/";
        public string DisplayFolder { get; set; } = "/_ChartFiles/";
        public string DisplayPath1 { get; set; }
        public string DisplayPath2 { get; set; }
        public string DisplayPath3 { get; set; }
        public string DisplayPath4 { get; set; }
        public string DisplayPath5 { get; set; }
        public string DisplayPath6 { get; set; }

    }
}