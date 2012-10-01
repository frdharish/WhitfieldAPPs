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
/// Summary description for Whitfield_Project
/// </summary>
public class Whitfield_Project
{
	public Whitfield_Project()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet GetGeneralConditions(Int32 EstNum, Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*  from Whitfield_Project_Qualificaton a, LU_Qualification b Where a.qual_id = b.qual_id AND b.qual_type_id = 1 AND  EstNum = @EstNum and TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
    public DataSet GetSpecExcl(Int32 EstNum, Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*  from Whitfield_Project_Qualificaton a, LU_Qualification b Where a.qual_id = b.qual_id AND b.qual_type_id = 2 AND  EstNum = @EstNum  and TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public DataSet GetTerms(Int32 EstNum, Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*  from Whitfield_Project_consideration a, LU_Consideration b Where a.con_id = b.con_id AND b.Con_type_id = 1 AND  EstNum = @EstNum  and TWC_proj_number=@TWC_proj_number ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
    public DataSet GetIntTerms(Int32 EstNum, Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select a.*  from Whitfield_Project_consideration a, LU_Consideration b Where a.con_id = b.con_id AND b.Con_type_id = 2 AND  EstNum = @EstNum   and TWC_proj_number=@TWC_proj_number ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public IDataReader GetProjectInfo(Int32 EstNum, Int32 TWC_proj_number)
    {
        try
        {   //Init_Payment_Date,Final_Payment_Date,Payment_point_of_contact
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT EstNum,client_proj_number,contract_number " +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate,BidTime" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,C_Contract_Value " + 
                                "   ,O_Contract_Value " +
                                "   ,Change_Order_Value,Init_Payment_Date,Final_Payment_Date,Payment_point_of_contact" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                 "  ,ISNULL(MatContCost,0) MatContCost " +
                                "   ,ISNULL(OverheadCost,0) OverheadCost " +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(FinalPrice,0) FinalPrice" +
                                "   ,ISNULL(BaseBid,0) BaseBid " +
                                "   ,Negotiated" +
                                "   ,Architect" +
                                "   ,LEED" +
                                "   ,Is_MD_Sales_Tax" +
                                "   ,loginid,Real_proj_Number" +
                                "    FROM [Whitfielddb].[dbo].[Whitfield_ProjectInfo] WHERE EstNum = @EstNum   and TWC_proj_number=@TWC_proj_number ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
            String sqlCommand = " SELECT EstNum " +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                 "  ,C_Contract_Value " +
                                "   ,O_Contract_Value " +
                                "   ,Change_Order_Value,Init_Payment_Date,Final_Payment_Date,Payment_point_of_contact" +
                                "   ,ISNULL(MatContCost,0) MatContCost " +
                                "   ,ISNULL(OverheadCost,0) OverheadCost " +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(FinalPrice,0) FinalPrice" +
                                "   ,ISNULL(BaseBid,0) BaseBid " +
                                "   ,Negotiated" +
                                "   ,Architect" +
                                "   ,LEED" +
                                "   ,Is_MD_Sales_Tax,FirstName + ' ' + LastName as Estimator,Real_proj_Number " +
                                "   ,ProjectInfo.loginid,ltrim(rtrim(replace(replace(baseBid,'$',''),',',''))) fmtBaseBid, ltrim(rtrim(replace(replace(FinalPrice,'$',''),',',''))) fmtFinalPrice" +
                                "    FROM Whitfield_ProjectInfo LEFT JOIN [user] on ProjectInfo.Loginid = [user].loginid WHERE  1=1 ";

            if (projStatus != "")
            {
                sqlCommand = sqlCommand + " AND Status IN (" + projStatus + ")";
            }

            if (role_id.Equals("2"))
            {
                sqlCommand = sqlCommand + " AND ProjectInfo.loginid = '" + _userid + "'";
            }

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
            String sqlCommand = " SELECT EstNum ,TWC_proj_number" +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                "   ,C_Contract_Value " +
                                "   ,O_Contract_Value " +
                                "   ,Change_Order_Value,Init_Payment_Date,Final_Payment_Date,Payment_point_of_contact" +
                                "   ,ISNULL(MatContCost,0) MatContCost " +
                                "   ,ISNULL(OverheadCost,0) OverheadCost " +
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
                                "    FROM Whitfield_ProjectInfo LEFT JOIN [user] on ProjectInfo.Loginid = [user].loginid WHERE 1=1 ";

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
            String sqlCommand = " SELECT EstNum ,TWC_proj_number" +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                "   ,C_Contract_Value " +
                                "   ,O_Contract_Value " +
                                "   ,Change_Order_Value,Init_Payment_Date,Final_Payment_Date,Payment_point_of_contact" +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(FinalPrice,0) FinalPrice" +
                                "   ,ISNULL(BaseBid,0) BaseBid " +
                                "   ,ISNULL(MatContCost,0) MatContCost " +
                                "   ,ISNULL(OverheadCost,0) OverheadCost " +
                                "   ,Negotiated" +
                                "   ,Architect" +
                                "   ,LEED" +
                                "   ,Is_MD_Sales_Tax" +
                                "   ,[user].loginid,FirstName + ' ' + LastName as Estimator,Real_proj_Number " +
                                "   ,ltrim(rtrim(replace(replace(baseBid,'$',''),',',''))) fmtBaseBid, ltrim(rtrim(replace(replace(FinalPrice,'$',''),',',''))) fmtFinalPrice" +
                                "   ,(select pInfo.fab_start from ProjectInfo pInfo WHERE pInfo.EstNum = [Whitfielddb].[dbo].[Whitfield_ProjectInfo].EstNum) fab_start " +
                                "   ,(select pInfo.fab_end from ProjectInfo pInfo WHERE pInfo.EstNum = [Whitfielddb].[dbo].[Whitfield_ProjectInfo].EstNum) fab_end " +
                                "   ,( select ISNULL(sum(isnull(b.install_hours,0)),0)  from   whitfield_Project_workorder  b where [Whitfielddb].[dbo].[Whitfield_ProjectInfo].EstNum = b.EstNum)  install_hours    " +
                                "   ,( select  ISNULL(sum(isnull(b.fab_hours,0) + isnull(b.Fin_hours,0)),0)  from   whitfield_Project_workorder  b where [Whitfielddb].[dbo].[Whitfield_ProjectInfo].EstNum = b.EstNum) fab_hours  " + 
                                //"   ,( select  ISNULL(sum(isnull(b.fab_hours,0)),0)  from   whitfield_Project_workorder  b where [Whitfielddb].[dbo].[Whitfield_ProjectInfo].EstNum = b.EstNum) fab_hours  " + 
                                "    FROM [Whitfielddb].[dbo].[Whitfield_ProjectInfo]  LEFT JOIN [user] on Whitfield_ProjectInfo.Loginid = [user].loginid " + 
                                "    WHERE  1=1 AND Status = 5";
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

    public DataSet GetInsallerAssignedProjects(Int32 Userid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT EstNum ,Whitfield_ProjectInfo.TWC_proj_number" +
                                "   ,ProjName" +
                                "   ,ProjDescr" +
                                "   ,Notes" +
                                "   ,ProjType" +
                                "   ,BidDate" +
                                "   ,AwardDate" +
                                "   ,AwardDur" +
                                "   ,ConstrStart" +
                                "   ,ConstrDur" +
                                "   ,ConstrCompl" +
                                "   ,GC1" +
                                "   ,Status" +
                                "   ,C_Contract_Value " +
                                "   ,O_Contract_Value " +
                                "   ,Change_Order_Value,Init_Payment_Date,Final_Payment_Date,Payment_point_of_contact" +
                                "   ,ClientType" +
                                "   ,WinClient" +
                                "   ,WinMill" +
                                "   ,ISNULL(FinalPrice,0) FinalPrice" +
                                "   ,ISNULL(BaseBid,0) BaseBid " +
                                "   ,Negotiated" +
                                "   ,Architect" +
                                "   ,LEED" +
                                "   ,Is_MD_Sales_Tax" +
                                "   ,[user].loginid,FirstName + ' ' + LastName as Estimator,Real_proj_Number " +
                                "   ,ltrim(rtrim(replace(replace(baseBid,'$',''),',',''))) fmtBaseBid, ltrim(rtrim(replace(replace(FinalPrice,'$',''),',',''))) fmtFinalPrice" +
                                "    FROM [Whitfielddb].[dbo].[Whitfield_ProjectInfo]  LEFT JOIN [user] on Whitfield_ProjectInfo.Loginid = [user].loginid INNER JOIN [Whitfielddb].[dbo].[Whitfield_Project_Installers] wpi ON Whitfield_ProjectInfo.TWC_proj_number = wpi.TWC_proj_number   WHERE  1=1 and wpi.Userid=@Userid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@Userid", DbType.Int32, Userid);
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

    public Boolean IsItemExists(Int32 EstNum , Int32 TWC_proj_number)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from Whitfield_ProjectInfo  Where  EstNum = @EstNum and TWC_proj_number = @TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public Boolean UpdateCostUpdates(String EstNum, String TWC_Proj_Number)
    {
        try
        {
            project_invoice _pi = new project_invoice();
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = "    UPDATE Whitfield_ProjectInfo SET " +
                                         "   [O_Contract_Value]    =   @O_Contract_Value  " +
                                         "   ,[Change_Order_Value]  =   @Change_Order_Value " +
                                         "   WHERE EstNum = @EstNum and TWC_proj_number=@TWC_proj_number";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, Convert.ToInt32(EstNum));
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, Convert.ToInt32(TWC_Proj_Number));
            db.AddInParameter(dbCommand, "@O_Contract_Value", DbType.String, _pi.GetOriginalContractValue(Convert.ToInt32(TWC_Proj_Number)).ToString());
            db.AddInParameter(dbCommand, "@Change_Order_Value", DbType.String, _pi.GetChangeOrderValue(Convert.ToInt32(TWC_Proj_Number)).ToString());
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


    public Boolean UpdateCostUpdates(String EstNum
                                    ,  String TWC_proj_number
                                    , String O_Contract_Value
                                    , String Change_Order_Value
                                    )
     {

        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (IsItemExists(Convert.ToInt32(EstNum),Convert.ToInt32(TWC_proj_number)))
            {
                sqlCommand = "    UPDATE Whitfield_ProjectInfo SET " +
                             "   [O_Contract_Value]    =   @O_Contract_Value  " +
                             "   ,[Change_Order_Value]  =   @Change_Order_Value " +
                             "   WHERE EstNum = @EstNum and TWC_proj_number=@TWC_proj_number";

                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, Convert.ToInt32(EstNum));
                db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
                //db.AddInParameter(dbCommand, "@C_Contract_Value", DbType.String, C_Contract_Value);
                db.AddInParameter(dbCommand, "@O_Contract_Value", DbType.String, O_Contract_Value);
                db.AddInParameter(dbCommand, "@Change_Order_Value", DbType.String, Change_Order_Value);
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


    public Boolean InsertEstimateMain(String EstNum
                                    ,  String TWC_proj_number
                                    , String projname
                                    , String projdesc
                                    , String notes
                                    , String projtype
                                   // , String biddate
                                   // , String bidtime
                                   // , String awddate
                                   // , String awddur
                                    , String constrstdt
                                    , String constrcompl
                                    , String constdur
                                    , String gc1
                                    , String status
                                    , String clienttype
                                   , String winclient
                                   // , String winmill
                                    , String finalprice
                                   // , String basebid
                                    , String nogotiated
                                    , String architect
                                    , String leed
                                    , String mdtax
                                   // , String loginid
                                    ,String clientprojNumber
                                    ,String ContractNumber
                                    ,String MatContCost
                                    , String OverheadCost)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsItemExists(Convert.ToInt32(EstNum),Convert.ToInt32(TWC_proj_number)))
            {
                sqlCommand = " INSERT INTO Whitfield_ProjectInfo (EstNum,TWC_proj_number " +
                                  "   ,ProjName" +
                                  "   ,ProjDescr" +
                                  "   ,Notes" +
                                  "   ,ProjType" +
                                  //"   ,BidDate" +
                                  //"   ,BidTime" +
                                  //"   ,AwardDate" +
                                  //"   ,AwardDur" +
                                  "   ,ConstrStart" +
                                  "   ,ConstrDur" +
                                  "   ,ConstrCompl" +
                                  "   ,GC1" +
                                  "   ,Status" +
                                  "   ,ClientType" +
                                  "   ,WinClient" +
                                  //"   ,WinMill" +
                                  "   ,FinalPrice" +
                                 // "   ,BaseBid" +
                                  "   ,Negotiated" +
                                  "   ,Architect" +
                                  "   ,LEED" +
                                  "   ,Is_MD_Sales_Tax,MatContCost,OverheadCost" +
                                 // "   ,loginid " +
                                  "   ) " + 
                                  "   VALUES (@EstNum " + 
                                  "   , @TWC_proj_number" +
                                  "   ,@ProjName   " +
                                  "   ,@ProjDescr" +
                                  "   ,@Notes" +
                                  "   ,@ProjType" +
                                  //"   ,@BidDate" +
                                  //"   ,@BidTime" +
                                  //"   ,@AwardDate" +
                                  //"   ,@AwardDur" +
                                  "   ,@ConstrStart" +
                                  "   ,@ConstrDur" +
                                  "   ,@ConstrCompl" +
                                  "   ,@GC1" +
                                  "   ,@Status" +
                                  "   ,@ClientType" +
                                  "   ,@WinClient" +
                                  //"   ,@WinMill" +
                                  "   ,@FinalPrice" +
                                 // "   ,@BaseBid" +
                                  "   ,@Negotiated" +
                                  "   ,@Architect" +
                                  "   ,@LEED" +
                                  "   ,@Is_MD_Sales_Tax,@MatContCost,@OverheadCost)";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE Whitfield_ProjectInfo SET " +
                        "  [ProjName] =   @ProjName  " +
                        "  ,[ProjDescr] =  @ProjDescr " +
                        "  ,[Notes]  =  @Notes " +
                        "  ,[ProjType] = @ProjType " +
                        //"  ,[BidDate]  =  @BidDate " +
                        //"  ,[BidTime]  =  @BidTime " +
                        //"  ,[AwardDate] =  @AwardDate " +
                        //"  ,[AwardDur] =  @AwardDur " +
                        "  ,[ConstrStart]=  @ConstrStart " +
                        "  ,[ConstrDur]  = @ConstrDur " +
                        "  ,[ConstrCompl] = @ConstrCompl " +
                        "  ,[GC1]  =   @GC1 " +
                        "  ,[Status]=  @Status " +
                        "  ,[ClientType]= @ClientType " +
                        "  ,[WinClient] = @WinClient " +
                        //"  ,[WinMill] = @WinMill " +
                        "  ,[FinalPrice]  = @FinalPrice " +
                        //"  ,[BaseBid]  = @BaseBid " +
                        "  ,[Negotiated]=   @Negotiated " +
                        "  ,[Architect]  = @Architect " +
                        "  ,[LEED]  = @LEED " +
                        "  ,[Is_MD_Sales_Tax] = @Is_MD_Sales_Tax,[client_proj_number]=@clientprojnumber ,[contract_number]=@contractNumber ,MatContCost=@MatContCost,OverheadCost=@OverheadCost" +
                        "   WHERE EstNum = @EstNum and TWC_proj_number=@TWC_proj_number";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, Convert.ToInt32(EstNum));
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32,TWC_proj_number);
            db.AddInParameter(dbCommand, "@ProjName", DbType.String, projname);
            db.AddInParameter(dbCommand, "@ProjDescr", DbType.String, projdesc);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "@ProjType", DbType.Int32, projtype);
            //db.AddInParameter(dbCommand, "@BidDate", DbType.String, biddate);
            //db.AddInParameter(dbCommand, "@BidTime", DbType.String, bidtime);
            //db.AddInParameter(dbCommand, "@AwardDate", DbType.String, awddate);
            //db.AddInParameter(dbCommand, "@AwardDur", DbType.String, awddur);
            db.AddInParameter(dbCommand, "@ConstrStart", DbType.String, constrstdt);
            db.AddInParameter(dbCommand, "@ConstrDur", DbType.String, constdur);
            db.AddInParameter(dbCommand, "@ConstrCompl", DbType.String, constrcompl);
            db.AddInParameter(dbCommand, "@GC1", DbType.String, gc1);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Convert.ToInt32(status));
            db.AddInParameter(dbCommand, "@ClientType", DbType.Int32, Convert.ToInt32(clienttype));
            db.AddInParameter(dbCommand, "@WinClient", DbType.Int32, Convert.ToInt32(winclient));
            //db.AddInParameter(dbCommand, "@WinMill", DbType.Int32, Convert.ToInt32(winmill));
            db.AddInParameter(dbCommand, "@FinalPrice", DbType.String, finalprice);
            //db.AddInParameter(dbCommand, "@BaseBid", DbType.String, basebid);
            db.AddInParameter(dbCommand, "@Negotiated", DbType.String, nogotiated);
            db.AddInParameter(dbCommand, "@Architect", DbType.Int32, Convert.ToInt32(architect));
            db.AddInParameter(dbCommand, "@LEED", DbType.String, leed);
            db.AddInParameter(dbCommand, "@Is_MD_Sales_Tax", DbType.String, mdtax);
            //db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
            db.AddInParameter(dbCommand, "@clientprojnumber", DbType.String, clientprojNumber);
            db.AddInParameter(dbCommand, "@contractNumber", DbType.String, ContractNumber);
            db.AddInParameter(dbCommand, "@MatContCost", DbType.String, MatContCost);
            db.AddInParameter(dbCommand, "@OverheadCost", DbType.String, OverheadCost);
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
    public DataSet GetClientlistForProject(String EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.ClientID,b.Name as Name1 from Project_Client a, clientinfo b Where a.ClientID = b.clientid and a.EstNum =" + EstNum + "  ORDER BY b.Name asc ";
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
    public DataSet GetCompetitors(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select b.compeId,a.Name as Name1 from Competition a, Whitfield_Project_Compe b WHERE a.compeId = b.compeId and b.EstNum =" + EstNum.ToString() + " AND b.TWC_proj_number = " + TWC_proj_number.ToString();
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

    public DataSet GetWorkOrders(String EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select *,   work_order_id + ' - ' + Description as woid from Whitfield_Project_workorder Where EstNum = '" + EstNum + "'";
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

    public DataSet GetWorkOrders(String EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * , Description + '(' + work_order_id + ')' as WODesc from Whitfield_Project_workorder Where EstNum = '" + EstNum + "' AND TWC_proj_number = " + TWC_proj_number.ToString();
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
    public void DeleteWorkOrders(String _woNumber, String TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_workorder WHERE work_order_id = @work_order_id AND TWC_proj_number= @TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, _woNumber);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.String, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public Boolean UpdateWorkorders(String WorkOrderID,Int32 EstNum, Int32 tot_mat_cost, String Description, Int32 fab_hours, Int32 fin_hours, Int32 Inst_hours, Int32 Eng_hours, Int32 misc_hours, String Notes, String isActive)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = " UPDATE Whitfield_Project_workorder SET " +
                               "            Description=@description, tot_mat_cost=@tot_mat_cost," +
                               "            fab_hours=@fab_hours, " +
                               "            fin_hours=@fin_hours, " +
                               "            install_hours=@install_hours, " +
                               "            eng_hours=@eng_hours, " +
                               "            misc_hours=@misc_hours, " +
                               "            Notes=@notes, " +
                               "            isActive=1" +
                               "            WHERE work_order_id = @work_order_id AND EstNum = @EstNum";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

            db.AddInParameter(dbCommand, "@EstNum", DbType.String, EstNum);
            db.AddInParameter(dbCommand, "@work_order_id", DbType.String, WorkOrderID);
            db.AddInParameter(dbCommand, "@description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@fab_hours", DbType.Int32, fab_hours);
            db.AddInParameter(dbCommand, "@fin_hours", DbType.Int32, fin_hours);
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, Inst_hours);
            db.AddInParameter(dbCommand, "@tot_mat_cost", DbType.Int32, tot_mat_cost);
            db.AddInParameter(dbCommand, "@eng_hours", DbType.Int32, Eng_hours);
            db.AddInParameter(dbCommand, "@misc_hours", DbType.Int32, misc_hours);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
            db.AddInParameter(dbCommand, "@isActive", DbType.String, isActive);
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

    public Boolean ManageWorkOrders(Int32 EstNum,Int32 TWC_proj_number, String Description,Int32 tot_mat_cost, Int32 fab_hours, Int32 fin_hours, Int32 Inst_hours, Int32 Eng_hours, Int32 misc_hours, String Notes, String isActive)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            sqlCommand = " INSERT INTO Whitfield_Project_workorder(work_order_id,tot_mat_cost,EstNum,TWC_proj_number,Description,fab_hours,fin_hours,install_hours,eng_hours,misc_hours,Notes,isActive) Values " +
                         " (@woid,@tot_mat_cost,@EstNum,@TWC_proj_number,@description,@fab_hours,@fin_hours,@install_hours,@eng_hours,@misc_hours,@notes,@isActive) ";


            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@woid", DbType.String, GenerateWO(EstNum, TWC_proj_number));
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@tot_mat_cost", DbType.Int32, tot_mat_cost);
            db.AddInParameter(dbCommand, "@description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@fab_hours", DbType.Int32, fab_hours);
            db.AddInParameter(dbCommand, "@fin_hours", DbType.Int32, fin_hours);
            db.AddInParameter(dbCommand, "@install_hours", DbType.Int32, Inst_hours);
            db.AddInParameter(dbCommand, "@eng_hours", DbType.Int32, Eng_hours);
            db.AddInParameter(dbCommand, "@misc_hours", DbType.Int32, misc_hours);
            db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
            db.AddInParameter(dbCommand, "@isActive", DbType.String, isActive);
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
    public String GenerateWO(Int32 EstNum,Int32 TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(Convert(int,work_order_id)),0) EstNum from Whitfield_Project_WorkOrder Where EstNum = @EstNum and TWC_proj_number=@TWC_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
         db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
                return (Convert.ToInt32(retVal.ToString()) + 1).ToString();
            }
        }
        else
        {
            return "001";
        }
    }
    public DataSet GetContactsForProject(Int32 EstNum,Int32 TWC_proj_number,Int32 winClient)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "    SELECT a.primary_contact,b.ClientId, b.Name,c.first + ',' + c.last contactName, c.email, c.Tel from Whitfield_project_client a  LEFT JOIN  clientinfo b ON a.clientid = b.clientid  LEFT JOIN contacts c ON  a.primary_contact = c.contactID " +
                                "    WHERE   " +
                                "    EstNum = @EstNum and TWC_proj_number=@TWC_proj_number and a.clientid = @winclient ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@winclient", DbType.Int32, winClient);
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

    public DataSet GetInstallers()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT [UserId] " +
                                " ,[FirstName] + ',' + [LastName] InstallerName" +
                                "  FROM [Whitfielddb].[dbo].[User]" +
                                "  Where [empl_type_id] = 7";
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

    public DataSet GetCompetitonForProject(Int32 EstNum,Int32 TWC_proj_number )
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " select b.Compeid,a.Name,b.Bid from competition a LEFT JOIN  Whitfield_project_compe b  ON a.compeID = b.CompeID  " +
                                " Where EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public Boolean PopulateProject_client(Int32 EstNum, Int32 ClientID,Int32 TWC_proj_number)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Whitfield_PROJECT_CLIENT(EstNum,TWC_proj_number, ClientID) Values (@EstNum, @TWC_proj_number,@ClientID)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public Boolean PopulateProject_compe(Int32 EstNum,Int32 TWC_proj_number, Int32 CompeID)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Whitfield_Project_Compe(EstNum, TWC_proj_number,compeId) Values (@EstNum,@TWC_proj_number, @compeId)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
             db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public void DeleteEstimateRecords(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            DeleteConsideration(EstNum,TWC_proj_number);
            DeleteProjectClient(EstNum,TWC_proj_number);
            DeleteProjectCompe(EstNum,TWC_proj_number);
            DeleteQualification(EstNum,TWC_proj_number);
            DeleteConvLog(EstNum,TWC_proj_number);
            DeleteProjectDocs(EstNum,TWC_proj_number);
            DeleteEstimate(EstNum,TWC_proj_number);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteEstimate(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_ProjectInfo WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    public void DeleteConvLog(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_conv_log WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
             db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteProjectCompe(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_Compe WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteProjectCompe(Int32 EstNum, Int32 CompeID,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_Compe WHERE EstNum = @EstNum and compeID = @compeid AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@compeid", DbType.Int32, CompeID);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public void DeleteProjectClient(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_client WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }


    public void AddPrimaryContact(Int32 EstNum,Int32 TWC_proj_number, Int32 ClientID, Int32 ContactID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Whitfield_Project_client SET Primary_contact = @ContactID WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number and ClientID = @ClientID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public void AddBidAmount(Int32 EstNum,Int32 TWC_proj_number, Int32 Compeid, String BidAMT)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Whitfield_Project_compe SET Bid = @Bid WHERE EstNum = @EstNum and compeid = @Compeid AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
             db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public String GetBidAmt(Int32 EstNum, Int32 Compeid,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ISNULL(Bid,'') as Bid  FROM [Whitfield_Project_compe] WHERE EstNum = @EstNum and compeid = @Compeid AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
             db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public String GetProjectName(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ISNULL(ProjName,'') as ProjName  FROM [Whitfield_ProjectInfo] WHERE TWC_proj_number=@TWC_proj_number AND EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public String GetClientName(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ISNULL(b.Name,'') as CompeName  FROM Whitfield_Project_Compe a, Competition b WHERE   a.compeID = b.compeID and EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public Boolean PopulateConsideration(Int32 EstNum, Int32 ConID,Int32 TWC_proj_number)
    {

        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Whitfield_Project_consideration(EstNum,TWC_proj_number, con_id) Values (@EstNum,@TWC_proj_number, @con_id)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@con_id", DbType.Int32, ConID);
             db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
    public Boolean DeleteConsideration(Int32 EstNum,Int32 TWC_proj_number)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_consideration WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
              db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public Boolean PopulateQualification(Int32 EstNum, Int32 qualid,Int32 TWC_proj_number)
    {

        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Whitfield_Project_Qualificaton(EstNum,TWC_proj_number, qual_id) Values (@EstNum,@TWC_proj_number, @qual_id)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public void DeleteProjectDocs(Int32 EstNum,Int32 TWC_proj_number)
    {
        //Project_documents
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_documents WHERE EstNum = @EstNum  AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);

        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);

        }
    }
    public Boolean DeleteQualification(Int32 EstNum,Int32 TWC_proj_number)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_Qualificaton WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
    public DataSet GetConversationLogforProject(Int32 EstNum,Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * FROM [Whitfield_Project_conv_log] WHERE EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
              db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public Boolean InsertConversation(Int32 EstNum, Int32 TWC_proj_number,String _userid, String _comments, String _commentsDate, String _commentsTime)
    {
        try
        {

            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Whitfield_Project_conv_log(EstNum,TWC_proj_number, seq_no,comments, LastModifiedBy,LastModifiedDate,LastModifiedTime) Values (@EstNum,@TWC_proj_number,@seqid, @comments,@userid,@commentsDate,@commentsTime)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
              db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@seqid", DbType.Int32, GenerateseqNumber(EstNum,TWC_proj_number));
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

    public Int32 GenerateseqNumber(Int32 EstNum, Int32 TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(seq_no),0) seqID from Whitfield_Project_conv_log Where EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
          db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
    public Int32 GenerateseqNumberforDocs(Int32 EstNum, Int32 TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(seq_num),0) seqID from Whitfield_Project_documents Where EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public DataSet GetDocumentsforProject(Int32 EstNum, Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.*,b.doc_Type_Desc FROM Whitfield_Project_documents a,List_document_type b  WHERE a.doc_type_id = b.doc_type_id AND EstNum = @EstNum AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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
    public void DeleteProjDocument(Int32 EstNum, Int32 SeqNum, Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_documents WHERE EstNum = @EstNum and seq_num = @seq_num AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@seq_num", DbType.Int32, SeqNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    public Int32 SetUpProjecs(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO [Whitfield_ProjectInfo](" +
                                "   [EstNum]" +
                                "   ,[ProjName]" +
                                "   ,[ProjDescr]" +
                                "   ,[Notes]" +
                                "   ,[ProjType]" +
                                "   ,[BidDate]" +
                                "   ,[BidTime]" +
                                "   ,[AwardDate]" +
                                "   ,[AwardDur]" +
                                "   ,[ConstrStart]" +
                                "   ,[ConstrDur]" +
                                "   ,[ConstrCompl]" +
                                "   ,[GC1]" +
                                "   ,[Status]" +
                                "   ,[ClientType]" +
                                "   ,[WinClient]" +
                                "   ,[WinMill]" +
                                "   ,[FinalPrice]" +
                                "   ,[BaseBid]" +
                                "   ,[Negotiated]" +
                                "   ,[Architect]" +
                                "   ,[LEED]" +
                                "   ,[Is_MD_Sales_Tax]" +
                                "   ,[loginid]" +
                                "   ,[empl_type_id],[Real_proj_Number]) " +
                                "    SELECT  " +
                                "   [EstNum]" +
                                "   ,[ProjName]" +
                                "   ,[ProjDescr]" +
                                "   ,[Notes]" +
                                "   ,[ProjType]" +
                                "   ,[BidDate]" +
                                "   ,[BidTime]" +
                                "   ,[AwardDate]" +
                                "   ,[AwardDur]" +
                                "   ,[ConstrStart]" +
                                "   ,[ConstrDur]" +
                                "   ,[ConstrCompl]" +
                                "   ,[GC1]" +
                                "   ,[Status]" +
                                "   ,[ClientType]" +
                                "   ,[WinClient]" +
                                "   ,[WinMill]" +
                                "   ,[FinalPrice]" +
                                "   ,[BaseBid]" +
                                "   ,[Negotiated]" +
                                "   ,[Architect]" +
                                "   ,[LEED]" +
                                "   ,[Is_MD_Sales_Tax]" +
                                "   ,[loginid],[empl_type_id],[Real_proj_Number] FROM ProjectInfo WHERE EstNum = @EstNum ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.ExecuteNonQuery(dbCommand);
            SetUpWorkOrders(EstNum, GetTWC_ProjectNumber(EstNum));
            SetupDocs(EstNum, GetTWC_ProjectNumber(EstNum));
            UpdateEstStatus(EstNum);
            //UpdateReal_proj_Number(EstNum);
            return GetTWC_ProjectNumber(EstNum);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return 0;
        }
    }

    public void UpdateReal_proj_Number(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Whitfield_ProjectInfo SET Real_proj_Number = " + GetTWC_ProjectNumber(EstNum) + " WHERE EstNum = @EstNum";
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
     public String GetWinningClient(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = "  select ISNULL(WinClient,0) from ProjectInfo Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return retVal.ToString();
        }
        else
        {
            return "0";
        }
    }

    //Real_proj_Number
    public Int32 GetTWC_ProjectNumber(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select TWC_proj_number from Whitfield_ProjectInfo Where EstNum = @EstNum";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString());
        }
        else
        {
            return 1;
        }
    }

   

    public Int32 GetReal_proj_Number(Int32 EstNum)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select Real_proj_Number from Whitfield_ProjectInfo Where TWC_proj_number = @TWC_proj_number";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, EstNum);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToInt32(retVal.ToString()) > 0)
        {
            return Convert.ToInt32(retVal.ToString());
        }
        else
        {
            return 1;
        }
    }

    public void SetupDocs(Int32 EstNum, Int32 TWC_Project_Number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO [whitfield_Project_documents](" +
                                "         [TWC_proj_number]" +
                                 "      ,[EstNum]" +
                                "       ,[seq_num]" +
                                "       ,[doc_type_id]" +
                                "       ,[doc_mime_type]" +
                                "       ,[document]" +
                                "       ,[LastModifiedBy]" +
                                "       ,[LastModifiedDate]" +
                                "       ,[docsize],doc_name)" +
                                 "    SELECT " +
                               "       @TWC_Project_Number " +
                               "      ,[EstNum]" +
                                "       ,[seq_num]" +
                                "       ,[doc_type_id]" +
                                "       ,[doc_mime_type]" +
                                "       ,[document]" +
                                "       ,[LastModifiedBy]" +
                                "       ,[LastModifiedDate]" +
                                "       ,[docsize],doc_name" +
                               "  FROM Project_documents WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_Project_Number", DbType.Int32, TWC_Project_Number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    public void SetUpWorkOrders(Int32 EstNum,Int32 TWC_Project_Number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO [whitfield_Project_workorder](" +
                                "   [TWC_proj_number] " +
                                "  ,[EstNum]" +
                                "  ,[work_order_id]" +
                                "  ,[Description]" +
                                "  ,[fab_hours]" +
                                "  ,[Fin_hours]" +
                                "  ,[install_hours]" +
                                "  ,[eng_hours]" +
                                "  ,[misc_hours],[tot_mat_cost]" +
                                "  ,[notes]" +
                                "  ,[isActive] )" +
                                " SELECT " +
                                "   @TWC_Project_Number " +
                                "  ,[EstNum]" +
                                "  ,[work_order_id]" +
                                "  ,[Description]" +
                                "  ,[fab_hours]" +
                                "  ,[Fin_hours]" +
                                "  ,[install_hours]" +
                                "  ,[eng_hours]" +
                                "  ,[misc_hours],[tot_mat_cost]" +
                                "  ,[notes]" +
                                "  ,[isActive] FROM Project_workorder WHERE EstNum = @EstNum";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_Project_Number", DbType.Int32, TWC_Project_Number);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    public void UpdateEstStatus(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE ProjectInfo SET IsMoved = 'Y' WHERE EstNum = @EstNum";
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


    public DataSet SelectInstallers(Int32 TWC_proj_number)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT * FROM Whitfield_Project_Installers WHERE TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            DataSet ds= db.ExecuteDataSet(dbCommand);
            return ds;
             
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
            return null;
        }
    }

    public Boolean DeleteInstallers(Int32 TWC_proj_number)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " DELETE Whitfield_Project_Installers WHERE TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
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

    public Boolean PopulateProject_Installers(Int32 TWC_proj_number, Int32 InstallID)
    {

        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO Whitfield_Project_Installers(TWC_proj_number, Userid) Values (@TWC_proj_number,@InstallID)  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@InstallID", DbType.Int32, InstallID);
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
}
