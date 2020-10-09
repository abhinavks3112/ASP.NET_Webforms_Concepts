<%@ Page Language="C#" AutoEventWireup="true" Trace="true" CodeBehind="TracingRealTimeExampleWebForm.aspx.cs" Inherits="WebFormBasics.TracingRealTimeExampleWebForm" %>
<%-- For checking performance issue, we are setting Trace to true --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            All Employees<asp:GridView ID="gvAllEmployees" runat="server">
            </asp:GridView>
            <br />
            Total Employees By Department<asp:GridView ID="gvEmployeeCountByDept" runat="server">
            </asp:GridView>
            <br />
            Total Employees By Gender<asp:GridView ID="gvEmployeeCountByGender" runat="server">
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
