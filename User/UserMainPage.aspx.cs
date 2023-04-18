using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lbluser = (Label)Master.FindControl("lbluser");
        if (Session["Emails"] != null)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from userlogin where Email='" + Session["Emails"] + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MailAddress addr = new MailAddress(ds.Tables[0].Rows[0]["Email"].ToString());
            lbluser.Text = "Hello : " + addr.User;
        }
        else
        {
            lbluser.Text = "Hello : Guest";
            // Response.Redirect("UserLogin.aspx");
        }
        if (!IsPostBack)
        {
            BindProductRepeater();
            BindCartNumber();
            FilterCategoryDropdownlist();
        }

    }
    public void BindCartNumber()
    {
        if (Session["Emails"] != null)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            string UserIDD = Session["Emails"].ToString();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblCart  where UseID = @UseID";
            //D CROSS APPLY(SELECT TOP 1 E.Name, Extention FROM tblProductImages E WHERE E.PID = D.PID) Name
            cmd.Parameters.AddWithValue("@UseID", UserIDD);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();     
                var SummaryContainer = (System.Web.UI.HtmlControls.HtmlGenericControl)Page.Master.FindControl("CartBadge");
                SummaryContainer.InnerText = CartQuantity;
            }
            else
            {       
               var SummaryContainer = (System.Web.UI.HtmlControls.HtmlGenericControl)Page.Master.FindControl("CartBadge");
                SummaryContainer.InnerText = "0";
            }

        }

    }
    private void BindProductRepeater()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from products";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        rptrProducts.DataSource = dt;
        rptrProducts.DataBind();
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from products where productName=@txtvalue or ProductCompany=@txtvalue";
        cmd.Parameters.AddWithValue("txtvalue", txtsearch.Text.Trim());
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        rptrProducts.DataSource = dt;
        rptrProducts.DataBind();

    }
    public void FilterCategoryDropdownlist()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        MySqlDataAdapter adp = new MySqlDataAdapter("select * from category", con);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        if (dt.Rows.Count != 0)
        {
            filecategory.DataSource = dt;
            filecategory.DataTextField = "CategoryName";
            filecategory.DataValueField = "Categoyid";
            filecategory.DataBind();
            filecategory.Items.Insert(0, new ListItem("Select Category", "0"));

        }
    }
    protected void filecategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from products where CatID=@DropCategoryFilterData";
        cmd.Parameters.AddWithValue("DropCategoryFilterData", filecategory.SelectedIndex);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        rptrProducts.DataSource = dt;
        rptrProducts.DataBind();
    }
}

//protected override void InitializeCulture()
//{
//    CultureInfo ci = new CultureInfo("en-IN");
//    ci.NumberFormat.CurrencySymbol = "₹";
//    Thread.CurrentThread.CurrentCulture = ci;

//    base.InitializeCulture();
//}
