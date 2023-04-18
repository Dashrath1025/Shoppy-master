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

public partial class User_UserProductDetails : System.Web.UI.Page
{
    readonly Int32 myQty = 1;
    static int UseID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
                DataTable dt = new DataTable();
                da.Fill(ds);
                MailAddress addr = new MailAddress(ds.Tables[0].Rows[0]["Email"].ToString());
                UseID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
                
                lbluser.Text = "Hello : " + addr.User;
               
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
                UserProductDescription();
                BindCartNumber();
                UserRatingView();
                BindCartNumbesr();
            }
            else
            {
                lbluser.Text = "Hello : Guest";
                //  Response.Redirect("UserLogin.aspx");
                //Response.Redirect("UserMainPage.aspx");
            }


        }
    }
    public void BindCartNumbesr()
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
    private void UserProductDescription()
    {

        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from products  where ProductId=@ProductId";
        cmd.Parameters.AddWithValue("@ProductId", Request.QueryString["PID"]);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ProductDescriptionData.DataSource = dt;
        ProductDescriptionData.DataBind();
        Session["CartPID"] = Convert.ToInt32(dt.Rows[0]["ProductId"].ToString());
        Session["myPName"] = dt.Rows[0]["productName"].ToString();
        Session["myPPrice"] = dt.Rows[0]["ProductPrice"].ToString();
        Session["myPSelPrice"] = dt.Rows[0]["ProductPriceBeforeDiscount"].ToString();

    }
    private void UserRatingView()
    {

        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select * from ratingview  where PID=@PID";
        cmd.Parameters.AddWithValue("@PID", Request.QueryString["PID"]);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }

    protected void SaveRating_Click(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "insert into ratingview(PID,Uname,Email,Description,Rating,RatingDate)values(@PID,@Uname,@Email,@Description,@Rating,@RatingDate)";
        cmd.Parameters.AddWithValue("@PID", Request.QueryString["PID"]);
        cmd.Parameters.AddWithValue("@Uname", TxtName.Text);
        cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
        cmd.Parameters.AddWithValue("@Description", TxtReview.Value);
        cmd.Parameters.AddWithValue("@Rating", Rating.Text);
        cmd.Parameters.AddWithValue("@RatingDate", DateTime.Now);
        if (cmd.ExecuteNonQuery() > 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Review Has Been Added Successfully ', 'success');", true);
            UserRatingView();
            resetdata();
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
        }
        con.Close();
        cmd.Dispose();

    }
    public void resetdata()
    {
        TxtName.Text = "";
        TxtEmail.Text = "";
        TxtReview.Value = "";
        Rating.Text = "";

    }

    protected void BtnAddtoCart_Click(object sender, EventArgs e)
    {
        //if(Session["Emails"] != null)
        //{
        //    Response.Redirect("AddtoCart.aspx?PID=" + Request.QueryString["PID"].ToString());
        //}
        //else
        //{
        //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Login Please!', 'error');", true);

        //}
        if (Session["Emails"] != null)
        {
            string UserID = Session["Emails"].ToString();
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblCart where ProductId= @ProductId and UseID = @UseID";
            cmd.Parameters.AddWithValue("@ProductId", PID);
            cmd.Parameters.AddWithValue("@UseID", UseID);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                //MySqlCommand myCmd = new MySqlCommand("SP_UpdateCart", con)
                //{
                //    CommandType = CommandType.StoredProcedure
                //};

                //MySqlCommand myCmd = new MySqlCommand();
                //myCmd.Connection = con;
                //myCmd.CommandText = "UPDATE tblcart SET Qty = @Qty WHERE ProductId = @ProductId AND Email = @Email";
                //myCmd.Parameters.AddWithValue("@Qty", updateQty + 1);
                //myCmd.Parameters.AddWithValue("@ProductId", PID);
                //myCmd.Parameters.AddWithValue("@Email", UserID);
                //Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                //con.Close();
                //BindCartNumber();
                //divSuccess.Visible = true;MySqlCommand myCmd = new MySqlCommand("insert into tblCart(Email,ProductId,productName,ProductPrice,ProductPriceBeforeDiscount,Qty) VALUES(@Email,@ProductId,@productName,@ProductPrice,@ProductPriceBeforeDiscount,@Qty)", con);
                MySqlCommand myCmd = new MySqlCommand("insert into tblCart(UseID,ProductId,productName,ProductPrice,ProductPriceBeforeDiscount,Qty) VALUES(@UseID,@ProductId,@productName,@ProductPrice,@ProductPriceBeforeDiscount,@Qty)", con);
                myCmd.Parameters.AddWithValue("@UseID", UseID);
                myCmd.Parameters.AddWithValue("@ProductId", Session["CartPID"].ToString());
                myCmd.Parameters.AddWithValue("@productName", Session["myPName"].ToString());
                myCmd.Parameters.AddWithValue("@ProductPrice", Session["myPPrice"].ToString());
                myCmd.Parameters.AddWithValue("@ProductPriceBeforeDiscount", Session["myPSelPrice"].ToString());
                myCmd.Parameters.AddWithValue("@Qty", myQty);
                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your product Has Been Added in to The Cart ', 'success');", true);
                Response.Redirect("../User/AddtoCart.aspx");
                con.Close();
                BindCartNumber();
            }
            else
            {
                MySqlCommand myCmd = new MySqlCommand("insert into tblCart(UseID,ProductId,productName,ProductPrice,ProductPriceBeforeDiscount,Qty) VALUES(@UseID,@ProductId,@productName,@ProductPrice,@ProductPriceBeforeDiscount,@Qty)", con);
                myCmd.Parameters.AddWithValue("@UseID", UseID);
                myCmd.Parameters.AddWithValue("@ProductId", Session["CartPID"].ToString());
                myCmd.Parameters.AddWithValue("@productName", Session["myPName"].ToString());
                myCmd.Parameters.AddWithValue("@ProductPrice", Session["myPPrice"].ToString());
                myCmd.Parameters.AddWithValue("@ProductPriceBeforeDiscount", Session["myPSelPrice"].ToString());
                myCmd.Parameters.AddWithValue("@Qty", myQty);
                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your product Has Been Added in to The Cart ', 'success');", true);
                con.Close();
                BindCartNumber();
                //  divSuccess.Visible = true;
            }


        }
        else
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            Response.Redirect("UserLogin.aspx?rurl=" + PID);
        }
    }
    public void BindCartNumber()
    {
        if (Session["Emails"] != null)
        {
            string UserIDD = Session["Emails"].ToString();
         
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select u.Email,t.UseID,t.Qty from userlogin as u inner join tblcart as t on u.UserID = t.UseID where u.Email = @Email";
            cmd.Parameters.AddWithValue("@Email", UserIDD);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                //CartBadge.InnerText = CartQuantity;

            }
            else
            {
                //CartBadge.InnerText = 0.ToString();
            }
        }
    }

    protected void btnCart2_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("AddtoCart.aspx");
    }
}
