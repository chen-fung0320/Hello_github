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
    public partial class Message_index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindToRepeater();
            }
        }
        private void DataBindToRepeater()
        {
            //使用using語句進行數據庫連接 
            string strConnectionName = "Message_boardConnectionString";
            string strconnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(strconnection))
            {
                sqlCon.Open(); //打開數據庫連接 

                SqlCommand sqlcom = new SqlCommand();  //創建數據庫命令對象 
                sqlcom.CommandText = "select *,(select count(*) from reply where message_board.id = reply.messageID) 回應 from message_board"; //為命令對象指定執行語句 
                sqlcom.Connection = sqlCon; //為命令對象指定連接對象 

                this.userRepeat.DataSource = sqlcom.ExecuteReader();  //為Repeater對象指定數據源 
                this.userRepeat.DataBind(); //綁定數據源 
            }
        }
        protected void userRepeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //獲取命令文本，判斷發出的命令為何種類型，根據命令類型調用事件 

            int id = int.Parse(e.CommandArgument.ToString());  //獲取刪除行的ID號 
                                                               //刪除選定的行，並重新指定綁定操作 
            this.DeleteRepeater(id);


            //重新綁定控件上的內容 
            this.DataBindToRepeater();
        }
        private void DeleteRepeater(int intId)
        {
            string strConnectionName = "Message_boardConnectionString";
            string strconnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(strconnection))
            {
                sqlCon.Open(); //打開數據庫連接 

                SqlCommand sqlcom = new SqlCommand();  //創建數據庫命令對象 
                sqlcom.CommandText = "delete from message_board where id=@id"; //為命令對象指定執行語句 
                sqlcom.Connection = sqlCon; //為命令對象指定連接對象 

                //創建參數集合,並向sqlcom中添加參數集合 


                sqlcom.Parameters.Add("@id", SqlDbType.NVarChar);
                sqlcom.Parameters["@id"].Value = intId;
                sqlcom.ExecuteNonQuery();  //指定更新語句 

            }
        }

        protected void userRepeat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判斷Repeater控件中的數據是否是綁定的數據源，如果是的話將會驗證是否進行了編輯操作 
            //ListItemType 枚舉表示在一個列表控件可以包括，例如 DataGrid、 DataList和 Repeater 控件的不同項目。  
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //獲取綁定的數據源，這裏要註意上面使用sqlReader的方法來綁定數據源，所以下面使用的DbDataRecord方法獲取的 
                //如果綁定數據源是DataTable類型的使用下面的語句就會報錯. 
                System.Data.Common.DbDataRecord record = (System.Data.Common.DbDataRecord)e.Item.DataItem;
                //DataTable類型的數據源驗證方式 
                //System.Data.DataRowView record = (DataRowView)e.Item.DataItem; 
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_Add.aspx");
        }
    }
}