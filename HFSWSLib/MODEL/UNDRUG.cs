using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 其它非药品收费项目（UNDRUG）
    /// </summary>
    public partial class UNDRUG
    {
        /// <summary>
        /// 1	MD_UNDRUG_CODE	项目编码	是	是	VARCHAR2(12)	　	生产	不处理
        /// </summary>
        public string MD_UNDRUG_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 2	MD_UNDRUG_NAME	项目名称	否	是	VARCHAR2(100)	　	生产	不处理
        /// </summary>
        public string MD_UNDRUG_NAME
        {
            get;
            set;
        }

        /// <summary>
        ///3	MD_FEE_CODE	项目费别	否	否	VARCHAR2(3)	　	生产	不处理
        /// </summary>
        public string MD_FEE_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 4	MD_SPELL_CODE	拼音码	否	否	VARCHAR2(8)	　	生产	不处理
        /// </summary>
        public string MD_SPELL_CODE
        {
            get;
            set;
        }

        /// <summary>
        ///  5	MD_EXEDEPT_CODE	执行科室	否	否	VARCHAR2(20)	　	生产	不处理
        /// </summary>
        public string MD_EXEDEPT_CODE
        {
            get;
            set;
        }

        /// <summary>
        ///6	MD_STOCK_UNIT	单位	否	否	VARCHAR2(16)	　	生产	不处理
        /// </summary>
        public string MD_STOCK_UNIT
        {
            get;
            set;
        }

        /// <summary>
        /// 7	MD_UNIT_PRICE	价格	否	否	NUMBER(12,6)	　	生产	不处理
        /// </summary>
        public double MD_UNIT_PRICE
        {
            get;
            set;
        }

        /// <summary>
        /// 8	MD_SPECIAL_FLAG2	自费项目  	否	否	VARCHAR2(1)	1是自费，0是非自费	生产	不处理
        /// </summary>
        public string MD_SPECIAL_FLAG2
        {
            get;
            set;
        }

        /// <summary>
        /// 9	MD_SPECIAL_FLAG3	自付比例 	否	否	VARCHAR2(5)	　	生产	不处理
        /// </summary>
        public string MD_SPECIAL_FLAG3
        {
            get;
            set;
        }

        /// <summary>
        /// 10	MD_APPLICABILITYAREA	适用范围 	否	否	VARCHAR2(20)	0 全部  1 门诊 2住院 	生产	不处理
        /// </summary>
        public string MD_APPLICABILITYAREA
        {
            get;
            set;
        }


        /// <summary>
        /// 11	MD_VALID_STATE	状态	否	否	VARCHAR2(1)	　	生产	不处理
        /// </summary>
        public string MD_VALID_STATE
        {
            get;
            set;
        }

        /// <summary>
        /// 12	MD_UNDRUG_FEE_CODE	物价编码	否	否	VARCHAR2(20)	　	生产	不处理
        /// </summary>
        public string MD_UNDRUG_FEE_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 13	MD_UNDRUG_FEE_NAME	物价名称	否	否	VARCHAR2(100)	　	生产	不处理
        /// </summary>
        public string MD_UNDRUG_FEE_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 14	MD_UNDRUG_EXT1	备用一	否	否	Varchar2(40)	　	
        /// </summary>
        public string MD_UNDRUG_EXT1
        {
            get;
            set;
        }

        /// <summary>
        /// 15	MD_UNDRUG_EXT2	备用二	否	否	Varchar2(40)
        /// </summary>
        public string MD_UNDRUG_EXT2
        {
            get;
            set;
        }

        /// <summary>
        /// 16	MD_UNDRUG_EXT3	备用三	否	否	Varchar2(40)	　	
        /// </summary>
        public string MD_UNDRUG_EXT3
        {
            get;
            set;
        }

        /// <summary>
        /// 17	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public string MD_OPER_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 18	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public string MD_OPER_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 19	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public DateTime MD_OPER_TIME
        {
            get;
            set;
        }

        /// <summary>
        /// 20	DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收
        /// </summary>
        public string DOEVENT
        {
            get;
            set;
        }

    }
}
