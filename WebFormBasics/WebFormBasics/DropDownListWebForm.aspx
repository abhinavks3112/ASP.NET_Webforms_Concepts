<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownListWebForm.aspx.cs" Inherits="WebFormBasics.DropDownListWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>&nbsp;
            <asp:DropDownList ID="ddlCity" runat="server">
            </asp:DropDownList>
            <%-- <asp:DropDownList ID="ddlCity" runat="server" DataTextField="CityName" DataValueField="CityId">
            </asp:DropDownList>--%>
            <br />
            <br />
            <asp:Label ID="lblCountries" runat="server" Text="Country: "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCountries" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </div>
    </form>
</body>
</html>
