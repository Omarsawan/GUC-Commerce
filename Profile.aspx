<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GUC_Commerce_GUI.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add Mobile number:
            <br />
            <br />
            <asp:TextBox ID="txt_mobilenum" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="addMobile" runat="server" OnClick="addMobile" Text="Add number" />
        </div>
    </form>
</body>
</html>
