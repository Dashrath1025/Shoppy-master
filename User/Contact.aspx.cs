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

public partial class User_Contact : System.Web.UI.Page
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
          //  Response.Redirect("UserMainPage.aspx");
            // Response.Redirect("UserLogin.aspx");
        }
    }

    protected void SendMessage_Click(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "insert into contactus(Name,Email,Title,Description,DateTime)values(@Name,@Email,@Title,@Description,@DateTime)";
        cmd.Parameters.AddWithValue("@Name", exampleInputName.Text);
        cmd.Parameters.AddWithValue("@Email", exampleInputEmail1.Text);
        cmd.Parameters.AddWithValue("@Title", exampleInputTitle.Text);
        cmd.Parameters.AddWithValue("@Description", exampleInputComments.Value);
        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
        if (cmd.ExecuteNonQuery() > 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Problem Solve Out Very Quickely', 'success');", true);
            resetdata();
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
        }
        con.Close();
        cmd.Dispose();

    }
    public void resetdata()
    {
        exampleInputName.Text = "";
        exampleInputEmail1.Text = "";
        exampleInputTitle.Text = "";
        exampleInputComments.Value = "";
    }
}