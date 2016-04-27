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
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;


            for (int i = 0; i <= 5; i++)
            {

                // How to change the month when a certain number of days have been reached and what about the months that have only 30 days or 29.
                //Temporary fix
                int a = 0;
                if (DateTime.Now.AddDays(i).ToString() == "1")
                {
                    a++;
                }

                date = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.AddMonths(a).ToString("MM") + "-" + DateTime.Now.AddDays(i).Day.ToString();
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
