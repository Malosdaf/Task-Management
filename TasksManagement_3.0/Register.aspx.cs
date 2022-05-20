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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["COMPANY"] != null) Response.Redirect("~/CompanyHome.aspx");
        }

        protected void BtSubmit_Click(object sender, EventArgs e)
        {
            string StCompanyName = TbCompanyName.Text;
            string StPasswordInput = TbPassword.Text;
            string StEmail = TbEmail.Text;
            string StPasswordConfirm = TbConfirmPassword.Text;
            string StNumberEmployees = TbNumberOfEmplyees.Text;

            int IntNumberEmployees = 0;

            bool BoolCheckInput = true;
            
            // Check from form

            if (StPasswordInput.Length < 6)
            {
                PasswordWarning.Visible = true;
                BoolCheckInput = false;
            }
            if (StPasswordInput != StPasswordConfirm)
            {
                ConfirmPasswordWarning.Visible = true;
                BoolCheckInput = false;
            }
            if (!int.TryParse(StNumberEmployees, out IntNumberEmployees))
            {
                NumberWarning.Visible = true;
                BoolCheckInput = false;
            }
            if (!Agree.Checked)
            { 
                BoolCheckInput = false;
            }


            // Check from database

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                
                SqlCommand cmd = conn.CreateCommand();
          
                cmd.Connection = conn;
                conn.Open();


                // Check if company name was used
                string StCmd = "SELECT CoId From CompanyAccount WHERE CompanyName='" + StCompanyName + "'";
                cmd.CommandText = StCmd;
                    int tmp = Convert.ToInt32(cmd.ExecuteScalar());
                if (tmp!=0)
                {
                    CompanyNameWarning.Visible = true;
                    BoolCheckInput = false;
                }

                // Check if company email was used

                StCmd = "SELECT CoId From CompanyAccount WHERE Email='" + StEmail + "'";
                cmd.CommandText = StCmd;
                tmp = Convert.ToInt32(cmd.ExecuteScalar());
                if (tmp!=0)
                {
                    EmailWarning.Visible = true;
                    BoolCheckInput = false;
                }

                conn.Close();
            }

            // Add Company to database
            if (BoolCheckInput)
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    string StCmd;
                    SqlCommand cmd;
                   // Insert to companyAccount.dbo
                    StCmd = "INSERT INTO CompanyAccount VALUES('" + StCompanyName + "','" + StPasswordInput + "','" + StEmail + "'," + StNumberEmployees + ")";
                    cmd = new SqlCommand(StCmd, conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Get id
                    string id;
                    StCmd = "SELECT * FROM CompanyAccount WHERE Email='" + StEmail + "'";
                    SqlDataAdapter adpt = new SqlDataAdapter(StCmd, conn);
                    DataTable dt = new DataTable();

                    adpt.Fill(dt);
                    id = dt.Rows[0]["CoId"].ToString();


                    // Insert to User.dbo
                    StCmd = "INSERT INTO Users VALUES(" + id + ",1,'" + StEmail + "','" + StPasswordInput + "','" + StCompanyName + "','Activated','Company')";
                    Response.Write(StCmd);
                    
                    cmd = new SqlCommand(StCmd, conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                Response.Write("<script>alert('Register successfully')</script>");
                Response.Redirect("~/Login.aspx");
            }

        }
    }
}