using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Text;

public partial class User_UserLogin : System.Web.UI.Page
{
    static string ActivationCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //CountryDropdownlist();
            first.Enabled = false;
            second.Enabled = false;
            third.Enabled = false;
            fourth.Enabled = false;
            Email.Enabled = true;
        }
    }
    public void sendotp()
    {

        string to = Email.Text.Trim(); //To address    
                                       //  Response.Write(to);
        string from = "onlinshopping710@gmail.com"; //From address    
        MailMessage message = new MailMessage(from, to);

        string mailbody = "Dear " + Email.Text.Trim() + ", Your Activation  Code is " + ActivationCode + "\n\n Thanks & Regarding Onshopping and Team";
        message.Subject = "Sending Email Using Verification of OTP";
        message.Body = mailbody;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
        System.Net.NetworkCredential basicCredential1 = new
        System.Net.NetworkCredential("onlinshopping710@gmail.com", "wvicrpxlfwwcuwgm");
        client.EnableSsl = true;
        client.UseDefaultCredentials = true;
        client.Credentials = basicCredential1;
        try
        {
            client.Send(message);
        }

        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void Verifyotp_Click(object sender, EventArgs e)
    {
        try
        {
            string txtotp = first.Text + second.Text + third.Text + fourth.Text;
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select Email,UserOtp from userlogin where Email=@Email and UserOtp=@UserOtp";
            cmd.Parameters.AddWithValue("@Email", Email.Text.Trim());
            cmd.Parameters.AddWithValue("@UserOtp", txtotp);
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !!!', 'Login Successfully !', 'success');", true);
                Session["Emails"] = Email.Text.Trim();
                Email.Text = string.Empty;
                first.Text = string.Empty;
                second.Text = string.Empty;
                third.Text = string.Empty;
                fourth.Text = string.Empty;
                Response.Redirect("UserMainPage.aspx");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            con.Close();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }


    }

    protected void BtnUserLogin_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmdd = new MySqlCommand();
        conn.Open();
        cmdd.Connection = conn;
        cmdd.CommandText = "select Email from userlogin where Email=@Email";
        cmdd.Parameters.AddWithValue("@Email", Email.Text.Trim());
        MySqlDataReader rd = cmdd.ExecuteReader();
        if (rd.HasRows)
        {

            Random random = new Random();
            ActivationCode = random.Next(2001, 9999).ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update userlogin set UserOtp=@UserOtp,Datetime=@Datetime where Email=@Email";
            cmd.Parameters.AddWithValue("@Email", Email.Text);
            cmd.Parameters.AddWithValue("@UserOtp", ActivationCode);
            cmd.Parameters.AddWithValue("@Datetime", DateTime.Now);

            if (cmd.ExecuteNonQuery() > 0)
            {

                sendotp();

                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !!!', 'OTP Has Been Sent Successfully !', 'success');", true);
                first.Enabled = true;
                second.Enabled = true;
                third.Enabled = true;
                fourth.Enabled = true;
                Email.Enabled = false;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            con.Close();
            cmd.Dispose();

        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Email Not Existi!', 'error');", true);

        }
    }
}