using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
public partial class Admin_AddState : System.Web.UI.Page
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
            CountryDropdownlist();
            ShowstateData();
        }
    }

    public void ShowstateData()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "SELECT distinct s.StateId,s.StateName,c.CountryName from state as s inner join country as c on c.CountryId = s.CountryId ";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ShowStateDatas.DataSource = dt;
        ShowStateDatas.DataBind();
        CountRow.Text = "Number of State : " + ShowStateDatas.Rows.Count.ToString();
        con.Close();
        cmd.Dispose();
    }
    public void CountryDropdownlist()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        MySqlDataAdapter adp = new MySqlDataAdapter("select * from country", con);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        if (dt.Rows.Count != 0)
        {
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "CountryName";
            DropDownList1.DataValueField = "CountryName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    protected void BtnSate_Click(object sender, EventArgs e)
    {
        if (BtnSate.Text == "Update")
        {
            try
            {
                int FriendId = int.Parse(CatID.Value);
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update state set CountryId=@CountryId,StateName=@StateName where StateId=@StateId";
                cmd.Parameters.AddWithValue("@CountryId", DropDownList1.SelectedIndex);
                cmd.Parameters.AddWithValue("@StateName", StateName.Text.Trim());

                cmd.Parameters.AddWithValue("@StateId", FriendId);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your State Has Been Updated Successfully ', 'success');", true);
                    ShowstateData();
                    ResetDatas();
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
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                //  lblMessage.ForeColor = System.Drawing.Color.Red;
                // lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
        }
        else
        {
            //try
            //{
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into state(CountryId,StateName) values (@CountryId,@StateName)";
            cmd.Parameters.AddWithValue("@CountryId", DropDownList1.SelectedIndex);
            cmd.Parameters.AddWithValue("@StateName", StateName.Text.Trim());
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your State Has Been Added Successfully ', 'success');", true);
                ShowstateData();
                ResetDatas();
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            con.Close();
            cmd.Dispose();
            //  }
            //catch (Exception)
            //{
            //    //  lblMessage.ForeColor = System.Drawing.Color.Red;
            //    // lblMessage.Text = "Invalid username and password";
            //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            //}
        }
    }

    protected void ResetData_Click(object sender, EventArgs e)
    {
        ResetDatas();
    }
    public void ResetDatas()
    {
        DropDownList1.ClearSelection();
        StateName.Text = string.Empty;
    }

    protected void ShowStateDatas_SelectedIndexChanged(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from state";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds, "dt");
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {

            CatID.Value = ds.Tables[0].Rows[0]["StateId"].ToString();
            SCName = ds.Tables[0].Rows[0]["CountryId"].ToString();
            MainCID = ds.Tables[0].Rows[0]["StateName"].ToString();
            CountryDropdownlist();

            StateName.Text = MainCID;
            DropDownList1.SelectedIndex =Convert.ToInt32(SCName);
            BtnSate.Text = "Update";

        }
        else
        {
            ID = "";
            SCName = "";
            MainCID = "";
        }
        con.Close();
    }


    protected void lnkView_Click1(object sender, EventArgs e)
    {
        int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        int categoryidds = Convert.ToInt32(ShowStateDatas.Rows[rowindex].Cells[2].Text);
        try
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from state where StateId=@StateId";
            cmd.Parameters.AddWithValue("@StateId", categoryidds);
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your State Has Been Deleted Successfully ', 'success');", true);
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            ShowstateData();
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

