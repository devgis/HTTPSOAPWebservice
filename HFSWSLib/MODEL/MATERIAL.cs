using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 物资材料信息（MATERIAL）
    /// </summary>
    public class MATERIAL
    {
        /// <summary>
        ///  1	MD_MATERIAL_ID	材料（一次性物品）ID	是	是	Number(9)	HIS的输入码	生产	接收	
        /// </summary>
        public int MD_MATERIAL_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 2	MD_MATERIAL_NAME	材料（一次性物品）名称	否	是	VarChar2(100)	HIS的非药品名称	生产	接收
        /// </summary>
        public string MD_MATERIAL_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 3	MD_SPECIFICATION	规格型号	否	否	VarChar2(40)	　	生产	接收	　
        /// </summary>
        public string MD_SPECIFICATION
        {
            get;
            set;
        }

        /// <summary>
        /// 4	MD_MATERIAL_UNIT	单位	否	否	VarChar2(20)	　	生产	接收
        /// </summary>
        public string MD_MATERIAL_UNIT
        {
            get;
            set;
        }

        /// <summary>
        /// 5	MD_COST	成本价	否	否	VarChar2(20)	　	生产	接收
        /// </summary>
        public string MD_COST
        {
            get;
            set;
        }

        /// <summary>
        /// 6	MD_IS_ADMIN	是否条码管理	否	否	VarChar2(20)	HERP中用来进行高值核销，HIS需要增加相应字段	生产	接收
        /// </summary>
        public string MD_IS_ADMIN
        {
            get;
            set;
        }

        /// <summary>
        /// 7	MD_FEE_CODE	最小费用代码	否	否	VARCHAR2(4)	财务核算分类	生产	接收	传材料费编码
        /// </summary>
        public string MD_FEE_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 8	MD_UNIT_PRICE	销售价	否	否	NUMBER(12,6)	销售价格，HERP有调价功能	生产	接收	　
        /// </summary>
        public double MD_UNIT_PRICE
        {
            get;
            set;
        }

        /// <summary>
        /// 9	MD_VALID_STATE	是否停用 1 在用 0停用 2 废弃	否	否	VARCHAR2(1)	HERP中的是否停用  1是在用、0是停用	生产	接收	
        /// </summary>
        public string MD_VALID_STATE
        {
            get;
            set;
        }
       　
        /// <summary>
        /// 10	MD_IS_CHARGE	是否收费	否	是	VARCHAR2(1)	1是收费 0为不收费	生产	接收	
        /// </summary>
        public string MD_IS_CHARGE
        {
            get;
            set;
        }

        /// <summary>
        /// 11	MD_EXEDEPT_CODE	执行科室	否	否	VARCHAR2(200)	HIS需要限制材料使用科室，HERP默认全院	　	生产	可空
        /// </summary>
        public string MD_EXEDEPT_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 12	MD_PRODUCER_INFO	生产厂家	否	否	VARCHAR2(40)	　	生产	接收	　
        /// </summary>
        public string MD_PRODUCER_INFO
        {
            get;
            set;
        }

        /// <summary>
        /// 13	MD_MATERIAL_EXT1	备用一	否	否	Varchar2(40)	
        /// </summary>
        public string MD_MATERIAL_EXT1
        {
            get;
            set;
        }

        /// <summary>
        /// 14	MD_MATERIAL_EXT2	备用二	否	否	Varchar2(40)	
        /// </summary>
        public string MD_MATERIAL_EXT2
        {
            get;
            set;
        }

        /// <summary>
        /// 15	MD_MATERIAL_EXT3	备用三	否	否	Varchar2(40)	　
        /// </summary>
        public string MD_MATERIAL_EXT3
        {
            get;
            set;
        }

        /// <summary>
        /// 16	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收	　
        /// </summary>
        public string MD_OPER_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 17	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
        public string MD_OPER_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 18	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收	　
        /// </summary>
        public DateTime MD_OPER_TIME
        {
            get;
            set;
        }

        /// <summary>
        /// 19	DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收	
        /// </summary>
        public string DOEVENT
        {
            get;
            set;
        }
    }
}
