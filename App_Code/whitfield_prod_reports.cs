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
/// Summary description for whitfield_prod_reports
/// </summary>
public class whitfield_prod_reports
{
	public whitfield_prod_reports()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Boolean IsReportActivityExists(String Project_Number, String work_order_id, String LoginId, Int32 RptNumber)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from twc_daily_prod_activity  Where  twc_report_number=@RptNumber AND loginID=@LoginId  AND work_order_id=@work_order_id AND Project_Number=@Project_Number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@LoginId", DbType.String, LoginId);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
            db.AddInParameter(dbCommand, "@Project_Number", DbType.String, Project_Number);
            db.AddInParameter(dbCommand, "@RptNumber", DbType.Int32, RptNumber);
            object retVal = db.ExecuteScalar(dbCommand);
            if (Convert.ToInt32(retVal.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public void DeleteProjectActivity(String _activityid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE twc_daily_prod_activity WHERE activity_id = @_activityid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@_activityid", DbType.String, _activityid);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    public Boolean IsReportExists(String rpt_date)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from twc_daily_prod_report  Where  rpt_date=@rpt_date";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            //db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, twc_project_number);
            db.AddInParameter(dbCommand, "@rpt_date", DbType.String, rpt_date);
            object retVal = db.ExecuteScalar(dbCommand);
            if (Convert.ToInt32(retVal.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public DataSet GetProductionDailyReports()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT a.rpt_date,a.twc_report_number,sum(Convert(float,b.fab_hours)) as fab_hours,sum(Convert(float,b.fin_hours)) as fin_hours ,sum(Convert(float,b.eng_hours)) as eng_hours,sum(Convert(float,b.misc_hours)) as misc_hours ,sum(Convert(float,b.fab_hours)) + sum(Convert(float,b.fin_hours)) + sum(Convert(float,b.eng_hours)) + sum(Convert(float,b.misc_hours)) as TotHours FROM  " +
                                "    twc_daily_prod_report a,twc_daily_prod_activity b  " +
                                "    Where a.twc_report_number = b.twc_report_number " +
                                "    GROUP BY a.rpt_date,a.twc_report_number" +
                                "    order by CONVERT(datetime ,a.rpt_date) desc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
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

    public Boolean ManageReportMain(
                                        String rpt_date
                                        , String Daily_notes
                                        , String Daily_comments
                                        , String Change_order_notes
                                        , String is_locked
                                   )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsReportExists(rpt_date))
            {
                sqlCommand = " INSERT INTO twc_daily_prod_report ( " +
                                "            rpt_date   " +
                                "            ,Daily_notes  " +
                                "            ,Daily_comments  " +
                                "            ,Change_order_notes  " +
                                "            ,is_locked)  " +
                                "            VALUES (" +
                                "            @rpt_date   " +
                                "            ,@Daily_notes  " +
                                "            ,@Daily_comments  " +
                                "            ,@Change_order_notes  " +
                                "            ,@is_locked) ";

            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE twc_daily_prod_report SET " +
                        "   [Daily_notes]           =   @Daily_notes  " +
                        "  ,[Daily_comments]        =  @Daily_comments " +
                        "  ,[Change_order_notes]    =  @Change_order_notes " +
                        "  ,[is_locked]             =    @is_locked " +
                        "   WHERE rpt_date = @rpt_date ";
            }

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            //db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, twc_project_number);
            db.AddInParameter(dbCommand, "@rpt_date", DbType.String, rpt_date);
            db.AddInParameter(dbCommand, "@Daily_notes", DbType.String, Daily_notes);
            db.AddInParameter(dbCommand, "@Daily_comments", DbType.String, Daily_comments);
            db.AddInParameter(dbCommand, "@Change_order_notes", DbType.String, Change_order_notes);
            db.AddInParameter(dbCommand, "@is_locked", DbType.String, is_locked);
            db.ExecuteNonQuery(dbCommand);
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public Boolean UpdateReportActivity(
                                Int32 ActivityId
                                , String fab_hours, String fin_hours, String eng_hours, String misc_hours
                                , String empl_comments
                           )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand =    " UPDATE twc_daily_prod_activity SET " +
                            "  fab_hours    =  @fab_hours, fin_hours = @fin_hours, eng_hours=@eng_hours, misc_hours = @misc_hours " +
                            "  ,[empl_comments]    =  @empl_comments " +
                            "   WHERE activity_id = @ActivityId ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ActivityId", DbType.Int32, Convert.ToInt32(ActivityId));
            db.AddInParameter(dbCommand, "@fab_hours", DbType.String, fab_hours.ToString());
            db.AddInParameter(dbCommand, "@fin_hours", DbType.String, fin_hours.ToString());
            db.AddInParameter(dbCommand, "@eng_hours", DbType.String, eng_hours.ToString());
            db.AddInParameter(dbCommand, "@misc_hours", DbType.String, misc_hours.ToString());
            db.AddInParameter(dbCommand, "@empl_comments", DbType.String, empl_comments);
            db.ExecuteNonQuery(dbCommand);
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }
    public Boolean ManageReportActivityMain(
                                       Int32 twc_report_number
                                       , String LoginId
                                       , String Project_Number
                                       , String work_order_id
                                       , String fab_hours, String fin_hours, String eng_hours, String misc_hours
                                       , String empl_comments
                                  )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsReportActivityExists(Project_Number,work_order_id, LoginId, twc_report_number))
            {
                sqlCommand = " INSERT INTO twc_daily_prod_activity ( " +
                                "            twc_report_number  " +
                                "            ,LoginId ,Project_Number  " +
                                "            ,work_order_id  " +
                                "            ,fab_hours,fin_hours,eng_hours,misc_hours  " +
                                "            ,empl_comments)  " +
                                "            VALUES (@twc_report_number" +
                                "            ,@LoginId ,@Project_Number  " +
                                "            ,@work_order_id  " +
                                "            ,@fab_hours,@fin_hours,@eng_hours,@misc_hours " +
                                "            ,@empl_comments) ";

            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE twc_daily_prod_activity SET " +
                                "  fab_hours    =  @fab_hours, fin_hours = @fin_hours, eng_hours=@eng_hours, misc_hours = @misc_hours " +
                                "  ,[empl_comments]    =  @empl_comments " +
                                "   WHERE twc_report_number = @twc_report_number AND Project_Number=@Project_Number AND work_order_id = @work_order_id AND loginID = @loginId ";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, Convert.ToInt32(twc_report_number));
            db.AddInParameter(dbCommand, "@LoginId", DbType.String, LoginId);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
            db.AddInParameter(dbCommand, "@Project_Number", DbType.String, Project_Number);
            db.AddInParameter(dbCommand, "@fab_hours", DbType.String, fab_hours.ToString());
            db.AddInParameter(dbCommand, "@fin_hours", DbType.String, fin_hours.ToString());
            db.AddInParameter(dbCommand, "@eng_hours", DbType.String, eng_hours.ToString());
            db.AddInParameter(dbCommand, "@misc_hours", DbType.String, misc_hours.ToString());
            db.AddInParameter(dbCommand, "@empl_comments", DbType.String, empl_comments);
            db.ExecuteNonQuery(dbCommand);
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public DataSet GetReportActivityForProject(Int32 twc_report_number)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT     a.activity_id,a.twc_report_number  " +
                                "            ,a.LoginId ,a.Project_Number  " +
                                "            ,a.work_order_id  " +
                                "            ,Convert(float,a.fab_hours) fab_hours,Convert(float,a.fin_hours) fin_hours,Convert(float,a.eng_hours) eng_hours,Convert(float,a.misc_hours) misc_hours " +
                                "            ,a.empl_comments ," + 
                                "            b.work_order_id + ' - ' + b.Description  as Description,c.ProjName,u.FirstName + ' ' + u.LastName as UName from twc_daily_prod_activity a, whitfield_Project_workorder b,Whitfield_ProjectInfo c  , [User] u  Where a.work_order_id = b.work_order_id AND b.EstNum = c.EstNum AND  twc_report_number = @twc_report_number  AND a.Loginid = u.LoginID AND a.Project_Number = c.EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, twc_report_number);
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

    public DataSet GetReportActivityForProjectForEmail(Int32 twc_report_number)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT    " +
                                "  c.ProjName as [Project Name],b.work_order_id + ' - ' + b.Description  as [Work Order Description],a.empl_comments [Work Completed]  " +
                                " ,Convert(float,a.fab_hours) Fab,Convert(float,a.fin_hours) Fin,Convert(float,a.eng_hours) Eng,Convert(float,a.misc_hours) Misc " +
                                " ,u.FirstName + ' ' + u.LastName as [Employee] from twc_daily_prod_activity a, whitfield_Project_workorder b,Whitfield_ProjectInfo c  , [User] u  Where a.work_order_id = b.work_order_id AND b.EstNum = c.EstNum AND  twc_report_number = @twc_report_number  AND a.Loginid = u.LoginID AND a.Project_Number = c.EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, twc_report_number);
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

     public DataSet GetProjectReportOuter(String RptDate)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT   distinct  " +
                                "         d.twc_report_number,  " +
                                "         c.TWC_Proj_Number, " +
                                "         c.ProjName FROM" +
                                "         twc_daily_prod_activity a," +
                                "         whitfield_Project_workorder b," +
                                "         Whitfield_ProjectInfo c  ," +
                                "         twc_daily_prod_report d" +
                                "         Where a.work_order_id = b.work_order_id AND " +
                                "         b.EstNum = c.EstNum AND " +
                                "         a.twc_report_number = d.twc_report_number AND" +
                                "         rpt_date = @rptdate";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@rptdate", DbType.String, RptDate);
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

     public DataSet GetBudgetHoursForWO(String EstNum, String Woid)
     {
         Database db = DatabaseFactory.CreateDatabase();
         String sqlCommand = " select Convert(float,a.fab_hours) as fab_hours, Convert(float,a.fin_hours) as fin_hours, Convert(float,a.eng_hours) as eng_hours, Convert(float,a.misc_hours) as misc_hours,Convert(float,a.fab_hours) + Convert(float,a.fin_hours) + Convert(float,a.eng_hours) + Convert(float,a.misc_hours) as TotHours FROM Whitfield_Project_workorder a" +
         "  Where work_order_id = @woid AND EstNum= @EstNum";
         DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
         db.AddInParameter(dbCommand, "@Woid", DbType.String, Woid);
         db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
         DataSet IDataset = db.ExecuteDataSet(dbCommand);
         return IDataset;
     }
     public DataSet GetHoursTDForWO(String EstNum, String Woid)
     {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select sum(Convert(float,a.fab_hours)) as fab_hours, sum(Convert(float,a.fin_hours)) as fin_hours, sum(Convert(float,a.eng_hours)) as eng_hours, sum(Convert(float,a.misc_hours)) as misc_hours,sum(Convert(float,a.fab_hours)) + sum(Convert(float,a.fin_hours)) + sum(Convert(float,a.eng_hours)) + sum(Convert(float,a.misc_hours)) as TotHours FROM twc_daily_prod_activity a, whitfield_project_workorder b WHERE  a.work_order_id = b.work_order_id and a.Project_number = b.EstNum " +
            "  AND b.work_order_id = @woid AND b.EstNum= @EstNum and a.Project_number = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@Woid", DbType.String, Woid);
            db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
            DataSet IDataset = db.ExecuteDataSet(dbCommand);
            return IDataset;
     }
     public DataSet GetCummulativeBudgetHoursForWO(String RptDate)
     {
         Database db = DatabaseFactory.CreateDatabase();
         String sqlCommand = " select sum(Convert(float,a.fab_hours)) as fab_hours, sum(Convert(float,a.fin_hours)) as fin_hours, sum(Convert(float,a.eng_hours)) as eng_hours, sum(Convert(float,a.misc_hours)) as misc_hours,sum(Convert(float,a.fab_hours)) + sum(Convert(float,a.fin_hours)) + sum(Convert(float,a.eng_hours)) + sum(Convert(float,a.misc_hours)) as TotHours FROM Whitfield_Project_workorder a" +
         "  Where a.work_order_id IN (select work_order_id FROM twc_daily_prod_activity Where  Project_number = a.EstNum AND twc_report_number=" + GetReportNumber(RptDate) + ")";
         DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
         db.AddInParameter(dbCommand, "@RptDate", DbType.String, RptDate);
         DataSet IDataset = db.ExecuteDataSet(dbCommand);
         return IDataset;
     }
     public DataSet GetCummulativeHoursTDForWO(String RptDate)
     {
         Database db = DatabaseFactory.CreateDatabase();
         String sqlCommand = " select sum(Convert(float,a.fab_hours)) as fab_hours, sum(Convert(float,a.fin_hours)) as fin_hours, sum(Convert(float,a.eng_hours)) as eng_hours, sum(Convert(float,a.misc_hours)) as misc_hours,sum(Convert(float,a.fab_hours)) + sum(Convert(float,a.fin_hours)) + sum(Convert(float,a.eng_hours)) + sum(Convert(float,a.misc_hours)) as TotHours FROM twc_daily_prod_activity a" +
         "  Where Project_number IN (select Project_number FROM twc_daily_prod_activity Where twc_report_number=" + GetReportNumber(RptDate) + ")";
         DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
         db.AddInParameter(dbCommand, "@RptDate", DbType.String, RptDate);
         DataSet IDataset = db.ExecuteDataSet(dbCommand);
         return IDataset;
     }
     public DataSet GetCummulativeHoursForToday(String RptDate)
     {
         Database db = DatabaseFactory.CreateDatabase();
         String sqlCommand = " select sum(Convert(float,a.fab_hours)) as fab_hours, sum(Convert(float,a.fin_hours)) as fin_hours, sum(Convert(float,a.eng_hours)) as eng_hours, sum(Convert(float,a.misc_hours)) as misc_hours,sum(Convert(float,a.fab_hours)) + sum(Convert(float,a.fin_hours)) + sum(Convert(float,a.eng_hours)) + sum(Convert(float,a.misc_hours)) as TotHours FROM twc_daily_prod_activity a" +
         "  Where twc_report_number=" + GetReportNumber(RptDate);
         DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
         db.AddInParameter(dbCommand, "@RptDate", DbType.String, RptDate);
         DataSet IDataset = db.ExecuteDataSet(dbCommand);
         return IDataset;
     }
     public DataSet GetEmployeeDailyHours(String RptDate)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase();
             String sqlCommand = " SELECT d.FirstName + ' ' + d.LastName as UName , sum(Convert(float,a.fab_hours)) as fab_hours, sum(Convert(float,a.fin_hours)) as fin_hours, sum(Convert(float,a.eng_hours)) as eng_hours, sum(Convert(float,a.misc_hours)) as misc_hours,sum(Convert(float,a.fab_hours)) + sum(Convert(float,a.fin_hours)) + sum(Convert(float,a.eng_hours)) + sum(Convert(float,a.misc_hours)) as TotHours " +
                                 "    FROM " +
                                 "   twc_daily_prod_activity a, whitfield_Project_workorder b,Whitfield_ProjectInfo c , [User] d,twc_daily_prod_report f " +
                                 "   Where a.twc_report_number = f.twc_report_number AND  a.work_order_id = b.work_order_id AND b.EstNum = c.EstNum  AND a.LoginId = d.LoginID AND a.Project_Number = c.EstNum" +
                                 "   AND  f.rpt_date = @rptdate " +
                                 "   GROUP BY d.FirstName + ' ' + d.LastName";

             DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
             db.AddInParameter(dbCommand, "@rptdate", DbType.String, RptDate);
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
     
     public DataSet GetProjectReportInner(Int32 twc_report_number,Int32 twc_proj_Number)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase();
             String sqlCommand = " SELECT     a.activity_id, a.twc_report_number  " +
                                "            ,a.LoginId ,a.Project_Number  " +
                                "            ,a.work_order_id  " +
                                "            ,Convert(float,a.fab_hours) fab_hours,Convert(float,a.fin_hours) fin_hours,Convert(float,a.eng_hours) eng_hours,Convert(float,a.misc_hours) misc_hours " +
                                "            ,a.empl_comments ," + 
                                 "  b.Description + '(' + b.work_order_id  + ')' as Description,c.ProjName,d.FirstName + ' ' + d.LastName as UName " +
                                 "   FROM " +
                                 "   twc_daily_prod_activity a, whitfield_Project_workorder b,Whitfield_ProjectInfo c , [User] d " +
                                 "   Where a.work_order_id = b.work_order_id AND b.EstNum = c.EstNum  AND a.LoginId = d.LoginID AND  twc_report_number = @twc_report_number AND c.TWC_Proj_Number = @TWC_Proj_Number ";
             
             DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
             db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, twc_report_number);
             db.AddInParameter(dbCommand, "@TWC_Proj_Number", DbType.Int32, twc_proj_Number);
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

    public String GetCurrentDate()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = "SELECT CONVERT(VARCHAR(10), GETDATE(), 101)  CurrentDate";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        object retVal = db.ExecuteScalar(dbCommand);
        return retVal.ToString();
    }

    public Int32 GetReportNumber(String RptDate)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT twc_report_number from twc_daily_prod_report Where rpt_date = @RptDate";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@RptDate", DbType.String, RptDate);
        object retVal = db.ExecuteScalar(dbCommand);
        if (retVal == null)
        {
            return 0;
        }
        else
        {
            return Convert.ToInt32(retVal.ToString());
        }
    }

    public DataSet GetReportForProject(String RptDate)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from twc_daily_prod_report Where rpt_date = @RptDate";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@RptDate", DbType.String, RptDate);
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

    public DataSet GetProjectReportData(String reportNumber)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from twc_daily_prod_report Where twc_report_number = @twc_report_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, Convert.ToInt32(reportNumber));
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


    public DataSet GetProductionScheduleForDates(String _month, String _fycd, string _week)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand =  " SELECT b.ProjName as [Project Name] " +
                                 " ,a.[Hours] [Hours] " +
                                 " ,a.[weeklyNotes] [Notes] " +
                                " FROM [whitfielddb].[dbo].[twc_project_productionschedule] a inner join whitfielddb.dbo.Whitfield_ProjectInfo  b " +
                                " on a.twc_proj_number = b.TWC_proj_number " +
                                " Where yearmonth = @yearmonth and week_number = @week_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@yearmonth", DbType.String, _month + '(' + _fycd + ')' );
            db.AddInParameter(dbCommand, "@week_number", DbType.String, _week);
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
