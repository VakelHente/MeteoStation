using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Globalization;
using System.Threading;

namespace MeteorologyStationApp.Models
{
    public class ServiceDatabaseModels
    {
        
        public enum TypeOfMeteorologyData { Tempreture, Humidity, Pressure };
        MeteorologyStationEntities db = new MeteorologyStationEntities();

        List<double> tempreture = new List<double>();
        List<double> humidity = new List<double>();

        public DataModels GetAllDatas(int howManyDays, TypeOfMeteorologyData typeOfMeteorologyData)
        {
            
            DataModels listOfDatas = new DataModels();
            listOfDatas.dateTime = new List<DateTime>();
            DateTime sinceWhen = DateTime.Now.AddDays(-howManyDays+1);
            if (typeOfMeteorologyData == TypeOfMeteorologyData.Humidity)
            {
                listOfDatas.outdata = new List<double>();
                foreach (var item in db.data.Where(m => m.date >= sinceWhen))
                {
                    listOfDatas.outdata.Add((double)item.humidity);
                    listOfDatas.dateTime.Add((DateTime)item.date);
                }
            }
            else if (typeOfMeteorologyData == TypeOfMeteorologyData.Tempreture)
            {
                listOfDatas.outdata = new List<double>();
                foreach (var item in db.data.Where(m => m.date >= sinceWhen))
                {
                    listOfDatas.outdata.Add((double)item.tempreture);
                    listOfDatas.dateTime.Add((DateTime)item.date);
                }
            }
            else if (typeOfMeteorologyData == TypeOfMeteorologyData.Pressure)
            {
                listOfDatas.outdata = new List<double>();
                foreach (var item in db.data.Where(m => m.date >= sinceWhen))
                {
                    listOfDatas.outdata.Add((double)item.pressure);
                    listOfDatas.dateTime.Add((DateTime)item.date);
                }
            }
            return listOfDatas;
        }

        /// <summary>
        /// Returns a specified number of rows from the database.
        /// </summary>
        /// <param name="numberOfRowToRead">Number of row to read.</param>
        /// <returns>Read data.</returns>
        public DataModels GetData(int numberOfRowToRead)
        {

            DataModels Data = new DataModels();

            Data.iddata = new List<int>();
            Data.humidity = new List<double>();
            Data.tempreture = new List<double>();
            Data.pressure = new List<double>();
            Data.dateTime = new List<DateTime>();
            Data.outdata = new List<double>();
            Data.iddevice = new List<int>();
            Data.idregion = new List<int>();

        int minID = db.data.Where(m => m.iddata >= 0).Max(m => m.iddata);
            minID -= numberOfRowToRead;

            foreach (var item in db.data.Where(m => m.iddata > minID))
            {
                Data.iddata.Add(item.iddata);
                Data.humidity.Add((double)item.humidity);
                Data.tempreture.Add((double)item.tempreture);
                Data.pressure.Add((double)item.pressure);
            }
            return Data;
        }
    }
}