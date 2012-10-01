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
/// Summary description for project_invoice
/// </summary>
public class project_invoice
{
	public project_invoice()
	{
        //TWC_proj_number
        //Date_Submited
        //Date_Received
        //Date_Approved
        //fab_lab_Cost
        //Ins_lab_Cost
        //Material_cost
        //Base_contract
        //Change_order
        //Invoice_comments
        //invoice_number
	}

    public DataSet GetHashtableData()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "  SELECT seq_value,seq_text from [whitfielddb].[dbo].[whitfield_sequence_table] order by seq_no asc";
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

    public DataSet GetInvoiceforProject(Int32 TWC_proj_number )
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            //9.	Overhead Costs = [Total Invoice Amount – (Fabrication Labor Costs + Installation Labor Costs + Material Costs)]
            //12.	Total Invoice Amount = [Base Contract Billing Amount + Change Orders Billing Amount]
            //ISNULL(Base_contract,0) + ISNULL(Change_order,0)
            //((ISNULL(Base_contract,0) + ISNULL(Change_order,0)) - (ISNULL(fab_lab_Cost,0) + ISNULL(Ins_lab_Cost,0) +  ISNULL(Material_cost,0)))
            String sqlCommand = " SELECT  " +
                                "  TWC_proj_number " +
                                " ,Date_Submited" +
                                " ,Date_Received" +
                                " ,Date_Approved" +
                                " ,ltrim(rtrim(replace(ISNULL(fab_lab_Cost,0),',',''))) fab_lab_Cost " +
                                " ,ltrim(rtrim(replace(ISNULL(Ins_lab_Cost,0),',',''))) Ins_lab_Cost" +
                                " ,ltrim(rtrim(replace(ISNULL(Material_cost,0),',',''))) Material_cost" +
                                " ,ltrim(rtrim(replace(ISNULL(Base_contract,0),',',''))) Base_contract" +
                                " ,ltrim(rtrim(replace(ISNULL(Change_order,0),',',''))) Change_order" +
                                " ,( Convert(float,ISNULL(Base_contract,0)) + Convert(float,ISNULL(Change_order,0)) ) Total_inv_Amount " +
                                " ,( ( Convert(float,ISNULL(Base_contract,0)) + Convert(float,ISNULL(Change_order,0)) ) - ( Convert(float,ISNULL(fab_lab_Cost,0)) + Convert(float,ISNULL(Ins_lab_Cost,0)) +  Convert(float,ISNULL(Material_cost,0)) )) Overhead_Costs " + 
                                " ,Invoice_comments" +
                                " ,invoice_number" +
                                "  FROM Whitfield_Project_Invoice " +
                                "  Where [TWC_proj_number] = @TWC_proj_number";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
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

    public DataSet GetInvoiceforProjectForInvoice(Int32 TWC_proj_number, String Invoice_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT  " +
                                "  TWC_proj_number " +
                                " ,Date_Submited" +
                                " ,Date_Received" +
                                " ,Date_Approved" +
                                " ,fab_lab_Cost" +
                                " ,Ins_lab_Cost" +
                                " ,Material_cost" +
                                " ,Base_contract" +
                                " ,Change_order" +
                                " ,Invoice_comments" +
                                " ,invoice_number" +
                                "  FROM Whitfield_Project_Invoice " +
                                "  Where [TWC_proj_number] = @TWC_proj_number AND Invoice_number=@Invoice_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@invoice_number", DbType.String, Invoice_number);
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

    public Boolean IsItemExists(Int32 TWC_proj_number, String Invoice_number)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from Whitfield_Project_Invoice  Where  TWC_proj_number = @TWC_proj_number and Invoice_number = @Invoice_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
           
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@Invoice_number", DbType.String, Invoice_number);

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

