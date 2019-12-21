<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FinalAssignmentCS.Pages.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Reset.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Forms.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Signup.css" />
    <title>Registration</title>
</head>
<body>
    <form id="registration" class="form-container" runat="server">
        <h1 id="form-title">Sign Up</h1>
            <h2 class="form-label">Email: </h2>
                <asp:TextBox ID="email" class="form-textbox" TextMode="Email" placeholder="example@mail.com" runat="server" />
                <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="Please enter an email" ControlToValidate="email" Display="Dynamic" />

            <h2 class="form-label">First name: </h2>
                <asp:TextBox ID="fname" class="form-textbox" placeholder="First Name" runat="server" />
                <asp:RequiredFieldValidator ID="rf2" runat="server" ErrorMessage="Please enter your first name" ControlToValidate="fname" Display="Dynamic" />

            <h2 class="form-label">Last name: </h2>
                <asp:TextBox ID="lname" class="form-textbox" placeholder="Last Name" runat="server" />
                <asp:RequiredFieldValidator ID="rf3" runat="server" ErrorMessage="Please enter your last name" ControlToValidate="lname" Display="Dynamic" />

            <h2 class="form-label">Password: </h2>
                <asp:TextBox ID="pass" class="form-textbox" TextMode="Password" placeholder="Password" runat="server" />
                <asp:RequiredFieldValidator ID="rf4" runat="server" ErrorMessage="Please enter a password" ControlToValidate="pass" Display="Dynamic" />
            
            <br />
            <asp:Button ID="regBtn" class="form-submit" OnClick="regBtn_Click" runat="server" Text="Register" />
    </form>
</body>
</html>
