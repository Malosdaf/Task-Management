using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TasksManagement_3._0
{
    public partial class Employee_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtSubmit_Click(object sender, EventArgs e)
        {
            string StPassword = TbPassword.Text, StPasswordConfirm = TbConfirmPassword.Text;
            string StEmail = TbEmail.Text;
            string StBossEmail = TbBoss.Text;
            string StName = TbUsername.Text;

            bool BoolCheckInput = true;

            if (StPassword.Length < 6)
            {
                PasswordWarning.Visible = true;
                BoolCheckInput = false;
            }
            if (StPassword != StPasswordConfirm)
            {
                ConfirmPasswordWarning.Visible = true;
                BoolCheckInput = false;
            }
            if (!Agree.Checked)
            {
                BoolCheckInput = false;
            }

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;

            // Check from database
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                SqlCommand cmd = conn.CreateCommand();

                cmd.Connection = conn;
                conn.Open();


                // Check if email was used
                string StCmd = "SELECT CompanyId From Users WHERE Email='" + StEmail + "'";
                cmd.CommandText = StCmd;
                int tmp = Convert.ToInt32(cmd.ExecuteScalar());
                if (tmp != 0)
                {
                    EmailWarning.Visible = true;
                    BoolCheckInput = false;
                }

                // Check if boss name exists
                StCmd = "SELECT CompanyId From Users WHERE Email='" + StBossEmail + "'";
                cmd.CommandText = StCmd;
                tmp = Convert.ToInt32(cmd.ExecuteScalar());
                if (tmp == 0)
                {
                    BossWarning.Visible = true;
                    BoolCheckInput = false;
                }
            }

            if (BoolCheckInput)
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    SqlCommand cmd = conn.CreateCommand();

                    cmd.Connection = conn;
                    conn.Open();


                    // Notificate for boss
                    string Message = "A new account of " + StName + " with email " + StEmail + " will become your inferior";
                    string StCmd = "INSERT INTO Notifications (ReceiveEmail,SendEmail,Content,Type) VALUES('" + StBossEmail +"','"+StEmail+ "','" + Message + "','RegisterConfirm')";

                    cmd = new SqlCommand(StCmd, conn);

                 
                    cmd.ExecuteNonQuery();


                    // --------------Add user to Users.dbo-------------------

                    // Get Boss's Company ID
                    StCmd = "SELECT CompanyId FROM Users WHERE Email='" + StBossEmail + "'";
                    cmd.CommandText = StCmd;
                    int CoId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Count number employee in company
                    StCmd = "SELECT COUNT(*) FROM Users WHERE CompanyId=" + CoId.ToString();
                    cmd.CommandText = StCmd;
                    int IdinCo = Convert.ToInt32(cmd.ExecuteScalar()) + 1;


                    //StCmd = "INSERT INTO Users VALUES "
                    StCmd = "INSERT INTO Users VALUES(" + CoId.ToString() + "," + IdinCo.ToString() + ",'" + StEmail + "','" + StPassword + "','" + StName + "','Confirming','"+StBossEmail+"')";
                    cmd = new SqlCommand(StCmd, conn);

                  
                    cmd.ExecuteNonQuery();

                    conn.Close();
                
                }

                Response.Write("<script>alert('Register successfully')</script>");
                Response.Redirect("~/Login.aspx");

            }

        }
    }
}