<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TasksManagement_3._0.CompanyHome" %>
<!DOCTYPE html>
<link rel="stylesheet" href="/CSS/NavigationBar.css">
<link rel="stylesheet" type="text/css" href="/CSS/Home.css">
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
                        <a class="nav-link" href="Home.aspx" style="color:white">Home</a>
                     </li>
                     <li class="nav-item">
                        <a class="nav-link" href="NewTask.aspx">New Task</a>
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
         <div >
            <asp:Repeater runat="server" id="RepNotification" OnItemCommand="RepNotification_ItemCommand">
               <ItemTemplate>
                  <div class="noti">
                     <label ><%#Eval("Content")%></label>  
                     <asp:LinkButton runat="server" CssClass="AcDnBt" Text="Deny" CommandArgument='<%# Eval("NotiID") %>' OnClick="DenyBt_Click"> </asp:LinkButton>
                     <asp:LinkButton runat="server" CssClass="AcDnBt" Text="Accept" CommandArgument='<%# Eval("NotiID") %>' OnClick="AcceptBt_Click"> </asp:LinkButton>
                  </div>
               </ItemTemplate>
            </asp:Repeater>
         </div>
      </form>
      <p>
         &nbsp;
      </p>
   </body>
</html>