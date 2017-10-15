<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetalHoses.aspx.cs" Inherits="Lances.Pages.MetalHoses" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MetalHosesContent" runat="server">
    <div style="text-align: center;">     
    <h3 class="page-header"> Информация о металлорукаве </h3>
    <div >
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <table class="table  alert-warning"">
                    <tr>
                        <td>№ Рукава:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Hose_no")%> </td>
                        <td>№ конвертера: </td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Cv_no")%> </td>
                        <td>МПК: </td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Mpk")%> </td>
                    </tr><tr>
                        <td> Бригада </td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Team")%> 
                        <td>Тип рукава:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Kind")%></td>
                        <td>стойкость  рукава:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Durability")%> </td>
                    </tr><tr>
                        <td>дата установки:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.DateInstall")%> </td>
                        <td>дата демонтажа:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.DateDeinstall")%> </td>
                    </tr><tr>
                        <td>Выполненые работы:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Jobs")%></td>
                        <td>Причина замены :</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Reason")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <asp:HyperLink runat="server" CssClass="btn btn-info" 
            visible="false" ID="EditLink" NavigateUrl="#">Правка рукава <%= Hose_num %></asp:HyperLink>
    </div>
    <asp:ValidationSummary ID="validationSummary" runat="server" ShowModelStateErrors="true" />
    <br />    
    <div>
        <table class="table table-striped table-hover">
                <tr class="warning">
                    <td><label>№ Рукава</label></td>
                    <td><input ID="Hose_no_input" name="Hose_no" type="text" class="form-control" runat="server"></td>
                    <td><asp:Button ID="RequestButton" runat="server" Text="Поиск" CssClass="btn btn-success"/></td>
                </tr>
        </table>
        <%--<input ID="First_blow_hiden" name="First_blow" runat="server" type="text" class="form-control" value="3706869" style="visibility:hidden">--%>
    </div>     
</div>
</asp:Content>