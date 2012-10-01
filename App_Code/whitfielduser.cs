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
/// Summary description for whitfielduser
/// </summary>
public class whitfielduser
{
	public whitfielduser()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public String GetContactNo(String loginid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select ISNULL(ContactNo1,'') as ContactNo  FROM [User]  WHERE loginid = @loginid ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
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


    public String GetEstimatorName(String loginid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select firstname + ' ' + lastname uName   FROM [User]  WHERE loginid = @loginid ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
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


    public Boolean IsUserExists(String loginid,String passwd)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            //string sqlCommand = " SELECT ISNULL(Note,'NULL') Notes from FormNotesRecords WHERE formid =" + formid + " AND loginid = '" + loginid + "' AND logindate =  '" + logindate + "' AND  viewid=" + viewid + " AND columnnum=" + columnnum + " AND controlid=" + controlid.ToString();
            String sqlCommand = " Select count(*)  from [User]  Where  loginid = @loginid and password = @passwd AND IsActive = 1 ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
            db.AddInParameter(dbCommand, "@passwd", DbType.String, passwd);

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

    public Boolean IsUserExists(String loginid)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            
            String sqlCommand = " Select count(*)  from [User]  Where  loginid = @loginid AND IsActive = 1 ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
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

    public DataSet FetchAllWorkers()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select list_installerl_type.installer_type_name,worker_table.*,worker_firstName + ',' + worker_lastname as worker_name from worker_table INNER JOIN list_installerl_type on worker_table.worker_type = list_installerl_type.installer_type_id";
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

    public DataSet FetchWorkersForInstaller(String loginid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT list_installerl_type.installer_type_name,worker_table.*,worker_id,worker_firstName + ',' + worker_lastname as worker_name from worker_table INNER JOIN list_installerl_type on worker_table.worker_type = list_installerl_type.installer_type_id  Where  User_id = @loginid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
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


    public Boolean IsWorkerExists(String fn,String ln)
    {
        // Create the Database object, using the default database service. The
        // default database service is determined through configuration.
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            String sqlCommand = " Select count(*)  from [Worker_table]  Where  worker_firstname = @fn AND worker_lastname = @ln ";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@fn", DbType.String, fn);
            db.AddInParameter(dbCommand, "@ln", DbType.String, ln);
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

    public DataSet GetUserRecord(String loginid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.* , b.RoleId from [User] a , UserRole b Where a.loginid = b.loginid AND  a.loginid = @loginid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
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

    public DataSet GetProjectUsersNoInstallers()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select firstname + ' ' + lastname uName, loginId from [user] Where ( empl_type_id <> 7 or empl_type_id is Null) ";
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

    public DataSet GetProjectUsers()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select firstname + ' ' + lastname uName, loginId from [user] Where empl_type_id <> 2 ";
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
    public DataSet SearchUserRecord(String loginid,String firstname, String lastname, String role, String phonenumber)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select a.* , b.RoleId from [User] a , UserRole b Where a.loginid = b.loginid ";

            if (loginid != "")
            {
                sqlCommand += " AND a.loginid like '" + loginid + "%'" ;
            }

            if (firstname != "")
            {
                sqlCommand += " AND  a.FirstName LIKE  '" + firstname + "%'";
            }

            if (lastname != "")
            {
                sqlCommand += "  AND a.LastName LIKE  '" + lastname + "%'";
            }

            if (role != "")
            {
                sqlCommand += "  AND b.roleid =  " + role;
            }

            if (phonenumber != "")
            {
                sqlCommand += "  AND a.ContactNo1 =  '" + phonenumber + "'";
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

    public DataSet GetAllRoles()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " SELECT * from Role";
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

    public Boolean DeleteWorkerRecord(String loginid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand2 = " DELETE [worker_table] WHERE  worker_id = @loginid";
            DbCommand dbCommand1 = db.GetSqlStringCommand(sqlCommand2);
            db.AddInParameter(dbCommand1, "@loginid", DbType.String, loginid);
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

    public Boolean  DeleteRecord(String loginid)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand1 = " DELETE [UserRole] WHERE  a.loginid = @loginid";
            String sqlCommand2 = " DELETE [user] WHERE  a.loginid = @loginid";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand1);
            DbCommand dbCommand1 = db.GetSqlStringCommand(sqlCommand2);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, loginid);
            db.AddInParameter(dbCommand1,  "@loginid", DbType.String, loginid);
            db.ExecuteNonQuery(dbCommand);
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

    public Boolean ManageUsers(        
                    String FirstName  ,
                    String LastName  ,
                    String Address    ,  
                    String City        ,
                    String State       , 
                    String Zip         , 
                    String ContactNo1  , 
                    String LoginId     , 
                    String Password    , 
                    String EmployeeNo  , 
                    String IsActive    , 
                    String email_address,
                    String hourly_rate,
                    String Roleid ,Int32 empl_type_id
        )
    {
        Database db = DatabaseFactory.CreateDatabase();
        try
        {
            if (!IsUserExists(LoginId))
            {
                String strInsert = " INSERT INTO [User] ( " +
                                    "           [FirstName]         ," +
                                    "           [LastName]          ," +
                                    "           [Address]           ," +
                                    "           [City]              ,   " +
                                    "           [State]             ,  " +
                                    "           [Zip]               , " +
                                    "           [ContactNo1]        ," +
                                    "           [LoginId]           ," +
                                    "           [Password]          ," +
                                    "           [CreatedOn]         ," +
                                    "           [ModifiedOn]        ," +
                                    "           [EmployeeNo]        ," +
                                    "           [email_address]     , " +
                                    "           [empl_type_id]      ,   " +
                                    "           [hourly_rate]       " +
                                    "          )" +
                                    "           Values(" +
                                    "           @FirstName          ," +
                                    "           @LastName           ," +
                                    "           @Address            , " +
                                    "           @City               ," +
                                    "           @State              , " +
                                    "           @Zip                , " +
                                    "           @ContactNo1         , " +
                                    "           @LoginId            , " +
                                    "           @Password           , " +
                                    "           getdate()           , " +
                                    "           getdate()           , " +
                                    "           @EmployeeNo         , " +
                                    "           @email_address      ," +
                                    "           @empl_typeid      ," +
                                    "           @hourly_rate)";

                String sqlInsertRole = " INSERT UserRole(Roleid, Loginid,Createdon, Modifiedon) values (@Roleid, @Loginid,getdate(),getdate())";

                DbCommand dbCommand = db.GetSqlStringCommand(strInsert);
                DbCommand dbCommand1 = db.GetSqlStringCommand(sqlInsertRole);



                //for dbCommand
                db.AddInParameter(dbCommand, "@Firstname", DbType.String, FirstName);
                db.AddInParameter(dbCommand, "@Lastname", DbType.String, LastName);
                db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
                db.AddInParameter(dbCommand, "@City", DbType.String, City);
                db.AddInParameter(dbCommand, "@State", DbType.String, State);
                db.AddInParameter(dbCommand, "@Zip", DbType.String, Zip);
                db.AddInParameter(dbCommand, "@ContactNo1", DbType.String, ContactNo1);
                db.AddInParameter(dbCommand, "@Loginid", DbType.String, LoginId);
                db.AddInParameter(dbCommand, "@Password", DbType.String, Password);
                db.AddInParameter(dbCommand, "@EmployeeNo", DbType.String, EmployeeNo);
                db.AddInParameter(dbCommand, "@email_address", DbType.String, email_address);
                db.AddInParameter(dbCommand, "@hourly_rate", DbType.String, hourly_rate);
                db.AddInParameter(dbCommand, "@empl_typeid", DbType.Int32, empl_type_id);

                //for dbCommand1
                db.AddInParameter(dbCommand1, "@Loginid", DbType.String, LoginId);
                db.AddInParameter(dbCommand1, "@Roleid", DbType.String, Roleid);
                

                db.ExecuteNonQuery(dbCommand);
                db.ExecuteNonQuery(dbCommand1);
            }
            else
            {
                String strUpdate = " UPDATE [User] SET " +
                                "           [FirstName] =   @Firstname ,  " +
                                "           [LastName] =    @Lastname, " +
                                "           [Address]  =    @Address ," +
                                "           [City]     =    @City ,   " +
                                "           [State]    =    @State,  " +
                                "           [Zip]      =    @Zip , " +
                                "           [ContactNo1]=   @ContactNo1 ," +
                                "           [LoginId]    =  @Loginid  ," +
                                "           [Password]   =  @Password  ," +
                                "           [ModifiedOn] =  getdate()," +
                                "           [EmployeeNo] =  @EmployeeNo ," +
                                "           [email_address]=    @email_address ,empl_type_id = @empl_typeid, " +
                                "           [hourly_rate] =     @hourly_rate WHERE Loginid = @Loginid";

                String sqlUpdateRole = " UPDATE UserRole SET Roleid = @Roleid, Loginid = @Loginid, Modifiedon=getdate() WHERE Loginid = @Loginid";

                DbCommand dbCommand = db.GetSqlStringCommand(strUpdate);
                DbCommand dbCommand1 = db.GetSqlStringCommand(sqlUpdateRole);
                //for dbCommand
                db.AddInParameter(dbCommand, "@Firstname", DbType.String, FirstName);
                db.AddInParameter(dbCommand, "@Lastname", DbType.String, LastName);
                db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
                db.AddInParameter(dbCommand, "@City", DbType.String, City);
                db.AddInParameter(dbCommand, "@State", DbType.String, State);
                db.AddInParameter(dbCommand, "@Zip", DbType.String, Zip);
                db.AddInParameter(dbCommand, "@ContactNo1", DbType.String, ContactNo1);
                db.AddInParameter(dbCommand, "@Loginid", DbType.String, LoginId);
                db.AddInParameter(dbCommand, "@Password", DbType.String, Password);
                db.AddInParameter(dbCommand, "@EmployeeNo", DbType.String, EmployeeNo);
                db.AddInParameter(dbCommand, "@email_address", DbType.String, email_address);
                db.AddInParameter(dbCommand, "@hourly_rate", DbType.String, hourly_rate);
                db.AddInParameter(dbCommand, "@empl_typeid", DbType.Int32, empl_type_id);

                //for dbCommand1
                db.AddInParameter(dbCommand1, "@Loginid", DbType.String, LoginId);
                db.AddInParameter(dbCommand1, "@Roleid", DbType.String, Roleid);
                

                db.ExecuteNonQuery(dbCommand);
                db.ExecuteNonQuery(dbCommand1);
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


    public Boolean ManageWorkers(
                    String FirstName,
                    String LastName,
                    String Address,
                    String City,
                    String State,
                    String hourly_rate,
                    Int32 empl_type_id,String SSN, String Installer
        )
    {
        Database db = DatabaseFactory.CreateDatabase();
        try
        {
            if (!IsWorkerExists(FirstName, LastName))
            {
                String strInsert = " INSERT INTO [Worker_table] ( " +
                                    "           [worker_firstName]         ," +
                                    "           [worker_lastName]          ," +
                                    "           [Street]           ," +
                                    "           [City]              ,   " +
                                    "           [state_cd]             ,  " +
                                    "           [worker_type]      ,   " +
                                    "           ssn                 ,   " +
                                    "           User_id              ,   " +
                                    "           [rate_of_pay]       " +
                                    "          )" +
                                    "           Values(" +
                                    "           @FirstName          ," +
                                    "           @LastName           ," +
                                    "           @Address            , " +
                                    "           @City               ," +
                                    "           @State              , " +
                                    "           @empl_typeid      ," +
                                    "           @SSN            ," +
                                    "           @Installer      ," +
                                    "           @hourly_rate)";

                DbCommand dbCommand = db.GetSqlStringCommand(strInsert);

                //for dbCommand
                db.AddInParameter(dbCommand, "@Firstname", DbType.String, FirstName);
                db.AddInParameter(dbCommand, "@Lastname", DbType.String, LastName);
                db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
                db.AddInParameter(dbCommand, "@City", DbType.String, City);
                db.AddInParameter(dbCommand, "@State", DbType.String, State);
                db.AddInParameter(dbCommand, "@hourly_rate", DbType.String, hourly_rate);
                db.AddInParameter(dbCommand, "@empl_typeid", DbType.Int32, empl_type_id);
                db.AddInParameter(dbCommand, "@Installer", DbType.String, Installer);
                db.AddInParameter(dbCommand, "@SSN", DbType.String, SSN);
                db.ExecuteNonQuery(dbCommand);
            }
            else
            {
                String strUpdate = " UPDATE [Worker_table] SET " +
                                "           [worker_FirstName] =   @Firstname ,  " +
                                "           [worker_LastName] =    @Lastname, " +
                                "           [Street]  =    @Address ," +
                                "           [City]     =    @City ,   " +
                                "           [state_cd]    =    @State,  " +
                                "           worker_type = @empl_typeid, " +
                                "           [rate_of_pay] =     @hourly_rate WHERE worker_FirstName = @Firstname AND worker_LastName =    @Lastname";

                DbCommand dbCommand = db.GetSqlStringCommand(strUpdate);
                //DbCommand dbCommand1 = db.GetSqlStringCommand(sqlUpdateRole);
                //for dbCommand
                db.AddInParameter(dbCommand, "@Firstname", DbType.String, FirstName);
                db.AddInParameter(dbCommand, "@Lastname", DbType.String, LastName);
                db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
                db.AddInParameter(dbCommand, "@City", DbType.String, City);
                db.AddInParameter(dbCommand, "@State", DbType.String, State);
                db.AddInParameter(dbCommand, "@hourly_rate", DbType.String, hourly_rate);
                db.AddInParameter(dbCommand, "@empl_typeid", DbType.Int32, empl_type_id);
                db.AddInParameter(dbCommand, "@Installer", DbType.String, Installer);
                db.AddInParameter(dbCommand, "@SSN", DbType.String, SSN);
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

    public Boolean UpdateWorkers(
                   Int32 worker_id,
                   String FirstName,
                   String LastName,
                   String Address,
                   String City,
                   String State,
                   String hourly_rate,
                   Int32 empl_type_id, 
                   String SSN, 
                   String Installer)
    {

        Database db = DatabaseFactory.CreateDatabase();
        try
        {


               String strUpdate = " UPDATE [Worker_table] SET " +
                                "           [worker_FirstName] =   @Firstname ,  " +
                                "           [worker_LastName] =    @Lastname, " +
                                "           [Street]  =    @Street ," +
                                "           [City]     =    @City ,   " +
                                "           [state_cd]    =    @state_cd, ssn=@SSN, " +
                                "           [worker_type] = @worker_type, " +
                                "           [rate_of_pay] =     @hourly_rate WHERE worker_id =    @worker_id";

                DbCommand dbCommand = db.GetSqlStringCommand(strUpdate);
                //DbCommand dbCommand1 = db.GetSqlStringCommand(sqlUpdateRole);
                //for dbCommand
                db.AddInParameter(dbCommand, "@Firstname", DbType.String, FirstName);
                db.AddInParameter(dbCommand, "@Lastname", DbType.String, LastName);
                db.AddInParameter(dbCommand, "@Street", DbType.String, Address);
                db.AddInParameter(dbCommand, "@City", DbType.String, City);
                db.AddInParameter(dbCommand, "@state_cd", DbType.String, State);
                db.AddInParameter(dbCommand, "@hourly_rate", DbType.String, hourly_rate);
                db.AddInParameter(dbCommand, "@worker_type", DbType.Int32, empl_type_id);
                db.AddInParameter(dbCommand, "@SSN", DbType.String, SSN);
                db.AddInParameter(dbCommand, "@worker_id", DbType.Int32, worker_id);
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

    public DataSet GetStates()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * from List_State ";
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

    public DataSet GetCitiesForStates(String statecd)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " Select * from List_City WHERE statecd = @statecd";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@statecd", DbType.String, statecd);
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
    public Boolean ChangePass(String userid, String _newpass)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String strUpdate = " UPDATE [User] SET " +
                               "           [Password]   =  @Password  ," +
                               "           [ModifiedOn] =  getdate() Where loginid = @loginid";
            
            DbCommand dbCommand = db.GetSqlStringCommand(strUpdate);
            db.AddInParameter(dbCommand, "@loginid", DbType.String, userid);
            db.AddInParameter(dbCommand, "@Password", DbType.String, _newpass);

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

    public DataSet GetEmplyeeTypes()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " select * from list_empl_type";
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

    public DataSet GetEmplyeeTypesNOPM()
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = "  select * from list_installerl_type";
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
   
}
