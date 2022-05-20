<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistic_Individual.aspx.cs" Inherits="TasksManagement_3._0.Statistic_Individual" %>

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
         
        
            <asp:Repeater runat="server" id="Display_UserInfo">
            <ItemTemplate>
                    <div style="text-decoration: none; color:black; border:solid;border-color: darkblue; padding-bottom: 20px">
                        <image class="Image" style="width: 150px; height: 100px" src="Media/Image/User-Avatar-Transparent.png"></image>
                         <div class="Information" style="display: inline-block;">
                             <label style="font-size: 30px"> <%#Eval("Username")%> </label> <br />
                             <label style="color: dimgray; font-size: 15px;"> Email: <%#Eval("Email")%> </label> <br />
                         </div>
                    </div>
                    
                    <div style="display: flex;
        flex-direction: row;
        width: 100%;
        height: 74vh;
        padding: 4px;
        gap: 8px;
        background-color: #4648665  f;
        backdrop-filter: blur(2px);">
                        <label style="font-size: 30px; color: darkgreen; display:flex; justify-content:space-between"> Current tasks: </label> <br />
                        <div style="display:inline-block; text-align: center">
                            <label> Done </label> <br />
                            <div class="pie animate" style="--p:<%#Done%>;--c:lightgreen; margin: 30px"> <%# Done %>% </div> 
                        </div>
                        <div style="display:inline-block; text-align: center">
                            <label> Pending </label> <br />
                            <div class="pie animate" style="--p:<%#Pending%>;--c:yellow; margin: 30px;"> <%# Pending %>% </div>
                        </div>
                        <div style="display:inline-block; text-align: center">
                            <label> Haven't finished </label> <br />
                            <div class="pie animate" style="--p:<%#Not_Finished%>;--c:red; margin: 30px; "> <%# Not_Finished %>% </div>
                        </div>
                    </div>
                <br />
            </ItemTemplate>
         </asp:Repeater>
    
    </form>
</body>
</html>
