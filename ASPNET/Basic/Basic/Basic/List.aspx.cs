using BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Basic.Basic
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //처음 로드할 때만
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            var repository = new BasicRepository();

            ctlBasicList.DataSource = repository.GetAll();
            ctlBasicList.DataBind();
        }
    }
}