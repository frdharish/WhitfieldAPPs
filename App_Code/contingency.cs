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
/// Summary description for contingency
/// </summary>
public class contingency
{
	public contingency()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    #region Manager Project Item Breakdown
        //    CREATE TABLE [dbo].[Project_Item_Breakdown](
        //    [idnumber] [int] IDENTITY(1,1) NOT NULL,
        //    [EstNum] [int] NOT NULL,
        //    [item_number] [varchar](50) NOT NULL,
        //    [description] [varchar](100) NOT NULL,
        //    [amount] [varchar](20) NOT NULL
        //) ON [PRIMARY]

    public Int32 UPDATEProjectItemBreakdown(Int32 idnumber, String item_number, String descrip, String amount)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "    UPDATE [Project_Item_Breakdown]  " +
                                "       SET " +
                                "    [item_number] = @item_number, " +
                                "    [description] = @descrip," +
                                "    [amount]= @amount WHERE idnumber= @idnumber";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@idnumber", DbType.Int32, idnumber);
                db.AddInParameter(dbCommand, "@descrip", DbType.String, descrip.Trim());
                db.AddInParameter(dbCommand, "@item_number", DbType.String, item_number.Trim());
                db.AddInParameter(dbCommand, "@amount", DbType.String, amount.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 PopulateProjectItemBreakdown(Int32 EstNum, String item_number,  String descrip, String amount)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO [Project_Item_Breakdown] ( " +
                                "    [EstNum] ," +
                                "    [item_number], " +
                                "    [description] ," +
                                "    [amount] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @EstNum ," +
                                "    @item_number ," +
                                "    @descrip ," +
                                "    @amount" +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@descrip", DbType.String, descrip.Trim());
                db.AddInParameter(dbCommand, "@item_number", DbType.String, item_number.Trim());
                db.AddInParameter(dbCommand, "@amount", DbType.String, amount.Trim());
                db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }


    public Int32 DeleteProjectItemBreakdown(Int32 idnumber)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete Project_Item_Breakdown  " +
                                "    WHERE  idnumber= @idnumber ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@idnumber", DbType.Int32, idnumber);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchProjectItemBreakdown(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From Project_Item_Breakdown WHERE EstNum = @EstNum order by item_number asc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            // Input parameters can specify the input value 
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion Manager Project Item Breakdown


    #region Manage Alternatives
    //    CREATE TABLE [dbo].[Project_Alternatives](
    //    [idnumber] [int] NOT NULL,
    //    [EstNum] [int] NOT NULL,
    //    [Alternate_Number] [varchar](50) NOT NULL,
    //    [Type] [varchar](10) NOT NULL,
    //    [Description] [varchar](100) NOT NULL,
    //    [Amount] [varchar](20) NOT NULL
    //) ON [PRIMARY]

  

    public Int32 Deletealternatives(Int32 idnumber)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete Project_Alternatives  " +
                                "    WHERE  idnumber= @idnumber ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@idnumber", DbType.Int32, idnumber);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }


    public DataSet FetchAlternatives(Int32 EstNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From Project_Alternatives WHERE EstNum = @EstNum order by Alternate_Number asc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            // Input parameters can specify the input value 
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 UPDATEAlternatives(Int32 idnumber, String type, String number, String Description, String amount)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "    UPDATE [Project_Alternatives]  " +
                                "    SET " +
                                "    [Type] = @type, " +
                                "    [Alternate_Number] = @number," +
                                "    [amount]= @amount ," +
                                "    [Description]= @Description " +
                                "    WHERE idnumber= @idnumber";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@idnumber", DbType.Int32, idnumber);
                db.AddInParameter(dbCommand, "@type", DbType.String, type.Trim());
                db.AddInParameter(dbCommand, "@number", DbType.String, number.Trim());
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());             
                db.AddInParameter(dbCommand, "@amount", DbType.String, amount.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 PopulateAlternatives(Int32 EstNum, String type, String number, String descrip, String amount)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO [Project_Alternatives] ( " +
                                "    [EstNum] ," +
                                "    [Type], " +
                                "    [Alternate_Number] ," +
                                "    [Description],[Amount] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @EstNum ," +
                                "    @type ," +
                                "    @number ," +
                                "    @descrip,@amount" +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@type", DbType.String, type.Trim());
                db.AddInParameter(dbCommand, "@descrip", DbType.String, descrip.Trim());
                db.AddInParameter(dbCommand, "@number", DbType.String, number.Trim());
                db.AddInParameter(dbCommand, "@amount", DbType.String, amount.Trim());
                db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion Manage Alternatives


    #region Manage Drawing List
    //type varchar 50 0 0 True   False 0 0 False 
    //doc_name varchar 50 0 0 True   False 0 0 False 
    //doc_number varchar 50 0 0 True   False 0 0 False 
    //revision varchar 50 0 0 True   False 0 0 False  
    //doc_date varchar 50 0 0 True   False 0 0 False 
    //EstNum int 4 10 0 True   False 0 0 False   
    //idnumber 

    public Int32 PopulateDrawingList(Int32 EstNum, String type, String doc_name, String doc_number, String revision, String doc_date)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO [Project_Drawing_List] ( " +
                                "    [type] ," +
                                "    [doc_name], " +
                                "    [doc_number] ," +
                                "    [revision],[doc_date],[EstNum] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @type ," +
                                "    @doc_name ," +
                                "    @doc_number ," +
                                "    @revision,@doc_date,@EstNum" +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@type", DbType.String, type.Trim());
                db.AddInParameter(dbCommand, "@doc_name", DbType.String, doc_name.Trim());
                db.AddInParameter(dbCommand, "@doc_number", DbType.String, doc_number.Trim());
                db.AddInParameter(dbCommand, "@revision", DbType.String, revision.Trim());
                db.AddInParameter(dbCommand, "@doc_date", DbType.String, doc_date);
                 db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

     public Int32 UpdateDrawingList(String type, String doc_name, String doc_number, String revision, String doc_date,Int32 idNum)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Update Project_Drawing_List SET " +
                                "    [type] = @type , " +
                                "    [doc_name] = @doc_name, " +
                                "    [doc_number] = @doc_number," +
                                "    [revision] = @revision," +
                                "    [doc_date] = @doc_date" +
                                "    WHERE  idnumber= @idNum ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@type", DbType.String, type.Trim());
                db.AddInParameter(dbCommand, "@doc_name", DbType.String, doc_name.Trim());
                db.AddInParameter(dbCommand, "@doc_number", DbType.String, doc_number.Trim());
                db.AddInParameter(dbCommand, "@revision", DbType.String, revision.Trim());
                db.AddInParameter(dbCommand, "@doc_date", DbType.String, doc_date);
                db.AddInParameter(dbCommand, "@idNum", DbType.Int32, idNum);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

     public DataSet FetchDrawingList(Int32 EstNum)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase();
             string sqlCommand = "SELECT * From Project_Drawing_List WHERE EstNum = @EstNum";
             DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
             // Add paramters 
             // Input parameters can specify the input value 
             db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
             DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
             return dsmsirrecs;
         }
         catch (Exception)
         {
             throw;
         }
     }

     public Int32 DeleteDrawingList(Int32 idnumber)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase();
             string sqlCommand = " Delete Project_Drawing_List  " +
                                 "    WHERE  idnumber= @idnumber ";

             try
             {
                 DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                 db.AddInParameter(dbCommand, "@idnumber", DbType.Int32, idnumber);
                 db.ExecuteNonQuery(dbCommand);
                 return 1;
             }
             catch (Exception)
             {
                 return 0;
                 throw;
             }

         }
         catch (Exception)
         {
             throw;
         }
     }

    #endregion Manage Drawing List

    #region Manage Amendments
     //type varchar 50 0 0 True   False 0 0 False 
     //amendment_number varchar 50 0 0 True   False 0 0 False 
     //amendment_date varchar 50 0 0 True   False 0 0 False 
     //amendment_impact varchar 50 0 0 True   False 0 0 False 
     //EstNum int 4 10 0 True   False 0 0 False  
     //idNum 
     public Int32 PopulateAmendmentList(Int32 EstNum, String type, String amendment_number, String amendment_date, String amendment_impact,String notes)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase();
             string sqlCommand = " INSERT INTO [Project_Amendment_List] ( " +
                                 "    [type] ," +
                                 "    [amendment_number], " +
                                 "    [amendment_date] ," +
                                 "    [amendment_impact],[EstNum],[notes] " +
                                 "    )" +
                                 "    VALUES(  " +
                                 "    @type ," +
                                 "    @amendment_number ," +
                                 "    @amendment_date ," +
                                 "    @amendment_impact,@EstNum,@notes" +
                                 "    )";


             try
             {
                 DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                 db.AddInParameter(dbCommand, "@type", DbType.String, type.Trim());
                 db.AddInParameter(dbCommand, "@amendment_number", DbType.String, amendment_number.Trim());
                 db.AddInParameter(dbCommand, "@amendment_date", DbType.String, amendment_date.Trim());
                 db.AddInParameter(dbCommand, "@amendment_impact", DbType.String, amendment_impact.Trim());
                 db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
                 db.AddInParameter(dbCommand, "@notes", DbType.String, notes);
                 db.ExecuteNonQuery(dbCommand);
                 return 1;
             }
             catch (Exception)
             {
                 return 0;
                 throw;
             }

         }
         catch (Exception)
         {
             throw;
         }
     }

     public Int32 UpdateAmendmentList(Int32 idnumber, String type, String amendment_number, String amendment_date, String amendment_impact, String Notes)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase();
             string sqlCommand = " Update Project_Amendment_List SET " +
                                 "    [type] = @type , " +
                                 "    [amendment_number] = @amendment_number, " +
                                 "    [amendment_date] = @amendment_date," +
                                 "    [amendment_impact] = @amendment_impact , " +
                                  "   [Notes] = @Notes" +
                                 "    WHERE  idNum = @idnumber ";

             try
             {
                 DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                 db.AddInParameter(dbCommand, "@type", DbType.String, type.Trim());
                 db.AddInParameter(dbCommand, "@amendment_number", DbType.String, amendment_number.Trim());
                 db.AddInParameter(dbCommand, "@amendment_date", DbType.String, amendment_date.Trim());
                 db.AddInParameter(dbCommand, "@amendment_impact", DbType.String, amendment_impact.Trim());
                 db.AddInParameter(dbCommand, "@idnumber", DbType.Int32, idnumber);
                 db.AddInParameter(dbCommand, "@Notes", DbType.String, Notes);
                 db.ExecuteNonQuery(dbCommand);
                 return 1;
             }
             catch (Exception ex)
             {
                 
                 //HttpResponse objResponse = HttpContext.Current.Response;
                 //objResponse.Write(ex.Message);
                 return 0;
                 throw;
             }

         }
         catch (Exception)
         {
             throw;
         }
     }

     public DataSet FetchAmendmenList(Int32 EstNum)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase(); 
             string sqlCommand = "SELECT * From Project_Amendment_List WHERE EstNum = @EstNum";
             DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
             // Add paramters 
             // Input parameters can specify the input value 
             db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
             DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
             return dsmsirrecs;
         }
         catch (Exception)
         {
             throw;
         }
     }

     public Int32 DeleteAmendmentList(Int32 idnumber)
     {
         try
         {
             Database db = DatabaseFactory.CreateDatabase();
             string sqlCommand = " Delete Project_Amendment_List  " +
                                 "    WHERE  idNum = @idnumber ";

             try
             {
                 DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                 db.AddInParameter(dbCommand, "@idnumber", DbType.Int32, idnumber);
                 db.ExecuteNonQuery(dbCommand);
                 return 1;
             }
             catch (Exception)
             {
                 return 0;
                 throw;
             }

         }
         catch (Exception)
         {
             throw;
         }
     }
    #endregion Manage Amendmentst


    #region Contingency & Sub Contingency

    public Int32 PopulateContingency(String Group_name, String Description)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO [whitfield_master_contingency] ( " +
                                "    [Group_name] ," +
                                "    [Description] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @Group_name ," +
                                "    @Description " +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@Group_name", DbType.String, Group_name.Trim());
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 PopulateSubContingency(Int32 contingency_id, String Description, String UOM, String cost, String is_default)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO [whitfield_sub_contingency] ( " +
                                "    [Description] ," +
                                "    [UOM], " +
                                "    [cost] ," +
                                "    [is_default],[contingency_id] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @Description ," +
                                "    @UOM ," +
                                "    @cost ," +
                                "    @is_default,@contingency_id" +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.AddInParameter(dbCommand, "@UOM", DbType.String, UOM.Trim());
                db.AddInParameter(dbCommand, "@cost", DbType.String, cost.Trim());
                db.AddInParameter(dbCommand, "@is_default", DbType.String, is_default.Trim());
                db.AddInParameter(dbCommand, "@contingency_id", DbType.Int32, contingency_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }


    public Int32 UpdatesubContingency(Int32 sub_contingency_id, String Description, String UOM, String cost, String is_default)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Update whitfield_sub_contingency SET " +
                                "    [Description] = @Description , " +
                                "    [UOM] = @UOM, " +
                                "    [cost] = @cost," +
                                "    [is_default] = @is_default" +
                                "    WHERE  sub_contingency_id= @sub_contingency_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@sub_contingency_id", DbType.Int32, sub_contingency_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.AddInParameter(dbCommand, "@UOM", DbType.String, UOM.Trim());
                db.AddInParameter(dbCommand, "@cost", DbType.String, cost.Trim());
                db.AddInParameter(dbCommand, "@is_default", DbType.String, is_default.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 UpdateContingency(Int32 contingency_id, String Description)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE whitfield_master_contingency SET " +
                                "    [Description] = @Description  " +
                                "    WHERE  contingency_id= @contingency_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@contingency_id", DbType.Int32, contingency_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteContingency(Int32 contingency_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete whitfield_master_contingency  " +
                                "    WHERE  contingency_id= @contingency_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@contingency_id", DbType.Int32, contingency_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteSubContingencyForContingency(Int32 contingency_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete whitfield_sub_contingency  " +
                                "    WHERE  contingency_id= @contingency_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@contingency_id", DbType.Int32, contingency_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteSubContingency(Int32 sub_contingency_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete whitfield_sub_contingency  " +
                                "    WHERE  sub_contingency_id= @sub_contingency_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@sub_contingency_id", DbType.Int32, sub_contingency_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }



    public DataSet FetchContingencyData()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_master_contingency";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            // Input parameters can specify the input value 
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchSubContingencyData()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_sub_contingency";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            // Input parameters can specify the input value 
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public DataSet FetchContingencyData(Int32 ContingencyID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_master_contingency  Where contingency_id =  @contingency_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            db.AddInParameter(dbCommand, "@contingency_id", DbType.Int32, ContingencyID);
            // Input parameters can specify the input value 
            DataSet IReader = db.ExecuteDataSet(dbCommand);
            return IReader;
            //DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            //return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public DataSet FetchSubContingencyData(Int32 contingency_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_sub_contingency  Where contingency_id =  @contingency_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            db.AddInParameter(dbCommand, "@contingency_id", DbType.Int32, contingency_id);
            // Input parameters can specify the input value 
            DataSet DataSet = db.ExecuteDataSet(dbCommand);
            return DataSet;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion


    #region Terms & Sub Terms

    public Int32 PopulateTerms(String Group_name, String Description)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO whitfield_master_terms  ( " +
                                "    [Group_name] ," +
                                "    [Description] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @Group_name ," +
                                "    @Description " +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@Group_name", DbType.String, Group_name.Trim());
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 PopulateSubTerms(Int32 terms_id, String Description, String is_default)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO whitfield_sub_terms  ( " +
                                "    [terms_id] ," +
                                "    [description] ," +
                                "    [is_default] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @terms_id ," +
                                "    @Description ," +
                                "    @is_default" +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@terms_id", DbType.Int32, terms_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.AddInParameter(dbCommand, "@is_default", DbType.String, is_default.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }
    public Int32 UpdateTerms(Int32 terms_id, String Description)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Update whitfield_master_terms SET " +
                                "    [Description] = @Description  " +
                                "    WHERE  terms_id= @terms_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@terms_id", DbType.Int32, terms_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 UpdateSubTerms(Int32 sub_terms_id,  String Description, String is_default)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Update whitfield_sub_terms SET " +
                                "    [Description] = @Description , " +
                                "    [is_default] = @is_default " +
                                "    WHERE  sub_terms_id = @sub_terms_id  ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@sub_terms_id", DbType.Int32, sub_terms_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.AddInParameter(dbCommand, "@is_default", DbType.String, is_default.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteTerms(Int32 terms_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete whitfield_master_terms  " +
                                "    WHERE  terms_id= @terms_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@terms_id", DbType.Int32, terms_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteSubTermsForTems(Int32 terms_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete [whitfield_sub_terms]  " +
                                "    WHERE  terms_id= @terms_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@terms_id", DbType.Int32, terms_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteSubTerms(Int32 sub_terms_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete [whitfield_sub_terms]  " +
                                "    WHERE  [sub_terms_id] = @sub_terms_id ";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@sub_terms_id", DbType.Int32, sub_terms_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchTermsData()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_master_terms";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            // Input parameters can specify the input value 
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public DataSet FetchSubTermsData()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_sub_terms";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            // Input parameters can specify the input value 
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchTermsData(Int32 terms_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_master_terms  Where terms_id =  @terms_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            db.AddInParameter(dbCommand, "@terms_id", DbType.Int32, terms_id);
            // Input parameters can specify the input value 
            DataSet IReader = db.ExecuteDataSet(dbCommand);
            return IReader;
            //DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            //return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchSubTermsData(Int32 terms_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_sub_terms Where terms_id =  @terms_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            db.AddInParameter(dbCommand, "@terms_id", DbType.Int32, terms_id);
            // Input parameters can specify the input value 
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region Qualifications

    public Int32 PopulateQuals(String Group_name, String Description)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO whitfield_master_qualifications( " +
                                "    [group_name] ," +
                                "    [description] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @Group_name ," +
                                "    @Description " +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@Group_name", DbType.String, Group_name.Trim());
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 PopulateSubQuals(Int32 qual_id, String Group_name, String Description, String is_default)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " INSERT INTO whitfield_sub_qualifications( " +
                                "    [qual_id] ," +
                                "    group_name , " +
                                "    [description] ," +
                                "    [is_default] " +
                                "    )" +
                                "    VALUES(  " +
                                "    @qual_id ," +
                                "    'Testing', " +
                                "    @Description ," +
                                "    @is_default" +
                                "    )";


            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@qual_id", DbType.Int32, qual_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.AddInParameter(dbCommand, "@is_default", DbType.String, is_default.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 UpdateQuals(Int32 qual_id, String Description)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Update whitfield_master_qualifications    SET " +
                                "    [Description] = @Description  " +
                                "    WHERE  qual_id= @qual_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@qual_id", DbType.Int32, qual_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }


    public Int32 UpdateSubQuals(Int32 sub_qual_id, String Description, String is_default)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Update whitfield_sub_qualifications    SET " +
                                "    [Description] = @Description , " +
                                "    [is_default] = @is_default" +
                                "    WHERE  sub_qual_id= @sub_qual_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@sub_qual_id ", DbType.Int32, sub_qual_id);
                db.AddInParameter(dbCommand, "@Description", DbType.String, Description.Trim());
                db.AddInParameter(dbCommand, "@is_default", DbType.String, is_default.Trim());
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }


    public Int32 DeleteQuals(Int32 qual_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete whitfield_master_qualifications  " +
                                "    WHERE  qual_id= @qual_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@qual_id", DbType.Int32, qual_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteSubQualsForQual(Int32 qual_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete [whitfield_sub_qualifications]  " +
                                "    WHERE   qual_id= @qual_id ";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@qual_id", DbType.Int32, qual_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Int32 DeleteSubQuals(Int32 sub_qual_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " Delete [whitfield_sub_qualifications]  " +
                                "    WHERE  [sub_qual_id] = @sub_qual_id ";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                db.AddInParameter(dbCommand, "@sub_qual_id", DbType.Int32, sub_qual_id);
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchQualData()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_master_qualifications  ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            // Input parameters can specify the input value 
            DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchQualData(Int32 qual_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_master_qualifications    Where qual_id =  @qual_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            db.AddInParameter(dbCommand, "@qual_id", DbType.Int32, qual_id);
            // Input parameters can specify the input value 
            DataSet IReader = db.ExecuteDataSet(dbCommand);
            return IReader;
            //DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            //return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataSet FetchSubQualData(Int32 qual_id)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * From whitfield_sub_qualifications Where qual_id =  @qual_id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            // Add paramters 
            db.AddInParameter(dbCommand, "@qual_id", DbType.Int32, qual_id);
            // Input parameters can specify the input value 
            DataSet IReader = db.ExecuteDataSet(dbCommand);
            return IReader;
            //DataSet dsmsirrecs = db.ExecuteDataSet(dbCommand);
            //return dsmsirrecs;
        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion
}
