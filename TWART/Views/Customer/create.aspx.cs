using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TWART.DataObjects;

namespace TWART.Views.Customer
{
    public partial class newCustomerView : System.Web.Mvc.ViewPage<IEnumerable<DataObjects.Account_Type>>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var atype in Model)
            {
                ListItem item = new ListItem(atype.Name.ToString());
                item.Value = atype.ID.ToString();
                accountTypes.Items.Add(item);
            }

        }
    }
}