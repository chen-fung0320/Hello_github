using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Li
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
            TextBox2.TextMode=TextBoxMode.Password;
            if (!IsPostBack)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                if (Request.Cookies["user"] != null)
                {
                    TextBox1.Text = Request.Cookies["user"].Value.ToString();
                }
            }
            if (Request.Cookies["count"] == null)
            {
                Response.Cookies["count"].Value = "1";
            }
            else
            {
                Response.Cookies["count"].Value =
                    Convert.ToString(int.Parse(Request.Cookies["count"].Value) + 1);
            }
            Response.Cookies["count"].Expires = DateTime.Now.AddMinutes(5);
            Response.Write("歡迎光臨!!您是第");
            Response.Write(Response.Cookies["count"].Value);
            Response.Write("次參觀本站");
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text == "123") && (TextBox2.Text == "321"))
            {
                TextBox1.Text = " ";
                TextBox2.Text = " ";
                Response.Cookies["user"].Value = TextBox1.Text.ToString();
                Response.Cookies["user"].Expires = DateTime.Now.AddSeconds(50);
                Response.Redirect("WebForm2.aspx?name=" + TextBox1.Text);
               // Response.Write("<script>window.location='WebForm2.aspx?name=" +TextBox1.Text + "'</script>");
              // Response.Write("<script>window.open('WebForm2.aspx?name="+ TextBox1.Text +"','_blank')</script>");//保留現有視窗，開啟新頁面
            }
            else
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                Label3.Text = "輸入錯誤";
            }
            //Response.Redirect("Webform2.aspx");
           // Response.Write("<script>window.location='WebForm2.aspx'</script>");//以原頁面直接開啟網址
                                                                               
            
        }

        
        //private void view()
        //{
        //    string strConnectionName = "ConnectionString";//欲取得的連接字串名稱
        //    string strConnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
        //    SqlConnection sqlstr = new SqlConnection(strConnection);
        //    sqlstr.Open();
         //  SqlCommand cmd = new SqlCommand($"Select * from Student_Management", sqlstr);
        //    SqlDataReader dataread = cmd.ExecuteReader();
        //    GridView1.DataSource = dataread;
        //    GridView1.DataBind();
        //    sqlstr.Close();

        //}


    }
}