using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Cbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            getcurrencybydate(dateTimePicker1.Value.ToString("dd.MM.yyyy"));


        }

        public void getcurrencybydate (string p_date)
        {
             
            Uri uri = new Uri($"https://www.cbar.az/currencies/{p_date}.xml");
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Proxy = null;
            WebResponse webResponse = webRequest.GetResponse();
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(webResponse.GetResponseStream());
            DataSet dt = new DataSet();
            XmlNodeReader xnr = new XmlNodeReader(doc1);
            dt.ReadXml(xnr);
            dt.Tables[1].Rows[0].Delete();
            dgwvalyuta.DataSource = dt.Tables[2];
        }
     


    }
}
