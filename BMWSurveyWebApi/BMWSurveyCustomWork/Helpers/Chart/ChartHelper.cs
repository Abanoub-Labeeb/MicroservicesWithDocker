using System;
using System.Collections;
//using System.Web.Helpers;

namespace BMWSurvey
{
    /**
     * deprecated : replaced by angular charts 
     * https://valor-software.com/ng2-charts/
     * https://github.com/valor-software/ng2-charts
     * ex. https://stackblitz.com/edit/ng2-charts-line-template
    **/
    public static class ChartHelper
    {
        /**
        public static void DrawBarChart(String title , ArrayList xValues, ArrayList yValues , string pathToSave) 
        {

            var myChart = new Chart(width: 700, height: 500, theme: ChartTheme.Yellow)
                               .AddTitle(title)
                               .AddSeries("Default",
                                          chartType: "Column",
                                          xValue: xValues,
                                          yValues: yValues
                                          );

            myChart.Save(path: pathToSave);
        }
        public static void DrawLineChart(String title, ArrayList xValues, ArrayList yValues, string pathToSave)
        {

            var myChart = new Chart(width: 700, height: 500, theme: ChartTheme.Yellow)
                               .AddTitle(title)
                               .AddSeries("Default",
                                          chartType: "Line",
                                          xValue: xValues,
                                          yValues: yValues
                                          );

            myChart.Save(path: pathToSave);
        }

        public static void DrawPieChart(String title, ArrayList xValues, ArrayList yValues, string pathToSave,string xField,string yField)
        {

            var myChart = new Chart(width: 700, height: 500, theme: ChartTheme.Yellow)
                               .AddTitle(title)
                               .AddSeries("Default",
                                          chartType: "Pie",
                                          xValue: xValues,
                                          xField: xField,
                                          yValues: yValues,
                                          yFields: yField
                                          );

            myChart.Save(path: pathToSave);
        }
        **/
    }
}