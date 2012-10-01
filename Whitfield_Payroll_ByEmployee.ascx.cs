using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
public partial class Whitfield_Payroll_ByEmployee : System.Web.UI.UserControl
{
    private Decimal TotalEngHours = 0;
    private Decimal TotalFabHours = 0;
    private Decimal TotalfinHours = 0;
    private Decimal TotalMiscHours = 0;
    private Decimal TotalHours = 0;
    private Decimal TotalPrice = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void DisplayGrid(Int32 EstNum, String FromDate, String ToDate)
    {
        try
        {
            WhitfieldPayroll _dbClass = new WhitfieldPayroll();
            DataSet dsSubMats = _dbClass.GetPayRollEmployeeHoursForProject(EstNum, FromDate, ToDate);
            PopulateDataGrid(dsSubMats, grdEmpl);

        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    public void PopulateDataGrid(DataSet dsGridResults, DataGrid grdpl1)
    {
        Int32 resultCount = 0;
        if (dsGridResults.Tables.Count > 0)
            resultCount = dsGridResults.Tables[0].Rows.Count;
        Int32 maxResultItemInPage = 0;
        Int32 minResultItemInPage = 0;
        try
        {
            if (resultCount > 0)
            {

                DataTable tblInstallments = dsGridResults.Tables[0];
                //Display results in Grid
                if (resultCount > (grdpl1.CurrentPageIndex + 1) * grdpl1.PageSize)
                    maxResultItemInPage = (grdpl1.CurrentPageIndex + 1) * grdpl1.PageSize;

                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdpl1.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdpl1.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdpl1.Visible = true;
                grdpl1.DataSource = tblInstallments;
                grdpl1.DataBind();
            }
            else
            {
                grdpl1.Visible = false;
            }
        }
        catch (Exception exp)
        {

            Response.Write(exp.Message.ToString());
        }
    }

    public void grdEmpl_OnItemDataBound(object sender, DataGridItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalEngHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[1].Text));
            TotalFabHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[2].Text));
            TotalfinHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[3].Text));
            TotalMiscHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[4].Text));
            TotalHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[5].Text));
            TotalPrice += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[6].Text));
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[1].Text = TotalEngHours.ToString();
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[2].Text = TotalFabHours.ToString();
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[3].Text = TotalfinHours.ToString();
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[4].Text = TotalMiscHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[5].Text = TotalHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[6].Text = TotalPrice.ToString();
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Left;
        }
    }
}
