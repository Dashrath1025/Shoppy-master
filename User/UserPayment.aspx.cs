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

public partial class User_UserPayment : System.Web.UI.Page
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
            cmd.CommandText = "select * from userlogin where Email='" + Session["Emails"] + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
           int UseID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
            con.Close();
            cmd.Dispose();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmdd = new MySqlCommand();
            cmdd.Connection = conn;
            conn.Open();
            cmdd.CommandText = "select tblcart.ProductId,tblcart.productName,tblcart.ProductPriceBeforeDiscount,products.ProductId,products.ProductImage1,products.ProductDescription,products.ProductCompany from tblcart inner join products WHERE tblCart.ProductId = products.ProductId and UseID = '" + Session["UID"] + "'";
            MySqlDataAdapter daa = new MySqlDataAdapter(cmdd);
            DataSet dt = new DataSet();
            daa.Fill(dt);
            PaymentDetails.DataSource = dt;
            PaymentDetails.DataBind();
            string totalprice = dt.Tables[0].Rows[0]["ProductPriceBeforeDiscount"].ToString();
            int ProductID = Convert.ToInt32(dt.Tables[0].Rows[0]["ProductId"].ToString());
            //TotalPaypables.Text = totalprice;s
            //TotalPaypable.Text = totalprice;
            //Label1.Text = Session["UserPayment"].ToString();

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

            Session["Useid"] = UseID;
            Session["ProductID"] = ProductID;
            
            //BillingFirstname.Text = ds.Tables[0].Rows[0]["Firstname"].ToString();
            //BillingMiddlename.Text = ds.Tables[0].Rows[0]["Middlename"].ToString();
            //BillingLastname.Text = ds.Tables[0].Rows[0]["Lastname"].ToString();
            //BillingEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            //BillingMobileno.Text = ds.Tables[0].Rows[0]["Mobileno"].ToString();
            //BillingAddress.Value = ds.Tables[0].Rows[0]["Street"].ToString();
            ////string bindbilingcountry = ds.Tables[0].Rows[0]["Country"];
            ////BillingCountry.SelectedValue = bindbilingcountry;
            //BillingPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

            // Bindgroiddata();

            //    TextBox1.Text = Application["Productsid"].ToString();

            //Dictionary<string, object> input = new Dictionary<string, object>();
            ////input.Add("amount", (Convert.ToInt32(payableAmount)*100)); // this amount should be same as transaction amount
            //input.Add("amount", 100); // this amount should be same as transaction amount
            //input.Add("currency", "INR");
            //input.Add("receipt", "1121");
            //input.Add("payment_capture", 1);

            //string key = "rzp_test_zRVtNrhYeKNpWu";
            //string secret = "CLUFWCAonegVMsHoOGp6cEjx";

            //RazorpayClient client = new RazorpayClient(key, secret);

            //Razorpay.Api.Order order = client.Order.Create(input);
            //orderId = order["id"].ToString();

        }
        else
        {
            //lbluser.Text = "Hello : Guest";
            Response.Redirect("UserLogin.aspx");
        }

    }
    //public void Bindgroiddata()
    //{
    //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //    MySqlCommand cmd = new MySqlCommand();
    //    cmd.Connection = con;
    //    con.Open();
    //    cmd.CommandText = "select tblcart.ProductId,tblcart.productName,tblcart.ProductPriceBeforeDiscount,products.ProductId,products.ProductImage1 from tblcart inner join products WHERE tblCart.ProductId = products.ProductId and UseID = '" + Session["UID"] + "'";
    //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
    //    DataSet dt = new DataSet();
    //    da.Fill(dt);
    //    YourProducts.DataSource = dt;
    //    YourProducts.DataBind();
    //    string totalprice = dt.Tables[0].Rows[0]["ProductPriceBeforeDiscount"].ToString();
    //    TotalPaypables.Text = totalprice;
    //    TotalPaypable.Text = totalprice;
    //    Label1.Text = Session["UserPayment"].ToString();

    //    Dictionary<string, object> input = new Dictionary<string, object>();
    //    input.Add("amount", (Convert.ToInt32(totalprice)) * 100); // this amount should be same as transaction amount
    //    input.Add("currency", "INR");
    //    input.Add("receipt", "1121");
    //    input.Add("payment_capture", 1);

    //    string key = "rzp_test_zRVtNrhYeKNpWu";
    //    string secret = "CLUFWCAonegVMsHoOGp6cEjx";

    //    RazorpayClient client = new RazorpayClient(key, secret);

    //    Razorpay.Api.Order order = client.Order.Create(input);
    //    orderId = order["id"].ToString();

    //}
    //protected void YourProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //}

    //protected void YourProducts_DataBound(object sender, EventArgs e)
    //{


    //}

}