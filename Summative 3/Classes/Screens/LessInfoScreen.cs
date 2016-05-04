using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Summative_3
{
    public partial class LessInfoScreen : UserControl
    {
        Button[] buttons = new Button[7];

        public LessInfoScreen()
        {
            InitializeComponent();
        }

        private void LessInfoScreen_Load(object sender, EventArgs e)
        {
            timerTime.Enabled = true;

            buttons[0] = buttonDay1;
            buttons[1] = buttonDay2;
            buttons[2] = buttonDay3;
            buttons[3] = buttonDay4;
            buttons[4] = buttonDay5;
            buttons[5] = buttonDay6;
            buttons[6] = buttonMenu;

            ButtonRegions(45, 45, Color.FromArgb(140, 0, 0, 0));

            labelTime.BackColor = Color.FromArgb(140, 0, 0, 0);
            labelCity.BackColor = Color.FromArgb(140, 0, 0, 0);

            LoadData(0);
        }

        private void ButtonRegions(int x, int y, Color colour)
        {
            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(0, 0, x, y);

            for (int i = 0; i < buttons.Count(); i++)
            {
                buttons[i].Region = new Region(circlePath);
                buttons[i].BackColor = colour;
            }

            for (int i = 0; i < 6; i++)
            {
                string day = DateTime.Now.AddDays(i).DayOfWeek.ToString();
                day = day.Substring(0, 3);

                buttons[i].Text = day;
            }

            buttonMenu.Text = "Menu";
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void LoadData(int day)
        {
            labelCity.Text = MainForm.city;
            labelDayTemp.Text = MainForm.days[day].temperatureDay + "°";
            labelHighTemp.Text = MainForm.days[day].temperatureMax + "° ↑";
            labelLowTemp.Text = MainForm.days[day].temperatureMin + "° ↓";

            labelWind.Text = MainForm.days[day].windSpeedName + MainForm.days[day].windSpeedValue + MainForm.days[day].windDirection;

            labelCloud.Text = MainForm.days[day].cloudsName;
        }
    }
}
