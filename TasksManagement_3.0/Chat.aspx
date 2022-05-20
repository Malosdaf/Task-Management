<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="TasksManagement_3._0.Chat" %>

<!DOCTYPE html>
<link rel="stylesheet" href="/CSS/NavigationBar.css">
<link rel="stylesheet" href="/CSS/Chat.css">
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
        <div>
         <nav class="navbar nav-pills navbar-expand-sm bg-dark navbar-dark">
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
                          <a class="nav-link" href="Chat.aspx"  style="color:white"> Chat </a>
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
        </div>
        <div class="UserList">
            <b>
            <label> BOSS: </label> <br />
            <asp:Repeater runat="server" ID="BossMes">
                <ItemTemplate>
                    <a  style="        text-decoration: none;
        color: black;
    " href="Chat.aspx?ToE=<%# Eval("Boss") %>">
                        <div style="overflow:hidden" class="Name">
                            <%# Eval("Boss") %>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <label> INFERIOR: </label> <br />
            <asp:Repeater runat="server" ID="InfMes">
                <ItemTemplate>
                    <a  style="text-decoration: none; color:black; " href="Chat.aspx?ToE=<%# Eval("Email") %>">
                        <div style="overflow:hidden" class="Name">
                            <%# Eval("Email") %>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
               </b>
        </div>
        <div class="Message" style="overflow-y: scroll">
            <b>
            <div>
                <asp:Repeater runat="server" ID="ChatHistory">
                    <ItemTemplate>
                        <div class=<%# (Eval("FromE").ToString()==receiver) ? "MesYou" : "MesMe" %>>
                            <%# Eval("Message") %>
                        </div></br><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:TextBox runat="server" CssClass="MesText" ID="MesTxBox"></asp:TextBox>
            <asp:Button runat="server" Text="Send" ID="SendBtn" CssClass="SendBtn" OnClick="SendBtn_Click"></asp:Button>
                </b>
        </div>
    </form>
</body>
</html>
