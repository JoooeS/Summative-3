 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_3
{
    class Day
    {
        public string date, windSpeedName, windDirection, cloudsName, windSpeedValue;

        public string temperatureDay, temperatureMax, temperatureMin;


        /// <summary>
        /// Constructor Method for a day
        /// </summary>
        /// <param name="_date">Date</param>
        /// <param name="_windSpeedName">Wind type</param>
        /// <param name="_windDirection">Wind Direction: N, E, W, or S</param>
        /// <param name="_cloudsName">Type of clouds</param>
        /// <param name="_temperatureDay">Average Temperature</param>
        /// <param name="_temperatureMax">Max Temperature</param>
        /// <param name="_temperatureMin">Min Temperature</param>
        /// <param name="_windSpeedValue">Speed of win</param>
        public Day(string _date, string _windSpeedName, string _windDirection, 
            string _cloudsName, string _temperatureDay, string _temperatureMax, string _temperatureMin,
            string _windSpeedValue)
        {
            _date = date;
            _windSpeedName = windSpeedName;
            _windDirection = windDirection;
            _cloudsName = cloudsName;

            _temperatureDay = temperatureDay;
            _temperatureMax = temperatureMax;
            _temperatureMin = temperatureMin;
            _windSpeedValue = windSpeedValue;
        }


    }
}
