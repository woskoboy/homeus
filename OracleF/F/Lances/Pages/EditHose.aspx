<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditHose.aspx.cs" Inherits="Lances.Pages.EditHose" MasterPageFile="~/Site.Master" %>
<asp:Content ContentPlaceHolderID="EditHosesContent" ID="HosesEditPage" runat="server">
<div id="EditTableDiv" runat="server" style="text-align:center">
        <h4>Для рукава <input runat="server" readonly="readonly" ID="Hose_no"/></h4>
        <table id="MainProperty" class="table table-striped table-hover">
            <thead><tr><th class="warning">Причина замены</th><th class="success">Выполненные работы</th><th class="danger">Стойкость общая</th></tr>
            </thead>
            <tbody>
                <tr>
                    <td class="warning">
                        <asp:DropDownList ID="DL_Reasons" runat="server" multiple="multiple" class="form-control"> 
                            <%--AutoPostBack="true" OnSelectedIndexChanged="DL_Reasons_SelectedIndexChanged"--%>
                            <asp:ListItem value="причина1">причина1</asp:ListItem>
                            <asp:ListItem value="причина2">причина2</asp:ListItem>
                            <asp:ListItem value="причина3">причина3</asp:ListItem>
                        </asp:DropDownList></td>
                    <td class="success">
                        <asp:DropDownList runat="server" ID="DL_Jobs" multiple="multiple" class="form-control">
                        <%--AutoPostBack="true" OnSelectedIndexChanged="DL_Jobs_SelectedIndexChanged"--%>
                        <asp:ListItem value="работа1">работа1</asp:ListItem>
                        <asp:ListItem value="работа2">работа2</asp:ListItem>
                        <asp:ListItem value="работа3">работа3</asp:ListItem>
                        <asp:ListItem value="работа4">работа4</asp:ListItem>
                        </asp:DropDownList></td>
                    <td id="durability" class="danger">
                        <div><asp:Literal ID="DurabilityControl" runat="server"></asp:Literal></div>
                        Ручной ввод:</td></tr>
                <tr>
                    <td class="warning">
                        <textarea id="Reason" rows="2" runat="server" ClientIDMode="Static"
                            style="width: 100%" class="form-control"></textarea></td>
                    <td class="success">
                        <textarea id="Jobs" rows="2" runat="server"  ClientIDMode="Static"
                            style="width: 100%" class="form-control"></textarea></td>
                    <td class="danger"><input id="Durability" class="form-control" runat="server"></td>
                </tr>
            </tbody>
        </table>

        <table class="table table-striped table-hover">
            <thead><tr><td>№ конвертера</td><td>МПК</td><td>Тип</td><td>Бригада</td></tr></thead>
            <tbody><tr>
                <td><select id=Cv_no runat="server" class="form-control">
                        <option value=""></option>
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                    </select></td>
                <td><select id=Mpk runat="server" class="form-control">
                        <option value=""></option>
                        <option value="левая">левая</option>
                        <option value="правая">правая</option>
                    </select></td>
                <td><select id="Kind" runat="server" class="form-control">
                        <option value=""></option>
                        <option value="кислородный">кислородный</option>
                        <option value="напорный">напорный</option>
                        <option value="сливной">сливной</option>
                    </select></td>
                <td><input id=Team runat="server" class="form-control" /></td>
            </tr></tbody>
        </table>

        <table class="table table-striped table-hover">
            <tr><td>Дата монтажа</td>
                <td><div class="bootstrap-iso">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="form-group ">
                                        <div class="col-sm-10">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <input class="form-control" id="DateInstall" name="DateInstall" placeholder="Д/М/Г" 
                                                    style="width:100px">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-10 col-sm-offset-2">
                                            <input name="_honey" style="display: none" type="text">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div></td>
                <td>Дата демонтажа</td>
                <td>
                    <div class="bootstrap-iso">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="form-group ">
                                        <div class="col-sm-10">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <input class="form-control" style="width:100px"
                                                    id="DateDeinstall" name="DateDeinstall" placeholder="Д/М/Г">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-10 col-sm-offset-2">
                                            <input name="_honey" style="display: none" type="text">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </td></tr>
        </table>

        <table class="table alert-warning">
            <thead><tr><td colspan="8">Стойкость вставок</td></tr>
                <tr><td>1</td><td>2</td><td>3</td><td>4</td>
                <td>5</td><td>6</td><td>7</td><td>8</td>
                </tr></thead>
            <tbody><tr>
                <td><input id=Part1 runat="server" class="form-control" /></td>
                <td><input id=Part2 runat="server" class="form-control" /></td>
                <td><input id=Part3 runat="server" class="form-control" /></td>
                <td><input id=Part4 runat="server" class="form-control" /></td>
                <td><input id=Part5 runat="server" class="form-control" /></td>
                <td><input id=Part6 runat="server" class="form-control" /></td>
                <td><input id=Part7 runat="server" class="form-control" /></td>
                <td><input id=Part8 runat="server" class="form-control" /></td></tr>
           </tbody>
        </table>
    <br /><asp:Button class="btn btn-danger" id="SaveEditButton" runat="server" Text="Сохранить"/>
    </div>

    <script>
        ; (function ($) {
            $.fn.datepicker.dates['ru'] = {
                days: ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"],
                daysShort: ["Вск", "Пнд", "Втр", "Срд", "Чтв", "Птн", "Суб"],
                daysMin: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"],
                months: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
                monthsShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июн", "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"],
                today: "Сегодня",
                clear: "Очистить",
                format: "dd.mm.yyyy",
                weekStart: 1,
                monthsTitle: 'Месяцы'
            };
        }(jQuery));
    </script>
    <script>
        $(document).ready(function () {
            var date_input = $('input[name="DateInstall"]');
            var container = $('.bootstrap-iso').length > 0 ? $('#DateInstall').parent() : "body";
            date_input.datepicker({
                format: 'dd/mm/yyyy',
                container: container,
                todayHighlight: true,
                autoclose: true,
                language: 'ru',
            });
            var date_input = $('input[name="DateDeinstall"]');
            var container = $('.bootstrap-iso').length > 0 ? $('#DateDeinstall').parent() : "body";
            date_input.datepicker({
                format: 'dd/mm/yyyy',
                container: container,
                todayHighlight: true,
                autoclose: true,
                language: 'ru',
            });
            var date = $("#DateInstall_hidden").attr("value");
            $("#DateInstall").attr("value", date);
            date = $("#DateDeinstall_hidden").attr("value");
            $("#DateDeinstall").attr("value", date);
            $("#<%=DL_Reasons.ClientID%>").change(function () {
                var str = "";
                $("#<%=DL_Reasons.ClientID%> option:selected").each(function () {
                    str += $(this).text() + ", ";
                });
                $('#<%=DL_Reasons.ClientID%>').text(str);
            });
            $("#<%=DL_Jobs.ClientID%>").change(function () {
                var str = "";
                $("#<%=DL_Jobs.ClientID%> option:selected").each(function () {
                    str += $(this).text() + ", ";
                });
                $('#<%=DL_Jobs.ClientID%>').text(str);
            });
        });
    </script>
</asp:Content>