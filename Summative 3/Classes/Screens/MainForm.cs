using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;

namespace Summative_3
{
    public partial class MainForm : Form
    {
        public static string city, date;
        public static string[] dates = new string[6];
        public static List<Day> days = new List<Day>();

        public MainForm()
        {
            InitializeComponent();

            GetData();

            //ExtractCurrent();

            ExtractForecast();
        }

        private static void GetData()
        {
            WebClient client = new WebClient();

            string currentFile = "http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0";
            string forecastFile = "http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0";

            //client.DownloadFile(currentFile, "WeatherData.xml");
            client.DownloadFile(forecastFile, "WeatherData7Day.xml");
        }

        private void ExtractCurrent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;


        }

        private void ExtractForecast()
        {
            string date, windDirection, windName, cloudName, windSpeed, tMax, tMin, tDay;

            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            // Dates
            for (int i = 0; i <= 5; i++)
            {
                date = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.AddDays(i).Day.ToString();
                dates[i] = date;
            }

            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == "location")
                {
                    foreach (XmlNode gChild in child.ChildNodes)
                    {
                        if (gChild.Name == "name")
                        {
                            city = gChild.InnerText;
                        }
                    }
                }

                if (child.Name == "forecast")
                {
                    foreach (XmlNode gChild in child.ChildNodes)
                    {
                        if (gChild.Name == "time")
                        {
                            for (int i = 0; i < dates.Count(); i++)
                            {
                                if (gChild.Attributes["day"].Value == dates[i])
                                {
                                    
                                    date = dates[i];

                                    foreach (XmlNode ggchild in gChild.ChildNodes)
                                    {
                                        

                                        switch (ggchild.Name)
                                        {
                                            case "windDirection":
                                                windDirection = ggchild.Attributes["name"].Value;
                                                break;

                                            case "windSpeed":
                                                windSpeed = ggchild.Attributes["name"].Value;
                                                break;

                                            case "temperature":
                                                tDay = ggchild.Attributes["day"].Value;
                                                tMax = ggchild.Attributes["max"].Value;
                                                tMin = ggchild.Attributes["min"].Value;
                                                break;

                                            case "clouds":
                                                cloudName = ggchild.Attributes["value"].Value;
                                                break;

                                            default:
                                                break;
                                        }

                                        Day d = new Day(date, windName, windDirection, cloudName, tDay, tMax, tMin, windSpeed);
                                        days.Add(d);
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            LessInfoScreen lis = new LessInfoScreen();
            f.Controls.Add(lis);
        }
    }
}
