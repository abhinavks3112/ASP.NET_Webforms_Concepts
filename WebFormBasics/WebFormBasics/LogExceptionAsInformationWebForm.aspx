<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogExceptionAsInformationWebForm.aspx.cs" Inherits="WebFormBasics.LogExceptionAsInformationWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFirstNumber" runat="server" Text="First Number" Width="118px"></asp:Label>
            <asp:TextBox ID="txtFirstNumber" runat="server" Width="118px"></asp:TextBox>
            <br />
            <asp:Label ID="lblSecondNumber" runat="server" Text="Second Number" Width="118px"></asp:Label>
            <asp:TextBox ID="txtSecondNumber" runat="server" Width="118px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnDivide" runat="server" OnClick="btnDivide_Click" Text="Divide" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
