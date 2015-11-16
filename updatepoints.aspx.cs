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
using System.Web.Configuration;
using System.Text;
using System.Net;
using System.IO;

namespace WebProject
{
    public partial class updatepoints : System.Web.UI.Page
    {
        string strconn;
        SqlDataAdapter sqlda;
        SqlDataReader dr;
        string authToken;
        string txToken;
        string query;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            strconn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
            if (!Page.IsPostBack)
            {
                // CUSTOMIZE THIS: This is the seller's Payment Data Transfer authorization token.
                // Replace this with the PDT token in "Website Payment Preferences" under your account.

                 authToken = "FYsKugBr4oQZTANPc3KuyLqCwtlMht_6-7DAv708kvXNdpxQaAZ77W8V5Ri";
                 txToken = Request.QueryString["tx"];
                 query = "cmd=_notify-synch&tx=" + txToken + "&at=" + authToken;

                //Post back to either sandbox or live
               // string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                string strLive = "https://www.paypal.com/cgi-bin/webscr";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);

                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = query.Length;


                //Send the request to PayPal and get the response
                StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                streamOut.Write(query);
                streamOut.Close();
                StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                string strResponse = streamIn.ReadToEnd();
                streamIn.Close();

                Dictionary<string, string> results = new Dictionary<string, string>();
                if (strResponse != "")
                {
                    StringReader reader = new StringReader(strResponse);
                    string line = reader.ReadLine();

                    if (line == "SUCCESS")
                    {

                        while ((line = reader.ReadLine()) != null)
                        {
                            results.Add(line.Split('=')[0], line.Split('=')[1]);

                        }
                        Response.Write("<p><h3>Your order has been received.</h3></p>");
                        Response.Write("<b>Details</b><br>");
                        Response.Write("<li>Name: " + results["first_name"] + " " + results["last_name"] + "</li>");
                        Response.Write("<li>Item: " + results["item_name"] + "</li>");
                        Response.Write("<li>Amount: " + results["payment_gross"] + "</li>");
                        Response.Write("<hr>");
                    }
                    else if (line == "FAIL")
                    {
                        // Log for manual investigation
                        Response.Write("Unable to retrive transaction detail");
                    }
                }
                else
                {
                    //unknown error
                    Response.Write("ERROR");
                }
            }

            if (!IsPostBack)
            {
                getCarOwnerData();
            }
            Response.Redirect("booking.aspx");
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


                    int currentpoint = Convert.ToInt16(dr["MyPoints"].ToString());
                    //put this on Text then use to update from paypal variable
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
    }
}