using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 供应商（PROVIDER）
    /// </summary>
    public class PROVIDER
    {
        /// <summary>
        /// 1	MD_PRO_ID	供货商ID	是	是	Number(9)	　	生产	接收
        /// </summary>
        public int MD_PRO_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 2	MD_PRO_NAME	供货商名称	否	是	VarChar2(100)	　	生产	接收
        /// </summary>
        public string MD_PRO_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 3	MD_PRO_ADDR	地址	否	否	VarChar2(40)	　	生产	接收
        /// </summary>
        public string MD_PRO_ADDR
        {
            get;
            set;
        }

        /// <summary>
        /// 4	MD_PRO_CONTACT	联系人	否	否	VarChar2(20)	　	生产	接收
        /// </summary>
        public string MD_PRO_CONTACT
        {
            get;
            set;
        }

        /// <summary>
        /// 5	MD_PRO_TELE	电话	否	否	VarChar2(20)	　	生产	接收
        /// </summary>
        public string MD_PRO_TELE
        {
            get;
            set;
        }

        /// <summary>
        /// 6	MD_IS_STOP	是否停用	否	否	Number(9)	　	生产	接收
        /// </summary>
        public int MD_IS_STOP
        {
            get;
            set;
        }

        /// <summary>
        /// 7	MD_PRO_EXT1	备用一	否	否	Varchar2(40)	
        /// </summary>
        public string MD_PRO_EXT1
        {
            get;
            set;
        }
        /// <summary>
        /// 8	MD_PRO_EXT2	备用二	否	否	Varchar2(40)
        /// </summary>
        public string MD_PRO_EXT2
        {
            get;
            set;
        }
        /// <summary>
        /// 9	MD_PRO_EXT3	备用三	否	否	Varchar2(40)	　	　
        /// </summary>
        public string MD_PRO_EXT3
        {
            get;
            set;
        }
        /// <summary>
        /// 10	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public string MD_OPER_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 11	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public string MD_OPER_CODE
        {
            get;
            set;
        }
        /// <summary>
        /// 12	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public DateTime MD_OPER_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 13	DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收
        /// </summary>
        public string DOEVENT
        {
            get;
            set;
        }

    }
}
