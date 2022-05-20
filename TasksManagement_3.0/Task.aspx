﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="TasksManagement_3._0.Task" %>

<!DOCTYPE html>
<link rel="stylesheet" href="/CSS/NavigationBar.css">
<link rel="stylesheet" href="/CSS/TaskView.css">   
<link rel="stylesheet" href="/CSS/Home.css">    

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
                        <a class="nav-link" href="NewTask.aspx">New Task</a>
                     </li>
                     <li class="nav-item">
                        <a class="nav-link" href="TaskView.aspx" style="color:white">Tasks</a>
                     </li>
                      <li class="nav-item">
                        <a class="nav-link" href="Chat.aspx">Chat</a>
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
        <asp:Repeater runat="server" ID="Display">
            <ItemTemplate>
                <div style="margin: 10px;">
                    <label style="font-size: 30px"><%#Eval("Name")%></label> <br />

                    <label style="font-size: 10px; color: gray;">Due to: <%#Eval("Deadline")%> </label>
                    <p>
                        <%#Eval("Description")%>
                    </p>
                    <label style="font-size: 10px"><%#Eval("AttachmentName")%></label>
                    <asp:LinkButton class="button" runat="server" Text="Download" OnClick="Download_Click"> </asp:LinkButton>
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
        <hr>
        <div style="margin: 10px;">
            <label > YOUR WORKS: </label>
            <br />
            <asp:TextBox ID="TbDes" style="width: 98%;height: 300px;" runat="server" TextMode="MultiLine" placholder="Type your work here or attach a file"> </asp:TextBox>
            <asp:FileUpload ID="FlAttachment" runat="server" />  
            <br />
            <br />
            <asp:Button ID="BtSubmit" runat="server" Text=" Turn in " CssClass="button" OnClick="BtSubmit_Click">  </asp:Button>
        </div>

       
    </form>
</body>
</html>
