<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TasksManagement_3._0.Register" %>

<!DOCTYPE html>

<link rel="stylesheet" href="/CSS/Sign_Up_For_Business.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Sign Up for Bussiness | TasksManagement
    </title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body class="default" style="background-image:url('Media/Image/background.jpg'); 
background-size: cover; background-repeat:no-repeat; background-attachment:fixed;">
    <form id="form1" runat="server" class="default" style="background-image:url('Media/Image/background.jpg'); 
background-size: cover; background-repeat:no-repeat; background-attachment:fixed;">
        <div class="heading"> <label> SIGN UP FOR BUSINESS</label> </div>
        <div class="center-page">
            <label>Company name</label>
            <asp:TextBox ID="TbCompanyName" runat="server" CssClass="textbox" placeholder="Example: ABC Co"> </asp:TextBox>
            <br><asp:label ID="CompanyNameWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Company name has already been taken</asp:label>  <br>
            <label>Company Email</label>  
            <asp:TextBox ID="TbEmail" runat="server" CssClass="textbox" placeholder="Example: abc@abc.com"> </asp:TextBox> 
            <br><asp:label ID="EmailWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Email has already been used</asp:label>  <br>
            <label>Password</label>
            <asp:TextBox ID="TbPassword"  runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox> 
            <br><asp:label ID="PasswordWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Password must be at least 6 characters long</asp:label>  <br>
            <label>Confirm Password</label> 
            <asp:TextBox ID="TbConfirmPassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox> 
            <br><asp:label ID="ConfirmPasswordWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* Password does not match </asp:label>  <br>
            <label> Number of employees</label> 
            <asp:TextBox ID="TbNumberOfEmplyees" runat="server" CssClass="textbox" placeholder="Example: 28"></asp:TextBox> 
            <br><asp:label ID="NumberWarning" runat="server" Visible="false" ForeColor="Red" Font-Size="XX-Small">* It must be an integer </asp:label>  <br>
            <asp:RadioButton ID="Agree" style="font-size: 10px" runat="server" Text="I agree to your Terms, Data Policy and Cookie Policy." >  </asp:RadioButton>
            
            <br />
            <br />
            <asp:Button CssClass="button" runat="server" Text="Submit" ID="BtSubmit" OnClick="BtSubmit_Click"></asp:Button>
         </div>
    </form>

    

</body>
</html>
