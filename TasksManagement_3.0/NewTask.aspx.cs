using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace TasksManagement_3._0
{
    public partial class NewTask : System.Web.UI.Page
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
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        private List<string> Separate(string s) // Separate string into list of emails
        {
            List<string> res = new List<string>();

            string cur = "";
            s += ',';
            for (int i=0; i<s.Length; ++i)
            {
                if (s[i] == ' ') continue; // email can't contain spaces
                else if (s[i] == ',')
                {
                    if (cur != "") // email can't be null
                    {
                        res.Add(cur);
                        cur = "";
                    }
                    
                }
                else cur += s[i];
            }

            return res;
        }

        private Boolean Directcheck(string inferior)
        {
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Users WHERE Email='" + inferior + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                if (dt.Rows[0]["Boss"].ToString() == Session["EMAIL"].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        protected void BtSubmit_Click(object sender, EventArgs e)
        {
            List<string> LiToUsers = Separate(TbTo.Text);
            

            string filename = Path.GetFileName(FlAttachment.PostedFile.FileName);
            string contentType = FlAttachment.PostedFile.ContentType;

       

                foreach (string StTo in LiToUsers)
                {
                if (!Directcheck(StTo)) continue;
                    
                    using (Stream fs = FlAttachment.PostedFile.InputStream)
                    {

                        using (BinaryReader br = new BinaryReader(fs))
                        {

                            byte[] bytes = br.ReadBytes((Int32)fs.Length); // Convert file to byte

                            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;

                            // Check from database
                            using (SqlConnection conn = new SqlConnection(ConnectString))
                            {
                                string StCmd = "INSERT INTO Tasks (Name,FromE,ToE,Deadline,Description,AttachmentName,AttachmentType,Attachment) VALUES('" + TbTaskName.Text + "','" + Session["EMAIL"] + "','" + StTo + "','" + TbDeadline.Text + "','" + TbDes.Text + "','" + filename + "',@AttachmentType,@Attachment)";
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
                                conn.Close();
                            }

                        }
                    }

                }
            Response.Write("<script> alert('Submit successfully') </script>");
            Response.Redirect("~/TaskView.aspx");
        }
    }
}