    public Boolean DeleteInvoice(Int32 TWC_proj_number, String Invoice_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand1 = " DELETE Whitfield_Project_Invoice  Where [TWC_proj_number] = @TWC_proj_number AND Invoice_number=@Invoice_number";
            DbCommand dbCommand1 = db.GetSqlStringCommand(sqlCommand1);
            db.AddInParameter(dbCommand1, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand1, "@invoice_number", DbType.String, Invoice_number);

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

    public Boolean MaintainInvoiceRecords(String TWC_proj_number
                                        ,String Date_Submited
                                        ,String Date_Received
                                        ,String Date_Approved
                                        ,String fab_lab_Cost
                                        ,String Ins_lab_Cost
                                        ,String Material_cost
                                        ,String Base_contract
                                        ,String Change_order
                                        ,String Invoice_comments
                                        ,String invoice_number)
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsItemExists(Convert.ToInt32(TWC_proj_number), invoice_number))
            {
                sqlCommand = " INSERT INTO Whitfield_Project_Invoice ( " +
                                     " TWC_proj_number  " +
                                    " ,Date_Submited" +
                                    " ,Date_Received" +
                                    " ,Date_Approved" +
                                    " ,fab_lab_Cost" +
                                    " ,Ins_lab_Cost" +
                                    " ,Material_cost" +
                                    " ,Base_contract" +
                                    " ,Change_order" +
                                    " ,Invoice_comments" +
                                    " ,invoice_number" +
                                  "   ) " +
                                  "   VALUES ( " +
                                  "    @TWC_proj_number  " +
                                  "   ,@Date_Submited" +
                                  "   ,@Date_Received" +
                                  "   ,@Date_Approved" +
                                  "   ,@fab_lab_Cost" +
                                  "   ,@Ins_lab_Cost" +
                                  "   ,@Material_cost" +
                                  "   ,@Base_contract" +
                                  "   ,@Change_order" +
                                  "   ,@Invoice_comments" +
                                  "   ,@invoice_number)";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE Whitfield_Project_Invoice SET " +
                                    " Date_Submited = @Date_Submited " +
                                    " ,Date_Received=@Date_Received" +
                                    " ,Date_Approved=@Date_Approved" +
                                    " ,fab_lab_Cost=@fab_lab_Cost" +
                                    " ,Ins_lab_Cost=@Ins_lab_Cost" +
                                    " ,Material_cost=@Material_cost" +
                                    " ,Base_contract=@Base_contract" +
                                    " ,Change_order=@Change_order" +
                                    " ,Invoice_comments=@Invoice_comments" +
                                    "  Where [TWC_proj_number] = @TWC_proj_number AND Invoice_number=@Invoice_number";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@invoice_number", DbType.String, invoice_number);
            db.AddInParameter(dbCommand, "@Date_Submited", DbType.String, Date_Submited);
            db.AddInParameter(dbCommand, "@Date_Received", DbType.String, Date_Received);
            db.AddInParameter(dbCommand, "@Date_Approved", DbType.String, Date_Approved);
            db.AddInParameter(dbCommand, "@fab_lab_Cost", DbType.String, fab_lab_Cost.Replace("$", "").Trim());
            db.AddInParameter(dbCommand, "@Ins_lab_Cost", DbType.String, Ins_lab_Cost.Replace("$", "").Trim());
            db.AddInParameter(dbCommand, "@Material_cost", DbType.String, Material_cost.Replace("$", "").Trim());
            db.AddInParameter(dbCommand, "@Base_contract", DbType.String, Base_contract.Replace("$", "").Trim());
            db.AddInParameter(dbCommand, "@Change_order", DbType.String, Change_order.Replace("$","").Trim());
            db.AddInParameter(dbCommand, "@Invoice_comments", DbType.String, Invoice_comments);
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

    // Invoice SOV

    public Boolean DeleteSOV(Int32 TWC_proj_number, String seq_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand1 = " DELETE Whitfield_Project_Invoice_SOV  Where [TWC_proj_number] = @TWC_proj_number AND seq_number=@seq_number";
            DbCommand dbCommand1 = db.GetSqlStringCommand(sqlCommand1);
            db.AddInParameter(dbCommand1, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand1, "@seq_number", DbType.Int32, Convert.ToInt32(seq_number));

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

    public DataSet GetInvoiceSOVforProject(Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT  " +
                                "  TWC_proj_number " +
                                " ,seq_number" +
                                " ,Description" +
                                " ,ltrim(rtrim(replace(sov_amount,',',''))) sov_amount" +
                                "  FROM Whitfield_Project_Invoice_SOV  " +
                                "  Where [TWC_proj_number] = @TWC_proj_number order by cast(seq_number as int) asc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
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

    public Decimal GetOriginalContractValue(Int32 TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select isNull(SUM((Convert(float, replace(replace(sov_amount,'$',''),',','')))),0) as sov_amount from Whitfield_Project_Invoice_SOV WHERE [TWC_proj_number] = @TWC_proj_number ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToDecimal(retVal.ToString()) > 0)
        {
            return Convert.ToDecimal(retVal.ToString());
        }
        else
        {
            return 0;
        }
    }

    public Decimal GetChangeOrderValue(Int32 TWC_proj_number)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " select isNull(SUM((Convert(float, replace(replace(sov_amount,'$',''),',','')))),0) as sov_amount from Whitfield_Project_Invoice_COSOV WHERE [TWC_proj_number] = @TWC_proj_number ";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
        object retVal = db.ExecuteScalar(dbCommand);
        if (Convert.ToDecimal(retVal.ToString()) > 0)
        {
            return Convert.ToDecimal(retVal.ToString());
        }
        else
        {
            return 0;
        }
    }

    public DataSet GetInvoiceSOVforProjectForInvoice(Int32 TWC_proj_number, String seq_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT  " +
                                "  TWC_proj_number " +
                                " ,seq_number" +
                                " ,Description" +
                                " ,sov_amount" +
                                "  FROM Whitfield_Project_Invoice_SOV  " +
                                "  Where [TWC_proj_number] = @TWC_proj_number AND seq_number=@seq_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@seq_number", DbType.String, seq_number);
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

    public Boolean IsSOVItemExists(Int32 TWC_proj_number, String seq_number)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from Whitfield_Project_Invoice_SOV  Where  TWC_proj_number = @TWC_proj_number and seq_number = @seq_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@seq_number", DbType.String, seq_number);

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

    public Boolean MaintainInvoiceRecords(String TWC_proj_number
                                        , String seq_number
                                        , String Description
                                        , String sov_amount
                                        )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsSOVItemExists(Convert.ToInt32(TWC_proj_number), seq_number))
            {
                sqlCommand = " INSERT INTO Whitfield_Project_Invoice_SOV ( " +
                                    " TWC_proj_number  " +
                                    " ,seq_number" +
                                    " ,Description" +
                                    " ,sov_amount" +
                                    "   ) " +
                                    "   VALUES ( " +
                                    "    @TWC_proj_number  " +
                                    "   ,@seq_number" +
                                    "   ,@Description" +
                                    "   ,@sov_amount" +
                                    ")";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE Whitfield_Project_Invoice_SOV SET " +
                                    " Description = @Description " +
                                    " ,sov_amount=@sov_amount" +
                                    "  Where [TWC_proj_number] = @TWC_proj_number AND seq_number=@seq_number";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@seq_number", DbType.Int32, seq_number);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);
            db.AddInParameter(dbCommand, "@sov_amount", DbType.String, sov_amount.Replace("$", "").Trim());
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


    public void UpdateProjectInfo(Int32 EstNum, Int32 TWC_proj_number, String Init_Payment_Date, String Final_Payment_Date, String Payment_point_of_contact, String O_Contract_Value, String Change_Order_Value )
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " UPDATE Whitfield_ProjectInfo SET Change_Order_Value=@Change_Order_Value, O_Contract_Value=@O_Contract_Value, Init_Payment_Date = @Init_Payment_Date,Final_Payment_Date=@Final_Payment_Date,Payment_point_of_contact=@Payment_point_of_contact  WHERE EstNum = @EstNum  AND TWC_proj_number=@TWC_proj_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@Init_Payment_Date", DbType.String, Init_Payment_Date);
            db.AddInParameter(dbCommand, "@Final_Payment_Date", DbType.String, Final_Payment_Date);
            db.AddInParameter(dbCommand, "@Payment_point_of_contact", DbType.Int32, Convert.ToInt32(Payment_point_of_contact));
            db.AddInParameter(dbCommand, "@O_Contract_Value", DbType.String, O_Contract_Value);
            db.AddInParameter(dbCommand, "@Change_Order_Value", DbType.String, Change_Order_Value);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

//5.	Number = Project Number from “Whitfield_projectinfo.aspx/Whitfield Project #;”
//6.	Project Name = Project Name from “Whitfield_projectinfo.aspx/Project Name”
//7.	Current Contract = Current Contract Value from “Whitfield_projectinfo.aspx/Current Contract Value”
//8.	Original Contract = Original Contract Value from “Whitfield_projectinfo.aspx/Original Contract Value”
//9.	Change Orders = Change Order Value from “Whitfield_projectinfo.aspx/Change Order Value”
//10.	Earned Amount = [Current Contract - (Open Invoices + Balance Remaining)]
//11.	Open Invoices = Sum of “Total Invoice Amount” where “Date Received” is null (from Whitfield_projectinvoice.aspx)
//12.	Balance Remaining = [Current Contract – (Earned Amount + Open Invoices)]

