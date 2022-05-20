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
    public partial class Statistic_Individual : System.Web.UI.Page
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

            // Check authority
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            string email =  Request.QueryString["Email"];
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Users WHERE Email='" + email + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                if (dt.Rows.Count == 0 || dt.Rows[0]["Boss"].ToString() != Session["EMAIL"].ToString())
                {
                    Response.Redirect("~/Home.aspx");
                }
            }

            // Display

            // Display User information
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Users WHERE Email='" + email + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                Calculate_Productivity();

                Display_UserInfo.DataSource = dt;
                Display_UserInfo.DataBind();
            }

            
        }

        public float Turning_Late;
        public float Not_Finished, Pending, Done;

        public void Calculate_Productivity()
        {

            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            string email = Request.QueryString["Email"];

            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Tasks WHERE ToE='" + email + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
                int Total = 0, Done1 = 0, Pending1 = 0;

                foreach (DataRow Task in dt.Rows)
                {
                    string dl = Task["Deadline"].ToString();

                    string yyyy = dl.Substring(15, 4);
                    string mm = dl.Substring(12, 2);
                    string dd = dl.Substring(9, 2);
                    string time = dl.Substring(0, 8);

                    string dlc = yyyy + '/' + mm + '/' + dd + ' ' + time;
                    string curt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

                    if (string.Compare(dlc, curt) == 1)
                    {
                        Total += 1;
                        if (Task["Status"].ToString() == "Finished")
                        {
                            Done1 += 1;
                        }
                        else if (Task["Status"].ToString() == "Pending")
                        {
                            Pending1 += 1;
                        }
                    }
                }

                Done = (float)100 * Done1 / Total;
                Pending = (float)100 * Pending1 / Total;
                Not_Finished = (float)100 - Done - Pending;

            }

        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}