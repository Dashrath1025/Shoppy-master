using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data;

public partial class Admin_AddNewAdmin : System.Web.UI.Page
{
    string ID = "";
    string SCName = "";
    string MainCID = "";
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
        if (!Page.IsPostBack)
        {
            ShowAdminData();
        }
    }
    public void ShowAdminData()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from adminlogin";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ShowAdminDatas.DataSource = dt;
        ShowAdminDatas.DataBind();
        CountRow.Text = "Number of Admin : " + ShowAdminDatas.Rows.Count.ToString();
        con.Close();
        cmd.Dispose();
    }
    protected void BtnNewAdmin_Click(object sender, EventArgs e)
    {
        if (BtnNewAdmin.Text == "Update")
        {
            try
            {
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update adminlogin set Username=@Username,Password=@Password,UpdationDate=@UpdationDate where Aid=@Aid";
                cmd.Parameters.AddWithValue("@Aid", CatID.Value);                
                cmd.Parameters.AddWithValue("@Username", TxtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", Encrypt(TxtPassword.Text.Trim()));
                cmd.Parameters.AddWithValue("@UpdationDate", DateTime.Now);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !!!', 'Admin Added Successfully !', 'success');", true);
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    // lblMessage.Text = "New Admin Added SuccessFully :) ";
                    ShowAdminData();
                    resetdats();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    //lblMessage.Text = "Oops Something Wents Wrong !";
                }
                ShowAdminData();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Oops Something Wents Wrong !";
            }
        }
        else
        {
            try
            {
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into adminlogin(Username,Password,CreationDate) values (@Username,@Password,@CreationDate)";
                cmd.Parameters.AddWithValue("@Username", TxtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", Encrypt(TxtPassword.Text.Trim()));
                cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !!!', 'Admin Added Successfully !', 'success');", true);
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    // lblMessage.Text = "New Admin Added SuccessFully :) ";
                    ShowAdminData();
                    resetdats();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    //lblMessage.Text = "Oops Something Wents Wrong !";
                }
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Oops Something Wents Wrong !";
            }

        }
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

    protected void lnkView_Click(object sender, EventArgs e)
    {
        int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        int categoryidds = Convert.ToInt32(ShowAdminDatas.Rows[rowindex].Cells[2].Text);
        try
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from adminlogin where Aid=@Aid";
            cmd.Parameters.AddWithValue("@Aid", categoryidds);
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Deleted Successfully ', 'success');", true);
                ShowAdminData();
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
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

    protected void ShowAdminDatas_SelectedIndexChanged(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from adminlogin";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds, "dt");
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {

            CatID.Value = ds.Tables[0].Rows[0]["Aid"].ToString();
            TxtUsername.Text = ds.Tables[0].Rows[0]["Username"].ToString();
            BtnNewAdmin.Text = "Update";
        }
        else
        {
            ID = "";
            SCName = "";
            MainCID = "";
        }
        con.Close();
    }

    protected void ResetData_Click(object sender, EventArgs e)
    {
        resetdats();
    }
    public void resetdats()
    {
        TxtUsername.Text = "";
        TxtPassword.Text = "";
    }
}