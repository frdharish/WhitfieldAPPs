using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Web.UI.HtmlControls;

public partial class Newestimate_material : System.Web.UI.Page
{
    public Int32 EstNum;
    protected void Page_Load(object sender, EventArgs e)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        if (!Page.IsPostBack)
        {
            // 1 Get collection
            NameValueCollection n = Request.QueryString;
            // 2 See if any query string exists
            if (n.HasKeys())
            {
                // 3 Get first key and value
                string k = n.GetKey(0);
                string v = n.Get(0);
                // 4
                // Test different keys
                EstNum = Convert.ToInt32(v);
                hidEstNum.Value = EstNum.ToString();
            }
            GenerateJScript();
            ViewState["EstNum"] = EstNum.ToString();
            BindMaterialTypes();
            BindSubMaterials();

        }
    }
    public void GenerateJScript()
    {
        Type cstype = this.GetType();

        string strScript;
        strScript = "<script language=JavaScript>								";
        strScript += "function CheckAll( checkAllBox )							";
        strScript += "{															";
        strScript += "	var frm = document.Form1;								";
        strScript += "	var ChkState=checkAllBox.checked;						";
        strScript += "	for(i=0;i< frm.length;i++)								";
        strScript += "	{														";
        strScript += "		e=frm.elements[i];									";
        strScript += "        if(e.type=='checkbox' && e.name.indexOf('Id') != -1)";
        strScript += "            e.checked= ChkState ;							";
        strScript += "	}														";
        strScript += "}															";
        strScript += " </script>													";

        if (!ClientScript.IsClientScriptBlockRegistered(cstype, "clientScriptCheckAll"))
            ClientScript.RegisterClientScriptBlock(cstype, "clientScriptCheckAll", strScript);

        strScript = "";
        strScript = "<script language=JavaScript>								";
        strScript += "function CheckChanged()										";
        strScript += "{															";
        strScript += "  var frm = document.Form1;									";
        strScript += "  var boolAllChecked;										";
        strScript += "  boolAllChecked=true;										";
        strScript += "  for(i=0;i< frm.length;i++)								";
        strScript += "  {															";
        strScript += "    e=frm.elements[i];										";
        strScript += "	if ( e.type=='checkbox' && e.name.indexOf('Id') != -1 ) ";
        strScript += "      if(e.checked== false)									";
        strScript += "      {														";
        strScript += "		boolAllChecked=false;								";
        strScript += "		break;												";
        strScript += "      }														";
        strScript += "  }															";
        strScript += "  for(i=0;i< frm.length;i++)								";
        strScript += "  {															";
        strScript += "    e=frm.elements[i];										";
        strScript += "    if ( e.type=='checkbox' && e.name.indexOf('checkAll') != -1 )";
        strScript += "    {														";
        strScript += "      if( boolAllChecked==false)							";
        strScript += "		 e.checked= false ;									";
        strScript += "		 else												";
        strScript += "		 e.checked= true;									";
        strScript += "      break;												";
        strScript += "    }														";
        strScript += "   }														";
        strScript += " }															";
        strScript += " </script>													";

        if (!ClientScript.IsClientScriptBlockRegistered(cstype ,"clientScriptCheckChanged"))
            ClientScript.RegisterClientScriptBlock(cstype,"clientScriptCheckChanged", strScript);
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        Whitfieldcore wUser = new Whitfieldcore();
        //ArrayList chkArray = GetSelectedItems(ChkProjContacts
        foreach (DataGridItem di in grdRpResults.Items)
        {
            HtmlInputCheckBox chkBx = (HtmlInputCheckBox)di.FindControl("EmpId");
            if (chkBx != null && chkBx.Checked)
            {
                Label lbl = (Label)di.FindControl("Id");
                if (!wUser.IsMaterialExistsInEstimate(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(lbl.Text)))
                {
                        wUser.PopulateMaterialinEstimation(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(lbl.Text));
                }
                    //Response.Write(lbl.Text + "<br>");
            }
        }
        //for (int i = 0; i < RdoPrjClient.Items.Count; i++)
        //{
        //    if (RdoPrjClient.Items[i].Selected)
        //        wUser.PopulateMaterialinEstimation(Convert.ToInt32(ViewState["EstNum"].ToString()), Convert.ToInt32(RdoPrjClient.Items[i].Value));
       // }
        //Response.Write("<script language='javascript'>parent.location.replace('whitfield_estimation.aspx');</script>");
        //Uncomment here
        Response.Write("<script language='javascript'>parent.location.replace('Whitfield_estimation.aspx?EstNum=" + ViewState["EstNum"].ToString() + "');</script>");
    }
    private void BindMaterialTypes()
    {
        try
        {
            Whitfieldcore _dbClass = new Whitfieldcore();
            DataSet dsportfolio = new DataSet();
            dsportfolio = _dbClass.GetAllMaterialTypes();
            if (dsportfolio.Tables[0].Rows.Count > 0)
            {

                ddlMatType.DataSource = dsportfolio;
                ddlMatType.DataTextField = "Mat_type_Desc";
                ddlMatType.DataValueField = "Mat_type_id";
                ddlMatType.DataBind();
                ddlMatType.Items.Insert(0, common.AddItemToList("Fetch All Material Types", "0"));
            }
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }
    protected void ddlMatType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubMaterials();
    }
    private void BindSubMaterials()
    {
        DataSet dsGrp = new DataSet();
        Whitfieldcore wUser = new Whitfieldcore();
        dsGrp = wUser.GetAllSubMaterials(ddlMatType.SelectedItem.Value,"Grid");
        this.PopulateDataGrid(dsGrp);  
       // if (dsGrp.Tables[0].Rows.Count > 0)
      //  {
            //RdoPrjClient.DataSource = dsGrp;
            //RdoPrjClient.DataTextField = "matdesc";
            //RdoPrjClient.DataValueField = "sub_mat_id";
            //RdoPrjClient.DataBind();
       // }
    }
    public void PageResultGrid1(object sender, DataGridPageChangedEventArgs e)
    {

        DataSet dsGridResults;
        grdRpResults.CurrentPageIndex = e.NewPageIndex;
        Whitfieldcore wUser = new Whitfieldcore();
        dsGridResults = wUser.GetAllSubMaterials(ddlMatType.SelectedItem.Value, "Grid");
        this.PopulateDataGrid(dsGridResults);  

    }
    private void PopulateDataGrid(DataSet dsGridResults)
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
                if (resultCount > (grdRpResults.CurrentPageIndex + 1) * grdRpResults.PageSize)
                    maxResultItemInPage = (grdRpResults.CurrentPageIndex + 1) * grdRpResults.PageSize;
                else
                    maxResultItemInPage = resultCount;
                if (maxResultItemInPage - (grdRpResults.PageSize - 1) > 1)
                    minResultItemInPage = maxResultItemInPage - (grdRpResults.PageSize - 1);
                else
                    minResultItemInPage = 1;
                grdRpResults.Visible = true;
                grdRpResults.DataSource = tblInstallments;
                grdRpResults.DataBind();
                //Display the results message line
                //txtSelectionResultsMSG.Text = "Your selection found " + dsGridResults.Tables[0].Rows.Count + " contacts(s). Displaying users " + minResultItemInPage.ToString() + " - " + maxResultItemInPage.ToString() + ".";
            }
            else
            {
                //txtSelectionResultsMSG.Text = "No Contacts Setup yet.";
                grdRpResults.Visible = false;
            }
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
}
