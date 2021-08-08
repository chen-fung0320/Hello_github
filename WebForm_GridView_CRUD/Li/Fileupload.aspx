<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fileupload.aspx.cs" Inherits="Li.Fileupload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br/>
        <asp:Button ID="Button1" runat="server" Text="確定上傳" OnClick="Button1_Click" />
        <br/>
        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
    </form>
</body>
</html>
