using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharePoint.CSOM.Pages
{
    public partial class LookupField : System.Web.UI.Page
    {
        string siteUrl = "http://tomato/sites/store";
        string listTitle = "Products";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ClientContext context = new ClientContext(siteUrl))
            {
                List productsList = context.Web.Lists.GetByTitle(listTitle);
                Microsoft.SharePoint.Client.ListItemCollection productItems = productsList.GetItems(CamlQuery.CreateAllItemsQuery());
                context.Load(productItems);
                context.ExecuteQuery();

                StringBuilder tableDataMarkup = new StringBuilder();
                foreach (var item in productItems)
                {
                    try
                    {
                        StringBuilder rowMarkup = new StringBuilder();
                        rowMarkup.AppendFormat("<tr><td>{0}</td><td>{1}</td>", Convert.ToString(item["ID"]), Convert.ToString(item["Title"]));

                        FieldLookupValue categoryLookup = item["Category"] as FieldLookupValue;
                        rowMarkup.AppendFormat("<td>{0}</td><td>{1}</td>", categoryLookup == null ? String.Empty : Convert.ToString(categoryLookup.LookupId), categoryLookup == null ? String.Empty : Convert.ToString(categoryLookup.LookupValue));

                        FieldLookupValue priceRangeLookup = item["Price_x0020_Range"] as FieldLookupValue;
                        rowMarkup.AppendFormat("<td>{0}</td><td>{1}</td></tr>", priceRangeLookup == null ? String.Empty : Convert.ToString(priceRangeLookup.LookupId), priceRangeLookup == null ? String.Empty : Convert.ToString(priceRangeLookup.LookupValue));

                        tableDataMarkup.Append(rowMarkup);
                    }
                    catch { }
                }

                string tableMarkup = "<table class='result-grid'>" + 
                                        "<tr><th>ID</th><th>Title</th><th>Category Lookup ID</th><th>Category Lookup Value</th><th>Price Range Lookup ID</th><th>Price Range Lookup Value</th></tr>" + 
                                        tableDataMarkup.ToString() + 
                                     "</table>";

                contentPanel.Controls.Add(new LiteralControl(tableMarkup));

            }
        }        
    }
}