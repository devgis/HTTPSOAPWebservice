using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 生产厂家（manufactorer）
    /// </summary>
    public class MANUFACTORER
    {
        /// <summary>
        /// 1	MD_MANU_ID	生产厂商编码	是	是	Number(9)	　	生产	接收
        /// </summary>
        public int MD_MANU_ID
        {
            get;
            set;
        }


        /// <summary>
        /// 2	MD_MANU_NAME	生产厂商名称	否	是	VarChar2(100)	　	生产	接收
        /// </summary>
        public string MD_MANU_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 3	MD_IS_STOP	是否停用	否	否	VarChar2(40)	1在用、0停用	生产	接收
        /// </summary>
        public int MD_IS_STOP
        {
            get;
            set;
        }

        /// <summary>
        /// 4	MD_MANU_ADDR	地址	否	否	VarChar2(20)	　	生产	接收
        /// </summary>
        public string MD_MANU_ADDR
        {
            get;
            set;
        }

        /// <summary>
        /// 5	MD_MANU_CONTACT	联系人	否	否	VarChar2(20)	　	生产	接收
        /// </summary>
        public string MD_MANU_CONTACT
        {
            get;
            set;
        }

        /// <summary>
        /// 6	MD_MANU_TELEPHONE	电话	否	否	VarChar2(20)	　	生产	接收
        /// </summary>
        public string MD_MANU_TELEPHONE
        {
            get;
            set;
        }

        /// <summary>
        /// 7	MD_MANU_EXT1	备用一	否	否	Varchar2(40)	　
        /// </summary>
        public string MD_MANU_EXT1
        {
            get;
            set;
        }

        /// <summary>
        /// 8	MD_MANU_EXT2	备用二	否	否	Varchar2(40)
        /// </summary>
        public string MD_MANU_EXT2
        {
            get;
            set;
        }

        /// <summary>
        /// 9	MD_MANU_EXT3	备用三	否	否	Varchar2(40)	　
        /// </summary>
        public string MD_MANU_EXT3
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
