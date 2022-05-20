using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TasksManagement_3._0
{
    public partial class Company_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //do something 
                if (Session["NAME"] != null) Response.Redirect("~/Home.aspx");
            }
                
        }

        
        protected void BttonSubmit_Click(object sender, EventArgs e)
        {
            string StEmail = TbEmail.Text;
            string StPassword = TbPassword.Text;

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Users WHERE Email='" + StEmail +"'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
           

                if (dt.Rows.Count == 0)
                {
                    LoginWarning.Visible = true;
                }
                else if (dt.Rows[0]["Password"].ToString() != StPassword )
                {
                    LoginWarning.Visible = true;
                }
                else
                {
                    Session["NAME"] = dt.Rows[0]["Username"];
                    Session["EMAIL"] = StEmail;
                    Response.Redirect("~/Home.aspx");
                }
            }
        }

       
    }
}