    public DataSet GetProjectInvoices()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT  " +
                                "  distinct a.EstNum,a.TWC_proj_number " +
                                "  ,a.ProjName" +
                                "  ,ISNULL(a.C_Contract_Value,0) C_Contract_Value" +
                                "  ,ISNULL(a.O_Contract_Value,0) O_Contract_Value" +
                                "  ,ISNULL(a.Change_Order_Value,0) CO_Contract_Value" +
                                "  ,ISNULL((SELECT SUM((ISNULL(Convert(float,b1.Base_contract),0) + ISNULL(Convert(float,b1.Change_order),0))) FROM Whitfield_Project_Invoice b1 WHERE b1.TWC_proj_number = a.TWC_proj_number AND (Date_Received is Null or Date_Received = '') ),0) as Open_invoices" +
                                "  ,ISNULL((SELECT SUM((ISNULL(Convert(float,b1.Base_contract),0) + ISNULL(Convert(float,b1.Change_order),0))) FROM Whitfield_Project_Invoice b1 WHERE b1.TWC_proj_number = a.TWC_proj_number AND (Date_Received is not Null or Date_Received <> '') ),0) as Earned_amt" +
                                "  FROM Whitfield_ProjectInfo a LEFT JOIN Whitfield_Project_Invoice b on a.TWC_proj_number = b.TWC_proj_number" +
                                "    WHERE  1=1 AND Status = 5";

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

