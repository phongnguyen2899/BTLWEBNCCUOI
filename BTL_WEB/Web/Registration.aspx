<%@ Page Title="" Language="C#" MasterPageFile="~/Web/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BTL_WEB.Web.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="div_textmail">
            <label for="mail">Your Email</label>
            <asp:TextBox ID="mail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div class="div_textmail">
            <label for="mail">Your Name</label>
            <asp:TextBox ID="txtName" runat="server" TextMode="SingleLine"></asp:TextBox>
        </div>
        <div class="moi">
            <h1>Bạn muốn cập nhật thông tin mới nhất?</h1>
        </div>
        <div class="hehe">
            <p> Hãy lựa chọn các mục tin bên dưới để nhật tin tức về mail hằng ngày nhé!</p>
        </div>
        <div class="checkbox_div">
            <asp:ListView ID="List_categoties" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <asp:CheckBox ID="cb1" runat="server" value='<%# Eval("Id") %>' />
                        <label class="label_card" for="ContentPlaceHolder1_List_categoties_cb1_<%# Eval("index") %>">
                            <img src="/ADMIN/Image/<%# Eval("img") %>" />
                            <label class="label_cate"><%# Eval("Tenchude") %></label>
                        </label>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>
    
            <asp:Button CssClass="btnSubmit" Text="Submit" runat="server" OnClick="Submit" />

      
    </div>
</asp:Content>
