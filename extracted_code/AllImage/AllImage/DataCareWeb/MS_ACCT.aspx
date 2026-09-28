<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MS_ACCT.aspx.vb" Inherits="DcRemainder.MS_ACCT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/CSS/MS_ACCT.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="mid">
                <div class="iconline">
                    <div class="icon">
                        <div class="mainline">
                            <div class="top">
                            <label class="toplbl">Party Master </label>
                        </div>
                            

                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">AC Code </label>
                            <asp:TextBox ID="tAcCode" CssClass="textbox" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">AC Name </label>
                            <asp:TextBox ID="tAcName" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">AC Group </label>
                            <asp:DropDownList ID="cboAcGrCode" CssClass="drop" runat="server" AutoPostBack="True"
                                DataTextField="AC_CITY" DataValueField="AC_CITY" AppendDataBoundItems="true">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">Mobile NO </label>
                            <asp:TextBox ID="tMobile" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">Address 1 </label>
                            <asp:TextBox ID="tAddress1" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">Address 2 </label>
                            <asp:TextBox ID="tAddress2" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">Address3 </label>
                            <asp:TextBox ID="tAddress3" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">Area </label>
                             <asp:DropDownList ID="Aeria" CssClass="drop" runat="server" AutoPostBack="True"
                                        DataTextField="AC_CITY" DataValueField="AC_CITY" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">City </label>
                            <asp:DropDownList ID="cboCity"  CssClass="drop" runat="server" AutoPostBack="True"
                                        DataTextField="AC_CITY" DataValueField="AC_CITY" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">PinCode </label>
                            <asp:TextBox ID="tPinCode" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">GST NO </label>
                            <asp:TextBox ID="tGstNo" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">State </label>
                           <asp:DropDownList ID="cboState"  CssClass="drop" runat="server" AutoPostBack="True"
                                                 AppendDataBoundItems="true">
                                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <label class="acclbl">District </label>
                            <asp:DropDownList ID="cboDist"  CssClass="drop" runat="server" AutoPostBack="True"
                                                 AppendDataBoundItems="true">
                                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <asp:Button ID="btnSave" CssClass="textbox" runat="server" Text="SAVE" />
                        </div>
                    </div>
                    <div class="icon">
                        <div class="mainline">
                            <asp:Button ID="btnCancle" CssClass="textbox" runat="server" Text="Cancle" />
                        </div>
                    </div>

                </div>
            </div>
            <div class="bottom">
                <asp:ImageButton ID="btnMsHome" class="left-buttom" src="assets/image/home.png" runat="server" />
                <asp:ImageButton ID="btnMsNoti" class="mid-buttom" src="assets/image/email.png" runat="server" />
                <asp:ImageButton ID="btnMsUs" class="right-buttom" src="assets/image/user.png" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
