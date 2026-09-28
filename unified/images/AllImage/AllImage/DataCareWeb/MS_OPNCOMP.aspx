<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MS_OPNCOMP.aspx.vb" Inherits="DcRemainder.MS_OPNCOMP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <%--<meta name="viewport" content="width=1024">--%>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="icon" type="image/png" href="assets/image/lg.png">
    <title>DataCare Softech OrderApp
    </title>

    <!--     Fonts and icons  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">   -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
    <link id="pagestyle" rel="stylesheet" href="assets/CSS/MS_LOGIN.css" />
</head>
<body>
    <div class="year-box">

        <form role="form" runat="server">
            <label class="lbl">Company</label>

            <div class="col-4">
                <div class="drop-icons">
                    <asp:DropDownList ID="cboCompany" runat="server" AutoPostBack="True" class="drop" DataTextField="CO_CODE" DataValueField="CO_CODE" AppendDataBoundItems="true" />
                </div>
            </div>
            <label class="lbl">Branch</label>
            <div class="col-4 ">
                <div class="drop-icons">
                    <asp:DropDownList ID="cboLc" class="drop" runat="server" AppendDataBoundItems="true" DataTextField="CO_YEAR" DataValueField="LC_CODE" TabIndex="1" />
                </div>
            </div>
            <label class="lbl">Financial Year</label>
            <div class="col-4">
                <div class="drop-icons">
                    <asp:DropDownList ID="cboYear" class="drop" runat="server" AppendDataBoundItems="true" DataTextField="LCCODE" DataValueField="CO_YEAR" TabIndex="2" />
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="COSELECT" runat="server" Text="SUBMIT" class="loginbtn" TabIndex="3" />
            </div>
            </form>
    </div>
</body>
</html>
