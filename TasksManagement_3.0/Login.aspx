<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TasksManagement_3._0.Company_Login" %>

<!DOCTYPE html>

<link rel="stylesheet" href="/CSS/Company_Login.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="default" style="background-image:url('Media/Image/background.jpg'); 
background-size: cover; background-repeat:no-repeat; background-attachment:fixed;">
    <form id="form1" runat="server">
        <div class="heading"> 
            <b> 
                <label> LOGIN</label>
            </b> 
        </div>
        <div class="center-page">
            <b>
            <label style="color:white">Email</label>
            <asp:TextBox CssClass="textbox" runat="server" ID="TbEmail"> </asp:TextBox> 
            <label style="color: white ">Password</label>
            <asp:TextBox CssClass="textbox" runat="server" ID="TbPassword" TextMode="Password"> </asp:TextBox> 
            <asp:CheckBox ForeColor="White" runat="server" Text="Remember me"> </asp:CheckBox> <br />
            <asp:Label runat="server" ID="LoginWarning" Visible="false" ForeColor="Red" Font-Size="XX-Small"> * Wrong password or Email. Please check again </asp:Label>
            <asp:Button CssClass="button" runat="server" ID="BttonSubmit" Text="Log In" OnClick="BttonSubmit_Click"> </asp:Button>
            </b>
            <br />
        </div>
    </form>
     
</body>
</html>
