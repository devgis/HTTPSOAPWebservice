using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using HongFengShu.WSLib.COMMON;
using HongFengShu.WSLib.BLL;


namespace HFSWS
{
    /// <summary>
    /// HFSWS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class HFSWS : System.Web.Services.WebService
    {
        /// <summary>
        /// 同步处方信息
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "同步处方信息")]
        public string HisTransData(string xml)
        {
            return WebRequestBll.HisTransData(xml);
        }

        /// <summary>
        /// 同步科室信息
        /// </summary>
        /// <param name="xml">科室信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "同步科室信息")]
        public string deal_dept(string xml)
        {
            return WebRequestBll.deal_dept(xml);
        }

        /// <summary>
        /// 医院人员(EMPLOYEE)
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "医院人员(EMPLOYEE)")]
        public string deal_employee(string xml)
        {
            return WebRequestBll.deal_employee(xml);
        }

        /// <summary>
        /// 药品信息（DRUG）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "药品信息（DRUG）")]
        public string deal_drug(string xml)
        {
            return WebRequestBll.deal_drug(xml);
        }

        /// <summary>
        /// 其它非药品收费项目（UNDRUG）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "其它非药品收费项目（UNDRUG）")]
        private string deal_undrug(string xml)
        {
            return WebRequestBll.deal_undrug(xml);
        }

        /// <summary>
        /// 物资材料信息（MATERIAL）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "物资材料信息（MATERIAL）")]
        private string deal_material(string xml)
        {
            return WebRequestBll.deal_material(xml);
        }

        /// <summary>
        /// 供应商（PROVIDER）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "供应商（PROVIDER）")]
        private string deal_provider(string xml)
        {
            return WebRequestBll.deal_provider(xml);
        }

        /// <summary>
        /// 生产厂家（manufactorer）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        [WebMethod(Description = "生产厂家（manufactorer）")]
        private string deal_manufactorer(string xml)
        {
            return WebRequestBll.deal_manufactorer(xml);
        }
    }
}
