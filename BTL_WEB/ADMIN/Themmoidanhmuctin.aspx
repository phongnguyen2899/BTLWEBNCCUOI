<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/HeaderFooterAdmin.Master" AutoEventWireup="true" CodeBehind="Themmoidanhmuctin.aspx.cs" Inherits="BTL_WEB.ADMIN.Themmoidanhmuctin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../CSS/suatin.css" rel="stylesheet" />
    <link href="../CSS/reponsive.css" rel="stylesheet" />
	<style>
	 #themdanhmuc{
		 min-width:80px;
	 }
	</style>
    <form runat="server">
    <h1>Thêm Mới</h1>

				<div class="form">
					<div class="form-item">
						<label>Tên chủ đề</label>
						<input id="tenchude" type="text" runat="server" name="link">
					</div>
                    <asp:FileUpload ID="filedanhmuc" runat="server" />
				
					<div class="form-item">
						<label></label>
                        <asp:Button ID="Button1" class="update_tin"  runat="server" Text="Button" OnClick="Button1_Click" />
					</div>
				</div>
        </form>
</asp:Content>
