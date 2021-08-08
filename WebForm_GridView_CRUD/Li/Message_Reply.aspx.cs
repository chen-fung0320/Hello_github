using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Li
{
    public partial class Message_Reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strConnectionName = "Message_boardConnectionString";
                string strconnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
                SqlConnection sqlstr = new SqlConnection(strconnection);
                SqlCommand cmd = new SqlCommand($"select * from message_board where id=@id",sqlstr);
                cmd.Parameters.Add("@id", SqlDbType.NVarChar);
                cmd.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);
                sqlstr.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    Reply_Header.Text = "RE : " + read["header"].ToString();
                }
                sqlstr.Close();
                read.Close();
            }
        }

        protected void pass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Reply_Name.Text) && string.IsNullOrEmpty(Reply_Main.Text))
            {
                Message.Text = "請填名字跟內容";
            }
            else if (string.IsNullOrEmpty(Reply_Main.Text))
            {
                Message.Text = "請填內容";
            }
            else if (string.IsNullOrEmpty(Reply_Name.Text))
            {
                Message.Text = "請填名字";
            }
            else
            {
                string strConnectionName = "message_boardConnectionString";
                string strconnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
                SqlConnection sqlstr = new SqlConnection(strconnection);
                SqlCommand cmd = new SqlCommand($"insert into reply(messageID,name,main,initDate)values(@messageID,@name,@main,@initDate)", sqlstr);
                cmd.Parameters.Add("@messageID",SqlDbType.Int);
                cmd.Parameters["@messageID"].Value = Convert.ToInt32(Request.QueryString["id"]);
                cmd.Parameters.Add("@name",SqlDbType.NVarChar);
                cmd.Parameters["@name"].Value = Reply_Name.Text;
                cmd.Parameters.Add("@main",SqlDbType.NVarChar);
                cmd.Parameters["@main"].Value = Reply_Main.Text;
                cmd.Parameters.Add("@initDate",SqlDbType.DateTime);
                cmd.Parameters["@initDate"].Value = DateTime.Now.ToString();
                sqlstr.Open();
                cmd.ExecuteNonQuery();
                sqlstr.Close();
                Response.Redirect("Message_Main.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}