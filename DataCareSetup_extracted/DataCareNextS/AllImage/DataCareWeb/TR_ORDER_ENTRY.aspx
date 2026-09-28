<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="TR_ORDER_ENTRY.aspx.vb" Inherits="DcRemainder.TR_ORDER_ENTRY" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/CSS/TR_ORDER_ENTRY.css" rel="stylesheet" />
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
                                    <label class="toplbl">Order Entry </label>
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
                                    <asp:TextBox ID="tAcCode" CssClass="textbox" Width="20%" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                    <asp:TextBox ID="tAcName" CssClass="textbox" Width="53%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Item Name </label>
                                    <asp:TextBox ID="tItCode" CssClass="textbox" Width="20%" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                    <asp:TextBox ID="tItName" CssClass="textbox" Width="53%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Design No </label>
                                    <asp:TextBox ID="tDesignNo" CssClass="textbox" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Pcs </label>
                                    <asp:TextBox ID="nPcs" CssClass="textbox" TextMode="Number" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">GrWt </label>
                                    <asp:TextBox ID="nGrWt" CssClass="textbox" CausesValidation="true" Width="27%" runat="server" AutoPostBack="true" OnTextChanged="Value_TextChanged" autocomplete="off"></asp:TextBox>

                                    <label class="Midacclbl">NetWt </label>
                                    <asp:TextBox ID="nNetWt" CssClass="Midtextbox" CausesValidation="true" Width="27%" runat="server" AutoPostBack="true" OnTextChanged="Value_TextChanged" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>

                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Touch </label>
                                    <asp:TextBox ID="nTouch" CssClass="textbox" CausesValidation="true" Width="27%" TextMode="Number" AutoPostBack="true" OnTextChanged="Value_TextChanged" runat="server" autocomplete="off"></asp:TextBox>

                                    <label class="Midacclbl">Fine </label>
                                    <asp:TextBox ID="nFine" CssClass="Midtextbox" CausesValidation="true" Width="27%" TextMode="Number" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Remark</label>
                                    <asp:TextBox ID="tRemark" CssClass="textbox" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>


                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Photo</label>
                                    <input type="file" class="textbox fileSelect" name="FileUpload" />
                                </div>
                            </div>

                            <div class="icon">
                                <div class="mainline">
                                    <asp:Button ID="BtnGridFill" CssClass="textbox" runat="server" Text="Add Item" />
                                </div>
                            </div>
                            
                            <div class="icon">
                                <div class="mainline">
                                    <div class="oth-main">
                                        <div class="grid">
                                            <div class="oth-gv">
                                                <asp:GridView ID="DGV" runat="server" ShowFooter="true" AutoGenerateColumns="False" ShowHeaderFilterButton="true" HeaderStyle-Font-Bold="true" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" Font-Bold="False" AutoPostBack="true" Font-Italic="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="cSrNo" ItemStyle-CssClass="cSrNo" HeaderText="Sr" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cDesignNo" ItemStyle-CssClass="cDesignNo" HeaderText="DesignNo" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cItCode" ItemStyle-CssClass="cItCode" HeaderText="ItCode" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cItName" ItemStyle-CssClass="cItName" HeaderText="ItemName" Visible="False"></asp:BoundField>
                                                        <asp:BoundField DataField="cPcs" ItemStyle-CssClass="cPcs" HeaderText="Pcs" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cGrwt" ItemStyle-CssClass="cGrwt" HeaderText="Grwt" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cNetWt" ItemStyle-CssClass="cNetWt" HeaderText="NetWt" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cTouch" ItemStyle-CssClass="cTouch" HeaderText="Touch" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cFine" ItemStyle-CssClass="cFine" HeaderText="Fine" Visible="true"></asp:BoundField>
                                                        <asp:BoundField DataField="cImage" ItemStyle-CssClass="cImage" HeaderText="Image" Visible="false"></asp:BoundField>
                                                        <asp:BoundField DataField="cItDesc" ItemStyle-CssClass="cItDesc" HeaderText="ItDesc" Visible="true"></asp:BoundField>
                                                    </Columns>
                                                    <HeaderStyle Font-Bold="True"></HeaderStyle>
                                                    <FooterStyle Font-Bold="True" ForeColor="#000000" CssClass="ft" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Fine Total</label>
                                    <asp:TextBox ID="nTotFine" CssClass="textbox" runat="server" autocomplete="off"></asp:TextBox>
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
                                    <label class="acclbl">Rec Fine</label>
                                    <asp:TextBox ID="nRecFine" CssClass="textbox" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Rec AMT</label>
                                    <asp:TextBox ID="nCashAmt" CssClass="textbox" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Bank Amt</label>
                                    <asp:TextBox ID="nBankAmt" CssClass="textbox" runat="server" autocomplete="off"></asp:TextBox>
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
                            <div class="icon">
                                <div class="mainline">
                                    <div id="imgContainer" runat="server" style="width: 700px; height: 700px; overflow: auto; border: solid 1px black; padding: 10px; margin-bottom: 5px;">
                                        <asp:Image ID="Or_Image"
                                            Style="width: 700px; height: 700px;"
                                            runat="server"></asp:Image>

                                        <%--<img id="Or_Image"  style="width: 700px; height: 700px;" runat="server" />--%>
                                    </div>
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
                                        <input id="btnPartyMasterSearch" onkeyup="myFunction()" placeholder="SEARCH  NAME - MOBILE" width="100%" class="serch-input" type="text" text="SEARCH  NAME - MOBILE" />
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

                            <!--====================Item Search Popup =====================-->

                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            <ajaxToolkit:ModalPopupExtender ID="ModalItmSearch" TargetControlID="Label2" PopupControlID="ItmSearch" runat="server">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="ItmSearch" runat="server" Style="width: 900px; height: 350px; position: relative; margin-top: 5%;">
                                <div style="overflow: scroll; background-color: white; padding: 2px;">
                                    <div class="d-searchbox">
                                        <input id="ItmNameSearch" onkeyup="itmSearch()" placeholder="SERCH ITEM NAME" width="100%" class="serch-input" type="text" text="SERCH ITEM NAME" />
                                    </div>
                                    <div class="hlp-main">
                                        <div class="hlpgrid">
                                            <div class="hlp-gv">
                                                <asp:GridView ID="ItmHelpGrid" runat="server" AutoGenerateColumns="false" ShowHeaderFilterButton="true" HeaderStyle-Font-Bold="true" OnRowDataBound="ItmhelpRowDataBound" OnSelectedIndexChanged="ItmhelpSelectedIndexChanged" Font-Bold="False" AutoPostBack="true" Font-Italic="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="IT_CODE" HeaderText="IT Code" ItemStyle-Width="250" />
                                                        <asp:BoundField DataField="IT_NAME" HeaderText="IT Name" ItemStyle-Width="550" />
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
                <script>
                    function itmSearch() {
                        var letterNumber = /[^0-9]/;
                        var input, filter, table, tr, td, i, txtValue;
                        input = document.getElementById("ItmNameSearch");
                        filter = input.value.toUpperCase();
                        table = document.getElementById("ItmHelpGrid");
                        tr = table.getElementsByTagName("tr");
                        for (i = 0; i < tr.length; i++) {
                            if (input.value.match(letterNumber)) {
                                td = tr[i].getElementsByTagName("td")[1];
                            }
                            else {
                                td = tr[i].getElementsByTagName("td")[0];
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
                
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnGridFill" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
