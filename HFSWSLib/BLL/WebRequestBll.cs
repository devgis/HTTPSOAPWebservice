using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HongFengShu.WSLib.DAL;

namespace HongFengShu.WSLib.BLL
{
    public class WebRequestBll
    {
        /// <summary>
        /// 同步处方信息
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string HisTransData(string xml)
        {
            return WebRequestDal.HisTransData(xml);
        }

        /// <summary>
        /// 同步处方信息根据参数DOEVENT判断是新增还是编辑或者删除
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string HisTransData2(string xml)
        {
            return WebRequestDal.HisTransData2(xml);
        }
        /// <summary>
        /// 同步科室信息
        /// </summary>
        /// <param name="xml">科室信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_dept(string xml)
        {
            return WebRequestDal.deal_dept(xml);
        }

        /// <summary>
        /// 医院人员(EMPLOYEE)
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_employee(string xml)
        {
            return WebRequestDal.deal_employee(xml);
        }

        /// <summary>
        /// 药品信息（DRUG）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_drug(string xml)
        {
            return WebRequestDal.deal_drug(xml);
        }

        /// <summary>
        /// 其它非药品收费项目（UNDRUG）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_undrug(string xml)
        {
            return WebRequestDal.deal_undrug(xml);
        }

        /// <summary>
        /// 物资材料信息（MATERIAL）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_material(string xml)
        {
            return WebRequestDal.deal_material(xml);
        }

        /// <summary>
        /// 供应商（PROVIDER）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_provider(string xml)
        {
            return WebRequestDal.deal_provider(xml);
        }

        /// <summary>
        /// 生产厂家（manufactorer）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_manufactorer(string xml)
        {
            return WebRequestDal.deal_manufactorer(xml);
        }
    }
}
