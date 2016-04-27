 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_3
{
    class Day
    {
        public static string date, cityName, countryName, windSpeedName, windDirection, cloudsName;

        public static int temperatureDay, temperatureMorning, temperatureEvening, temperatureNight,
            temperatureMax, temperatureMin, humidityValue, windSpeedValue, precipitation;

        public Day(string _date, string _cityName, string _countryName, string _windSpeedName, 
            string _windDirection, string _cloudsName, int _temperatureDay, int _temperatureMorning, 
            int _temperatureEvening, int _temperatureNight, int _temperatureMax, int _temperatureMin,
            int _humidityValue, int _windSpeedValue, int _precipitation)
        {
            _date = date;
            _cityName = cityName;
            _countryName = countryName;
            _windSpeedName = windSpeedName;
            _windDirection = windDirection;
            _cloudsName = cloudsName;

            _temperatureDay = temperatureDay;
            _temperatureMorning = temperatureMorning;
            _temperatureEvening = temperatureEvening;
            _temperatureNight = temperatureNight;
            _temperatureMax = temperatureMax;
            _temperatureMin = temperatureMin;
            _humidityValue = humidityValue;
            _windSpeedValue = windSpeedValue;
            _precipitation = precipitation;
        }


    }
}