    #region Change Order SOV
    public Boolean DeleteCOSOV(Int32 TWC_proj_number, String seq_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand1 = " DELETE Whitfield_Project_Invoice_COSOV  Where [TWC_proj_number] = @TWC_proj_number AND seq_number=@seq_number";
            DbCommand dbCommand1 = db.GetSqlStringCommand(sqlCommand1);
            db.AddInParameter(dbCommand1, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand1, "@seq_number", DbType.Int32, Convert.ToInt32(seq_number));

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

    public DataSet GetInvoiceCOSOVforProject(Int32 TWC_proj_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT  " +
                                "  TWC_proj_number " +
                                " ,seq_number" +
                                " ,Description" +
                                " ,sov_amount" +
                                " ,co_number" +
                                " ,Date_Submited" +
                                " ,Date_Approved" +
                                " ,Notes" +
                                "  FROM Whitfield_Project_Invoice_COSOV  " +
                                "  Where [TWC_proj_number] = @TWC_proj_number order by cast(seq_number as int) asc";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
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

    public DataSet GetInvoiceCOSOVforProjectForInvoice(Int32 TWC_proj_number, String seq_number)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " SELECT  " +
                                "  TWC_proj_number " +
                                " ,seq_number" +
                                " ,Description" +
                                " ,ltrim(rtrim(replace(sov_amount,',',''))) sov_amount" +
                                " ,co_number" +
                                " ,Date_Submited" +
                                " ,Date_Approved" +
                                " ,Notes" +
                                "  FROM Whitfield_Project_Invoice_COSOV  " +
                                "  Where [TWC_proj_number] = @TWC_proj_number AND seq_number=@seq_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@seq_number", DbType.String, seq_number);
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

    public Boolean IsCOSOVItemExists(Int32 TWC_proj_number, String seq_number)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select count(*)  from Whitfield_Project_Invoice_COSOV  Where  TWC_proj_number = @TWC_proj_number and seq_number = @seq_number";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

            db.AddInParameter(dbCommand, "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand, "@seq_number", DbType.String, seq_number);

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

    public Boolean MaintainChangeOrderSOVRecords(String TWC_proj_number
                                        , String seq_number
                                        , String coNumber
                                        , String Description
                                        , String sov_amount
                                        , String Date_Submitted
                                        , String Date_Approved
                                        , String comments
                                        )
    {
        try
        {
            String sqlCommand = "";
            Database db = DatabaseFactory.CreateDatabase();
            if (!IsCOSOVItemExists(Convert.ToInt32(TWC_proj_number), seq_number))
            {
                sqlCommand = " INSERT INTO Whitfield_Project_Invoice_COSOV ( " +
                                    " TWC_proj_number  " +
                                    " ,seq_number" +
                                    " ,Description" +
                                    " ,sov_amount" +
                                    " ,co_number" +
                                    " ,Date_Submited" +
                                    " ,Date_Approved" +
                                    " ,Notes" +
                                    "   ) " +
                                    "   VALUES ( " +
                                    "    @TWC_proj_number  " +
                                    "   ,@seq_number" +
                                    "   ,@Description" +
                                    "   ,@sov_amount" +
                                    "   ,@coNumber" +
                                    "   ,@Date_Submitted" +
                                    "   ,@Date_Approved" +
                                    "   ,@comments" +
                                    ")";


            }
            else  //Here is the update if the system already exists.
            {
                sqlCommand = " UPDATE Whitfield_Project_Invoice_COSOV SET " +
                                    " Description = @Description " +
                                    " ,sov_amount=@sov_amount" +
                                    " ,co_number=@coNumber" +
                                    " ,Date_Approved=@Date_Approved" +
                                    " ,Date_Submited=@Date_Submitted" +
                                    " ,Notes=@comments" +
                                    "  Where [TWC_proj_number] = @TWC_proj_number AND seq_number=@seq_number";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand,  "@TWC_proj_number", DbType.Int32, TWC_proj_number);
            db.AddInParameter(dbCommand,  "@seq_number", DbType.Int32, seq_number);
            db.AddInParameter(dbCommand,  "@Description", DbType.String, Description);
            db.AddInParameter(dbCommand,  "@sov_amount", DbType.String, sov_amount.Replace("$", "").Trim());
             db.AddInParameter(dbCommand, "@coNumber", DbType.String, coNumber);
             db.AddInParameter(dbCommand, "@Date_Approved", DbType.String, Date_Approved);
             db.AddInParameter(dbCommand, "@Date_Submitted", DbType.String, Date_Submitted);
             db.AddInParameter(dbCommand, "@comments", DbType.String, comments);
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

    #endregion Change Order SOV
}
