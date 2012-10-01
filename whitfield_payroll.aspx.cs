using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
public partial class whitfield_payroll : System.Web.UI.Page
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

    #region	Show Closing Tag
    public string ShowClosingTags()
    {

        return "</td></tr><tr><td colspan=\"8\">";

    }
    #endregion
    private void DisplayGrid()
    {
        try
        {
            WhitfieldPayroll _dbClass = new WhitfieldPayroll();
            DataSet _dsRecords = new DataSet();
            if (ddlEmpl.SelectedItem.Value == "1")
            {
                grdProj.Visible = false;
                grdEmpl.Visible = true;
                txtSelectionResultsEmpl.Text = "Employee Payroll Hours";
                txtSelectionResultsProj.Text = "";
                _dsRecords = _dbClass.GetPayRollHoursForEmployee(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
                PopulateDataGrid(_dsRecords, grdEmpl);
            }
            else
            {
                grdEmpl.Visible = false;
                grdProj.Visible = true;
                txtSelectionResultsProj.Text = "Project Payroll Hours";
                txtSelectionResultsEmpl.Text = "";
                _dsRecords = _dbClass.GetPayRollHoursForProjects(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
                PopulateDataGrid(_dsRecords,grdProj);
            }           

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

    public void grdEmpl_Itemcommand(Object sender, DataGridCommandEventArgs e)
    {
        String loginid = "";
        DataSet dsExpand = new DataSet();
        WhitfieldPayroll _dbClass = new WhitfieldPayroll();
        switch (e.CommandName)
        {

            case "Expand":
                {

                    loginid = Convert.ToString(grdEmpl.DataKeys[e.Item.ItemIndex]);
                    dsExpand = _dbClass.GetPayRollProjectHoursForEmployee(loginid, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
                    PlaceHolder exp = new PlaceHolder();
                    exp = (System.Web.UI.WebControls.PlaceHolder)e.Item.Cells[7].FindControl("ExpandedContent");
                    ImageButton img = new ImageButton();
                    img = (System.Web.UI.WebControls.ImageButton)e.Item.Cells[0].FindControl("btnExpand");
                    if (dsExpand.Tables[0].Rows.Count > 0)
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((Whitfield_Payroll_ByProject)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((Whitfield_Payroll_ByProject)(e.Item.FindControl("DynamicTable1"))).DisplayGrid(loginid, txtFromDate.Text.Trim(), txtToDate.Text.Trim());

                        }
                        else
                        {
                            exp.Visible = false;
                            ((Whitfield_Payroll_ByProject)(e.Item.FindControl("DynamicTable1"))).Visible = false;
                            img.ImageUrl = "assets/img/Plus.gif";
                        }
                    }
                    else
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            //((ViewDesignAdmin)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((Whitfield_Payroll_ByProject)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            ((Whitfield_Payroll_ByProject)(e.Item.FindControl("DynamicTable1"))).DisplayGrid(loginid, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
                        }
                        else
                        {
                            exp.Visible = false;
                            ((Whitfield_Payroll_ByProject)(e.Item.FindControl("DynamicTable1"))).Visible = false;
                            img.ImageUrl = "assets/img/Plus.gif";
                        }

                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void grdProj_Itemcommand(Object sender, DataGridCommandEventArgs e)
    {
        Int32 EstNum = 0;
        DataSet dsExpand = new DataSet();
        WhitfieldPayroll _dbClass = new WhitfieldPayroll();
        switch (e.CommandName)
        {

            case "Expand":
                {

                    EstNum = Convert.ToInt32(grdProj.DataKeys[e.Item.ItemIndex]);
                    dsExpand = _dbClass.GetPayRollEmployeeHoursForProject(EstNum, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
                    PlaceHolder exp = new PlaceHolder();
                    exp = (System.Web.UI.WebControls.PlaceHolder)e.Item.Cells[7].FindControl("ExpandedContent");
                    ImageButton img = new ImageButton();
                    img = (System.Web.UI.WebControls.ImageButton)e.Item.Cells[0].FindControl("btnExpand");
                    if (dsExpand.Tables[0].Rows.Count > 0)
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((Whitfield_Payroll_ByEmployee)(e.Item.FindControl("DynamicTable2"))).Visible = true;
                            ((Whitfield_Payroll_ByEmployee)(e.Item.FindControl("DynamicTable2"))).DisplayGrid(EstNum, txtFromDate.Text.Trim(), txtToDate.Text.Trim());

                        }
                        else
                        {
                            exp.Visible = false;
                            ((Whitfield_Payroll_ByEmployee)(e.Item.FindControl("DynamicTable2"))).Visible = false;
                            img.ImageUrl = "assets/img/Plus.gif";
                        }
                    }
                    else
                    {
                        if (img.ImageUrl == "assets/img/Plus.gif")
                        {
                            //((ViewDesignAdmin)(e.Item.FindControl("DynamicTable1"))).Visible = true;
                            img.ImageUrl = "assets/img/Minus.gif";
                            exp.Visible = true;
                            ((Whitfield_Payroll_ByEmployee)(e.Item.FindControl("DynamicTable2"))).Visible = true;
                            ((Whitfield_Payroll_ByEmployee)(e.Item.FindControl("DynamicTable2"))).DisplayGrid(EstNum, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
                        }
                        else
                        {
                            exp.Visible = false;
                            ((Whitfield_Payroll_ByEmployee)(e.Item.FindControl("DynamicTable2"))).Visible = false;
                            img.ImageUrl = "assets/img/Plus.gif";
                        }

                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void grdEmpl_OnItemDataBound(object sender, DataGridItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalEngHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[2].Text));
            TotalFabHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[3].Text));
            TotalfinHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[4].Text));
            TotalMiscHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[5].Text));
            TotalHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[6].Text));
            TotalPrice += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[7].Text));
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[1].Text = " Totals:";
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[2].Text = TotalEngHours.ToString();
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[3].Text = TotalFabHours.ToString();
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[4].Text = TotalfinHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[5].Text = TotalMiscHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[6].Text = TotalHours.ToString();
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[7].Text = TotalPrice.ToString();
            e.Item.Cells[7].Font.Bold = true;
            e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    public void grdProj_OnItemDataBound(object sender, DataGridItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TotalEngHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[2].Text));
            TotalFabHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[3].Text));
            TotalfinHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[4].Text));
            TotalMiscHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[5].Text));
            TotalHours += Convert.ToDecimal(Convert.ToDecimal(e.Item.Cells[6].Text));
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[1].Text = " Totals:";
            e.Item.Cells[1].Font.Bold = true;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[2].Text = TotalEngHours.ToString();
            e.Item.Cells[2].Font.Bold = true;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[3].Text = TotalFabHours.ToString();
            e.Item.Cells[3].Font.Bold = true;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[4].Text = TotalfinHours.ToString();
            e.Item.Cells[4].Font.Bold = true;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[5].Text = TotalMiscHours.ToString();
            e.Item.Cells[5].Font.Bold = true;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            e.Item.Cells[6].Text = TotalHours.ToString();
            e.Item.Cells[6].Font.Bold = true;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DisplayGrid();
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
}
