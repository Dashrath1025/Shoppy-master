using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddCountry : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            ShowAddCountry();
        }
    }
    public void ShowAddCountry()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from country";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ShowAddCountryDatas.DataSource = dt;
        ShowAddCountryDatas.DataBind();
        CountRow.Text = "Number of Country : " + ShowAddCountryDatas.Rows.Count.ToString();
        con.Close();
        cmd.Dispose();
    }
    protected void BtnCreateCountry_Click(object sender, EventArgs e)
    {
        if (BtnCreateCountry.Text == "Update")
        {
            try
            {
                int FriendId = int.Parse(CountryID.Value);
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update country set CountryName=@CountryName where CountryId=@CountryId";
                cmd.Parameters.AddWithValue("@CountryName", CountryName.Text.Trim());
                //cmd.Parameters.AddWithValue("@CountryDescription", Description.Value);
                cmd.Parameters.AddWithValue("@CountryId", FriendId);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Country Has Been Updated Successfully ', 'success');", true);
                    BtnCreateCountry.Text = "Create";
                    restdata();
                }
                else
                {
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    //lblMessage.Text = "Invalid username and password";
                    // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                }
                ShowAddCountry();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                //Response.Write(ex.ToString());
                //  lblMessage.ForeColor = System.Drawing.Color.Red;
                // lblMessage.Text = "Invalid username and password";
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
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
                cmd.CommandText = "insert into country(CountryName,CreationDate) values (@CountryName,@CreationDate)";
                cmd.Parameters.AddWithValue("@CountryName", CountryName.Text.Trim());
                //cmd.Parameters.AddWithValue("@CountryDescription", Description.Value);
                cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Country Has Been Added Successfully ', 'success');", true);
                    restdata();
                }
                else
                {
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    //lblMessage.Text = "Invalid username and password";
                    // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                }
                ShowAddCountry();
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
    }
    public void restdata()
    {
        CountryName.Text = "";
        //Description.Value = "";
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        restdata();
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        try
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int categoryidds = Convert.ToInt32(ShowAddCountryDatas.Rows[rowindex].Cells[2].Text);
           
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from country where CountryId=@CountryId";
            cmd.Parameters.AddWithValue("@CountryId", categoryidds);
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Country Has Been Deleted Successfully ', 'success');", true);
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            ShowAddCountry();
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

    protected void ShowAddCountryDatas_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = ShowAddCountryDatas.SelectedRow;
        CountryID.Value = gr.Cells[2].Text;
        CountryName.Text = gr.Cells[3].Text;
        //Description.Value = gr.Cells[4].Text;
        BtnCreateCountry.Text = "Update";
    }
}