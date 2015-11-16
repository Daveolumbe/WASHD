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

namespace WebProject
{
    public partial class booking : System.Web.UI.Page
    {
        string strconn;
        SqlDataAdapter sqlda;
        SqlDataReader dr;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            strconn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
            if (!IsPostBack)
            {
                getCarOwnerData();
                countBooking();
            }

        }

        private void countBooking()
        {
            string email = Session["Email"].ToString();
            SqlConnection con = new SqlConnection(strconn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(*) from schedule where schedule.ownerID = (select ownerID from carOwner where Email = '" + email + "')", con);

            
            SqlDataAdapter sqlda = new SqlDataAdapter();

            DataSet ds = new DataSet();
            cmd.Connection = con;

            int count = (int)cmd.ExecuteScalar();

            try
            {
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {

                    Label1.Text = count.ToString();
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error Accessing Database", ex);
            }


            finally
            {
                con.Close();
            }
        }

        private void getCarOwnerData()
        {
            string email = Session["Email"].ToString();
            SqlConnection con = new SqlConnection(strconn);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from carOwner where Email = '" + email + "'", con);

            sqlda = new SqlDataAdapter();

            DataSet ds = new DataSet();
            cmd.Connection = con;
            sqlda.SelectCommand = cmd;
            sqlda.Fill(ds);


            try
            {
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (dr.Read())
                {
                    int yourPoints = Convert.ToInt16(dr["MyPoints"].ToString());
                    string points = Convert.ToString(yourPoints);
                    pointstxt.Text = points;

                    int id = Convert.ToInt16(dr["ownerID"].ToString());

                    string ownerid = Convert.ToString(id);
                    owneridtxt.Text = ownerid;

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ", ex);
            }
            finally
            {
                con.Close();

            }
        }

        protected void bookBtn_Click(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            int getmycurrentpoints = Convert.ToInt16(pointstxt.Text);
            int bookingpoint = Convert.ToInt16(servicetxt.Text);

            if (bookingpoint < getmycurrentpoints)
            {
                //INSERT AND UPDATE PROCEDURE
                SqlConnection con = new SqlConnection(strconn);
                SqlCommand cmd = new SqlCommand("Booking", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //INPUT DATA CALCULATING THE POINTS
                int updatemypoint = getmycurrentpoints - bookingpoint;

                cmd.Parameters.AddWithValue("@ownerID", Convert.ToInt16(owneridtxt.Text));
                cmd.Parameters.AddWithValue("@carModel", modeltxt.Text);
                cmd.Parameters.AddWithValue("@regNumber", carregtxt.Text);
                cmd.Parameters.AddWithValue("@servicePoints", servicetxt.Text);
                cmd.Parameters.AddWithValue("@dateandTime", datatimetxt.Text);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MyPoints", updatemypoint);
                string location = Request.Form["locationtxt"];
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@washStatus", "IN PROGRESS");


                con.Open();

                int res = cmd.ExecuteNonQuery();

                try

                {

                    if (res > 0)
                    {
                        displayMessage.Visible = true;
                        displayMessage.Text = "Your booking has been registered.";
                        displayMessage.BackColor = Color.Lavender;
                        displayMessage.ForeColor = Color.Blue;
                    }
                    else
                    {
                        displayMessage.Visible = true;
                        displayMessage.Text = "Unsuccessful booking.";
                        displayMessage.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Accessing Database", ex);
                }
                finally
                {
                    con.Close();
                }

                clear();
            }
            else
            {
                displayMessage.Visible = true;
                displayMessage.Text = "Insufficient Points, Please buy more points.";
                displayMessage.ForeColor = Color.Red;
            }
        }

        protected void clear()
        {
            //CLEAR ALL TEXTBOX
            modeltxt.Text = "";
            carregtxt.Text = "";
            servicetxt.Text = "";
            getCarOwnerData();
        }

    }
}
