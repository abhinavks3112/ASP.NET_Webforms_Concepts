<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStateWebForm.aspx.cs" Inherits="WebFormBasics.ViewStateWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
            <asp:Button ID="btnCount" runat="server" OnClick="btnCount_Click" Text="Click Me" />
        </div>
    </form>
</body>
</html>
