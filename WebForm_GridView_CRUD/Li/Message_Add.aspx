<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Add.aspx.cs" Inherits="Li.WebForm3" %>

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
       標題 <asp:TextBox ID="Message_Header" runat="server" required=" " aria-required ="true" 
           oninput="setCustomValidity('');" oninvalid="setCustomValidity('記得填寫標題喔')" ></asp:TextBox>
        <p>
        暱稱<asp:TextBox ID="Message_Name" runat="server"></asp:TextBox>
        </p>
        內容<asp:TextBox ID="Message_Main" runat="server" Height="477px" TextMode="MultiLine" Width="596px"></asp:TextBox>
        
        <br/>
        <br/>
        <br/>
        <p>
        <asp:Button ID="Confirm" runat="server" Text="確定留言" OnClick="Confirm_Click" />
        <input id="Reset1" type="reset" value="重新填寫" />
        </p>
    </form>
</body>
</html>
