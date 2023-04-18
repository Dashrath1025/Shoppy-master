using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserViewProduct : System.Web.UI.Page
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
          //  Response.Redirect("UserMainPage.aspx");
        }
        BindCategoryWiseProductRepeater();
        BindCartNumber();
      

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
            cmd.CommandText = "select u.Email,t.UseID,t.Qty from userlogin as u inner join tblcart as t on u.UserID = t.UseID where u.Email = @Email";
            //D CROSS APPLY(SELECT TOP 1 E.Name, Extention FROM tblProductImages E WHERE E.PID = D.PID) Name
            cmd.Parameters.AddWithValue("@Email", UserIDD);
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
    private void BindCategoryWiseProductRepeater()
    {
        
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select s.SubCategoryName,p.ProductId,p.productName,p.ProductCompany,p.ProductPrice,p.ProductPriceBeforeDiscount,p.Discount,p.ProductDescription,p.ShippingCharge,p.ProductImage1,p.ProductAvailability from subcategory as s inner join products as p on p.SubCatID = s.SubCategoryId and p.SubCatID =@SubCategoryId";
        cmd.Parameters.AddWithValue("@SubCategoryId", Request.QueryString["SubCategory"]);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        productcategorywises.DataSource = dt;
        productcategorywises.DataBind();
    }
    private void PriceFilteration()
    {

        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        int a = 0;
        cmd.CommandText = "select distinct * from products where ProductPriceBeforeDiscount between '"+ a +"' and '"+ filterprices.Text +"'; ";
        //cmd.Parameters.AddWithValue("@SubCategory", Request.QueryString["SubCategory"]);
        //cmd.Parameters.AddWithValue("@pricemin", a);
        //cmd.Parameters.AddWithValue("@FilePrice", filterprices.Text);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        productcategorywises.DataSource = dt;
        productcategorywises.DataBind();
    }



    protected void filterprices_TextChanged1(object sender, EventArgs e)
    {
        
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        int a = 0;
        cmd.CommandText = "select distinct * from products where ProductPriceBeforeDiscount between '" + a + "' and '" + filterprices.Text + "'; ";
        //cmd.Parameters.AddWithValue("@SubCategory", Request.QueryString["SubCategory"]);
        //cmd.Parameters.AddWithValue("@pricemin", a);
        //cmd.Parameters.AddWithValue("@FilePrice", filterprices.Text);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        productcategorywises.DataSource = dt;
        productcategorywises.DataBind();
        lblOutput.Text = filterprices.Text;
    }
}