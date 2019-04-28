using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 处方主表
    /// </summary>
    public class PRESCRIPTION_MASTER
    {
        /// <summary>
        /// PrescriptionID	VARCHAR2(36)	处方ID	✔
        /// </summary>
        public string PrescriptionID
        {
            get;
            set;
        }

        /// <summary>
        /// Deliver_No	VARCHAR2(10)	发药流水号	
        /// </summary>
        public string Deliver_No
        {
            get;
            set;
        }

        /// <summary>
        /// PrescriptionNo	VARCHAR2(36)	处方号	✔
        /// </summary>
        public string PrescriptionNo
        {
            get;
            set;
        }

        /// <summary>
        /// RecriptNO	VARCHAR2(36)	收据号（发票号）
        /// </summary>
        public string RecriptNO
        {
            get;
            set;
        }

        /// <summary>
        /// PrescriptionSource	NUMBER(1)	处方来源 1-门诊 2-住院	✔
        /// </summary>
        public int PrescriptionSource
        {
            get;
            set;
        }

        /// <summary>
        /// PrescriptionAttribute	NUMBER(1)	处方属性 0-普通 1-儿科 2-毒麻精3-急诊	
        /// </summary>
        public int PrescriptionAttribute
        {
            get;
            set;
        }

        /// <summary>
        /// PatientID	VARCHAR2(36)	患者标识	✔
        /// </summary>
        public string PatientID
        {
            get;
            set;
        }

        /// <summary>
        /// OutpNo	VARCHAR2(36)	门诊号	
        /// </summary>
        public string OutpNo
        {
            get;
            set;
        }

        /// <summary>
        /// InpNo	VARCHAR2(36)	住院号	✔
        /// </summary>
        public string InpNo
        {
            get;
            set;
        }

        /// <summary>
        /// PatientName	VARCHAR2(20)	患者姓名	✔
        /// </summary>
        public string PatientName
        {
            get;
            set;
        }

        /// <summary>
        /// Sex	NUMBER(1)	患者性别 1-男 2-女	✔
        /// </summary>
        public int Sex
        {
            get;
            set;
        }


        /// <summary>
        /// BirthDay	DATE	出生日期	✔
        /// </summary>
        public DateTime BirthDay
        {
            get;
            set;
        }

        /// <summary>
        /// DeptName	VARCHAR2(50)	诊疗科室	✔
        /// </summary>
        public string DeptName
        {
            get;
            set;
        }

        /// <summary>
        /// DeptCode	VARCHAR2(50)	科室编号	
        /// </summary>
        public string DeptCode
        {
            get;
            set;
        }

        /// <summary>
        /// DoctorName	VARCHAR2(20)	诊疗医生	✔
        /// </summary>
        public string DoctorName
        {
            get;
            set;
        }

        /// <summary>
        /// IsPay	NUMBER(1)	收费标示 0-未收费1-已收费	
        /// </summary>
        public int IsPay
        {
            get;
            set;
        }

        /// <summary>
        /// PayDate	DATE	收费日期	
        /// </summary>
        public DateTime PayDate
        {
            get;
            set;
        }

        /// <summary>
        /// ward	VARCHAR2(60)	病区	✔
        /// </summary>
        public string ward
        {
            get;
            set;
        }

        /// <summary>
        /// wardcode	VARCHAR2(60)	病区编号	✔
        /// </summary>
        public string wardcode
        {
            get;
            set;
        }

        /// <summary>
        /// usage	DATE	服用时间	✔
        /// </summary>
        public DateTime usage
        {
            get;
            set;
        }

        /// <summary>
        /// bedno	VARCHAR2(10)	床号	✔
        /// </summary>
        public string bedno
        {
            get;
            set;
        }

        /// <summary>
        /// 明细列表
        /// </summary>
        public List<PRESCRIPTION_DETAIL> Details
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
