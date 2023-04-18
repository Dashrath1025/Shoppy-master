using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading;
using System.Data;

public partial class User_Charge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Emails"] != null)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmdd = new MySqlCommand();
            cmdd.Connection = conn;
            conn.Open();
            cmdd.CommandText = "select * from userlogin where Email='" + Session["Emails"] + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmdd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            cmdd.Dispose();

            string paymentId = Request.Form["razorpay_payment_id"];

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 10); // this amount should be same as transaction amount

            string key = "rzp_test_zRVtNrhYeKNpWu";
            string secret = "CLUFWCAonegVMsHoOGp6cEjx";

            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, string> attributes = new Dictionary<string, string>();

            attributes.Add("razorpay_payment_id", paymentId);
            attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

            Utils.verifyPaymentSignature(attributes);

            //             please use the below code to refund the payment 
            //             Refund refund = new Razorpay.Api.Payment((string) paymentId).Refund();

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into orderdetails(UID,ProductID,PaymentID,DateTime) values(@UID,@ProductID,@PaymentID,@DateTime)";
            cmd.Parameters.AddWithValue("@UID", Session["Useid"].ToString());
            cmd.Parameters.AddWithValue("@ProductID", Session["ProductID"].ToString());
            cmd.Parameters.AddWithValue("@PaymentID", paymentId);
            cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
            if (cmd.ExecuteNonQuery() > 0)
            {
                //Thread.Sleep(20);
               Response.Redirect("UserOrder.aspx");
            }
            con.Close();
            cmd.Dispose();
            // Console.WriteLine(paymentId);
        }
        else
        {
            //lbluser.Text = "Hello : Guest";
            Response.Redirect("UserLogin.aspx");
        }
    }
}