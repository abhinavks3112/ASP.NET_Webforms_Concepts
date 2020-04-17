<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CascadingDropDownListsWebForm.aspx.cs" Inherits="WebFormBasics.CascadingDropDownListsWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblContinents" runat="server" Text="Continent:" Width="70px"></asp:Label>
&nbsp;&nbsp;
            <asp:DropDownList ID="ddlContinents" runat="server" Width="200px"
                DataTextField="ContinentName" DataValueField="ContinentId" OnSelectedIndexChanged="ddlContinents_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblCountry" runat="server" Text="Country:" Width="70px"></asp:Label>
&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCountries" runat="server" Width="200px"
                DataTextField="CountryName" DataValueField="CountryId" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblCity" runat="server" Text="City" Width="70px"></asp:Label>
&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCities" runat="server" Width="200px"
                DataTextField="CityName" DataValueField="CityId">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
