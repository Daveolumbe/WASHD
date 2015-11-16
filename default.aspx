<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebProject._default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="title1" runat="server">
    WASHD
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" id="top-color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <button type="button" class="btn btn-primary-outline btn-md pull-right" data-toggle="modal" data-target="#myModal"><i class="fa fa-sign-in"></i> login</button>
                </div>
            </div>
            <div class="row">
                <div class="col-md-7" id="logosec">
                    <a href="default.aspx">
                        <img src="img/washd.png" class="img-responsive" width="300" alt="LOGO" /></a>
                </div>
                <div class="col-md-5" id="hide-content">
                    <img src="img/test.png" class="img-responsive" width="100%" alt="washd" />
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <!-- WELCOME MESSAGE -->
            <div class="col-md-7">
                <h1>Washd</h1>
                <p>
                    Providing the best car washing service, 100% reliable.
                </p>
            </div>
            <div class="col-md-5">
                <!-- SIGNUP FORM  -->
                <div class="form-group">
                    <asp:Label ID="displayMessage" CssClass="alert" runat="server" Text="Label" Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="fnametxt" for="fnametxt" runat="server" CssClass="form-control form-inline" placeholder="First name"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="RegGroup" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required" CssClass="alert alert-danger alert-dismissible fade in" ControlToValidate="fnametxt"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="lnametxt" runat="server" CssClass="form-control form-inline" placeholder="Last name" ></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="RegGroup" Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Last name is required" CssClass="alert alert-danger alert-dismissible fade in" ControlToValidate="lnametxt"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="emailtxt" runat="server" CssClass="form-control form-inline" placeholder="Email address" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="emailtxt" ValidationGroup="RegGroup" CssClass="alert alert-danger alert-dismissible fade in" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="emailtxt" ValidationGroup="RegGroup" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" CssClass="alert alert-danger alert-dismissible fade in" ErrorMessage="Please enter valid email address"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="passtxt" CssClass="form-control form-inline" TextMode="Password" runat="server" placeholder="Choose a password" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="Password must contain: Minimum 6 characters atleast 1 Alphabet and 1 Number" runat="server" CssClass="alert alert-danger alert-dismissible fade in" ControlToValidate="passtxt" ></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ValidationGroup="RegGroup" Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password is required" ControlToValidate="passtxt" CssClass="alert alert-danger alert-dismissible fade in"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="numbertxt" runat="server" CssClass="form-control form-inline" placeholder="Enter mobile number" TextMode="Phone" ></asp:TextBox>
                </div>
               <asp:Button ID="regBtn" name="submit" ValidationGroup="RegGroup" CssClass="btn btn-secondary-outline" OnClick="regBtn_Click" runat="server" Text="Signup for free" />
            </div>

        </div>
    </div>
    <!-- MODAL FOR LOGIN -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title text-center" id="myModalLabel"> <i class="fa fa-user fa-fw fa-3x"></i>&nbsp;</h4>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <asp:TextBox ID="txtemail" TextMode="Email" required CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="LogGroup" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="txtemail"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtpass" TextMode="Password" class="form-control" placeholder="password" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="loginBtn" CssClass="btn btn-secondary-outline form-control" ValidationGroup="LogGroup" OnClick="loginBtn_Click" runat="server" Text="LOGIN" />
                    <asp:Label ID="displaymsg" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times-circle fa-x4"></i></button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
