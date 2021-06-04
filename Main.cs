using PoiBot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaoParse
{
    public partial class main : Form
    {
        public string client1 = "";
        public main()
        {
            InitializeComponent();
        }

        public static string clientnameplusch = "";
        public static string online = "";

        private void bclient1_Click(object sender, EventArgs e)
        {
            RaidBot client1 = new RaidBot();
            client1.Show();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (clientnameplusch.Contains("Ch1"))
            {
                tCH1.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }

            if (clientnameplusch.Contains("Ch2"))
            {
                tCH2.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }

            if (clientnameplusch.Contains("Ch3"))
            {
                tCH3.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }

            if (clientnameplusch.Contains("Ch4"))
            {
                tCH4.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }
            if (clientnameplusch.Contains("Ch5"))
            {
                tCH5.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }

            if (clientnameplusch.Contains("Ch6"))
            {
                tCH6.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }
            if (clientnameplusch.Contains("Ch7"))
            {
                tCH7.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }

            if (clientnameplusch.Contains("Ch8"))
            {
                tCH8.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }
            if (clientnameplusch.Contains("Ch9"))
            {
                tCH9.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }

            if (clientnameplusch.Contains("Ch10"))
            {
                tCH10.Text = clientnameplusch.Substring(0, clientnameplusch.IndexOf(" "));
            }


        }

        private void main_Load(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
