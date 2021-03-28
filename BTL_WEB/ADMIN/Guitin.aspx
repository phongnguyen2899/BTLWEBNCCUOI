<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/HeaderFooterAdmin.Master" AutoEventWireup="true" CodeBehind="Guitin.aspx.cs" Inherits="BTL_WEB.ADMIN.Guitin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../CSS/suatin.css" rel="stylesheet" />
    <link href="../CSS/reponsive.css" rel="stylesheet" />
    <style>
        .list-checkbox{
            display:flex;
            flex-flow:column;
            width:200px;
            margin-left:90px;
        }       
        .checkbox-item input{
            float:left;
        }

        .form-item-fix{
            display:block;
        }
        #myProgress {
          width: 100%;
          background-color: #ddd;
          margin-right:10px;
        }

        #myBar {
          width: 0%;
          height: 20px;
          background-color: #4CAF50;
        }
        .bar{
            width:50%;
            height:20px;
            margin-top:10px;
        }
        .update_tin{
            width:100%;
        }
    </style>
    <form runat="server" method="post" action="GuitinAjax.aspx">
    <h1>Gửi Tin</h1>

				<div class="form">
					<div class="form-item">
						<label>Link</label>
						<input id="link" type="text" name="link">
					</div>
					<div class="form-item">
						<label>Mô Tả</label>
						<input type="text" name="">
					</div>
					<div class="form-item form-item-fix">
						<label>Nhóm Tin</label>
                        <br />
						<div runat="server" id="list_checkbox" class="list-checkbox">
                            <div class="checkbox-item">
                                <input type="checkbox" />
                                <label>Y tế</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" />
                                <label>Y tế</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" />
                                <label>Y tế</label>
                            </div>
						</div>
					</div>

					<div class="form-item">
						<label></label>
                        <button class="update_tin" id="a" type="button" value="insert">Gửi</button>
					</div>
                    <div class="bar">
                        <div id="myProgress">
                        <div id="myBar"></div>
                    </div>
				</div>
        </form>
			
    </div>		
        

    <script>
        var i = 0;
        function move() {
          if (i == 0) {
            i = 1;
            var elem = document.getElementById("myBar");
            var width = 1;
            var id = setInterval(frame, 10);
            function frame() {
              if (width >= 100) {
                clearInterval(id);
                i = 0;
              } else {
                width++;
                elem.style.width = width + "%";
              }
            }
          }
        }
      
   /*
        document.getElementById('a').onclick = function (e) {

            var checkedValue = null; 
            var inputElements = document.getElementsByClassName('nhom');
            for(var i=0; inputElements[i]; ++i){
              if(inputElements[i].checked){
                   checkedValue = inputElements[i].value;
                  console.log(checkedValue)
              }
}

            e.preventDefault();
        }*/
        /*
        var data = {a:"1",b:"2"}
        document.getElementById('a').onclick = function () {
            fetch("Guitin.aspx/num", {
                method: "POST",
                headers: {
      'Content-Type': 'application/json'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
                body: JSON.stringify(data)
            }).then(response => response.text()).then(function (data) { console.log(data) })
        }*/

        function callback(tang) {
            process = process + tang;
            var elem = document.getElementById("myBar");
                      elem.style.width = process + "%";
        }
        var process = 0;
         var url = document.querySelector("input[name=link]");
        function sendsmsajax(id) {

            fetch("Guitin.aspx/sendmail", {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ nhom: id, url: url.value })
            })
                .then(response => response.text()).then(function (data) {
                    process = process + phan;
                    var elem = document.getElementById("myBar");
                      elem.style.width = process + "%";
                })
        }
        var phan = 0;
        document.getElementById('a').onclick = function (e) {
            process = 0;
            var dem = 0;
             var checkedValue = null; 
            var inputElements = document.getElementsByClassName('nhom');
            for (var j = 0; inputElements[j]; ++j) {
                if (inputElements[j].checked) {
                    dem++;
                }
            }
            phan = 100 / dem;
            for(var i=0; inputElements[i]; ++i){
              if(inputElements[i].checked){
                   checkedValue = inputElements[i].value;
                  //console.log(checkedValue)
                  sendsmsajax(checkedValue)
                 
              }
            }
            e.preventDefault();
        }

    </script>
</asp:Content>

