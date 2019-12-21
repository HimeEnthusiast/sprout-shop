<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="FinalAssignmentCS.Pages.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Reset.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Forms.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Signup.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Order.css" />
    <title></title>
</head>
<body>
    <form id="orderForm" class="form-container" runat="server">
        <h1 id="form-title">Order</h1>
        <div id="orderDisplay" runat="server">
        </div><br />
        <div id="form-holder">
            <div id="address">
                <h2 class="form-label2">Street</h2>
                    <asp:TextBox ID="street" class="form-text" runat="server" />
                    <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="Please enter a street" ControlToValidate="street" Display="Dynamic" />

                <h2 class="form-label2">City</h2>
                    <asp:TextBox ID="city" class="form-text" runat="server" />
                    <asp:RequiredFieldValidator ID="rf2" runat="server" ErrorMessage="Please enter a city." ControlToValidate="city" Display="Dynamic" />

                <h2 class="form-label2">Postal Code</h2>
                    <asp:TextBox ID="postalCode" class="form-text" runat="server" />
                    <asp:RequiredFieldValidator ID="rf3" runat="server" ErrorMessage="Please enter a postal code" ControlToValidate="postalCode" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="re1" runat="server" ErrorMessage="Please enter your postal code in the correct format." ControlToValidate="postalCode" ValidationExpression="^[a-zA-Z][0-9][a-zA-Z][\ \-]{0,1}[0-9][a-zA-Z][0-9]$" />
            </div>

            <div id="payment">
                <h2 class="form-label2">Card Type</h2>
                    <asp:DropDownList ID="cardType" class="form-text" runat="server">
                        <asp:ListItem Text="MasterCard" Value="mastercard" />
                        <asp:ListItem Text="Visa" Value="visa" />
                    </asp:DropDownList>

                <h2 class="form-label2">Card Number</h2>
                    <asp:TextBox ID="cardNumber" class="form-text" runat="server" />
                    <asp:RequiredFieldValidator ID="rf4" runat="server" ErrorMessage="Please enter your card number" ControlToValidate="cardNumber" Display="Dynamic" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="cardNumber" ErrorMessage="Please enter a number." Display="Dynamic" />
                    <asp:RangeValidator id="RangeValidator2" ControlToValidate="cardNumber" MinimumValue="1" MaximumValue="2147483647" Type="Integer" Text="Number is too large." runat="server"/>

                <h2 class="form-label2">Security Code</h2>
                    <asp:TextBox ID="securityCode" class="form-text" runat="server" />
                    <asp:RequiredFieldValidator ID="rf5" runat="server" ErrorMessage="Please enter the security code" ControlToValidate="securityCode" Display="Dynamic" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="securityCode" ErrorMessage="Please enter a number." Display="Dynamic" />
                    <asp:RangeValidator id="RangeValidator3" ControlToValidate="securityCode" MinimumValue="1" MaximumValue="999" Type="Integer" Text="Number is too large." runat="server"/>

                <h2 class="form-label2">Card Holder Name</h2>
                    <asp:TextBox ID="cardName" class="form-text" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the name on the card" ControlToValidate="cardName" Display="Dynamic" />
            </div>
        </div>
        <asp:Button ID="sendOrder" Text="Order Now" OnClick="sendOrder_Click" runat="server" />
    </form>
</body>
</html>
