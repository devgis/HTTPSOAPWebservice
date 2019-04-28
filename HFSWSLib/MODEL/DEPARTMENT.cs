using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 部门
    /// </summary>
    public class DEPARTMENT
    {
        /// <summary>
        /// 1	MD_COMP_CODE	单位编码	否	是	Varchar2(20)	　	生产	接收	　
        /// </summary>
        public string MD_COMP_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 2	MD_DEPT_CODE	部门编码	是	是	Varchar2(20)	　	生产	接收		　
        /// </summary>
        public string MD_DEPT_CODE
        {
            get;
            set;
        }
        
        /// <summary>
        /// 3	MD_DEPT_NAME	部门名称	否	是	Varchar2(40)	　	生产	接收		　
        /// </summary>
        public string MD_DEPT_NAME
        {
            get;
            set;
        }

        /// <summary>
        ///4	MD_DEPT_ENG_NAME	科室英文名	否	否	Varchar2(40)	　	生产	接收	可空	　
        /// </summary>
        public string MD_DEPT_ENG_NAME
        {
            get;
            set;
        }

        /// <summary>
        ///5	MD_DEPT_DEFINED	自定义码	否	否	Varchar2(40)	　	生产	接收	可空	　
        /// </summary>
        public string MD_DEPT_DEFINED
        {
            get;
            set;
        }

        /// <summary>
        /// 6	MD_DEPT_SEQUENCE	排序号	否	否	number	加载科室时的加载顺序	生产	接收	可空　
        /// </summary>
        public int MD_DEPT_SEQUENCE
        {
            get;
            set;
        }


        /// <summary>
        ///7	MD_DEPT_SHORT	科室简称	否	否	Varchar2(40)	　	生产	接收	可空	　
        /// </summary>
        public string MD_DEPT_SHORT
        {
            get;
            set;
        }

        /// <summary>
        /// 8	MD_DEPT_ACCOUNT	是否核算科室	否	否	Varchar2(8)	　	生产	接收	　		　
        /// </summary>
        public string MD_DEPT_ACCOUNT
        {
            get;
            set;
        }

        /// <summary>
        /// 9	MD_DEPT_SPECIAL	特殊科室属性	否	否	Varchar2(40)	特殊科室属性字典	生产	接收　
        /// </summary>
        public string MD_DEPT_SPECIAL
        {
            get;
            set;
        }　

        /// <summary>
        /// 10	MD_IS_REGISTER	是否挂号科室	否	否	Varchar2(8)	　	生产	接收		　
        /// </summary>
        public string MD_IS_REGISTER
        {
            get;
            set;
        }

        /// <summary>
        /// 11	MD_SUPER_CODE	上级编码	否	否	Varchar2(20)	上级科室的编码	生产	接收		　
        /// </summary>
        public string MD_SUPER_CODE
        {
            get;
            set;
        }　
　
        /// <summary>
        /// 12	MD_DEPT_LEVEL	部门级别	否	否	Varchar2(20)	　	生产	接收			　
        /// </summary>
        public string MD_DEPT_LEVEL
        {
            get;
            set;
        }

        /// <summary>
        /// 13	MD_SPELL	拼音码	否	否	Varchar2(8)	　	生产	接收	可空　
        /// </summary>
        public string MD_SPELL
        {
            get;
            set;
        }

        /// <summary>
        /// 14	MD_WUBI	五笔码	否	否	Varchar2(8)	　	生产	接收	可空　
        /// </summary>
        public string MD_WUBI
        {
            get;
            set;
        }

        /// <summary>
        /// 15	MD_ARRT_CODE	科室类型	否	否	Varchar2(20)	科室类型字典	生产	接收			　
        /// </summary>
        public string MD_ARRT_CODE
        {
            get;
            set;
        }
        /// <summary>
        /// 16	MD_IS_FUNC	职能部门标志	否	否	Varchar2(20)	　	生产	接收	可空		　
        /// </summary>
        public string MD_IS_FUNC
        {
            get;
            set;
        }

        /// <summary>
        /// 17	MD_IS_BUDG	预算标志	否	否	Varchar2(20)	　	生产	接收	可空	　
        /// </summary>
        public string MD_IS_BUDG
        {
            get;
            set;
        }
	
　      /// <summary>
        /// 18	MD_IS_LAST	末级标志	否	否	Varchar2(20)	　	生产	接收		　
        /// </summary>
        public string MD_IS_LAST
        {
            get;
            set;
        }

    　  /// <summary>
        /// 19	MD_IS_STOCK	采购标志	否	否	Varchar2(20)	　	生产	接收			　
        /// </summary>
        public string MD_IS_STOCK
        {
            get;
            set;
        }
        /// <summary>
        /// 20	MD_IS_STOP	停用标志	否	否	Varchar2(20)	　	生产	接收			　
        /// </summary>
        public string MD_IS_STOP
        {
            get;
            set;
        }
        /// <summary>
        /// 21	MD_IS_OUTER	外部单位标志	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>

        public string MD_IS_OUTER
        {
            get;
            set;
        }
        /// <summary>
        /// 22	MD_DEPT_ADDR	部门地址	否	否	Varchar2(100)	　	生产	接收	
        /// </summary>
　       public string MD_DEPT_ADDR
        {
            get;
            set;
        }
        /// <summary>
        /// 23	MD_ORI_BEDNUM	编制床位数	否	否	number	　	生产	接收
        /// </summary>
        public int MD_ORI_BEDNUM
        {
            get;
            set;
        }
        /// <summary>
        /// 24	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
　      public string MD_OPER_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 25	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
	    public string MD_OPER_CODE
        {
            get;
            set;
        }
        /// <summary>
        /// 26	MD_OPER_TIME	操作时间	否	否	Va26	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收	
        ///
        public DateTime MD_OPER_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 27	MD_DEPT_EXT1	备用一	否	否	Varchar2(100)	　	生产	接收	　
        /// </summary>
        public string MD_DEPT_EXT1
        {
            get;
            set;
        }
        /// <summary>
        /// 28	MD_DEPT_EXT2	备用二	否	否	Varchar2(100)	　	生产	接收	　
        /// </summary>
        public string MD_DEPT_EXT2
        {
            get;
            set;
        }
        /// <summary>
        /// 29	MD_DEPT_EXT3	备用三	否	否	Varchar2(100)	　	生产	接收	
        /// </summary>
　      public string MD_DEPT_EXT3
        {
            get;
            set;
        }
        /// <summary>
        /// 30	DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收	
        /// </summary>
　      public string DOEVENT
        {
            get;
            set;
        }

    }
}
