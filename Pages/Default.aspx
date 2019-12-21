<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalAssignmentCS.Pages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Reset.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Forms.css" />
    <link rel="stylesheet" type="text/css" href="CSS/Signup.css" />
    <link rel="stylesheet" type="text/css" href="CSS/home.css" />
    <title>Welcome to sprout!</title>
</head>
<body>
    <form id="enter" class="form-container" runat="server">
        <h1 id="form-title">Welcome!</h1>
            <asp:Button ID="login" class="main" Text="Log In" OnClick="login_Click" runat="server" />
        <asp:Button ID="register" class="main" Text="Register" OnClick="register_Click" runat="server" />
    </form>
</body>
</html>
