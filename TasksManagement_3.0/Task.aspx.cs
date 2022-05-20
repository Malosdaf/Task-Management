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
    public partial class Task : System.Web.UI.Page
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
            // Load Your tasks from database
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Tasks WHERE Id=" + Id.ToString();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
                Display.DataSource = dt;
                Display.DataBind();


            }
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
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
                contentType= dt.Rows[0]["AttachmentType"].ToString();
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

        protected void BtSubmit_Click(object sender, EventArgs e)
        {
            Int64 Id = Convert.ToInt64(Request.QueryString["ID"]);
            string filename = Path.GetFileName(FlAttachment.PostedFile.FileName);
            string contentType = FlAttachment.PostedFile.ContentType;

            using (Stream fs = FlAttachment.PostedFile.InputStream)
            {

                using (BinaryReader br = new BinaryReader(fs))
                {

                    byte[] bytes = br.ReadBytes((Int32)fs.Length); // Convert file to byte

                    string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;

                    // Check from database
                    using (SqlConnection conn = new SqlConnection(ConnectString))
                    {
                        string StCmd = "INSERT INTO Works (Id,Description,AttachmentName,AttachmentType,Attachment) VALUES("+Id.ToString()+",'"+ TbDes.Text + "','" + filename + "',@AttachmentType,@Attachment)";
                        SqlCommand cmd = new SqlCommand(StCmd);

                        cmd.Connection = conn;

                        //cmd.Parameters.AddWithValue("@Name", TbTaskName.Text);
                        //cmd.Parameters.AddWithValue("@From", Session["EMAIL"]);
                        //cmd.Parameters.AddWithValue("@To", StTo);
                        //cmd.Parameters.AddWithValue("@Deadline",TbDeadline.Text);
                        //cmd.Parameters.AddWithValue("@Description",TbDes.Text);
                        //cmd.Parameters.AddWithValue("@AttachmentName",filename);
                        cmd.Parameters.AddWithValue("@AttachmentType", contentType);
                        cmd.Parameters.AddWithValue("@Attachment", bytes);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        StCmd= "UPDATE Tasks SET Status='Pending' WHERE Id="+Id.ToString();
                        cmd = new SqlCommand(StCmd);
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }

                }
            }
            Response.Redirect("TaskView.aspx");
        }
    }
}