<%@ Page Title="" Language="C#" MasterPageFile="~/pages.Master" AutoEventWireup="true" CodeBehind="cancel.aspx.cs" Inherits="WebProject.cancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h4 class="">Cancel your booking<small> </small></h4>

                <hr />

                <asp:Label ID="ownid" runat="server" Text='<%#Eval("ownerID")%>'></asp:Label>
                <asp:Label ID="Label5" Visible="false" ForeColor="Yellow" BackColor="Teal" runat="server" Text="Label"></asp:Label>
                <div class="table-responsive">
                    <asp:DataList ID="Booking" DataKeyField="id" CssClass="col-md-12" OnDeleteCommand="Booking_DeleteCommand" runat="server">
                        <HeaderTemplate>
                            <table class="table">
                                <tr>
                                    <th>MODEL</th>
                                    <th>REG. NUMBER</th>
                                    <th>DATE & TIME</th>
                                    <th>LOCATION</th>
                                    <th>CANCEL</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("carModel")%>' /></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("regNumber")%>' /></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("dateandtime")%>' /></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("location")%>' /></td>
                                <td>
                                    <asp:LinkButton ID="edit" CssClass="btn btn-danger" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id")%>'>CANCEL</asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate></table></FooterTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
