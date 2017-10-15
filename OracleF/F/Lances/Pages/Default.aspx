<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lances.Pages.Default" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="DefaultPage" runat="server" ID="DefPage">
    <div style="text-align: center; width:100%;"><h3 class="page-header"> Информация о фурме </h3>
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate><table class="table  alert-info""></HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>№ Фурмы:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.lance_no")%> </td>
                        <td>№ конвертера: </td>
                        <td>МПК-<%# DataBinder.Eval(Container, "DataItem.cv_no")%> </td>
                        <td>МПК:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.mpk")%> </td>
                    </tr>
                    <tr>
                        <td>№ наконечника: </td>
                        <td><%# DataBinder.Eval(Container, "DataItem.tip_no")%>
                        <td>производитель наконечника:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.tip_comp")%></td>
                        <td>стойкость  наконечника:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Durability")%> </td>
                    </tr>
                    <tr>
                        <td>длина фурмы</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.lance_len")%> </td>
                        <td>установка и первая плавка:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.FirstHeat")%>&nbsp
                                <%# DataBinder.Eval(Container, "DataItem.DateInstall")%> </td>
                        <td>демонтаж и последняя плавка:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.LastHeat")%>&nbsp
                                <%# DataBinder.Eval(Container, "DataItem.DateDeinstall")%> </td>
                    </tr>
                    <tr>
                        <td>реперная метка:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.reper_label")%></td>
                        <td>Особые отметки:</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.spec_marks")%></td>
                        <td>Причина замены :</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.reason")%></td>
                    </tr>
                    <tr>
                        <td>Выполненные работы :</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Jobs")%></td>
                        <td>Износ сопел :</td>
                        <td><%# DataBinder.Eval(Container, "DataItem.Nozzle_wear")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:Repeater>
            <div>
                <div style="text-align: right; float:left;">
                    <button id="excelBut" type="button" style="left: -20px;" runat="server"
                        class="button" visible="false"> <%--onclick="ShowCurrentTime()">--%>
                        <span class="submit">в Excel</span>
                        <span class="loading"><i class="fa fa-refresh"></i></span>
                        <span class="check"><i class="fa fa-check"></i></span></button>
                    <a href="#" id="link" visible="false" runat="server">Скачать</a></div>    
                 <div style="text-align: left; float:right;">
                    <button type="button" id="all_but" class="button" style="right: -20px;" runat="server" >все</button></div>
            </div> 
            <asp:HyperLink runat="server" CssClass="btn btn-info" visible="false" ID="EditLink" NavigateUrl="#">
                Правка фурмы <%= Lance_num %></asp:HyperLink>
        </div>

        <asp:ValidationSummary ID="validationSummary" runat="server" ShowModelStateErrors="true" />
        <br />  
        
        <div>
            <table class="table table-striped table-hover">
                <tr class="info">
                    <td><label>№ Фурмы</label></td>
                    <td><input ID="Lance_no_input" name="Lance_no" type="text" class="form-control" runat="server"></td>
                    <td><asp:Button ID="RequestButton" runat="server" Text="Поиск" CssClass="btn btn-success"/></td>
                </tr>
            </table>
         <%--<input ID="First_blow_hiden" name="First_blow" runat="server" type="text" class="form-control" value="3706869" style="visibility:hidden">--%>
        </div>
        <%--<asp:Literal ID="literal" runat="server"></asp:Literal><br /> 
       <script src="js/index.js"></script>
        <script type="text/javascript">
            function ShowCurrentTime() {
                var dataValue = '{ number: "<%# Lance_num %>" }';
                $.ajax({
                    type: "POST",
                    url: "/Pages/Default.aspx/GetExcel",
                    data: dataValue,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: OnSuccess,
                });
                function OnSuccess(response) {
                    //alert(response.d);
                    $("#link").attr("style", "visibility:visible");
                    $("#link").attr("href", response.d);
                    $("#excelBut").css("pointer-events", "none");
                }
            }
        </script>--%>
    </div>    
</asp:Content>


