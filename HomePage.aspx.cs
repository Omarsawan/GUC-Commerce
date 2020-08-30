using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GUC_Commerce_GUI
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLoggedIn = HttpContext.Current.Session["LoggedIn"] == null ? false : (bool)HttpContext.Current.Session["LoggedIn"];

            if (!isLoggedIn)
            {
                Response.Redirect("HomeLogin.aspx");
            }
        }
        protected void makeOrder(object sender, EventArgs e)
        {
            //configuration
            //connection
            //the purpose of the method

            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUI"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/


            SqlCommand cmd = new SqlCommand("makeorder", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string username = (string)(Session["currUser"]);
            
            //To read the input from the user
            //pass parameters to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@customername", username));


            //Executing the SQLCommand
            conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
           
             conn = new SqlConnection(connStr);

             cmd = new SqlCommand("reviewOrders", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                int order_no = rdr.GetInt32(rdr.GetOrdinal("order_no"));
                //Get the value of the attribute field in the Company table
                String custname = rdr.GetString(rdr.GetOrdinal("customer_name"));
                int orderamount = 0;
                
                if (custname == username)
                {
                    //Create a new label and add it to the HTML form
                    Label lbl_CompanyName = new Label();
                    lbl_CompanyName.Text = "Order_id  "+order_no  ;
                    form1.Controls.Add(lbl_CompanyName);

                    Label lbl_CompanyField = new Label();
                    lbl_CompanyField.Text = "Orderamount "+orderamount + "  <br /> <br />";
                    form1.Controls.Add(lbl_CompanyField);

                }

            }

        }
        protected void logOut(object sender, EventArgs e)
        {
            Session["currUser"] = null;
            Session["LoggedIn"] = false;
            Response.Redirect("HomeLogin.aspx");
        }
            
    }
}