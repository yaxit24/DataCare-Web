<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TR_BANKREC.aspx.vb" Inherits="DcRemainder.TR_BANKREC" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/CSS/TR_BANKREC.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server" enctype="multipart/form-data" >
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="card">
                    <div class="mid">
                        <div class="iconline">
                            <div class="icon">
                                <div class="top">
                                    <label class="toplbl">Bank Recive </label>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Vch No </label>
                                    <asp:TextBox ID="tVchNo" CssClass="textbox" Width="20%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="tVchDate" CssClass="textbox" Width="53%" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>

                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Ac Name </label>
                                    <asp:TextBox ID="tAcCode" onkeyup="ACCODECOUNT()" CssClass="textbox" Width="20%" runat="server" autocomplete="off" ></asp:TextBox>
                                    <asp:TextBox ID="tAcName" CssClass="textbox" Width="53%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Cheq NO </label>
                                    <asp:TextBox ID="nCheqNo" CssClass="textbox" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Bank Rec </label>
                                    <asp:TextBox ID="nBankAMTRec" CssClass="textbox" onfocus="this.select();" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Charges </label>
                                    <asp:TextBox ID="nCharges" CssClass="textbox" onfocus="this.select();" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Kasar </label>
                                    <asp:TextBox ID="nKasar" CssClass="textbox" onfocus="this.select();" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">EMP Name</label>
                                    <asp:TextBox ID="tEmpCode" CssClass="textbox" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                           
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Remark</label>
                                    <asp:TextBox ID="tRemark" CssClass="textbox" runat="server" autocomplete="off" maxlength="30"></asp:TextBox>
                                </div>
                            </div>

                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">BankName</label>
                                    <asp:TextBox ID="tBankName" CssClass="textbox" runat="server" autocomplete="off" maxlength="30"></asp:TextBox>
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
                            <div class="icon">
                                <div class="mainline">
                                    <asp:Button ID="btnPrint" CssClass="textbox" runat="server" Text="Print" />
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <asp:Button ID="btnDelete" CssClass="textbox" runat="server" Text="Delete" />
                                </div>
                            </div>
                            
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>

                            <!--===================Acc Help Popup==================-->

                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="Label1" PopupControlID="modalpan" runat="server">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="modalpan" runat="server" Style="width: 900px; height: 350px; position: relative; margin-top: -31%;">
                                <div style="overflow: scroll; background-color: white; padding: 2px;">
                                    <div class="d-searchbox">
<%--                                        <input id="btnPartyMasterSearch" onkeyup="myFunction()" placeholder="SEARCH  NAME - MOBILE" width="100%" class="serch-input" type="text" text="SEARCH  NAME - MOBILE" />--%>
                                            <asp:TextBox ID="btnPartyMasterSearch" onfocus="this.setSelectionRange(this.value.length, this.value.length);" MaxLength="15" onkeyup="myFunction()" CssClass="serch-input" Width="70%" runat="server" placeholder="SEARCH  NAME - MOBILE" class="serch-input" type="text" Text="SEARCH  NAME - MOBILE" autocomplete="off"></asp:TextBox>

                                    </div>
                                    <div class="hlp-main">
                                        <div class="hlpgrid">
                                            <div class="hlp-gv">
                                                <asp:GridView ID="AccHelpGrid" runat="server" ShowFooter="false" AutoGenerateColumns="false" ShowHeaderFilterButton="true" HeaderStyle-Font-Bold="true" OnRowDataBound="AcchelpRowDataBound" OnSelectedIndexChanged="AcchelpSelectedIndexChanged" Font-Bold="False" AutoPostBack="true" Font-Italic="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="AC_CODE" HeaderText="Ac Code" ItemStyle-Width="150" />
                                                        <asp:BoundField DataField="AC_NAME" HeaderText="Ac Name" ItemStyle-Width="450" />
                                                        <asp:BoundField DataField="AC_MOBILE" HeaderText="Ac Mobile" ItemStyle-Width="200" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="bottom">

                        <asp:ImageButton ID="btnMsHome" class="left-buttom" src="assets/image/home.png" runat="server" />
                        <asp:ImageButton ID="btnMsNoti" class="mid-buttom" src="assets/image/email.png" runat="server" />
                        <asp:ImageButton ID="btnMsUs" class="right-buttom" src="assets/image/user.png" runat="server" />
                    </div>
                </div>

                <script>
                    function myFunction() {
                        var A = document.getElementById("btnPartyMasterSearch").value.length;
                        if (A < 1) {
                            document.getElementById("<%= btnACFIRE.ClientID %>").click();
                        }
                        var letterNumber = /[^0-9]/;
                        var input, filter, table, tr, td, i, txtValue;
                        input = document.getElementById("btnPartyMasterSearch");
                        filter = input.value.toUpperCase();
                        table = document.getElementById("AccHelpGrid");
                        tr = table.getElementsByTagName("tr");
                        for (i = 0; i < tr.length; i++) {
                            if (input.value.match(letterNumber)) {
                                td = tr[i].getElementsByTagName("td")[1];
                            }
                            else {
                                td = tr[i].getElementsByTagName("td")[2];
                            }
                            if (td) {
                                txtValue = td.textContent || td.innerText;
                                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = "";
                                } else {
                                    tr[i].style.display = "none";
                                }
                            }
                        }
                    }
                </script>
                <script type="text/javascript">
                    function ACCODECOUNT() {
                        var i = document.getElementById("tAcCode").value.length;

                        if (i == 2) {
                            document.getElementById("<%= btnACFIRE.ClientID %>").click();
                        }
                    }
                </script>
                <asp:Button ID="btnACFIRE" CssClass="btnFireAcCode" BackColor="White" Width="0px" runat="server" Text="" Visible="true" />

                
            </ContentTemplate>
            <%--<Triggers>
                <asp:PostBackTrigger ControlID="BtnGridFill" />
            </Triggers>--%>
        </asp:UpdatePanel>
    </form>
</body>
</html>
