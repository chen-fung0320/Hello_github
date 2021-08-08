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
    public partial class Message_Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strConnectionName = "Message_boardConnectionString";
                string strConnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
                SqlConnection sqlstr = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand($"select * from message_board where id = @id",sqlstr);
                cmd.Parameters.Add("@id",SqlDbType.NVarChar);
                cmd.Parameters["@id"].Value = Request.QueryString["id"].ToString();
                sqlstr.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    Message_header.Text = read["header"].ToString();
                    Message_Name.Text = read["name"].ToString();
                    Message_Time.Text = read["initDate"].ToString();
                    Main.Text = read["main"].ToString();
                }
                read.Close();
                SqlCommand cmd_reply = new SqlCommand($"select name,main from reply where messageID = @id", sqlstr);
                cmd_reply.Parameters.Add("@id",SqlDbType.NVarChar);
                cmd_reply.Parameters["@id"].Value = Request.QueryString["id"];
                SqlDataReader reader = cmd_reply.ExecuteReader();
                Repeater1.DataSource = reader;
                Repeater1.DataBind();
                reader.Close();

                sqlstr.Close();
                 
            }
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_Reply.aspx?id="+Request.QueryString["id"]);
        }
    }
}