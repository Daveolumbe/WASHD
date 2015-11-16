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
    public partial class cancel : System.Web.UI.Page
    {
        string strconn;
        protected void Page_Load(object sender, EventArgs e)
        {
            strconn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
            displayBooking();
        }

        protected void displayBooking()
        {
            string email = Session["Email"].ToString();
            SqlConnection con = new SqlConnection(strconn);
            string newbook = "N";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from schedule where ownerID = (select ownerID from carOwner where Email = '" + email + "')", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Booking.DataSource = ds.Tables[0];
                Booking.DataBind();

            }
            finally
            {
                con.Close();
            }

        }

        protected void Booking_DeleteCommand(object source, DataListCommandEventArgs e)
        {

            int bookingid;
            bookingid = Convert.ToInt32(e.CommandArgument);

            SqlConnection con = new SqlConnection(strconn);
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from schedule where id = '" + bookingid + "'", con);
            SqlCommand cmd2 = new SqlCommand("UPDATE  carOwner  SET   MyPoints =  MyPoints+200   where carOwner.ownerID = (Select schedule.OwnerID from schedule where id = '" + bookingid + "')", con);

            int res2 = cmd2.ExecuteNonQuery();
            int res = cmd.ExecuteNonQuery();
            if (res > 0 && res2 > 0)
            {
                Label5.Visible = true;
                Label5.Text = "Your booking has been cancelled and you have been refunded back with 200 points";
                con.Close();
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "Error in booking cancelling try again later";
                con.Close();
            }

            displayBooking();

        }
    }

}