using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hava_Durumu_Projesi_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text=DateTime.Now.ToShortDateString();
            string api = "b3d75769ee34cb6c6615349e96465448";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Tekirda%C4%9F&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(connection);

            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var ruzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var hava_durumu = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            var hissedilen_sicaklik = hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;

            label3.Text=sicaklik.ToString();
            label7.Text = ruzgar + " m/s";
            label8.Text = nem + " %";
            label10.Text= hava_durumu.ToString();
            label13.Text=hissedilen_sicaklik.ToString();

            if(hava_durumu == "güneşli" || hava_durumu == "açık")
                pictureBox1.ImageLocation = "gunes.png";

            if(hava_durumu == "yağmurlu" || hava_durumu == "sağanak yağmur")
                pictureBox1.ImageLocation = "yagmur.png";

            if(hava_durumu == "bulutlu" || hava_durumu == "kapalı" || hava_durumu == "parçalı bulutlu" || hava_durumu == "az bulutlu")
                pictureBox1.ImageLocation = "bulutlu.png";
        }

      
    }
}
