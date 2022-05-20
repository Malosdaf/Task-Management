<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_Register.aspx.cs" Inherits="TasksManagement_3._0.Employee_Register" %>

<!DOCTYPE html>

<link rel="stylesheet" href="/CSS/Sign_Up_For_Business.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="default" style="background-image:url('Media/Image/background.jpg'); 
background-size: cover; background-repeat:no-repeat; background-attachment:fixed;">
    <form id="form1" runat="server" class="default">
        <div class="heading"> <label> SIGN UP FOR INDIVIDUAL</label> </div>
        <div class="center-page">
            <label>Name</label>
            <asp:TextBox ID="TbUsername" runat="server" CssClass="textbox" placeholder="Example: A B C"> </asp:TextBox>
            <br />
            <br />
            <label>Email</label>  
            <asp:TextBox ID="TbEmail" runat="server" CssClass="textbox" placeholder="Example: abc@email.com"> </asp:TextBox> 
            <br><asp:label ID="EmailWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Email has already been used</asp:label>  <br>
            <label>Password</label>
            <asp:TextBox ID="TbPassword"  runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox> 
            <br><asp:label ID="PasswordWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Password must be at least 6 characters long</asp:label>  <br>
            <label>Confirm Password</label> 
            <asp:TextBox ID="TbConfirmPassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox> 
            <br><asp:label ID="ConfirmPasswordWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Password does not match </asp:label>  <br>

            <label> Your superior email </label>
            <asp:TextBox ID="TbBoss" runat="server" CssClass="textbox"></asp:TextBox> 
            <br><asp:label ID="BossWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Your boss account doesn't exist </asp:label>  <br>
            
            <asp:RadioButton ID="Agree" style="font-size: 10px" runat="server" Text="I agree to your Terms, Data Policy and Cookie Policy." >  </asp:RadioButton>
            
            <br />
            <br />
            <asp:Button CssClass="button" runat="server" Text="Submit" ID="BtSubmit" OnClick="BtSubmit_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
