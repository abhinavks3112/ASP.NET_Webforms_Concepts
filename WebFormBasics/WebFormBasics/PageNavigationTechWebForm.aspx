<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageNavigationTechWebForm.aspx.cs" Inherits="WebFormBasics.PageNavigationTechWebForm" %>
<%-- We can disable session state on Page level by setting attribute EnableSessionState="False" --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OpenInNewWindow() {
            var Name = document.getElementById('txtName').value;
            var Email = document.getElementById('txtEmail').value;

            window.open('PageNavigatedToWebForm.aspx?Name=' + Name + '&Email=' + Email, '_blank', 'toolbar=no,location=no,resizable=no', true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>This is first webform.</h3>
            <asp:HyperLink ID="HyperLinkSameServer" runat="server" NavigateUrl="~/Contact.aspx">HyperLink Same Server Different Page, History Is Maintained, No server side event exposed</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLinkDiffServer" runat="server" NavigateUrl="https://www.google.com">HyperLink Different Server Page, History Is Maintained, No server side event exposed</asp:HyperLink>
            <br />
            <br />

            <%-- Response.Redirect() method. When the user clicks the button, the web server receives, 
                a request for redirection. The server then sends a response header to the client. The client then
                automatically issues a new GET request to the web server. The web server will then serve the new page.
                So, in short, Response.Redirect causes 2 request/response cycles. 
                Also, note that when Response.Redirect is used the URL in the address bar changes and
                the browser history is maintained.
                Response.Redirect() can be used to navigate pages/websites on the same web server or,
                on a different web server--%>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Response Redirect, History Is Maintained, 2 client server trips, Server side event exposed" />
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name" Width="100px"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email" Width="100px"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnServerTransfer" runat="server" OnClick="btnServerTransfer_Click" Text="Server Transfer, Transfer to second webform, same server" />
            <br />
            <br />
            <asp:Button ID="btnServerExecute" runat="server" OnClick="btnServerExecute_Click" Text="Server Execute, Transfer to second webform, same server" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" PostBackUrl="~/PageNavigatedToWebForm.aspx" Text="Cross Post Back, Posting back to different webform" />
            <br />
            <br />
            <asp:Button ID="btnQueryString" runat="server" OnClick="btnQueryString_Click" Text="Query String" />
            <br />
            <br />
            <asp:Button ID="btnCookies" runat="server" OnClick="btnCookies_Click" Text="Cookies" />
            <br />
            <br />
            <asp:Button ID="btnSession" runat="server" OnClick="btnSession_Click" Text="Session" />
            <br />
            <br />
            <asp:Button ID="btnApplication" runat="server" OnClick="btnApplication_Click" Text="Application" />
            <br />
            <br />
            <input id="btnHTML" type="button" onclick="OpenInNewWindow()" value="HTML Button Window Open" /><br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="Status" ForeColor="Red" Font-Bold></asp:Label>
            <br />

        </div>
    </form>
</body>
</html>
