using System;using System.Web.UI.WebControls;using System.Data;using System.Web;using System.Collections;using System.IO;using System.Web.UI.HtmlControls;using System.Web.UI;

/// <summary>
	/// Summary description for common.
	/// </summary>
	public class common
	{
		public common()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region Load Data From cookie
		public static void LoadDataFromCookie(string currPageName,HtmlForm frmCurrForm )
		{
			if (HttpContext.Current.Request.Cookies[currPageName]!=null)
			{
				string searchFields = HttpContext.Current.Request.Cookies[currPageName].Value;

				if (searchFields.Trim()!="")
				{
					Array arrFlds = searchFields.Split(',');

					if (arrFlds.Length>0)
					{
						for(int cntr=0;cntr<arrFlds.Length;cntr++)
						{
							Array arrFldsWithValue = arrFlds.GetValue(cntr).ToString().Split(':');

							if (arrFldsWithValue.Length>0)
							{
								if (arrFldsWithValue.GetValue(0).ToString().StartsWith("txt"))
								{	
									//*- text box 
									((TextBox) frmCurrForm.FindControl(arrFldsWithValue.GetValue(0).ToString())).Text=(arrFldsWithValue.GetValue(1)==null)? "":arrFldsWithValue.GetValue(1).ToString().Trim();
				

								}
								else if ((arrFldsWithValue.GetValue(0).ToString().StartsWith("dbl"))||
									(arrFldsWithValue.GetValue(0).ToString().StartsWith("ddl"))||
									(arrFldsWithValue.GetValue(0).ToString().StartsWith("lst")))
								{
									// list box
									((DropDownList)frmCurrForm.FindControl(arrFldsWithValue.GetValue(0).ToString())).SelectedValue	= (arrFldsWithValue.GetValue(1)==null)? "":arrFldsWithValue.GetValue(1).ToString().Trim();
									//(arrFldsWithValue.GetValue(0).ToString())).SelectedValue = (arrFldsWithValue.GetValue(1)==null)? "":arrFldsWithValue.GetValue(0).ToString();
								}
							}
						}
					}
				}
			}
		}
		#endregion
		
		#region Create Cookie

		public static void CreateCookie(string cookieName, string cookieValue, DateTime expiretime)
		{	
			if (HttpContext.Current.Request.Cookies.Get(cookieName)!=null)
			{
				HttpContext.Current.Response.Cookies.Remove(cookieName);
			}

			HttpCookie newCookie = new HttpCookie(cookieName, cookieValue);
			newCookie.Expires = expiretime;

			HttpContext.Current.Response.Cookies.Set(newCookie);
			
		}
		
		#endregion		#region Get Page Name
		public static string GetPageName(string pageNameWithPath)
		{
			string returnValue="";

			if (pageNameWithPath.Trim()!="")
			{	
				Array arrPageName = pageNameWithPath.Split('/');

				if (arrPageName.Length>0)
				{
					returnValue = arrPageName.GetValue(arrPageName.Length-1).ToString();

				}

			}

			return returnValue;
		}		#endregion Get Page Name
		# region Add Item to Listbox,combobox, Dropdown box		public static ListItem AddItemToList(string displayText, string dataValue)
		{
			ListItem itemColl = new ListItem(displayText, dataValue);
			return itemColl;
		}
		#endregion
	}

