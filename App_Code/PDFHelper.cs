using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.IO;
using System.Collections.Specialized;
using GDI = System.Drawing;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Net;
using System.Text;
using System.Net.Mail;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
/// <summary>
/// Summary description for PDFHelper
/// </summary>
public class PDFHelper
{
    public String EstNum = "";
    public String IsFinancial = "N";
    public String txtprjname;
    public String lblPrjHeader;
    public String txtbasebid;
    public String txtfinalbid;
    public String txtdesc;
    public String txtNotes;
    public String txtBidDate;
    public String txtEditStartTime;
    public String txtARDt;
    public String txtawardDate;
    public String txtConstStdate;
    public String txtConstDuration;
    public String txtConstEndDate;
    public String txtfabEndDate;
    public String txtfabStartdate;
    public String txtfabdurationt;
    public String txtStreet;
    public String txtCity;
    public String txtState;
    public String txtzip;
    public String txtrealprjNumbert;
    public String prjArch;
    public String prjEsti;
    public String txtTotCotCost;
    public String txtEngRate;
    public String txtFabRate;
    public String txtInstRate;
    public String txtMiscRate;
    public String txtOverHeadRate;
    public String txtMarkUpPercent;
    public String txtDrawingDate;
    public String txtTypeOfWork;
    public String _filename;
	public PDFHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Maintaining Email Documents
    //***************Project documents******************************************************
    public Int32 GenerateseqNumberforDocs(Int32 EstNum, String doc_type)
    {
        Database db = DatabaseFactory.CreateDatabase();
        String sqlCommand = " Select IsNull(max(seq_num),0) seqID from [twc_email_documents] Where EstNum = @EstNum AND doc_type = @doc_type";
        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
        db.AddInParameter(dbCommand, "@doc_type", DbType.String, doc_type);
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
            String sqlCommand = " Select * FROM twc_email_documents  WHERE  EstNum = @EstNum";
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

    public void SetupEmailDocs(Int32 EstNum,Int32 seq_num, String doc_name, String doc_type)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            String sqlCommand = " INSERT INTO [twc_email_documents]  " +
                                "   (" +
                                "     [EstNum] , " +
                                "     [seq_num] ," +
                                "     [doc_name]  ," +
                                "     [doc_type] " +
                                "   )   " +
                                "   VALUES " +
                                "   (   " +
                                "      @EstNum" +
                                "     ,@seq_num" +
                                "     ,@doc_name" +
                                "     ,@doc_type " +
                                "   ) ";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@EstNum", DbType.Int32, EstNum);
            db.AddInParameter(dbCommand, "@seq_num", DbType.Int32, seq_num);
            db.AddInParameter(dbCommand, "@doc_name", DbType.String, doc_name);
            db.AddInParameter(dbCommand, "@doc_type", DbType.String, doc_type);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
    }

    #endregion 
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

