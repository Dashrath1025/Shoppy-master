using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

public partial class User_GetUserDetails : System.Web.UI.Page
{
    public string UserEmail;
    static int UseID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Response.Write(Session["totalPayment"].ToString());
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
            UseID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
            // Session["UserPayment"] = Label1.Text;
            //Label1.Text = UseID;
            Session["UID"] = UseID;
            UserEmail = (string)Session["Emails"];
            //BillingFirstname.Text = ds.Tables[0].Rows[0]["Firstname"].ToString();
            //BillingMiddlename.Text = ds.Tables[0].Rows[0]["Middlename"].ToString();
            //BillingLastname.Text = ds.Tables[0].Rows[0]["Lastname"].ToString();
            //BillingEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            //BillingMobileno.Text = ds.Tables[0].Rows[0]["Mobileno"].ToString();
            //BillingAddress.Value = ds.Tables[0].Rows[0]["Street"].ToString();
            //string bindbilingcountry = ds.Tables[0].Rows[0]["Country"];
            //BillingCountry.SelectedValue = bindbilingcountry;
            //BillingPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

            Bindgroiddata();

            //    TextBox1.Text = Application["Productsid"].ToString();



        }
        else
        {
            //lbluser.Text = "Hello : Guest";
            Response.Redirect("UserLogin.aspx");
        }
        if (!Page.IsPostBack)
        {
          //  ShippingBindgriddata();
            CountryDropdownlist();

        }

    }
    public void Bindgroiddata()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select tblcart.ProductId,tblcart.productName,tblcart.ProductPriceBeforeDiscount,products.ProductId,products.ProductImage1 from tblcart CROSS join products WHERE tblCart.ProductId = products.ProductId  and  UseID= '" + UseID + "'";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);

    }
    public void CountryDropdownlist()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        MySqlDataAdapter adp = new MySqlDataAdapter("select * from country", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        BillingCountry.DataSource = ds;
        BillingCountry.DataTextField = "CountryName";
        BillingCountry.DataValueField = "CountryId";
        BillingCountry.DataBind();
        BillingCountry.Items.Insert(0, new ListItem("-- Select --", "0"));
        BillingState.Items.Insert(0, new ListItem("-- Select --", "0"));
        BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
    //public void ShippingBindgriddata()
    //{
    //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //    MySqlCommand cmd = new MySqlCommand();
    //    con.Open();
    //    cmd.Connection = con;
    //    MySqlDataAdapter adp = new MySqlDataAdapter("select * from country", con);
    //    DataSet ds = new DataSet();
    //    adp.Fill(ds);
    //    ShippingCountry.DataSource = ds;
    //    ShippingCountry.DataTextField = "CountryName";
    //    ShippingCountry.DataValueField = "CountryId";
    //    ShippingCountry.DataBind();
    //    ShippingCountry.Items.Insert(0, new ListItem("-- Select --", "0"));
    //    ShippingState.Items.Insert(0, new ListItem("-- Select --", "0"));
    //    ShippingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}

    protected void rzpbutton1_Click(object sender, EventArgs e)
    {
        try
        { 
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        // DataTable dt = new DataTable();
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "insert into useraddress(UserID,BillingFirstname,BillingMiddlename,BillingLastname,BillingEmail,BillingMobileno,BillingAddress,BillingCountry,BillingState,BillingCity,BillingPincode,DateTime) values(@UserID,@BillingFirstname,@BillingMiddlename,@BillingLastname,@BillingEmail,@BillingMobileno,@BillingAddress,@BillingCountry,@BillingState,@BillingCity,@BillingPincode,@DateTime)";
        cmd.Parameters.AddWithValue("@UserID", UseID.ToString());
        cmd.Parameters.AddWithValue("@BillingFirstname", BillingFirstname.Text);
        cmd.Parameters.AddWithValue("@BillingMiddlename", BillingMiddlename.Text);
        cmd.Parameters.AddWithValue("@BillingLastname", BillingLastname.Text);
        cmd.Parameters.AddWithValue("@BillingEmail", BillingEmail.Text);
        cmd.Parameters.AddWithValue("@BillingMobileno", BillingMobileno.Text);
        cmd.Parameters.AddWithValue("@BillingAddress", BillingAddress.Value);
        cmd.Parameters.AddWithValue("@BillingCountry", BillingCountry.SelectedIndex);
        cmd.Parameters.AddWithValue("@BillingState", BillingState.SelectedIndex);
        cmd.Parameters.AddWithValue("@BillingCity", BillingCity.SelectedIndex);
        cmd.Parameters.AddWithValue("@BillingPincode", BillingPincode.Text);
        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
        if (cmd.ExecuteNonQuery() > 0)
        {


            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Order Placed Successfully :) ')", true);
            Response.Redirect("UserPayment.aspx");
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);

        }
        }catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }



