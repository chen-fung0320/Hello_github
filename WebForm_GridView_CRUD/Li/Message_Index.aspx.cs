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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
            if (!IsPostBack)
            {
                string strConnectionName = "Message_boardConnectionString";
                string strConnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
                SqlConnection sqlstr = new SqlConnection(strConnection);
                sqlstr.Open();
                SqlDataAdapter sqladapter = new SqlDataAdapter("select *,(select count(messageID) from reply where reply.messageID = message_board.id) 回應 from message_board", sqlstr);
                DataSet ds = new DataSet();
                sqladapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                sqladapter.Dispose();
                ds.Dispose();
                sqlstr.Close();
            }
            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_Add.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string strConnectionString = "Message_boardConnectionString";
            string strconnection = ConfigurationManager.ConnectionStrings[strConnectionString].ConnectionString;
            SqlConnection sqlstr = new SqlConnection(strconnection);
            SqlCommand cmd = new SqlCommand($"delete from Message_board where id = @id", sqlstr);
            SqlCommand cmd_reply = new SqlCommand($"delete from reply where messageID = @id", sqlstr);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar);
            cmd.Parameters["@id"].Value = id;
            cmd_reply.Parameters.Add("@id", SqlDbType.NVarChar);
            cmd_reply.Parameters["@id"].Value = id;
            sqlstr.Open();
            cmd.ExecuteNonQuery();
            cmd_reply.ExecuteNonQuery();
            sqlstr.Close();
            Response.Redirect(Request.Url.ToString());
        }
    }
}