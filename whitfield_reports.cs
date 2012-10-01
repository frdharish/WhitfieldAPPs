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
/// Summary description for whitfield_reports
/// </summary>
public class whitfield_reports
{
	public whitfield_reports()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //*****************************************************************************************//
    //********************************  Report Methods ***************************************//
    //*****************************************************************************************//
    public Boolean IsManpowerExists(Int32 empl_type_id, Int32 RptNumber)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from twc_daily_manpower_entries  Where  twc_report_number=@RptNumber  AND empl_type_id=@empl_type_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            //db.AddInParameter(dbCommand, "@LoginId", DbType.String, LoginId);
            db.AddInParameter(dbCommand, "@empl_type_id", DbType.Int32, empl_type_id);
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


    public Boolean IsReportActivityExists(String work_order_id,Int32 RptNumber)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from twc_daily_field_activity  Where  twc_report_number=@RptNumber  AND work_order_id=@work_order_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            //db.AddInParameter(dbCommand, "@LoginId", DbType.String, LoginId);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
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
            String sqlCommand = " DELETE twc_daily_field_activity WHERE activity_id = @_activityid";
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

    public void DeleteManPowerEntries(String manPowerid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE twc_daily_manpower_entries WHERE manhour_id = @manPowerid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@manPowerid", DbType.String, Convert.ToString(manPowerid));
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public Boolean IsReportExists(Int32 twc_project_number, String rpt_date)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from twc_daily_field_report  Where  twc_proj_number = @twc_project_number AND rpt_date=@rpt_date";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, twc_project_number);
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

    public Boolean ManageReportMain(
                                        String rpt_date
                                        , Int32 twc_project_number
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
            if (!IsReportExists(twc_project_number, rpt_date))
            {
                sqlCommand = " INSERT INTO twc_daily_field_report ( " +
                                "            twc_proj_number  " +
                                "            ,rpt_date   " +
                                "            ,Daily_notes  " +
                                "            ,Daily_comments  " +
                                "            ,Change_order_notes  " +
                                "            ,is_locked)  " +
                                "            VALUES (@twc_project_number" +
                                "            ,@rpt_date   " +
                                "            ,@Daily_notes  " +
                                "            ,@Daily_comments  " +
                                "            ,@Change_order_notes  " +
                                "            ,@is_locked) ";

            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE twc_daily_field_report SET " +
                        "   [Daily_notes]           =   @Daily_notes  " +
                        "  ,[Daily_comments]        =  @Daily_comments " +
                        "  ,[Change_order_notes]    =  @Change_order_notes " +
                        "  ,[is_locked]             =    @is_locked " +
                        "   WHERE twc_proj_number = @twc_project_number AND rpt_date = @rpt_date ";
            }

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, twc_project_number);
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
                                , Int32 install_hours
                                , String empl_comments
                           )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
                sqlCommand =    " UPDATE twc_daily_field_activity SET " +
                                "  [install_hours]    =  @install_hours " +
                                "  ,[empl_comments]    =  @empl_comments " +
                                "   WHERE activity_id = @ActivityId ";
            
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ActivityId", DbType.Int32, Convert.ToInt32(ActivityId));
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, install_hours);
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

    public Boolean UpdateManPowerActivity(
                                  Int32 manpowerid
                                , Int32 install_hours
                                , Int32 Qty
                          )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = " UPDATE twc_daily_manpower_entries SET " +
                            "  [install_hours]    =  @install_hours " +
                            "  ,[qty]    =  @qty " +
                            "   WHERE manhour_id = @manpowerid ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@manpowerid", DbType.Int32, Convert.ToInt32(manpowerid));
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, install_hours);
            db.AddInParameter(dbCommand, "@qty", DbType.String, Qty);
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
                                    , String Project_Number
                                    , String  work_order_id
                                    , Int32 install_hours
                                    , String empl_comments
                               )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsReportActivityExists(work_order_id,twc_report_number))
            {
                sqlCommand = " INSERT INTO twc_daily_field_activity ( " +
                                "            twc_report_number  " +
                                "            ,Project_Number   " +
                                "            ,work_order_id  " +
                                "            ,install_hours  " +
                                "            ,empl_comments)  " +
                                "            VALUES (@twc_report_number" +
                                "            ,@Project_Number   " +
                                "            ,@work_order_id  " +
                                "            ,@install_hours  " +
                                "            ,@empl_comments) ";

            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand =    " UPDATE twc_daily_field_activity SET " +
                                "  [install_hours]    =  @install_hours " +
                                "  ,[empl_comments]    =  @empl_comments " +
                                "   WHERE twc_report_number = @twc_report_number AND work_order_id = @work_order_id ";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, Convert.ToInt32(twc_report_number));
            db.AddInParameter(dbCommand, "@Project_Number", DbType.Int32, Project_Number);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, install_hours);
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

    public Boolean ManageManpower(
                                Int32 twc_report_number
                                , Int32 empl_type_id
                                , Int32 install_hours
                                , Int32 Qty
                           )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsManpowerExists(empl_type_id, twc_report_number))
            {
                sqlCommand = " INSERT INTO twc_daily_manpower_entries ( " +
                                "            twc_report_number  " +
                                "            ,empl_type_id  " +
                                "            ,install_hours  " +
                                "            ,qty)  " +
                                "            VALUES (@twc_report_number" +
                                "            ,@empl_type_id  " +
                                "            ,@install_hours  " +
                                "            ,@Qty) ";

            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE twc_daily_manpower_entries SET " +
                                "  [install_hours]    =  @install_hours " +
                                "  ,[qty]    =  @qty " +
                                "   WHERE twc_report_number = @twc_report_number AND empl_type_id = @empl_type_id ";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, Convert.ToInt32(twc_report_number));
            db.AddInParameter(dbCommand, "@empl_type_id", DbType.Int32, empl_type_id);
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, install_hours);
            db.AddInParameter(dbCommand, "@qty", DbType.Int32, Qty);
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

    public DataSet GetReportActivityForProject(Int32 twc_report_number, Int32 twc_project_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*,b.Description,b.Description + '(' + b.work_order_id + ')' as WODesc  from twc_daily_field_activity a, whitfield_Project_workorder b  Where a.work_order_id = b.work_order_id AND b.TWC_proj_number=@twc_project_number AND  twc_report_number = @twc_report_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_report_number", DbType.Int32, twc_report_number);
            db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, twc_project_number);
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

    public DataSet GetFieldDailyReports(Int32 _projectNumber)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT a.rpt_date,a.twc_report_number,sum(b.install_hours) as install_hours FROM  " +
                                "    twc_daily_field_report a,twc_daily_field_activity b  " +
                                "    Where a.twc_report_number = b.twc_report_number AND a.twc_proj_number = @twc_project_number " +
                                "    GROUP BY a.rpt_date,a.twc_report_number" +
                                "    order by CONVERT(datetime ,a.rpt_date) desc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, _projectNumber);
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

    public DataSet GetManPowerEntries(Int32 twc_report_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*,b.empl_type_name,a.install_hours * a.qty as TotHours from twc_daily_manpower_entries a, list_empl_type b  Where a.empl_type_id = b.empl_type_id AND  twc_report_number = @twc_report_number";
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

    public String GetCurrentDate()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = "SELECT CONVERT(VARCHAR(10), GETDATE(), 101)  CurrentDate";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        object retVal = db.ExecuteScalar(dbCommand);
        return retVal.ToString();
    }

    public Int32 GetReportNumber(Int32 _projectNumber, String RptDate)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT twc_report_number from twc_daily_field_report Where twc_proj_number = @_projectNumber AND rpt_date = @RptDate";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@_projectNumber", DbType.Int32, _projectNumber);
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

    public DataSet GetReportForProject(Int32 _projectNumber,String RptDate)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from twc_daily_field_report Where twc_proj_number = @_projectNumber AND rpt_date = @RptDate";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@_projectNumber", DbType.Int32, _projectNumber);
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


    public DataSet GetBudgetHoursForWO(String EstNum, String Woid)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select a.install_hours as install_hours FROM Whitfield_Project_workorder a" +
        "  Where a.work_order_id = @woid AND a.EstNum= @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@Woid", DbType.String, Woid);
        db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

    public DataSet GetHoursTDForWO(String EstNum, String Woid)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select sum(a.install_hours) as install_hours FROM twc_daily_field_activity a, whitfield_project_workorder b WHERE  a.work_order_id = b.work_order_id  " +
        "  AND b.work_order_id = @woid AND b.EstNum= @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@Woid", DbType.String, Woid);
        db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

    public Int32 GetReportNumber(String RptDate)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT twc_report_number from twc_daily_field_report Where rpt_date = @RptDate";
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

    public DataSet GetCummulativeBudgetHoursForWO(String RptDate)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select sum(a.install_hours) as install_hours FROM Whitfield_Project_workorder a" +
        "  Where a.work_order_id IN (select work_order_id FROM twc_daily_field_activity Where  Project_Number = a.TWC_proj_number AND twc_report_number=" + GetReportNumber(RptDate) + ")";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@RptDate", DbType.String, RptDate);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }
    public DataSet GetCummulativeHoursTDForWO(String RptDate)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select sum(a.install_hours) as install_hours FROM twc_daily_field_activity a" +
        "  Where Project_number IN (select Project_number FROM twc_daily_field_activity Where twc_report_number=" + GetReportNumber(RptDate) + ")";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@RptDate", DbType.String, RptDate);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

}
