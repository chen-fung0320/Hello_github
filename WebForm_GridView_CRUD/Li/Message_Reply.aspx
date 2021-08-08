<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Reply.aspx.cs" Inherits="Li.Message_Reply" %>

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
        <h1>回應留言</h1>
        標題 : <asp:TextBox ID="Reply_Header" runat="server"></asp:TextBox>
        <p>
        暱稱 : <asp:TextBox ID="Reply_Name" runat="server"></asp:TextBox>
        </p>
        內容 : <asp:TextBox ID="Reply_Main" runat="server" TextMode="MultiLine"  ></asp:TextBox>
        <br/>
        <asp:Button ID="pass" runat="server" Text="確定回應" OnClick="pass_Click" />
        <input id="Reset1" type="reset" value="reset" />
        <asp:Label ID="Message" runat="server" Text="" ForeColor="red"></asp:Label>

    </form>
</body>
</html>
