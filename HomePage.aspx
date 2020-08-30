<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="GUC_Commerce_GUI.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            WELCOME
            <br />
            <br />
            <asp:HyperLink ID="MyProfile" runat="server" href="MyProfile.aspx">My Profile</asp:HyperLink>
                <br />
            <br />
                     
            Make Order:
            <br />
        <asp:Button ID="btn_login" runat="server" Text="OrderNow" onclick="makeOrder" Width="90px"/>
          <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" href="OrderPayment.aspx">Payment</asp:HyperLink>
                <br />
            <br />
            <asp:Button ID="btn_logout" runat="server" Text="Logout" onclick="logOut"/>
        </div>
    </form>
</body>
</html>