protected void BillingState_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        int SId = Convert.ToInt32(BillingState.SelectedValue);
        MySqlDataAdapter adp = new MySqlDataAdapter("select * from City where StateId=" + SId, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        BillingCity.DataSource = ds;
        BillingCity.DataTextField = "Cityname";
        BillingCity.DataValueField = "CityId";
        BillingCity.DataBind();
        BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
        if (BillingState.SelectedValue == "0")
        {
            BillingCity.Items.Clear();
            BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message.ToString());
    }
}



protected void BillingCountry_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        int cId = Convert.ToInt32(BillingCountry.SelectedValue);
        MySqlDataAdapter adp = new MySqlDataAdapter("select * from State where CountryId=" + cId, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        BillingState.DataSource = ds;
        BillingState.DataTextField = "StateName";
        BillingState.DataValueField = "StateId";
        BillingState.DataBind();
        BillingState.Items.Insert(0, new ListItem("-- Select --", "0"));
        if (BillingCountry.SelectedValue == "0")
        {
            BillingState.Items.Clear();
            BillingState.Items.Insert(0, new ListItem("-- Select --", "0"));
            BillingCity.Items.Clear();
            BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message.ToString());
    }
}


protected void Button1_Click(object sender, EventArgs e)
{

//    ShippingFirstname.Text = BillingFirstname.Text;
//    ShippingMiddlename.Text = BillingMiddlename.Text;
//    ShippingLastname.Text = BillingLastname.Text;
//    ShippingEmail.Text = BillingEmail.Text;
//    ShippingMobileno.Text = BillingMobileno.Text;
//    ShippingAddress.Value = BillingAddress.Value;
//    // ShippingCountry.SelectedValue = BillingCountry.SelectedValue;
//    //ShippingState.SelectedValue = BillingState.SelectedValue;
//    //ShippingCity.SelectedValue = BillingCity.SelectedValue;
//    ShippingPincode.Text = BillingPincode.Text;


}
public void SavedCartDetails(int a, string b, string c)
{
    try
    {

        string datainsert = "insert into purchaseproduct(ProductId,Productname,ProductPrice,Email,DateTime) values('" + a + "','" + b + "','" + c + "','" + Session["Emails"].ToString() + "','" + DateTime.Now + "')";
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.CommandText = datainsert;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
    }
    catch (Exception ex)
    {
        Response.Write(ex.ToString());
    }
}

//protected void ShippingCountry_SelectedIndexChanged(object sender, EventArgs e)
//{
//    try
//    {
//        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
//        MySqlCommand cmd = new MySqlCommand();
//        con.Open();
//        cmd.Connection = con;
//        int cId = Convert.ToInt32(ShippingCountry.SelectedValue);
//        MySqlDataAdapter adp = new MySqlDataAdapter("select * from State where CountryId=" + cId, con);
//        DataSet ds = new DataSet();
//        adp.Fill(ds);
//        ShippingState.DataSource = ds;
//        ShippingState.DataTextField = "StateName";
//        ShippingState.DataValueField = "StateId";
//        ShippingState.DataBind();
//        ShippingState.Items.Insert(0, new ListItem("-- Select --", "0"));
//        if (ShippingCountry.SelectedValue == "0")
//        {
//            ShippingState.Items.Clear();
//            ShippingState.Items.Insert(0, new ListItem("-- Select --", "0"));
//            ShippingCity.Items.Clear();
//            ShippingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
//        }
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex.Message.ToString());
//    }
//}


//protected void ShippingState_SelectedIndexChanged(object sender, EventArgs e)
//{
//    try
//    {
//        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
//        MySqlCommand cmd = new MySqlCommand();
//        con.Open();
//        cmd.Connection = con;
//        int SId = Convert.ToInt32(ShippingState.SelectedValue);
//        MySqlDataAdapter adp = new MySqlDataAdapter("select * from City where StateId=" + SId, con);
//        DataSet ds = new DataSet();
//        adp.Fill(ds);
//        ShippingCity.DataSource = ds;
//        ShippingCity.DataTextField = "Cityname";
//        ShippingCity.DataValueField = "CityId";
//        ShippingCity.DataBind();
//        ShippingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
//        if (ShippingState.SelectedValue == "0")
//        {
//            ShippingCity.Items.Clear();
//            ShippingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
//        }
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex.Message.ToString());
//    }
//}


}

    