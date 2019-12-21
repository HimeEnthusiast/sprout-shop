<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalAssignmentCS.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Reset.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Forms.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Signup.css" />
    <title>Login</title>
</head>
<body>
    <form id="login" class="form-container" runat="server">
        <h1 id="form-title">Log In</h1>
            <h2 class="form-label">Email: </h2>
                <asp:TextBox ID="email" class="form-textbox" TextMode="Email" runat="server" />
                <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="Please enter an email" ControlToValidate="email" Display="Dynamic" /><br />
            
            <h2 class="form-label">Password: </h2>
                <asp:TextBox ID="password" class="form-textbox" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator ID="rf2" runat="server" ErrorMessage="Please enter a password" ControlToValidate="password" Display="Dynamic" /><br />

            <asp:Button ID="submit" class="form-submit" Text="Log In" onclick="submit_Click" runat="server" />
    </form>
</body>
</html>
