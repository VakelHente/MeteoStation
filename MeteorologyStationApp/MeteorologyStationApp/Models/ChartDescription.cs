using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeteorologyStationApp.Models
{
    public class ChartDescription
    {
        private int width;
        private int height;
        private string title;
        private string xAxisTitle;
        private string yAxisTitle;
        private string charType;

        public ChartDescription( int width, int height, string title, string XaxisTitle, string YaxisTitle, string charType)
        {
            this.width = width;
            this.height = height;
            this.title = title;
            this.xAxisTitle = XaxisTitle;
            this.yAxisTitle = YaxisTitle;
            this.charType = charType;
        }

        public int Width { get { return this.width; } }
        public int Height { get { return this.height; } }
        public string Title { get { return this.title; } }
        public string XAxisTitle { get { return this.xAxisTitle; } }
        public string YAxisTitle { get { return this.yAxisTitle; } }
        public string CharType { get { return this.charType; } }
    }
}