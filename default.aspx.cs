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
    public partial class _default : System.Web.UI.Page
    {
        string strconn;
        protected void Page_Load(object sender, EventArgs e)
        {
            strconn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand("Registersql", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //INPUT DATA

            cmd.Parameters.AddWithValue("@FirstName", fnametxt.Text);
            cmd.Parameters.AddWithValue("@LastName", lnametxt.Text);
            cmd.Parameters.AddWithValue("@Email", emailtxt.Text);
            cmd.Parameters.AddWithValue("@Passcode", passtxt.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", numbertxt.Text);

            con.Open();

            int res = cmd.ExecuteNonQuery();

            try

            {

                if (res == 1)
                {
                    displayMessage.Visible = true;
                    displayMessage.Text = "Congratulations you have been registered.";
                    displayMessage.ForeColor = Color.Blue;
                }
                else
                {
                    displayMessage.Visible = true;
                    displayMessage.Text = "Unsuccessful registration.";
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

        protected void clear()
        {
            //CLEAR ALL TEXTBOX

            fnametxt.Text = "";
            lnametxt.Text = "";
            emailtxt.Text = "";
            passtxt.Text = "";
            numbertxt.Text = "";
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strconn);

            SqlCommand com = new SqlCommand("UserLogin", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@email", txtemail.Text);
            SqlParameter p2 = new SqlParameter("@passcode", txtpass.Text);

            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            con.Open();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                Session["Email"] = txtemail.Text;
                Response.Redirect("booking.aspx");
            }
            else
            {
                displaymsg.Visible = true;
                displaymsg.Text = "Invalid username or password.";
                displaymsg.ForeColor = Color.Red;
                displaymsg.BackColor = Color.Wheat;
            }

        }
    }

}