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
public partial class Admin_AddCIty : System.Web.UI.Page
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
            CategoryDropdownlist();
            ShowSubCategoryData();
        }
    }
    public void ShowSubCategoryData()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "SELECT distinct c.CityId,c.StateId,c.Cityname,s.StateId,s.CountryId,s.StateName from city as c inner join state s on c.StateId = s.StateId";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ShowSubCategoryDatas.DataSource = dt;
        ShowSubCategoryDatas.DataBind();
        CountRow.Text = "Number of SubCategory : " + ShowSubCategoryDatas.Rows.Count.ToString();
        con.Close();
        cmd.Dispose();
    }
    public void CategoryDropdownlist()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        MySqlDataAdapter adp = new MySqlDataAdapter("select * from state", con);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        if (dt.Rows.Count != 0)
        {
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "StateName";
            DropDownList1.DataValueField = "StateName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    protected void BtnCity_Click(object sender, EventArgs e)
    {
        if (BtnCity.Text == "Update")
        {
            try
            {
                int FriendId = int.Parse(CatID.Value);
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update city set StateId=@StateId,Cityname=@Cityname where CityId=@CityId";
                cmd.Parameters.AddWithValue("@StateId", DropDownList1.SelectedIndex);
                cmd.Parameters.AddWithValue("@Cityname", CityName.Text.Trim());
              
                cmd.Parameters.AddWithValue("@CityId", FriendId);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your City Has Been Updated Successfully ', 'success');", true);
                    ShowSubCategoryData();
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
            try
            {
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into city(StateId,Cityname) values (@StateId,@Cityname)";
                cmd.Parameters.AddWithValue("@StateId", DropDownList1.SelectedIndex);
                cmd.Parameters.AddWithValue("@Cityname", CityName.Text.Trim());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your City Has Been Added Successfully ', 'success');", true);
                    ShowSubCategoryData();
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
            catch (Exception)
            {
                //  lblMessage.ForeColor = System.Drawing.Color.Red;
                // lblMessage.Text = "Invalid username and password";
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
        }
    }

    protected void ResetData_Click(object sender, EventArgs e)
    {
        ResetDatas();
    }
    public void ResetDatas()
    {
        DropDownList1.ClearSelection();
        CityName.Text = string.Empty;
    }


    protected void ShowSubCategoryDatas_SelectedIndexChanged(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "SELECT distinct c.CityId,c.StateId,c.Cityname,s.StateId,s.CountryId,s.StateName from city as c inner join state s on c.StateId = s.StateId";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(ds, "dt");
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {

            CatID.Value = ds.Tables[0].Rows[0]["StateId"].ToString();
            SCName = ds.Tables[0].Rows[0]["StateName"].ToString();
            MainCID = ds.Tables[0].Rows[0]["Cityname"].ToString();
            CategoryDropdownlist();
            CityName.Text = MainCID;
            DropDownList1.SelectedValue = SCName;
            BtnCity.Text = "Update";
        }
        else
        {
            ID = "";
            SCName = "";
            MainCID = "";
        }
        con.Close();
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        int categoryidds = Convert.ToInt32(ShowSubCategoryDatas.Rows[rowindex].Cells[2].Text);
        try
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from city where CityId=@CityId";
            cmd.Parameters.AddWithValue("@CityId", categoryidds);
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your City Has Been Deleted Successfully ', 'success');", true);
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            ShowSubCategoryData();
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