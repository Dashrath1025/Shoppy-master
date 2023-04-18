using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnForgotPassword_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
       
        sb.Append("Hi,<br/> Click on below given link to Reset Your Password<br/>");
        // sb.Append("<a href=http://localhost:54749/User/ResetLink.aspx?usernames=" + GetUserEmail(TxtUsername.Text));
         sb.Append("<a href=http://localhost:54749/User/ResetLink.aspx?usernames=" + GetUserEmail("milanlimbani555@gmail.com"));
        sb.Append("&Username=" + TxtUsername.Text + ">Click here to change your password</a><br/>");
        sb.Append("<b>Thanks</b>,<br> Code Solution <br/>");
        sb.Append("<br/><b> for more post </b> <br/>");
        sb.Append("thanks");
       // Session["Username"] = GetUserEmail(TxtUsername.Text);
       
        MailMessage message = new System.Net.Mail.MailMessage("onlinshopping710@gmail.com", TxtUsername.Text.Trim(), "Reset Your Password", sb.ToString());
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("onlinshopping710@gmail.com", "gekcddcytrlghone");
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
        cmd.CommandText = "select Email from userdetails WHERE Email=@Email";
        cmd.Parameters.AddWithValue("@Email", TxtUsername.Text);
        string username = cmd.ExecuteScalar().ToString();
        return username;
    }
    private void TxtUsernameClear()
    {
        TxtUsername.Text = "";
    }
}