<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvailabilityLances.aspx.cs" Inherits="Lances.Pages.AvailabilityLances" MasterPageFile="~/Site.Master"%>

<asp:Content ContentPlaceHolderID="AvailabilityContent" runat="server">
    
    <table class="table table-striped table-hover" style="text-align:center">
        <thead>
            <tr>
                <td colspan="7" class="active">Наличие фурм</td>
            </tr>
            <tr>
                <td rowspan="2" class="info">№ фурмы</td>
                <td colspan="2" class="success">МПК-1</td>
                <td colspan="2" class="warning">МПК-2</td>
                <td colspan="2" class="danger">МПК-3</td>
            </tr>
            <tr>
                <td>левая</td><td>правая</td><td>левая</td>
                <td>правая</td><td>левая</td><td>правая</td>
            </tr>
        </thead>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
                <tr style="text-align:center;">
                    <td><%# DataBinder.Eval(Container, "DataItem.Lance_no")%></td>
                    <td class="<%# DataBinder.Eval(Container, "DataItem.Position[0]")%>"></td>
                    <td class="<%# DataBinder.Eval(Container, "DataItem.Position[1]")%>"></td>
                    <td class="<%# DataBinder.Eval(Container, "DataItem.Position[2]")%>"></td>
                    <td class="<%# DataBinder.Eval(Container, "DataItem.Position[3]")%>"></td>
                    <td class="<%# DataBinder.Eval(Container, "DataItem.Position[4]")%>"></td>
                    <td class="<%# DataBinder.Eval(Container, "DataItem.Position[5]")%>"></td>
                </tr>
        </ItemTemplate>
    </asp:Repeater> 
    </table>
</asp:Content>