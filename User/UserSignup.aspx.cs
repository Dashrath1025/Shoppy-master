using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Net;
using System.Net.Mail;
public partial class User_UserSignup : System.Web.UI.Page
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



    protected void BtnUserSignup_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmdd = new MySqlCommand();
        conn.Open();

        cmdd.Connection = conn;
        cmdd.CommandText = "select UserID from userlogin where Email=@Email";
        cmdd.Parameters.AddWithValue("@Email", Email.Text.Trim());
        var result = cmdd.ExecuteScalar();
        if (result != null)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'This Email has been using by another user!', 'error');", true);
        }
        else
        {
            Random random = new Random();
            ActivationCode = random.Next(2001, 9999).ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into userlogin(Email,UserOtp,Datetime) values (@Email,@UserOtp,@Datetime)";
            cmd.Parameters.AddWithValue("@Email", Email.Text);
            cmd.Parameters.AddWithValue("@UserOtp", ActivationCode);
            cmd.Parameters.AddWithValue("@Datetime", DateTime.Now);
            if (cmd.ExecuteNonQuery() > 0)
            {

                sendotp();
                this.ClientScript.RegisterStartupScript(this.GetType(), "sweetalert", "swal('done !!!', 'otp has been sent successfully !', 'success');", true);

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
        conn.Close();
        cmdd.Dispose();
    }
    public void sendotp()
    {
      
        string to = Email.Text.Trim(); //To address    
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


}