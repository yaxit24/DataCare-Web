<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PT_CASHREC.aspx.vb" Inherits="DcRemainder.PT_CASHREC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CashRec Print</title>
    <link href="assets/CSS/PT_CASHREC.css" rel="stylesheet" />
</head>
<body bgcolor="FFFFFF" topmargin="19">
    <form id="form1" style="width:90mm" runat="server">
        <div class="HeadName" style="text-align: center; padding-bottom: 20px;">Cash Recive Bill</div>
        <div class="line" style="width: 90mm; margin: auto;">
            <div class="codetail" style="width: 100mm; text-align: right;">
                <div class="coname">
                    <asp:Label ID="CoName" runat="server" Text=""></asp:Label>
                </div>
               <%-- <div class="VCHNO">
                    <asp:Label ID="Label5" runat="server" Text="Vch No:"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </div>--%>
                <div class="VCHDATE">
                    <asp:Label ID="Label6" runat="server" Text="Vch Date:"></asp:Label>
                    <asp:Label ID="VchDate" runat="server" Text=""></asp:Label>
                </div>
                <div class="vchtime">
                    <asp:Label ID="Label7" runat="server" Text="Time :"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

        <div class="line">
            <div class="AcDetile">
                <div class="coname">
                    <asp:Label ID="ACNAME" runat="server" Text=""></asp:Label>
                </div>
                <div class="VCHNO">
                    <asp:Label ID="VCHNO" runat="server" Text=""></asp:Label>
                </div>
                <div class="VCHDATE">
                    <asp:Label ID="ACMONO" runat="server" Text=""></asp:Label>
                </div>
               <%-- <div class="vchtime">
                    <asp:Label ID="Label13" runat="server" Text="ACOP :"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Text="11:30am"></asp:Label>
                </div>--%>
            </div>
        </div>
        <br />
        <div class="line" style="width: 90mm; margin: auto; margin-top: 50px;">
            <div class="codetail" style="width: 100mm; text-align: center; border:2px solid; margin-top: 50px;">
                <asp:Label ID="lbltotal" CssClass="RecAmt" ForeColor="Black" Font-Size="20px" runat="server" Text="Rec Amount :" ></asp:Label>
                <asp:Label ID="lblCashAmt" CssClass="RecAmt" runat="server" ></asp:Label>
                
            </div>
        </div>

        <div class="line" style="width: 90mm; margin: auto; margin-top: 10px;">
            <div class="codetail" style="width: 100mm; text-align: left; margin-top: 10px;">
                <asp:Label ID="Label1" CssClass="RecAmt" ForeColor="Black" Font-Size="16px" runat="server" Text="In Word :" ></asp:Label>

                <asp:Label ID="lblAmtWord" CssClass="AmtWord"  Font-Size="20px" runat="server" ></asp:Label>
                
            </div>
        </div>
        <br />
        

        <asp:Button ID="btnPrintExit" CssClass="btnExit" runat="server" Text="....Click Heare to Back...." />
    </form>
</body>
</html>
