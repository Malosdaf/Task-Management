using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TasksManagement_3._0
{
    public partial class Chat : System.Web.UI.Page
    {
        protected string receiver;
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

            receiver = Request.QueryString["ToE"];


            // Load Boss
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Users WHERE Email='" + Session["EMAIL"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
                BossMes.DataSource = dt;
                BossMes.DataBind();
            }

            // Load inferior
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Users WHERE Boss='" + Session["EMAIL"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
                InfMes.DataSource = dt;
                InfMes.DataBind();
            }

            // Load message's history
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Messages WHERE (FromE='" + Session["EMAIL"] + "' AND ToE='"+receiver+"') OR (FromE='"+receiver+"' AND ToE='"+Session["EMAIL"]+"')";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
                ChatHistory.DataSource = dt;
                ChatHistory.DataBind();
            }

        }
        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void SendBtn_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('"+receiver+"')</script>");
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string StCmd = "INSERT INTO Messages (FromE,ToE,Message) VALUES('" + Session["EMAIL"] + "','" + receiver + "','" +MesTxBox.Text+"')";
                //Response.Write(StCmd);
                SqlCommand cmd = new SqlCommand(StCmd);

                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}