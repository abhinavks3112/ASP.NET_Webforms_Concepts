<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationControlsWebForm.aspx.cs" Inherits="WebFormBasics.ValidationControlsWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" lang="javascript">
        function isEven(source, args) {
            // Check if input is empty
            if (args.Value == "") {
                args.IsValid = false;
            }
            else {
                if ((args.Value % 2) == 0) {
                    args.IsValid = true;
                }
                else {
                    args.IsValid = false;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name" Width="150px"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="100px"></asp:TextBox>
            <%-- Validation controls is used to perform both on client side and server side, on server side.
                 Server side validation is always performed, irrespective of whether the client side validation is done or not.--%>&nbsp;<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email" Width="150px"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email is not valid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password" Width="150px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" Width="150px"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is Required" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Password and Confirm Password do not match" ForeColor="Red">*</asp:CompareValidator>
            <br />
            <br />
            <asp:Label ID="Gender" runat="server" Text="Gender" Width="150px"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rblGender" ErrorMessage="Gender is Required" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
            <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
            &nbsp;<br />
            <asp:Label ID="lblCountry" runat="server" Text="Country" Width="150px"></asp:Label>
            <asp:DropDownList ID="ddlCountry" runat="server">
                <asp:ListItem Value="-1">Select Country</asp:ListItem>
                <asp:ListItem>India</asp:ListItem>
                <asp:ListItem>Russia</asp:ListItem>
                <asp:ListItem>Germany</asp:ListItem>
                <asp:ListItem>Japan</asp:ListItem>
                <asp:ListItem>Poland</asp:ListItem>
            </asp:DropDownList>
            <%-- InitialValue="-1" or any value for first item specified here, so that while evaluating, it doesn't consider this option as
                a valid value chosen by the user--%>&nbsp;<asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Country is Required" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblAge" runat="server" Text="Age" Width="150px"></asp:Label>
            <asp:TextBox ID="txtAge" runat="server" Width="100px"></asp:TextBox>
            <%-- Range validator does not check for blank/empty input, it sets Valid to true in this case, so for validation to work,
                input must be there and to enforce that, required validator will additionally be required on same input.--%>
            <asp:RangeValidator ID="rgvAge" runat="server" ErrorMessage="Age must be between 1-100" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Integer" ControlToValidate="txtAge" Display="Dynamic">*</asp:RangeValidator>
            <%-- Display="Dynamic" should be set in case we have more than one validator and we want to appear at the same place
                when validation fails, meaning if Display="Static", space will be kept reserved for each validator, so even if
                second validator in triggered, it won't appear right next to input, since that place has been kept reserved for
                first validator. Display="Dynamic" doesn't reserve space and whichever validation is triggered, that message
                will appear dynamically next to the input.--%>
            <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" ErrorMessage="Age is Required" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblEvenNumber" runat="server" Text="Even Number" Width="150px"></asp:Label>
            <asp:TextBox ID="txtEvenNumber" runat="server" Width="100px"></asp:TextBox>
            <%-- Generally any validator(except RequiredField Validator) doesn't check 
                and doesn't call validation event handler if input is empty, and set isValid to true.
                To make the custom validator check for empty input/textbox and also call validation event
                handler, we set ValidateEmptyText="True". Setting it true will only call validation function,
                we have to write code to handle the empty string or empty input.
                For other validators, we have to additionally apply Required Field Validator on same input.--%>
            <asp:CustomValidator 
                ID="CustomValidatorEvenNumber" 
                runat="server" 
                ErrorMessage="Not an Even Number." 
                ControlToValidate="txtEvenNumber" 
                ForeColor="Red" 
                OnServerValidate="CustomValidatorEvenNumber_ServerValidate"
                ClientValidationFunction ="isEven"
                ValidateEmptyText="True">*</asp:CustomValidator>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Validation Errors:" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
