using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 医院人员(EMPLOYEE)
    /// </summary>
    public class EMPLOYEE
    {
        /// <summary>
        /// 1	MD_EMP_CODE	人员编码	是	是	Varchar2(20)	　	生产	接收	　
        /// </summary>
        public string MD_EMP_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 2	MD_EMP_NAME	姓名	否	是	Varchar2(20)	　	生产	接收	
        /// </summary>
        public string MD_EMP_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 3	MD_STAMP_NO	印章号	否	否	Varchar2(20)	HERP定义之后进行同步推送	　	生产	可空
        /// </summary>
        public string MD_STAMP_NO
        {
            get;
            set;
        }

        /// <summary>
        /// 4	MD_DEPT_CODE	所属科室编码	否	是	Varchar2(20)	　	生产	接收	　
        /// </summary>
        public string MD_DEPT_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 5	MD_COMP_CODE	单位编码	否	否	Varchar2(20)	　	生产	接收
        /// </summary>
        public string MD_COMP_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 6	MD_BIRTHDAY	出生日期	否	否	date	　	生产	接收	　
        /// </summary>
        public DateTime MD_BIRTHDAY
        {
            get;
            set;
        }

        /// <summary>
        /// 7	MD_EMP_IDNO	身份证号	是	是	Varchar2(20)	　	生产	接收
        /// </summary>
        public string MD_EMP_IDNO
        {
            get;
            set;
        }

        /// <summary>
        /// 8	MD_SEX	性别	否	否	Varchar2(20)	性别字典	生产	接收
        /// </summary>
        public string MD_SEX
        {
            get;
            set;
        }

        /// <summary>
        /// 9	MD_PHONE	联系电话	否	否	Varchar2(40)	　	生产	接收
        /// </summary>
        public string MD_PHONE
        {
            get;
            set;
        }

        /// <summary>
        /// 10	MD_EMAIL	邮箱	否	否	Varchar2(40)	　	生产	接收
        /// </summary>
        public string MD_EMAIL
        {
            get;
            set;
        }

        /// <summary>
        /// 11	MD_INPUT_CODE	拼音码	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
        public string MD_INPUT_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 12	MD_WUBI_CODE	五笔码	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
        public string MD_WUBI_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 13	MD_EMP_TYPE	人员类型	否	否	Varchar2(20)	人员类型字典	生产	接收
        /// </summary>
        public string MD_EMP_TYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 14	MD_WORK	职务	否	否	Varchar2(20)	职务字典	生产	接收
        /// </summary>
        public string MD_WORK
        {
            get;
            set;
        }

        /// <summary>
        /// 15	MD_WORK_LEVEL	职务等级	否	否	Varchar2(20)	　	生产	接收	　
        /// </summary>
        public string MD_WORK_LEVEL
        {
            get;
            set;
        }

        /// <summary>
        /// 16	MD_TITLE	职称（HERP）	否	否	Varchar2(20)	HERP职称字典HIS职级	生产	接收	　
        /// </summary>
        public string MD_TITLE
        {
            get;
            set;
        }

        /// <summary>
        /// 17	MD_TITLE_HERP	职级	否	否	Varchar2(20)	HERP职级，HIS不解析	生产	接收	
        /// </summary>
        public string MD_TITLE_HERP
        {
            get;
            set;
        }

        /// <summary>
        /// 18	MD_EDUCATION	学历	否	否	Varchar2(20)	学历字典	生产	接收	　
        /// </summary>
        public string MD_EDUCATION
        {
            get;
            set;
        }

        /// <summary>
        /// 19	MD_IS_TALENT	人才标志	否	否	Varchar2(20)	是否标志	生产	接收	废弃
        /// </summary>
        public string MD_IS_TALENT
        {
            get;
            set;
        }


        /// <summary>
        /// 20	MD_TALENT_TYPE	人才类别	否	否	Varchar2(20)	人才类别字典	生产	接收	废弃
        /// </summary>
        public string MD_TALENT_TYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 21	MD_CREATE_DATE	创建日期	否	否	date	　	生产	接收	　
        /// </summary>
        public DateTime MD_CREATE_DATE
        {
            get;
            set;
        }

        /// <summary>
        /// 22	MD_IS_STOP	停用标志	否	否	Varchar2(20)	是否标志	生产	接收
        /// </summary>
        public string MD_IS_STOP
        {
            get;
            set;
        }

        /// <summary>
        /// 23	MD_EMP_EXT1	备用一	否	否	Varchar2(40)	　	　	
        /// </summary>
        public string MD_EMP_EXT1
        {
            get;
            set;
        }

        /// <summary>
        /// 24	MD_EMP_EXT2	备用二	否	否	Varchar2(40)	　
        /// </summary>
        public string MD_EMP_EXT2
        {
            get;
            set;
        }

        /// <summary>
        /// 25	MD_EMP_EXT3	备用三	否	否	Varchar2(40)	　
        /// </summary>
        public string MD_EMP_EXT3
        {
            get;
            set;
        }

        /// <summary>
        /// 26	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
        public string MD_OPER_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 27	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收	　
        /// </summary>
        public string MD_OPER_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 28	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
        public DateTime MD_OPER_TIME
        {
            get;
            set;
        }

        /// <summary>
        /// 29	DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收	　
        /// </summary>
        public string DOEVENT
        {
            get;
            set;
        }

    }
}
