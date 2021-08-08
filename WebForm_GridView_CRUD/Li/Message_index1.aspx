<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_index1.aspx.cs" Inherits="Li.Message_index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>主題清單</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button1" runat="server" Text="新增主題" OnClick="Button1_Click" />
            <asp:Repeater ID="userRepeat" runat="server" OnItemCommand="userRepeat_ItemCommand" OnItemDataBound="userRepeat_ItemDataBound">
                <HeaderTemplate>
                    <table border="1" style="width: 1000px; text-align: center; border-collapse: collapse;">
                        <thead style="background-color: red;">
                            <tr>
                                <td>編號</td>
                                <td>主題</td>
                                <td>發表人</td>
                                <td>留言日期</td>
                                <td>回應</td>
                                <td>操作</td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server"><%# Container.ItemIndex +1 %></asp:Label></td>
                        <td>

                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("header")%>' NavigateUrl='<%# "Message_Main.aspx?id="+Eval("id") %>'></asp:HyperLink></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("initDate") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("回應") %>'></asp:Label></td>
                        <td>
                            <asp:LinkButton ID="lbtDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' runat="server" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;">刪除</asp:LinkButton>
                    </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>        
    </form>
</body>
</html>
