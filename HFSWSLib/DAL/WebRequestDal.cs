using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Data.SqlClient;
using HongFengShu.WSLib.COMMON;
using HongFengShu.WSLib.MODEL;
using System.Data;

namespace HongFengShu.WSLib.DAL
{
    public class WebRequestDal
    {
        
        #region 共有方法
        /// <summary>
        /// 同步处方信息
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string HisTransData(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return getResult(-1, "xml文件内容为空"); //校验失败
            }

            var request = InitHFSRequestData(xml);//解析xml

            ////用户输入校验
            //string errors = Check(listDrugInfo);
            //if (!string.IsNullOrEmpty(errors))
            //{
            //    return getResult(1, errors); //校验失败
            //}
            
            List<string> listsqls = new List<string>();
            List<SqlParameter[]> listparameters = new List<SqlParameter[]>();

            foreach (var master in request.PRESCRIPTION_MASTERS)
            {
                string sql = string.Empty;

                //liyafei 需要查询是否存在
                
                string pid = GetPrescriptionID(master.PrescriptionNo);
                string sqlmain = string.Empty;
                string sqlsub = string.Empty;

                SqlParameter[] parametersmain = new SqlParameter[32];
                SqlParameter[] parameterssub = new SqlParameter[22];
                if (!string.IsNullOrEmpty(pid)) //修改
                {
                    //主表修改
                    sqlmain = "UPDATE T_PRESCRIPTION_MASTER_TEMP SET "
                        + "DELIVER_NO=@DELIVER_NO,PRESCRIPTIONNO=@PRESCRIPTIONNO,"
                        + "PRESCRIPTIONSOURCE=@PRESCRIPTIONSOURCE,PRESCRIPTIONATTRIBUTE =@PRESCRIPTIONATTRIBUTE,"
                        + "PATIENTID=@PATIENTID,OUTPNO=@OUTPNO,INPNO=@INPNO,PATIENTNAME=@PATIENTNAME,"
                        +"SEX=@SEX,BIRTHDAY=@BIRTHDAY,DEPTNAME=@DEPTNAME,DOCTORNAME=@DOCTORNAME,"
                        + "ISPAY=@ISPAY,PAYDATE=@PAYDATE,PRINTSTATUS=@PRINTSTATUS,SENDSTATUS=@SENDSTATUS,"
                        +"SENDER=@SENDER,SENDDATE=@SENDDATE,LAYOUTSTATUS=@LAYOUTSTATUS,"
                        +"LAYOUTER=@LAYOUTER,LAYOUTDATE=@LAYOUTDATE,WINDOWNO=@WINDOWNO,"
                        + "EQUIPNOOFFAST=@EQUIPNOOFFAST,EQUIPNOOFEASY=@EQUIPNOOFEASY,WARD=@WARD,"
                        + "USAGE=@USAGE,BEDNO=@BEDNO,EQUIPNOOFPACK=@EQUIPNOOFPACK,"
                        + "[快发发药状态]=@STATUSOFFAST,[分包发药状态]=@STATUSOFPACK,"
                        + "SORTSTATE=@SORTSTATE "
                        + "WHERE PRESCRIPTIONID=@PRESCRIPTIONID";
                }
                else //添加
                {
                    pid = Guid.NewGuid().ToString();
                    //主表新增
                    sqlmain = "INSERT INTO T_PRESCRIPTION_MASTER_TEMP("
                        + "PRESCRIPTIONID,DELIVER_NO,PRESCRIPTIONNO,PRESCRIPTIONSOURCE,PRESCRIPTIONATTRIBUTE,"
                        + "PATIENTID,OUTPNO,INPNO,PATIENTNAME,SEX,BIRTHDAY,DEPTNAME,DOCTORNAME,"
                        + "ISPAY,PAYDATE,PRINTSTATUS,SENDSTATUS,SENDER,SENDDATE,LAYOUTSTATUS,LAYOUTER,LAYOUTDATE,WINDOWNO,"
                        + "EQUIPNOOFFAST,EQUIPNOOFEASY,WARD,USAGE,BEDNO,EQUIPNOOFPACK,"
                        + "[快发发药状态],[分包发药状态],SORTSTATE)"
                        + "VALUES(@PRESCRIPTIONID,@DELIVER_NO,@PRESCRIPTIONNO,@PRESCRIPTIONSOURCE,@PRESCRIPTIONATTRIBUTE,"
                        + "@PATIENTID,@OUTPNO,@INPNO,@PATIENTNAME,@SEX,@BIRTHDAY,@DEPTNAME,@DOCTORNAME,"
                        + "@ISPAY,@PAYDATE,@PRINTSTATUS,@SENDSTATUS,@SENDER,@SENDDATE,@LAYOUTSTATUS,@LAYOUTER,@LAYOUTDATE,@WINDOWNO,"
                        + "@EQUIPNOOFFAST,@EQUIPNOOFEASY,@WARD,@USAGE,@BEDNO,@EQUIPNOOFPACK,"
                        + "@STATUSOFFAST,@STATUSOFPACK,@SORTSTATE)";
                }

                //主表参数
                parametersmain[0] = new SqlParameter("@PRESCRIPTIONID", SqlDbType.VarChar, 50); // PRESCRIPTIONID;
                parametersmain[1] = new SqlParameter("@DELIVER_NO", SqlDbType.VarChar, 50); // DELIVER_NO;
                parametersmain[2] = new SqlParameter("@PRESCRIPTIONNO", SqlDbType.VarChar, 50); // PRESCRIPTIONNO;
                parametersmain[3] = new SqlParameter("@PRESCRIPTIONSOURCE", SqlDbType.Int, 1); // PRESCRIPTIONSOURCE;
                parametersmain[4] = new SqlParameter("@PRESCRIPTIONATTRIBUTE", SqlDbType.Int, 1); // PRESCRIPTIONATTRIBUTE;
                parametersmain[5] = new SqlParameter("@PATIENTID", SqlDbType.VarChar, 50); // PATIENTID;
                parametersmain[6] = new SqlParameter("@OUTPNO", SqlDbType.VarChar, 50); // OUTPNO;
                parametersmain[7] = new SqlParameter("@INPNO", SqlDbType.VarChar, 50); // INPNO;
                parametersmain[8] = new SqlParameter("@PATIENTNAME", SqlDbType.VarChar, 50); // PATIENTNAME;
                parametersmain[9] = new SqlParameter("@SEX", SqlDbType.Int, 1); // SEX;
                parametersmain[10] = new SqlParameter("@BIRTHDAY", SqlDbType.DateTime, 50); // BIRTHDAY;
                parametersmain[11] = new SqlParameter("@DEPTNAME", SqlDbType.VarChar, 50); // DEPTNAME;
                parametersmain[12] = new SqlParameter("@DOCTORNAME", SqlDbType.VarChar, 50); // DOCTORNAME;
                parametersmain[13] = new SqlParameter("@ISPAY", SqlDbType.Int, 1); // ISPAY;
                parametersmain[14] = new SqlParameter("@PAYDATE", SqlDbType.DateTime, 50); // PAYDATE;
                parametersmain[15] = new SqlParameter("@PRINTSTATUS", SqlDbType.Int, 1); // PRINTSTATUS;
                parametersmain[16] = new SqlParameter("@SENDSTATUS", SqlDbType.Int, 1); // SENDSTATUS;
                parametersmain[17] = new SqlParameter("@SENDER", SqlDbType.VarChar, 50); // SENDER;
                parametersmain[18] = new SqlParameter("@SENDDATE", SqlDbType.DateTime, 50); // SENDDATE;
                parametersmain[19] = new SqlParameter("@LAYOUTSTATUS", SqlDbType.Int, 1); // LAYOUTSTATUS;
                parametersmain[20] = new SqlParameter("@LAYOUTER", SqlDbType.VarChar, 50); // LAYOUTER;
                parametersmain[21] = new SqlParameter("@LAYOUTDATE", SqlDbType.DateTime, 50); // LAYOUTDATE;
                parametersmain[22] = new SqlParameter("@WINDOWNO", SqlDbType.VarChar, 50); // WINDOWNO;
                parametersmain[23] = new SqlParameter("@EQUIPNOOFFAST", SqlDbType.VarChar, 50); // EQUIPNOOFFAST;
                parametersmain[24] = new SqlParameter("@EQUIPNOOFEASY", SqlDbType.VarChar, 50); // EQUIPNOOFEASY;
                parametersmain[25] = new SqlParameter("@WARD", SqlDbType.VarChar, 50); // WARD;
                parametersmain[26] = new SqlParameter("@USAGE", SqlDbType.DateTime, 50); // USETIME;
                parametersmain[27] = new SqlParameter("@BEDNO", SqlDbType.VarChar, 50); // BEDNO;
                parametersmain[28] = new SqlParameter("@EQUIPNOOFPACK", SqlDbType.VarChar, 50); // EQUIPNOOFPACK;
                parametersmain[29] = new SqlParameter("@STATUSOFFAST", SqlDbType.Int, 1); // STATUSOFFAST;
                parametersmain[30] = new SqlParameter("@STATUSOFPACK", SqlDbType.Int, 1); // STATUSOFPACK;
                //parametersmain[32] = new SqlParameter("@BASKETID", SqlDbType.VarChar, 50); // BASKETID;
                parametersmain[31] = new SqlParameter("@SORTSTATE", SqlDbType.VarChar, 50); // SORTSTATE;
                //parametersmain[32] = new SqlParameter("@SENDERID", SqlDbType.VarChar, 50); // SENDERID;

                //列名 'USETIME' 无效。
                //列名 'STATUSOFFAST' 无效。 快发发药状态
                //列名 'STATUSOFPACK' 无效。 分包发药状态
                //列名 'PRESCRIPTIONTYPE' 无效。 PRESCRIPTIONATTRIBUTE
                //列名 'BASKETID' 无效。
                //列名 'SENDERID' 无效。 Sender

                //主表参数赋值
                parametersmain[0].Value = pid; // PRESCRIPTIONID;
                parametersmain[1].Value = master.Deliver_No; // DELIVER_NO;
                parametersmain[2].Value = master.PrescriptionNo; // PRESCRIPTIONNO;
                parametersmain[3].Value = master.PrescriptionSource; // PRESCRIPTIONSOURCE; 处方来源
                parametersmain[4].Value = master.PrescriptionAttribute; // PRESCRIPTIONATTRIBUTE; 处方属性
                parametersmain[5].Value = master.PatientID; // PATIENTID;
                parametersmain[6].Value = master.OutpNo; // OUTPNO; 门诊号
                parametersmain[7].Value = master.InpNo; // INPNO; 住院号
                parametersmain[8].Value = master.PatientName; // PATIENTNAME;
                parametersmain[9].Value = master.Sex; // SEX;
                parametersmain[10].Value =master.BirthDay; // BIRTHDAY;
                parametersmain[11].Value = master.DeptName; // DEPTNAME;
                parametersmain[12].Value = master.DoctorName; // DOCTORNAME;
                parametersmain[13].Value = master.IsPay; // ISPAY;
                parametersmain[14].Value = master.PayDate; // PAYDATE;
                parametersmain[15].Value = DBNull.Value; // PRINTSTATUS;
                parametersmain[16].Value = DBNull.Value; // SENDSTATUS;
                parametersmain[17].Value = DBNull.Value; // SENDER;
                parametersmain[18].Value = DBNull.Value; // SENDDATE;
                parametersmain[19].Value = DBNull.Value; // LAYOUTSTATUS;
                parametersmain[20].Value = DBNull.Value; // LAYOUTER;
                parametersmain[21].Value = DBNull.Value; // LAYOUTDATE;
                parametersmain[22].Value = DBNull.Value; // WINDOWNO;
                parametersmain[23].Value = DBNull.Value; // EQUIPNOOFFAST;
                parametersmain[24].Value = DBNull.Value; // EQUIPNOOFEASY;
                parametersmain[25].Value = master.ward; // WARD;
                parametersmain[26].Value = master.usage; // USETIME;
                parametersmain[27].Value = master.bedno; // BEDNO; //床号
                parametersmain[28].Value = DBNull.Value; // EQUIPNOOFPACK;
                parametersmain[29].Value = DBNull.Value; // STATUSOFFAST;
                parametersmain[30].Value = DBNull.Value; // STATUSOFPACK;
                //parametersmain[31].Value = DBNull.Value; // PRESCRIPTIONTYPE;
                //parametersmain[32].Value = DBNull.Value; // BASKETID;
                parametersmain[31].Value = DBNull.Value; // SORTSTATE;
                //parametersmain[32].Value = DBNull.Value; // SENDERID;


                /* 处方主表

        /// PrescriptionID	VARCHAR2(36)	处方ID	✔
        public string PrescriptionID

        /// RecriptNO	VARCHAR2(36)	收据号（发票号）
        public string RecriptNO

        /// DeptCode	VARCHAR2(50)	科室编号	
        public string DeptCode

        /// wardcode	VARCHAR2(60)	病区编号	✔
        public string wardcode

                */

                listsqls.Add(sqlmain);
                listparameters.Add(parametersmain);

                foreach (var detail in master.Details)
                {
                    //要判断是新增还是删除
                    //子表新增
                    sqlsub = "INSERT INTO T_PRESCRIPTION_DETAIL_TEMP(PRESDETAILID,PRESCRIPTIONID,MEDINO,MEDICODE,STOREROOM,"
                        + "BATCH,ORIGINPLACE,BATCHNO,EXPIRATIONDATE,PACKAGE,"
                        + "UNIT,QUANTITY,TRADEPRICE,TRADECOST,RETAILPRICE,"
                        + "RETAILCOST,DOSE,DOSEUNIT,USAGE,FREQUENCY,"
                        + "SENDSTATUS,SENDDATE)"
                        + "VALUES(@PRESDETAILID,@PRESCRIPTIONID,@MEDINO,@MEDICODE,@STOREROOM,"
                        + "@BATCH,@ORIGINPLACE,@BATCHNO,@EXPIRATIONDATE,@PACKAGE,"
                        + "@UNIT,@QUANTITY,@TRADEPRICE,@TRADECOST,@RETAILPRICE,"
                        + "@RETAILCOST,@DOSE,@DOSEUNIT,@USAGE,@FREQUENCY,"
                        + "@SENDSTATUS,@SENDDATE)";

                    //从表参数
                    parameterssub[0] = new SqlParameter("@PRESDETAILID", SqlDbType.VarChar, 50); // PRESDETAILID;
                    parameterssub[1] = new SqlParameter("@PRESCRIPTIONID", SqlDbType.VarChar, 50); // PRESCRIPTIONID;
                    parameterssub[2] = new SqlParameter("@MEDINO", SqlDbType.VarChar, 50); // MEDINO;
                    parameterssub[3] = new SqlParameter("@MEDICODE", SqlDbType.VarChar, 50); // MEDICODE;
                    parameterssub[4] = new SqlParameter("@STOREROOM", SqlDbType.VarChar, 50); // STOREROOM;
                    parameterssub[5] = new SqlParameter("@BATCH", SqlDbType.VarChar, 50); // BATCH;
                    parameterssub[6] = new SqlParameter("@ORIGINPLACE", SqlDbType.VarChar, 50); // ORIGINPLACE;
                    parameterssub[7] = new SqlParameter("@BATCHNO", SqlDbType.VarChar, 50); // BATCHNO;
                    parameterssub[8] = new SqlParameter("@EXPIRATIONDATE", SqlDbType.DateTime, 50); // EXPIRATIONDATE;
                    parameterssub[9] = new SqlParameter("@PACKAGE", SqlDbType.Int, 50); // PACKAGE;
                    parameterssub[10] = new SqlParameter("@UNIT", SqlDbType.VarChar, 6); // UNIT;
                    parameterssub[11] = new SqlParameter("@QUANTITY", SqlDbType.Float, 30); // QUANTITY;
                    parameterssub[12] = new SqlParameter("@TRADEPRICE", SqlDbType.Float, 30); // TRADEPRICE;
                    parameterssub[13] = new SqlParameter("@TRADECOST", SqlDbType.Float, 30); // TRADECOST;
                    parameterssub[14] = new SqlParameter("@RETAILPRICE", SqlDbType.Float, 30); // RETAILPRICE;
                    parameterssub[15] = new SqlParameter("@RETAILCOST", SqlDbType.Float, 30); // RETAILCOST;
                    parameterssub[16] = new SqlParameter("@DOSE", SqlDbType.Float, 50); // DOSE;
                    parameterssub[17] = new SqlParameter("@DOSEUNIT", SqlDbType.Int, 50); // DOSEUNIT;
                    parameterssub[18] = new SqlParameter("@USAGE", SqlDbType.VarChar, 50); // USAGE;
                    parameterssub[19] = new SqlParameter("@FREQUENCY", SqlDbType.VarChar, 50); // FREQUENCY;
                    parameterssub[20] = new SqlParameter("@SENDSTATUS", SqlDbType.Int, 2); // SENDSTATUS;
                    //parameterssub[21] = new SqlParameter("@ENTRUST", SqlDbType.VarChar, 50); // ENTRUST;
                    //parameterssub[22] = new SqlParameter("@OTHERKITID", SqlDbType.Int, 2); // OTHERKITID;
                    //parameterssub[23] = new SqlParameter("@DOSAGE", SqlDbType.VarChar, 50); // DOSAGE;
                    parameterssub[21] = new SqlParameter("@SENDDATE", SqlDbType.DateTime, 50); // DOSAGE;

                    //从表参数赋值
                    parameterssub[0].Value = Guid.NewGuid().ToString(); // PRESDETAILID;
                    parameterssub[1].Value = pid; // PRESCRIPTIONID;
                    parameterssub[2].Value = detail.MediNo; // MEDINO; 药品序号
                    parameterssub[3].Value = detail.MediCode; // MEDICODE; 药品编码
                    parameterssub[4].Value = detail.StoreRoom; // STOREROOM; 库房代码
                    parameterssub[5].Value = detail.Batch; // BATCH; 批次
                    parameterssub[6].Value = detail.OriginPlace; // ORIGINPLACE; 来源地
                    parameterssub[7].Value = detail.BatchNo; // BATCHNO; 批次号
                    if (detail.ExpirationDate != null)
                    {
                        parameterssub[8].Value = detail.ExpirationDate; // EXPIRATIONDATE; 有效期
                    }
                    else
                    {
                        parameterssub[8].Value = DBNull.Value;
                    }
                    
                    parameterssub[9].Value = detail.Package; // PACKAGE; 包装系数
                    parameterssub[10].Value = detail.Unit; // UNIT; 发药单位
                    parameterssub[11].Value = detail.Quantity; // QUANTITY; 发药数量
                    parameterssub[12].Value = detail.TradePrice; // TRADEPRICE;
                    parameterssub[13].Value = detail.TradeCost; // TRADECOST;
                    parameterssub[14].Value = detail.RetailPrice; // RETAILPRICE;
                    parameterssub[15].Value = detail.RetailCost; // RETAILCOST;
                    parameterssub[16].Value = detail.Dose; // DOSE;
                    parameterssub[17].Value = detail.DoseUnit; // DOSEUNIT;
                    parameterssub[18].Value = detail.Usage; // USAGE;
                    parameterssub[19].Value = detail.Frequency; // FREQUENCY;
                    parameterssub[20].Value = detail.SendStatus; // SENDSTATUS;
                    //parameterssub[21].Value = DBNull.Value; // ENTRUST;
                    //parameterssub[22].Value = DBNull.Value; // OTHERKITID;
                    //parameterssub[23].Value = DBNull.Value; // DOSAGE;
                    parameterssub[21].Value = DBNull.Value; // SENDDATE;

                    //列名 'ENTRUST' 无效。
                    //列名 'OTHERKITID' 无效。
                    //列名 'DOSAGE' 无效。

                    /*
        /// PresDetailID	VARCHAR2(36)	处方明细ID	✔
        public string PresDetailID

        /// PrescriptionID	VARCHAR2(36)	处方ID	✔
        public string PrescriptionID

                     * */

                    listsqls.Add(sqlsub);
                    listparameters.Add(parameterssub);
                }
                //插入子表语句
            }
            try
            {
                if (SQLServerHelper.ExecSqlByTran(listsqls, listparameters))
                {
                    return getResult(1, "成功");
                }
                else
                {
                    return getResult(-1, "失败了");
                }
            }
            catch (Exception ex)
            {
                return getResult(-1, string.Format("ERROR:{0}\r\nSTACKTRACE:{1}", ex.Message, ex.StackTrace));
            }
        }

