<%@ Page Title="" Language="C#" MasterPageFile="~/pages.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="WebProject.booking" %>

<asp:Content ID="Content3" ContentPlaceHolderID="title1" runat="server">
    SCHEDULE CAR WASH
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="owneridtxt" runat="server" Visible="false" Text="Label"></asp:Label>
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <h4 class="">Start Booking Now<small> Please fill the form appropraitely</small></h4>
                <hr />
                  <div class="form-group">
                    <asp:Label ID="displayMessage" CssClass="alert" runat="server" Text="Label" Visible="false"></asp:Label>
                </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label">Car Model:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="modeltxt" required runat="server" class="form-control" placeholder="Mercedez Benz"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label">Registration:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="carregtxt" runat="server" required class="form-control text-uppercase" placeholder="GYU456PR"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-2">Services</label>
                    <div class="col-sm-10">
                        <div class="radio">
                            <label>
                                <asp:RadioButtonList ID="servicetxt" runat="server" required>
                                    <asp:ListItem Value="200">Exterior Wash, Glass Polish &amp; Tyres Dressed (£15.00 - 200 Points)</asp:ListItem>
                                    <asp:ListItem Value="400">Exterior Wash, Glass Polish, Tyres Dressed, Tar Spot Removal, (£18.00 - 300 Points)</asp:ListItem>
                                </asp:RadioButtonList>
                            </label>
                        </div>
                    </div>
                </div>
                <hr/>
                <div class="form-group row">
                    <label class="col-sm-2">DateTime:</label>
                    <div class="col-sm-10 controls input-append date form_datetime" data-date="2015-09-16T05:25:07Z" data-date-format="dd MM yyyy - HH:ii p" data-link-field="dtp_input1">
                        <asp:TextBox ID="datatimetxt" runat="server" class="form-control" placeholder="Choose Date & Time"></asp:TextBox>
                        <span class="add-on"><i class="icon-remove"></i></span><span class="add-on"><i class="icon-th"></i></span>
                    </div>
                    <input type="hidden" id="dtp_input1" class="form-control" value="" /><br />
                </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label">Location:</label>
                    <div class="col-sm-10">
                        <input type="text" class="controlss" name="locationtxt" id="pac-input" placeholder="39, James Bond Road SW16 17DE" />
                        <div id="map"></div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="bookBtn" runat="server" OnClick="bookBtn_Click" class="btn btn-danger-outline" Text="BOOK NOW" />
                        <asp:Button ID="resetBtn" runat="server" class="btn btn-danger" Text="RESET" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <h4 class="">Washd Records</h4>
                <hr />
                <ul class="list-group">
                    <li class="list-group-item">
                        <span class="label label-danger label-pill pull-right">
                            <asp:Label ID="Label1" runat="server" Text="0"></asp:Label></span>
                        Booking History
                    </li>
                    <li class="list-group-item">
                        <span class="label label-primary label-pill pull-right">
                            <asp:Label ID="pointstxt" runat="server" Text="Label"></asp:Label></span>
                        Wash Points
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
