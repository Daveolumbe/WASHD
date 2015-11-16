<%@ Page Title="" Language="C#" MasterPageFile="~/pointssales.Master" AutoEventWireup="true" CodeBehind="buypoints.aspx.cs" Inherits="WebProject.buypoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
    POINTS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
          <h4 class="">Buy Wash Points<small>....</small></h4>
                <hr />
        <input type="hidden" name="cmd" value="_s-xclick" />
        <input type="hidden" name="hosted_button_id" value="VU62LNVWJKFJQ" />
        <table>
            <tr>
                <td>
                    <input type="hidden" name="on0" value="Select Points" />Select Points</td>
            </tr>
            <tr>
                <td>
                    <select name="os0" class="form-control">
                        <option value="Exterior Washing (200 Points)">Exterior Washing (200 Points) £0.10 GBP</option>
                        <option value="Exterior Washing Plus (300 Points)">Exterior Washing Plus (300 Points) £0.15 GBP</option>
                    </select>
                </td>
            </tr>
        </table>
        <br />
        <input type="hidden" name="currency_code" value="GBP" />
        <input type="image" class="btn btn-warning btn-lg" src="https://www.paypalobjects.com/en_GB/i/btn/btn_buynow_LG.gif" border="0" name="submit" alt="PayPal – The safer, easier way to pay online." />
        <img alt="" border="0" src="https://www.paypalobjects.com/en_GB/i/scr/pixel.gif" width="1" height="1" />
    </div>
</asp:Content>
