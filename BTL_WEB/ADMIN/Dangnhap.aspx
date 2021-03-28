﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dangnhap.aspx.cs" Inherits="BTL_WEB.ADMIN.Dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
      background: #e9e9e9;
      color: #666666;
      font-family: 'RobotoDraft', 'Roboto', sans-serif;
      font-size: 14px;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
    }
 
 
    /* Form Module */
    .form-module {
      position: relative;
      background: #ffffff;
      max-width: 320px;
      width: 100%;
      border-top: 5px solid #33b5e5;
      box-shadow: 0 0 3px rgba(0, 0, 0, 0.1);
      margin: 0 auto;
    }
    .form-module .toggle {
      cursor: pointer;
      position: absolute;
      top: -0;
      right: -0;
      background: #33b5e5;
      width: 30px;
      height: 30px;
      margin: -5px 0 0;
      color: #ffffff;
      font-size: 12px;
      line-height: 30px;
      text-align: center;
    }
    .form-module .toggle .tooltip {
      position: absolute;
      top: 5px;
      right: -65px;
      display: block;
      background: rgba(0, 0, 0, 0.6);
      width: auto;
      padding: 5px;
      font-size: 10px;
      line-height: 1;
      text-transform: uppercase;
    }
    .form-module .toggle .tooltip:before {
      content: '';
      position: absolute;
      top: 5px;
      left: -5px;
      display: block;
      border-top: 5px solid transparent;
      border-bottom: 5px solid transparent;
      border-right: 5px solid rgba(0, 0, 0, 0.6);
    }
    .form-module .form {
      display: none;
      padding: 40px;
    }
    .form-module .form:nth-child(2) {
      display: block;
    }
    .form-module h2 {
      margin: 0 0 20px;
      color: #33b5e5;
      font-size: 18px;
      font-weight: 400;
      line-height: 1;
    }
    .form-module input {
      outline: none;
      display: block;
      width: 100%;
      border: 1px solid #d9d9d9;
      margin: 0 0 20px;
      padding: 10px 15px;
      box-sizing: border-box;
      font-wieght: 400;
      -webkit-transition: 0.3s ease;
      transition: 0.3s ease;
    }
    .form-module input:focus {
      border: 1px solid #33b5e5;
      color: #333333;
    }
    .form-module button {
      cursor: pointer;
      background: #33b5e5;
      width: 100%;
      border: 0;
      padding: 10px 15px;
      color: #ffffff;
      -webkit-transition: 0.3s ease;
      transition: 0.3s ease;
    }
    .form-module button:hover {
      background: #178ab4;
    }
    .form-module .cta {
      background: #f2f2f2;
      width: 100%;
      padding: 15px 40px;
      box-sizing: border-box;
      color: #666666;
      font-size: 12px;
      text-align: center;
    }
    .form-module .cta a {
      color: #333333;
      text-decoration: none;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form">
            <div class="module form-module">
                <div class="toggle">
                    <i class="fa fa-times fa-pencil"></i>
                </div>
                <div class="form">
                    <h2>Login to your account</h2>
                    <form>
                        <input type="text" id="username" runat="server" placeholder="Username" />
                        <input type="password" id="password" runat="server" placeholder="Password" />
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
                    </form>
                </div>
               
                <div class="cta"><a href="https://www.thuthuatweb.net/">Forgot your password?</a></div>
            </div>
        </div>
    </form>
</body>
</html>
