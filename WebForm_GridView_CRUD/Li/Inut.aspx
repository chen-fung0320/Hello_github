<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inut.aspx.cs" Inherits="Li.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>form1</title>
    <script>
        
    </script>
</head>
<body>
    <form id="form1" runat="server" method ="get">
        <div>
           
        </div>
        <asp:Label ID="Label1" runat="server" >帳號</asp:Label>
         <asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" >密碼</asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" > </asp:Label>
            <br/>
        <asp:Button ID="Button1" runat="server" Text="登入" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="測試" OnClick="Button2_Click" />
        <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
        <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
    </form>
</body>
</html>
