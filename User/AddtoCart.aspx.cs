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

public partial class User_AddtoCart : System.Web.UI.Page
{
    static int UseID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
                UseID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
                lbluser.Text = "Hello : " + addr.User;
                // lbluser.Text = "Hello : " + ds.Tables[0].Rows[0]["Firstname"].ToString();
            }
            else
            {
                //lbluser.Text = "Hello : Guest";
                Response.Redirect("UserLogin.aspx");
            }
            BindProductCart();
            BindCartNumber();

        }

    }
    public void BindCartNumber()
    {
        if (Session["Emails"] != null)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            string UserIDD = Session["Emails"].ToString();
            
            DataTable dt = new DataTable();

            //MySqlCommand cmd = new MySqlCommand("SP_BindCartNumberz", con)
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblCart  where UseID = @UseID";
            //D CROSS APPLY(SELECT TOP 1 E.Name, Extention FROM tblProductImages E WHERE E.PID = D.PID) Name
            cmd.Parameters.AddWithValue("@UseID", UseID);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();

                // CartBadge.InnerText = CartQuantity;
                var SummaryContainer = (System.Web.UI.HtmlControls.HtmlGenericControl)Page.Master.FindControl("CartBadge");
                SummaryContainer.InnerText = CartQuantity;
            }
            else
            {
                // CartBadge.InnerText == 0.ToString();
                //CartBadge.InnerText = "0";
                var SummaryContainer = (System.Web.UI.HtmlControls.HtmlGenericControl)Page.Master.FindControl("CartBadge");
                SummaryContainer.InnerText = "0";
            }

        }

    }

    private void BindProductCart()
    {
        string UserIDD = Session["Emails"].ToString();

        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        //SqlCommand cmd = new SqlCommand("SP_BindUserCart", con)
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "SELECT tblCart.CartID,tblCart.UseID,tblCart.ProductId,tblCart.productName,tblCart.ProductPrice,tblCart.ProductPriceBeforeDiscount,tblCart.Qty,products.ProductImage1,products.ProductPrice,products.ProductPriceBeforeDiscount,products.ProductAvailability,products.ProductDescription,products.ShippingCharge FROM tblCart CROSS join products WHERE tblCart.ProductId = products.ProductId and UseID=@UseID";
        //D CROSS APPLY(SELECT TOP 1 E.Name, Extention FROM tblProductImages E WHERE E.PID = D.PID) Name
        cmd.Parameters.AddWithValue("@UseID", UseID);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        RptrCartProducts.DataSource = dt;
        RptrCartProducts.DataBind();
        if (RptrCartProducts.Items.Count <= 0)
        {
            Button1.Enabled = false;
        }

        //if (dt.Rows.Count > 0)
        //{
        //    string Total = dt.Compute("Sum(SubSAmount)", "").ToString();
        //    string CartTotal = dt.Compute("Sum(SubPAmount)", "").ToString();
        //    string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
        //    h4NoItems.InnerText = "My Cart ( " + CartQuantity + " Item(s) )";
        //    int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
        //    int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
        //    spanTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(Total)) + ".00";
        //    spanCartTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(CartTotal)) + ".00";
        //    spanDiscount.InnerText = "- Rs. " + (CartTotal1 - Total1).ToString() + ".00";
        //}
        //else
        //{
        //    h4NoItems.InnerText = "Your Shopping Cart is Empty.";
        //    divAmountSect.Visible = false;

        //}

    }

    protected void btnCart2_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("AddtoCart.aspx");
    }

    //protected void btnBuyNow_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("GetUserDetails.aspx");
    //}
    protected void RptrCartProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        //string UserID = Session["Emails"].ToString();
        ////This will add +1 to current quantity using PID
        //if (e.CommandName == "DoPlus")
        //{
        //    string PID = (e.CommandArgument.ToString());
        //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        //    MySqlCommand cmd = new MySqlCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "SELECT * FROM tblcart WHERE ProductId = @ProductId AND Email = @Email";
        //    cmd.Parameters.AddWithValue("@ProductId", PID);
        //    cmd.Parameters.AddWithValue("@Email", UserID);
        //    MySqlDataAdapter sda = new MySqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
        //        //   MySqlCommand myCmd = new MySqlCommand("UPDATE tblcart SET Qty=@Qty WHERE ProductId= @ProductId AND Email = @Email", con);
        //        MySqlCommand myCmd = new MySqlCommand();
        //        con.Open();
        //        myCmd.Connection = con;
        //        myCmd.CommandText = "UPDATE tblcart SET Qty=@Qty WHERE ProductId= @ProductId AND Email = @Email";
        //        myCmd.Parameters.AddWithValue("@Qty", updateQty + 1);
        //        myCmd.Parameters.AddWithValue("@ProductId", PID);
        //        myCmd.Parameters.AddWithValue("@Email", UserID);
        //        con.Open();
        //        Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
        //        con.Close();
        //        BindProductCart();
        //        BindCartNumber();
        //    }
        //}

        //else if (e.CommandName == "DoMinus")
        //{
        //    string PID = (e.CommandArgument.ToString());
        //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        //    MySqlCommand cmd = new MySqlCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "SELECT * FROM tblCart WHERE ProductId = @ProductId AND Email = @Email";
        //    cmd.Parameters.AddWithValue("@ProductId", PID);
        //    cmd.Parameters.AddWithValue("@Email", UserID);
        //    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        Int32 myQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
        //        if (myQty <= 1)
        //        {
        //            //divQtyError.Visible = true;
        //        }
        //        else
        //        {
        //            //MySqlCommand myCmd = new MySqlCommand("UPDATE tblCart SET Qty= @Qty WHERE ProductId= @ProductId AND Email = @Email", con);
        //            MySqlCommand myCmd = new MySqlCommand();
        //            con.Open();
        //            myCmd.Connection = con;
        //            myCmd.CommandText = "UPDATE tblCart SET Qty= @Qty WHERE ProductId= @ProductId AND Email = @Email";
        //            myCmd.Parameters.AddWithValue("@Qty", myQty - 1);
        //            myCmd.Parameters.AddWithValue("@ProductId", PID);
        //            myCmd.Parameters.AddWithValue("@Email", UserID);
        //            con.Open();
        //            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
        //            con.Close();
        //            BindProductCart();
        //            BindCartNumber();

        //        }
        //    }

        //}
        //else if (e.CommandName == "RemoveThisCart")
        //{
        //    int CartPID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
        //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        //    MySqlCommand myCmd = new MySqlCommand("DELETE FROM tblCart WHERE ProductId = @ProductId", con);
        //    myCmd.Parameters.AddWithValue("@ProductId", CartPID);
        //    con.Open();
        //    myCmd.ExecuteNonQuery();
        //    con.Close();
        //    BindProductCart();
        //    BindCartNumber();
        //}
        if (e.CommandName == "delete")
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM tblCart WHERE CartID = @CartID and UseID=@UseID";
            ////   SqlConnection SqlCnn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            //  SqlCommand SqlCmd = new SqlCommand("delete CPMEMBERS where id=@ID", SqlCnn);
            cmd.Parameters.Add("@CartID", MySqlDbType.VarChar).Value = e.CommandArgument;
            cmd.Parameters.AddWithValue("@UseID", UseID);
            try
            {

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            BindProductCart();
            BindCartNumber();

        }
    }

    //protected void btnRemoveCart_Click(object sender, EventArgs e)
    //{
    //    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    //    DataTable dt = new DataTable();
    //    MySqlCommand cmd = new MySqlCommand();
    //    con.Open();
    //    cmd.Connection = con;
    //    cmd.CommandText = "SELECT CartID FROM tblCart";
    //    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
    //    sda.Fill(dt);
    //    int pid = Convert.ToInt32(dt.Rows[0]["CartID"].ToString());
    //    MySqlCommand myCmd = new MySqlCommand("DELETE FROM tblCart WHERE CartID = @CartID and Email=@Email", con);
    //    myCmd.Parameters.AddWithValue("@CartID", pid);
    //    myCmd.Parameters.AddWithValue("@Email", Session["Emails"].ToString());
    //    myCmd.ExecuteNonQuery();
    //    con.Close();
    //    BindProductCart();
    //    BindCartNumber();
    //}

    public void TotalPayableAmount()
    {
        
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Application["Productsid"] = pids.Text;
        Application["TotalPrice"] = name.Text;
        //Response.Write("Hello");
        //string variable = hdnfldVariable.Value;
       // Console.WriteLine("hello");
     //   Session["totalPayment"] = spn.InnerText;
      Response.Redirect("GetUserDetails.aspx");
    }
}