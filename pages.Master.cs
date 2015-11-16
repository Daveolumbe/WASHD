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
    public partial class pages : System.Web.UI.MasterPage
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
            }

        }

     

        private void getCarOwnerData()
        {
            string email = Session["Email"].ToString();
            SqlConnection con = new SqlConnection(strconn);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from carOwner where Email = '" + email +"'", con);

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
              

                    string fname = dr["FirstName"].ToString();
                    fnametxt.Text = fname;
                }
                dr.Close();
            }
            catch(Exception ex)
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