        /// <summary>
        /// 同步处方信息根据参数DOEVENT判断是新增还是编辑或者删除
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string HisTransData2(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return getResult(-1, "xml文件内容为空"); //校验失败
            }

            var request = InitHFSRequestData(xml);//解析xml

            ////用户输入校验
            //string errors = Check(listDrugInfo);
            //if (!string.IsNullOrEmpty(errors))
            //{
            //    return getResult(1, errors); //校验失败
            //}

            List<string> listsqls = new List<string>();
            List<SqlParameter[]> listparameters = new List<SqlParameter[]>();

            foreach (var master in request.PRESCRIPTION_MASTERS)
            {
                #region 主表SQL语句
                string sql = string.Empty;

                //liyafei 需要查询是否存在

                //string pid = string.Empty; //GetPrescriptionID(master.PrescriptionNo);
                string sqlmain = string.Empty;
                string sqlsub = string.Empty;

                SqlParameter[] parametersmain = new SqlParameter[32];
                SqlParameter[] parameterssub = new SqlParameter[22];

                switch (master.DOEVENT)
                {
                    case "N": //新增
                        //pid = Guid.NewGuid().ToString();
                        //主表新增
                        sqlmain = "INSERT INTO T_PRESCRIPTION_MASTER_TEMP("
                            + "PRESCRIPTIONID,DELIVER_NO,PRESCRIPTIONNO,PRESCRIPTIONSOURCE,PRESCRIPTIONATTRIBUTE,"
                            + "PATIENTID,OUTPNO,INPNO,PATIENTNAME,SEX,BIRTHDAY,DEPTNAME,DOCTORNAME,"
                            + "ISPAY,PAYDATE,PRINTSTATUS,SENDSTATUS,SENDER,SENDDATE,LAYOUTSTATUS,LAYOUTER,LAYOUTDATE,WINDOWNO,"
                            + "EQUIPNOOFFAST,EQUIPNOOFEASY,WARD,USAGE,BEDNO,EQUIPNOOFPACK,"
                            + "[快发发药状态],[分包发药状态],SORTSTATE)"
                            + "VALUES(@PRESCRIPTIONID,@DELIVER_NO,@PRESCRIPTIONNO,@PRESCRIPTIONSOURCE,@PRESCRIPTIONATTRIBUTE,"
                            + "@PATIENTID,@OUTPNO,@INPNO,@PATIENTNAME,@SEX,@BIRTHDAY,@DEPTNAME,@DOCTORNAME,"
                            + "@ISPAY,@PAYDATE,@PRINTSTATUS,@SENDSTATUS,@SENDER,@SENDDATE,@LAYOUTSTATUS,@LAYOUTER,@LAYOUTDATE,@WINDOWNO,"
                            + "@EQUIPNOOFFAST,@EQUIPNOOFEASY,@WARD,@USAGE,@BEDNO,@EQUIPNOOFPACK,"
                            + "@STATUSOFFAST,@STATUSOFPACK,@SORTSTATE)";
                        break;
                    case "U": //修改
                        //主表修改
                        //pid = master.PrescriptionID;
                        sqlmain = "UPDATE T_PRESCRIPTION_MASTER_TEMP SET "
                            + "DELIVER_NO=@DELIVER_NO,PRESCRIPTIONNO=@PRESCRIPTIONNO,"
                            + "PRESCRIPTIONSOURCE=@PRESCRIPTIONSOURCE,PRESCRIPTIONATTRIBUTE =@PRESCRIPTIONATTRIBUTE,"
                            + "PATIENTID=@PATIENTID,OUTPNO=@OUTPNO,INPNO=@INPNO,PATIENTNAME=@PATIENTNAME,"
                            + "SEX=@SEX,BIRTHDAY=@BIRTHDAY,DEPTNAME=@DEPTNAME,DOCTORNAME=@DOCTORNAME,"
                            + "ISPAY=@ISPAY,PAYDATE=@PAYDATE,PRINTSTATUS=@PRINTSTATUS,SENDSTATUS=@SENDSTATUS,"
                            + "SENDER=@SENDER,SENDDATE=@SENDDATE,LAYOUTSTATUS=@LAYOUTSTATUS,"
                            + "LAYOUTER=@LAYOUTER,LAYOUTDATE=@LAYOUTDATE,WINDOWNO=@WINDOWNO,"
                            + "EQUIPNOOFFAST=@EQUIPNOOFFAST,EQUIPNOOFEASY=@EQUIPNOOFEASY,WARD=@WARD,"
                            + "USAGE=@USAGE,BEDNO=@BEDNO,EQUIPNOOFPACK=@EQUIPNOOFPACK,"
                            + "[快发发药状态]=@STATUSOFFAST,[分包发药状态]=@STATUSOFPACK,"
                            + "SORTSTATE=@SORTSTATE "
                            + "WHERE PRESCRIPTIONID=@PRESCRIPTIONID";
                        break;
                    case "D"://删除
                        //pid = master.PrescriptionID;
                        sqlmain = "DELETE FROM T_PRESCRIPTION_MASTER_TEMP WHERE PRESCRIPTIONID=@PRESCRIPTIONID";
                        break;
                    default:
                        continue;// 不识别的代号则直接跳过
                        break;
                }
                #endregion

                #region //主表参数
                parametersmain[0] = new SqlParameter("@PRESCRIPTIONID", SqlDbType.VarChar, 50); // PRESCRIPTIONID;
                parametersmain[1] = new SqlParameter("@DELIVER_NO", SqlDbType.VarChar, 50); // DELIVER_NO;
                parametersmain[2] = new SqlParameter("@PRESCRIPTIONNO", SqlDbType.VarChar, 50); // PRESCRIPTIONNO;
                parametersmain[3] = new SqlParameter("@PRESCRIPTIONSOURCE", SqlDbType.Int, 1); // PRESCRIPTIONSOURCE;
                parametersmain[4] = new SqlParameter("@PRESCRIPTIONATTRIBUTE", SqlDbType.Int, 1); // PRESCRIPTIONATTRIBUTE;
                parametersmain[5] = new SqlParameter("@PATIENTID", SqlDbType.VarChar, 50); // PATIENTID;
                parametersmain[6] = new SqlParameter("@OUTPNO", SqlDbType.VarChar, 50); // OUTPNO;
                parametersmain[7] = new SqlParameter("@INPNO", SqlDbType.VarChar, 50); // INPNO;
                parametersmain[8] = new SqlParameter("@PATIENTNAME", SqlDbType.VarChar, 50); // PATIENTNAME;
                parametersmain[9] = new SqlParameter("@SEX", SqlDbType.Int, 1); // SEX;
                parametersmain[10] = new SqlParameter("@BIRTHDAY", SqlDbType.DateTime, 50); // BIRTHDAY;
                parametersmain[11] = new SqlParameter("@DEPTNAME", SqlDbType.VarChar, 50); // DEPTNAME;
                parametersmain[12] = new SqlParameter("@DOCTORNAME", SqlDbType.VarChar, 50); // DOCTORNAME;
                parametersmain[13] = new SqlParameter("@ISPAY", SqlDbType.Int, 1); // ISPAY;
                parametersmain[14] = new SqlParameter("@PAYDATE", SqlDbType.DateTime, 50); // PAYDATE;
                parametersmain[15] = new SqlParameter("@PRINTSTATUS", SqlDbType.Int, 1); // PRINTSTATUS;
                parametersmain[16] = new SqlParameter("@SENDSTATUS", SqlDbType.Int, 1); // SENDSTATUS;
                parametersmain[17] = new SqlParameter("@SENDER", SqlDbType.VarChar, 50); // SENDER;
                parametersmain[18] = new SqlParameter("@SENDDATE", SqlDbType.DateTime, 50); // SENDDATE;
                parametersmain[19] = new SqlParameter("@LAYOUTSTATUS", SqlDbType.Int, 1); // LAYOUTSTATUS;
                parametersmain[20] = new SqlParameter("@LAYOUTER", SqlDbType.VarChar, 50); // LAYOUTER;
                parametersmain[21] = new SqlParameter("@LAYOUTDATE", SqlDbType.DateTime, 50); // LAYOUTDATE;
                parametersmain[22] = new SqlParameter("@WINDOWNO", SqlDbType.VarChar, 50); // WINDOWNO;
                parametersmain[23] = new SqlParameter("@EQUIPNOOFFAST", SqlDbType.VarChar, 50); // EQUIPNOOFFAST;
                parametersmain[24] = new SqlParameter("@EQUIPNOOFEASY", SqlDbType.VarChar, 50); // EQUIPNOOFEASY;
                parametersmain[25] = new SqlParameter("@WARD", SqlDbType.VarChar, 50); // WARD;
                parametersmain[26] = new SqlParameter("@USAGE", SqlDbType.DateTime, 50); // USETIME;
                parametersmain[27] = new SqlParameter("@BEDNO", SqlDbType.VarChar, 50); // BEDNO;
                parametersmain[28] = new SqlParameter("@EQUIPNOOFPACK", SqlDbType.VarChar, 50); // EQUIPNOOFPACK;
                parametersmain[29] = new SqlParameter("@STATUSOFFAST", SqlDbType.Int, 1); // STATUSOFFAST;
                parametersmain[30] = new SqlParameter("@STATUSOFPACK", SqlDbType.Int, 1); // STATUSOFPACK;
                //parametersmain[32] = new SqlParameter("@BASKETID", SqlDbType.VarChar, 50); // BASKETID;
                parametersmain[31] = new SqlParameter("@SORTSTATE", SqlDbType.VarChar, 50); // SORTSTATE;
                //parametersmain[32] = new SqlParameter("@SENDERID", SqlDbType.VarChar, 50); // SENDERID;

                //列名 'USETIME' 无效。
                //列名 'STATUSOFFAST' 无效。 快发发药状态
                //列名 'STATUSOFPACK' 无效。 分包发药状态
                //列名 'PRESCRIPTIONTYPE' 无效。 PRESCRIPTIONATTRIBUTE
                //列名 'BASKETID' 无效。
                //列名 'SENDERID' 无效。 Sender

                //主表参数赋值
                parametersmain[0].Value = master.PrescriptionID; // PRESCRIPTIONID;
                parametersmain[1].Value = master.Deliver_No; // DELIVER_NO;
                parametersmain[2].Value = master.PrescriptionNo; // PRESCRIPTIONNO;
                parametersmain[3].Value = master.PrescriptionSource; // PRESCRIPTIONSOURCE; 处方来源
                parametersmain[4].Value = master.PrescriptionAttribute; // PRESCRIPTIONATTRIBUTE; 处方属性
                parametersmain[5].Value = master.PatientID; // PATIENTID;
                parametersmain[6].Value = master.OutpNo; // OUTPNO; 门诊号
                parametersmain[7].Value = master.InpNo; // INPNO; 住院号
                parametersmain[8].Value = master.PatientName; // PATIENTNAME;
                parametersmain[9].Value = master.Sex; // SEX;
                parametersmain[10].Value = master.BirthDay; // BIRTHDAY;
                parametersmain[11].Value = master.DeptName; // DEPTNAME;
                parametersmain[12].Value = master.DoctorName; // DOCTORNAME;
                parametersmain[13].Value = master.IsPay; // ISPAY;
                parametersmain[14].Value = master.PayDate; // PAYDATE;
                parametersmain[15].Value = DBNull.Value; // PRINTSTATUS;
                parametersmain[16].Value = DBNull.Value; // SENDSTATUS;
                parametersmain[17].Value = DBNull.Value; // SENDER;
                parametersmain[18].Value = DBNull.Value; // SENDDATE;
                parametersmain[19].Value = DBNull.Value; // LAYOUTSTATUS;
                parametersmain[20].Value = DBNull.Value; // LAYOUTER;
                parametersmain[21].Value = DBNull.Value; // LAYOUTDATE;
                parametersmain[22].Value = DBNull.Value; // WINDOWNO;
                parametersmain[23].Value = DBNull.Value; // EQUIPNOOFFAST;
                parametersmain[24].Value = DBNull.Value; // EQUIPNOOFEASY;
                parametersmain[25].Value = master.ward; // WARD;
                parametersmain[26].Value = master.usage; // USETIME;
                parametersmain[27].Value = master.bedno; // BEDNO; //床号
                parametersmain[28].Value = DBNull.Value; // EQUIPNOOFPACK;
                parametersmain[29].Value = DBNull.Value; // STATUSOFFAST;
                parametersmain[30].Value = DBNull.Value; // STATUSOFPACK;
                //parametersmain[31].Value = DBNull.Value; // PRESCRIPTIONTYPE;
                //parametersmain[32].Value = DBNull.Value; // BASKETID;
                parametersmain[31].Value = DBNull.Value; // SORTSTATE;
                //parametersmain[32].Value = DBNull.Value; // SENDERID;


                /* 处方主表

        /// PrescriptionID	VARCHAR2(36)	处方ID	✔
        public string PrescriptionID

        /// RecriptNO	VARCHAR2(36)	收据号（发票号）
        public string RecriptNO

        /// DeptCode	VARCHAR2(50)	科室编号	
        public string DeptCode

        /// wardcode	VARCHAR2(60)	病区编号	✔
        public string wardcode

                */
                #endregion

                listsqls.Add(sqlmain);
                listparameters.Add(parametersmain);

                foreach (var detail in master.Details)
                {
                    #region 从表SQL语句设置
                    string detailid = detail.PresDetailID;
                    switch (detail.DOEVENT)
                    {
                        case "N": //新增
                            //子表新增
                            detailid = Guid.NewGuid().ToString();
                            sqlsub = "INSERT INTO T_PRESCRIPTION_DETAIL_TEMP(PRESDETAILID,PRESCRIPTIONID,MEDINO,MEDICODE,STOREROOM,"
                                + "BATCH,ORIGINPLACE,BATCHNO,EXPIRATIONDATE,PACKAGE,"
                                + "UNIT,QUANTITY,TRADEPRICE,TRADECOST,RETAILPRICE,"
                                + "RETAILCOST,DOSE,DOSEUNIT,USAGE,FREQUENCY,"
                                + "SENDSTATUS,SENDDATE)"
                                + "VALUES(@PRESDETAILID,@PRESCRIPTIONID,@MEDINO,@MEDICODE,@STOREROOM,"
                                + "@BATCH,@ORIGINPLACE,@BATCHNO,@EXPIRATIONDATE,@PACKAGE,"
                                + "@UNIT,@QUANTITY,@TRADEPRICE,@TRADECOST,@RETAILPRICE,"
                                + "@RETAILCOST,@DOSE,@DOSEUNIT,@USAGE,@FREQUENCY,"
                                + "@SENDSTATUS,@SENDDATE)";
                            break;
                        case "U": //修改
                            //子表修改

                            sqlsub = "UPDATE T_PRESCRIPTION_DETAIL_TEMP SET PRESCRIPTIONID=@PRESCRIPTIONID,MEDINO=@MEDINO,MEDICODE=@MEDICODE,STOREROOM=@STOREROOM,"
                                + "BATCH=@BATCH,ORIGINPLACE=@ORIGINPLACE,BATCHNO=@BATCHNO,EXPIRATIONDATE=@EXPIRATIONDATE,PACKAGE=@PACKAGE,"
                                + "UNIT=@UNIT,QUANTITY=@QUANTITY,TRADEPRICE=@TRADEPRICE,TRADECOST=@TRADECOST,RETAILPRICE=@RETAILPRICE,"
                                + "RETAILCOST=@RETAILCOST,DOSE=@DOSE,DOSEUNIT=@DOSEUNIT,USAGE=@USAGE,FREQUENCY=@FREQUENCY,"
                                + "SENDSTATUS=@SENDSTATUS,SENDDATE=@SENDDATE"
                                + " WHERE PRESCRIPTIONID=@PRESCRIPTIONID";
                            break;
                        case "D"://删除
                            //pid = master.PrescriptionID;
                            sqlsub = "DELETE FROM T_PRESCRIPTION_DETAIL_TEMP WHERE PRESDETAILID=@PRESDETAILID";
                            break;
                        default:
                            continue;// 不识别的代号则直接跳过
                            break;
                    }
                    #endregion

                    #region //从表参数设置
                    parameterssub[0] = new SqlParameter("@PRESDETAILID", SqlDbType.VarChar, 50); // PRESDETAILID;
                    parameterssub[1] = new SqlParameter("@PRESCRIPTIONID", SqlDbType.VarChar, 50); // PRESCRIPTIONID;
                    parameterssub[2] = new SqlParameter("@MEDINO", SqlDbType.VarChar, 50); // MEDINO;
                    parameterssub[3] = new SqlParameter("@MEDICODE", SqlDbType.VarChar, 50); // MEDICODE;
                    parameterssub[4] = new SqlParameter("@STOREROOM", SqlDbType.VarChar, 50); // STOREROOM;
                    parameterssub[5] = new SqlParameter("@BATCH", SqlDbType.VarChar, 50); // BATCH;
                    parameterssub[6] = new SqlParameter("@ORIGINPLACE", SqlDbType.VarChar, 50); // ORIGINPLACE;
                    parameterssub[7] = new SqlParameter("@BATCHNO", SqlDbType.VarChar, 50); // BATCHNO;
                    parameterssub[8] = new SqlParameter("@EXPIRATIONDATE", SqlDbType.DateTime, 50); // EXPIRATIONDATE;
                    parameterssub[9] = new SqlParameter("@PACKAGE", SqlDbType.Int, 50); // PACKAGE;
                    parameterssub[10] = new SqlParameter("@UNIT", SqlDbType.VarChar, 6); // UNIT;
                    parameterssub[11] = new SqlParameter("@QUANTITY", SqlDbType.Float, 30); // QUANTITY;
                    parameterssub[12] = new SqlParameter("@TRADEPRICE", SqlDbType.Float, 30); // TRADEPRICE;
                    parameterssub[13] = new SqlParameter("@TRADECOST", SqlDbType.Float, 30); // TRADECOST;
                    parameterssub[14] = new SqlParameter("@RETAILPRICE", SqlDbType.Float, 30); // RETAILPRICE;
                    parameterssub[15] = new SqlParameter("@RETAILCOST", SqlDbType.Float, 30); // RETAILCOST;
                    parameterssub[16] = new SqlParameter("@DOSE", SqlDbType.Float, 50); // DOSE;
                    parameterssub[17] = new SqlParameter("@DOSEUNIT", SqlDbType.Int, 50); // DOSEUNIT;
                    parameterssub[18] = new SqlParameter("@USAGE", SqlDbType.VarChar, 50); // USAGE;
                    parameterssub[19] = new SqlParameter("@FREQUENCY", SqlDbType.VarChar, 50); // FREQUENCY;
                    parameterssub[20] = new SqlParameter("@SENDSTATUS", SqlDbType.Int, 2); // SENDSTATUS;
                    //parameterssub[21] = new SqlParameter("@ENTRUST", SqlDbType.VarChar, 50); // ENTRUST;
                    //parameterssub[22] = new SqlParameter("@OTHERKITID", SqlDbType.Int, 2); // OTHERKITID;
                    //parameterssub[23] = new SqlParameter("@DOSAGE", SqlDbType.VarChar, 50); // DOSAGE;
                    parameterssub[21] = new SqlParameter("@SENDDATE", SqlDbType.DateTime, 50); // DOSAGE;

                    //从表参数赋值
                    parameterssub[0].Value = detailid; // PRESDETAILID;
                    parameterssub[1].Value = master.PrescriptionID; // PRESCRIPTIONID;
                    parameterssub[2].Value = detail.MediNo; // MEDINO; 药品序号
                    parameterssub[3].Value = detail.MediCode; // MEDICODE; 药品编码
                    parameterssub[4].Value = detail.StoreRoom; // STOREROOM; 库房代码
                    parameterssub[5].Value = detail.Batch; // BATCH; 批次
                    parameterssub[6].Value = detail.OriginPlace; // ORIGINPLACE; 来源地
                    parameterssub[7].Value = detail.BatchNo; // BATCHNO; 批次号
                    if (detail.ExpirationDate != null)
                    {
                        parameterssub[8].Value = detail.ExpirationDate; // EXPIRATIONDATE; 有效期
                    }
                    else
                    {
                        parameterssub[8].Value = DBNull.Value;
                    }

                    parameterssub[9].Value = detail.Package; // PACKAGE; 包装系数
                    parameterssub[10].Value = detail.Unit; // UNIT; 发药单位
                    parameterssub[11].Value = detail.Quantity; // QUANTITY; 发药数量
                    parameterssub[12].Value = detail.TradePrice; // TRADEPRICE;
                    parameterssub[13].Value = detail.TradeCost; // TRADECOST;
                    parameterssub[14].Value = detail.RetailPrice; // RETAILPRICE;
                    parameterssub[15].Value = detail.RetailCost; // RETAILCOST;
                    parameterssub[16].Value = detail.Dose; // DOSE;
                    parameterssub[17].Value = detail.DoseUnit; // DOSEUNIT;
                    parameterssub[18].Value = detail.Usage; // USAGE;
                    parameterssub[19].Value = detail.Frequency; // FREQUENCY;
                    parameterssub[20].Value = detail.SendStatus; // SENDSTATUS;
                    //parameterssub[21].Value = DBNull.Value; // ENTRUST;
                    //parameterssub[22].Value = DBNull.Value; // OTHERKITID;
                    //parameterssub[23].Value = DBNull.Value; // DOSAGE;
                    parameterssub[21].Value = DBNull.Value; // SENDDATE;

                    //列名 'ENTRUST' 无效。
                    //列名 'OTHERKITID' 无效。
                    //列名 'DOSAGE' 无效。

                    /*
        /// PresDetailID	VARCHAR2(36)	处方明细ID	✔
        public string PresDetailID

        /// PrescriptionID	VARCHAR2(36)	处方ID	✔
        public string PrescriptionID

                     * */
                    #endregion

                    listsqls.Add(sqlsub);
                    listparameters.Add(parameterssub);
                }
            }
            try
            {
                if (SQLServerHelper.ExecSqlByTran(listsqls, listparameters))
                {
                    return getResult(1, "成功");
                }
                else
                {
                    return getResult(-1, "失败了");
                }
            }
            catch (Exception ex)
            {
                return getResult(-1, string.Format("ERROR:{0}\r\nSTACKTRACE:{1}", ex.Message, ex.StackTrace));
            }
        }

        /// <summary>
        /// 同步科室信息
        /// </summary>
        /// <param name="xml">科室信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_dept(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return getResult(-1, "xml文件内容为空"); //校验失败
            }

            var list = InitDepartment(xml);//解析xml

            var listsqls = new List<string>();
            var listparameters = new List<SqlParameter[]>();

            foreach (var dept in list)
            {
                string sql = string.Empty;
                switch (dept.DOEVENT)
                {
                    case "N": //新增
                        //新增
                        sql = "INSERT INTO DEPT_DICT(CODE,NAME,ALIAS,OUT_IN_PATIENT,INTERNAL_SURGERY,INPUT_CODE,PARENT_ID,ORDER_ID)VALUES"
           + "(@CODE,@NAME,@ALIAS,@OUT_IN_PATIENT,@INTERNAL_SURGERY,@INPUT_CODE,@PARENT_ID,@ORDER_ID)";
                        break;
                    case "U": //修改
                        //修改
                        sql = "UPDATE DEPT_DICT SET CODE=@CODE,NAME=@NAME,ALIAS=@ALIAS,OUT_IN_PATIENT=@OUT_IN_PATIENT,INTERNAL_SURGERY=@INTERNAL_SURGERY,INPUT_CODE=@INPUT_CODE,PARENT_ID=@PARENT_ID,ORDER_ID=@ORDER_ID "
           + " WHERE CODE=@CODE";
                        break;
                    case "D"://删除
                        sql = "DELETE FROM DEPT_DICT WHERE CODE=@CODE";
                        break;
                    default:
                        continue;// 不识别的代号则直接跳过
                        break;
                }

                SqlParameter[] parameters = new SqlParameter[8];
                parameters[0] = new SqlParameter("CODE", SqlDbType.VarChar, 32); // CODE;
                parameters[1] = new SqlParameter("NAME", SqlDbType.VarChar, 32); //NAME;
                parameters[2] = new SqlParameter("ALIAS", SqlDbType.VarChar, 32); //ALIAS;
                parameters[3] = new SqlParameter("OUT_IN_PATIENT", SqlDbType.VarChar, 2); //OUT_IN_PATIENT;
                parameters[4] = new SqlParameter("INTERNAL_SURGERY", SqlDbType.VarChar, 2);  //INTERNAL_SURGERY;
                parameters[5] = new SqlParameter("INPUT_CODE", SqlDbType.VarChar, 32); //INPUT_CODE;
                parameters[6] = new SqlParameter("PARENT_ID", SqlDbType.VarChar, 32); //PARENT_ID;
                parameters[7] = new SqlParameter("ORDER_ID", SqlDbType.Int, 50); //ORDER_ID;

                //赋值
                parameters[0].Value = dept.MD_DEPT_CODE; // CODE;
                parameters[1].Value = dept.MD_DEPT_NAME; //NAME;
                parameters[2].Value = dept.MD_DEPT_ENG_NAME; //ALIAS;
                parameters[3].Value = DBNull.Value; //OUT_IN_PATIENT;
                parameters[4].Value = DBNull.Value;  //INTERNAL_SURGERY;
                parameters[5].Value = dept.MD_SPELL; //INPUT_CODE;
                parameters[6].Value = dept.MD_SUPER_CODE; //PARENT_ID;
                parameters[7].Value = dept.MD_DEPT_SEQUENCE; //ORDER_ID;

                
                listsqls.Add(sql);
                listparameters.Add(parameters);
            }
            try
            {
                if (SQLServerHelper.ExecSqlByTran(listsqls, listparameters))
                {
                    return getResult(1, "成功");
                }
                else
                {
                    return getResult(-1, "失败了");
                }
            }
            catch (Exception ex)
            {
                return getResult(-1, string.Format("ERROR:{0}\r\nSTACKTRACE:{1}", ex.Message, ex.StackTrace));
            }

        /*
        /// 1	MD_COMP_CODE	单位编码	否	是	Varchar2(20)	　	生产	接收	　
        public string MD_COMP_CODE

        /// 2	MD_DEPT_CODE	部门编码	是	是	Varchar2(20)	　	生产	接收		　
        public string MD_DEPT_CODE

        /// 3	MD_DEPT_NAME	部门名称	否	是	Varchar2(40)	　	生产	接收		　
        public string MD_DEPT_NAME

        ///4	MD_DEPT_ENG_NAME	科室英文名	否	否	Varchar2(40)	　	生产	接收	可空	　
        public string MD_DEPT_ENG_NAME

        ///5	MD_DEPT_DEFINED	自定义码	否	否	Varchar2(40)	　	生产	接收	可空	　
        public string MD_DEPT_DEFINED
  
        /// 6	MD_DEPT_SEQUENCE	排序号	否	否	number	加载科室时的加载顺序	生产	接收	可空　
        public int MD_DEPT_SEQUENCE

        ///7	MD_DEPT_SHORT	科室简称	否	否	Varchar2(40)	　	生产	接收	可空	　
        public string MD_DEPT_SHORT

        /// 8	MD_DEPT_ACCOUNT	是否核算科室	否	否	Varchar2(8)	　	生产	接收	　		　
        public string MD_DEPT_ACCOUNT

        /// 9	MD_DEPT_SPECIAL	特殊科室属性	否	否	Varchar2(40)	特殊科室属性字典	生产	接收　
        public string MD_DEPT_SPECIAL

        /// 10	MD_IS_REGISTER	是否挂号科室	否	否	Varchar2(8)	　	生产	接收		　
        public string MD_IS_REGISTER

        /// 11	MD_SUPER_CODE	上级编码	否	否	Varchar2(20)	上级科室的编码	生产	接收		　
        public string MD_SUPER_CODE

        /// 12	MD_DEPT_LEVEL	部门级别	否	否	Varchar2(20)	　	生产	接收			　
        public string MD_DEPT_LEVEL

        /// 13	MD_SPELL	拼音码	否	否	Varchar2(8)	　	生产	接收	可空　
        public string MD_SPELL

        /// 14	MD_WUBI	五笔码	否	否	Varchar2(8)	　	生产	接收	可空　
        public string MD_WUBI

        /// 15	MD_ARRT_CODE	科室类型	否	否	Varchar2(20)	科室类型字典	生产	接收			　
        public string MD_ARRT_CODE

        /// 16	MD_IS_FUNC	职能部门标志	否	否	Varchar2(20)	　	生产	接收	可空		　
        public string MD_IS_FUNC

        /// 17	MD_IS_BUDG	预算标志	否	否	Varchar2(20)	　	生产	接收	可空	　
        public string MD_IS_BUDG

        /// 18	MD_IS_LAST	末级标志	否	否	Varchar2(20)	　	生产	接收		　
        public string MD_IS_LAST

        /// 19	MD_IS_STOCK	采购标志	否	否	Varchar2(20)	　	生产	接收			　
        public string MD_IS_STOCK

        /// 20	MD_IS_STOP	停用标志	否	否	Varchar2(20)	　	生产	接收			　
        public string MD_IS_STOP

        /// 21	MD_IS_OUTER	外部单位标志	否	否	Varchar2(20)	　	生产	接收	
        public string MD_IS_OUTER

        /// 22	MD_DEPT_ADDR	部门地址	否	否	Varchar2(100)	　	生产	接收	
　       public string MD_DEPT_ADDR

        /// 23	MD_ORI_BEDNUM	编制床位数	否	否	number	　	生产	接收
        public int MD_ORI_BEDNUM
  
        /// 24	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收	
　      public string MD_OPER_NAME

        /// 25	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收
	    public string MD_OPER_CODE

        /// 26	MD_OPER_TIME	操作时间	否	否	Va26	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收	
        public DateTime MD_OPER_TIME

        /// 27	MD_DEPT_EXT1	备用一	否	否	Varchar2(100)	　	生产	接收	　
        public string MD_DEPT_EXT1
   
        /// 28	MD_DEPT_EXT2	备用二	否	否	Varchar2(100)	　	生产	接收	　
        public string MD_DEPT_EXT2

        /// 29	MD_DEPT_EXT3	备用三	否	否	Varchar2(100)	　	生产	接收	
　      public string MD_DEPT_EXT3

        /// 30	DOEVENT	操作类型标志	否	否	Varchar2(1)	新增N 更新U 删除D	生产	接收	
　      public string DOEVENT
         * */
            return "";
        }

        /// <summary>
        /// 医院人员(EMPLOYEE)
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_employee(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return getResult(-1, "xml文件内容为空"); //校验失败
            }

            var list = InitEmployee(xml);//解析xml

            ////客户输入校验
            //string errors = Check(request);
            //if (!string.IsNullOrEmpty(errors))
            //{
            //    return getResult(1, errors); //校验失败
            //}

            var listsqls = new List<string>();
            var listparameters = new List<SqlParameter[]>();

            foreach (var user in list)
            {
                string sql = string.Empty;
                switch (user.DOEVENT)
                {
                    case "N": //新增
                        //新增
                        sql = "INSERT INTO USERS(ID,ENABLE,PASSWORD,PUBLIC_PASSWORD,INPUT,TRUE_NAME,MAIN_DEPT_CODE,"
                            + "MAIN_DEPT_NAME,IP_ADDRESS,CREATE_DATE,JOB_CATEGORY,PRO_TITLE,EMR_SECRET_LEVEL,PASSWORD_DATE,IS_LOCKED,USERNAME)"
                            + "VALUES(@ID,@ENABLE,@PASSWORD,@PUBLIC_PASSWORD,@INPUT,@TRUE_NAME,@MAIN_DEPT_CODE,"
                            + "@MAIN_DEPT_NAME,@IP_ADDRESS,getdate(),@JOB_CATEGORY,@PRO_TITLE,@EMR_SECRET_LEVEL,getdate(),@IS_LOCKED,@USERNAME)";
                        
                        break;
                    case "U": //修改
                        //修改
                        sql = "UPDATE USERS SET ID=@ID,ENABLE=@ENABLE,PASSWORD=@PASSWORD,PUBLIC_PASSWORD=@PUBLIC_PASSWORD,"
                            + "INPUT=@INPUT,TRUE_NAME=@TRUE_NAME,MAIN_DEPT_CODE=@MAIN_DEPT_CODE,"
                            + "MAIN_DEPT_NAME=@MAIN_DEPT_NAME,IP_ADDRESS=@IP_ADDRESS,CREATE_DATE=getdate(),JOB_CATEGORY=@JOB_CATEGORY,"
                            + "PRO_TITLE=@PRO_TITLE,EMR_SECRET_LEVEL=@EMR_SECRET_LEVEL,PASSWORD_DATE=getdate(),IS_LOCKED=@IS_LOCKED,USERNAME=@USERNAME"
                            + " WHERE ID=@ID";
                        break;
                    case "D"://删除
                        sql = "DELETE FROM USERS WHERE ID=@ID";
                        break;
                    default:
                        continue;// 不识别的代号则直接跳过
                        break;
                }

                SqlParameter[] parameters = new SqlParameter[14];
                parameters[0] = new SqlParameter("ID", SqlDbType.VarChar, 50); // ID;
                parameters[1] = new SqlParameter("ENABLE", SqlDbType.Int, 32); //ENABLE;
                parameters[2] = new SqlParameter("PASSWORD", SqlDbType.VarChar, 50); //PASSWORD;
                parameters[3] = new SqlParameter("PUBLIC_PASSWORD", SqlDbType.VarChar, 50); //PUBLIC_PASSWORD;
                parameters[4] = new SqlParameter("INPUT", SqlDbType.VarChar, 50);  //INPUT;
                parameters[5] = new SqlParameter("TRUE_NAME", SqlDbType.VarChar, 50); //TRUE_NAME;
                parameters[6] = new SqlParameter("MAIN_DEPT_CODE", SqlDbType.VarChar, 50); //MAIN_DEPT_CODE;
                parameters[7] = new SqlParameter("MAIN_DEPT_NAME", SqlDbType.VarChar, 50); //MAIN_DEPT_NAME;
                parameters[8] = new SqlParameter("IP_ADDRESS", SqlDbType.VarChar, 50); //IP_ADDRESS;
                parameters[9] = new SqlParameter("JOB_CATEGORY", SqlDbType.VarChar, 50); //JOB_CATEGORY;
                parameters[10] = new SqlParameter("PRO_TITLE", SqlDbType.VarChar, 64); //PRO_TITLE;
                parameters[11] = new SqlParameter("EMR_SECRET_LEVEL", SqlDbType.Int, 50); //EMR_SECRET_LEVEL;
                parameters[12] = new SqlParameter("IS_LOCKED", SqlDbType.VarChar, 2);  //IS_LOCKEDCA_KEY;
                parameters[13] = new SqlParameter("USERNAME", SqlDbType.VarChar, 50);  //USERNAME;


                //赋值
                parameters[0].Value = user.MD_OPER_CODE; // ID;
                parameters[1].Value = 0; //ENABLE;
                parameters[2].Value = "123456"; //PASSWORD; //初始密码123456
                parameters[3].Value = "000000"; //PUBLIC_PASSWORD;
                parameters[4].Value = user.MD_OPER_NAME;  //INPUT;
                parameters[5].Value = user.MD_EMP_NAME; //TRUE_NAME;
                parameters[6].Value = user.MD_DEPT_CODE; //MAIN_DEPT_CODE;
                parameters[7].Value = DBNull.Value; //MAIN_DEPT_NAME;
                parameters[8].Value = DBNull.Value; //IP_ADDRESS;

                if (user.MD_WORK.Length > 4)
                {
                    parameters[9].Value = user.MD_WORK.Substring(0, 4); //JOB_CATEGORY;
                }
                else
                {
                    parameters[9].Value = user.MD_WORK; //JOB_CATEGORY;
                }

                parameters[10].Value = user.MD_TITLE; //PRO_TITLE;
                parameters[11].Value = user.MD_WORK_LEVEL; //EMR_SECRET_LEVEL;
                parameters[12].Value = "1";  //IS_LOCKEDCA_KEY; 是否锁定（0锁定，1不锁定）//这个锁定是在登陆N次失败之后锁定的，和是否启用没有关系
                parameters[13].Value = user.MD_EMP_CODE; //USERNAME 使用人员编号

                listsqls.Add(sql);
                listparameters.Add(parameters);
            }
            try
            {
                if (SQLServerHelper.ExecSqlByTran(listsqls, listparameters))
                {
                    return getResult(1, "成功");
                }
                else
                {
                    return getResult(-1, "失败了");
                }
            }
            catch (Exception ex)
            {
                return getResult(1, string.Format("ERROR:{0}\r\nSTACKTRACE:{1}", ex.Message, ex.StackTrace));
            }
        }

        /// <summary>
        /// 药品信息（DRUG）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_drug(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return getResult(-1, "xml文件内容为空"); //校验失败
            }

            var list = InitDrug(xml);//解析xml

            ////用户输入校验
            //string errors = Check(listDrugInfo);
            //if (!string.IsNullOrEmpty(errors))
            //{
            //    return getResult(1, errors); //校验失败
            //}

            List<string> listsqls = new List<string>();
            List<SqlParameter[]> listparameters = new List<SqlParameter[]>();

            foreach (var drug in list)
            {
                string sql = string.Empty;

                switch (drug.DOEVENT)
                {
                    case "N": //新增
                        //新增
                        sql = "INSERT INTO T_BASE_MEDICODE(MEDICODE,PRICESORTMAIN,MEDITYPE,MEDINAME, MEDIALIAS1,MEDIALIAS2,MEDIALIAS3"
                    + ",SPEC,PACKUNIT,BASEQTY,BASEUNIT,DOSAGETYPE,EFFICACY,MEDISORT,FACTORY,VALUETYPE,ISANTIBIOTIC,TOXICOTYPE,"
                    + "INJECTORTYPE,ISUSEREFRI,ISCENTRAL,SHORTCUT,MATCHCODE,FILETYPE,FILENO,REMARK,ISUSED,UPDATEID,UPDATEDATE,"
                    + "LENGTH,WIDTH,HEIGHT,PACKAGINGCATEGORY,LOCATION,VOLUME,DOSEUNIT,DOSEQTY,WEIGHTTYPE,WEIGHT,IfIpackWB,IFDMG)"
                    + "VALUES(@MEDICODE,@PRICESORTMAIN,@MEDITYPE,@MEDINAME, @MEDIALIAS1,@MEDIALIAS2,@MEDIALIAS3,"
                    + "@SPEC,@PACKUNIT,@BASEQTY,@BASEUNIT,@DOSAGETYPE,@EFFICACY,@MEDISORT,@FACTORY,@VALUETYPE,@ISANTIBIOTIC,@TOXICOTYPE,"
                    + "@INJECTORTYPE,@ISUSEREFRI,@ISCENTRAL,@SHORTCUT,@MATCHCODE,@FILETYPE,@FILENO,@REMARK,@ISUSED,@UPDATEID,getdate(),"
                    + "@LENGTH,@WIDTH,@HEIGHT,@PACKAGINGCATEGORY,@LOCATION,@VOLUME,@DOSEUNIT,@DOSEQTY,@WEIGHTTYPE,@WEIGHT,0,0)";
                        break;
                    case "U": //修改
                        //更新
                        sql = "UPDATE T_BASE_MEDICODE SET PRICESORTMAIN=@PRICESORTMAIN,MEDITYPE=@MEDITYPE"
                    + ",MEDINAME=@MEDINAME,MEDIALIAS1=@MEDIALIAS1,MEDIALIAS2=@MEDIALIAS2,MEDIALIAS3=@MEDIALIAS3"
                    + ",SPEC=@SPEC,PACKUNIT=@PACKUNIT,BASEQTY=@BASEQTY,BASEUNIT=@BASEUNIT,DOSAGETYPE=@DOSAGETYPE,EFFICACY=@EFFICACY"
                    + ",MEDISORT=@MEDISORT,FACTORY=@FACTORY,VALUETYPE=@VALUETYPE,ISANTIBIOTIC=@ISANTIBIOTIC,TOXICOTYPE=@TOXICOTYPE,"
                    + "INJECTORTYPE=@INJECTORTYPE,ISUSEREFRI=@ISUSEREFRI,ISCENTRAL=@ISCENTRAL,SHORTCUT=@SHORTCUT,MATCHCODE=@MATCHCODE"
                    + ",FILETYPE=@FILETYPE,FILENO=@FILENO,REMARK=@REMARK,ISUSED=@ISUSED,UPDATEID=@UPDATEID,UPDATEDATE=getdate(),"
                    + "LENGTH=@LENGTH,WIDTH=@WIDTH,HEIGHT=@HEIGHT,PACKAGINGCATEGORY=@PACKAGINGCATEGORY,LOCATION=@LOCATION"
                    + ",VOLUME=@VOLUME,DOSEUNIT=@DOSEUNIT,DOSEQTY=@DOSEQTY,WEIGHTTYPE=@WEIGHTTYPE,WEIGHT=@WEIGHT WHERE MEDICODE=@MEDICODE";
                        break;
                    case "D"://删除
                        sql = "DELETE FROM T_BASE_MEDICODE WHERE MEDICODE=@MEDICODE";
                        break;
                    default:
                        continue;// 不识别的代号则直接跳过
                        break;
                }


                SqlParameter[] parameters = new SqlParameter[40];
                parameters[0] = new SqlParameter("MEDICODE", SqlDbType.VarChar, 50); // MEDICODE;
                parameters[1] = new SqlParameter("PRICESORTMAIN", SqlDbType.VarChar, 50); //PRICESORTMAIN;
                parameters[2] = new SqlParameter("MEDITYPE", SqlDbType.VarChar, 50); //MEDITYPE;
                parameters[3] = new SqlParameter("MEDINAME", SqlDbType.VarChar, 100); //MEDINAME;
                parameters[4] = new SqlParameter("MEDIALIAS1", SqlDbType.VarChar, 100);  //MEDIALIAS1;
                parameters[5] = new SqlParameter("MEDIALIAS2", SqlDbType.VarChar, 100); //MEDIALIAS2;
                parameters[6] = new SqlParameter("MEDIALIAS3", SqlDbType.VarChar, 100); //MEDIALIAS3;
                parameters[7] = new SqlParameter("SPEC", SqlDbType.VarChar, 50); //SPEC;
                parameters[8] = new SqlParameter("PACKUNIT", SqlDbType.VarChar, 4); //PACKUNIT;
                parameters[9] = new SqlParameter("BASEQTY", SqlDbType.Int, 30); //BASEQTY;
                parameters[10] = new SqlParameter("BASEUNIT", SqlDbType.VarChar, 50); //BASEUNIT;
                parameters[11] = new SqlParameter("DOSAGETYPE", SqlDbType.VarChar, 50);  //DOSAGETYPE;
                parameters[12] = new SqlParameter("EFFICACY", SqlDbType.VarChar, 50); //EFFICACY;
                parameters[13] = new SqlParameter("MEDISORT", SqlDbType.VarChar, 50); //MEDISORT;
                parameters[14] = new SqlParameter("FACTORY", SqlDbType.VarChar, 50);  //FACTORY;
                parameters[15] = new SqlParameter("VALUETYPE", SqlDbType.VarChar, 50); //VALUETYPE;
                parameters[16] = new SqlParameter("ISANTIBIOTIC", SqlDbType.Int, 2);  //ISANTIBIOTIC;
                parameters[17] = new SqlParameter("TOXICOTYPE", SqlDbType.VarChar, 50);  //TOXICOTYPE;
                parameters[18] = new SqlParameter("INJECTORTYPE", SqlDbType.VarChar, 50);  //INJECTORTYPE;
                parameters[19] = new SqlParameter("ISUSEREFRI", SqlDbType.Int, 2);  //ISUSEREFRI 是否冷藏;
                parameters[20] = new SqlParameter("ISCENTRAL", SqlDbType.Int, 2); //ISCENTRAL;
                parameters[21] = new SqlParameter("SHORTCUT", SqlDbType.VarChar, 50);  //SHORTCUT;
                parameters[22] = new SqlParameter("MATCHCODE", SqlDbType.VarChar, 50);  //MATCHCODE;
                parameters[23] = new SqlParameter("FILETYPE", SqlDbType.VarChar, 50);  //FILETYPE;
                parameters[24] = new SqlParameter("FILENO", SqlDbType.VarChar, 50); //FILENO;
                parameters[25] = new SqlParameter("REMARK", SqlDbType.VarChar, 50);  //REMARK;
                parameters[26] = new SqlParameter("ISUSED", SqlDbType.Int, 2);  //ISUSED;
                parameters[27] = new SqlParameter("UPDATEID", SqlDbType.VarChar, 50);  //UPDATEID;
                parameters[28] = new SqlParameter("LENGTH", SqlDbType.Float, 50);  //LENGTH;
                parameters[29] = new SqlParameter("WIDTH", SqlDbType.Float, 50);  //WIDTH;
                parameters[30] = new SqlParameter("HEIGHT", SqlDbType.Float, 50);  //HEIGHT;
                parameters[31] = new SqlParameter("PACKAGINGCATEGORY", SqlDbType.Int, 2);  //PACKAGINGCATEGORY;
                parameters[32] = new SqlParameter("PICTURE", SqlDbType.Image, 50);  //PICTURE;
                parameters[33] = new SqlParameter("LOCATION", SqlDbType.VarChar, 50);  //LOCATION;
                parameters[34] = new SqlParameter("VOLUME", SqlDbType.Float, 20);  //VOLUME;
                parameters[35] = new SqlParameter("DOSEUNIT", SqlDbType.VarChar, 50);  //DOSEUNIT;
                parameters[36] = new SqlParameter("DOSEQTY", SqlDbType.Float, 20);  //DOSEQTY;
                parameters[37] = new SqlParameter("WEIGHTTYPE", SqlDbType.Int, 20);  //WEIGHTTYPE;
                parameters[38] = new SqlParameter("WEIGHT", SqlDbType.Float, 20);  //WEIGHT;
                parameters[39] = new SqlParameter("UPDATEDATE", SqlDbType.DateTime, 50);  //UPDATEID;

                //赋值
                parameters[0].Value = drug.MD_DRUG_CODE; // MEDICODE; 药品编码
                parameters[1].Value = drug.MD_DRUG_TYPE; //药品主分类;
                parameters[2].Value = DBNull.Value; //药品子分类;
                parameters[3].Value = drug.MD_TRADE_NAME; //MEDINAME;
                parameters[4].Value = drug.MD_DRUG_EXT1;  //MEDIALIAS1;
                parameters[5].Value = drug.MD_DRUG_EXT2; //MEDIALIAS2;
                parameters[6].Value = drug.MD_DRUG_EXT3; //MEDIALIAS3;
                parameters[7].Value = drug.MD_SPECS; //SPEC 规格;
                parameters[8].Value = drug.MD_PACK_UNIT; //PACKUNIT 包装单位;
                parameters[9].Value = DBNull.Value; //BASEQTY 包装含量;
                parameters[10].Value = DBNull.Value; //BASEUNIT 含量单位;
                parameters[11].Value = drug.MD_MODEL_CODE;  //DOSAGETYPE 剂型;
                parameters[12].Value = DBNull.Value; //EFFICACY;
                parameters[13].Value = DBNull.Value; //MEDISORT;
                parameters[14].Value = DBNull.Value;  //FACTORY 生产厂家;
                parameters[15].Value = DBNull.Value; //VALUETYPE;
                parameters[16].Value = drug.MD_ANT_FLAG;  //ISANTIBIOTIC 是否抗生素;
                parameters[17].Value = DBNull.Value;  //TOXICOTYPE 毒理分类;
                parameters[18].Value = DBNull.Value;  //INJECTORTYPE;
                parameters[19].Value = DBNull.Value;  //ISUSEREFRI;
                parameters[20].Value = DBNull.Value; //ISCENTRAL;
                parameters[21].Value = drug.MD_SPELL_CODE;  //SHORTCUT 缩写;
                parameters[22].Value = DBNull.Value;  //MATCHCODE;
                parameters[23].Value = DBNull.Value;  //FILETYPE;
                parameters[24].Value = drug.MD_APPROVE_INFO; //FILENO; 批文信息
                parameters[25].Value = DBNull.Value;  //REMARK;
                parameters[26].Value = drug.MD_VALID_STATE;  //ISUSED;
                parameters[27].Value = DBNull.Value;  //UPDATEID;
                parameters[28].Value = DBNull.Value;  //LENGTH;
                parameters[29].Value = DBNull.Value;  //WIDTH;
                parameters[30].Value = DBNull.Value;  //HEIGHT;
                parameters[31].Value = DBNull.Value;  //PACKAGINGCATEGORY;
                parameters[32].Value = DBNull.Value;  //PICTURE;
                parameters[33].Value = DBNull.Value;  //LOCATION;
                parameters[34].Value = DBNull.Value;  //VOLUME;
                parameters[35].Value = DBNull.Value;  //DOSEUNIT;
                parameters[36].Value = DBNull.Value;  //DOSEQTY;
                parameters[37].Value = DBNull.Value;  //WEIGHTTYPE;
                parameters[38].Value = DBNull.Value;  //WEIGHT;
                parameters[39].Value = DBNull.Value;  //WEIGHT;


                listsqls.Add(sql);
                listparameters.Add(parameters);

                /* 没有用到的字段


        /// 5	MD_DRUG_QUALITY	药品性质	否	否	VARCHAR2(2)	HIS提供字典	生产	接收	不处理
        public string MD_DRUG_QUALITY

        /// 7	MD_RETAIL_PRICE	零售价	否	否	NUMBER(12,4)	药库零价	生产	接收	不处理
        public double MD_RETAIL_PRICE

        /// 11	MD_SELF_FLAG	自制标志	否	否	VARCHAR2(1)	自制制剂标志  1  ,0  	生产	接收	不处理
        public string MD_SELF_FLAG
  
        /// 12	MD_TEST_FLAG	是否需要皮试	否	否	VARCHAR2(1)	皮试标志     1  ,0  	生产	接收	不处理
        public string MD_TEST_FLAG

        /// 14	MD_OWNFEE_FLAG	自费或可报	否	否	VARCHAR2(1)	 1  自费  0 可报	生产	接收	不处理
        public string MD_OWNFEE_FLAG

        /// 15	MD_PUBFEERATE	自付比例	否	否	VARCHAR2(5)	如 10  代表 10%自付 20 代表20%自付	生产	接收	不处理
        public string MD_PUBFEERATE

        /// 17	MD_ISBASEDRUG	是否基本药物	否	否	VARCHAR2(1)	‘1’ 基本药物 ‘0’ 非基本药物	生产	接收	不处理
        public string MD_ISBASEDRUG

        /// <summary>
        /// 18	MD_ISELECRECIPE	是否电子处方	否	否	VARCHAR2(1)	电子病历可用标志 0 不可用 1 可用	生产	接收	不处理
        public string MD_ISELECRECIPE

        /// 19	MD_ANTIBIOTICS_LEVEL	抗生素等级	否	否	VARCHAR2(1)	1代表一级  2代表二级 3代表三级	生产	接收	不处理
        public string MD_ANTIBIOTICS_LEVEL

        /// <summary>
        /// 23	MD_OPER_NAME	操作员姓名	否	否	Varchar2(20)	　	生产	接收	
        /// </summary>
        public string MD_OPER_NAME

        /// 24	MD_OPER_CODE	操作员编号	否	否	Varchar2(20)	　	生产	接收
        public string MD_OPER_CODE

        /// 25	MD_OPER_TIME	操作时间	否	否	Varchar2(20)	　	生产	接收
        public DateTime MD_OPER_TIME


                 * */
            }
            try
            {
                if (SQLServerHelper.ExecSqlByTran(listsqls, listparameters))
                {
                    return getResult(1, "成功");
                }
                else
                {
                    return getResult(-1, "失败了");
                }
            }
            catch (Exception ex)
            {
                return getResult(1, string.Format("ERROR:{0}\r\nSTACKTRACE:{1}", ex.Message, ex.StackTrace));
            }
        }


        //以下4,5,6,7暂不提供接口

        /// <summary>
        /// 其它非药品收费项目（UNDRUG）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_undrug(string xml)
        {
            return "";
        }

        /// <summary>
        /// 物资材料信息（MATERIAL）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_material(string xml)
        {
            return "";
        }

        /// <summary>
        /// 供应商（PROVIDER）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_provider(string xml)
        {
            return "";
        }

        /// <summary>
        /// 生产厂家（manufactorer）
        /// </summary>
        /// <param name="xml">处方信息xml</param>
        /// <returns>成功结果xml</returns>
        public static string deal_manufactorer(string xml)
        {
            return "";
        }
        #endregion
        
        #region 校验方法 对每一个客户端调用传值都需要进行校验

        private static string Check(List<EMPLOYEE> list)
        {
            List<string> listResult = new List<string>();
            if (list == null || list.Count <= 0)
            {
                listResult.Add("没有可执行的对象【-1】");
            }
            else
            {
                for (int i = 0; i < list.Count;i++ )
                {
                    var employee = list[i];
                    if (string.IsNullOrEmpty(employee.MD_EMP_CODE))
                    {
                        listResult.Add(string.Format("人员编码为空【{0}】", i));
                    }

                    if (string.IsNullOrEmpty(employee.MD_EMP_NAME))
                    {
                        listResult.Add(string.Format("人员名称为空【{0}】", i));
                    }
                }
            }

            return GetErrorString(listResult);
        }


        /// <summary>
        /// 根据错误信息列表生成错误字符串
        /// </summary>
        /// <param name="listResult">错误列表</param>
        /// <returns>错误字符串</returns>
        private static string GetErrorString(List<string> listResult)
        {
            if (listResult == null || listResult.Count <= 0)
            {
                return string.Empty; //通过
            }
            else
            {
                string stemp = "";
                for (int i = 0; i < listResult.Count; i++)
                {
                    if (i == 0)
                    {
                        stemp = listResult[i];
                    }
                    else
                    {
                        stemp += ("," + listResult[i]);
                    }
                }

                return stemp;
            }

        }

        ///// <summary>
        ///// 3.1校验 服务端对客户端传入药品信息校验
        ///// </summary>
        ///// <param name="listDrugInfo">药品列表</param>
        ///// <returns>校验通过返回空字符串 失败则字符串不为空</returns>
        //private static string Check(List<DrugInfo> listDrugInfo)
        //{
        //    List<string> listResult = new List<string>();
        //    if (listDrugInfo == null || listDrugInfo.Count <= 0)
        //    {
        //        listResult.Add("没有可执行的对象【-1】");
        //    }
        //    else
        //    {
        //        for (int i = 0; i < listDrugInfo.Count; i++)
        //        {
        //            if (string.IsNullOrEmpty(listDrugInfo[i].ArcimCode))
        //            {
        //                listResult.Add(string.Format("药品编码为空【{0}】", i));
        //            }

        //            if (string.IsNullOrEmpty(listDrugInfo[i].ArcimDesc))
        //            {
        //                listResult.Add(string.Format("药品名称为空【{0}】", i));
        //            }

        //            if (string.IsNullOrEmpty(listDrugInfo[i].Specification))
        //            {
        //                listResult.Add(string.Format("药品规格为空【{0}】", i));
        //            }

        //            if (string.IsNullOrEmpty(listDrugInfo[i].PackUnit))
        //            {
        //                listResult.Add(string.Format("药品包装单位为空【{0}】", i));
        //            }
        //        }
        //    }

        //    return GetErrorString(listResult);
        //}


       
        #endregion
       
        #region 私有方法

        /// <summary>
        /// 根据处方号查询处方ID 
        /// </summary>
        /// <param name="prescriptionNo">处方号</param>
        /// <returns>处方ID</returns>
        private static string GetPrescriptionID(string prescriptionNo)
        {
            string sql = "select PrescriptionID,PrescriptionNo from T_Prescription_Master_Temp where PrescriptionNo=@PrescriptionNo";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("PrescriptionNo", SqlDbType.VarChar, 50);
            parameters[0].Value = prescriptionNo; // ID;
            var ds = SQLServerHelper.GetDataTable(sql, parameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 返回xml结果
        /// </summary>
        /// <param name="result">1 成功 -1 其他失败</param>
        /// <param name="message">返回结果信息详细内容</param>
        /// <returns>返回结果</returns>
        private static string getResult(int result, string message)
        {
            return string.Format("<ROOT><MARK>{0}</MARK><MSG>{1}</MSG></ROOT>"
                , result, message);
        }


        #region 解析xml方法
        /// <summary>
        /// 解析科室(DEPARTMENT)
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回科室列表</returns>
        public static List<DEPARTMENT> InitDepartment(string xml)
        {
            List<DEPARTMENT> list = new List<DEPARTMENT>();
            var departNodeList = XMLHelper.selectNodeList(xml, "MSG/ROW");  //selectNodeList  getNodeList
            if (departNodeList.Count > 0)
            {
                foreach (XmlNode node in departNodeList)
                {
                    var department = new DEPARTMENT();
                    department.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);
                    department.MD_ARRT_CODE = XMLHelper.getValue(node.OuterXml, "MD_ARRT_CODE", false);
                    department.MD_COMP_CODE = XMLHelper.getValue(node.OuterXml, "MD_COMP_CODE", false);
                    department.MD_DEPT_ACCOUNT = XMLHelper.getValue(node.OuterXml, "MD_DEPT_ACCOUNT", false);
                    department.MD_DEPT_ADDR = XMLHelper.getValue(node.OuterXml, "MD_DEPT_ADDR", false);
                    department.MD_DEPT_CODE = XMLHelper.getValue(node.OuterXml, "MD_DEPT_CODE", false);
                    department.MD_DEPT_DEFINED = XMLHelper.getValue(node.OuterXml, "MD_DEPT_DEFINED", false);
                    department.MD_DEPT_ENG_NAME = XMLHelper.getValue(node.OuterXml, "MD_DEPT_ENG_NAME", false);
                    department.MD_DEPT_EXT1 = XMLHelper.getValue(node.OuterXml, "MD_DEPT_EXT1", false);
                    department.MD_DEPT_EXT2 = XMLHelper.getValue(node.OuterXml, "MD_DEPT_EXT2", false);
                    department.MD_DEPT_EXT3 = XMLHelper.getValue(node.OuterXml, "MD_DEPT_EXT3", false);
                    department.MD_DEPT_LEVEL = XMLHelper.getValue(node.OuterXml, "MD_DEPT_LEVEL", false);
                    department.MD_DEPT_NAME = XMLHelper.getValue(node.OuterXml, "MD_DEPT_NAME", false);
                    int squence = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_DEPT_SEQUENCE", false), out squence))
                    {
                        department.MD_DEPT_SEQUENCE = squence;
                    }
                    
                    department.MD_DEPT_SHORT = XMLHelper.getValue(node.OuterXml, "MD_DEPT_SHORT", false);
                    department.MD_DEPT_SPECIAL = XMLHelper.getValue(node.OuterXml, "MD_DEPT_SPECIAL", false);
                    department.MD_IS_BUDG = XMLHelper.getValue(node.OuterXml, "MD_IS_BUDG", false);
                    department.MD_IS_FUNC = XMLHelper.getValue(node.OuterXml, "MD_IS_FUNC", false);
                    department.MD_IS_LAST = XMLHelper.getValue(node.OuterXml, "MD_IS_LAST", false);
                    department.MD_IS_OUTER = XMLHelper.getValue(node.OuterXml, "MD_IS_OUTER", false);
                    department.MD_IS_REGISTER = XMLHelper.getValue(node.OuterXml, "MD_IS_REGISTER", false);
                    department.MD_IS_STOCK = XMLHelper.getValue(node.OuterXml, "MD_IS_STOCK", false);
                    department.MD_IS_STOP = XMLHelper.getValue(node.OuterXml, "MD_IS_STOP", false);
                    department.MD_OPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_OPER_CODE", false);
                    department.MD_OPER_NAME = XMLHelper.getValue(node.OuterXml, "MD_OPER_NAME", false);

                    DateTime opTime = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_OPER_TIME", false), out opTime))
                    {
                        department.MD_OPER_TIME = opTime;
                    }

                    int bednum = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_ORI_BEDNUM", false), out bednum))
                    {
                        department.MD_ORI_BEDNUM = bednum;
                    }
                    department.MD_SPELL = XMLHelper.getValue(node.OuterXml, "MD_SPELL", false);
                    department.MD_SUPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_SUPER_CODE", false);
                    department.MD_WUBI = XMLHelper.getValue(node.OuterXml, "MD_WUBI", false);
                    list.Add(department);
                }
            }
            return list;
        }

        /// <summary>
        /// 解析医院人员(EMPLOYEE)
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回医院人员列表</returns>
        public static List<EMPLOYEE> InitEmployee(string xml)
        {
            List<EMPLOYEE> list = new List<EMPLOYEE>();
            var employeeNodeList = XMLHelper.selectNodeList(xml, "MSG/ROW");  //selectNodeList  getNodeList
            if (employeeNodeList.Count > 0)
            {
                foreach (XmlNode node in employeeNodeList)
                {
                    var emplyee=new EMPLOYEE();
                    emplyee.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);
                    DateTime birthday = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_BIRTHDAY", false), out birthday))
                    {
                        emplyee.MD_BIRTHDAY = birthday;
                    }
                    emplyee.MD_COMP_CODE = XMLHelper.getValue(node.OuterXml, "MD_COMP_CODE", false);
                    DateTime createDate = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_CREATE_DATE", false), out createDate))
                    {
                        emplyee.MD_CREATE_DATE = createDate;
                    }
                    emplyee.MD_DEPT_CODE = XMLHelper.getValue(node.OuterXml, "MD_DEPT_CODE", false);
                    emplyee.MD_EDUCATION = XMLHelper.getValue(node.OuterXml, "MD_EDUCATION", false);
                    emplyee.MD_EMAIL = XMLHelper.getValue(node.OuterXml, "MD_EMAIL", false);
                    emplyee.MD_EMP_CODE = XMLHelper.getValue(node.OuterXml, "MD_EMP_CODE", false);
                    emplyee.MD_EMP_EXT1 = XMLHelper.getValue(node.OuterXml, "MD_EMP_EXT1", false);
                    emplyee.MD_EMP_EXT2 = XMLHelper.getValue(node.OuterXml, "MD_EMP_EXT2", false);
                    emplyee.MD_EMP_EXT3 = XMLHelper.getValue(node.OuterXml, "MD_EMP_EXT3", false);
                    emplyee.MD_EMP_IDNO = XMLHelper.getValue(node.OuterXml, "MD_EMP_IDNO", false);
                    emplyee.MD_EMP_NAME = XMLHelper.getValue(node.OuterXml, "MD_EMP_NAME", false);
                    emplyee.MD_EMP_TYPE = XMLHelper.getValue(node.OuterXml, "MD_EMP_TYPE", false);
                    emplyee.MD_INPUT_CODE = XMLHelper.getValue(node.OuterXml, "MD_INPUT_CODE", false);
                    emplyee.MD_IS_STOP = XMLHelper.getValue(node.OuterXml, "MD_IS_STOP", false);
                    emplyee.MD_IS_TALENT = XMLHelper.getValue(node.OuterXml, "MD_IS_TALENT", false);
                    emplyee.MD_OPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_OPER_CODE", false);
                    emplyee.MD_OPER_NAME = XMLHelper.getValue(node.OuterXml, "MD_OPER_NAME", false);

                    DateTime opTime = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_OPER_TIME", false), out opTime))
                    {
                        emplyee.MD_OPER_TIME = opTime;
                    }

                    emplyee.MD_PHONE = XMLHelper.getValue(node.OuterXml, "MD_PHONE", false);
                    emplyee.MD_SEX = XMLHelper.getValue(node.OuterXml, "MD_SEX", false);
                    emplyee.MD_STAMP_NO = XMLHelper.getValue(node.OuterXml, "MD_STAMP_NO", false);
                    emplyee.MD_TALENT_TYPE = XMLHelper.getValue(node.OuterXml, "MD_TALENT_TYPE", false);
                    emplyee.MD_TITLE = XMLHelper.getValue(node.OuterXml, "MD_TITLE", false);
                    emplyee.MD_TITLE_HERP = XMLHelper.getValue(node.OuterXml, "MD_TITLE_HERP", false);
                    emplyee.MD_WORK = XMLHelper.getValue(node.OuterXml, "MD_WORK", false);
                    emplyee.MD_WORK_LEVEL = XMLHelper.getValue(node.OuterXml, "MD_WORK_LEVEL", false);
                    emplyee.MD_WUBI_CODE = XMLHelper.getValue(node.OuterXml, "MD_WUBI_CODE", false);
                    list.Add(emplyee);
                }
            }
            return list;
        }

        /// <summary>
        /// 解析药品信息（DRUG）
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回药品信息列表</returns>
        public static List<DRUG> InitDrug(string xml)
        {
            List<DRUG> list = new List<DRUG>();
            var drugNodeList = XMLHelper.selectNodeList(xml, "MSG/ROW");  //selectNodeList  getNodeList
            if (drugNodeList.Count > 0)
            {
                foreach (XmlNode node in drugNodeList)
                {
                    var drug = new DRUG();
                    drug.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);

                    int antFlag = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_ANT_FLAG", false), out antFlag))
                    {
                        drug.MD_ANT_FLAG = antFlag;
                    }

                    drug.MD_ANTIBIOTICS_LEVEL = XMLHelper.getValue(node.OuterXml, "MD_ANTIBIOTICS_LEVEL", false);
                    drug.MD_APPROVE_INFO = XMLHelper.getValue(node.OuterXml, "MD_APPROVE_INFO", false);
                    drug.MD_DRUG_CODE = XMLHelper.getValue(node.OuterXml, "MD_DRUG_CODE", false);
                    drug.MD_DRUG_EXT1 = XMLHelper.getValue(node.OuterXml, "MD_DRUG_EXT1", false);
                    drug.MD_DRUG_EXT2 = XMLHelper.getValue(node.OuterXml, "MD_DRUG_EXT2", false);
                    drug.MD_DRUG_EXT3 = XMLHelper.getValue(node.OuterXml, "MD_DRUG_EXT3", false);
                    drug.MD_DRUG_QUALITY = XMLHelper.getValue(node.OuterXml, "MD_DRUG_QUALITY", false);
                    drug.MD_DRUG_TYPE = XMLHelper.getValue(node.OuterXml, "MD_DRUG_TYPE", false);
                    drug.MD_ISBASEDRUG = XMLHelper.getValue(node.OuterXml, "MD_ISBASEDRUG", false);
                    drug.MD_ISELECRECIPE = XMLHelper.getValue(node.OuterXml, "MD_ISELECRECIPE", false);
                    drug.MD_MODEL_CODE = XMLHelper.getValue(node.OuterXml, "MD_MODEL_CODE", false);
                    drug.MD_OPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_OPER_CODE", false);
                    drug.MD_OPER_NAME = XMLHelper.getValue(node.OuterXml, "MD_OPER_NAME", false);

                    drug.MD_OWNFEE_FLAG = XMLHelper.getValue(node.OuterXml, "MD_OWNFEE_FLAG", false);
                    drug.MD_PACK_UNIT = XMLHelper.getValue(node.OuterXml, "MD_PACK_UNIT", false);
                    drug.MD_PUBFEERATE = XMLHelper.getValue(node.OuterXml, "MD_PUBFEERATE", false);

                    drug.MD_SELF_FLAG = XMLHelper.getValue(node.OuterXml, "MD_SELF_FLAG", false);
                    drug.MD_SPECS = XMLHelper.getValue(node.OuterXml, "MD_SPECS", false);
                    drug.MD_SPELL_CODE = XMLHelper.getValue(node.OuterXml, "MD_SPELL_CODE", false);
                    drug.MD_TEST_FLAG = XMLHelper.getValue(node.OuterXml, "MD_TEST_FLAG", false);
                    drug.MD_TRADE_NAME = XMLHelper.getValue(node.OuterXml, "MD_TRADE_NAME", false);
 
                    int validState = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_VALID_STATE", false), out validState))
                    {
                        drug.MD_VALID_STATE = validState;
                    }

                    Double price = 0;
                    if (double.TryParse(XMLHelper.getValue(node.OuterXml, "MD_RETAIL_PRICE", false), out price))
                    {
                        drug.MD_RETAIL_PRICE = price;
                    }
                    DateTime opTime = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_OPER_TIME", false), out opTime))
                    {
                        drug.MD_OPER_TIME = opTime;
                    }
                    list.Add(drug);
                }
            }
            return list;
        }

        /// <summary>
        /// 解析其它非药品收费项目（UNDRUG）
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回非药品收费项目列表</returns>
        public static List<UNDRUG> InitUuDrug(string xml)
        {
            List<UNDRUG> list = new List<UNDRUG>();
            var drugUnNodeList = XMLHelper.selectNodeList(xml, "MSG/ROW");  //selectNodeList  getNodeList
            if (drugUnNodeList.Count > 0)
            {
                foreach (XmlNode node in drugUnNodeList)
                {
                    var uNDrug = new UNDRUG();
                    uNDrug.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);
                    uNDrug.MD_APPLICABILITYAREA = XMLHelper.getValue(node.OuterXml, "MD_APPLICABILITYAREA", false);
                    uNDrug.MD_EXEDEPT_CODE = XMLHelper.getValue(node.OuterXml, "MD_EXEDEPT_CODE", false);
                    uNDrug.MD_FEE_CODE = XMLHelper.getValue(node.OuterXml, "MD_FEE_CODE", false);
                    uNDrug.MD_OPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_OPER_CODE", false);
                    uNDrug.MD_OPER_NAME = XMLHelper.getValue(node.OuterXml, "MD_OPER_NAME", false);

                    uNDrug.MD_SPECIAL_FLAG2 = XMLHelper.getValue(node.OuterXml, "MD_SPECIAL_FLAG2", false);
                    uNDrug.MD_SPECIAL_FLAG3 = XMLHelper.getValue(node.OuterXml, "MD_SPECIAL_FLAG3", false);
                    uNDrug.MD_SPELL_CODE = XMLHelper.getValue(node.OuterXml, "MD_SPELL_CODE", false);
                    uNDrug.MD_STOCK_UNIT = XMLHelper.getValue(node.OuterXml, "MD_STOCK_UNIT", false);
                    uNDrug.MD_UNDRUG_CODE = XMLHelper.getValue(node.OuterXml, "MD_UNDRUG_CODE", false);
                    uNDrug.MD_UNDRUG_EXT1 = XMLHelper.getValue(node.OuterXml, "MD_UNDRUG_EXT1", false);
                    uNDrug.MD_UNDRUG_EXT2 = XMLHelper.getValue(node.OuterXml, "MD_UNDRUG_EXT2", false);
                    uNDrug.MD_UNDRUG_EXT3 = XMLHelper.getValue(node.OuterXml, "MD_UNDRUG_EXT3", false);
                    uNDrug.MD_UNDRUG_FEE_CODE = XMLHelper.getValue(node.OuterXml, "MD_UNDRUG_FEE_CODE", false);
                    uNDrug.MD_UNDRUG_FEE_NAME = XMLHelper.getValue(node.OuterXml, "MD_UNDRUG_FEE_NAME", false);
                    uNDrug.MD_UNDRUG_NAME = XMLHelper.getValue(node.OuterXml, "MD_UNDRUG_NAME", false);

                    uNDrug.MD_VALID_STATE = XMLHelper.getValue(node.OuterXml, "MD_VALID_STATE", false);
                    

                    Double price = 0;
                    if (double.TryParse(XMLHelper.getValue(node.OuterXml, "MD_UNIT_PRICE", false), out price))
                    {
                        uNDrug.MD_UNIT_PRICE = price;
                    }
                    DateTime opTime = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_OPER_TIME", false), out opTime))
                    {
                        uNDrug.MD_OPER_TIME = opTime;
                    }
                    list.Add(uNDrug);
                }
            }
            return list;
        }

        /// <summary>
        /// 解析物资材料信息（MATERIAL）
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回物资材料列表</returns>
        public static List<MATERIAL> InitMaterial(string xml)
        {
            List<MATERIAL> list = new List<MATERIAL>();
            var materialNodeList = XMLHelper.selectNodeList(xml, "MSG/ROW");  //selectNodeList  getNodeList
            if (materialNodeList.Count > 0)
            {
                foreach (XmlNode node in materialNodeList)
                {
                    var material = new MATERIAL();
                    material.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);
                    material.MD_COST = XMLHelper.getValue(node.OuterXml, "MD_COST", false);
                    material.MD_EXEDEPT_CODE = XMLHelper.getValue(node.OuterXml, "MD_EXEDEPT_CODE", false);
                    material.MD_FEE_CODE = XMLHelper.getValue(node.OuterXml, "MD_FEE_CODE", false);
                    material.MD_IS_ADMIN = XMLHelper.getValue(node.OuterXml, "MD_IS_ADMIN", false);
                    material.MD_IS_CHARGE = XMLHelper.getValue(node.OuterXml, "MD_IS_CHARGE", false);
                    material.MD_MATERIAL_EXT1 = XMLHelper.getValue(node.OuterXml, "MD_MATERIAL_EXT1", false);
                    material.MD_MATERIAL_EXT2 = XMLHelper.getValue(node.OuterXml, "MD_MATERIAL_EXT2", false);
                    material.MD_MATERIAL_EXT3 = XMLHelper.getValue(node.OuterXml, "MD_MATERIAL_EXT3", false);
                    material.MD_MATERIAL_NAME = XMLHelper.getValue(node.OuterXml, "MD_MATERIAL_NAME", false);
                    material.MD_MATERIAL_UNIT = XMLHelper.getValue(node.OuterXml, "MD_MATERIAL_UNIT", false);
                    material.MD_OPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_OPER_CODE", false);
                    material.MD_OPER_NAME = XMLHelper.getValue(node.OuterXml, "MD_OPER_NAME", false);
                    material.MD_PRODUCER_INFO = XMLHelper.getValue(node.OuterXml, "MD_PRODUCER_INFO", false);
                    material.MD_SPECIFICATION = XMLHelper.getValue(node.OuterXml, "MD_SPECIFICATION", false);
                    material.MD_VALID_STATE = XMLHelper.getValue(node.OuterXml, "MD_VALID_STATE", false);

                    int id = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_MATERIAL_ID", false), out id))
                    {
                        material.MD_MATERIAL_ID = id;
                    }

                    Double price = 0;
                    if (double.TryParse(XMLHelper.getValue(node.OuterXml, "MD_UNIT_PRICE", false), out price))
                    {
                        material.MD_UNIT_PRICE = price;
                    }
                    DateTime opTime = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_OPER_TIME", false), out opTime))
                    {
                        material.MD_OPER_TIME = opTime;
                    }
                    list.Add(material);
                }
            }
            return list;
        }

        /// <summary>
        /// 解析供应商（PROVIDER）
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回供应商列表</returns>
        public static List<PROVIDER> InitProvider(string xml)
        {
            List<PROVIDER> list = new List<PROVIDER>();
            var providerNodeList = XMLHelper.selectNodeList(xml, "MSG/ROW");  //selectNodeList  getNodeList
            if (providerNodeList.Count > 0)
            {
                foreach (XmlNode node in providerNodeList)
                {
                    var provider = new PROVIDER();
                    provider.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);
                    provider.MD_OPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_OPER_CODE", false);
                    provider.MD_OPER_NAME = XMLHelper.getValue(node.OuterXml, "MD_OPER_NAME", false);
                    provider.MD_PRO_ADDR = XMLHelper.getValue(node.OuterXml, "MD_PRO_ADDR", false);
                    provider.MD_PRO_CONTACT = XMLHelper.getValue(node.OuterXml, "MD_PRO_CONTACT", false);
                    provider.MD_PRO_EXT1 = XMLHelper.getValue(node.OuterXml, "MD_PRO_EXT1", false);
                    provider.MD_PRO_EXT2 = XMLHelper.getValue(node.OuterXml, "MD_PRO_EXT2", false);
                    provider.MD_PRO_EXT3 = XMLHelper.getValue(node.OuterXml, "MD_PRO_EXT3", false);
                    provider.MD_PRO_NAME = XMLHelper.getValue(node.OuterXml, "MD_PRO_NAME", false);
                    provider.MD_PRO_TELE = XMLHelper.getValue(node.OuterXml, "MD_PRO_TELE", false);

                    int id = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_PRO_ID", false), out id))
                    {
                        provider.MD_PRO_ID = id;
                    }

                    int stoped = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_IS_STOP", false), out stoped))
                    {
                        provider.MD_IS_STOP = stoped;
                    }
                    DateTime opTime = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_OPER_TIME", false), out opTime))
                    {
                        provider.MD_OPER_TIME = opTime;
                    }
                    list.Add(provider);
                }
            }
            return list;
        }

        /// <summary>
        /// 解析生产厂家（manufactorer）
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回生产厂家列表</returns>
        public static List<MANUFACTORER> InitManufactorer(string xml)
        {
            List<MANUFACTORER> list = new List<MANUFACTORER>();
            var manufactorerNodeList = XMLHelper.selectNodeList(xml, "MSG/ROW");  //selectNodeList  getNodeList
            if (manufactorerNodeList.Count > 0)
            {
                foreach (XmlNode node in manufactorerNodeList)
                {
                    var manufactorer = new MANUFACTORER();
                    manufactorer.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);
                    manufactorer.MD_MANU_ADDR = XMLHelper.getValue(node.OuterXml, "MD_MANU_ADDR", false);
                    manufactorer.MD_MANU_CONTACT = XMLHelper.getValue(node.OuterXml, "MD_MANU_CONTACT", false);
                    manufactorer.MD_MANU_EXT1 = XMLHelper.getValue(node.OuterXml, "MD_MANU_EXT1", false);
                    manufactorer.MD_MANU_EXT2 = XMLHelper.getValue(node.OuterXml, "MD_MANU_EXT2", false);
                    manufactorer.MD_MANU_EXT3 = XMLHelper.getValue(node.OuterXml, "MD_MANU_EXT3", false);
                    manufactorer.MD_MANU_NAME = XMLHelper.getValue(node.OuterXml, "MD_MANU_NAME", false);
                    manufactorer.MD_MANU_TELEPHONE = XMLHelper.getValue(node.OuterXml, "MD_MANU_TELEPHONE", false);
                    manufactorer.MD_OPER_CODE = XMLHelper.getValue(node.OuterXml, "MD_OPER_CODE", false);
                    manufactorer.MD_OPER_NAME = XMLHelper.getValue(node.OuterXml, "MD_OPER_NAME", false);

                    int id = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_MANU_ID", false), out id))
                    {
                        manufactorer.MD_MANU_ID = id;
                    }

                    int stoped = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "MD_IS_STOP", false), out stoped))
                    {
                        manufactorer.MD_IS_STOP = stoped;
                    }
                    DateTime opTime = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "MD_OPER_TIME", false), out opTime))
                    {
                        manufactorer.MD_OPER_TIME = opTime;
                    }
                    list.Add(manufactorer);
                }
            }
            return list;
        }

        /// <summary>
        /// 解析处方请求信息
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <returns>返回处方请求信息</returns>
        public static HFS_REQUESTDATA InitHFSRequestData(string xml)
        {
            HFS_REQUESTDATA request = new HFS_REQUESTDATA();

            request.OPIP = XMLHelper.getValue(xml, "ROOT/OPIP");
            request.OPMANNAME = XMLHelper.getValue(xml, "ROOT/OPMANNAME");
            request.OPMANNO = XMLHelper.getValue(xml, "ROOT/OPMANNO");
            request.OPSYSTEM = XMLHelper.getValue(xml, "ROOT/OPSYSTEM");
            request.OPTYPE = XMLHelper.getValue(xml, "ROOT/OPTYPE");
            request.OPWINID = XMLHelper.getValue(xml, "ROOT/OPWINID");
            request.PRESCRIPTION_MASTERS = new List<PRESCRIPTION_MASTER>();

            var userNodeList = XMLHelper.selectNodeList(xml, "ROOT/IPACK_BASIC_PRESCRIPTION_MASTER");  //selectNodeList  getNodeList
            if (userNodeList.Count > 0)
            {
                foreach (XmlNode node in userNodeList)
                {
                    var master = new PRESCRIPTION_MASTER();
                    master.bedno = XMLHelper.getValue(node.OuterXml, "bedno",false);
                    DateTime birthDay = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "BirthDay", false), out birthDay))
                    {
                        master.BirthDay = birthDay;
                    }
                    master.Deliver_No = XMLHelper.getValue(node.OuterXml, "Deliver_No", false);
                    master.DeptCode = XMLHelper.getValue(node.OuterXml, "DeptCode", false);
                    master.DeptName = XMLHelper.getValue(node.OuterXml, "DeptName", false);
                    master.Details = new List<PRESCRIPTION_DETAIL>();
                    master.DoctorName = XMLHelper.getValue(node.OuterXml, "DoctorName", false);
                    master.InpNo = XMLHelper.getValue(node.OuterXml, "InpNo", false);

                    int isPay = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "IsPay", false), out isPay))
                    {
                        master.IsPay = isPay;
                    }
                    master.OutpNo = XMLHelper.getValue(node.OuterXml, "OutpNo", false);
                    master.PatientID = XMLHelper.getValue(node.OuterXml, "PatientID", false);
                    master.PatientName = XMLHelper.getValue(node.OuterXml, "PatientName", false);

                    DateTime payDate = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "PayDate", false), out payDate))
                    {
                        master.PayDate = payDate;
                    }

                    int prescriptionAttribute = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "PrescriptionAttribute", false),out prescriptionAttribute))
                    {
                        master.PrescriptionAttribute = prescriptionAttribute;
                    }
                    
                    master.PrescriptionID = XMLHelper.getValue(node.OuterXml, "PrescriptionID", false);
                    master.PrescriptionNo = XMLHelper.getValue(node.OuterXml, "PrescriptionNo", false);

                    int prescriptionSource = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "PrescriptionSource", false), out prescriptionSource))
                    {
                        master.PrescriptionSource = prescriptionSource;
                    }

                    master.RecriptNO = XMLHelper.getValue(node.OuterXml, "RecriptNO", false);

                    int sex = 0;
                    if (int.TryParse(XMLHelper.getValue(node.OuterXml, "Sex", false), out sex))
                    {
                        master.Sex = sex;
                    }

                    DateTime usage = new DateTime();
                    if (DateTime.TryParse(XMLHelper.getValue(node.OuterXml, "usage", false), out usage))
                    {
                        master.usage = usage;
                    }
                    master.ward = XMLHelper.getValue(node.OuterXml, "ward", false);
                    master.wardcode = XMLHelper.getValue(node.OuterXml, "wardcode", false);
                    master.DOEVENT = XMLHelper.getValue(node.OuterXml, "DOEVENT", false);

                    var detailNOdeList = XMLHelper.selectNodeList(node.OuterXml, "IPACK_BASIC_PRESCRIPTION_MASTER/DETALS/IPACK_BASIC_PRESCRIPTION_DETAIL");  //selectNodeList  getNodeList
                    if (detailNOdeList.Count > 0)
                    {
                        foreach (XmlNode nodeDetail in detailNOdeList)
                        {
                            var detail = new PRESCRIPTION_DETAIL();
                            detail.Batch = XMLHelper.getValue(nodeDetail.OuterXml, "Batch", false);
                            detail.BatchNo = XMLHelper.getValue(nodeDetail.OuterXml, "BatchNo", false);
                            double dose = 0;
                            if (double.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "Dose", false), out dose))
                            {
                                detail.Dose = dose;
                            }


                            int doseUnit = 0;
                            if (int.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "DoseUnit", false), out doseUnit))
                            {
                                detail.DoseUnit = doseUnit;
                            }


                            DateTime expirationDate;
                            if (DateTime.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "ExpirationDate", false), out expirationDate))
                            {
                                detail.ExpirationDate = expirationDate;
                            }
                            else
                            {
                                detail.ExpirationDate = null;
                            }

                            detail.Frequency = XMLHelper.getValue(nodeDetail.OuterXml, "Frequency", false);
                            detail.MediCode = XMLHelper.getValue(nodeDetail.OuterXml, "MediCode", false);
                            detail.MediNo = XMLHelper.getValue(nodeDetail.OuterXml, "MediNo", false);
                            detail.OriginPlace = XMLHelper.getValue(nodeDetail.OuterXml, "OriginPlace", false);
                            int package = 0;
                            if (int.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "Package", false), out package))
                            {
                                detail.Package = package;
                            }
                            detail.PrescriptionID = XMLHelper.getValue(nodeDetail.OuterXml, "PrescriptionID", false);
                            detail.PresDetailID = XMLHelper.getValue(nodeDetail.OuterXml, "PresDetailID", false);

                            double quantity = 0;
                            if (double.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "Quantity", false), out quantity))
                            {
                                detail.Quantity = quantity;
                            }

                            double retailCost = 0;
                            if (double.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "RetailCost", false), out retailCost))
                            {
                                detail.RetailCost = retailCost;
                            }

                            double retailPrice = 0;
                            if (double.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "RetailPrice", false), out retailPrice))
                            {
                                detail.RetailPrice = retailPrice;
                            }

                            int sendStatus = 0;
                            if (int.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "SendStatus", false), out sendStatus))
                            {
                                detail.SendStatus = sendStatus;
                            }

                            detail.StoreRoom = XMLHelper.getValue(nodeDetail.OuterXml, "StoreRoom", false);

                            double tradeCost = 0;
                            if (double.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "TradeCost", false), out tradeCost))
                            {
                                detail.TradeCost = tradeCost;
                            }

                            double tradePrice = 0;
                            if (double.TryParse(XMLHelper.getValue(nodeDetail.OuterXml, "TradePrice", false), out tradePrice))
                            {
                                detail.TradePrice = tradePrice;
                            }
                            detail.Unit = XMLHelper.getValue(nodeDetail.OuterXml, "Unit", false);
                            detail.Usage = XMLHelper.getValue(nodeDetail.OuterXml, "Usage", false);
                            detail.DOEVENT = XMLHelper.getValue(nodeDetail.OuterXml, "DOEVENT", false);
                            master.Details.Add(detail);
                        }
                    }
                    request.PRESCRIPTION_MASTERS.Add(master);
                }
            }

            return request;
        }

        #endregion

        #endregion
    }
}
