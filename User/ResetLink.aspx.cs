using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ResetLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Request.QueryString["usernames"].ToString());
        //if (Session["Emailsid"] != null)
        //{

        //}
        //else
        //{
        //    Response.Redirect("/User/UserLogin.aspx");
        //}
        //string email = Session["Username"].ToString();
    }

    protected void BtnForgotpassword_Click(object sender, EventArgs e)
    {
       
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Update userdetails set Password = '" + Encrypt(TxtPassword.Text.Trim()) + "' where Email = '" + Request.QueryString["usernames"].ToString() + "'";
        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();
        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !!!', 'Your Password Has Been Updated Successfully !', 'success');", true);
        TxtPassword.Text = "";
        TxtCofrmPwd.Text = "";
    }
    private string Encrypt(string clearText)
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

    protected void ResetData_Click(object sender, EventArgs e)
    {
        TxtPassword.Text = "";
        TxtCofrmPwd.Text = "";
    }
}