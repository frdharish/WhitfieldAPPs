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
using System.Collections;
/// <summary>
/// Summary description for Whitfieldcore
/// </summary>
public class Whitfieldcore
{
	public Whitfieldcore()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    // *******************************Qualifications******************************************

    public DataSet GetGeneralConditions()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from LU_Qualification Where qual_type_id = 1";
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

    public DataSet GetGeneralConditions(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*  from Project_Qualificaton a, LU_Qualification b Where a.qual_id = b.qual_id AND b.qual_type_id = 1 AND  EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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
    public DataSet GetMasterQualification(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select sub_qual_id,description  from whitfield_sub_qualifications   Where sub_qual_id not in (select qual_id FROM Project_Qualificaton Where EstNum = @EstNum) ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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
    public DataSet GetSpecExcl(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsQualificationxists(EstNum))
            {
                String insTerms = "INSERT INTO Project_Qualificaton select @EstNum,sub_qual_id from whitfield_sub_qualifications Where (is_default = 'Y' or is_default = 'YES')";
                DbCommand dbCommandInsert = db.GetSqlStringCommand(insTerms);
                db.AddInParameter(dbCommandInsert, "@EstNum", DbType.Int32, EstNum);
                db.ExecuteNonQuery(dbCommandInsert);
            }

            String sqlCommand = " select b.*,c.group_name as gName1  from Project_Qualificaton a INNER JOIN whitfield_sub_qualifications b ON a.qual_id = b.sub_qual_id INNER JOIN whitfield_master_qualifications c on b.qual_id = c.qual_id WHERE EstNum = @EstNum order by c.qual_id asc ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public void DeleteQualifications(Int32 EstNum, Int32 sub_qual_id)
    {
       try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_Qualificaton Where  EstNum = @EstNum and qual_id=@sub_qual_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_qual_id", DbType.Int32, sub_qual_id);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public DataSet GetSpecificExclusions()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from LU_Qualification Where qual_type_id = 2 ";
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

    //*****************************************************************************************
    // *******************************Considerations ******************************************

    public DataSet GetTerms()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from LU_Consideration Where Con_type_id = 1 ";
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

    public DataSet GetTerms(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsTermExists(EstNum))
            {
                String insTerms = "INSERT INTO Project_consideration select @EstNum,sub_terms_id from whitfield_sub_terms Where (is_default = 'Y' or is_default = 'YES')";
                DbCommand dbCommandInsert = db.GetSqlStringCommand(insTerms);
                db.AddInParameter(dbCommandInsert, "@EstNum", DbType.Int32, EstNum);
                db.ExecuteNonQuery(dbCommandInsert);
            }
            String sqlCommand = " select b.*,c.group_name  from Project_consideration a INNER JOIN whitfield_sub_terms b ON a.con_id = b.sub_terms_id INNER JOIN whitfield_master_terms c on b.terms_id = c.terms_id Where  EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public DataSet GetMasterTerms(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select sub_terms_id,description  from whitfield_sub_terms   Where sub_terms_id not in (select con_id FROM Project_consideration Where EstNum = @EstNum) ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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
    public void DeleteTerm(Int32 EstNum, Int32 sub_term_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_consideration Where  EstNum = @EstNum and con_id=@sub_term_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_term_id", DbType.Int32, sub_term_id);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    //Check For Terms

    public Boolean IsTermExists(Int32 EstNum)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from Project_consideration  Where  EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    //Check For Qualifications whitfield_sub_qualifications
    public Boolean IsQualificationxists(Int32 EstNum)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from Project_Qualificaton   Where  EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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


    #region PROJECT Contingency

    //Check For Contingency [Project_Contingency]    
    public Boolean IsContingencyxists(Int32 EstNum)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from [Project_Contingency] Where  EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public void DeleteContingencyRecord(Int32 EstNum, Int32 sub_contingency_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE [Project_Contingency] Where  EstNum = @EstNum and sub_contingency_id=@sub_contingency_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_contingency_id", DbType.Int32, sub_contingency_id);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public Boolean PopulateContingency(Int32 EstNum, Int32 ContingencyID)
    {

        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "INSERT INTO Project_Contingency select @EstNum,sub_contingency_id,cost,'1' from whitfield_sub_contingency Where sub_contingency_id = @ContingencyID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@ContingencyID", DbType.Int32, ContingencyID);
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

    public void UpdateContingencyRecord(Int32 EstNum, Int32 sub_contingency_id,String qty, String cost)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE [Project_Contingency] set cost=@cost, qty=@qty Where  EstNum = @EstNum and sub_contingency_id=@sub_contingency_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_contingency_id", DbType.Int32, sub_contingency_id);
            db.AddInParameter(dbCommand, "@cost", DbType.String, cost);
            db.AddInParameter(dbCommand, "@qty", DbType.String, qty);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public DataSet GetMasterContingencies(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select sub_contingency_id,description  from whitfield_sub_contingency   Where sub_contingency_id not in (select sub_contingency_id FROM Project_Contingency Where EstNum = @EstNum) ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public DataSet GetContingency(Int32 EstNum)
    {
        try
        {
            //[EstNum] [int] NOT NULL,
            //[sub_contingency_id] [int] NOT NULL,
            //[cost] [varchar](10) NOT NULL,
            //[qty] [varchar](10) NOT NULL
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsContingencyxists(EstNum))
            {
                String insTerms = "INSERT INTO Project_Contingency select @EstNum,sub_contingency_id,cost,'1' from whitfield_sub_contingency Where (is_default = 'Y' or is_default = 'YES')";
                DbCommand dbCommandInsert = db.GetSqlStringCommand(insTerms);
                db.AddInParameter(dbCommandInsert, "@EstNum", DbType.Int32, EstNum);
                db.ExecuteNonQuery(dbCommandInsert);
            }
            String sqlCommand = " select b.sub_contingency_id,replace(isnull(a.cost,0),'$','') as cost,a.qty, b.description,b.UOM,c.group_name  from Project_Contingency a INNER JOIN whitfield_sub_contingency b ON a.sub_contingency_id = b.sub_contingency_id INNER JOIN whitfield_master_contingency c on b.contingency_id = c.contingency_id Where  EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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
    #endregion 


    public DataSet GetIntTerms(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*  from Project_consideration a, LU_Consideration b Where a.con_id = b.con_id AND b.Con_type_id = 2 AND  EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public DataSet GetInternationalTerms()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from LU_Consideration Where Con_type_id = 2 ";
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

    //*****************************************************************************************
    public DataSet GetProjectTypes()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * from List_ProjType ";
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


    public DataSet GetListtitles()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * from List_Title ";
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
    

    //*****************************************************************************************//
    //******************************** PROJECT INFORMATION ************************************//
    //*****************************************************************************************//
    public DataSet GetEstimators()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.loginid ,a.FirstName + ' ' + a.LastName as estName from [User] a , UserRole b Where a.loginid = b.loginid and b.RoleId in (1,2,3)";
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

    public DataSet GetProjectStatus()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * from List_StatusType ";
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

    public DataSet GetProjectStatusWithFilter()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT * FROM List_StatusType WHERE StatID in (5,8) ";
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

    public DataSet GetBudgetHoursForEstimation(String EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select sum(a.install_hours) as install_hours, sum(a.fab_hours) as fab_hours, sum(a.fin_hours) as fin_hours, sum(a.eng_hours) as eng_hours, sum(a.misc_hours) as misc_hours,sum(a.fab_hours) + sum(a.fin_hours) + sum(a.eng_hours) + sum(a.misc_hours) as TotHours FROM Project_workorder a" +
        "  Where  EstNum= @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

    public String GetTotalFabricationHours(String TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();

        String sqlCommand = " SELECT  ISNULL(sum(isnull(a.fab_hours,0) + isnull(a.Fin_hours,0)),0) as fab_hours FROM whitfield_Project_workorder a" +
                            "  WHERE  a.TWC_proj_number= @TWC_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.String, TWC_proj_number);
        object retVal = db.ExecuteScalar(dbCommand);
        if (retVal == null)
        {
            return "0";
        }
        else
        {
            if (Convert.ToInt32(retVal.ToString()) > 0)
            {
                return retVal.ToString();
            }
            else
            {
                return "0";
            }
        }
         
    }
    public Boolean UpdateDrawingDate(String EstNum, String drawingdate)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = "  UPDATE ProjectInfo SET " +
                         "   drawingdate   =   @drawingdate  " +
                         "   WHERE EstNum       = @EstNum";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
            db.AddInParameter(dbCommand, "@drawingdate", DbType.String, drawingdate);
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
    public Boolean UpdateParameters(String EstNum, Decimal EngRate, Decimal FabRate, Decimal InstRate, Decimal MiscRate, Decimal overheadrate, Decimal Profit_markup, Decimal Overhead_percent, String baseBidAmt, String typeofwork)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = "  UPDATE ProjectInfo SET " +
                         "  [enghourrate] =   @enghourrate ," +
                         "  [insthourrate] =   @insthourrate," +
                         "  [fabhourrate] =   @fabhourrate," +
                         "   [mischourrate] =   @mischourrate," +
                         "   [overheadrate]     =   @overheadrate," +
                         "   [profit_markup]    =   @profit_markup, " +
                         "   Overhead_percent   =   @Overhead_percent , " +
                         "   typeofwork   =   @typeofwork , " +
                         "   [BaseBid]          = @baseBidAmt" + 
                         "   WHERE EstNum       = @EstNum";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, Convert.ToInt32(EstNum));
            db.AddInParameter(dbCommand, "@enghourrate", DbType.Decimal, EngRate);
            db.AddInParameter(dbCommand, "@fabhourrate", DbType.Decimal, FabRate);
            db.AddInParameter(dbCommand, "@insthourrate", DbType.Decimal, InstRate);
            db.AddInParameter(dbCommand, "@mischourrate", DbType.Decimal, MiscRate);
            db.AddInParameter(dbCommand, "@overheadrate", DbType.Decimal, overheadrate);
            db.AddInParameter(dbCommand, "@profit_markup", DbType.Decimal, Profit_markup);
            db.AddInParameter(dbCommand, "@Overhead_percent", DbType.Decimal, Overhead_percent);
            db.AddInParameter(dbCommand, "@baseBidAmt", DbType.String, baseBidAmt);
            db.AddInParameter(dbCommand, "@typeofwork", DbType.String, typeofwork);
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
    public IDataReader GetProjectInfo(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT EstNum " +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate,BidTime" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(FinalPrice,0) FinalPrice" +
                                "   ,ISNULL(BaseBid,0) BaseBid " +
                                "   ,Negotiated" +
                                "   ,Architect" +
                                "   ,LEED,drawingdate,typeofwork" +
                                "   ,Is_MD_Sales_Tax,fab_start,fab_end,fab_duration,prj_street,prj_city,prj_state,prj_zip" +
                                "   ,loginid,Real_proj_Number,ISNULL(Contengency,0) Contengency,ISNULL(enghourrate,45.00) enghourrate,ISNULL(fabhourrate,32.00) fabhourrate,ISNULL(insthourrate,45.00) insthourrate,ISNULL(mischourrate,25.00) mischourrate,ISNULL(overheadrate,24.11) overheadrate,ISNULL(profit_markup,15.00) profit_markup" +
                                "    FROM [Whitfielddb].[dbo].[ProjectInfo] WHERE EstNum = @EstNum";
            sqlCommand = sqlCommand + " order by Convert(datetime,BidDate) ASC "; 
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            IDataReader IReader = db.ExecuteReader(dbCommand);
            return IReader;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }

    }

    public DataSet GetProjectInfo(String role_id, String _userid, String projStatus)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT EstNum,ISNULL(Contengency,0) Contengency " +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate,BidTime" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(REPLACE(FinalPrice,'',0),0) FinalPrice" +
                                "   ,ISNULL(REPLACE(BaseBid,'',0),0) BaseBid " +
                                "   ,Negotiated" +
                                "   ,Architect" +
                                "   ,LEED,fab_start,fab_end,fab_duration,prj_street,prj_city,prj_state,prj_zip" +
                                "   ,( select sum(isnull(b.install_hours,0))  from   Project_workorder b where ProjectInfo.EstNum = b.EstNum)  install_hours    " +
                                "   ,( select  sum(isnull(b.fab_hours,0) + isnull(b.Fin_hours,0))  from   Project_workorder b where ProjectInfo.EstNum = b.EstNum)     fab_hours  " + 
                                "   ,Is_MD_Sales_Tax,FirstName + ' ' + LastName as Estimator,Real_proj_Number " +
                                "   ,ProjectInfo.loginid,ltrim(rtrim(replace(replace(isnull(baseBid,0),'$',''),',',''))) fmtBaseBid, ltrim(rtrim(replace(replace(isnull(FinalPrice,0),'$',''),',',''))) fmtFinalPrice" +
                                "    FROM ProjectInfo LEFT JOIN [user] on ProjectInfo.Loginid = [user].loginid WHERE  1=1 ";

            if (projStatus != "")
            {
                sqlCommand = sqlCommand + " AND Status IN (" + projStatus + ")";
            }

            if (role_id.Equals("2"))
            {
                sqlCommand = sqlCommand + " AND ProjectInfo.loginid = '" + _userid + "'";
            }

            if (role_id.Equals(""))
            {
                sqlCommand = sqlCommand + " AND ProjectInfo.IsMoved IS NULL";
            }

            sqlCommand = sqlCommand + " order by Convert(datetime,BidDate) ASC "; 
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet IDataSet = db.ExecuteDataSet(dbCommand);
            return IDataSet;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }

    public DataSet GetProjectInfo(String _roleid, String _userid, String projName, String projStatus)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT EstNum,ISNULL(Contengency,0) Contengency " +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate,BidTime" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(FinalPrice,0) FinalPrice" +
                                "   ,ISNULL(BaseBid,0) BaseBid " +
                                "   ,Negotiated" +
                                "   ,Architect" +
                                "   ,LEED" +
                                "   ,Is_MD_Sales_Tax" +
                                "   ,ProjectInfo.loginid,FirstName + ' ' + LastName as Estimator,Real_proj_Number  " +
                                "    FROM ProjectInfo LEFT JOIN [user] on ProjectInfo.Loginid = [user].loginid WHERE 1=1 ";

            if (projName != "")
            {
                sqlCommand = sqlCommand + " AND ProjName like '" + projName + "%'";
            }

            if (projStatus != "")
            {
                sqlCommand = sqlCommand + " AND Status =" + projStatus;
            }

            

            if (_roleid.Equals("2"))
            {
                sqlCommand = sqlCommand + " AND ProjectInfo.loginid = '" + _userid + "'";
            }
            else
            {
                if (_userid != "")
                {
                    sqlCommand = sqlCommand + " AND ProjectInfo.Loginid = '" + _userid + "'";
                }
            }
            sqlCommand = sqlCommand + " order by Convert(datetime,BidDate) ASC "; 
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet IDataSet = db.ExecuteDataSet(dbCommand);
            return IDataSet;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }
    public DataSet GetProjectInfo()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT EstNum ,ISNULL(Contengency,0) Contengency" +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate,BidTime" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(FinalPrice,0) FinalPrice" +
                                "   ,ISNULL(BaseBid,0) BaseBid " +
                                "   ,Negotiated,fab_start,fab_end,fab_duration,prj_street,prj_city,prj_state,prj_zip" +
                                "   ,Architect" +
                                "   ,LEED" +
                                "   ,Is_MD_Sales_Tax" +
                                "   ,loginid,Real_proj_Number" +
                                "    FROM [Whitfielddb].[dbo].[ProjectInfo]";
            sqlCommand = sqlCommand + " order by Convert(datetime,BidDate) ASC "; 
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet IDataSet = db.ExecuteDataSet(dbCommand);
            return IDataSet;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }
    public Decimal GetMaterialCost(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        //String sqlCommand = " Select IsNull(Sum(tot_mat_cost),0) EstNum from Project_workorder Where EstNum = @EstNum ";
        String sqlCommand = " select isNull(SUM( (Convert(float, replace(replace(a.price,'$',''),',','')) *  Convert(float,b.Qty) )),0) as pWO from Project_Materials a INNER JOIN Project_workorder_materials b on a.EstNum = b.EstNum and a.submatid = b.sub_mat_id  Where b.EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToDecimal(retVal.ToString()) > 0)
        {
            return Convert.ToDecimal(retVal.ToString());
        }
        else
        {
            return 1;
        }
    }

    public Int32 GenerateEstNum()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(EstNum),0) EstNum from ProjectInfo";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;  
        }
        else
        {
            return 1;
        }
    }

    public String GenerateWO(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(Convert(int,work_order_id)),0) EstNum from Project_WorkOrder Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            if ((Convert.ToInt32(retVal.ToString()) >= 1) && (Convert.ToInt32(retVal.ToString()) < 10))
            {
                return "00" + (Convert.ToInt32(retVal.ToString()) + 1).ToString();
            }

            else if ((Convert.ToInt32(retVal.ToString()) >= 10) && (Convert.ToInt32(retVal.ToString()) <= 99))
            {
                return "0" + (Convert.ToInt32(retVal.ToString()) + 1).ToString();
            }
            else
            {
                return  (Convert.ToInt32(retVal.ToString()) + 1).ToString();
            }
        }
        else
        {
            return "001";
        }
    }

    public Boolean IsItemExists(Int32 EstNum)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from ProjectInfo  Where  EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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
    public Boolean UpdateContengency(String EstNum, Int32 Contengency)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = "  UPDATE ProjectInfo SET " +
                         "  [Contengency] =   @Contengency  " +
                         "   WHERE EstNum = @EstNum";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, Convert.ToInt32(EstNum));
            db.AddInParameter(dbCommand, "@Contengency", DbType.Int32, Contengency);
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
    public Boolean InsertEstimateMain(String EstNum
                                    , String projname
                                    , String projdesc
                                    , String notes
                                    , String projtype
                                    , String biddate
                                    , String bidtime
                                    , String awddate
                                    , String awddur
                                    , String constrstdt
                                    , String constrcompl
                                    , String constdur
                                    , String gc1
                                    , String status
                                    , String clienttype
                                    , String winclient
                                    , String winmill
                                    , String  finalprice
                                    , String basebid
                                    , String nogotiated
                                    , String architect
                                    , String leed
                                    , String mdtax
                                    , String loginid, String Real_proj_Number, String fab_start, String fab_end, String fab_duration, String prj_street, String prj_city, String prj_state, String prj_zip)
     {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsItemExists(Convert.ToInt32(EstNum)))
            {
                  sqlCommand = " INSERT INTO ProjectInfo (EstNum " +
                                    "   ,ProjName" +
                                    "   ,ProjDescr" +
                                    "   ,Notes" +
                                    "   ,ProjType" +
                                    "   ,BidDate" +
                                    "   ,BidTime" +
                                    "   ,AwardDate" +
                                    "   ,AwardDur" +
                                    "   ,ConstrStart" +
                                    "   ,ConstrDur" +
                                    "   ,ConstrCompl" +
                                    "   ,GC1" +
                                    "   ,Status" +
                                    "   ,ClientType" +
                                    "   ,WinClient" +
                                    "   ,WinMill" +
                                    "   ,FinalPrice" +
                                    "   ,BaseBid" +
                                    "   ,Negotiated" +
                                    "   ,Architect" +
                                    "   ,LEED" +
                                    "   ,Is_MD_Sales_Tax" +
                                    "   ,loginid,Real_proj_Number,fab_start,fab_end,fab_duration,prj_street,prj_city,prj_state,prj_zip) VALUES (@EstNum" +
                                    "   ,@ProjName   " +
                                    "   ,@ProjDescr" +
                                    "   ,@Notes" +
                                    "   ,@ProjType" +
                                    "   ,@BidDate" +
                                    "   ,@BidTime" +
                                    "   ,@AwardDate" +
                                    "   ,@AwardDur" +
                                    "   ,@ConstrStart" +
                                    "   ,@ConstrDur" +
                                    "   ,@ConstrCompl" +
                                    "   ,@GC1" +
                                    "   ,@Status" +
                                    "   ,@ClientType" +
                                    "   ,@WinClient" +
                                    "   ,@WinMill" +
                                    "   ,@FinalPrice" +
                                    "   ,@BaseBid" +
                                    "   ,@Negotiated" +
                                    "   ,@Architect" +
                                    "   ,@LEED" +
                                    "   ,@Is_MD_Sales_Tax,@loginid,@Real_proj_Number,@fab_start,@fab_end,@fab_duration,@prj_street,@prj_city,@prj_state,@prj_zip)";

                
            }
            else  //Here is the update if the system already exists.
            {
                  sqlCommand = " UPDATE ProjectInfo SET " +
                          "  [ProjName] =   @ProjName  " +
                          "  ,[ProjDescr] =  @ProjDescr " +
                          "  ,[Notes]  =  @Notes " +
                          "  ,[ProjType] = @ProjType " +
                          "  ,[BidDate]  =  @BidDate " +
                          "  ,[BidTime]  =  @BidTime " +
                          "  ,[AwardDate] =  @AwardDate " +
                          "  ,[AwardDur] =  @AwardDur " +
                          "  ,[ConstrStart]=  @ConstrStart " +
                          "  ,[ConstrDur]  = @ConstrDur " +
                          "  ,[ConstrCompl] = @ConstrCompl " +
                          "  ,[GC1]  =   @GC1 " +
                          "  ,[Status]=  @Status " +
                          "  ,[ClientType]= @ClientType " +
                          "  ,[WinClient] = @WinClient " +
                          "  ,[WinMill] = @WinMill " +
                          "  ,[FinalPrice]  = @FinalPrice " +
                          "  ,[BaseBid]  = @BaseBid " +
                          "  ,[Negotiated]=   @Negotiated " +
                          "  ,[Architect]  = @Architect " +
                          "  ,[LEED]  = @LEED " +
                          "  ,[Is_MD_Sales_Tax] = @Is_MD_Sales_Tax " +
                          "  ,[loginid] = @loginid,[Real_proj_Number]=@Real_proj_Number,fab_start=@fab_start,fab_end=@fab_end,fab_duration=@fab_duration,prj_street=@prj_street,prj_city=@prj_city,prj_state=@prj_state,prj_zip=@prj_zip WHERE EstNum = @EstNum";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, Convert.ToInt32(EstNum));
            db.AddInParameter(dbCommand, "@ProjName", DbType.String, projname);
            db.AddInParameter(dbCommand, "@ProjDescr", DbType.String, projdesc);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "@ProjType", DbType.Int32, projtype);
            db.AddInParameter(dbCommand, "@BidDate", DbType.String, biddate);
            db.AddInParameter(dbCommand, "@BidTime", DbType.String, bidtime);
            db.AddInParameter(dbCommand, "@AwardDate", DbType.String, awddate);
            db.AddInParameter(dbCommand, "@AwardDur", DbType.String, awddur);
            db.AddInParameter(dbCommand, "@ConstrStart", DbType.String, constrstdt);
            db.AddInParameter(dbCommand, "@ConstrDur", DbType.String, constdur);
            db.AddInParameter(dbCommand, "@ConstrCompl", DbType.String, constrcompl);
            db.AddInParameter(dbCommand, "@GC1", DbType.String, gc1);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Convert.ToInt32(status));
            db.AddInParameter(dbCommand, "@ClientType", DbType.Int32, Convert.ToInt32(clienttype));
            db.AddInParameter(dbCommand, "@WinClient", DbType.Int32, Convert.ToInt32(winclient));
            db.AddInParameter(dbCommand, "@WinMill", DbType.Int32, Convert.ToInt32(winmill));
            db.AddInParameter(dbCommand, "@FinalPrice", DbType.String, finalprice);
            db.AddInParameter(dbCommand, "@BaseBid", DbType.String, basebid);
            db.AddInParameter(dbCommand, "@Negotiated", DbType.String, nogotiated);
            db.AddInParameter(dbCommand, "@Architect", DbType.Int32, Convert.ToInt32(architect));
            db.AddInParameter(dbCommand, "@LEED", DbType.String, leed);
            db.AddInParameter(dbCommand, "@Is_MD_Sales_Tax", DbType.String, mdtax);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
            db.AddInParameter(dbCommand, "@Real_proj_Number", DbType.Int32, Convert.ToInt32(Real_proj_Number));
            db.AddInParameter(dbCommand, "@fab_start", DbType.String, fab_start);
            db.AddInParameter(dbCommand, "@fab_end", DbType.String, fab_end);
            db.AddInParameter(dbCommand, "@fab_duration", DbType.String, fab_duration);
            db.AddInParameter(dbCommand, "@prj_street", DbType.String, prj_street);
            db.AddInParameter(dbCommand, "@prj_city", DbType.String, prj_city);
            db.AddInParameter(dbCommand, "@prj_state", DbType.String, prj_state);
            db.AddInParameter(dbCommand, "@prj_zip", DbType.String, prj_zip);
            
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
    //*******************************PROJECT INFORMATION ENDS**********************************//


    //*****************************************************************************************//
    //********************************  Clients Methods ***************************************//
    //*****************************************************************************************//
    public Boolean ManageClients(
                                        Int32 ClientID 
	                                    ,String Name
	                                    ,Int32 ClientType
	                                    ,String Street
	                                    ,Int32 City
	                                    ,Int32 State
	                                    ,String Phone
	                                    ,String Fax
	                                    ,String Web
	                                    ,String FTP
	                                    ,String login
	                                    ,String pw
	                                    ,String Notes
                                   )
     {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsClientExists(ClientID))
            {
                sqlCommand = " INSERT INTO ClientInfo ( " +
                                "            ClientID  " +
                                "            ,Name   " +
                                "            ,ClientType  " +
                                "            ,Street  " +
                                "            ,City  " +
                                "            ,State  " +
                                "            ,Phone " +
                                "            ,Fax  " +
                                "            ,Web " +
                                "            ,FTP " +
                                "            ,login " +
                                "            ,pw " +
                                "            ,Notes)  " +
                                "            VALUES (@ClientID" +
                                "            ,@Name   " +
                                "            ,@ClientType  " +
                                "            ,@Street  " +
                                "            ,@City  " +
                                "            ,@State  " +
                                "            ,@Phone " +
                                "            ,@Fax  " +
                                "            ,@Web " +
                                "            ,@FTP " +
                                "            ,@login " +
                                "            ,@pw " +
                                "            ,@Notes )";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE ClientInfo SET " +
                        "   [Name]          =   @Name  " +
                        "  ,[ClientType] =  @ClientType " +
                        "  ,[Street]    =  @Street " +
                        "  ,[City]      = @City " +
                        "  ,[State]     =  @State " +
                        "  ,[Phone]     =  @Phone " +
                        "  ,[Fax]       =  @Fax " +
                        "  ,[Web]       =  @Web " +
                        "  ,[FTP]       =  @FTP " +
                        "  ,[login]     = @login " +
                        "  ,[pw]        = @pw " +
                        "  ,[Notes]  =   @Notes WHERE ClientID = @ClientID";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
            db.AddInParameter(dbCommand, "@Name", DbType.String, Name);
            db.AddInParameter(dbCommand, "@ClientType", DbType.Int32, ClientType);
            db.AddInParameter(dbCommand, "@Street", DbType.String, Street);
            db.AddInParameter(dbCommand, "@City", DbType.Int32, City);
            db.AddInParameter(dbCommand, "@State", DbType.Int32, State);
            db.AddInParameter(dbCommand, "@Phone", DbType.String, Phone);
            db.AddInParameter(dbCommand, "@Fax", DbType.String, Fax);
            db.AddInParameter(dbCommand, "@Web", DbType.String, Web);
            db.AddInParameter(dbCommand, "@FTP", DbType.String, FTP);
            db.AddInParameter(dbCommand, "@login", DbType.String, login);
            db.AddInParameter(dbCommand, "@pw", DbType.String, pw);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
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

    public Int32 GenerateClientID()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(ClientID),0) ClientID from Clientinfo";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;
        }
        else
        {
            return 1;
        }
    }
    
    public Boolean IsClientExists(Int32 ClientID)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from Clientinfo  Where  ClientID = @ClientID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
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
    public IDataReader GetClientInfo(Int32 ClientID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  " +
                                " ClientID , " +
                                " Name, " +
                                " ClientType, " +
                                " Street, " +
                                " City, " +
                                " State, " +
                                " Phone, " +
                                " Fax, " +
                                " Web, " +
                                " FTP, " +
                                " login, " +
                                " pw, " +
                                " Notes " +
                              "   FROM [Whitfielddb].[dbo].[ClientInfo] WHERE ClientID = @ClientID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
            IDataReader IReader = db.ExecuteReader(dbCommand);
            return IReader;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }

    }

    // For Client Module
    public DataSet GetClientTypes()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * from List_ClientType ";
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
    public DataSet GetStatelist()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select StateCD, StateID from List_State ";
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

    public DataSet GetCityList(String StateCD)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select CityID, City from List_City WHERE 1=1 ";

            if (StateCD != "")
            {
                sqlCommand = sqlCommand + " AND Statecd = '" + StateCD + "'";
            }

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
    // For Client Module Ends
    public DataSet GetClientlist()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "  Select a.*,b.City as citynm,c.State as statenm from Clientinfo a LEFT JOIN List_City b on a.city = b.cityid  " +
                                " LEFT JOIN  List_State c  ON  a.state = c.stateid order by Name asc";
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

    public DataSet GetClientlistForProject(String EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.ClientID,b.Name as Name1 from Project_Client a, clientinfo b Where a.ClientID = b.clientid and a.EstNum =" + EstNum  + "  ORDER BY b.Name asc ";
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
    //************************************Client Methods Ends ******************************************//

    //**************************************************************************************************//
    //*************************************Competition Set *********************************************//
    //**************************************************************************************************//

    public DataSet GetCompetitors()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "Select a.*,b.City as citynm,c.State as statenm,d.specialty as spec from Competition a LEFT JOIN List_City b on a.city = b.cityid " +
                                " LEFT JOIN  List_State c  ON  a.state = c.stateid " +
                                " LEFT JOIN  List_Specialty d ON a.Specialty = d.SpecID  ORDER BY a.Name asc";
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

    public DataSet GetCompetitors(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select b.compeId,a.Name as Name1 from Competition a, Project_Compe b WHERE a.compeId = b.compeId and b.EstNum =" + EstNum.ToString();
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

    public DataSet GetSpeciality()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  SpecID " +
                                "         ,Specialty " +
                                " FROM List_Specialty";
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
    public Boolean ManageCompetition(
                                           Int32 CompeID
                                         , String Name
                                         , String Web
                                         , Int32 Specialty
                                         , String Notes
                                         , Int32 City
                                         , Int32 State
                                         , String LaborRate
                                         , String OverheadBurden
                                         , String Installation
                                   )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsCompeExists(CompeID))
            {
                sqlCommand = " INSERT INTO Competition ( " +
                                "            CompeID  " +
                                "            ,Name   " +
                                "            ,Web  " +
                                "            ,Specialty  " +
                                "            ,City  " +
                                "            ,State  " +
                                "            ,LaborRate " +
                                "            ,OverheadBurden  " +
                                "            ,Installation) " +
                                "            VALUES (@CompeID" +
                                "            ,@Name   " +
                                "            ,@Web  " +
                                "            ,@Speciality  " +
                                "            ,@City  " +
                                "            ,@State  " +
                                "            ,@LaborRate " +
                                "            ,@OverheadBurden  " +
                                "            ,@Installation )";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE Competition SET " +
                             "   [Name]          =   @Name  " +
                             "  ,[Web]           =   @Web " +
                             "  ,[City]          =   @City " +
                             "  ,[State]         =   @State " +
                             "  ,[Specialty]    =   @Speciality " +
                             "  ,[LaborRate]     =   @LaborRate " +
                             "  ,[OverheadBurden]=   @OverheadBurden " +
                             "  ,[Installation]  =   @Installation " +
                             "  ,[Notes]         =   @Notes WHERE CompeID = @CompeID";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@CompeID",    DbType.Int32, CompeID);
            db.AddInParameter(dbCommand, "@Name",       DbType.String, Name);
            db.AddInParameter(dbCommand, "@City",       DbType.Int32, City);
            db.AddInParameter(dbCommand, "@State",      DbType.Int32, State);
            db.AddInParameter(dbCommand, "@Speciality", DbType.Int32, Specialty);
            db.AddInParameter(dbCommand, "@LaborRate", DbType.String, LaborRate);
            db.AddInParameter(dbCommand, "@Web",        DbType.String, Web);
            db.AddInParameter(dbCommand, "@OverheadBurden", DbType.String, OverheadBurden);
            db.AddInParameter(dbCommand, "@Installation", DbType.String, Installation);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
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
    public IDataReader GetCompetitorInfo(Int32 CompeID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  " +
                                " CompeID , " +
                                " Name, " +
                                " Web, " +
                                " Specialty, " +
                                " Notes, " +
                                " City, " +
                                " State, " +
                                " LaborRate, " +
                                " OverheadBurden, " +
                                " Installation " +
                                "   FROM [Competition] WHERE CompeID = @CompeID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@CompeID", DbType.Int32, CompeID);
            IDataReader IReader = db.ExecuteReader(dbCommand);
            return IReader;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }

    }

    public Int32 GenerateCompeID()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(CompeID),0) CompeID from Competition";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;
        }
        else
        {
            return 1;
        }
    }

    public Boolean IsCompeExists(Int32 CompeID)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*) FROM [Competition] WHERE CompeID = @CompeID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@CompeID", DbType.Int32, CompeID);
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
    //*****************************Competition Set Ends*************************************************//

    //**************************************************************************************************//
    //*************************************Architect Set *********************************************//
    //**************************************************************************************************//

    public DataSet GetArchitects()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.*,b.City as citynm,c.State as statenm from ArchitectInfo a LEFT JOIN List_City b on a.city = b.cityid " +
                                " LEFT JOIN  List_State c  ON  a.state = c.stateid ORDER BY Architect ASC";
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

    public Boolean ManageArchitects(
                                               Int32 Archid
                                             , String Architect
                                             , String Address
                                             , Int32 City
                                             , Int32 State
                                             , String Zip
                                             , String Phone
                                             , String Fax
                                             , String Web
                                             , String Notes
                                       )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsArchExists(Archid)) 
            {
                sqlCommand = " INSERT INTO ArchitectInfo ( " +
                                "             Archid  " +
                                "            ,Architect   " +
                                "            ,Address  " +
                                "            ,City  " +
                                "            ,State  " +
                                "            ,Zip " +
                                "            ,Phone  " +
                                "            ,Fax " +
                                "            ,Web " + 
                                "            ,Notes) " +
                                "            VALUES (@Archid" +
                                "            ,@Architect   " +
                                "            ,@Address  " +
                                "            ,@City  " +
                                "            ,@State  " +
                                "            ,@Zip  " +
                                "            ,@Phone " +
                                "            ,@Fax  " +
                                "            ,@Web,@Notes )";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE ArchitectInfo SET " +
                             "   [Archid]           =   @Archid  " +
                             "  ,[Architect]        =   @Architect " +
                             "  ,[Address]          =   @Address " +
                             "  ,[City]             =   @City " +
                             "  ,[State]            =   @State " +
                             "  ,[Zip]              =   @Zip " +
                             "  ,[Phone]            =   @Phone " +
                             "  ,[Fax]              =   @Fax " +
                             "  ,[Web]              =   @Web " +
                             "  ,[Notes]            =   @Notes WHERE Archid = @Archid";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@Archid", DbType.Int32, Archid);
            db.AddInParameter(dbCommand, "@Architect", DbType.String, Architect);
            db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
            db.AddInParameter(dbCommand, "@City", DbType.Int32, City);
            db.AddInParameter(dbCommand, "@State", DbType.Int32, State);
            db.AddInParameter(dbCommand, "@Zip", DbType.String, Zip);
            db.AddInParameter(dbCommand, "@Phone", DbType.String, Phone);
            db.AddInParameter(dbCommand, "@Fax", DbType.String, Fax);
            db.AddInParameter(dbCommand, "@Web", DbType.String, Web);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
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

    public String GetArchitectName(Int32 ArchID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  " +
                                " isnull(Architect,'')  " +
                                "   FROM [ArchitectInfo] WHERE ArchID = @ArchID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ArchID", DbType.Int32, ArchID);
            object retVal = db.ExecuteScalar(dbCommand);
            return retVal.ToString();
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }
    public IDataReader GetArchitectInfo(Int32 ArchID)
    {
        //[ArchID]  
        //[Architect]  
        //[Address]  
        //[City]  
        //[State] 
        //[Zip]  
        //[Phone]  
        //[Fax]  
        //[Web]  
        //[Notes]
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  " +
                                " Archid , " +
                                " Architect, " +
                                " Address, " +
                                " City, " +
                                " State, " +
                                " Zip, " +
                                " Phone, " +
                                " Fax, " +
                                " Web, " +
                                " Notes " +
                                "   FROM [ArchitectInfo] WHERE ArchID = @ArchID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ArchID", DbType.Int32, ArchID);
            IDataReader IReader = db.ExecuteReader(dbCommand);
            return IReader;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }

    }

    public Int32 GenerateArchID()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(ArchID),0) ArchID from ArchitectInfo";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;
        }
        else
        {
            return 1;
        }
    }

    public Boolean IsArchExists(Int32 ArchID)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*) FROM [ArchitectInfo] WHERE ArchID = @ArchID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ArchID", DbType.Int32, ArchID);
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

    //*********************************************************************************************************/
    //**************************************CONTACTS MODULE ***************************************************
    //*********************************************************************************************************/
    public Int32 GenerateContactID()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(ContactID),0) ContactID from Contacts";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;
        }
        else
        {
            return 1;
        }
    }
    public Boolean IsContactExists(Int32 ContactID)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*) FROM [Contacts] WHERE ContactID = @ContactID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
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

    public IDataReader GetContactInfo(Int32 ContactID)
    {
            //ContactID
            //ClientID 
            //First 
            //Last 
            //Title 
            //Tel 
            //Ext 
            //Email ,
            //Notes 
            //FullName 
            //Address 
            //City 
            //State 
            //Zip 
 
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  " +
                                "    ContactID," +
	                            "    ClientID ," +
	                            "    First ," +
	                            "    Last ," +
	                            "    Title ," +
	                            "    Tel ," +
	                            "    Ext ," +
	                            "    Email ," +
	                            "    Notes, " +
	                            "    FullName, " +
	                            "    Address ," +
	                            "    City ," +
	                            "    State ," +
                                "    Zip " +
                                "   FROM [Contacts] WHERE ContactID = @ContactID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
            IDataReader IReader = db.ExecuteReader(dbCommand);
            return IReader;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }

    }
    public DataSet GetWorkOrders(String EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select  a.*, b.* ,(a.EnghourRate * b.eng_hours + a.fabhourrate * b.fab_hours + a.insthourrate * b.install_hours + a.mischourrate*b.misc_hours + a.fabhourrate*b.fin_hours) total_labor " +
                                " from PROJECTINFO a INNER JOIN Project_workorder b on a.EstNum = b.EstNum Where a.EstNum = '" + EstNum + "'  order by Convert(int, work_order_id) asc";
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
    public void DeleteWorkOrders(String _woNumber,String EstNum )
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_workorder WHERE work_order_id = @work_order_id AND EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, _woNumber);
            db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public Boolean UpdateWorkorders(String WorkOrderID, Int32 tot_mat_cost, Int32 EstNum, String Description, Int32 fab_hours, Int32 fin_hours, Int32 Inst_hours, Int32 Eng_hours, Int32 misc_hours, String Notes, String isActive, String reftext)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = " UPDATE Project_workorder SET " +
                               "            Description=@description, " +
                               "            fab_hours=@fab_hours, " +
                               "            tot_mat_cost=@tot_mat_cost, " +
                               "            fin_hours=@fin_hours, " +
                               "            install_hours=@install_hours, " +
                               "            eng_hours=@eng_hours, " +
                               "            misc_hours=@misc_hours, " +
                               "            Notes=@notes, " +
                               "            isActive=1,reftext=@reftext" +
                               "            WHERE EstNum = @EstNum AND work_order_id = @work_order_id";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, WorkOrderID);
            db.AddInParameter(dbCommand, "@description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@fab_hours", DbType.Int32, fab_hours);
            db.AddInParameter(dbCommand, "@tot_mat_cost", DbType.Int32, tot_mat_cost);
            db.AddInParameter(dbCommand, "@fin_hours", DbType.Int32, fin_hours);
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, Inst_hours);
            db.AddInParameter(dbCommand, "@eng_hours", DbType.Int32, Eng_hours);
            db.AddInParameter(dbCommand, "@misc_hours", DbType.Int32, misc_hours);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
            db.AddInParameter(dbCommand, "@isActive", DbType.String, isActive);
            db.AddInParameter(dbCommand, "@reftext", DbType.String, reftext);
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

    public Boolean ManageWorkOrders(Int32 EstNum, String Description,Int32 tot_mat_cost, Int32 fab_hours, Int32 fin_hours, Int32 Inst_hours, Int32 Eng_hours, Int32 misc_hours, String Notes, String isActive, String reftext)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = " INSERT INTO Project_workorder(work_order_id,tot_mat_cost,EstNum,Description,fab_hours,fin_hours,install_hours,eng_hours,misc_hours,Notes,isActive,reftext) Values " +
                         " (@woid,@tot_mat_cost,@EstNum,@description,@fab_hours,@fin_hours,@install_hours,@eng_hours,@misc_hours,@notes,@isActive,@reftext) ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@woid", DbType.String, GenerateWO(EstNum));
            db.AddInParameter(dbCommand, "@tot_mat_cost", DbType.Int32,tot_mat_cost);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@fab_hours", DbType.Int32, fab_hours);
            db.AddInParameter(dbCommand, "@fin_hours", DbType.Int32, fin_hours);
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, Inst_hours);
            db.AddInParameter(dbCommand, "@eng_hours", DbType.Int32, Eng_hours);
            db.AddInParameter(dbCommand, "@misc_hours", DbType.Int32, misc_hours);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
            db.AddInParameter(dbCommand, "@isActive", DbType.String, isActive);
            db.AddInParameter(dbCommand, "@reftext", DbType.String, reftext);
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

    public Boolean ManageContacts(
                                     Int32 ContactID
                                     ,Int32 ClientID 
                                     ,String First 
                                     ,String Last 
                                     ,String Title 
                                    ,String Tel 
                                    ,String Ext 
                                    ,String Email 
                                    ,String Notes 
                                    ,String Address 
                                    ,String City 
                                    ,String State 
                                    ,String Zip 
                                       )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsContactExists(ContactID))
            {
                sqlCommand = " INSERT INTO Contacts ( " +
                                "            ContactID," +
                                "            ClientID, " +
                                "            First, " +
                                "            Last, " +
                                "            Title, " +
                                "            Tel, " +
                                "            Ext, " +
                                "            Email ," +
                                "            Notes, " +
                                "            Address ," +
                                "            City ," +
                                "            State, " +
                                "            Zip  )" +
                                "            VALUES (  " +
                                "            @ContactID," +
                                "            @ClientID, " +
                                "            @First, " +
                                "            @Last, " +
                                "            @Title, " +
                                "            @Tel, " +
                                "            @Ext, " +
                                "            @Email ," +
                                "            @Notes, " +
                                "            @Address ," +
                                "            @City ," +
                                "            @State, " +
                                "            @Zip  )";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE Contacts SET " +
                                "            First  =   @First, " +
                                "            Last   =   @Last, " +
                                "            Title  =   @Title, " +
                                "            Tel    =   @Tel, " +
                                "            Ext    =   @Ext, " +
                                "            Email  =   @Email," +
                                "            Notes  =   @Notes, " +
                                "            Address    =   @Address," +
                                "            City   =       @City," +
                                "            State  =       @State, " +
                                "            Zip    =   @Zip " +
                                "   WHERE ContactID = @ContactID";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
            db.AddInParameter(dbCommand, "@First", DbType.String, First);
            db.AddInParameter(dbCommand, "@Last", DbType.String, Last);
            db.AddInParameter(dbCommand, "@Title", DbType.String, Title);
            db.AddInParameter(dbCommand, "@Tel", DbType.String, Tel);
            db.AddInParameter(dbCommand, "@Ext", DbType.String, Ext);
            db.AddInParameter(dbCommand, "@Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
            db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
            db.AddInParameter(dbCommand, "@City", DbType.Int32, Convert.ToInt32(City));
            db.AddInParameter(dbCommand, "@State", DbType.Int32, Convert.ToInt32(State));
            db.AddInParameter(dbCommand, "@Zip", DbType.String, Zip);
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
    public DataSet GetContacts()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.*,b.City as citynm,c.State as statenm from Contacts a LEFT JOIN List_City b on a.city = b.cityid " +
                                " LEFT JOIN  List_State c  ON  a.state = c.stateid ORDER BY a.First ASC";
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

    public DataSet GetContactsForClients(Int32 ClientID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ContactID, first + ' ' + last as FName FROM [contacts] WHERE ClientID = @ClientID ORDER BY First ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
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

    public DataSet GetContactsForClientsSOV(Int32 ClientID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ContactID, first + ' ' + last + '(' + Tel + ')' as FName FROM [contacts] WHERE ClientID = @ClientID ORDER BY First ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
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

    public DataSet GetContactsForClient(Int32 ClientID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * FROM [contacts] WHERE ClientID = @ClientID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
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

    public DataSet GetContactsForProject(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "    SELECT a.primary_contact,b.ClientId, b.Name,c.first + ',' + c.last contactName, c.email, c.Tel from project_client a  LEFT JOIN  clientinfo b ON a.clientid = b.clientid  LEFT JOIN contacts c ON  a.primary_contact = c.contactID " +
                                "    WHERE   "  + 
                                "    EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public DataSet GetCompetitonForProject(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " select b.Compeid,a.Name,b.Bid from competition a LEFT JOIN  project_compe b  ON a.compeID = b.CompeID  " +
                                " Where EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public Boolean PopulateProject_client(Int32 EstNum, Int32 ClientID)
    {
        
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO PROJECT_CLIENT(EstNum, ClientID) Values (@EstNum, @ClientID)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
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

    public Boolean PopulateProject_compe(Int32 EstNum, Int32 CompeID)
    {
        
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_Compe(EstNum, compeId) Values (@EstNum, @compeId)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@compeId", DbType.Int32, CompeID);
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

    public void DeleteEstimateRecords(Int32 EstNum)
    {
        try
        {
            DeleteConsideration(EstNum);
            DeleteProjectClient(EstNum);
            DeleteProjectCompe(EstNum);
            DeleteQualification(EstNum);
            DeleteConvLog(EstNum);
            DeleteProjectDocs(EstNum);
            DeleteEstimate(EstNum);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteEstimate(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE ProjectInfo WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    public void DeleteConvLog(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_conv_log WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteProjectCompe(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_Compe WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteProjectCompe(Int32 EstNum,Int32 CompeID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_Compe WHERE EstNum = @EstNum and compeID = @compeid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@compeid", DbType.Int32, CompeID);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteProjectClient(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_client WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }


    public void AddPrimaryContact(Int32 EstNum, Int32 ClientID, Int32 ContactID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Project_client SET Primary_contact = @ContactID WHERE EstNum = @EstNum and ClientID = @ClientID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@ClientID", DbType.Int32, ClientID);
            db.AddInParameter(dbCommand, "@ContactID", DbType.Int32, ContactID);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void AddBidAmount(Int32 EstNum, Int32 Compeid, String BidAMT)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Project_compe SET Bid = @Bid WHERE EstNum = @EstNum and compeid = @Compeid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@Compeid", DbType.Int32, Compeid);
            db.AddInParameter(dbCommand, "@Bid", DbType.String, BidAMT);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public String GetBidAmt(Int32 EstNum, Int32 Compeid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ISNULL(Bid,'') as Bid  FROM [Project_compe] WHERE EstNum = @EstNum and compeid = @Compeid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@Compeid", DbType.Int32, Compeid);
            object retVal = db.ExecuteScalar(dbCommand);
            return retVal.ToString();
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return "";
        }
    }

    public String GetProjectName(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ISNULL(ProjName,'') as ProjName  FROM [ProjectInfo] WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            object retVal = db.ExecuteScalar(dbCommand);
            return retVal.ToString();
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return "";
        }
    }

    public String GetClientName(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ISNULL(b.Name,'') as CompeName  FROM Project_Compe a, Competition b WHERE a.compeID = b.compeID and EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            object retVal = db.ExecuteScalar(dbCommand);
            return retVal.ToString();
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return "";
        }
    }

    public Boolean PopulateConsideration(Int32 EstNum, Int32 ConID)
    {

            try
            {

                    Database db = DatabaseFactory.CreateDatabase();
                    String sqlCommand = " INSERT INTO Project_consideration(EstNum, con_id) Values (@EstNum, @con_id)  ";
                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
                    db.AddInParameter(dbCommand, "@con_id", DbType.Int32, ConID);
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

    
    public Boolean DeleteConsideration(Int32 EstNum)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_consideration WHERE EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    
   

    public Boolean PopulateQualification(Int32 EstNum, Int32 qualid)
    {

        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_Qualificaton(EstNum, qual_id) Values (@EstNum, @qual_id)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@qual_id", DbType.Int32, qualid);
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

    public void DeleteProjectDocs(Int32 EstNum)
    {
        //Project_documents
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_documents WHERE EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.ExecuteNonQuery(dbCommand);

        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);

        }
    }
    public Boolean DeleteQualification(Int32 EstNum)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_Qualificaton WHERE EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    //***********************Conversation Log for the Project *****************************
    public DataSet GetConversationLogforProject(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * FROM [Project_conv_log] WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public Boolean InsertConversation(Int32 EstNum,String _userid, String _comments,String _commentsDate, String _commentsTime)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_conv_log(EstNum, seq_no,comments, LastModifiedBy,LastModifiedDate,LastModifiedTime) Values (@EstNum,@seqid, @comments,@userid,@commentsDate,@commentsTime)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@seqid", DbType.Int32, GenerateseqNumber(EstNum));
            db.AddInParameter(dbCommand, "@comments", DbType.String, _comments);
            db.AddInParameter(dbCommand, "@userid", DbType.String, _userid);
            db.AddInParameter(dbCommand, "@commentsDate", DbType.String, _commentsDate);
            db.AddInParameter(dbCommand, "@commentsTime", DbType.String, _commentsTime);
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

    public Int32 GenerateseqNumber(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(seq_no),0) seqID from Project_conv_log Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;
        }
        else
        {
            return 1;
        }
    }
    //*************************************************************************************

    //***************Project documents******************************************************
    public Int32 GenerateseqNumberforDocs(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(seq_num),0) seqID from Project_documents Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;
        }
        else
        {
            return 1;
        }
    }

    public DataSet GetDocumentsforProject(Int32 EstNum)
    {
        //System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.*,b.doc_Type_Desc FROM Project_documents a,List_document_type b  WHERE a.doc_type_id = b.doc_type_id AND EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    //*************************************

    public DataSet GetAllDocTypes()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT * from List_document_type ";
                                
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

    //********************************************
    public void DeleteProjDocument(Int32 EstNum,Int32 SeqNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_documents WHERE EstNum = @EstNum and seq_num = @seq_num";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@seq_num", DbType.Int32, SeqNum);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    // Material Administration
    public DataSet GetAllMaterials(Int32 mat_type_code)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT a.*,b.Mat_type_Desc from Master_Materials a INNER JOIN Master_material_type b ON a.mat_type = b.Mat_type_id WHERE 1=1 ";
               
            if (mat_type_code != 0)
            {
                sqlCommand = sqlCommand + " AND a.mat_type =" + mat_type_code;
            }
           
            sqlCommand = sqlCommand + " ORDER BY Mat_type_Desc ASC";
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

    public DataSet GetAllMaterialTypes()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT * from Master_material_type ";

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


    public Boolean PopulateMasterMaterials(Int32 mat_type, String Reference_Number, String Description, String Manufacturer, String LEED, String Comments)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Master_Materials(mat_type, Reference_Number,Description,Manufacturer,LEED,Comments) Values (@mat_type, @Reference_Number,@Description,@Manufacturer,@LEED,@comments)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@mat_type", DbType.Int32, mat_type);
            db.AddInParameter(dbCommand, "@Reference_Number", DbType.String, Reference_Number);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@Manufacturer", DbType.String, Manufacturer);
            db.AddInParameter(dbCommand, "@LEED", DbType.String, LEED);
            db.AddInParameter(dbCommand, "@Comments", DbType.String, Comments);
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

    public Boolean UPDATEMasterMaterials(Int32 material_id, String Reference_Number, String Description, String Manufacturer, String LEED, String Comments)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Master_Materials SET Reference_Number = @Reference_Number ,Description=@Description,Manufacturer=@Manufacturer,LEED=@LEED,Comments=@Comments WHERE  material_id = @material_id ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@material_id", DbType.Int32, material_id);
            db.AddInParameter(dbCommand, "@Reference_Number", DbType.String, Reference_Number);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@Manufacturer", DbType.String, Manufacturer);
            db.AddInParameter(dbCommand, "@LEED", DbType.String, LEED);
            db.AddInParameter(dbCommand, "@Comments", DbType.String, Comments);
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

    public Boolean DeleteMaterials(Int32 material_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand1 = " DELETE Sub_materials Where material_id = " + material_id;
            DbCommand dbCommand1 = db.GetSqlStringCommand(sqlCommand1);
            db.ExecuteNonQuery(dbCommand1);

            String sqlCommand = " DELETE Master_Materials Where material_id = @material_id";           
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@material_id", DbType.Int32, material_id);
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
    //End Material Adminstration

    //Get materials for Estimation
    public DataSet GetMaterialForEsitmation(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select IsNull(c.Purchased,'N') Purchased,IsNull(c.Received,'N') Received,IsNull(c.Verified,'N') Verified, c.matnotes,IsNull(c.price,'0') PriceInProject, a.description + '-' + b.Description + '(' + b.thickness + 'X' + b.length + 'X' + b.width+ ')' OrigMatName,c.EstNum,a.material_id, a.reference_number, a.description as matname, a.comments, b.sub_mat_id, b.thickness, b.length, b.width, b.description as submatname, b.cost, b.manufacturer, b.LEED, b.Notes,b.Material_Code,uomtab.uom_type_desc  from master_materials a INNER JOIN sub_materials b on a.material_id = b.material_id  inner join  project_materials c on b.sub_mat_id= c.submatid INNER JOIN UOM_TYPE uomtab ON b.UOM = uomtab.uom_type_id WHERE EstNum = @EstNum order by reference_number asc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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
    public DataSet GetMaterialForExcelExport(Int32 EstNum)
    {
        try
        {
           // Seq. No Material Type LEED Project Price Material Code Material Description Total Qty UOM Total Price Verified? Purchased? Received? Notes 
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select isNull(c.Purchased,'N') Purchased,IsNull(c.Received,'N') Received,IsNull(c.Verified,'N') Verified, a.reference_number,b.LEED,IsNull(c.price,'0') PriceInProject,Material_Code,a.description + '-' + b.Description + '(' + b.thickness + 'X' + b.length + 'X' + b.width+ ')' OrigMatName,uom_type_desc from master_materials a INNER JOIN sub_materials b on a.material_id = b.material_id  inner join  project_materials c on b.sub_mat_id= c.submatid INNER JOIN UOM_TYPE uomtab ON b.UOM = uomtab.uom_type_id WHERE EstNum = @EstNum order by reference_number asc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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
    //Get All SubMaterial for a Project

    public DataSet GetMaterialForWorkOrder(Int32 EstNum,String work_order_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            //replace(d.price,',','')
            String sqlCommand = " select isNull((Convert(float, replace(replace(d.price,',',''),'$','')) *  Convert(float,c.Qty) ),0) as pWO,IsNull(d.price,'0') PriceInProject, c.Qty, a.description + '-' + b.Description + '(' + b.thickness + 'X' + b.length + 'X' + b.width+ ')' OrigMatName,c.EstNum,c.work_order_id,a.material_id, a.reference_number, a.description as matname, a.comments, b.sub_mat_id, b.thickness, b.length, b.width, b.description as submatname, b.cost, b.manufacturer, b.LEED, b.Notes  from master_materials a INNER JOIN sub_materials b on a.material_id = b.material_id  INNER JOIN Project_materials d on b.sub_mat_id = d.submatid  inner join  Project_workorder_materials c on d.EstNum = c.EstNum AND d.submatid= c.sub_mat_id WHERE d.EstNum = @EstNum AND c.EstNum = @EstNum AND c.work_order_id=@work_order_id ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
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

    public String GetPriceForMaterial(Int32 sub_mat_id)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(cost,'0') price from Sub_materials Where sub_mat_id = @submatid";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@submatid", DbType.Int32, sub_mat_id);
        object retVal = db.ExecuteScalar(dbCommand);
        return retVal.ToString();
    }

    public String GetPriceinProject(Int32 EstNum, Int32 sub_mat_id)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(price,'0') price from Project_materials  Where EstNum = @EstNum AND sub_mat_id = @submatid";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        db.AddInParameter(dbCommand, "@submatid", DbType.Int32, sub_mat_id);
        object retVal = db.ExecuteScalar(dbCommand);
        return retVal.ToString();
    }

    public String GetTotalMaterialPriceForWorkOrder(Int32 EstNum, String work_order_id)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select isNull(SUM( (Convert(float, replace(replace(a.price,',',''),'$','')) *  Convert(float,b.Qty) )),0) as pWO from Project_Materials a INNER JOIN Project_workorder_materials b on a.EstNum = b.EstNum and a.submatid = b.sub_mat_id  Where b.EstNum = @EstNum and b.Work_order_id = @work_order_id";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
        object retVal = db.ExecuteScalar(dbCommand);
        return retVal.ToString();
    }

    public decimal GetTotalMaterialPriceForEstimation(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select isNull(SUM( (Convert(float, replace(replace(a.price,',',''),'$','')) *  Convert(float,b.Qty) )),0) as pWO from Project_Materials a INNER JOIN Project_workorder_materials b on a.EstNum = b.EstNum and a.submatid = b.sub_mat_id  Where b.EstNum = @EstNum ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        return Convert.ToDecimal(retVal.ToString());
    }
    public String GetTotalMaterialQtyForEstimation(Int32 EstNum, Int32 submatid)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select isNull(SUM(Convert(float,b.Qty)),0) as pWO from Project_Materials a INNER JOIN Project_workorder_materials b on a.EstNum = b.EstNum and a.submatid = b.sub_mat_id  Where b.EstNum = @EstNum and a.submatid = @submatid ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        db.AddInParameter(dbCommand, "@submatid", DbType.Int32, submatid);
        object retVal = db.ExecuteScalar(dbCommand);
        return retVal.ToString();
    }

    public String GetContengency(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select ISNULL(Contengency,0.0) Contengency from ProjectInfo  Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        return retVal.ToString();
    }

    public Decimal GetProfitMarkUp(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select ISNULL(profit_markup,1.0) Contengency from ProjectInfo  Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        return Convert.ToDecimal(retVal);
    }

    public Decimal GetOverHeadPercent(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select ISNULL(Overhead_percent,1.0) Contengency from ProjectInfo  Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        return Convert.ToDecimal(retVal);
    }

    public Boolean PopulateMaterialinWorkOrder(Int32 EstNum, String work_order_id, Int32 sub_mat_id)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_workorder_materials(EstNum, work_order_id,sub_mat_id,Qty) Values (@EstNum,@work_order_id, @sub_mat_id,@Qty)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
            db.AddInParameter(dbCommand, "@sub_mat_id", DbType.Int32, sub_mat_id);
            db.AddInParameter(dbCommand, "@Qty", DbType.String, "1");
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

    public Boolean DELETEMaterialinWorkOrder(Int32 EstNum, String work_order_id, Int32 sub_mat_id)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_workorder_materials WHERE EstNum = @EstNum AND Work_order_id = @work_order_id AND sub_mat_id = @sub_mat_id  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
            db.AddInParameter(dbCommand, "@sub_mat_id", DbType.Int32, sub_mat_id);
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

    public Boolean DELETEMaterialinWorkOrder(Int32 EstNum, String work_order_id)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_workorder_materials WHERE EstNum = @EstNum AND Work_order_id = @work_order_id  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
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

    public Boolean DELETEMaterialinWorkOrder(Int32 EstNum, Int32 sub_mat_id)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Project_workorder_materials WHERE EstNum = @EstNum AND sub_mat_id = @sub_mat_id  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_mat_id", DbType.Int32, sub_mat_id);
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

    public Boolean UPDATEMaterialinWorkOrder(Int32 EstNum, String work_order_id, Int32 sub_mat_id, String Qty)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Project_workorder_materials SET Qty = @Qty WHERE EstNum = @EstNum AND Work_order_id = @work_order_id AND sub_mat_id = @sub_mat_id  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, work_order_id);
            db.AddInParameter(dbCommand, "@sub_mat_id", DbType.Int32, sub_mat_id);
            db.AddInParameter(dbCommand, "@Qty", DbType.String, Qty);
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

    //Estimate Sub Material Management



        //Sub Material Adminstration
    //material_id, thickness,length,weight,width,Description,Cost,UOM,Manufacturer,LEED,FSC,Material_Code,Notes
    //mat_type, Reference_Number,Description,Manufacturer,LEED,Comments
        //[Primary Material Type]: [Material Type] – [Description], [UOM] – [Thickness] x [Width] x [Length]; LEED=[N/Y]
        //Example:
        //Solid Lumber: Walnut – S4S American Walnut, LF - .75 x 3.5 x 96; LEED=N

        //Mat_type_Desc
        //Reference_Number
        //Description
        //UOM
        //LEED

    public DataSet GetAllSubMaterials(String mat_type_code)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            //String sqlCommand = " SELECT  a.*,b.uom_type_desc,c.Mat_type_Desc + ':' + c.Reference_Number + '-' +  c.description + ',' + b.uom_type + '(' + a.thickness + 'X' + a.length + 'X' + a.width+ ')+LEED=' + a.LEED  matdesc from Sub_materials a INNER JOIN UOM_TYPE b  ON a.UOM = b.uom_type_id INNER JOIN master_materials c on a.material_id = c.material_id";
            String sqlCommand = " SELECT  a.*,b.uom_type_desc,d.Mat_type_Desc + ':' + c.Reference_Number + '-' +  a.description + ', ' + b.uom_type_desc + ' (' + a.thickness + 'X' + a.length + 'X' + a.width+ ') ;LEED=' + a.LEED  matdesc from Sub_materials a INNER JOIN UOM_TYPE b  ON a.UOM = b.uom_type_id INNER JOIN master_materials c on a.material_id = c.material_id  " +
                                    " INNER JOIN Master_material_type d ON c.mat_type = d.Mat_type_id  WHERE 1=1 ";
            if (mat_type_code != "0")
            {
                sqlCommand = sqlCommand + " AND c.mat_type = " + Convert.ToInt32(mat_type_code);
            }

            sqlCommand = sqlCommand + "order by d.Mat_type_id asc ";
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

    public DataSet GetAllSubMaterials(String mat_type_code,String dType)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            //String sqlCommand = " SELECT  a.*,b.uom_type_desc,c.Mat_type_Desc + ':' + c.Reference_Number + '-' +  c.description + ',' + b.uom_type + '(' + a.thickness + 'X' + a.length + 'X' + a.width+ ')+LEED=' + a.LEED  matdesc from Sub_materials a INNER JOIN UOM_TYPE b  ON a.UOM = b.uom_type_id INNER JOIN master_materials c on a.material_id = c.material_id";
           // sub_mat_id material_id thickness length width Description Cost UOM Manufacturer LEED FSC Material_Code Notes weight Default_Field 
            String sqlCommand = " SELECT DISTINCT d.Mat_type_id,a.sub_mat_id,a.material_id, b.uom_type_desc,d.Mat_type_Desc, c.Reference_Number, a.description, b.uom_type_desc, a.thickness ,a.length,a.width, a.LEED  FROM Sub_materials a INNER JOIN UOM_TYPE b  ON a.UOM = b.uom_type_id INNER JOIN master_materials c on a.material_id = c.material_id  " +
                                " INNER JOIN Master_material_type d ON c.mat_type = d.Mat_type_id  WHERE 1=1 ";
            if (mat_type_code != "0")
            {
                sqlCommand = sqlCommand + " AND c.mat_type = " + Convert.ToInt32(mat_type_code);
            }

            sqlCommand = sqlCommand + " order by d.Mat_type_id ASC ";
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

    public DataSet GetAllSubMaterials(Int32 material_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT a.*,b.uom_type_desc from Sub_materials a INNER JOIN UOM_TYPE b ON a.UOM = b.uom_type_id Where a.material_id = @material_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@material_id", DbType.Int32, material_id);
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

    //[thickness] [int] NULL,
    //[length] [int] NULL,
    //[width] [int] NULL,
    //[Description] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    //[Cost] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    //[UOM] [int] NULL,

    public Boolean PopulateSubMaterials(Int32 material_id, String thickness, String length, String weight, String width, String Description, String cost, Int32 EOM, String LEED, String Manufact, String FSC, String MatCode, String Comments, String Default_Field)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Sub_materials(material_id, thickness,length,weight,width,Description,Cost,UOM,Manufacturer,LEED,FSC,Material_Code,Notes,Default_Field) Values (@material_id, @thickness,@length,@weight,@width,@Description,@cost,@EOM,@Manufact,@LEED,@FSC,@MatCode,@Comments,@Default_Field)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@material_id", DbType.Int32, material_id);
            db.AddInParameter(dbCommand, "@thickness", DbType.String, thickness);
            db.AddInParameter(dbCommand, "@length", DbType.String, length);
            db.AddInParameter(dbCommand, "@weight", DbType.String, weight);
            db.AddInParameter(dbCommand, "@width", DbType.String, width);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@cost", DbType.String, cost);
            db.AddInParameter(dbCommand, "@EOM", DbType.Int32, EOM);
            //New Fields Added
            db.AddInParameter(dbCommand, "@LEED", DbType.String, LEED);
            db.AddInParameter(dbCommand, "@Manufact", DbType.String, Manufact);
            db.AddInParameter(dbCommand, "@FSC", DbType.String, FSC);
            db.AddInParameter(dbCommand, "@MatCode", DbType.String, MatCode);
            db.AddInParameter(dbCommand, "@Comments", DbType.String, Comments);
            db.AddInParameter(dbCommand, "@Default_Field", DbType.String, Default_Field);
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

    public Boolean UPDATESubMaterials(Int32 submat_id, String thickness, String length, String weight, String width, String Description, String cost, Int32 UOM, String LEED, String Manufact, String FSC, String MatCode, String Comments, String Default_Field)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Sub_materials SET thickness = @thickness ,length=@length,weight=@weight,width=@width,Description=@Description,cost=@cost,UOM=UOM,Manufacturer=@Manufact,LEED=@LEED,FSC=@FSC,Material_Code=@MatCode,Notes=@Comments,Default_Field=@Default_Field WHERE  sub_mat_id = @submat_id ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@submat_id", DbType.Int32, submat_id);
            db.AddInParameter(dbCommand, "@thickness", DbType.String, thickness);
            db.AddInParameter(dbCommand, "@length", DbType.String, length);
            db.AddInParameter(dbCommand, "@weight", DbType.String, weight);
            db.AddInParameter(dbCommand, "@width", DbType.String, width);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@cost", DbType.String, cost);
            db.AddInParameter(dbCommand, "@UOM", DbType.Int32, UOM);
            //New Fields Added
            db.AddInParameter(dbCommand, "@LEED", DbType.String, LEED);
            db.AddInParameter(dbCommand, "@Manufact", DbType.String, Manufact);
            db.AddInParameter(dbCommand, "@FSC", DbType.String, FSC);
            db.AddInParameter(dbCommand, "@MatCode", DbType.String, MatCode);
            db.AddInParameter(dbCommand, "@Comments", DbType.String, Comments);
            db.AddInParameter(dbCommand, "@Default_Field", DbType.String, Default_Field);
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

    public Boolean DeleteSubMaterials(Int32 submat_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand1 = " DELETE Sub_materials Where sub_mat_id = " + submat_id;
            DbCommand dbCommand1 = db.GetSqlStringCommand(sqlCommand1);
            db.ExecuteNonQuery(dbCommand1);
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public Boolean DeleteSubMaterialsFromEstimation(Int32 EstNum,Int32 submat_id)
    {
        //Project_materials(EstNum, submatid)
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand1 = " DELETE Project_materials Where EstNum = @EstNum AND submatid=@submat_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand1);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@submat_id", DbType.Int32, submat_id);
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
    //Ends Sub Material Adminstration

    public Boolean PopulateMaterialinEstimation(Int32 EstNum, Int32 sub_mat_id)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_materials (EstNum,submatid,price,Verified,Purchased,Received) Values (@EstNum,@sub_mat_id,@price,'N','N','N')  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_mat_id", DbType.Int32, sub_mat_id);
            db.AddInParameter(dbCommand, "@price", DbType.String, GetPriceForMaterial(sub_mat_id));
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

    public Boolean IsMaterialExistsInEstimate(Int32 EstNum, Int32 sub_mat_id)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*) FROM [Project_materials] WHERE EstNum = @EstNum AND submatid=@sub_mat_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_mat_id", DbType.Int32, sub_mat_id);
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


    public Boolean PopulateStandardMaterial(Int32 EstNum)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_materials(EstNum,submatid,price,Verified,Purchased,Received) " +
                                " SELECT  @EstNum,a.sub_mat_id,IsNull(a.cost,'0'),'N','N','N'  from Sub_materials a INNER JOIN UOM_TYPE b  ON a.UOM = b.uom_type_id INNER JOIN master_materials c on a.material_id = c.material_id WHERE a.LEED = 'N' AND  a.Default_Field = 'Y' ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public Boolean PopulateLEEDMaterial(Int32 EstNum)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_materials(EstNum,submatid,price,Verified,Purchased,Received) " +
                                " SELECT  @EstNum,a.sub_mat_id,IsNull(a.cost,'0'),'N','N','N'  from Sub_materials a INNER JOIN UOM_TYPE b  ON a.UOM = b.uom_type_id INNER JOIN master_materials c on a.material_id = c.material_id WHERE a.LEED = 'Y' AND " +
                                "   a.Default_Field = 'Y'  " +
                                "   UNION " +
                                "   SELECT  @EstNum,a.sub_mat_id,IsNull(a.cost,'0'),'N','N','N'  from Sub_materials a INNER JOIN UOM_TYPE b  ON a.UOM = b.uom_type_id INNER JOIN master_materials c on a.material_id = c.material_id WHERE a.LEED = 'N' AND " +
                                "   a.Default_Field = 'Y'  AND c.mat_type =2";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    


    public Boolean UpdateMaterialinEstimation(Int32 EstNum, Int32 sub_mat_id, String price, String matnotes, String Verified, String Purchased, String Received)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Project_materials  SET price = @price,matnotes=@matnotes,Verified=@Verified,Purchased=@Purchased,Received=@Received WHERE EstNum = @EstNum AND submatid = @sub_mat_id  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@sub_mat_id", DbType.Int32, sub_mat_id);
            db.AddInParameter(dbCommand, "@price", DbType.String, price);
            db.AddInParameter(dbCommand, "@matnotes", DbType.String, matnotes);
            db.AddInParameter(dbCommand, "@Verified", DbType.String, Verified);
            db.AddInParameter(dbCommand, "@Purchased", DbType.String, Purchased);
            db.AddInParameter(dbCommand, "@Received", DbType.String, Received);
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

    public DataSet GetAllUOM_TYPES()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT * from UOM_TYPE ";

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

    #region Schedule Logic

    public DataSet GetScheduleData(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select Hours,weeklyNotes,isnull(project_amount,0) project_amount FROM [twc_project_productionschedule] WHERE twc_proj_number = @twc_proj_number AND fycd = @fycd AND yearmonth =  @yearmonth AND week_number = @WeekNumber";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
            db.AddInParameter(dbCommand, "@fycd", DbType.String, fycd);
            db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
            db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
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

    public DataSet GetScheduleListing(String twc_project_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "usp_GetCrosstabReport";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, Convert.ToInt32(twc_project_number));
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

    public DataSet GetCummululativeProjectSchedule()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "usp_GetCummulativeCrosstabReport1";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
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

    public DataSet GetCummululativeProjectWeeklySchedule(String year, String yearmonth)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "usp_GetCummulativeWeeklyCrosstabReport1";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@year", DbType.String, year);
            db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
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

    public DataSet GetSchedule(String DateStart, String @DateEnd)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = "usp_SetupSchedule";

            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@DateStart", DbType.String, DateStart);
            db.AddInParameter(dbCommand, "@DateEnd", DbType.String, DateEnd);
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

    public DataSet GetWeeks()
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT week_number,week_name from tbl_fiscalweek   order by week_number asc ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
        
    }

    public Hashtable GetWeeksHash()
    {
        Hashtable hTable = new Hashtable();
        hTable.Add("WEEK 1", "WEEK 1");
        hTable.Add("WEEK 2", "WEEK 2");
        hTable.Add("WEEK 3", "WEEK 3");
        hTable.Add("WEEK 4", "WEEK 4");
        hTable.Add("WEEK 5", "WEEK 5");
        return hTable;
    }
     
    public DataSet GetMonths()
    {
        //SELECT [month_number],[month_name] from [whitfielddb].[dbo].[tbl_fiscalmonth] 
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT [month_number],[month_name] from [whitfielddb].[dbo].[tbl_fiscalmonth] order by [month_number] asc ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
        //Hashtable hTable = new Hashtable();
        //hTable.Add("January", "January");
        //hTable.Add("February", "February");
        //hTable.Add("March", "March");
        //hTable.Add("April", "April");
        //hTable.Add("May", "May");
        //hTable.Add("June", "June");
        //hTable.Add("July", "July");
        //hTable.Add("August", "August");
        //hTable.Add("September", "September");
        //hTable.Add("October", "October");
        //hTable.Add("November", "November");
        //hTable.Add("December", "December");
        //return hTable;
    }

    public DataSet GetYear()
    {
        //SELECT [fycd],[fycd_Desc] from [whitfielddb].[dbo].[tbl_fiscalyear] 
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT [fycd],[fycd_Desc] from [whitfielddb].[dbo].[tbl_fiscalyear] order by [fycd] asc ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;

        //Hashtable hTable = new Hashtable();
        //hTable.Add("2010", "2010");
        //hTable.Add("2011", "2011");
        //hTable.Add("2012", "2012");
        //hTable.Add("2013", "2013");
        //hTable.Add("2014", "2014");
        //return hTable;
    }

    public DataSet GetNotes(Int32 twc_proj_number)
    {
        //SELECT [fycd],[fycd_Desc] from [whitfielddb].[dbo].[tbl_fiscalyear] 
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT yearmonth,week_number,weeklyNotes from  twc_project_productionschedule  WHERE twc_proj_number = @twc_proj_number and ISNULL(weeklyNotes,'') <> '' order by [sequence] asc ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

    public Boolean IsScheduleExists(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*) FROM [twc_project_productionschedule] WHERE twc_proj_number = @twc_proj_number AND fycd = @fycd AND yearmonth =  @yearmonth AND week_number = @WeekNumber";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
            db.AddInParameter(dbCommand, "@fycd", DbType.String, fycd);
            db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
            db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
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

    
    public Boolean IsScheduleDataExists(Int32 twc_proj_number)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select isnull(count(*),0) FROM [twc_project_productionschedule] WHERE twc_proj_number = @twc_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
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

   


    public Boolean PopulateSchedule(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber, Int32 sequence, String project_amount)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsScheduleExists(twc_proj_number, fycd, yearmonth, WeekNumber))
            {
 
                String insTerms = "INSERT INTO twc_project_productionschedule(twc_proj_number,fycd,yearmonth,week_number,sequence,Hours,weeklyNotes,project_amount) VALUES (@twc_proj_number,@fycd,@yearmonth,@WeekNumber,@sequence,@Hours,@weeklyNotes,@project_amount)";
                DbCommand dbCommand = db.GetSqlStringCommand(insTerms);
                db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
                db.AddInParameter(dbCommand, "@fycd", DbType.String, fycd);
                db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
                db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
                db.AddInParameter(dbCommand, "@sequence", DbType.Int32, sequence);
                db.AddInParameter(dbCommand, "@Hours", DbType.String, 0);
                db.AddInParameter(dbCommand, "@weeklyNotes", DbType.String, "");
                db.AddInParameter(dbCommand, "@project_amount", DbType.Decimal, project_amount);
                
                db.ExecuteNonQuery(dbCommand);
            }
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public Boolean MaintainScheduledata(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber, Int32 Hours, String _notes, Int32 TotalFabHours, String project_amount)
    {
        try
        {
            Boolean validDataEntry = false;
            Database db = DatabaseFactory.CreateDatabase();
            if (IsScheduleExists(twc_proj_number, fycd, yearmonth, WeekNumber))
            {

                Int32 TotalScheduledHours = Convert.ToInt32(GetTotalscheduledHours(twc_proj_number)) + Hours;
                Boolean IsValid = ((TotalFabHours - TotalScheduledHours) >= 0) ? true : false;
                if (IsValid)
                {
                    String updTerms = "UPDATE twc_project_productionschedule SET Hours=@Hours,weeklyNotes=@weeklyNotes,project_amount=@project_amount WHERE twc_proj_number=@twc_proj_number AND yearmonth=@yearmonth AND week_number=@WeekNumber";
                    DbCommand dbCommand = db.GetSqlStringCommand(updTerms);

                    db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
                    db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
                    db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
                    db.AddInParameter(dbCommand, "@Hours", DbType.Int32, Hours);
                    db.AddInParameter(dbCommand, "@weeklyNotes", DbType.String, _notes);
                    db.AddInParameter(dbCommand, "@project_amount", DbType.Decimal, project_amount);
                    
                    db.ExecuteNonQuery(dbCommand);
                    validDataEntry = true;
                }
                else
                {
                    validDataEntry = false;
                }
            }
            return validDataEntry;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public String GetTotalscheduledHours(Int32 TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select isnull(sum(hours),0) from twc_project_productionschedule " +
                            "  WHERE  twc_proj_number = @TWC_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
        object retVal = db.ExecuteScalar(dbCommand);
        if (retVal == null)
        {
            return "0";
        }
        else
        {
            if (Convert.ToInt32(retVal.ToString()) > 0)
            {
                return retVal.ToString();
            }
            else
            {
                return "0";
            }
        }
    }
    #endregion Schedule Logic



    #region CashFlow Schedule Module

    public DataSet GetScheduleDataForCashFlow(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select weeklyNotes,isnull(project_amount,0) project_amount FROM [twc_project_CashFlowschedule] WHERE twc_proj_number = @twc_proj_number AND fycd = @fycd AND yearmonth =  @yearmonth AND week_number = @WeekNumber";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
            db.AddInParameter(dbCommand, "@fycd", DbType.String, fycd);
            db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
            db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
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


    public DataSet GetCashflowListing(String twc_project_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "usp_GetCrosstabReportForProjectedAmount";  
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_project_number", DbType.Int32, Convert.ToInt32(twc_project_number));
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

    public String GetTotalscheduledCashFlow(Int32 TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select isnull(sum(project_amount),0) from twc_project_CashFlowschedule " +
                            "  WHERE  twc_proj_number = @TWC_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
        object retVal = db.ExecuteScalar(dbCommand);
        if (retVal == null)
        {
            return "0.0";
        }
        else
        {
            if (Convert.ToDecimal(retVal.ToString()) > 0)
            {
                return retVal.ToString();
            }
            else
            {
                return "0.0";
            }
        }
    }

    public Boolean IsCashFlowScheduleDataExists(Int32 twc_proj_number)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select isnull(count(*),0) FROM [twc_project_CashFlowschedule] WHERE twc_proj_number = @twc_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
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

    public Boolean IsCashFlowScheduleExists(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*) FROM [twc_project_CashFlowschedule] WHERE twc_proj_number = @twc_proj_number AND fycd = @fycd AND yearmonth =  @yearmonth AND week_number = @WeekNumber";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
            db.AddInParameter(dbCommand, "@fycd", DbType.String, fycd);
            db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
            db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
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

    public Boolean MaintainCashFlowScheduledata(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber,  String _notes, String project_amount)
    {
        try
        {
            Boolean validDataEntry = false;
            Database db = DatabaseFactory.CreateDatabase();
            if (IsCashFlowScheduleExists(twc_proj_number, fycd, yearmonth, WeekNumber))
            {
                
               // Decimal TotalScheduledPaymentAmount = Convert.ToDecimal(GetTotalscheduledCashFlow(twc_proj_number));
                Boolean IsValid = ((GetCurrentContractValue(twc_proj_number) - Convert.ToDecimal(GetTotalscheduledCashFlow(twc_proj_number))) >= 0) ? true : false;
                //200190.00  - 108034
                if (IsValid)
                {
                    String updTerms = "UPDATE twc_project_CashFlowschedule SET weeklyNotes=@weeklyNotes,project_amount=@project_amount WHERE twc_proj_number=@twc_proj_number AND yearmonth=@yearmonth AND week_number=@WeekNumber";
                    DbCommand dbCommand = db.GetSqlStringCommand(updTerms);

                    db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
                    db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
                    db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
                    db.AddInParameter(dbCommand, "@weeklyNotes", DbType.String, _notes);
                    db.AddInParameter(dbCommand, "@project_amount", DbType.Decimal, project_amount);
                    db.ExecuteNonQuery(dbCommand);
                    validDataEntry = true;
                }
                else
                {
                    validDataEntry = false;
                }
            }
            return validDataEntry;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }

    public void RemoveCashFlowScheduledata(Int32 twc_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String DeleteScedule = "DELETE twc_project_CashFlowschedule WHERE twc_proj_number=@twc_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(DeleteScedule);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public Boolean PopulateCashFlowSchedule(Int32 twc_proj_number, String fycd, String yearmonth, String WeekNumber, Int32 sequence)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsCashFlowScheduleExists(twc_proj_number, fycd, yearmonth, WeekNumber))
            {
                String insTerms = "INSERT INTO twc_project_CashFlowschedule(twc_proj_number,fycd,yearmonth,week_number,sequence,weeklyNotes,project_amount) VALUES (@twc_proj_number,@fycd,@yearmonth,@WeekNumber,@sequence,@weeklyNotes,@project_amount)";
                DbCommand dbCommand = db.GetSqlStringCommand(insTerms);
                db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
                db.AddInParameter(dbCommand, "@fycd", DbType.String, fycd);
                db.AddInParameter(dbCommand, "@yearmonth", DbType.String, yearmonth);
                db.AddInParameter(dbCommand, "@WeekNumber", DbType.String, WeekNumber);
                db.AddInParameter(dbCommand, "@sequence", DbType.Int32, sequence);
                db.AddInParameter(dbCommand, "@weeklyNotes", DbType.String, "");
                db.AddInParameter(dbCommand, "@project_amount", DbType.Decimal, 0);

                db.ExecuteNonQuery(dbCommand);
            }
            return true;
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return false;
        }
    }
    public DataSet GetCashFlowNotes(Int32 twc_proj_number)
    {

        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " SELECT yearmonth,week_number,weeklyNotes from  twc_project_CashFlowschedule  WHERE twc_proj_number = @twc_proj_number and ISNULL(weeklyNotes,'') <> '' order by [sequence] asc ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

    public Decimal GetCurrentContractValue(Int32 twc_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select (CAST(ISNULL(O_Contract_Value,0) as decimal) + CAST(ISNULL(Change_Order_Value,0) as decimal)) as C_Contract_Value from Whitfield_ProjectInfo  Where  twc_proj_number = @twc_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
        object retVal = db.ExecuteScalar(dbCommand);
        return Convert.ToDecimal(retVal);
    }
    #endregion CashFlow Schedule Module

    #region Distribution List Maintenance
    public DataSet GetLeftDistributionList(Int32 estNum, Int32 twc_proj_number)
    {

        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select FirstName + ' ' + LastName as UName, email_address as Email from [User] Where " +
                            " email_address not in (select Email from whitfield_distributionlist Where twc_project_number = @twc_proj_number) " + 
                            " UNION " + 
                            " select First + ' ' + Last as UName, Email  from Contacts  " +
                            " Where Email not in (select Email from whitfield_distributionlist Where twc_project_number = @twc_proj_number) " + 
                            " AND ClientID = (select WinClient from ProjectInfo Where EstNum = @estNum) ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
        db.AddInParameter(dbCommand, "@estNum", DbType.Int32, estNum);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

    public DataSet GetRightDistributionList(Int32 twc_proj_number)
    {

        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select Email UName,Email from whitfield_distributionlist Where twc_project_number = @twc_proj_number ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
        DataSet IDataset = db.ExecuteDataSet(dbCommand);
        return IDataset;
    }

    public void DeleteRight(Int32 twc_proj_number,String EmailAddress)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String DeleteScedule = " DELETE FROM whitfield_distributionlist WHERE Email=@Email AND twc_project_number=@twc_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(DeleteScedule);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
            db.AddInParameter(dbCommand, "@Email", DbType.String, EmailAddress);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void InsertRight(Int32 twc_proj_number, String EmailAddress)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String DeleteScedule = " INSERT INTO whitfield_distributionlist VALUES (@twc_proj_number,@Email) ";
            DbCommand dbCommand = db.GetSqlStringCommand(DeleteScedule);
            db.AddInParameter(dbCommand, "@twc_proj_number", DbType.Int32, twc_proj_number);
            db.AddInParameter(dbCommand, "@Email", DbType.String, EmailAddress);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    #endregion



    //***********************Conversation Email Log for the Project *****************************
    public DataSet GetEmailConversationLogforProject(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * FROM [Project_mail_log] WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
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

    public Boolean InsertEmailConversation(Int32 EstNum, String _userid, String username,  String _commentsDate, String _commentsTime,String _comments)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Project_mail_log(EstNum, seq_no, LastModifiedBy,emailid,LastModifiedDate,LastModifiedTime,comments) Values (@EstNum,@seqid, @username,@userid,@commentsDate,@commentsTime,@comments)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@seqid", DbType.Int32, GenerateEmailseqNumber(EstNum, _userid));
            db.AddInParameter(dbCommand, "@userid", DbType.String, _userid);
            db.AddInParameter(dbCommand, "@username", DbType.String, username);
            db.AddInParameter(dbCommand, "@commentsDate", DbType.String, _commentsDate);
            db.AddInParameter(dbCommand, "@commentsTime", DbType.String, _commentsTime);
            db.AddInParameter(dbCommand, "@comments", DbType.String, "Emailed " + _comments);
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

    public Int32 GenerateEmailseqNumber(Int32 EstNum, String _userid)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(seq_no),0) seqID from Project_mail_log Where EstNum = @EstNum AND emailid = @emailid";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        db.AddInParameter(dbCommand, "@emailid", DbType.String, _userid);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString()) + 1;
        }
        else
        {
            return 1;
        }
    }
    //*************************************************************************************

}
 