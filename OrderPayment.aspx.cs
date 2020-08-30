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
    public partial class OrderPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Credit(object sender, EventArgs e)
        {


            try { 

            string connStr = ConfigurationManager.ConnectionStrings["GUI"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/


            SqlCommand cmd = new SqlCommand("CHECKIFPAYED", conn);
            int orderID = (int)(Session["id"]);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@order_id", orderID));
            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteNonQuery();
                conn.Close();





                if (success.Value.ToString().Equals("1"))
                {

                    Label lbl_CompanyField = new Label();
                    lbl_CompanyField.Text = "You already Paid stop wasting your money" + "  <br /> <br />";
                    form1.Controls.Add(lbl_CompanyField);

                }
                else
                {

                    connStr = ConfigurationManager.ConnectionStrings["GUI"].ToString();

                    //create a new connection
                    conn = new SqlConnection(connStr);

                    /*create a new SQL command which takes as parameters the name of the stored procedure and
                     the SQLconnection name*/


                    cmd = new SqlCommand("ChooseCreditCard", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    String cvv = CVV.Text;

                    cmd.Parameters.Add(new SqlParameter("@creditcard", cvv));
                    cmd.Parameters.Add(new SqlParameter("@orderID", orderID));
                    SqlParameter success1 = cmd.Parameters.Add("@success", SqlDbType.Int);
                    success1.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write(success1.Value.ToString());

                    if (success1.Value.ToString().Equals("0"))
                    {
                        

                        Label lbl_CompanyField = new Label();
                        lbl_CompanyField.Text = "CreditCardExpired" + "  <br /> <br />";
                        form1.Controls.Add(lbl_CompanyField);

                    }


                    else
                    {
                        connStr = ConfigurationManager.ConnectionStrings["GUI"].ToString();

                        //create a new connection
                        conn = new SqlConnection(connStr);


                        /*create a new SQL command which takes as parameters the name of the stored procedure and
                         the SQLconnection name*/


                        cmd = new SqlCommand("SpecifyAmount", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        string username = (string)(Session["currUser"]);
                        orderID = (int)(Session["id"]);

                        int credit = int.Parse(txt_credit.Text);

                        //To read the input from the user
                        //pass parameters to the stored procedure
                        cmd.Parameters.Add(new SqlParameter("@customername", username));
                        cmd.Parameters.Add(new SqlParameter("@orderID", orderID));
                        cmd.Parameters.Add(new SqlParameter("@cash", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@credit", credit));
                        success = cmd.Parameters.Add("@success", SqlDbType.Int);
                        success.Direction = ParameterDirection.Output;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();




                        //Executing the SQLCommand

                        //Executing the SQLCommand
                        if (success.Value.ToString().Equals("1"))
                        {

                            Label lbl_CompanyField = new Label();
                            lbl_CompanyField.Text = "Payment successfull" + "  <br /> <br />";
                            form1.Controls.Add(lbl_CompanyField);

                        }
                        else
                        {

                            Label lbl_CompanyField = new Label();
                            lbl_CompanyField.Text = "Payment FAILED" + "  <br /> <br />";
                            form1.Controls.Add(lbl_CompanyField);

                        }
                    }
                }
            }
            catch (Exception)
            {
                Label lbl_CompanyField = new Label();
                lbl_CompanyField.Text = "Invalid input try again" + "  <br /> <br />";
                form1.Controls.Add(lbl_CompanyField);

            }
        }
        protected void Cash(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUI"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/


            SqlCommand cmd = new SqlCommand("CHECKIFPAYED", conn);
            int orderID = (int)(Session["id"]);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@order_id", orderID));
            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString().Equals("1"))
            {

                Label lbl_CompanyField = new Label();
                lbl_CompanyField.Text = "You already Paid stop wasting your money" + "  <br /> <br />";
                form1.Controls.Add(lbl_CompanyField);

            }
            else
            {


                /*create a new SQL command which takes as parameters the name of the stored procedure and
                 the SQLconnection name*/
                //Get the information of the connection to the database
                connStr = ConfigurationManager.ConnectionStrings["GUI"].ToString();

                //create a new connection

                conn = new SqlConnection(connStr);

                cmd = new SqlCommand("SpecifyAmount", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string username = (string)(Session["currUser"]);
                orderID = (int)(Session["id"]);

                int cash2 = int.Parse(txt_cash.Text);
                int r = 0;
                //To read the input from the user
                //pass parameters to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@customername", username));
                cmd.Parameters.Add(new SqlParameter("@orderID", orderID));
                cmd.Parameters.Add(new SqlParameter("@cash", cash2));
                cmd.Parameters.Add(new SqlParameter("@credit", DBNull.Value));
                success = cmd.Parameters.Add("@success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();


                //Executing the SQLCommand
                if (success.Value.ToString().Equals("1"))
                {

                    Label lbl_CompanyField = new Label();
                    lbl_CompanyField.Text = "Payment successfull" + "  <br /> <br />";
                    form1.Controls.Add(lbl_CompanyField);

                }
                else
                {

                    Label lbl_CompanyField = new Label();
                    lbl_CompanyField.Text = "Payment FAILED" + "  <br /> <br />";
                    form1.Controls.Add(lbl_CompanyField);


                }




            }
        }
    }
}