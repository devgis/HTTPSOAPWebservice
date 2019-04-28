using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongFengShu.WSLib.MODEL
{
    /// <summary>
    /// 红枫树接口请求方法
    /// </summary>
    public class HFS_REQUESTDATA
    {
        /// <summary>
        /// 调用的系统
        /// </summary>
        public string OPSYSTEM
        {
            get;
            set;
        }

        /// <summary>
        /// OPWINID
        /// </summary>
        public string OPWINID
        {
            get;
            set;
        }

        /// <summary>
        /// 操作类型代码 新处方数据	201 取消处方药品数据	202 取消整个处方数据	203
        /// </summary>
        public string OPTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 操作IP地址
        /// </summary>
        public string OPIP
        {
            get;
            set;
        }

        /// <summary>
        /// 操作员代码
        /// </summary>
        public string OPMANNO
        {
            get;
            set;
        }

        /// <summary>
        /// 操作员名称
        /// </summary>
        public string OPMANNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 处方列表
        /// </summary>
        public List<PRESCRIPTION_MASTER> PRESCRIPTION_MASTERS
        {
            get;
            set;
        }
    }
}
