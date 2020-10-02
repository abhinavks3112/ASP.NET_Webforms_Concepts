<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageNavigatedToWebForm.aspx.cs" Inherits="WebFormBasics.PageNavigatedToWebForm" %>
<%@ PreviousPageType VirtualPath="~/PageNavigationTechWebForm.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>This is second webform on same server.</h3>
            <asp:Label ID="lblName" runat="server" Text="Name" Width="100px"></asp:Label>
            <asp:Label ID="lblNameValue" runat="server" Text="lblName" Width="100px"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email" Width="100px"></asp:Label>
            <asp:Label ID="lblEmailValue" runat="server" Text="lblEmail" Width="100px"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <br />
        </div>
    </form>
</body>
</html>
