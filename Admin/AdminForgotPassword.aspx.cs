using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;
using System.IO;


public partial class Admin_AdminForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
            Response.Redirect("/Admin/AdminLogin.aspx");
        }
        else
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from adminlogin where Username = '" + Session["uname"] + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            AdminName.Text = "Hello : " + ds.Tables[0].Rows[0]["Username"].ToString();
        }
    }
    protected void BtnForgotPassword_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Hi,<br/> Click on below given link to Reset Your Password<br/>");
        sb.Append("<a href=http://localhost:54749/Admin/ResetLink.aspx?username=" + GetUserEmail(TxtUsername.Text));
        sb.Append("&Username=" + TxtUsername.Text + ">Click here to change your password</a><br/>");
        sb.Append("<b>Thanks</b>,<br> Code Solution <br/>");
        sb.Append("<br/><b> for more post </b> <br/>");
        sb.Append("thanks");
        Session["Username"] = GetUserEmail(TxtUsername.Text);
        MailMessage message = new System.Net.Mail.MailMessage("onlinshopping710@gmail.com", TxtUsername.Text.Trim(), "Reset Your Password", sb.ToString());
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("onlinshopping710@gmail.com", "wvicrpxlfwwcuwgm");
        smtp.EnableSsl = true;
        message.IsBodyHtml = true;
        smtp.Send(message);
        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !!!', 'Reset Password Link Sent Your EmailAddress !', 'success');", true);
        TxtUsernameClear();
    }
    private string GetUserEmail(string Email)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select Username from adminlogin WHERE Username=@Username";
        cmd.Parameters.AddWithValue("@Username", TxtUsername.Text);
        string username = cmd.ExecuteScalar().ToString();
        return username;
    }
    private void TxtUsernameClear()
    {
        TxtUsername.Text = "";
    }

    protected void ResetData_Click(object sender, EventArgs e)
    {
        TxtUsernameClear();
    }
}