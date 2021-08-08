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
    public partial class Fileupload : System.Web.UI.Page
    {
        static string strConnectionName = "";//webconfig裡connectionstring的name
        private string strConnection = ConfigurationManager.ConnectionStrings[strConnectionName].ConnectionString;
        string MessageID = "" ; //session  或 cookie
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                SubmitFile(MessageID, FileUpload1.PostedFiles);
                Label1.Text = "檔案上傳完成";
            }
        }
        protected void SubmitFile(string MessageID, IList<HttpPostedFile> FileList)//上傳檔案及回傳檔案清單
        {
            using (SqlConnection nowConnection = new SqlConnection(strConnection))
            {
                nowConnection.Open();//開啟連線
                foreach (HttpPostedFile postedFile in FileList)
                {
                    String saveDir = @"\FileUpload\";
                    //String saveDir= "\\FileUpload\\";
                    String appPath = Request.PhysicalApplicationPath;//根目錄之實體路徑
                    String fileName, checkPath;
                    fileName = postedFile.FileName;
                    string tempfileName = fileName;
                    checkPath = appPath + saveDir + fileName;
                    if (System.IO.File.Exists(checkPath))//避免檔案重複儲存
                    {
                        int counter = 2;
                        while (System.IO.File.Exists(checkPath))
                        {
                            tempfileName = "(" + counter.ToString() + ")" + fileName;
                            checkPath = appPath + saveDir + tempfileName;
                            counter = counter + 1;
                        }
                        fileName = tempfileName;
                    }
                    string filePathName = appPath + saveDir + tempfileName;
                    postedFile.SaveAs(filePathName);
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.Clear();//清空參數
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = MessageID;
                        command.Parameters.AddWithValue("@FILENAME", postedFile.FileName);
                        command.Parameters.AddWithValue("@FILEPATH", filePathName);
                        command.CommandText = @"insert into Files(MessageID,FileName,FilePath)
                                        values(@ID,@FILENAME,@FILEPATH)";
                        command.Connection = nowConnection;//資料庫連接
                        command.ExecuteNonQuery();
                    }
                }

            }

        }
    }
}