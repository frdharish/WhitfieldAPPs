using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TallComponents.PDF.Layout;
using System.Drawing;

public partial class TallPDFTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        			if ( !this.IsPostBack )
			{
				invoiceDate.Text = DateTime.Now.ToLongDateString();
            
				Random RandomGenerator = new Random(DateTime.Now.Millisecond);
				invoiceNumber.Text = RandomGenerator.Next(1, 100).ToString();

				companyName.Text = "Dombo Enterprises, Inc.";
				companyAddress.Text = "PO box 1";
				companyPostalCode.Text = "1234 DP DomboPlace";
				companyCountry.Text = "DomboLand";

				shippingAndHandling.Text = "0";

			}

			for( int i = 0; i < NumberOfItems; i++ )
			{
				addItemLine( );
			}
    }
    private int NumberOfItems
		{
			get 
			{
				object numberOfItems = ViewState[ "NUMBER_ITEMS" ];
				if ( numberOfItems == null )
				{
					ViewState[ "NUMBER_ITEMS" ] = numberOfItems = 0;
				}
				return (int) numberOfItems;
			}
			set
			{
				ViewState[ "NUMBER_ITEMS" ] =  value; 
			}
		}

		void addItemRow( TallComponents.PDF.Layout.Table table, string name, string val )
		{
			Row row = table.Rows.Add();
			Cell cell = row.Cells.Add();
			//40%
			cell.PreferredWidth = (table.PreferredWidth / 10) * 4 - 5;
			cell.RightMargin = 10;
			cell.LeftMargin = 5;
			TextParagraph text = new TextParagraph();
			text.Fragments.Add( new Fragment( name, TallComponents.PDF.Layout.Font.HelveticaOblique, 9 ) );
			cell.Paragraphs.Add( text );
			cell = row.Cells.Add();
			//60%
			cell.PreferredWidth = ( table.PreferredWidth / 10 ) * 6 - 5;
			text = new TextParagraph();
			text.Fragments.Add( new Fragment( val, 9 ) );
			cell.Paragraphs.Add( text );
		}

		private void addItemLine( )
		{
			TableRow row = new TableRow();
			row.EnableViewState = true;

			TableCell cell = new TableCell();
			cell.EnableViewState = true;
			Control child = new TextBox();
		//	((TextBox)child).Width = TallComponents.PDF.Layout.Unit.Parse("100%");
 
			child.EnableViewState = true;
			cell.Controls.Add(child);
			row.Cells.Add(cell);

			cell = new TableCell();
			cell.EnableViewState = true;
			child = new TextBox();
			child.EnableViewState = true;
			cell.Controls.Add(child);
			row.Cells.Add(cell);

			cell = new TableCell();
			cell.EnableViewState = true;
			child = new TextBox();
			child.EnableViewState = true;
			cell.Controls.Add(child);
			row.Cells.Add(cell);

			cell = new TableCell();
			cell.EnableViewState = true;
			cell.Text = "&lt;calculated&gt;";
			row.Cells.Add(cell);

			orderTable.Rows.AddAt(orderTable.Rows.Count - 4, row);
		}

		private void btnAddLine_Click(object sender, System.EventArgs e)
		{
			NumberOfItems += 1;
			addItemLine( );
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Document document = new Document();
			Section section = document.Sections.Add();

//			TallComponents.PDF.Layout.Table headerTable = new TallComponents.PDF.Layout.Table();
//			
			Row row;
			Cell cell;
			TextParagraph text;
//
//			row = headerTable.Rows.Add();
//			
//			// INVOICE
//			cell = row.Cells.Add();
//			cell.PreferredWidth = ( section.PageSize.Width - section.LeftMargin - section.RightMargin ) / 2;
//			text = new TextParagraph();
//			text.Fragments.Add( new Fragment( "INVOICE", TallComponents.PDF.Layout.Font.HelveticaBold ) );
//			text.Alignment = Paragraph.HAlignment.Left;
//			cell.Paragraphs.Add( text );
//
//			// COMPANY
//			cell = row.Cells.Add();
//			cell.PreferredWidth = ( section.PageSize.Width - section.LeftMargin - section.RightMargin ) / 2;
//			text = new TextParagraph();
//			text.Fragments.Add( new Fragment( companyName.Text ) );
//			text.Alignment = Paragraph.HAlignment.Right;
//			cell.Paragraphs.Add( text );
//
//			// ADDRESS
//			row = headerTable.Rows.Add();
//			cell = row.Cells.Add();
//			cell.ColSpan = 2;
//			text = new TextParagraph();
//			text.Fragments.Add( new Fragment( companyAddress.Text ) );
//			text.Alignment = Paragraph.HAlignment.Right;
//			cell.Paragraphs.Add( text );
//
//			// POSTALCODE
//			row = headerTable.Rows.Add();
//			cell = row.Cells.Add();
//			cell.ColSpan = 2;
//			text = new TextParagraph();
//			text.Fragments.Add( new Fragment( companyPostalCode.Text ) );
//			text.Alignment = Paragraph.HAlignment.Right;
//			cell.Paragraphs.Add( text );
//
//			// COUNTRY
//			row = headerTable.Rows.Add();
//			cell = row.Cells.Add();
//			cell.ColSpan = 2;
//			text = new TextParagraph();
//			text.Fragments.Add( new Fragment( companyCountry.Text ) );
//			text.Alignment = Paragraph.HAlignment.Right;
//			cell.Paragraphs.Add( text );
//
//			headerTable.Border = new Border();
//			headerTable.Border.Bottom = new TallComponents.PDF.Layout.Pen();
//			section.Paragraphs.Add( headerTable );
//
//			TallComponents.PDF.Layout.Table invoiceTable = new TallComponents.PDF.Layout.Table();
//			invoiceTable.SpacingBefore = 10;
//
//			// INVOICE NUMBER
//			row = invoiceTable.Rows.Add();
//			cell = row.Cells.Add();
//			cell.PreferredWidth = section.PageSize.Width - section.LeftMargin - section.RightMargin;
//			text = new TextParagraph();
//			text.Fragments.Add( new Fragment( "Number", TallComponents.PDF.Layout.Font.HelveticaBold ) );
//			text.Fragments.Add( new Fragment( invoiceNumber.Text, TallComponents.PDF.Layout.Font.Helvetica ) );
//			text.Alignment = Paragraph.HAlignment.Right;
//			cell.Paragraphs.Add( text );
//
//			// INVOICE DATE 
//			row = invoiceTable.Rows.Add();
//			cell = row.Cells.Add();
//			cell.PreferredWidth = section.PageSize.Width - section.LeftMargin - section.RightMargin;
//			text = new TextParagraph();
//			text.Fragments.Add( new Fragment( "Date", TallComponents.PDF.Layout.Font.HelveticaBold ) );
//			text.Fragments.Add( new Fragment( invoiceDate.Text ) );
//			text.Alignment = Paragraph.HAlignment.Right;
//			cell.Paragraphs.Add( text );
//
//			section.Paragraphs.Add( invoiceTable );

			// INFO TABLE (contains billto and shipto tables)
			TallComponents.PDF.Layout.Table infoTable = new TallComponents.PDF.Layout.Table();
			infoTable.SpacingBefore = 20;
			section.Paragraphs.Add( infoTable );
			row = infoTable.Rows.Add();

			cell = row.Cells.Add();
			cell.PreferredWidth = ( section.PageSize.Width - section.LeftMargin - section.RightMargin ) / 2;
			cell.RightMargin = 5;
			cell.TopPadding = cell.BottomPadding = 5;
			cell.Border = new Border(Color.Black, 0.5, new TallComponents.PDF.Layout.SolidBrush( Color.LightGray ) );
			
			TallComponents.PDF.Layout.Table billToTable = new TallComponents.PDF.Layout.Table();
			billToTable.PreferredWidth = cell.PreferredWidth;
			cell.Paragraphs.Add( billToTable );

			cell = row.Cells.Add();
			cell.PreferredWidth = ( section.PageSize.Width - section.LeftMargin - section.RightMargin ) / 2;
			cell.LeftMargin = 5;
			cell.TopPadding = cell.BottomPadding = 5;
			cell.Border = new Border( Color.Black, 0.5, new TallComponents.PDF.Layout.SolidBrush( Color.LightGray ) );
			
			TallComponents.PDF.Layout.Table shipToTable = new TallComponents.PDF.Layout.Table();
			shipToTable.PreferredWidth = cell.PreferredWidth;
			cell.Paragraphs.Add( shipToTable );

			double demiPage = ( section.PageSize.Width - section.LeftMargin - section.RightMargin ) / 2;

			// BILL TO
			row = billToTable.Rows.Add();

			cell = row.Cells.Add();
			cell.LeftMargin = 5;
			cell.ColSpan = 2;
        
			text = new TextParagraph();
			text.Fragments.Add( new Fragment( "Bill to:", TallComponents.PDF.Layout.Font.HelveticaBold, 14 ) );
			cell.Paragraphs.Add( text );

			addItemRow( billToTable, "Name", billToName.Text );
			addItemRow( billToTable, "Address", billToAddress.Text );
			addItemRow( billToTable, "Contact person", billToContact.Text );
			addItemRow( billToTable, "Fax", billToFax.Text );

			// SHIP TO
			row = shipToTable.Rows.Add();

			cell = row.Cells.Add();
			cell.LeftMargin = 5;
			cell.ColSpan = 2;

			text = new TextParagraph();
			text.Fragments.Add( new Fragment( "Ship to:", TallComponents.PDF.Layout.Font.HelveticaBold, 14 ) );
			cell.Paragraphs.Add( text );

			addItemRow( shipToTable, "Method", shipMethod.Text );
			addItemRow( shipToTable, "Name", shipName.Text );
			addItemRow( shipToTable, "Address", shipAddress.Text );
			addItemRow( shipToTable, "Contact person", shipContact.Text );
			addItemRow( shipToTable, "E-mail", shipEmail.Text );

            TallComponents.PDF.Layout.Table itemsTable = new TallComponents.PDF.Layout.Table();
            itemsTable.SpacingBefore = 20;
            section.Paragraphs.Add(itemsTable);
            row = itemsTable.Rows.Add();
            row.Border = new Border();
            row.Border.Background = new TallComponents.PDF.Layout.SolidBrush(Color.LightGray);
            row.Border.Bottom = new TallComponents.PDF.Layout.Pen(Color.Black, 0.5);

            cell = row.Cells.Add();
            cell.PreferredWidth = (section.PageSize.Width - section.LeftMargin - section.RightMargin) / 2;
            text = new TextParagraph();
            text.Fragments.Add(new Fragment("Item"));
            cell.Paragraphs.Add(text);

            cell = row.Cells.Add();
            cell.PreferredWidth = (section.PageSize.Width - section.LeftMargin - section.RightMargin) / 6;
            text = new TextParagraph();
            text.Alignment = Paragraph.HAlignment.Right;
            text.Fragments.Add(new Fragment("Quantity"));
            cell.Paragraphs.Add(text);

            cell = row.Cells.Add();
            cell.PreferredWidth = (section.PageSize.Width - section.LeftMargin - section.RightMargin) / 6;
            text = new TextParagraph();
            text.Alignment = Paragraph.HAlignment.Right;
            text.Fragments.Add(new Fragment("Unit price"));
            cell.Paragraphs.Add(text);

            cell = row.Cells.Add();
            cell.PreferredWidth = (section.PageSize.Width - section.LeftMargin - section.RightMargin) / 6;
            text = new TextParagraph();
            text.Alignment = Paragraph.HAlignment.Right;
            text.Fragments.Add(new Fragment("Line total"));
            cell.Paragraphs.Add(text);

            double subTotal = 0;
            for (int i = 1; i < orderTable.Rows.Count && orderTable.Rows[i].Cells.Count == 4; i++)
            {
                row = new Row();
                row.TopMargin = 5;

                string item = (orderTable.Rows[i].Cells[0].Controls[0] as TextBox).Text;
                cell = row.Cells.Add();
                text = new TextParagraph();
                text.Fragments.Add(new Fragment(item));
                cell.Paragraphs.Add(text);

                int quantity = 0;
                try
                {
                    quantity = int.Parse((orderTable.Rows[i].Cells[1].Controls[0] as TextBox).Text);
                }
                catch (Exception /*ex*/ ) { }
                cell = row.Cells.Add();
                text = new TextParagraph();
                text.Fragments.Add(new Fragment(quantity.ToString()));
                text.Alignment = Paragraph.HAlignment.Right;
                cell.Paragraphs.Add(text);

                double unitPrice = 0;
                try
                {
                    unitPrice = double.Parse((orderTable.Rows[i].Cells[2].Controls[0] as TextBox).Text);
                }
                catch (Exception /*ex*/ ) { }
                cell = row.Cells.Add();
                text = new TextParagraph();
                text.Fragments.Add(new Fragment(string.Format("{0:f2}", unitPrice)));
                text.Alignment = Paragraph.HAlignment.Right;
                cell.Paragraphs.Add(text);

                double lineTotal = quantity * unitPrice;
                cell = row.Cells.Add();
                text = new TextParagraph();
                text.Fragments.Add(new Fragment(string.Format("{0:f2}", lineTotal)));
                text.Alignment = Paragraph.HAlignment.Right;
                cell.Paragraphs.Add(text);

                if (quantity > 0) itemsTable.Rows.Add(row);

                subTotal += lineTotal;
            }

            // SUBTOTAL
            row = itemsTable.Rows.Add();
            row.Border = new Border();
            row.Border.Top = new TallComponents.PDF.Layout.Pen(Color.Black, 0.5);
            row.TopPadding = 5;
            cell = row.Cells.Add();
            cell.ColSpan = 3;
            text = new TextParagraph();
            text.Fragments.Add(new Fragment("Subtotal"));
            text.Alignment = Paragraph.HAlignment.Right;
            cell.Paragraphs.Add(text);
            cell = row.Cells.Add();
            text = new TextParagraph();
            text.Fragments.Add(new Fragment(string.Format("{0:f2}", subTotal)));
            text.Alignment = Paragraph.HAlignment.Right;
            cell.Paragraphs.Add(text);

            // SHIPPING & HANDLING
            double shipping = double.Parse(shippingAndHandling.Text);
            row = itemsTable.Rows.Add();
            row.TopMargin = 5;
            cell = row.Cells.Add();
            cell.ColSpan = 3;
            text = new TextParagraph();
            text.Fragments.Add(new Fragment("Shipping & handling"));
            text.Alignment = Paragraph.HAlignment.Right;
            cell.Paragraphs.Add(text);
            cell = row.Cells.Add();
            text = new TextParagraph();
            text.Alignment = Paragraph.HAlignment.Right;
            if (shipping == 0)
            {
                text.Fragments.Add(new Fragment("n/a"));
            }
            else
            {
                text.Fragments.Add(new Fragment(string.Format("{0:f2}", shipping)));
            }
            text.Alignment = Paragraph.HAlignment.Right;
            cell.Paragraphs.Add(text);

            // VAT
            double vat = 0;

            if (chkVAT.Checked)
            {
                vat = 0.19 * (subTotal + shipping);
                row = itemsTable.Rows.Add();
                row.TopMargin = 5;
                cell = row.Cells.Add();
                cell.ColSpan = 3;
                text = new TextParagraph();
                text.Fragments.Add(new Fragment("19% VAT"));
                text.Alignment = Paragraph.HAlignment.Right;
                cell.Paragraphs.Add(text);
                cell = row.Cells.Add();
                text = new TextParagraph();
                text.Alignment = Paragraph.HAlignment.Right;
                text.Fragments.Add(new Fragment(string.Format("{0:f2}", vat)));
                text.Alignment = Paragraph.HAlignment.Right;
                cell.Paragraphs.Add(text);
            }

            // PAYMENT DUE
            row = itemsTable.Rows.Add();
            row.Border = new Border();
            row.Border.Top = new TallComponents.PDF.Layout.Pen(Color.Black, 0.5);
            row.Border.Background = new TallComponents.PDF.Layout.SolidBrush(Color.LightGray);
            row.TopMargin = 5;
            cell = row.Cells.Add();
            cell.ColSpan = 3;
            text = new TextParagraph();
            text.Fragments.Add(new Fragment("Payment due"));
            text.Alignment = Paragraph.HAlignment.Right;
            cell.Paragraphs.Add(text);
            cell = row.Cells.Add();
            text = new TextParagraph();
            text.Fragments.Add(new Fragment(string.Format("USD {0:f2}", subTotal + shipping + vat), TallComponents.PDF.Layout.Font.HelveticaBoldOblique));
            text.Alignment = Paragraph.HAlignment.Right;
            cell.Paragraphs.Add(text);

            // PAYMENT
            text = new TextParagraph();
            text.SpacingBefore = 20;
            text.Fragments.Add(new Fragment("Payment", TallComponents.PDF.Layout.Font.HelveticaBold, 14));
            section.Paragraphs.Add(text);

            text = new TextParagraph();
            text.SpacingBefore = 8;

            if (PaymentFull.Checked)
            {
                text.Fragments.Add(new Fragment("Paid in full"));
            }
            else if (PaymentCheck.Checked)
            {
                text.Fragments.Add(new Fragment("Send check payable to " + companyName.Text));
            }
            else if (PaymentOnline.Checked)
            {
                text.Fragments.Add(new Fragment("Purchase online using our shopping basket"));
                if (chkDiscountCoupon.Checked)
                {
                    text.Fragments.Add(new Fragment(" with discount coupon: " + discountCoupon.Text));
                }
            }

            section.Paragraphs.Add(text);

            // REMARKS
            if (remarks.Text.Trim().Length != 0)
            {
                text = new TextParagraph();
                text.SpacingBefore = 20;
                text.Fragments.Add(new Fragment("Remarks", TallComponents.PDF.Layout.Font.HelveticaBold, 14));
                section.Paragraphs.Add(text);

                text = new TextParagraph();
                text.SpacingBefore = 8;
                text.Fragments.Add(new Fragment(remarks.Text));
                section.Paragraphs.Add(text);
            }

			// Send to web client
			Response.Clear();
			document.Write( Response );
			Response.End();
		}

		private void Payment_ServerChange(object sender, System.EventArgs e)
		{
			chkDiscountCoupon.Disabled = !PaymentOnline.Checked;
			discountCoupon.Enabled = !chkDiscountCoupon.Disabled;
		}

}
