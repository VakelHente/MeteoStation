using System.Web.Helpers;

namespace MeteorologyStationApp.Models
{
    public class GenerateSpecifiedChartType
    {
        public enum ChartTypes { Area, Bar, Column, Line, Pie, Stock };
        public enum ChartName { Temperature, Humidity, Pressure};
        private ChartDescription chartDescription;

        public byte[] Chart(ChartName name, string type, int daysNumber)
        {
            ServiceDatabaseModels.TypeOfMeteorologyData typeOfChart = ServiceDatabaseModels.TypeOfMeteorologyData.Tempreture;
            switch(name)
            {
                case ChartName.Temperature:
                    {
                        this.chartDescription = new ChartDescription(700, 700, "Temperature chart", "Time [h]", "Temperature [oC]", type);
                        typeOfChart = ServiceDatabaseModels.TypeOfMeteorologyData.Tempreture;
                        break;
                    }
                case ChartName.Humidity:
                    {
                        this.chartDescription = new ChartDescription(700, 700, "Humidity chart", "Time [h]", "Humidity [%]", type);
                        typeOfChart = ServiceDatabaseModels.TypeOfMeteorologyData.Humidity;
                        break;
                    }
                case ChartName.Pressure:
                    {
                        this.chartDescription = new ChartDescription(700, 700, "Pressure chart", "Time [h]", "Pressure [hPa]", type);
                        typeOfChart = ServiceDatabaseModels.TypeOfMeteorologyData.Pressure;
                        break;
                    }
            }
            return GenerateChart(chartDescription, daysNumber, typeOfChart);
        }
        
        private byte[] GenerateChart(ChartDescription descrip, int daysNumber, ServiceDatabaseModels.TypeOfMeteorologyData typeOfChart)
        {
            var db = new ServiceDatabaseModels();
            var data = db.GetAllDatas(daysNumber, typeOfChart);

            var resultChart = new Chart(width: 800, height: 800)
                            .AddSeries
                            (
                                chartType: descrip.CharType,
                                xValue: data.dateTime, xField: descrip.XAxisTitle,
                                yValues: data.outdata, yFields: descrip.YAxisTitle
                            )
                            .GetBytes("png");

            return resultChart;
        }

        private ChartDescription GetDescription() { return this.chartDescription; }
    }
}