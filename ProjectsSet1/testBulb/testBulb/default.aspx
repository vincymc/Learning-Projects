<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="testBulb._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link href="style.css" rel="stylesheet" />
    <script>
        function myFunction() {
            document.getElementsByClassName("topnav")[0].classList.toggle("responsive");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="col-12 header"><h1>Bulbs.com</h1></div>
        <div class="col-12">
            <ul class="topnav">
                    <li><a href="#">Item 1</a></li>
                    <li><a href="#">Item 2</a></li>
                    <li><a href="#">Item 3</a></li>
                <li class="icon">
                    <a onclick="myFunction()">☰</a>
                </li>
             </ul>
        </div>
        <div class="row">
            <div class="col-2 menu" >
                <ul>
                    <li>Item 1</li>
                    <li>Item 2</li>
                    <li>Item 3</li>
                </ul>
            </div>
            <div class="col-7">Main</div>
            <div class="col-3">Aside</div>
        </div>
        <div class=" col-12 footer"><h1>Bulbs.com</h1></div>
    </div>
    </form>
</body>
</html>
