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
public partial class Admin_AddCategory : System.Web.UI.Page
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
            ShowAddCategoryData();
        }
    }
    public void ShowAddCategoryData()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from category";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ShowAddCategoryDatas.DataSource = dt;
        ShowAddCategoryDatas.DataBind();
        CountRow.Text = "Number of Category : " + ShowAddCategoryDatas.Rows.Count.ToString();
        con.Close();
        cmd.Dispose();
    }
  
    protected void BtnCreateCategory_Click(object sender, EventArgs e)
    {
       
        if (BtnCreateCategory.Text == "Update")
        {
            try
            {
                int FriendId = int.Parse(CatID.Value);
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update category set CategoryName=@CategoryName,CategoryDescription=@CategoryDescription where Categoyid=@Categoyid";
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryDescription", Description.Value);
                cmd.Parameters.AddWithValue("@Categoyid", FriendId);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                    BtnCreateCategory.Text = "Create";
                    restdata();
                }
                else
                {
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    //lblMessage.Text = "Invalid username and password";
                    // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                }
                ShowAddCategoryData();
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
                cmd.CommandText = "insert into category(CategoryName,CategoryDescription,CreationDate) values (@CategoryName,@CategoryDescription,@CreationDate)";
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryDescription", Description.Value);
                cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Added Successfully ', 'success');", true);
                    restdata();
                }
                else
                {
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    //lblMessage.Text = "Invalid username and password";
                    // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
                }
                ShowAddCategoryData();
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

   // protected void lnkView_Click(object sender, EventArgs e)
    //{
        //    int Categoyids = Convert.ToInt32((sender as LinkButton).CommandArgument);
        //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        //    MySqlCommand cmd = new MySqlCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    MySqlDataAdapter sqlDa = new MySqlDataAdapter("ContactViewByID", con);
        //    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    sqlDa.SelectCommand.Parameters.AddWithValue("@Categoyid", Categoyids);
        //    DataTable dtbl = new DataTable();
        //    sqlDa.Fill(dtbl);
        //    con.Close();
        //    hfContactID.Value = Categoyids.ToString();
        //    CategoryName.Text = dtbl.Rows[1]["CategoryName"].ToString();
        //    Description.Value = dtbl.Rows[0]["CategoryDescription"].ToString();
        //    BtnCreateCategory.Text = "Update";
    //}

    protected void ShowAddCategoryDatas_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = ShowAddCategoryDatas.SelectedRow;
        CatID.Value = gr.Cells[2].Text;
        CategoryName.Text = gr.Cells[3].Text;
        Description.Value = gr.Cells[4].Text;
        BtnCreateCategory.Text = "Update";
    }

    protected void lnkView_Click1(object sender, EventArgs e)
    {      
        try
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int categoryidds = Convert.ToInt32(ShowAddCategoryDatas.Rows[rowindex].Cells[2].Text);
            Response.Write(categoryidds);
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from category where Categoyid=@Categoyid";
            cmd.Parameters.AddWithValue("@Categoyid", categoryidds);
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Deleted Successfully ', 'success');", true);
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            ShowAddCategoryData();
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

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        restdata();
    }
    public void restdata()
    {
        CategoryName.Text = "";
        Description.Value = "";
    }
}