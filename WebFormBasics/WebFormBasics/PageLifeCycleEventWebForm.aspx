<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageLifeCycleEventWebForm.aspx.cs" Inherits="WebFormBasics.PageLifeCycleEventWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInput" runat="server" OnTextChanged="txtInput_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvtxtInput" runat="server" ControlToValidate="txtInput" ErrorMessage="Required Field Validation Event"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