    #region Helper methods
    /// <summary>
    /// Safely attempts to insert an image file into the document
    /// </summary>
    /// <param name="document">iTextSharp Document in which it needs to be inserted</param>
    /// <param name="sFilename">the name of the file to be inserted</param>
    /// <returns>false if failed to do so</returns>
    private iTextSharp.text.Image DoGetImageFile(string sFilename)
    {
        iTextSharp.text.Image img = null;

        try
        {

            if (File.Exists(sFilename))
            {
                img = iTextSharp.text.Image.GetInstance(sFilename);
            }

        }
        catch (Exception)
        {
            throw;
        }

        return img;
    }
    #endregion Helper files
    //public void GeneratePDF(DataSet _ms)
    public void GeneratePDF(String EstNum, String IsFinancial)
    {
        Whitfieldcore _wc = new Whitfieldcore();
        // MemoryStream m = new MemoryStream();
        // Document document = new Document();
        FileStream MyStream = null;
        Document document = new Document(PageSize.A4, 50, 50, 50, 50);
        try
        {
            iTextSharp.text.Font[] fonts = new iTextSharp.text.Font[16];
            fonts[0] = FontFactory.GetFont(FontFactory.COURIER, 8, iTextSharp.text.Font.NORMAL);
            fonts[1] = FontFactory.GetFont(FontFactory.COURIER, 8, iTextSharp.text.Font.BOLD);
            fonts[2] = FontFactory.GetFont(FontFactory.COURIER, 8, iTextSharp.text.Font.ITALIC);
            fonts[3] = FontFactory.GetFont(FontFactory.COURIER, 8, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC);
            fonts[4] = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
            fonts[5] = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD);
            fonts[6] = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.ITALIC);
            fonts[7] = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC);
            fonts[8] = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL);
            fonts[9] = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
            fonts[10] = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC);
            fonts[11] = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC);
            fonts[12] = FontFactory.GetFont(FontFactory.SYMBOL, 10, iTextSharp.text.Font.NORMAL);
            fonts[13] = FontFactory.GetFont(FontFactory.ZAPFDINGBATS, 10, iTextSharp.text.Font.NORMAL);
            fonts[14] = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.GRAY);
            fonts[15] = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.GRAY);

            // Response.ContentType = "application/pdf";
            // Response.AddHeader("content-disposition", "attachment;filename=Proposal_Document.pdf");
            //<Current Date> - <Project Name>, Architectural Millwork - WhitfieldCo
            //String _filename = DateTime.Now.ToString("MM-dd-yyyy") + "-"  + txtprjname  + ", Architectural Millwork - WhitfieldCo.pdf" 
            //PdfWriter.GetInstance(document, new FileStream(_filename, FileMode.Create));
            //PdfWriter writer = PdfWriter.GetInstance(document, m);
            //writer.CloseStream = false;

           

            IDataReader iReader = _wc.GetProjectInfo(Convert.ToInt32(EstNum));
            while (iReader.Read())
            {
                txtprjname = iReader["ProjName"] == DBNull.Value ? "" : iReader["ProjName"].ToString();
                lblPrjHeader = iReader["ProjName"] == DBNull.Value ? "" : iReader["ProjName"].ToString();
                txtbasebid = iReader["BaseBid"] == DBNull.Value ? "" : iReader["BaseBid"].ToString();
                txtfinalbid = iReader["FinalPrice"] == DBNull.Value ? "" : iReader["FinalPrice"].ToString();
                txtdesc = iReader["ProjDescr"] == DBNull.Value ? "" : iReader["ProjDescr"].ToString();
                txtNotes = iReader["Notes"] == DBNull.Value ? "" : iReader["Notes"].ToString();
                txtBidDate = iReader["BidDate"] == DBNull.Value ? "" : iReader["BidDate"].ToString();
                txtEditStartTime = iReader["BidTime"] == DBNull.Value ? "" : iReader["BidTime"].ToString();
                txtARDt = iReader["AwardDur"] == DBNull.Value ? "" : iReader["AwardDur"].ToString();
                txtawardDate = iReader["AwardDate"] == DBNull.Value ? "" : iReader["AwardDate"].ToString();
                txtConstStdate = iReader["ConstrStart"] == DBNull.Value ? "" : iReader["ConstrStart"].ToString();
                txtConstDuration = iReader["ConstrDur"] == DBNull.Value ? "" : iReader["ConstrDur"].ToString();
                txtConstEndDate = iReader["ConstrCompl"] == DBNull.Value ? DateTime.Now.ToString() : iReader["ConstrCompl"].ToString();
                //Adding New Fields
                txtfabEndDate = iReader["fab_end"] == DBNull.Value ? "" : iReader["fab_end"].ToString();
                txtfabStartdate = iReader["fab_start"] == DBNull.Value ? "" : iReader["fab_start"].ToString();
                txtfabdurationt = iReader["fab_duration"] == DBNull.Value ? "" : iReader["fab_duration"].ToString();
                txtStreet = iReader["prj_street"] == DBNull.Value ? "" : iReader["prj_street"].ToString();
                txtCity = iReader["prj_city"] == DBNull.Value ? "" : iReader["prj_city"].ToString();
                txtState = iReader["prj_state"] == DBNull.Value ? "" : iReader["prj_state"].ToString();
                txtzip = iReader["prj_zip"] == DBNull.Value ? "" : iReader["prj_zip"].ToString();
                //New Fields Ends
                txtrealprjNumbert = iReader["Real_proj_Number"] == DBNull.Value ? "" : iReader["Real_proj_Number"].ToString();
                prjArch = iReader["Architect"] == DBNull.Value ? "" : iReader["Architect"].ToString();
                prjEsti = iReader["loginid"] == DBNull.Value ? "" : iReader["loginid"].ToString();
                txtTotCotCost = iReader["Contengency"] == DBNull.Value ? "0" : iReader["Contengency"].ToString();
                txtEngRate = iReader["enghourrate"] == DBNull.Value ? "45.00" : iReader["enghourrate"].ToString();
                txtFabRate = iReader["fabhourrate"] == DBNull.Value ? "32.00" : iReader["fabhourrate"].ToString();
                txtInstRate = iReader["insthourrate"] == DBNull.Value ? "45.00" : iReader["insthourrate"].ToString();
                txtMiscRate = iReader["mischourrate"] == DBNull.Value ? "25.00" : iReader["mischourrate"].ToString();
                txtOverHeadRate = iReader["overheadrate"] == DBNull.Value ? "24.11" : iReader["overheadrate"].ToString();
                txtMarkUpPercent = iReader["profit_markup"] == DBNull.Value ? "15.00" : iReader["profit_markup"].ToString();
                txtDrawingDate = iReader["drawingdate"] == DBNull.Value ? "" : iReader["drawingdate"].ToString();
                txtTypeOfWork = iReader["typeofwork"] == DBNull.Value ? "" : iReader["typeofwork"].ToString();
            }

            Chunk chunkHeading;
            if (txtprjname.Length >= 30)
            {
                chunkHeading = new Chunk(txtprjname + "                                                                                                      ", fonts[15]);
            }
            else
            {
                chunkHeading = new Chunk(txtprjname + "                                                                                                                                      ", fonts[15]);
            }
     
            String _modetype = IsFinancial == "Y" ? "Proposal" : "Scope";

            Int32 _document_rev_number = GenerateseqNumberforDocs(Convert.ToInt32(EstNum), _modetype);

            _filename = DateTime.Now.ToString("MM-dd-yyyy") + "-" + txtprjname.Replace("."," ").Trim() + " Architectural Millwork - WhitfieldCo " + _modetype + "-REV 0" + _document_rev_number + ".pdf";
            
            
                //if (File.Exists(HttpContext.Current.Server.MapPath("~/attachments/") + _filename))  //If the file exists, create new one.
                //{
                //    //File.Delete(HttpContext.Current.Server.MapPath("~/attachments/") + _filename);
                //    char[] splitchar = { '.' };
                //    string[] strArr = null;
                //    strArr = _filename.Split(splitchar);
                //    String _filenmTest = strArr[0];
                //    int intIndexSubstring = 0;
                //    intIndexSubstring = _filenmTest.IndexOf("-REV#");
                //    _filename = DateTime.Now.ToString("MM-dd-yyyy") + "-" + txtprjname.Replace(".", " ").Trim() + " Architectural Millwork - WhitfieldCo " + _modetype  +"-REV#0" + (Convert.ToInt32(_filenmTest.Substring(intIndexSubstring).Substring(5)) + 1).ToString() + ".pdf";

                //}
                //FileStream MyStream;
                //MyStream = new FileStream(HttpContext.Current.Server.MapPath("~/attachments/") + _filename, FileMode.Create);
                //PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath("~/attachments/") + _filename, FileMode.Create));
                //using (StreamWriter sw = File.CreateText(mappath + "patientquery.txt"))


            using ( MyStream = new FileStream(HttpContext.Current.Server.MapPath("~/attachments/") + _filename, FileMode.Create))
            //using (FileStream MyStream = File.Create(HttpContext.Current.Server.MapPath("~/attachments/") + _filename))
            //new FileStream(HttpContext.Current.Server.MapPath("~/attachments/") + _filename, FileMode.Create)
            {
                PdfWriter.GetInstance(document, MyStream);
                //attachments
                document.AddAuthor("Whitfield Corporation");
                document.AddSubject("Proposal Generator");

                iTextSharp.text.Image img = this.DoGetImageFile(HttpContext.Current.Server.MapPath("~/assets/img/TWC Primary Logo1.JPG"));
                img.ScalePercent(50);
                Chunk ck = new Chunk(img, 0, -5);

                HeaderFooter headerRight = new HeaderFooter(new Phrase(chunkHeading), new Phrase(ck));
                document.Header = headerRight;
                headerRight.Alignment = iTextSharp.text.Rectangle.ALIGN_RIGHT;
                headerRight.Border = iTextSharp.text.Rectangle.NO_BORDER;


                // we Add a Footer that will show up on PAGE 1
                Phrase phFooter = new Phrase("The Whitfield Corporation, Incorporated  ", fonts[15]);
                phFooter.Add(new Phrase("P.O. Box 0385, Fulton, MD 20759  ", fonts[8]));
                phFooter.Add(new Phrase("Main: 301 483 0791 Fax: 301 483 0792  ", fonts[8]));
                phFooter.Add(new Phrase("\nDelivering on Promises", fonts[11]));
                //
                HeaderFooter footer = new HeaderFooter(phFooter, false);
                footer.Border = iTextSharp.text.Rectangle.NO_BORDER;
                footer.Alignment = iTextSharp.text.Rectangle.ALIGN_CENTER;
                document.Footer = footer;
                // step 3: we open the document
                document.Open();

                // we Add a Header that will show up on PAGE 2

                DateTime dt = DateTime.Now;
                //Chapters and Sections
                int ChapterSequence = 1;
                document.NewPage();
                iTextSharp.text.Font chapterFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font sectionFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Font subsectionFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

                //Chapter 1 Overview
                Paragraph cTitle = new Paragraph(_modetype, chapterFont);
                Chapter chapter = new Chapter(cTitle, ChapterSequence);

                Paragraph ChapterDate = new Paragraph(dt.ToString("\nMMMM dd, yyyy \n\n"), fonts[8]);
                Paragraph ChapterRef = new Paragraph("RE:   " + txtprjname + "\n\n", fonts[8]);

                Paragraph ChapterText1;

                if (txtTypeOfWork.Trim() == "Time & Material")
                {

                    ChapterText1 = new Paragraph("Whitfield proposes to complete the scope of work on a Time & Material basis per the rates included in the Item Breakdown section of this proposal.\n\n", fonts[8]);
                }
                else
                {
                    ChapterText1 = new Paragraph("Whitfield proposes to furnish all materials and perform all labor necessary, including " + txtTypeOfWork + ", to complete the following scope of work as per the Scope of Work breakdown.\n\n", fonts[8]);
                }

                String _fnlAmt = "";
                String amtWithnoDecimal = "";

                if (txtbasebid != "")
                {
                    string[] txtBaseBidStr = txtbasebid.Split('.');
                    custom.util.NumberToEnglish num = new custom.util.NumberToEnglish();
                    _fnlAmt = num.changeCurrencyToWords(txtBaseBidStr[0].Replace("$", "").Trim());
                    amtWithnoDecimal = txtBaseBidStr[0] + ".00";
                }

                contingency _cont = new contingency();
                if (IsFinancial == "Y")
                {

                    Paragraph ChapterText2;
                    if (txtTypeOfWork.Trim() == "Time & Material")
                    {
                        ChapterText2 = new Paragraph("The Material cost in the amount of " + _fnlAmt + " Dollars and No Cents (" + Convert.ToDecimal(amtWithnoDecimal).ToString("C") + ") includes all profit markup and assumes a construction start on approximately " + Convert.ToDateTime(txtConstStdate).ToString("MMMM dd, yyyy") + " with a completion on or around " + Convert.ToDateTime(txtConstEndDate).ToString("MMMM dd, yyyy") + " .\n\n", fonts[8]);
                        //ChapterText2.Add(new Phrase(new Chunk("This cost is in addition to any Time & Material cost and will be calculated on a unit price basis as included in the Item Breakdown section of this proposal for any time extension beyond the agreed upon construction schedule as included in this proposal.\n\n", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC | iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    }
                    else
                    {
                        ChapterText2 = new Paragraph("This proposal assumes all of the above work completed by " + Convert.ToDateTime(txtConstEndDate).ToString("MMMM dd, yyyy") + " for the sum of ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.ITALIC | iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK));
                        ChapterText2.Add(new Phrase(new Chunk(" " + _fnlAmt + "Dollars and No Cents (" + Convert.ToDecimal(amtWithnoDecimal).ToString("C") + ").\n\n", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.ITALIC | iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    }


                    chapter.Add(ChapterDate);
                    chapter.Add(ChapterRef);
                    chapter.Add(ChapterText1);
                    chapter.Add(ChapterText2);

                    // Chapter Item Breakdown
                    DataSet dsCont = _cont.FetchProjectItemBreakdown(Convert.ToInt32(EstNum));
                    if (dsCont.Tables[0].Rows.Count > 0)
                    {
                        Paragraph cBreakDown = new Paragraph("Item Breakdown", chapterFont);
                        chapter.Add(cBreakDown);
                        DataTable myValues;
                        myValues = dsCont.Tables[0];
                        int icntBreakDown = 1;
                        foreach (DataRow dRow in myValues.Rows)
                        {
                            String _cntlDesc = dRow["Description"] == DBNull.Value ? "" : dRow["Description"].ToString();
                            String _cntlAmt = dRow["Amount"] == DBNull.Value ? "" : dRow["Amount"].ToString();
                            Paragraph itemAlternatives = new Paragraph(icntBreakDown.ToString() + ". " + _cntlDesc + "...." + _cntlAmt, fonts[8]);
                            icntBreakDown++;
                            chapter.Add(itemAlternatives);
                        }

                    }

                    // Chapter Alternatives
                    DataSet dsAlternatives = _cont.FetchAlternatives(Convert.ToInt32(EstNum));
                    if (dsAlternatives.Tables[0].Rows.Count > 0)
                    {
                        Paragraph c = new Paragraph("\nAlternates", fonts[14]);
                        chapter.Add(c);
                        DataTable myValues;
                        myValues = dsAlternatives.Tables[0];
                        int icntAlternatives = 1;
                        foreach (DataRow dRow in myValues.Rows)
                        {
                            String _altType = dRow["Type"] == DBNull.Value ? "" : dRow["Type"].ToString();
                            String _cntlDesc = dRow["Description"] == DBNull.Value ? "" : dRow["Description"].ToString();
                            String _cntlAmt = dRow["Amount"] == DBNull.Value ? "" : dRow["Amount"].ToString();
                            Paragraph itemAlternatives = new Paragraph(icntAlternatives.ToString() + ". " + _altType + ":" + _cntlDesc + "...." + _cntlAmt, fonts[8]);
                            icntAlternatives++;
                            chapter.Add(itemAlternatives);
                        }
                    }
                    //document.Add(chapter);
                    //Chapters and Sections Declarations End.
                }

                //**********************Chapter for Itemized Scope of Work Begins
                //ChapterSequence++;
                Paragraph cAssumptions = new Paragraph("\nItemized Scope of Work", chapterFont);
                chapter.Add(cAssumptions);
                //Chapter chapterAssumptions = new Chapter(cAssumptions, ChapterSequence);

                //Paragraph AssumptionsHeading = new Paragraph("Scope of Work\n\n", sectionFont);
                Paragraph AssumptionsText1 = new Paragraph("Provided hereto is an itemized clarification of the proposed scope. It has been developed and derived from the pricing documents to clarify various assumptions that were considered while compiling this estimate. The General Conditions (listed last) occur throughout the scope of work and apply to “typical applications”, which are subsequently itemized in the corresponding breakdown. " + ".\n\n", fonts[8]);
                //AssumptionsText1.Add(new Phrase(new Chunk("Proposed price includes " + txtTypeOfWork + ".\n\n", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //chapterAssumptions.Add(AssumptionsHeading);
                chapter.Add(AssumptionsText1);

                DataSet dsScope = _wc.GetWorkOrders(EstNum);
                if (dsScope.Tables[0].Rows.Count > 0)
                {
                    LoadScopeOfWork(chapter, dsScope, fonts[14]);
                }

                Paragraph DrawingsPara1 = new Paragraph("Drawings:", fonts[14]);
                chapter.Add(DrawingsPara1);

                Paragraph itemDrawing = new Paragraph(txtprjname + " drawings prepared by " + _wc.GetArchitectName(Convert.ToInt32(prjArch)) + " dated " + txtDrawingDate + ".", fonts[8]);
                chapter.Add(itemDrawing);

                DataSet dsSpecs = _cont.FetchAmendmenList(Convert.ToInt32(EstNum));
                if (dsSpecs.Tables[0].Rows.Count > 0)
                {
                    Paragraph DrawingsPara = new Paragraph("\nAdditional Documents:", fonts[14]);
                    chapter.Add(DrawingsPara);
                    DataTable MyTerms;
                    MyTerms = dsSpecs.Tables[0];
                    int icntamendments = 1;
                    foreach (DataRow dRow in MyTerms.Rows)
                    {
                        String _AmedmentsType = dRow["type"] == DBNull.Value ? "" : dRow["type"].ToString();
                        String _AmedmentNumber = dRow["amendment_number"] == DBNull.Value ? "" : dRow["amendment_number"].ToString();
                        String _AmedmentDate = dRow["amendment_date"] == DBNull.Value ? "" : dRow["amendment_date"].ToString();
                        String amendment_impact = dRow["amendment_impact"] == DBNull.Value ? "" : dRow["amendment_impact"].ToString();
                        //if (_AmedmentsType == "Amendment")
                        //{
                        if (amendment_impact.ToLower() == "yes")
                        {
                            Paragraph itemAmendment = new Paragraph(icntamendments.ToString() + ". " + _AmedmentsType + " " + _AmedmentNumber + " dated " + _AmedmentDate + " impacts this scope of work.", fonts[8]);
                            chapter.Add(itemAmendment);
                            //Amendment 001 dated 11/19/2010; This Amendment has no impact to this scope of work.
                        }
                        else
                        {
                            Paragraph itemAmendment = new Paragraph(icntamendments.ToString() + ". " + _AmedmentsType + " " + _AmedmentNumber + " dated " + _AmedmentDate + " does not impact this scope of work.", fonts[8]);
                            chapter.Add(itemAmendment);
                        }

                        //}
                        //else
                        //{
                        //    Paragraph itemAmendment = new Paragraph(icntamendments.ToString() + ". " + _AmedmentsType + " " + _AmedmentNumber + " " + _AmedmentDate, fonts[8]);
                        //    chapter.Add(itemAmendment);
                        //}

                        icntamendments++;
                    }
                }
                //Qualifications
                DataSet dsConditions = _wc.GetSpecExcl(Convert.ToInt32(EstNum));
                if (dsConditions.Tables[0].Rows.Count > 0)
                {
                    Paragraph DrawingsPara = new Paragraph("\nQualifications:", fonts[14]);
                    chapter.Add(DrawingsPara);
                    int icnt = 1;
                    DataTable MyConditions;
                    MyConditions = dsConditions.Tables[0];
                    int tQualid = 0;
                    foreach (DataRow dRow in MyConditions.Rows)
                    {
                        if (Convert.ToInt32(dRow["qual_id"].ToString()) != tQualid)
                        {
                            Paragraph itemheading = new Paragraph(dRow["gName1"].ToString(), fonts[9]);
                            chapter.Add(itemheading);
                        }
                        String _cntlDesc = dRow["description"] == DBNull.Value ? "" : dRow["description"].ToString();
                        Paragraph itemTerms = new Paragraph(icnt.ToString() + ".  " + _cntlDesc, fonts[8]);
                        chapter.Add(itemTerms);
                        tQualid = Convert.ToInt32(dRow["qual_id"].ToString());
                        icnt++;
                    }
                }

                // document.Add(chapter);
                //************************Chapter for Itemized Scope of Work Ends

                //*******Chapter Terms Begins********************
                //ChapterSequence++;
                Paragraph cTerms = new Paragraph("\nTerms", fonts[14]);
                //Chapter chapterTerms = new Chapter(cTerms, ChapterSequence);
                chapter.Add(cTerms);
                //Chapter chapterTerms = new Chapter(cTerms, ChapterSequence);
                DataSet dsTerms = _wc.GetTerms(Convert.ToInt32(EstNum));

                if (dsTerms.Tables[0].Rows.Count > 0)
                {
                    DataTable MyTerms;
                    MyTerms = dsTerms.Tables[0];
                    int icntTerms = 1;
                    foreach (DataRow dRow in MyTerms.Rows)
                    {
                        String _cntlDesc = dRow["description"] == DBNull.Value ? "" : dRow["description"].ToString();
                        Paragraph itemTerms = new Paragraph(icntTerms.ToString() + ". " + _cntlDesc, fonts[8]);
                        chapter.Add(itemTerms);
                        icntTerms++;
                    }
                }

                
                Paragraph ChapterFooterText1 = new Paragraph("\nAll or part of the contract amount may be subject to change pending completion delay beyond agreed completion date and/or if changes to quantities are made. All agreements must be in writing prior to execution of any work.\n\n", fonts[8]);
                ChapterFooterText1.Add(Chunk.NEWLINE);
                ChapterFooterText1.Add(new Chunk("Respectfully submitted, ", fonts[8]));
                ChapterFooterText1.Add(new Chunk("                                                                  "));
                ChapterFooterText1.Add(new Chunk("Accepted By:, ", fonts[8]));
                ChapterFooterText1.Add(Chunk.NEWLINE);
                ChapterFooterText1.Add(new Chunk("The Whitfield Co., Inc., ", fonts[8]));
                ChapterFooterText1.Add(new Chunk("                                                                      "));
                ChapterFooterText1.Add(new Chunk("________________________ Date_________", fonts[8]));
                ChapterFooterText1.Add(Chunk.NEWLINE);
                ChapterFooterText1.Add(new Chunk("Jammie Whitfield, ", fonts[8]));
                ChapterFooterText1.Add(new Chunk("                                                                              "));
                ChapterFooterText1.Add(new Chunk("Name, Title", fonts[8]));
                //Paragraph ChapterFooterText2 = new Paragraph("Respectfully submitted,", fonts[8]);
                //Paragraph ChapterFooterText3 = new Paragraph("The Whitfield Co., Inc.\n\n", fonts[8]);
                //Paragraph ChapterFooterText4 = new Paragraph("Jammie Whitfield,", fonts[8]);
                //Paragraph ChapterFooterText5 = new Paragraph("Estimator", fonts[8]);

                chapter.Add(ChapterFooterText1);
                // Paragraph ChapterFooterText2 = new Paragraph("Respectfully submitted,", fonts[8]);
               // Paragraph ChapterFooterText3 = new Paragraph("The Whitfield Co., Inc.\n\n", fonts[8]);
                //Paragraph ChapterFooterText4 = new Paragraph("Jammie Whitfield,\n\n", fonts[8]);
                //Paragraph ChapterFooterText5 = new Paragraph("Accepted By:\n\n", fonts[8]);
               // Paragraph ChapterFooterText6 = new Paragraph("________________________ Date__________", fonts[8]);
               // Paragraph ChapterFooterText7 = new Paragraph("Name, Title", fonts[8]);

                chapter.Add(ChapterFooterText1);
               // chapter.Add(ChapterFooterText2);
               // chapter.Add(ChapterFooterText3);
               // chapter.Add(ChapterFooterText4);
               // chapter.Add(ChapterFooterText5);
                document.Add(chapter);

                //document.Add(new Chunk("Respectfully submitted, ", fonts[8]));
                //document.Add(new Chunk("                                                               "));
                //document.Add(new Chunk("Accepted By:, ", fonts[8]));
                //document.Add(Chunk.NEWLINE);
                //document.Add(new Chunk("The Whitfield Co., Inc., ", fonts[8]));
                //document.Add(new Chunk("                                                            "));
                //document.Add(new Chunk("________________________ Date_________", fonts[8]));
                //document.Add(Chunk.NEWLINE);
                //document.Add(new Chunk("Jammie Whitfield, ", fonts[8]));
                //document.Add(new Chunk("                                                                     "));
                //document.Add(new Chunk("Name, Title", fonts[8]));
                //*******Chapter Terms Ends********************
                document.Close();
                //MyStream.Flush();
                //MyStream.Close();
                //MyStream.Dispose();
                //}
                SetupEmailDocs(Convert.ToInt32(EstNum), _document_rev_number, _filename, _modetype);
                sendEmail(EstNum, _filename, IsFinancial);
            }
        }
        catch (DocumentException ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }
        finally
        {
            if (MyStream != null)
            {
                MyStream.Close();
                MyStream.Dispose();
            }
        } 
  
        //Response.Buffer = true;
        //Response.Clear();
        //Write pdf byes to outputstream
        //Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
        //Response.OutputStream.Flush();
        //Response.End();
  
    }

    private void sendEmail(String _estNum, String filenm, String IsFinancial)
    {

        Whitfieldcore _wcore = new Whitfieldcore();
        whitfielduser _wuser = new whitfielduser();
        using (DataSet dsContacts = _wcore.GetContactsForProject(Convert.ToInt32(_estNum)))
        {
            DataTable dtContacts = dsContacts.Tables[0];
            if (dtContacts.Rows.Count > 0)
            {
                foreach (DataRow dRow in dtContacts.Rows)
                {

                    String _contactNm = dRow["contactName"] == DBNull.Value ? " " : dRow["contactName"].ToString();
                    String _contactEmail = dRow["email"] == DBNull.Value ? " " : dRow["email"].ToString();
                    String _clientnm = dRow["Name"] == DBNull.Value ? " " : dRow["Name"].ToString();
                    String _contactNumber = _wuser.GetContactNo(prjEsti);

                    String mode = "";
                    if (IsFinancial == "Y")
                    {
                        mode = "Proposal";
                    }
                    else
                    {
                        mode = "Scope";
                    }

                    //HHS Uncomment this portion when there is an email list.
                    MailMessage message = new MailMessage();

                    //message.To.Add(System.Configuration.ConfigurationManager.AppSettings["devEmail"]);

                    //message.To.Add(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"].ToString());


                    message.To.Add(_contactEmail); //This will be added once JW oks the function
                    message.To.Add(System.Configuration.ConfigurationManager.AppSettings["EstimatingEmail"].ToString());  //This is tested for contact Email, remove once JW oks the function.

                    message.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["EstimatingEmail"]);
                    message.Subject = txtprjname + " Architectural Millwork - WhitfieldCo - " + mode;
                    message.IsBodyHtml = true;

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html><head></head>");
                    sb.Append("<body>");                  


                    sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
                    sb.Append("<TD>");

                    

                    sb.Append(_contactNm.Replace(",", " ")  + ",<br>");
                    sb.Append("<br>Thank you for the opportunity to provide pricing on the " + txtprjname + " project for " +  _clientnm + ". <br>");
                    sb.Append("<br>Please find attached our " + mode + " for the Custom Architectural Millwork which includes a complete and comprehensive scope for this work.<br>");
                    sb.Append("<br>You may contact me at " + _contactNumber + " with any questions regarding this estimate.<br>");
                    //sb.Append(<br>"_wuser.GetEstimatorName(prjEsti));
                    sb.Append("<br>" + txtNotes);
                    sb.Append("<br><br>" + _wuser.GetEstimatorName(prjEsti)+ ",<br>");
                    sb.Append("Estimator");
                    sb.Append("<br><br>");
                    sb.Append("</TD>");
                    sb.Append("</TR></TABLE>");


                    //Footer
                    sb.Append("<TABLE cellSpacing='0' cellPadding='0' width='100%' border='0'><TR>");
                    sb.Append("<TD><IMG height='80' alt='' src='http://www.whitfield-co.com/whitfield-co/assets/img/TWC%20Primary%20Logo1.JPG' border='0'></TD></TR>");
                    sb.Append("<TR><TD class='form1' vAlign='bottom' align='left' width='100%'><b>The Whitfield Co., Inc.<br>");
                    sb.Append("8836 Washington Blvd., Ste 101<br>");
                    sb.Append("Jessup, MD 20794<br>");
                    sb.Append("(301)-483-0791<br>");
                    sb.Append("(301)-483-0792<br>");
                    sb.Append("http://www.whitfield-co.com<br>");
                    sb.Append("<IMG height='9' alt='' src='http://www.whitfield-co.com/whitfield-co/assets/img/images.gif' width='1'>");
                    sb.Append("</TD>");
                    sb.Append("</TR></TABLE>");
                    sb.Append("</body></html>");
                    message.Body = sb.ToString();

                    message.Attachments.Add(new System.Net.Mail.Attachment(HttpContext.Current.Server.MapPath("~/attachments/") + filenm));
                    SmtpClient smtp = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp"]);
                    smtp.Send(message);

                    if (!_contactEmail.Equals(""))
                    {
                        _wcore.InsertEmailConversation(Convert.ToInt32(_estNum), _contactEmail, _contactNm, DateTime.Now.ToString("MM-dd-yyyy"), DateTime.Now.ToString("T"), mode);
                    }
                }
            }
        }
    }
    private void LoadScopeOfWork(Chapter chapterScope, DataSet ds, iTextSharp.text.Font font1)
    {
        int NumColumns = 4;
        try
        {
            // we add some meta information to the document
            //Paragraph DrawingsPara = new Paragraph("Scope of Work:\n\n", font1);
            //chapterScope.Add(DrawingsPara);

            PdfPTable datatable = new PdfPTable(NumColumns);
            //iTextSharp.text.Table datatable = new iTextSharp.text.Table(NumColumns);
            datatable.DefaultCell.Padding = 4;
            float[] headerwidths = { 8, 20, 45, 20 }; // percentage
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage

            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.AddCell("No.");
            datatable.AddCell(new Phrase("No.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            //datatable.AddCell("Description");
            datatable.AddCell(new Phrase("Description", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            //datatable.AddCell("Notes");
            datatable.AddCell(new Phrase("Notes", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            //datatable.AddCell("Reference");
            datatable.AddCell(new Phrase("Reference", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.NORMAL)));
            datatable.HeaderRows = 1;  // this is the end of the table header
            datatable.DefaultCell.BorderWidth = 1;

            int i = 1;
            DataTable MyScope;
            MyScope = ds.Tables[0];

            foreach (DataRow dRow in MyScope.Rows)
            {
                String _number = dRow["work_order_id"] == DBNull.Value ? "" : dRow["work_order_id"].ToString();
                String _description = dRow["Description"] == DBNull.Value ? "" : dRow["Description"].ToString();
                String _notes = dRow["notes1"] == DBNull.Value ? "" : dRow["notes1"].ToString();
                String _reference = dRow["reftext"] == DBNull.Value ? "" : dRow["reftext"].ToString();
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                if (i % 2 == 1)
                {
                    datatable.DefaultCell.GrayFill = 0.9f;
                }
                datatable.AddCell(new Phrase(_number, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                datatable.AddCell(new Phrase(_description, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                datatable.AddCell(new Phrase(_notes, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));
                datatable.AddCell(new Phrase(_reference, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)));

                if (i % 2 == 1)
                {
                    datatable.DefaultCell.GrayFill = 1.0f;
                }
                i++;
            }
            chapterScope.Add(datatable);
        }
        catch (Exception ex)
        {
            HttpResponse objResponse = HttpContext.Current.Response;
            objResponse.Write(ex.Message);
        }

    }
}