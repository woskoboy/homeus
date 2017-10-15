<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <table class="auto-style1">
                    <tr>
                        <td width="100" colspan="2">
                            <%# DataBinder.Eval(Container, "DataItem.Name")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%# DataBinder.Eval(Container, "DataItem.LastName")%>
                        </td>
                        <td width="150">
                            <%# DataBinder.Eval(Container, "DataItem.Age")%>
                        </td>
                    </tr>
                      </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
