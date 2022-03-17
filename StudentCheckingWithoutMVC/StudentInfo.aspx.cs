using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace StudentCheckingWithoutMVC
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                getStudentList();
                if (!IsPostBack)
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        #region "Check ID String"
                        getRecord(Convert.ToInt32(Request.QueryString["Id"]));

                        #endregion "Check Edit Permissions"
                    }

                }
            }
            catch (Exception lo)
            {

            }
           
        }

        public void getRecord(int id)
        {
            SqlConnection con = new SqlConnection(Getconnectionstring("studentconnection"));
            con.Open();
           


            SqlCommand command = new SqlCommand("Select Name,Telephone,Address,Roll_Number,Standard,student_id from student_table where student_id="+id, con);
          
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        txtStandard.Text = reader.GetString(4);
                        txtTelephone.Text = reader.GetString(1);
                        txtName.Text = reader.GetString(0);
                        txtRollNumber.Text = reader.GetString(3);
                        txtAddress.Text = reader.GetString(2);
                        hid_StudentID.Value = reader.GetInt32(5).ToString();
                        //display retrieved record
                       
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }

            }

            con.Close();
        }

        private void getStudentList()
        {

            using (SqlConnection con = new SqlConnection(Getconnectionstring("studentconnection")))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM student_table"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datatable1.DataSource = dt;
                            datatable1.DataBind();
                        }
                    }
                }
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Getconnectionstring("studentconnection"));
                con.Open();
                String insert = "INSERT INTO student_table(Name,Address,Telephone,Roll_Number,Standard) VALUES ('" + txtName.Text + "','" + txtAddress.Text + "','" + txtTelephone.Text + "','" + txtRollNumber.Text + "','" + txtStandard.Text + "')";
                SqlCommand cmd= new SqlCommand(insert,con);
               int m = cmd.ExecuteNonQuery();  
                if(m != 0)  
                {  
                   Response.Write("  <script>alert('Data Inserted !!')</script>  ");  
                }  
                else  
                {  
                   Response.Write("  <script>alert('Data Inserted !!')</script>  ");  
                }
                
                con.Close();
                
       
                    clearAll();
                
            }
            catch (Exception e1)
            {
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
         
            try
            {
                SqlConnection con = new SqlConnection(Getconnectionstring("studentconnection"));
                con.Open();
                String insert = "DELETE from student_table where student_id = "+hid_StudentID.Value;
                SqlCommand cmd= new SqlCommand(insert,con);
               int m = cmd.ExecuteNonQuery();  
                if(m != 0)  
                {  
                   Response.Write("  <script>alert('Data Deleted !!')</script>  ");  
                }  
                else  
                {
                    Response.Write("  <script>alert('Data Deleted!!')</script>  ");  
                }
                
                con.Close();
                
       
                    clearAll();
                
            }
         
            catch (Exception e1)
            {
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Getconnectionstring("studentconnection"));
                con.Open();
                String insert = "UPDATE student_table set Name=" + txtName.Text + ",Address=" + txtAddress.Text + ",Telephone=" + txtTelephone.Text + ",Roll_Number=" + txtRollNumber.Text + ",Standard=" + txtStandard.Text + " where student_id = " + hid_StudentID.Value;
                SqlCommand cmd = new SqlCommand(insert, con);
                int m = cmd.ExecuteNonQuery();
                if (m != 0)
                {
                    Response.Write("  <script>alert('Data Updated !!')</script>  ");
                }
                else
                {
                    Response.Write("  <script>alert('Data Updated !!')</script>  ");
                }

                con.Close();


                clearAll();

            }

            catch (Exception e1)
            {
            }
        }

        public void clearAll()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtStandard.Text = "";
            txtRollNumber.Text = "";
            txtTelephone.Text = "";
            Response.Redirect("StudentInfo.aspx");
        }

        protected void datatable1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "window.location.replace('StudentInfo.aspx?Id=" + e.Row.Cells[0].Text + "');";
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }


        public static string Getconnectionstring(string keyname)
        {
            string connection = string.Empty;
            switch (keyname)
            {
                case "studentconnection":
                    connection = ConfigurationManager.ConnectionStrings["studentconnection"].ConnectionString;
                    break;
              
                default:
                    break;
            }
            return connection;

        } 

    }
}