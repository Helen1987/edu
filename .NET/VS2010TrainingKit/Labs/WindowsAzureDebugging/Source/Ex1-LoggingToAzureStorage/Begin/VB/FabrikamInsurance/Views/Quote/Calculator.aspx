<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of FabrikamInsurance.QuoteViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fabrikam Insurance
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%-- The following line works around an ASP.NET compiler warning --%>
<%: ""%>
    <style type="text/css">
        label { float:left; clear: right; margin-bottom: 0.2em;}
        select { float: right; width: 20em; }
        #quotetitle { font-size:x-large; }
        #monthlypremium { font-size:xx-large; color: #648f3f; margin-left: 1em; }
        #yearlypremium { font-size:xx-large; color: #b6cba3; margin-left: 1em; }
        .field-validation-error { float: left; }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $('select#MakeId').change(function () {
                $.post('/Quote/GetModels',
                        { id: this.value },
                        function (data) {
                            var model = $('#ModelId');
                            var prompt = model.children().first();
                            model.empty();
                            model.append(prompt);
                            $.each(data, function (index, item) {
                                model.append($('<option />').val(item.Key).text(item.Value));
                            });
                        });
            }
            );
        });

    </script>
    <h2>Auto Insurance Quotes</h2>
    <% Using (Html.BeginForm())%>
        <%: Html.ValidationSummary(true) %>
        <fieldset id="input">
            <legend>Vehicle Details</legend>
            <div>
                <%: Html.LabelFor(Function(model) model.MakeId)%>
                <%: Html.ValidationMessageFor(Function(model) model.MakeId, "*")%>
                <%: Html.DropDownListFor(Function(model) model.MakeId, Model.Makes.AsSelectList(), "-- Select Make --", New With {.id = "MakeId"})%>
            </div>
            <div>
                <%: Html.LabelFor(Function(model) model.ModelId)%>
                <%: Html.ValidationMessageFor(Function(model) model.ModelId, "*")%>
                <%: Html.DropDownListFor(Function(model) model.ModelId, Model.Models.AsSelectList(), "-- Select Model --", New With {.id = "ModelId"})%>
            </div>
            <div>
                <%: Html.LabelFor(Function(model) model.ManufacturedYear)%>
                <%: Html.ValidationMessageFor(Function(model) model.ManufacturedYear, "*")%>
                <%: Html.DropDownListFor(Function(model) model.ManufacturedYear, Model.YearList.AsSelectList(), "-- Select Year --", New With {.id = "ManufacturedYear"})%>
            </div>
            <div>
                <%: Html.LabelFor(Function(model) model.BodyStyleId)%>
                <%: Html.ValidationMessageFor(Function(model) model.BodyStyleId, "*")%>
                <%: Html.DropDownListFor(Function(model) model.BodyStyleId, Model.BodyStyles.AsSelectList(), "-- Select Body Style --", New With {.id = "BodyStyleId"})%>
            </div>
            <div>
                <%: Html.LabelFor(Function(model) model.BrakeTypeId)%>
                <%: Html.ValidationMessageFor(Function(model) model.BrakeTypeId, "*")%>
                <%: Html.DropDownListFor(Function(model) model.BrakeTypeId, Model.BrakeTypes.AsSelectList(), "-- Select Brake Type --", New With {.id = "BrakeTypeId"})%>
            </div>
            <div>
                <%: Html.LabelFor(Function(model) model.SafetyEquipmentId)%>
                <%: Html.ValidationMessageFor(Function(model) model.SafetyEquipmentId, "*")%>
                <%: Html.DropDownListFor(Function(model) model.SafetyEquipmentId, Model.SafetyEquipment.AsSelectList(), "-- Select Safety Equipment --", New With {.id = "SafetyEquipmentId"})%>
            </div>
            <div>
                <%: Html.LabelFor(Function(model) model.AntiTheftDeviceId)%>
                <%: Html.ValidationMessageFor(Function(model) model.AntiTheftDeviceId, "*")%>
                <%: Html.DropDownListFor(Function(model) model.AntiTheftDeviceId, Model.AntiTheftDevices.AsSelectList(), "-- Select Anti-Theft Device --", New With {.id = "AntiTheftDeviceId"})%>
            </div>
        </fieldset>
        <div>
            <input id="calculate" type="submit" value="Calculate" />
        </div>
    <% End Using%>
    <br />
    <% If (Model.MonthlyPremium > 0) Then%>
    <div id="status">
        <div id="quotetitle">Your Quote:</div>
        <div id="monthlypremium"><%= Model.MonthlyPremium.ToString("c")%>/month</div>
        <div id="yearlypremium"><%= Model.YearlyPremium.ToString("c")%>/year</div>
    </div>
    <% End If%>

</asp:Content>
