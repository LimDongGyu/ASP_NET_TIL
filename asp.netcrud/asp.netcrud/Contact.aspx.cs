using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.Data;

namespace asp.netcrud
{
    public partial class Contact : System.Web.UI.Page
    {
        //server={0};user id = { 1 }; password={2};persistsecurityinfo=True;port={3};database={4};SslMode=none
        string connectionString = @"Server=localhost;Database=aspcruddb;Uid=root;Pwd=root;SslMode=none";

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
                Clear();
                GridFill();
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

        //CREATE
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("ContactCreateOrUpdate", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_contactid", Convert.ToInt32(hfContactID.Value == "" ? "0" : hfContactID.Value));
                    sqlCmd.Parameters.AddWithValue("_name", txtName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_mobile", txtMobile.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_address", txtAddress.Text.Trim());

                    sqlCmd.ExecuteNonQuery();

                    GridFill();
                    Clear();

                    lblSuccessMessage.Text = "Submitted Successfully";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }



        //SELECT
        void GridFill()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ContactViewAll", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvContact.DataSource = dtbl;
                gvContact.DataBind();
            }
        }

        
        //UPDATE
        protected void lnkSelect_OnClick(object sender, EventArgs e)
        {
            int contactID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ContactViewByID", sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("_contactid", contactID);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                txtName.Text = dtbl.Rows[0][1].ToString();
                txtMobile.Text = dtbl.Rows[0][2].ToString();
                txtAddress.Text = dtbl.Rows[0][3].ToString();

                hfContactID.Value = dtbl.Rows[0][0].ToString();

                btnSave.Text = "Update";
                lblSuccessMessage.Text = "Update Successfully";
                btnDelete.Enabled = true;
            }
        }


        //DELETE
        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand("ContactDeleteByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("_contactid", Convert.ToInt32(hfContactID.Value == "" ? "0" : hfContactID.Value));
                sqlCmd.ExecuteNonQuery();
                GridFill();
                Clear();
                lblSuccessMessage.Text = "Delete Successfully";
            }
        }

    }
}