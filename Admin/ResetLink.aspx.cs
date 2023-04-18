using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public partial class Admin_ResetLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string email = Session["Username"].ToString();
    }

    protected void BtnForgotpassword_Click(object sender, EventArgs e)
    {
        string email = Session["Username"].ToString();
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText="Update adminlogin set Password = '" + Encrypt(TxtPassword.Text.Trim()) + "'where Username = '" + email + "'";
        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();
        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !!!', 'Your Password Has Been Updated Successfully !', 'success');", true);
        resetdatas();
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
        resetdatas();
    }
    public void resetdatas()
    {
        TxtPassword.Text = "";
        TxtCofrmPwd.Text = "";
    }
}