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

public partial class User_Payment : System.Web.UI.Page
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


        //if (!Page.IsPostBack) { 
        //string payableAmount = Session["UserPayment"].ToString();
            //  Console.WriteLine(payableAmount);
            //  var a= (int.Parse(Session["UserPayment"].ToString()));
            // Response.Write(Label1.Text);
            //int payableAmount;
            //if (Int32.TryParse(Label1.Text.Trim(),out payableAmount))
            // int a = Convert.ToInt32(payableAmount);
            // Console.WriteLine(a.GetType());
            // Console.WriteLine(Convert.ToInt32(payableAmount).GetType());
            // Response.Write(Convert.ToInt32(payableAmount));
            // if(result)
            //{ 
      //  }
       
           // }
    }
    public void Bindgroiddata()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select tblcart.ProductId,tblcart.productName,tblcart.ProductPriceBeforeDiscount,products.ProductId,products.ProductImage1 from tblcart inner join products WHERE tblCart.ProductId = products.ProductId and UseID = '"+ Session["UID"]+"'";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        //YourProducts.DataSource = dt;
       // YourProducts.DataBind();
        string totalprice = dt.Tables[0].Rows[0]["ProductPriceBeforeDiscount"].ToString();
        //TotalPaypables.Text = totalprice;
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
        //for (int i = 0; i < YourProducts.Rows.Count - 1; i++)
        //{
        //    int a = Convert.ToInt32(dt.Tables[0].Rows[0]["ProductId"].ToString());
        //    string b = dt.Tables[0].Rows[0]["productName"].ToString();
        //    string c = dt.Tables[0].Rows[0]["ProductPriceBeforeDiscount"].ToString();
        //    SavedCartDetails(Convert.ToInt32(YourProducts.Rows[i].Cells[0].Text), YourProducts.Rows[i].Cells[1].Text, YourProducts.Rows[i].Cells[2].Text);
        //    CountRow.Text = "No. of Product : " + YourProducts.Rows.Count.ToString();
        //}
    }

    protected void YourProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void YourProducts_DataBound(object sender, EventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    // Display the company name in italics.
        //    e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";

        //}
        
    }
}