<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Index.aspx.cs" Inherits="Li.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>form2</title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>         
        </div>
        <asp:Button ID="Button1" runat="server" Text="新增主題" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="編號"  FooterStyle-BorderStyle="NotSet"><ItemTemplate><%# Container.DataItemIndex + 1%></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="主題" SortExpression="header">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("header") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("header") %>' NavigateUrl='<%# "Message_Main.aspx?id="+Eval("id") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="發表人" SortExpression="name" /> 
                <asp:BoundField DataField="initDate" HeaderText="留言日期" SortExpression="initDate" />
                <asp:TemplateField HeaderText="回應" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("回應") %>'></asp:Label>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="選取">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="select" Text="選取"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
