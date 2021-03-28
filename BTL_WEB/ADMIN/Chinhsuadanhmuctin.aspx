<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/HeaderFooterAdmin.Master" AutoEventWireup="true" CodeBehind="Chinhsuadanhmuctin.aspx.cs" Inherits="BTL_WEB.ADMIN.Chinhsuadanhmuctin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../CSS/suatin.css" rel="stylesheet" />
    <link href="../CSS/reponsive.css" rel="stylesheet" />
	<style>
	 #themdanhmuc{
		 min-width:80px;
	 }
	 .anhcu{
		 max-width:100px;
	 }
	 .form-item-custom{
		 display:flex;
		 margin-top:10px;
	 }
	 .form-item-custom label{
		 font-weight:500;
		 min-width:109px;
	 }
	</style>
    <form runat="server">
    <h1>Thêm Mới</h1>

				<div class="form">
					<div class="form-item">
						<label>Tên chủ đề</label>
						<input id="tenchudecs" type="text" runat="server" name="link">
					</div>

					<div class="form-item-custom">
						<label>Ảnh</label>
						<asp:FileUpload ID="filedanhmuc" runat="server" />
						<img src="" id="anhcu" class="anhcu" runat="server" />
					</div>

                    
					<div class="form-item">
						<label></label>
                        <asp:Button ID="Button1" class="update_tin"  runat="server" Text="Button" OnClick="Button1_Click"/>
					</div>
				</div>
        </form>
</asp:Content>
