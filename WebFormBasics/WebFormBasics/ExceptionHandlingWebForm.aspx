<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionHandlingWebForm.aspx.cs" Inherits="WebFormBasics.ExceptionHandlingWebForm" %>
<%-- For page level custom error page, we use ErrorPage attribute above  --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvCountries" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
