<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Main.aspx.cs" Inherits="Li.Message_Main" %>

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
        <h1>留言內容</h1>
        <br/>
        <asp:Button ID="Reply" runat="server" Text="回應文章" OnClick="Reply_Click" />
        <br/>
        <br/>
        主題 : <asp:Label ID="Message_header" runat="server" Text="Label"></asp:Label>
        <br/>
        發表人 : <asp:Label ID="Message_Name" runat="server" Text="Label"></asp:Label>
        <br/>
        發表時間 : <asp:Label ID="Message_Time" runat="server" Text="Label"></asp:Label>
        <br/>
        內容 : <asp:Label ID="Main" runat="server" Text="Label"></asp:Label>
        <br/>
        <h2>回覆留言</h2>
       
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <br/> <br/>
        <br/>
               暱稱 : <asp:Label ID="who" runat="server" Text='<%# Bind("name") %>' ></asp:Label>
                <br/>
                回應內容 : <asp:Label ID="repmain" runat="server" Text='<%# Bind("main") %>'></asp:Label>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
