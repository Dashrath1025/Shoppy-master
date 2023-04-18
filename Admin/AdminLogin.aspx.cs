using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
public partial class Admin_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                TxtUsername.Text = Request.Cookies["UserName"].Value;
                TxtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }
    }
   
    protected void BtnAdminLogin_Click(object sender, EventArgs e)
    {
        try
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select Username,Password from adminlogin where Username=@Username and Password=@Password";
            cmd.Parameters.AddWithValue("@Username", TxtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", Decrypt(TxtPassword.Text.Trim()));
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["uname"] = TxtUsername.Text.Trim();
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                if (remember.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(7);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = TxtUsername.Text.Trim();
                Response.Cookies["Password"].Value = TxtPassword.Text.Trim();
                Response.Redirect("../Admin/AdminDashboard.aspx");
                restdatas();
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            con.Close();
            cmd.Dispose();
        }
        catch (Exception)
        {
            //  lblMessage.ForeColor = System.Drawing.Color.Red;
            // lblMessage.Text = "Invalid username and password";
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
        }

    }
    private string Decrypt(string clearText)
    {
        string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    public void restdatas()
    {
        TxtUsername.Text = "";
        TxtPassword.Text = "";
    }
}