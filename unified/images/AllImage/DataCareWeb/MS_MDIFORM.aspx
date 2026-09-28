<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MS_MDIFORM.aspx.vb" Inherits="DcRemainder.MS_MDIFORM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DATACARE SOFTECH</title>
    <link href="assets/CSS/MS_MDIFORM.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
    <div class="card">
        <div class="mid">
            <div class="iconline">
                <div class="icon">
                    <div class="lo">
                        <asp:ImageButton ID="MS_PARTY_MASTER" class="imgtop" src="assets/image/people.png" runat="server" />
                    </div>
                     <label class="iconlbl"> Party Master </label>
                </div>
                <div class="icon">
                     <div class="lo">
                         <asp:ImageButton ID="btnEstimate" class="imgtop" src="assets/image/estimate.png" runat="server" />
                    </div>
                     <label class="iconlbl"> Estimate </label>
                    
                </div>
                <div class="icon">
                     <div class="lo">
                        <asp:ImageButton ID="btnTrSale" class="imgtop" src="assets/image/shopping-store.png" runat="server" />
                    </div>
                     <label class="iconlbl"> Sales </label>
                </div>
                <div class="icon">
                   <div class="lo">
                       <asp:ImageButton ID="btnTrWhSale" class="imgtop" src="assets/image/wholesaler.png" runat="server" />
                       
                    </div>
                     <label class="iconlbl"> Wh Sales </label>
                </div>

                <!-- ===================  2nd Row ==========--> 

                 <div class="icon">
                    <div class="lo">
                         <asp:ImageButton ID="btnTrOrder" class="imgtop" src="assets/image/choices.png" runat="server" />
                    </div>
                     <label class="iconlbl"> Order Master </label>
                </div>
                <div class="icon">
                     <div class="lo">
                         <asp:ImageButton ID="btnTagReport" class="imgtop" src="assets/image/choices.png" runat="server" />
                    </div>
                     <label class="iconlbl"> Tag Report</label>
                    
                </div>
                <div class="icon">
                     <div class="lo">
                        <asp:ImageButton ID="ImageButton3" class="imgtop" src="assets/image/shopping-store.png" runat="server" />
                    </div>
                     <label class="iconlbl"> soon.. </label>
                </div>
                <div class="icon">
                   <div class="lo">
                       <asp:ImageButton ID="ImageButton4" class="imgtop" src="assets/image/wholesaler.png" runat="server" />
                       
                    </div>
                     <label class="iconlbl"> soon.. </label>
                </div>
                

            </div>

            <!--=============long buton mate===============-->
            <div class="longbtn">
                <div class="longicon">
                    <div class="longbtnicon">
                        <asp:ImageButton ID="btnNotification" class="imgbottom" src="assets/image/notification.png" runat="server" />
                        <label class="longiconlbl-Main"> User Request </label>
                        <asp:Label ID="Notification" runat="server" class="longiconlbl-Notif" Text="Label"></asp:Label>
                        
                    </div>
                </div>
                <div class="longicon">
                    <div class="longbtnicon">
                        <asp:ImageButton ID="btnCashRec" class="imgbottom" src="assets/image/payment.png" runat="server" />
                        
                        <label class="longiconlbl-Main"> Cash Recive </label>
                        
                    </div>
                </div>
                <div class="longicon">
                   <div class="longbtnicon">
                        <asp:ImageButton ID="btnBankRec" class="imgbottom" src="assets/image/bank.png" runat="server" />
                        
                        <label class="longiconlbl-Main"> Bank Recive </label>
                        
                    </div>
                </div>
                <div class="longicon">
                    <div class="longbtnicon">
                        <img class="imgbottom" src="assets/image/reminder.png" />
                        <label class="longiconlbl-Main"> Remainder Entry </label>
                        
                    </div>
                </div>
                <div class="longicon">
                    <div class="longbtnicon">
                        <asp:ImageButton ID="btnLDR_Report" class="imgbottom" src="assets/image/document.png" runat="server" />
                        
                        <label class="longiconlbl-Main"> Ledr Report</label>
                        
                        
                    </div>
                </div>
                <div class="longicon">
                    <div class="longbtnicon">
                        
                        <img class="imgbottom" src="assets/image/statistics.png" />
                        <label class="longiconlbl-Main"> Sales Report </label>
                        
                    </div>
                </div>
            </div>
        </div>
        <div class="top">
            <div class="coHead">
            <asp:Label ID="CONAME" runat="server" CssClass="HeadName" Text=""></asp:Label>
            </div>
            <div class="coHead">
            <asp:Label ID="UserName" runat="server"  CssClass="HeadName" Text=""></asp:Label>
            </div>
        </div>

        <div class="bottom">
            <img class="left-buttom" src="assets/image/home.png" />
            <img class="mid-buttom" src="assets/image/email.png" />
            <img class="right-buttom" src="assets/image/user.png" />
        </div>
    </div>
        </form>
</body>
</html>
