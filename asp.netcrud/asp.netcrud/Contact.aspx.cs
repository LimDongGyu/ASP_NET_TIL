using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace asp.netcrud
{
    public partial class Contact : System.Web.UI.Page
    {
        /*
         * Page_Load 이벤트 처리기
         * ASP.NET 페이지가 실행되면 위 처리기에 작성된 코드가 실행된다.
         * 그런 후 해당 웹 폼에 있는 버튼을 클릭하면 클릭 이벤트만 발생하는 것이 아니라 Page_Load 이벤트
         * 처리기를 먼저 실행한 후 해당 Button_Click 이벤트 처리기가 실행된다. 
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            /* if(!page.IsPostBack){}
             * 처음 로드할 때만 어떤 처리를 해주기 위함
             */
            if (!IsPostBack)    
            {
                btnDelete.Enabled = false;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfContactID.Value = "";
            txtName.Text = txtMobile.Text = txtAddress.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "save";
            btnDelete.Enabled = false;
        }
    }
}