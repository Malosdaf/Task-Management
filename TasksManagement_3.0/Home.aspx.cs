using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TasksManagement_3._0
{
    public partial class CompanyHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["NAME"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Dashboard_LinkBtn_User_Name.Text = Session["NAME"].ToString();
                Dashboard_LinkBtn_User_Name.Visible = true;

            }

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Notifications WHERE ReceiveEmail='" + Session["EMAIL"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
                RepNotification.DataSource = dt;
                RepNotification.DataBind();


            }
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void RepNotification_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        protected void AcceptBt_Click(object sender, EventArgs e)
        {

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            string NotiId = (sender as LinkButton).CommandArgument;

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                conn.Open();
                string cmd = "SELECT * FROM Notifications WHERE NotiId=" + NotiId;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                if (dt.Rows[0]["Type"].ToString() == "RegisterConfirm")
                {

                    // Update status
                    string StSender = dt.Rows[0]["SendEmail"].ToString();
                    string StCmd = "UPDATE Users SET Status='Activated' WHERE Email='" + StSender + "'";


                    SqlCommand cmd1 = conn.CreateCommand();

                    cmd1.Connection = conn;
                    cmd1.CommandText = StCmd;
                    cmd1.ExecuteNonQuery();

                    // Delete Row

                    StCmd = "DELETE FROM Notifications WHERE NotiID=" + NotiId;
                    cmd1.CommandText = StCmd;
                    cmd1.ExecuteNonQuery();

                    // Refresh
                    Response.Redirect(Request.RawUrl);
                }
            }

        }

        protected void DenyBt_Click(object sender, EventArgs e)
        {

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            string NotiId = (sender as LinkButton).CommandArgument;

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                conn.Open();
                string cmd = "SELECT * FROM Notifications WHERE NotiId=" + NotiId;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                if (dt.Rows[0]["Type"].ToString() == "RegisterConfirm")
                {

                    // Update status
                    string StSender = dt.Rows[0]["SendEmail"].ToString();
                    string StCmd = "DELETE FROM Users WHERE Email='" + StSender + "'";


                    SqlCommand cmd1 = conn.CreateCommand();

                    cmd1.Connection = conn;
                    cmd1.CommandText = StCmd;
                    cmd1.ExecuteNonQuery();

                    // Delete Row

                    StCmd = "DELETE FROM Notifications WHERE NotiID=" + NotiId;
                    cmd1.CommandText = StCmd;
                    cmd1.ExecuteNonQuery();

                    // Refresh
                    Response.Redirect(Request.RawUrl);
                }
            }

        }
    }
}