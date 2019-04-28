using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HongFengShu.WSLib.COMMON
{
    /// <summary>
    /// xml文件访问帮助类
    /// </summary>
    public class XMLHelper
    {
        public static XmlNodeList getNodeList(string xml, string key)
        {
            XmlDocument xmldoc = new XmlDocument();//实例化一个XmlDocument对像
            xmldoc.LoadXml(xml);//加载为xml文档
            XmlNode node = xmldoc.FirstChild;//提取xml文档的第一个节点，其实这里也就那么一个节点，呵呵
            return xmldoc.GetElementsByTagName(key);
        }

        public static XmlNodeList selectNodeList(string xml, string key)
        {
            XmlDocument xmldoc = new XmlDocument();//实例化一个XmlDocument对像
            xmldoc.LoadXml(xml);//加载为xml文档
            XmlNode node = xmldoc.FirstChild;//提取xml文档的第一个节点，其实这里也就那么一个节点，呵呵
            return xmldoc.SelectNodes(key);
        }

        public static string getValue(string xml, string key,bool fullName=true)
        {
            XmlNodeList nodelist=null;
            if (fullName)
            {
                nodelist = selectNodeList(xml, key); ;
            }
            else
            {
                nodelist = getNodeList(xml, key);
            }
            if (nodelist.Count > 0)
            {
                return nodelist[0].InnerText;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
