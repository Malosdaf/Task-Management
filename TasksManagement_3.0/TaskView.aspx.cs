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
    public partial class TaskView : System.Web.UI.Page
    {
        
        public Dictionary<string, Color> dicStatusColor = new Dictionary<string, Color>();
        public Dictionary<string, string> dicStatusTxt = new Dictionary<string, string>();

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

            // Load Your tasks from database
            string ConnectString = ConfigurationManager.ConnectionStrings["TM30_DatabaseConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Tasks WHERE Status<>'Finished' AND FromE='" + Session["EMAIL"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                foreach (DataRow Task in dt.Rows)
                {
                    string id = Task["Id"].ToString();

                    string dl = Task["Deadline"].ToString();

                    string yyyy = dl.Substring(15, 4);
                    string mm = dl.Substring(12, 2);
                    string dd = dl.Substring(9, 2);
                    string time = dl.Substring(0, 8);

                    string dlc = yyyy + '/' + mm + '/' + dd + ' ' + time;
                    string curt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");


                    if (Task["Status"].ToString() == "Pending")
                    {
                        dicStatusColor[id] = Color.Green;
                        dicStatusTxt[id] = "Submitted";
                    }
                    else if (string.Compare(dlc, curt) == 1)
                    {
                        //Response.Write("<script>alert('" + id + "')</script>");
                        dicStatusColor[id] = Color.Green;
                        dicStatusTxt[id] = "Due to " + dl;
                        // Response.Write("<script>alert('" + dicStatusTxt[id] + "')</script>");
                    }
                    else
                    {
                        //Response.Write("<scrip>alert('" + id + "')</script>");
                        dicStatusColor[id] = Color.Red;
                        dicStatusTxt[id] = "Missing";
                    }


                }

                YourTasksNoti.DataSource = dt;
                YourTasksNoti.DataBind();

            }

            // Load To Do from database
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                string cmd = "SELECT * FROM Tasks WHERE Status<>'Finished' AND ToE='" + Session["EMAIL"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd, conn);
                DataTable dt = new DataTable();

                adpt.Fill(dt);

                foreach (DataRow Task in dt.Rows)
                {
                    string id = Task["Id"].ToString();
                    
                    string dl = Task["Deadline"].ToString();

                    string yyyy = dl.Substring(15, 4);
                    string mm = dl.Substring(12,2);
                    string dd = dl.Substring(9,2);
                    string time = dl.Substring(0,8);

                    string dlc = yyyy + '/' + mm + '/' + dd + ' ' + time;
                    string curt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");


                    if (Task["Status"].ToString() == "Pending")
                    {
                        dicStatusColor[id] = Color.SandyBrown;
                        dicStatusTxt[id] = "Pending";
                    }
                    else if (string.Compare(dlc, curt) == 1)
                    {
                        //Response.Write("<script>alert('" + id + "')</script>");
                        dicStatusColor[id] = Color.Green;
                        dicStatusTxt[id] = "Due to " + dl;
                       // Response.Write("<script>alert('" + dicStatusTxt[id] + "')</script>");
                    }
                    else
                    {
                        //Response.Write("<scrip>alert('" + id + "')</script>");
                        dicStatusColor[id] = Color.Red;
                        dicStatusTxt[id] = "Missing";
                    }

                    
                }
                
                ToDoNoti.DataSource = dt;
                ToDoNoti.DataBind();
            }
        }

        

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }


    }
}