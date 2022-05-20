<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskView.aspx.cs" Inherits="TasksManagement_3._0.TaskView" %>

<!DOCTYPE html>
<link rel="stylesheet" href="/CSS/NavigationBar.css">
<link rel="stylesheet" href="/CSS/TaskView.css">


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
        <div style="display: flex;
        flex-direction: row;
        width: 100%;
        height: 90vh;
        padding: 4px;
        gap: 8px;
        background-color: #4648664f;
        backdrop-filter: blur(8px);
    ">
        <div class="Yourtasks">
            <label> MANAGE YOUR TASKS: </label>
            <br />
            <asp:Repeater runat="server" id="YourTasksNoti">
                <ItemTemplate>
                    <a href="TaskConfirm.aspx?ID=<%#Eval("Id")%>" style="text-decoration: none; color:black">
                        <div class="Tasks">
                            <label> <%#Eval("Name")%> </label> <br />
                            <label style="font-size:75%; color:gray;"> to <%#Eval("ToE")%> </label> <br />
                            <asp:Label ID="Status" Font-Size="XX-Small" runat="server" ForeColor=<%# dicStatusColor[Eval("Id").ToString()] %>> <%# dicStatusTxt[Eval("Id").ToString()] %></asp:Label>
                        
                            </br>
                            <label style="color: chartreuse; font-size:8px"> <%#Eval("Percentage")%> % </label>
                            <div style='width: <%#Eval("Percentage")%>%; height: 1px; background-color:chartreuse'></div> 
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
         <div class="Yourtasks">
            <label> TO DO: </label>
             <br />
             <asp:Repeater runat="server" id="ToDoNoti">
                <ItemTemplate>
                    <a href="Task.aspx?ID=<%#Eval("Id")%>" style="text-decoration: none; color:black">
                        <div class="Tasks">
                            <label> <%#Eval("Name")%> </label> <br />
                            <label style="font-size:75%; color:gray;"> from <%#Eval("FromE")%> </label> <br />
                            <asp:Label ID="Status" Font-Size="XX-Small" runat="server" ForeColor=<%# dicStatusColor[Eval("Id").ToString()] %>> <%# dicStatusTxt[Eval("Id").ToString()] %></asp:Label>
                            </br>
                            <label style="color: chartreuse; font-size:8px"> <%#Eval("Percentage")%> % </label>
                            <div style='width: <%#Eval("Percentage")%>%; height: 1px; background-color:chartreuse'></div> 
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
            </div>
    </form>
</body>
</html>
