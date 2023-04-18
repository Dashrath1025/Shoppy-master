using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class Admin_ManageOrder : System.Web.UI.Page
{
    static Boolean validdate;
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
            DisplauUserOrderDetails();
        }
    }
    public void DisplauUserOrderDetails()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select distinct p.productName,p.ProductCompany,p.ProductPriceBeforeDiscount,p.ProductImage1,o.OID,o.PaymentID,o.UID,o.DateTime,o.OrderStatus,b.BillingAddress,b.BillingPincode,u.Email,c.CountryName,s.StateName,ci.CityName from products as p inner join orderdetails as o  inner join useraddress as b inner join userlogin as u inner join country as c inner join state as s inner join city as ci on p.ProductId = o.ProductID and b.UserID = u.UserID and b.BillingCountry = c.CountryId and b.BillingState = s.StateId and b.BillingCity = ci.CityId order by o.OID desc;";
        //cmd.Parameters.AddWithValue("@Email", Session["uname"].ToString());
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DisplayUserOrder.DataSource = ds;
        DisplayUserOrder.DataBind();
       
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        
    }

   

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select distinct p.productName,p.ProductCompany,p.ProductPriceBeforeDiscount,p.ProductImage1,o.OID,o.PaymentID,o.UID,o.DateTime,o.OrderStatus,b.BillingAddress,b.BillingPincode,u.Email,c.CountryName,s.StateName,ci.CityName from products as p inner join orderdetails as o  inner join useraddress as b inner join userlogin as u inner join country as c inner join state as s inner join city as ci on p.ProductId = o.ProductID and b.UserID = u.UserID and b.BillingCountry = c.CountryId and b.BillingState = s.StateId and b.BillingCity = ci.CityId and p.productName = '" + TextBox1.Text + "' order by o.OID desc;";
        //cmd.Parameters.AddWithValue("@Email", Session["uname"].ToString());
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);    
        DisplayUserOrder.DataSource = ds;
        DisplayUserOrder.DataBind();
    }

    protected void FetchDate_Click(object sender, EventArgs e)
    {
        DateTime fromDate = Convert.ToDateTime(FromDate.Text);
        DateTime toDate = Convert.ToDateTime(ToDate.Text);
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select distinct p.productName,p.ProductCompany,p.ProductPriceBeforeDiscount,p.ProductImage1,o.OID,o.PaymentID,o.UID,o.DateTime,o.OrderStatus ,b.BillingAddress,b.BillingPincode,u.Email,c.CountryName,s.StateName,ci.CityName from products as p inner join orderdetails as o  inner join useraddress as b inner join userlogin as u inner join country as c inner join state as s inner join city as ci on p.ProductId = o.ProductID and b.UserID = u.UserID and b.BillingCountry = c.CountryId and b.BillingState = s.StateId and b.BillingCity = ci.CityId and o.DateTime between @fromdates and @todates;";
        cmd.Parameters.AddWithValue("@fromdates", fromDate);
        cmd.Parameters.AddWithValue("@todates", toDate);

        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DisplayUserOrder.DataSource = ds;
        DisplayUserOrder.DataBind();
    }



    protected void DisplayUserOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = DisplayUserOrder.SelectedRow;
        txtoid.Text = gr.Cells[1].Text;
       
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE orderdetails SET OrderStatus = @OrderStatus WHERE OID = @OID";
            cmd.Parameters.AddWithValue("@OrderStatus", ddlOptions.SelectedValue);
            cmd.Parameters.AddWithValue("@OID", txtoid.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Order Status Has Been Deleted Successfully ', 'success');", true);
                DisplauUserOrderDetails();
                txtoid.Text = string.Empty;
                ddlOptions.ClearSelection();
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            DisplayUserOrder.DataBind();
            con.Close();
            cmd.Dispose();
        }
        catch (Exception)
        {
       
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
        }
    }
}