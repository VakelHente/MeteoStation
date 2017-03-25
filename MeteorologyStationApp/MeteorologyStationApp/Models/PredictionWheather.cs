using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeteorologyStationApp.Models
{
    public class PredictionWheather
    {
        /// <summary>
        /// Calculate weather indicators and return weather forecast and opinion about weather.
        /// </summary>
        /// <returns>String</returns>
        public string[] Prediction()
        {
            string[] result = new string[4] { string.Empty, string.Empty, string.Empty, string.Empty };
            string opinion = string.Empty;
             
            ServiceDatabaseModels serviceDB = new ServiceDatabaseModels();
            DataModels data = new DataModels();

            data = serviceDB.GetData(3);

            opinion = OpinionPrediction(data);

            result[0] = PressurePrediction(data);
            result[1] = HumidityPrediction(data);
            result[2] = TemperaturePrediction(data);
            result[3] = opinion;

            return result; 
        }

        private enum forecastOfTemperature { Good, Bad, Normal}
        private enum forecastOfHumidity { Bad, Normal}
        private enum forecastOfPressure { Good, Bad, VeryBad, Normal}

        private forecastOfPressure foPressure = forecastOfPressure.Normal;
        private forecastOfHumidity foHumidity = forecastOfHumidity.Normal;
        private forecastOfTemperature foTemperature = forecastOfTemperature.Normal;

        private string OpinionPrediction(DataModels data)
        {
            string goodResult = "Dobre warunki pogodowe.";
            string badResult = "Złe warunki, nie przebywać w pobliżu stacji meteo.";
            string normalResult = "Warunki pogodowe w normie.";

            switch (foPressure)
            {
                case forecastOfPressure.Good:
                    #region Pressure Good
                    switch (foTemperature)
                    {
                        case forecastOfTemperature.Good:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return normalResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return goodResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Bad:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return normalResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Normal:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return goodResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        default:
                            return normalResult;
                    }
                    #endregion
                    break;
                case forecastOfPressure.Bad:
                    #region Pressure Bad
                    switch (foTemperature)
                    {
                        case forecastOfTemperature.Good:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return normalResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return goodResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Bad:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return badResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Normal:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return normalResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        default:
                            return normalResult;
                    }
                    #endregion
                    break;
                case forecastOfPressure.VeryBad:
                    #region Pressure Very Bad
                    switch (foTemperature)
                    {
                        case forecastOfTemperature.Good:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return badResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Bad:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return badResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Normal:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return badResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        default:
                            return normalResult;
                    }
                    #endregion
                    break;
                case forecastOfPressure.Normal:
                    #region Pressure Normal
                    switch (foTemperature)
                    {
                        case forecastOfTemperature.Good:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return normalResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return goodResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Bad:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return normalResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        case forecastOfTemperature.Normal:
                            switch (foHumidity)
                            {
                                case forecastOfHumidity.Bad:
                                    return badResult;
                                    break;
                                case forecastOfHumidity.Normal:
                                    return normalResult;
                                    break;
                                default:
                                    return normalResult;
                            }
                            break;
                        default:
                            return normalResult;
                    }
                    #endregion
                    break;
                default:
                    return normalResult;
            }
        }

        private string PressurePrediction(DataModels data)
        {
            if(data.pressure[0] > data.pressure[1] && data.pressure[1] > data.pressure[2])
            {
                double difference = data.pressure[0] - data.pressure[1] + data.pressure[1] - data.pressure[2];
                if (difference >= 2 && difference <= 4)
                {
                    foPressure = forecastOfPressure.Bad;
                    return "- przednia część niżu, możliwy wzrost prędkości wiatru,";
                }
                else
                {
                    foPressure = forecastOfPressure.VeryBad;
                    return "- nadciąga niż, możliwe opady, silny wiatr,";
                }
            }
            else if(data.pressure[0] < data.pressure[1] && data.pressure[1] < data.pressure[2])
            {
                double difference = data.pressure[1] - data.pressure[0] + data.pressure[2] - data.pressure[1];
                if (difference >= 4)
                {
                    foPressure = forecastOfPressure.Bad;
                    return "- przejście frontu chłodnego, możliwy wzrost prędkości wiatru,";
                }
                else
                {
                    foPressure = forecastOfPressure.Good;
                    return "- nadciąga wyż, możliwa poprawa pogody,";
                }
            }
            else
            {
                foPressure = forecastOfPressure.Normal;
                return "- cieśnienie atmosferyczne w normie,";
            }
        }

        private string HumidityPrediction(DataModels data)
        {
            string result = string.Empty;

            if (data.humidity[0] > data.humidity[1] && data.humidity[1] > data.humidity[2])
            {
                foHumidity = forecastOfHumidity.Normal;
                return "- wilgotność powietrza maleje,";
            }
            else if (data.humidity[0] < data.humidity[1] && data.humidity[1] < data.humidity[2])
            {

                if ((data.tempreture[0] < data.tempreture[1] && data.tempreture[1] < data.tempreture[2]) && (data.pressure[0] > data.pressure[1] && data.pressure[1] > data.pressure[2]))
                {
                    foHumidity = forecastOfHumidity.Bad;
                    return "- możliwe opady deszczu lub burza,";
                }
                else if (data.tempreture[0] > data.tempreture[1] && data.tempreture[1] > data.tempreture[2])
                {
                    foHumidity = forecastOfHumidity.Bad;
                    return "- możliwe występowanie mgły,";
                }
                else if (data.pressure[0] > data.pressure[1] && data.pressure[1] > data.pressure[2])
                {
                    foHumidity = forecastOfHumidity.Bad;
                    return "- możliwe wystapienie burzy,";
                }
                else
                {
                    foHumidity = forecastOfHumidity.Normal;
                    return "- wilogtność powietrza rosnie,";
                }
            }
            else
            {
                foHumidity = forecastOfHumidity.Normal;
                return "- wilgotnośc powietrza w normie.";
            }
        }

        private string TemperaturePrediction(DataModels data)
        {
            if (data.tempreture[0] > data.tempreture[1] && data.tempreture[1] > data.tempreture[2])
            {
                foTemperature = forecastOfTemperature.Bad;
                return "- nadchodzi front chłodny, możliwe pogorszenie pogody.";
            }
            else if (data.tempreture[0] < data.tempreture[1] && data.tempreture[1] < data.tempreture[2])
            {
                foTemperature = forecastOfTemperature.Good;
                return "- zbliżanie się frontu ciepłego.";
            }
            else
            {
                foTemperature = forecastOfTemperature.Normal;
                return "- temperatura w normie.";
            }
        }
    }
}