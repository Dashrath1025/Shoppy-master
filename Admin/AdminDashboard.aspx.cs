using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
public partial class Admin_AdminDashboard : System.Web.UI.Page
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
            AdminName.Text = "Hello : "+ ds.Tables[0].Rows[0]["Username"].ToString();
            ShowAdminDashboardData();
        }
    }
    public void ShowAdminDashboardData()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(UserID) As Count FROM userlogin", con))
        {
            cmd.CommandType = CommandType.Text;
            con.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                Nousers.Text =  o.ToString();
            }
            con.Close();
        }
        MySqlConnection cono = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(OID) As Count FROM orderdetails", cono))
        {
            cmd.CommandType = CommandType.Text;
            cono.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                NoOrder.Text = o.ToString();
            }
            cono.Close();
        }
        MySqlConnection cond = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT count(*) FROM orderdetails WHERE DateTime > curdate()", cond))
        {
            cmd.CommandType = CommandType.Text;
            cond.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                TodaysOrder.Text = o.ToString();
            }
            cond.Close();
        }
        MySqlConnection cons = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(Categoyid) As Count FROM category", con))
        {
            cmd.CommandType = CommandType.Text;
            con.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                NoCategory.Text = o.ToString();
            }
            con.Close();
        }
        MySqlConnection cona = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(SubCategoryId) As Count FROM subcategory", cona))
        {
            cmd.CommandType = CommandType.Text;
            cona.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                NoSubCategory.Text = o.ToString();
            }
            cona.Close();
        }
        MySqlConnection conb = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(Aid) As Count FROM adminlogin", conb))
        {
            cmd.CommandType = CommandType.Text;
            conb.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                NoAdmin.Text = o.ToString();
            }
            conb.Close();
        }
        MySqlConnection conc = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ProductId) As Count FROM products", conc))
        {
            cmd.CommandType = CommandType.Text;
            conc.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                NoProducts.Text = o.ToString();
            }
            conc.Close();
        }
        MySqlConnection cone = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(CountryId) As Count FROM country", cone))
        {
            cmd.CommandType = CommandType.Text;
            cone.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                lblCountry.Text = o.ToString();
            }
            cone.Close();
        }
        MySqlConnection conf = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(StateId) As Count FROM state", conf))
        {
            cmd.CommandType = CommandType.Text;
            conf.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                lblState.Text = o.ToString();
            }
            conf.Close();
        }
        MySqlConnection cong = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(CityId) As Count FROM city", cong))
        {
            cmd.CommandType = CommandType.Text;
            cong.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                lblCIty.Text = o.ToString();
            }
            cong.Close();
        }
    }
}