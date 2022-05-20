<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewTask.aspx.cs" Inherits="TasksManagement_3._0.NewTask" %>

<!DOCTYPE html>

<link rel="stylesheet" href="/CSS/NavigationBar.css">
<link rel="stylesheet" href="/CSS/Home.css">
<link rel="stylesheet" href="/CSS/NewTask.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body class="default" style="background-image:url('Media/Image/background.jpg'); 
background-size: cover; background-repeat:no-repeat; background-attachment:fixed;">
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
            <div class="container-fluid">
               <div class="collapse navbar-collapse" id="collapsibleNavbar">
                  <ul class="navbar-nav">
                     <li class="nav-item">
                        <a class="nav-link" href="Home.aspx">Home</a>
                     </li>
                     <li class="nav-item">
                        <a class="nav-link" href="NewTask.aspx" style="color:white">New Task</a>
                     </li>
                     <li class="nav-item">
                        <a class="nav-link" href="TaskView.aspx">Tasks</a>
                     </li>
                      <li class="nav-item">
                          <a class="nav-link" href="Chat.aspx" > Chat </a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="Statistic.aspx">Statistic</a>
                     </li>
                     <li class="nav-item dropdown" style="position:absolute; left:100%; transform:translateX(-150%); z-index:100">
                        <div data-toggle="dropdown"  class="nav-link dropdown-toggle user-action"  data-bs-toggle="dropdown">
                           <asp:LinkButton ID="Dashboard_LinkBtn_User_Name" style="color:lightslategray; text-decoration:none"  runat="server"> </asp:LinkButton>
                           <b class="caret"></b>
                        </div>
                        <ul class="dropdown-menu">
                           <li><a class="dropdown-item" href="#">Settings</a></li>
                           <li> <asp:Button runat="server" CssClass="dropdown-item" Text="Sign Out" OnClick="BtnSignOut_Click" ></asp:Button></li>
                        </ul>
                     </li>
                  </ul>
               </div>
            </div>
         </nav>
        <div class="NewForm">
            <b>
            <label> Task name:</label> <br />
            <asp:TextBox runat="server" ID="TbTaskName" CssClass="textbox"> </asp:TextBox>  <br />
            <label> To:</label> <br />
            <asp:TextBox runat="server" ID="TbTo" placeholder="Emails must be separated by commas. Ex: abc@email.com, bcd@email.com" CssClass="textbox"> </asp:TextBox> <br />
            <label> Deadline:</label> <br />
            <asp:TextBox runat="server" ID="TbDeadline" CssClass="textbox" placeholder="HH:MM:SS dd/mm/yyyy"> </asp:TextBox> <br />
            <label> Description </label> <br />
            <asp:TextBox runat="server" ID="TbDes" TextMode="MultiLine" CssClass="description"> </asp:TextBox> <br /> 
            &nbsp;<br />
            <label> Attachment:</label><br />
            <asp:FileUpload ID="FlAttachment" runat="server" Height="39px" Width="295px" />  
   
            <br />

            <asp:Button runat="server" ID="BtSubmit" Text="Submit" CssClass="button" OnClick="BtSubmit_Click"></asp:Button>
            </b>
        </div>
    </form>
</body>
</html>
