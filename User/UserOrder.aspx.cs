using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        userorderdetails();
    }
    public void userorderdetails()
    {
        if (Session["Emails"] != null)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmdd = new MySqlCommand();
            cmdd.Connection = conn;
            conn.Open();
            cmdd.CommandText = "select * from userlogin where Email='" + Session["Emails"] + "'";
            MySqlDataAdapter daa = new MySqlDataAdapter(cmdd);
            DataSet ds = new DataSet();
            daa.Fill(ds);
            int UseID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
            conn.Close();
            cmdd.Dispose();

            string UserIDD = Session["Emails"].ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select distinct o.OID,o.ProductID,o.PaymentID,o.UID,o.DateTime,o.OrderStatus,p.productName,p.ProductCompany,p.ProductPriceBeforeDiscount,p.ProductDescription,p.ProductImage1 ,p.ProductId from orderdetails as o inner join products as p inner join userlogin as u on o.ProductID = p.ProductId where u.Email =@UID order by o.OID desc";
            cmd.Parameters.AddWithValue("@UID", UserIDD);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            UserOrderDetails.DataSource = dt;
            UserOrderDetails.DataBind();
            if (UserOrderDetails.Items.Count <= 0)
            {
                EmptyOrderDetails.Text = "Your Order History Empty :) ";
            }
        }
  
        else
        {
            Response.Redirect("UserLogin.aspx");
        }
    }
}