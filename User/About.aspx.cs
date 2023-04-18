using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbluser = (Label)Master.FindControl("lbluser");
        if (Session["Emails"] != null)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from userlogin where Email='" + Session["Emails"] + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MailAddress addr = new MailAddress(ds.Tables[0].Rows[0]["Email"].ToString());
            lbluser.Text = "Hello : " + addr.User;
        }
        else
        {
            lbluser.Text = "Hello : Guest";
           // Response.Redirect("UserMainPage.aspx");
        }
    }
}