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
    public partial class Statisic : System.Web.UI.Page
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
                string cmd = "SELECT * FROM Users WHERE Boss='" + Session["EMAIL"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                foreach (DataRow User in dt.Rows)
                {
                    Statistic(User["Email"].ToString());
                }

                Users_Statistic.DataSource = dt;
                Users_Statistic.DataBind();
            }
        }

        public class statis
        {
            public int Turn_in_late; // All time
            public int Total, Not_finished, Pending, Done; // Current
            public float Percentage; // Display
        }

        public Dictionary<string, statis> dicStat = new Dictionary<string, statis>();

        private void Statistic(string email)
        {
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Tasks WHERE ToE='" +email + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);
                int Total = 0, Done = 0;

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
                            Done += 1;
                        }
                    }
                }

                statis P = new statis();

                P.Total = Total;
                P.Done = Done;
                if (Total != 0) {
                    P.Percentage = (float)Done / Total * 80;
                }
                else
                {
                    P.Percentage = 80;
                }

                dicStat[email] = P;

            }
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}