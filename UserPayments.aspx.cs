using MySql.Data.MySqlClient;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPayments : System.Web.UI.Page
{
    public string orderId;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["Emails"] != null)
        {

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from userdetails where Email='" + Session["Emails"] + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //BillingFirstname.Text = ds.Tables[0].Rows[0]["Firstname"].ToString();
            //BillingMiddlename.Text = ds.Tables[0].Rows[0]["Middlename"].ToString();
            //BillingLastname.Text = ds.Tables[0].Rows[0]["Lastname"].ToString();
            //BillingEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            //BillingMobileno.Text = ds.Tables[0].Rows[0]["Mobileno"].ToString();
            //BillingAddress.Value = ds.Tables[0].Rows[0]["Street"].ToString();
            ////string bindbilingcountry = ds.Tables[0].Rows[0]["Country"];
            ////BillingCountry.SelectedValue = bindbilingcountry;
            //BillingPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

            Bindgroiddata();

            //    TextBox1.Text = Application["Productsid"].ToString();



        }
        else
        {
            //lbluser.Text = "Hello : Guest";
            Response.Redirect("UserLogin.aspx");
        }
        //if (!Page.IsPostBack)
        //{
        //    ShippingBindgriddata();
        //    CountryDropdownlist();

        //}

    }
    public void Bindgroiddata()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select tblcart.ProductId,tblcart.productName,tblcart.ProductPriceBeforeDiscount,products.ProductId,products.ProductImage1 from tblcart CROSS join products WHERE tblCart.ProductId = products.ProductId  and Email= '" + Session["Emails"] + "'";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        YourProducts.DataSource = dt;
        YourProducts.DataBind();
        string totalprice = dt.Tables[0].Rows[0]["ProductPriceBeforeDiscount"].ToString();
        TotalPaypables.Text = totalprice;
        TotalPaypable.Text = totalprice;
        Dictionary<string, object> input = new Dictionary<string, object>();
        input.Add("amount", (Convert.ToInt32(totalprice)) * 100); // this amount should be same as transaction amount
        input.Add("currency", "INR");
        input.Add("receipt", "1121");
        input.Add("payment_capture", 1);

        string key = "rzp_test_zRVtNrhYeKNpWu";
        string secret = "CLUFWCAonegVMsHoOGp6cEjx";

        RazorpayClient client = new RazorpayClient(key, secret);

        Razorpay.Api.Order order = client.Order.Create(input);
        orderId = order["id"].ToString();
        //for (int i = 0; i < YourProducts.Rows.Count - 1; i++)
        //{
        //    int a = Convert.ToInt32(dt.Tables[0].Rows[0]["ProductId"].ToString());
        //    string b = dt.Tables[0].Rows[0]["productName"].ToString();
        //    string c = dt.Tables[0].Rows[0]["ProductPriceBeforeDiscount"].ToString();
        //    SavedCartDetails(Convert.ToInt32(YourProducts.Rows[i].Cells[0].Text), YourProducts.Rows[i].Cells[1].Text, YourProducts.Rows[i].Cells[2].Text);
        //    CountRow.Text = "No. of Product : " + YourProducts.Rows.Count.ToString();
        //}
    }
    //public void CountryDropdownlist()
    //{
    //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //    MySqlCommand cmd = new MySqlCommand();
    //    con.Open();
    //    cmd.Connection = con;
    //    MySqlDataAdapter adp = new MySqlDataAdapter("select * from country", con);
    //    DataSet ds = new DataSet();
    //    adp.Fill(ds);
    //    BillingCountry.DataSource = ds;
    //    BillingCountry.DataTextField = "CountryName";
    //    BillingCountry.DataValueField = "CountryId";
    //    BillingCountry.DataBind();
    //    BillingCountry.Items.Insert(0, new ListItem("-- Select --", "0"));
    //    BillingState.Items.Insert(0, new ListItem("-- Select --", "0"));
    //    BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
    //}
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

    //protected void rzpbutton1_Click(object sender, EventArgs e)
    //{
    //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //    DataTable dt = new DataTable();
    //    MySqlCommand cmd = new MySqlCommand();
    //    con.Open();
    //    cmd.Connection = con;
    //    cmd.CommandText = "insert into shippingaddress(Firstname,Middlename,Lastname,Email,Mobileno,Address,Country,State,City,Pincode,ProductPrice,PaymentOption,DateTime) values(@Firstname,@Middlename,@Lastname,@Email,@Mobileno,@Address,@Country,@State,@City,@Pincode,@ProductPrice,@PaymentOption,@DateTime)";
    //    cmd.Parameters.AddWithValue("@Firstname", ShippingFirstname.Text);
    //    cmd.Parameters.AddWithValue("@Middlename", ShippingMiddlename.Text);
    //    cmd.Parameters.AddWithValue("@Lastname", ShippingLastname.Text);
    //    cmd.Parameters.AddWithValue("@Email", ShippingEmail.Text);
    //    cmd.Parameters.AddWithValue("@Mobileno", ShippingMobileno.Text);
    //    cmd.Parameters.AddWithValue("@Address", ShippingAddress.Value);
    //    cmd.Parameters.AddWithValue("@Country", ShippingCountry.SelectedItem);
    //    cmd.Parameters.AddWithValue("@State", ShippingState.SelectedItem);
    //    cmd.Parameters.AddWithValue("@City", ShippingCity.SelectedItem);
    //    cmd.Parameters.AddWithValue("@Pincode", ShippingPincode.Text);
    //    cmd.Parameters.AddWithValue("@ProductPrice", TotalPaypable.Text);
    //   cmd.Parameters.AddWithValue("@PaymentOption", "Online Payment");
    //    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
    //    if (cmd.ExecuteNonQuery() > 0)
    //    {
    //        cmd.CommandText = "insert into billingaddress(bFirstname,bMiddlename,bLastname,bEmail,bMobileno,bAddress,bCountry,bState,bCity,bPincode,bProductPrice,bPaymentOption,bDateTime) values(@bFirstname,@bMiddlename,@bLastname,@bEmail,@bMobileno,@bAddress,@bCountry,@bState,@bCity,@bPincode,@bProductPrice,@bPaymentOption,@bDateTime)";
    //        cmd.Parameters.AddWithValue("@bFirstname", BillingFirstname.Text);
    //        cmd.Parameters.AddWithValue("@bMiddlename", BillingMiddlename.Text);
    //        cmd.Parameters.AddWithValue("@bLastname", BillingLastname.Text);
    //        cmd.Parameters.AddWithValue("@bEmail", BillingEmail.Text);
    //        cmd.Parameters.AddWithValue("@bMobileno", BillingMobileno.Text);
    //        cmd.Parameters.AddWithValue("@bAddress", BillingAddress.Value);
    //        cmd.Parameters.AddWithValue("@bCountry", BillingCountry.SelectedItem);
    //        cmd.Parameters.AddWithValue("@bState", BillingState.SelectedItem);
    //        cmd.Parameters.AddWithValue("@bCity", BillingCity.SelectedItem);
    //        cmd.Parameters.AddWithValue("@bPincode", BillingPincode.Text);
    //        cmd.Parameters.AddWithValue("@bProductPrice", TotalPaypable.Text);
    //       cmd.Parameters.AddWithValue("@bPaymentOption", "Online Payment");
    //        cmd.Parameters.AddWithValue("@bDateTime", DateTime.Now);
    //        if (cmd.ExecuteNonQuery() > 0)
    //        {
    //            foreach (GridViewRow row in YourProducts.Rows)
    //            {
    //                int a = Convert.ToInt32(row.Cells[0].Text);
    //                string b = row.Cells[1].Text;
    //                string c = row.Cells[3].Text;
    //                //  string di = Session["Emails"].ToString();
    //                SavedCartDetails(a, b, c);
    //            }

    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Order Placed Successfully :) ')", true);
    //            Response.Redirect("UserOrder.aspx");
    //        }
    //        else
    //        {
    //            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);

    //        }
    //    }
    //    else
    //    {
    //        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);

    //    }
    //}

    //protected void BillingState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //        MySqlCommand cmd = new MySqlCommand();
    //        con.Open();
    //        cmd.Connection = con;
    //        int SId = Convert.ToInt32(BillingState.SelectedValue);
    //        MySqlDataAdapter adp = new MySqlDataAdapter("select * from City where StateId=" + SId, con);
    //        DataSet ds = new DataSet();
    //        adp.Fill(ds);
    //        BillingCity.DataSource = ds;
    //        BillingCity.DataTextField = "Cityname";
    //        BillingCity.DataValueField = "CityId";
    //        BillingCity.DataBind();
    //        BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
    //        if (BillingState.SelectedValue == "0")
    //        {
    //            BillingCity.Items.Clear();
    //            BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message.ToString());
    //    }
    //}



    //protected void BillingCountry_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //        MySqlCommand cmd = new MySqlCommand();
    //        con.Open();
    //        cmd.Connection = con;
    //        int cId = Convert.ToInt32(BillingCountry.SelectedValue);
    //        MySqlDataAdapter adp = new MySqlDataAdapter("select * from State where CountryId=" + cId, con);
    //        DataSet ds = new DataSet();
    //        adp.Fill(ds);
    //        BillingState.DataSource = ds;
    //        BillingState.DataTextField = "StateName";
    //        BillingState.DataValueField = "StateId";
    //        BillingState.DataBind();
    //        BillingState.Items.Insert(0, new ListItem("-- Select --", "0"));
    //        if (BillingCountry.SelectedValue == "0")
    //        {
    //            BillingState.Items.Clear();
    //            BillingState.Items.Insert(0, new ListItem("-- Select --", "0"));
    //            BillingCity.Items.Clear();
    //            BillingCity.Items.Insert(0, new ListItem("-- Select --", "0"));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message.ToString());
    //    }
    //}


    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //    ShippingFirstname.Text = BillingFirstname.Text;
    //    ShippingMiddlename.Text = BillingMiddlename.Text;
    //    ShippingLastname.Text = BillingLastname.Text;
    //    ShippingEmail.Text = BillingEmail.Text;
    //    ShippingMobileno.Text = BillingMobileno.Text;
    //    ShippingAddress.Value = BillingAddress.Value;
    //   // ShippingCountry.SelectedValue = BillingCountry.SelectedValue;
    //    //ShippingState.SelectedValue = BillingState.SelectedValue;
    //    //ShippingCity.SelectedValue = BillingCity.SelectedValue;
    //    ShippingPincode.Text = BillingPincode.Text;


    //}
    //public void SavedCartDetails(int a, string b, string c)
    //{
    //    try
    //    {

    //        string datainsert = "insert into purchaseproduct(ProductId,Productname,ProductPrice,Email,DateTime) values('" + a + "','" + b + "','" + c + "','" + Session["Emails"].ToString() + "','" + DateTime.Now + "')";
    //        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //        MySqlCommand cmd = new MySqlCommand();
    //        con.Open();
    //        cmd.CommandText = datainsert;
    //        cmd.Connection = con;
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.ToString());
    //    }
    //}

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


    protected void YourProducts_DataBound(object sender, EventArgs e)
    {
        //if (YourProducts.Rows.Count >= 1)
        //{
        //    rzpbutton1.Enabled = true;
        //}
        //else
        //{
        //    rzpbutton1.Enabled = false;
        //}
    }

    protected void YourProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
