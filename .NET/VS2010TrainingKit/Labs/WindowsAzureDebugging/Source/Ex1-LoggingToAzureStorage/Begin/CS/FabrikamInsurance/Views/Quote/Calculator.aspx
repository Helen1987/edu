<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FabrikamInsurance.Models.QuoteViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fabrikam Insurance
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <fieldset id="input">
            <legend>Vehicle Details</legend>
            <div>
                <%: Html.LabelFor(model => model.MakeId) %>
                <%: Html.ValidationMessageFor(model => model.MakeId, "*")%>
                <%: Html.DropDownListFor(model => model.MakeId, Model.Makes.AsSelectList(), "-- Select Make --", new {id = "MakeId"})%>
            </div>
            <div>
                <%: Html.LabelFor(model => model.ModelId) %>
                <%: Html.ValidationMessageFor(model => model.ModelId, "*")%>
                <%: Html.DropDownListFor(model => model.ModelId, Model.Models.AsSelectList(), "-- Select Model --", new {id = "ModelId"})%>
            </div>
            <div>
                <%: Html.LabelFor(model => model.ManufacturedYear) %>
                <%: Html.ValidationMessageFor(model => model.ManufacturedYear, "*")%>
                <%: Html.DropDownListFor(model => model.ManufacturedYear, Model.YearList.AsSelectList(), "-- Select Year --", new { id = "ManufacturedYear" })%>
            </div>
            <div>
                <%: Html.LabelFor(model => model.BodyStyleId) %>
                <%: Html.ValidationMessageFor(model => model.BodyStyleId, "*")%>
                <%: Html.DropDownListFor(model => model.BodyStyleId, Model.BodyStyles.AsSelectList(), "-- Select Body Style --", new { id = "BodyStyleId" })%>
            </div>
            <div>
                <%: Html.LabelFor(model => model.BrakeTypeId) %>
                <%: Html.ValidationMessageFor(model => model.BrakeTypeId, "*")%>
                <%: Html.DropDownListFor(model => model.BrakeTypeId, Model.BrakeTypes.AsSelectList(), "-- Select Brake Type --", new { id = "BrakeTypeId" })%>
            </div>
            <div>
                <%: Html.LabelFor(model => model.SafetyEquipmentId) %>
                <%: Html.ValidationMessageFor(model => model.SafetyEquipmentId, "*")%>
                <%: Html.DropDownListFor(model => model.SafetyEquipmentId, Model.SafetyEquipment.AsSelectList(), "-- Select Safety Equipment --", new { id = "SafetyEquipmentId" })%>
            </div>
            <div>
                <%: Html.LabelFor(model => model.AntiTheftDeviceId) %>
                <%: Html.ValidationMessageFor(model => model.AntiTheftDeviceId, "*") %>
                <%: Html.DropDownListFor(model => model.AntiTheftDeviceId, Model.AntiTheftDevices.AsSelectList(), "-- Select Anti-Theft Device --", new { id = "AntiTheftDeviceId" })%>
            </div>
        </fieldset>
        <div>
            <input id="calculate" type="submit" value="Calculate" />
        </div>
    <% } %>
    <br />
    <% if (Model.MonthlyPremium > 0) {%>
    <div id="status">
        <div id="quotetitle">Your Quote:</div>
        <div id="monthlypremium"><%= Model.MonthlyPremium.ToString("c")%>/month</div>
        <div id="yearlypremium"><%= Model.YearlyPremium.ToString("c")%>/year</div>
    </div>
    <% } %>

</asp:Content>
