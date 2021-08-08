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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            string strConnectionName = "Message_boardConnectionString";
            string strConnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
            SqlConnection sqlstr = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand($"insert into message_board(header,name,main,initDate)values(@header,@name,@main,@initdate)",sqlstr);
            cmd.Parameters.Add("@header", SqlDbType.NVarChar);
            cmd.Parameters["@header"].Value = Message_Header.Text;
            cmd.Parameters.Add("@name",SqlDbType.NVarChar);
            cmd.Parameters["@name"].Value = Message_Name.Text;
            cmd.Parameters.Add("@main", SqlDbType.NVarChar);
            cmd.Parameters["@main"].Value = Message_Main.Text;
            cmd.Parameters.Add("@initdate", SqlDbType.DateTime);
            cmd.Parameters["@initdate"].Value = DateTime.Now.ToString();
            sqlstr.Open();
            cmd.ExecuteNonQuery();
            sqlstr.Close();
            Response.Redirect("Message_Index.aspx");
        }
    }
}