using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HongFengShu.WSLib.DAL;
using HongFengShu.WSLib.BLL;
using System.Xml;
using System.Net;
using System.Xml.Serialization;
using System.Collections;

namespace HFSWS.Test
{
    public partial class Form1 : Form
    {
        ServiceReference1.HFSWSSoapClient client = new ServiceReference1.HFSWSSoapClient();
        public Form1()
        {
            InitializeComponent();
        }
        #region 读取xml信息

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\employee.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var list = WebRequestDal.InitEmployee(xml);
            MessageBox.Show(list.Count.ToString());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\department.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var list=  WebRequestDal.InitDepartment(xml);
            MessageBox.Show(list.Count.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\prescription.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var request = WebRequestDal.InitHFSRequestData(xml);
            MessageBox.Show(request.PRESCRIPTION_MASTERS.Count.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\drug.xml");
            string xml = File.ReadAllText(path, Encoding.Default);

            var list = WebRequestDal.InitDrug(xml);
            MessageBox.Show(list.Count.ToString());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\undrug.xml");
            string xml = File.ReadAllText(path, Encoding.Default);

            var list = WebRequestDal.InitUuDrug(xml);
            MessageBox.Show(list.Count.ToString());
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\material.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var list = WebRequestDal.InitMaterial(xml);
            MessageBox.Show(list.Count.ToString());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\provider.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var list = WebRequestDal.InitProvider(xml);
            MessageBox.Show(list.Count.ToString());
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\manufactorer.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var list = WebRequestDal.InitManufactorer(xml);
            MessageBox.Show(list.Count.ToString());
        }
        #endregion

        #region 本地化调用
        private void button10_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\prescription.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = WebRequestBll.HisTransData(xml);
            MessageBox.Show(rs);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\department.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = WebRequestBll.deal_dept(xml);
            MessageBox.Show(rs);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\employee.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = WebRequestBll.deal_employee(xml);
            MessageBox.Show(rs);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\drug.xml");
            string xml = File.ReadAllText(path, Encoding.Default);

            var rs = WebRequestBll.deal_drug(xml);
            MessageBox.Show(rs);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\prescription2.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = WebRequestBll.HisTransData2(xml);
            MessageBox.Show(rs);
        }
        #endregion

        #region ws调用
        private void button14_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.HFSWSSoapClient();
            string path = Path.Combine(Application.StartupPath, "xmls\\prescription.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = client.HisTransData(xml);
            MessageBox.Show(rs);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.HFSWSSoapClient();
            string path = Path.Combine(Application.StartupPath, "xmls\\department.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = client.deal_dept(xml);
            MessageBox.Show(rs);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.HFSWSSoapClient();
            string path = Path.Combine(Application.StartupPath, "xmls\\employee.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = client.deal_employee(xml);
            MessageBox.Show(rs);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.HFSWSSoapClient();
            string path = Path.Combine(Application.StartupPath, "xmls\\drug.xml");
            string xml = File.ReadAllText(path, Encoding.Default);
            var rs = client.deal_drug(xml);
            MessageBox.Show(rs);
        }
        #endregion

        private void button18_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\prescription2.xml");
            string xml = File.ReadAllText(path, Encoding.Default);


            Hashtable ht = new Hashtable();
            ht.Add("xml", xml);
            XmlDocument xx = WebSvcCaller.QuerySoapWebService("http://localhost:1767/HFSWS.asmx", "HisTransData", ht);
            MessageBox.Show(xx.OuterXml);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "xmls\\prescription2.xml");
            string xml = File.ReadAllText(path, Encoding.Default);

            String url = "http://localhost:1767/HFSWS.asmx";
            String soapAction = "http://tempuri.org/HisTransData";

            var soapClient = new SoapClient(url, soapAction);
            //soapClient.Arguments.Add(new SoapParameter("requestXml", "{'Head': { 'MethodCode': 'M1001', 'Security': { 'Token': ''}},'Body': { 'FlowID': 'ca0a9a91-bb13-4717-8590-d9258f5c292f'}}"));
            soapClient.Arguments.Add(new SoapParameter("xml", xml.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")));  // 1.0方式
            //soapClient.Arguments.Add(new SoapParameter("xml",xml));  // 1.0方式
            Object ob = soapClient.GetResult();
            MessageBox.Show(ob.ToString().Replace("&amp;","&").Replace("&lt;","<").Replace("&gt;",">"));
        }
    }
}
