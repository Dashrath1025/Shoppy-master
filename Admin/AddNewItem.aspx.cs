using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using System.IO;

public partial class Admin_AddNewItem : System.Web.UI.Page
{
    static int photoid;
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
        }
        if (!Page.IsPostBack)
        {
            CategoryDropdownlist();
           
            ShowProductData();
        }
    }
    public void ShowProductData()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select distinct p.ProductId,c.CategoryName,s.SubCategoryName,p.productName,p.ProductCompany,p.ProductPrice,p.ProductPriceBeforeDiscount,p.Discount,p.ProductDescription,p.ShippingCharge,p.ProductImage1,p.ProductImage2,p.ProductImage3,p.ProductAvailability,p.PostingDate from category as c inner join products as p inner join subcategory as s on p.CatID =c.Categoyid  and p.SubCatID =s.SubCategoryId ";
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ShowItemDetails.DataSource = dt;
        ShowItemDetails.DataBind();
        CountRow.Text = "Number of Item : " + ShowItemDetails.Rows.Count.ToString();
        con.Close();
        cmd.Dispose();
    }
   
    protected void Insert_Click(object sender, EventArgs e)
    {
        try
        {


            string str = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/UploadedImages/" + str));
            string Image = "~/UploadedImages/" + str.ToString();

            string str1 = FileUpload2.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/UploadedImages/" + str1));
            string Image1 = "~/UploadedImages/" + str.ToString();

            string str2 = FileUpload3.FileName;
            FileUpload3.PostedFile.SaveAs(Server.MapPath("~/UploadedImages/" + str2));
            string Image2 = "~/UploadedImages/" + str.ToString();



            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into products(CatID,SubCatID,productName,ProductCompany,ProductPrice,ProductPriceBeforeDiscount,Discount,ProductDescription,ShippingCharge,ProductImage1,ProductImage2,ProductImage3,ProductAvailability,PostingDate) values (@CatID,@SubCatID,@productName,@ProductCompany,@ProductPrice,@ProductPriceBeforeDiscount,@Discount,@ProductDescription,@ShippingCharge,@ProductImage1,@ProductImage2,@ProductImage3,@ProductAvailability,@PostingDate)";
            cmd.Parameters.AddWithValue("@CatID", DropCategory.SelectedIndex);
            cmd.Parameters.AddWithValue("@SubCatID", DropSubCategory.SelectedIndex);
            cmd.Parameters.AddWithValue("@productName", Productname.Text);
            cmd.Parameters.AddWithValue("@ProductCompany", ProductCompany.Text);
            cmd.Parameters.AddWithValue("@ProductPrice", ProductPriceBeofreDiscount.Text.Trim());
            cmd.Parameters.AddWithValue("@ProductPriceBeforeDiscount", ProductPriceAfterDiscount.Text);
            cmd.Parameters.AddWithValue("@Discount", Discount.Text);
            cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription.Value);
            cmd.Parameters.AddWithValue("@ShippingCharge", ProductShippingCharge.Text.Trim());
            cmd.Parameters.AddWithValue("@ProductImage1",Image );
            cmd.Parameters.AddWithValue("@ProductImage2", Image1);
            cmd.Parameters.AddWithValue("@ProductImage3", Image2);
            cmd.Parameters.AddWithValue("@ProductAvailability", ProductAvailability.Text.Trim());
            cmd.Parameters.AddWithValue("@PostingDate", DateTime.Now);
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Iten Has Been Added Successfully ', 'success');", true);
                ShowProductData();
                ResetData();
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            con.Close();
            cmd.Dispose();
        }
        catch (Exception)
        {
            //  lblMessage.ForeColor = System.Drawing.Color.Red;
            // lblMessage.Text = "Invalid username and password";
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
        }


    }


    protected void Reset_Click(object sender, EventArgs e)
    {
        ResetData();
    }
    public void ResetData()
    {
        DropCategory.ClearSelection();
        DropSubCategory.ClearSelection();
        Productname.Text = "";
        ProductCompany.Text = "";
        ProductPriceBeofreDiscount.Text = "";
        ProductPriceAfterDiscount.Text = "";
        Discount.Text = "";
        ProductDescription.Value = "";
        ProductShippingCharge.Text = "";
        ProductAvailability.Text = "";
        FileUpload1.Dispose();
        FileUpload2.Dispose();
        FileUpload3.Dispose();
    }
    public void CategoryDropdownlist()
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        con.Open();
        cmd.Connection = con;
        //MySqlDataAdapter adp = new MySqlDataAdapter("select * from category", con);
        //DataSet ds = new DataSet();
        //adp.Fill(ds);
        //DropCategory.DataSource = ds;
        //DropCategory.DataTextField = "CategoryName";
        //DropCategory.DataValueField = "Categoyid";
        //DropCategory.DataBind();
        //DropCategory.Items.Insert(0, new ListItem("-- Select --", "0"));
        MySqlDataAdapter adp = new MySqlDataAdapter("select * from category", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        DropCategory.DataSource = ds;
        DropCategory.DataTextField = "CategoryName";
        DropCategory.DataValueField = "Categoyid";
        DropCategory.DataBind();
        DropCategory.Items.Insert(0, new ListItem("-- Select --", "0"));
        DropSubCategory.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
    protected void DropCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            int SubId = Convert.ToInt32(DropCategory.SelectedValue);
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from subcategory where CategoryId=" + SubId, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DropSubCategory.DataSource = ds;
            DropSubCategory.DataTextField = "SubCategoryName";
            DropSubCategory.DataValueField = "SubCategoryId";
            DropSubCategory.DataBind();
            DropSubCategory.Items.Insert(0, new ListItem("-- Select --", "0"));
            if (DropCategory.SelectedValue == "0")
            {
                DropSubCategory.Items.Clear();
                DropSubCategory.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        try
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int categoryidds = Convert.ToInt32(ShowItemDetails.Rows[rowindex].Cells[1].Text);
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from products where ProductId=@ProductId";
            cmd.Parameters.AddWithValue("@ProductId", categoryidds);
            if (cmd.ExecuteNonQuery() > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Login successfully','success').then((value) => { window.location ='AdminLogin.aspx'; });", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Item Has Been Deleted Successfully ', 'success');", true);
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Invalid username and password";
                // this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done !', 'Your Category Has Been Updated Successfully ', 'success');", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
            }
            ShowProductData();
            con.Close();
            cmd.Dispose();
        }
        catch (Exception)
        {
            //  lblMessage.ForeColor = System.Drawing.Color.Red;
            // lblMessage.Text = "Invalid username and password";
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Something went wrong on the page!', 'error');", true);
        }
    }

    protected void ProductPriceAfterDiscount_TextChanged(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(ProductPriceBeofreDiscount.Text);

        int b = Convert.ToInt32(ProductPriceAfterDiscount.Text);

        int c = a - b;

        Discount.Text = Convert.ToString(c);
    }
}