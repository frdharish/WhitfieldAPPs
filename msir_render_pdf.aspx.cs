using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.IO;
using System.Collections.Specialized;
using GDI = System.Drawing;

public partial class msir_render_pdf : System.Web.UI.Page
{
    protected String actionKey;
    protected String _reportdt;
    private Int32 _totFabHours = 0;
    private Int32 _totFinHours = 0;
    private Int32 _totEngHours = 0;
    private Int32 _totMiscHours = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection n = Request.QueryString;
        // See if any query string exists
        if (n.HasKeys())
        {
            //Get value
            actionKey = n.GetKey(0);
            _reportdt = n.Get(0);
        }

        whitfield_prod_reports _wpr = new whitfield_prod_reports();
        DataSet _ms = _wpr.GetReportForProject(_reportdt);
        GeneratePDF(_ms);
    }
    private Phrase BuildNewCell1(string CellHeading, string CellValue)
    {
        Phrase phrase2 = new Phrase(CellHeading, FontFactory.GetFont("Times-Roman", 8.0F, 0, new iTextSharp.text.Color(200, 200, 200)));
        phrase2.Add(new Phrase(CellValue, FontFactory.GetFont("Times-Roman", 8.0F, 0, new iTextSharp.text.Color(200, 200, 200))));
        return phrase2;
    }
    private Phrase BuildNewCell(string CellHeading, string CellValue)
    {
        Phrase phrase2 = new Phrase(CellHeading, FontFactory.GetFont("Times-Roman", 8.0F, 0, new iTextSharp.text.Color(255, 0, 0)));
        phrase2.Add(new Phrase(CellValue, FontFactory.GetFont("Times-Roman", 8.0F, 0, new iTextSharp.text.Color(0, 0, 0))));
        return phrase2;
    }

    private Phrase BuildNewCellSpanRows(string CellHeading, string CellValue)
    {
        // trial
        return null;
    }

    public void GeneratePDF(DataSet _ms)
    {
        String rpt_date = "";
        String Daily_notes = "";
        String Daily_comments = "";
        String Change_order_notes = ""; 

        DataTable dtPDFData = _ms.Tables[0];
        foreach (DataRow dRow in dtPDFData.Rows)
        {
            rpt_date            = dRow["rpt_date"] == DBNull.Value ? "" : dRow["rpt_date"].ToString();
            Daily_notes         = dRow["Daily_notes"] == DBNull.Value ? "" : dRow["Daily_notes"].ToString();
            Daily_comments      = dRow["Daily_comments"] == DBNull.Value ? "" : dRow["Daily_comments"].ToString();
            Change_order_notes  = dRow["Change_order_notes"] == DBNull.Value ? "" : dRow["Change_order_notes"].ToString();            
        }

        MemoryStream m = new MemoryStream();
        //Document document = new Document();
        Document document = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition","attachment;filename=DailyProjectReport.pdf");

            //PdfWriter.GetInstance(document, new FileStream("HarishTesting.pdf", FileMode.Create));
            PdfWriter writer = PdfWriter.GetInstance(document, m); 
            writer.CloseStream = false;

            document.AddAuthor("Whitfield Corporation");
            document.AddSubject("Daily Production REPORT");
            Phrase  phrase4 = new  Phrase();
            phrase4.Add(BuildNewCellSpanRows("Whitfield Corporation Daily Production Report for ", rpt_date));
            HeaderFooter headerFooter2 = new HeaderFooter(phrase4, false);
            headerFooter2.Border = 0;
            HeaderFooter headerFooter1 = new HeaderFooter(new Phrase("Page: ", FontFactory.GetFont("Times-Roman", 8.0F, 0, new iTextSharp.text.Color(0, 0, 0))), true);
            headerFooter1.Border = 0;
            document.Footer = headerFooter1;
            document.Header = headerFooter2;
            document.Open();
            iTextSharp.text.Table table1 = new iTextSharp.text.Table(2);
            table1.Padding = 4.0F;
            table1.Spacing = 0.0F;
            float[] fArr2 = new float[] { 24.0F, 24.0F };
            float[] fArr1 = fArr2;
            table1.WidthPercentage = 100.0F;
            Cell cell = new Cell(new Phrase("General Information", FontFactory.GetFont(FontFactory.HELVETICA, 18, iTextSharp.text.Font.BOLD)));
            cell.HorizontalAlignment =  1;
            cell.VerticalAlignment = 1;
            cell.Leading = 8.0F;
            cell.Colspan = 2;
            cell.Border = 0;
            cell.BackgroundColor = new iTextSharp.text.Color(190, 190, 190);
            table1.AddCell(cell);
            table1.DefaultCellBorderWidth = 1.0F;
            table1.DefaultRowspan = 1;
            table1.DefaultHorizontalAlignment = 0;

            //table1.AddCell(BuildNewCell("Report Date:", rpt_date.Trim()));

            //cell = new Cell(BuildNewCell("Daily Notes:", Daily_notes));
            //cell.Colspan = 2;
            //table1.AddCell(cell);

            cell = new Cell(BuildNewCell("Daily Comments:", Daily_comments));
            cell.Colspan = 2;
            table1.AddCell(cell);

            //cell = new Cell(BuildNewCell("Change Order Notes:", Change_order_notes));
            //cell.Colspan = 2;
            //table1.AddCell(cell);

            //table1.AddCell("");
            document.Add(table1);

            document.Add(GenerateCoreReport(rpt_date));

        }
        catch (DocumentException)
        {
            throw;
        }
        document.Close();
        Response.Buffer = true;
        Response.Clear();
        //Write pdf byes to outputstream
        Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();
    }

    public iTextSharp.text.Table GenerateCoreReport(String RptDate)
    {
        iTextSharp.text.Table datatable = new iTextSharp.text.Table(10);
        datatable.Padding = 4.0F;
        datatable.Spacing = 0.0F;
        //datatable.setBorder(Rectangle.NO_BORDER);
        int[] headerwidths = { 10, 24, 12, 12, 7, 7, 7, 7, 1, 1 };
 
        datatable.SetWidths(headerwidths);
        datatable.Width = 100;

        // the first cell spans 10 columns
        Cell cell = new Cell(new Phrase("Daily Production Report For " + RptDate, FontFactory.GetFont(FontFactory.HELVETICA, 18, iTextSharp.text.Font.BOLD)));
        cell.HorizontalAlignment = 1;
        cell.Leading = 30;
        cell.Colspan = 10;
        cell.Border =   iTextSharp.text.Rectangle.NO_BORDER;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        datatable.AddCell(cell);

        // These cells span 2 rows
        datatable.DefaultCellBorderWidth = 2;
        datatable.DefaultHorizontalAlignment = 1;
        datatable.DefaultRowspan = 2;
        datatable.AddCell("User Id");
        datatable.AddCell(new Phrase("Name", FontFactory.GetFont(FontFactory.HELVETICA, 14, iTextSharp.text.Font.BOLD)));
        datatable.AddCell("Work order");
        datatable.AddCell("Comments");

        // This cell spans the remaining 6 columns in 1 row
        datatable.DefaultRowspan = 1;
        datatable.DefaultColspan = 6;
        datatable.AddCell("Hours");

        // These cells span 1 row and 1 column
        datatable.DefaultColspan = 1;
        datatable.AddCell("Fab.");
        datatable.AddCell("Finish");
        datatable.AddCell("Eng.");
        datatable.AddCell("Misc.");
        datatable.AddCell("");
        datatable.AddCell("");

        //Here goes the Outer Loop to get the Project Information for the Day.Get the Project Name and display Here.
        whitfield_prod_reports _wproj = new whitfield_prod_reports();
        DataSet _mOuter = _wproj.GetProjectReportOuter(RptDate);
        DataTable dtProject = _mOuter.Tables[0];
        foreach (DataRow dProjRow in dtProject.Rows)
        {
            String _projNumber = dProjRow["TWC_Proj_Number"] == DBNull.Value ? "" : dProjRow["TWC_Proj_Number"].ToString();
            String _projName = dProjRow["ProjName"] == DBNull.Value ? "" : dProjRow["ProjName"].ToString();
            String _rptNumber = dProjRow["twc_report_number"] == DBNull.Value ? "" : dProjRow["twc_report_number"].ToString();

            Cell cell1 = new Cell(new Phrase(_projName + '(' + _projNumber + ')' , FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD)));
            cell1.HorizontalAlignment = 1;
            cell1.Leading = 30;
            cell1.Colspan = 10;
            cell1.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            cell1.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            datatable.AddCell(cell1);


            datatable.DefaultCellBorderWidth = 1;
            datatable.DefaultRowspan = 1;

            //Here Goes the Inner Loop for the Employees worked on the Project.
            DataSet _mInner = _wproj.GetProjectReportInner(Convert.ToInt32(_rptNumber), Convert.ToInt32(_projNumber));
            DataTable dtActivity = _mInner.Tables[0];
            foreach (DataRow drActivity in dtActivity.Rows)
            {
                datatable.DefaultHorizontalAlignment = 1;
                datatable.AddCell(drActivity["loginid"] == DBNull.Value ? "" : drActivity["loginid"].ToString());
                datatable.AddCell(drActivity["UName"] == DBNull.Value ? "" : drActivity["UName"].ToString());
                datatable.AddCell(drActivity["Description"] == DBNull.Value ? "" : drActivity["Description"].ToString());
                datatable.AddCell(drActivity["empl_comments"] == DBNull.Value ? "" : drActivity["empl_comments"].ToString());
                datatable.DefaultHorizontalAlignment = 0;
                datatable.AddCell(drActivity["fab_hours"] == DBNull.Value ? "0" : drActivity["fab_hours"].ToString());
                datatable.AddCell(drActivity["fin_hours"] == DBNull.Value ? "0" : drActivity["fin_hours"].ToString());
                datatable.AddCell(drActivity["eng_hours"] == DBNull.Value ? "0" : drActivity["eng_hours"].ToString());
                datatable.AddCell(drActivity["misc_hours"] == DBNull.Value ? "0" : drActivity["misc_hours"].ToString());
                _totFabHours += Convert.ToInt32(drActivity["fab_hours"] == DBNull.Value ? "0" : drActivity["fab_hours"].ToString());
                _totFinHours += Convert.ToInt32(drActivity["fin_hours"] == DBNull.Value ? "0" : drActivity["fin_hours"].ToString());
                _totEngHours += Convert.ToInt32(drActivity["eng_hours"] == DBNull.Value ? "0" : drActivity["eng_hours"].ToString());
                _totMiscHours += Convert.ToInt32(drActivity["misc_hours"] == DBNull.Value ? "0" : drActivity["misc_hours"].ToString());
                datatable.AddCell("");
                datatable.AddCell("");
            }
                    //Here goes the SubTotal Per project.. Dont Forget.
                    datatable.DefaultCellBorderWidth = 1;
                    datatable.DefaultRowspan = 1;
                    datatable.DefaultHorizontalAlignment = 1;
                    datatable.AddCell("");
                    datatable.AddCell("Subtotal:");
                    datatable.AddCell("");
                    datatable.AddCell("");
                    datatable.DefaultHorizontalAlignment = 0;
                    datatable.AddCell(_totFabHours.ToString());
                    datatable.AddCell(_totFinHours.ToString());
                    datatable.AddCell(_totEngHours.ToString());
                    datatable.AddCell(_totMiscHours.ToString());
                    datatable.AddCell("");
                    datatable.AddCell("");
                    //Subtotal calculation ends here.
            _totFabHours = 0;
            _totFinHours = 0;
            _totEngHours = 0;
            _totMiscHours = 0;
        }      
        return datatable;
    }


}
