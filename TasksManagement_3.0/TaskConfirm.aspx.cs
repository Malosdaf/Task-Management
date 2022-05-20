using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TasksManagement_3._0
{
    public partial class TaskConfirm : System.Web.UI.Page
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

            Int64 Id = Convert.ToInt64(Request.QueryString["ID"]);
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Works WHERE Id=" + Id.ToString();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                if (dt.Rows.Count==0)
                {
                    Response.Write("<script> alert('Task has not been done') </script>");
                    Response.Redirect("TaskView.aspx");
                }

                Display.DataSource = dt;
                Display.DataBind();


            }
        }

        protected void BttonCompanyName_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }


        protected void Download_Click(object sender, EventArgs e)
        {
            Int64 Id = Convert.ToInt64(Request.QueryString["ID"]);
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;

            byte[] bytes;
            string fileName, contentType;

            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Tasks WHERE Id=" + Id.ToString();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                // 

                bytes = (byte[])dt.Rows[0]["Attachment"];
                contentType = dt.Rows[0]["AttachmentType"].ToString();
                fileName = dt.Rows[0]["AttachmentName"].ToString();
            }
            //Response.Write("<script>alert('"+fileName+' '+contentType+"')</script>");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void Accept_Click()
        {
            Int64 Id = Convert.ToInt64(Request.QueryString["ID"]);
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;

            // Check from database
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string StCmd = "UPDATE Tasks SET Status='Finished' WHERE Id=" + Id.ToString();
                SqlCommand cmd = new SqlCommand(StCmd);

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                StCmd = "DELETE FROM Works WHERE Id=" + Id.ToString();
                cmd.CommandText = StCmd;
                cmd.ExecuteNonQuery();


                conn.Close();
            }

            Response.Redirect("TaskView.aspx");
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void Deny_Click()
        {
            Int64 Id = Convert.ToInt64(Request.QueryString["ID"]);
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;

            // Check from database
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string StCmd = "UPDATE Tasks SET Status='Not finished' WHERE Id=" + Id.ToString();
                SqlCommand cmd = new SqlCommand(StCmd);

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                StCmd = "DELETE FROM Works WHERE Id=" + Id.ToString();
                cmd.CommandText = StCmd;
                cmd.ExecuteNonQuery();


                conn.Close();
            }

            Response.Redirect("TaskView.aspx");
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            int per = int.Parse(TxtBox_Percentage.Text);

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            Int64 Id = Convert.ToInt64(Request.QueryString["ID"]);

            // Check from database
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string StCmd = "UPDATE Tasks SET Percentage=" + per.ToString() + " WHERE Id=" + Id.ToString();
                SqlCommand cmd = new SqlCommand(StCmd);

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }

            if (per < 100)
            {
                Deny_Click();
            }
            else
            {
                Accept_Click();
            }
           
        }
    }
}