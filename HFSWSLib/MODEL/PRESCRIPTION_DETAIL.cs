using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 处方子表
    /// </summary>
    public class PRESCRIPTION_DETAIL
    {
        /// <summary>
        /// PresDetailID	VARCHAR2(36)	处方明细ID	✔
        /// </summary>
        public string PresDetailID
        {
            get;
            set;
        }

        /// <summary>
        /// PrescriptionID	VARCHAR2(36)	处方ID	✔
        /// </summary>
        public string PrescriptionID
        {
            get;
            set;
        }

        /// <summary>
        /// MediNo	VARCHAR2(10)	药品序号	✔
        /// </summary>
        public string MediNo
        {
            get;
            set;
        }

        /// <summary>
        /// MediCode	VARCHAR2(36)	药品编码	✔
        /// </summary>
        public string MediCode
        {
            get;
            set;
        }

        /// <summary>
        /// StoreRoom	VARCHAR2(36)	库房代码	✔
        /// </summary>
        public string StoreRoom
        {
            get;
            set;
        }

        /// <summary>
        /// Batch	VARCHAR2(36)	批次	
        /// </summary>
        public string Batch
        {
            get;
            set;
        }

        /// <summary>
        /// OriginPlace	VARCHAR2(100)	产地	
        /// </summary>
        public string OriginPlace
        {
            get;
            set;
        }

        /// <summary>
        /// BatchNo	VARCHAR2(20)	批号	
        /// </summary>
        public string BatchNo
        {
            get;
            set;
        }

        /// <summary>
        /// ExpirationDate	DATE	有效期	
        /// </summary>
        public DateTime? ExpirationDate
        {
            get;
            set;
        }

        /// <summary>
        /// Package	NUMBER(6)	包装系数	
        /// </summary>
        public int Package
        {
            get;
            set;
        }

        /// <summary>
        /// Unit	VARCHAR2(10)	发药单位	✔
        /// </summary>
        public string Unit
        {
            get;
            set;
        }

        /// <summary>
        /// Quantity	NUMBER(8)	发药数量	✔
        /// </summary>
        public double Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// TradePrice	NUMBER(16,7)	成本价	
        /// </summary>
        public double TradePrice
        {
            get;
            set;
        }

        /// <summary>
        /// TradeCost	NUMBER(16,5)	成本金额	
        /// </summary>
        public double TradeCost
        {
            get;
            set;
        }

        /// <summary>
        /// RetailPrice	NUMBER(16,7)	零售价	
        /// </summary>
        public double RetailPrice
        {
            get;
            set;
        }

        /// <summary>
        /// RetailCost	NUMBER(16,5)	零售金额	
        /// </summary>
        public double RetailCost
        {
            get;
            set;
        }

        /// <summary>
        /// Dose	NUMBER(16,7)	单次用量	✔
        /// </summary>
        public double Dose
        {
            get;
            set;
        }

        /// <summary>
        /// DoseUnit	Varchar2(10)	剂量单位	✔
        /// </summary>
        public int DoseUnit
        {
            get;
            set;
        }

        /// <summary>
        /// Usage	VARCHAR2(30)	用药途径	✔
        /// </summary>
        public string Usage
        {
            get;
            set;
        }

        /// <summary>
        /// Frequency	VARCHAR2(20)	执行频次	✔
        /// </summary>
        public string Frequency
        {
            get;
            set;
        }

        /// <summary>
        /// SendStatus	NUMBER(1)	发药状态	
        /// </summary>
        public int SendStatus
        {
            get;
            set;
        }

        /// <summary>
        /// DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收	
        /// </summary>
        public string DOEVENT
        {
            get;
            set;
        }

    }
}
