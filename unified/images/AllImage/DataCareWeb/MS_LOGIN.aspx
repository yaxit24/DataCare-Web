<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MS_LOGIN.aspx.vb" Inherits="DcRemainder.MS_LOGIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <%--<meta name="viewport" content="width=1024"/>--%>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link rel="icon" type="image/png" href="assets/image/lg.png"/>
    <title>DataCare Softech OrderApp
    </title>

    <!--     Fonts and icons   <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">  -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <link rel="stylesheet" href="font-awesome/css/font-awesome.css" />
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
    <link id="pagestyle" rel="stylesheet" href="assets/CSS/MS_LOGIN.css" />
</head>
<body>
    <div class="login-box">
            <img src="assets/image/pd.png" />
            <form runat="server">
                <div class="col-3">
                    <div class="input-icons">
                       <label class="lbl"> UserName</label>
                        <asp:TextBox ID="USERNAME" type="Text"  runat="server" autocomplete="off" placeholder="" />
                        <span class="focus-border">
                            <i></i>
                        </span>
                    </div>
                </div>
                <div class="col-3">
                    <div class="input-icons">
                        <label class="lbl">Password</label>
                        <asp:TextBox ID="PASSWORD" type="password"  runat="server" autocomplete="off" placeholder="" Wrap="False" />
                        <span class="focus-border">
                            <i></i>
                        </span>
                    </div>
                </div>
                <div>
                    <asp:Button ID="button" runat="server" Text="LOGIN" class="loginbtn" />
                </div>
            </form>
        </div>
</body>
</html>
