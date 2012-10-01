using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

/// <summary>
/// Summary description for WhitfieldPayroll
/// </summary>
public class WhitfieldPayroll
{
	public WhitfieldPayroll()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetPayRollHoursForEmployee(String FromDate,String ToDate)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  distinct  " +
                                " b.loginid,usr.firstName + ' ' + lastName UName,  " +
                                " sum(Convert(float,b.fab_hours)) as fab_hours, " +
                                " sum(Convert(float,b.fin_hours)) as fin_hours , " +
                                " sum(Convert(float,b.eng_hours)) as eng_hours, " +
                                " sum(Convert(float,b.misc_hours)) as misc_hours , " +
                                " sum(Convert(float,b.fab_hours)) + sum(Convert(float,b.fin_hours)) + sum(Convert(float,b.eng_hours)) + sum(Convert(float,b.misc_hours)) as TotHours ," +
                                 " isNull((Convert(float, replace(usr.hourly_rate,'$','')) *  sum(Convert(float,b.fab_hours)) + sum(Convert(float,b.fin_hours)) + sum(Convert(float,b.eng_hours)) + sum(Convert(float,b.misc_hours))),0) as pWO " +
                                "  FROM  " +
                                " twc_daily_prod_activity b INNER JOIN twc_daily_prod_report a on a.twc_report_number = b.twc_report_number  INNER JOIN [user] usr on b.loginid = usr.loginID " +
                                " WHERE len(b.loginid) > 0 AND " +
                                " CONVERT(datetime ,a.rpt_date)  >= @FromDate and CONVERT(datetime ,a.rpt_date) <= @ToDate  " +
                                "  GROUP BY  b.loginid ,usr.FirstName + ' ' + usr.LastName,usr.hourly_rate";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, Convert.ToDateTime(FromDate));
            db.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, Convert.ToDateTime(ToDate));
            DataSet IDataset = db.ExecuteDataSet(dbCommand);
            return IDataset;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }


    public DataSet GetPayRollProjectHoursForEmployee(String loginid,String FromDate, String ToDate)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  distinct " +
                                " c.EstNum,c.ProjName, " +
                                " sum(Convert(float,b.fab_hours)) as fab_hours, " +
                                " sum(Convert(float,b.fin_hours)) as fin_hours , " +
                                " sum(Convert(float,b.eng_hours)) as eng_hours, " +
                                " sum(Convert(float,b.misc_hours)) as misc_hours , " +
                                " sum(Convert(float,b.fab_hours)) + sum(Convert(float,b.fin_hours)) + sum(Convert(float,b.eng_hours)) + sum(Convert(float,b.misc_hours)) as TotHours " +
                                "  FROM  " +
                                " twc_daily_prod_activity b INNER JOIN twc_daily_prod_report a on a.twc_report_number = b.twc_report_number  " +
                                " INNER JOIN whitfield_ProjectInfo c on b.Project_Number = c.EstNum " +
                                " WHERE len(b.loginid) > 0 AND b.loginid = @loginid AND  " +
                                " CONVERT(datetime ,a.rpt_date)  >= @FromDate and CONVERT(datetime ,a.rpt_date) <= @ToDate " +
                                " GROUP BY c.EstNum,c.ProjName";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
            db.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, Convert.ToDateTime(FromDate));
            db.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, Convert.ToDateTime(ToDate));
            DataSet IDataset = db.ExecuteDataSet(dbCommand);
            return IDataset;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }


    public DataSet GetPayRollHoursForProjects(String FromDate, String ToDate)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  distinct " +
                                " c.EstNum, c.ProjName, " +
                                " sum(Convert(float,b.fab_hours)) as fab_hours," +
                                " sum(Convert(float,b.fin_hours)) as fin_hours ," +
                                " sum(Convert(float,b.eng_hours)) as eng_hours," +
                                " sum(Convert(float,b.misc_hours)) as misc_hours ," +
                                " sum(Convert(float,b.fab_hours)) + sum(Convert(float,b.fin_hours)) + sum(Convert(float,b.eng_hours)) + sum(Convert(float,b.misc_hours)) as TotHours" +
                                " FROM " +
                                " twc_daily_prod_activity b INNER JOIN twc_daily_prod_report a on a.twc_report_number = b.twc_report_number " +
                                " INNER JOIN whitfield_ProjectInfo c on b.Project_Number = c.EstNum" +
                                " WHERE " +
                                "  CONVERT(datetime ,a.rpt_date)  >= @FromDate and CONVERT(datetime ,a.rpt_date) <= @ToDate  " +
                                " GROUP BY c.EstNum,c.ProjName";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, Convert.ToDateTime(FromDate));
            db.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, Convert.ToDateTime(ToDate));
            DataSet IDataset = db.ExecuteDataSet(dbCommand);
            return IDataset;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }

    public DataSet GetPayRollEmployeeHoursForProject(Int32 EstNum, String FromDate, String ToDate)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  distinct " +
                                 "     b.loginid,usr.firstName + ' ' + lastName UName,   " +
                                 "     sum(Convert(float,b.fab_hours)) as fab_hours, " +
                                  "    sum(Convert(float,b.fin_hours)) as fin_hours , " +
                                 "     sum(Convert(float,b.eng_hours)) as eng_hours, " +
                                  "    sum(Convert(float,b.misc_hours)) as misc_hours , " +
                                  "    sum(Convert(float,b.fab_hours)) + sum(Convert(float,b.fin_hours)) + sum(Convert(float,b.eng_hours)) + sum(Convert(float,b.misc_hours)) as TotHours, " +
                                  "    isNull((Convert(float, replace(usr.hourly_rate,'$','')) *  sum(Convert(float,b.fab_hours)) + sum(Convert(float,b.fin_hours)) + sum(Convert(float,b.eng_hours)) + sum(Convert(float,b.misc_hours))),0) as pWO " +
                                  "     FROM  " +
                                  "    twc_daily_prod_activity b INNER JOIN twc_daily_prod_report a on a.twc_report_number = b.twc_report_number INNER JOIN [user] usr on b.loginid = usr.loginID " +
                                   "   INNER JOIN whitfield_ProjectInfo c on b.Project_Number = c.EstNum " +
                                   "   WHERE b.Project_number  = @EstNum AND " +
                                   "   CONVERT(datetime ,a.rpt_date)  >= @FromDate and CONVERT(datetime ,a.rpt_date) <= @ToDate " +
                                   "  GROUP BY  b.loginid ,usr.FirstName + ' ' + usr.LastName,usr.hourly_rate";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, Convert.ToDateTime(FromDate));
            db.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, Convert.ToDateTime(ToDate));
            DataSet IDataset = db.ExecuteDataSet(dbCommand);
            return IDataset;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }



}
