using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 药品信息（DRUG）
    /// </summary>
    public class DRUG
    {
        /// <summary>
        ///  1	MD_DRUG_CODE	药品编码	是	是	VARCHAR2(12)	药品代码	生产	接收	不处理
        /// </summary>
        public string MD_DRUG_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 2	MD_TRADE_NAME	药品名称包括通用名和商品名	否	是	VARCHAR2(50)	药库名称	生产	接收	不处理
        /// </summary>
        public string MD_TRADE_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 3	MD_SPELL_CODE	拼音码包括通用名拼音码和商品名拼音码	否	否	VARCHAR2(16)	药库名称拼音码	生产	接收	不处理
        /// </summary>
        public string MD_SPELL_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 4	MD_DRUG_TYPE	药品类型	否	否	VARCHAR2(1)	HIS提供字典	生产	接收	不处理
        /// </summary>
        public string MD_DRUG_TYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 5	MD_DRUG_QUALITY	药品性质	否	否	VARCHAR2(2)	HIS提供字典	生产	接收	不处理
        /// </summary>
        public string MD_DRUG_QUALITY
        {
            get;
            set;
        }

        /// <summary>
        /// 6	MD_SPECS	规格	否	否	VARCHAR2(32)	药库规格	生产	接收	不处理
        /// </summary>
        public string MD_SPECS
        {
            get;
            set;
        }

        /// <summary>
        /// 7	MD_RETAIL_PRICE	零售价	否	否	NUMBER(12,4)	药库零价	生产	接收	不处理
        /// </summary>
        public double MD_RETAIL_PRICE
        {
            get;
            set;
        }

        /// <summary>
        /// 8	MD_PACK_UNIT	包装单位	否	否	VARCHAR2(16)	 药库单位	生产	接收	不处理
        /// </summary>
        public string MD_PACK_UNIT
        {
            get;
            set;
        }

        /// <summary>
        /// 9	MD_MODEL_CODE	剂型	否	否	VARCHAR2(10)	HIS提供字典	生产	接收	不处理
        /// </summary>
        public string MD_MODEL_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 10	MD_VALID_STATE	有效状态	否	否	VARCHAR2(1)	默认1为有效，0为无效。	生产	接收	不处理
        /// </summary>
        public int MD_VALID_STATE
        {
            get;
            set;
        }

        /// <summary>
        /// 11	MD_SELF_FLAG	自制标志	否	否	VARCHAR2(1)	自制制剂标志  1  ,0  	生产	接收	不处理
        /// </summary>
        public string MD_SELF_FLAG
        {
            get;
            set;
        }

        /// <summary>
        /// 12	MD_TEST_FLAG	是否需要皮试	否	否	VARCHAR2(1)	皮试标志     1  ,0  	生产	接收	不处理
        /// </summary>
        public string MD_TEST_FLAG
        {
            get;
            set;
        }

        /// <summary>
        /// 13	MD_APPROVE_INFO	批文信息	否	否	VARCHAR2(32)	批准文号	生产	接收	不处理
        /// </summary>
        public string MD_APPROVE_INFO
        {
            get;
            set;
        }

        /// <summary>
        /// 14	MD_OWNFEE_FLAG	自费或可报	否	否	VARCHAR2(1)	 1  自费  0 可报	生产	接收	不处理
        /// </summary>
        public string MD_OWNFEE_FLAG
        {
            get;
            set;
        }

        /// <summary>
        /// 15	MD_PUBFEERATE	自付比例	否	否	VARCHAR2(5)	如 10  代表 10%自付 20 代表20%自付	生产	接收	不处理
        /// </summary>
        public string MD_PUBFEERATE
        {
            get;
            set;
        }

        /// <summary>
        /// 16	MD_ANT_FLAG	是否抗生素	否	否	int(1)	抗生素标志    1  ,0   	生产	接收	不处理
        /// </summary>
        public int MD_ANT_FLAG
        {
            get;
            set;
        }


        /// <summary>
        /// 17	MD_ISBASEDRUG	是否基本药物	否	否	VARCHAR2(1)	‘1’ 基本药物 ‘0’ 非基本药物	生产	接收	不处理
        /// </summary>
        public string MD_ISBASEDRUG
        {
            get;
            set;
        }

        /// <summary>
        /// 18	MD_ISELECRECIPE	是否电子处方	否	否	VARCHAR2(1)	电子病历可用标志 0 不可用 1 可用	生产	接收	不处理
        /// </summary>
        public string MD_ISELECRECIPE
        {
            get;
            set;
        }

        /// <summary>
        /// 19	MD_ANTIBIOTICS_LEVEL	抗生素等级	否	否	VARCHAR2(1)	1代表一级  2代表二级 3代表三级	生产	接收	不处理
        /// </summary>
        public string MD_ANTIBIOTICS_LEVEL
        {
            get;
            set;
        }
        
        /// <summary>
        /// 20	MD_DRUG_EXT1	备用一	否	否	Varchar2(40)	
        /// </summary>
        public string MD_DRUG_EXT1
        {
            get;
            set;
        }

        /// <summary>
        /// 21	MD_DRUG_EXT2	备用二	否	否	Varchar2(40)	　	　	
        /// </summary>
        public string MD_DRUG_EXT2
        {
            get;
            set;
        }

        /// <summary>
        /// 22	MD_DRUG_EXT3	备用三	否	否	Varchar2(40)
        /// </summary>
        public string MD_DRUG_EXT3
        {
            get;
            set;
        }

        /// <summary>
        /// 23	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
        public string MD_OPER_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 24	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public string MD_OPER_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 25	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public DateTime MD_OPER_TIME
        {
            get;
            set;
        }

        /// <summary>
        /// 26	DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收
        /// </summary>
        public string DOEVENT
        {
            get;
            set;
        }
    }
}
