<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistic.aspx.cs" Inherits="TasksManagement_3._0.Statisic" %>

<!DOCTYPE html>
<link rel="stylesheet" href="/CSS/NavigationBar.css">
<link rel="stylesheet" href="/CSS/TaskView.css">   
<link rel="stylesheet" href="/CSS/Home.css">    
<link rel="stylesheet" href="/CSS/Statistic.css">    


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
                        <a class="nav-link" href="TaskView.aspx">Tasks</a>
                     </li>
                      <li class="nav-item">
                        <a class="nav-link" href="Chat.aspx">Chat</a>
                     </li>
                      <li class="nav-item">
                        <a class="nav-link" href="Statistic.aspx"  style="color:white">Statistic</a>
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
        <asp:Repeater runat="server" id="Users_Statistic">
            <ItemTemplate>
                <a href="Statistic_Individual.aspx?Email=<%#Eval("Email")%>">
                    <div class="User" style="text-decoration: none; color:black">
                        <image class="Image" src="Media/Image/User-Avatar-Transparent.png"></image>
                         <div class="Information" style="display: inline-block; width: 80%">
                             <label> <%#Eval("Username")%> </label> <br />
                             <label style="color: dimgray; font-size: 11px;"> Email: <%#Eval("Email")%> </label> <br />
                  
                             <label style="color: chartreuse; font-size: 11px"> Current: <%# dicStat[Eval("Email").ToString()].Done %> / <%# dicStat[Eval("Email").ToString()].Total %></label>
                             <div style='border-radius: 3px; margin:0px; padding:0px;position: absolute; width: 80%; height: 5px; background-color:white;'></div> 
                             <div style='border-radius: 3px; margin:0px; padding:0px; position:absolute;width: <%#dicStat[Eval("Email").ToString()].Percentage%>%; height: 5px; background-color:chartreuse'></div> 
                        
                         </div>
                    </div>
               </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
