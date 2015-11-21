using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TWART.DataObjects;

namespace TWART.Views.Bank
{
    public partial class ListBanks : System.Web.Mvc.ViewPage<IEnumerable<DataObjects.Bank>>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}