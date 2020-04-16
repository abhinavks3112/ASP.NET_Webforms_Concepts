<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonEventsWebForm.aspx.cs" Inherits="WebFormBasics.ButtonEventsWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnPrint" runat="server" Text="Print" oncommand="ButtonCommand_Click" CommandName="Print" />

            <%-- Client side click event(OnClientClick) and its handler written here , using javascript or any language that a browser understands --%>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" oncommand="ButtonCommand_Click" CommandName="Delete" 
                OnClick="Button_Click"  OnClientClick="return confirm('Are you sure you want to delete this item?')"/>

            <%-- Event handler on server side is statically hooked up with event here(eg. oncommand="ButtonCommand_Click") eg.  --%>
            <asp:Button ID="btnTop10Emp" runat="server" Text="Show Top 10 Employees" oncommand="ButtonCommand_Click"
               CommandName="Show" CommandArgument="Top10"  />

            <asp:Button ID="btnBottom10Emp" runat="server" Text="Show Bottom 10 Employees" oncommand="ButtonCommand_Click" 
               CommandName="Show" CommandArgument="Bottom10"/>

            <asp:Label ID="lblOutput" runat="server" Text="Output"></asp:Label>
        </div>
    </form>
</body>
</html>
