<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TR_WHSALE.aspx.vb" Inherits="DcRemainder.TR_WHSALE" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/CSS/TR_WHSALE.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="card">
                    <div class="mid">
                        <div class="iconline">
                            <div class="icon">
                                <div class="top">
                                    <label class="toplbl">Wh Sale </label>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Vch No </label>
                                    <asp:TextBox ID="tVchNo" CssClass="textbox" Width="20%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="tVchDate" CssClass="textbox" Width="40%" runat="server" autocomplete="off"></asp:TextBox>
                                    <asp:Button ID="btnVchRePrint" Width="13%" CssClass="textbox" runat="server" Text="A1" />

                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Ac Name </label>
                                    <asp:TextBox ID="tAcCode" onfocus="this.setSelectionRange(this.value.length, this.value.length);" MaxLength="10" onkeyup="ACCODECOUNT()" CssClass="textbox" Width="20%" runat="server" autocomplete="off"></asp:TextBox>
                                    <asp:TextBox ID="tAcName" CssClass="textbox" Width="53%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="mainline">
                                    <label class="acclbl">Type </label>
                                    <asp:Button ID="Issue" CssClass="textbox" Width="32%" runat="server" Text="Issue" />
                                    <asp:Button ID="Recive" CssClass="textbox" Width="32%" runat="server" Text="Recive" />
                                </div>
                            </div>

                            <%--========================= Issue Panal ========================--%>
                            <asp:Panel ID="IRpanal" runat="server" class="IRiconline">
                                <div class="icon">
                                    <div class="mainline">
                                        <asp:Panel ID="WHIssue" runat="server" class="Paneliconline">
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">TagNo </label>
                                                    <asp:TextBox ID="tIsuTagNo" CssClass="textbox" Width="53%" runat="server" onfocus="this.select();" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                                    <asp:Button ID="QrScan" CssClass="textbox" runat="server" Width="20%" OnClick="QrScan_Click" Text="OK" />
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">Item Name </label>

                                                    <asp:TextBox ID="tIsuItCode" onkeyup="ISUITCODECOUNT()" CssClass="textbox" Width="20%" onfocus="this.select();" runat="server" autocomplete="off"></asp:TextBox>
                                                    <asp:TextBox ID="tIsuItName" CssClass="textbox" Width="53%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">Pcs </label>
                                                    <asp:TextBox ID="nIsuPcs" CssClass="textbox" TextMode="Number" onfocus="this.select();" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">GrWt </label>
                                                    <asp:TextBox ID="nIsuGrWt" CssClass="textbox" TextMode="Number" runat="server" AutoPostBack="true" onfocus="this.select();" autocomplete="off"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">OthWt </label>
                                                    <asp:TextBox ID="nIsuOthWt" CssClass="textbox" Width="27%" runat="server" onfocus="this.select();" AutoPostBack="true" autocomplete="off"></asp:TextBox>

                                                    <label class="Midacclbl">NetWt </label>
                                                    <asp:TextBox ID="nIsuNetWt" CssClass="Midtextbox" Width="27%" runat="server" onfocus="this.select();" AutoPostBack="true" autocomplete="off"></asp:TextBox>

                                                </div>
                                            </div>


                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">Touch </label>
                                                    <asp:TextBox ID="nIsuTouch" CssClass="textbox" Width="27%" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>

                                                    <label class="Midacclbl">West% </label>
                                                    <asp:TextBox ID="nIsuWestPrc" CssClass="Midtextbox" Width="27%" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">Fine </label>
                                                    <asp:TextBox ID="nIsuFine" CssClass="Midtextbox" TextMode="Number" runat="server" onfocus="this.select();" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">LbrAmt </label>
                                                    <asp:TextBox ID="nIsuLbrAmt" CssClass="textbox" Width="27%" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>

                                                    <label class="Midacclbl">OthAmt </label>
                                                    <asp:TextBox ID="nIsuOthAmt" CssClass="Midtextbox" Width="27%" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="isulbl">Mrp </label>
                                                    <asp:TextBox ID="nIsuMrp" CssClass="textbox" Width="27%" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>

                                                    <label class="Midacclbl">TotAmt </label>
                                                    <asp:TextBox ID="nIsuTotAmt" CssClass="Midtextbox" Width="27%" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <asp:Button ID="BtnIsuGridFill" CssClass="textbox" runat="server" Text="Issue Add Item" />
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <div class="oth-main">
                                                        <asp:GridView ID="IsuDGV" runat="server" Width="95%" BorderColor="white" ShowFooter="true" AutoGenerateColumns="False" ShowHeaderFilterButton="true" HeaderStyle-Font-Bold="true" Font-Bold="False" AutoPostBack="true" Font-Italic="False">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label11" Width="150px" runat="server" Text="SrNO"></asp:Label>
                                                                            <asp:Label CssClass="VCHNO" Width="150px" ID="cIsuSrNo" runat="server" Text='<%# Bind("cIsuSrNo") %>'></asp:Label>

                                                                            <asp:Label ID="Label12" Width="150px" runat="server" Text="Tag No"></asp:Label>
                                                                            <asp:Label ID="cIsuTagNo" Width="150px" CssClass="VCHNO" runat="server" Text='<%# Bind("cIsuTagNo") %>'></asp:Label>
                                                                        </div>

                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label4" Width="150px" runat="server" Text="It Name"></asp:Label>
                                                                            <asp:Label ID="cIsuItName" CssClass="VCHDATE" runat="server" Text='<%# Bind("cIsuItName") %>'></asp:Label>
                                                                        </div>

                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label5" Width="150px" runat="server" Text="It Code"></asp:Label>
                                                                            <asp:Label CssClass="VCHNO" Width="150px" ID="cIsuItCode" runat="server" Text='<%# Bind("cIsuItCode") %>'></asp:Label>

                                                                            <asp:Label ID="Label7" Width="150px" runat="server" Text="Pcs"></asp:Label>
                                                                            <asp:Label ID="cIsuPcs" Width="150px" CssClass="UserName" runat="server" Text='<%# Bind("cIsuPcs") %>'></asp:Label>
                                                                        </div>


                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label8" Width="150px" runat="server" Text="GrWt"></asp:Label>
                                                                            <asp:Label ID="cIsuGrWt" Width="150px" CssClass="EditUser" runat="server" Text='<%# Bind("cIsuGrWt") %>'></asp:Label>

                                                                            <asp:Label ID="Label9" Width="150px" runat="server" Text="OthWt"></asp:Label>
                                                                            <asp:Label ID="cIsuOthWt" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuOthWt") %>'></asp:Label>


                                                                        </div>


                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label14" Width="150px" runat="server" Text="NtWt"></asp:Label>
                                                                            <asp:Label ID="cIsuNetWt" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuNetWt") %>'></asp:Label>

                                                                            <asp:Label ID="Label16" Width="150px" runat="server" Text="Touch"></asp:Label>
                                                                            <asp:Label ID="cIsuTouch" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuTouch") %>'></asp:Label>


                                                                        </div>

                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label18" Width="150px" runat="server" Text="West%"></asp:Label>
                                                                            <asp:Label ID="cIsuWestPrc" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuWestPrc") %>'></asp:Label>

                                                                            <asp:Label ID="Label6" Width="150px" runat="server" Text="Fine"></asp:Label>
                                                                            <asp:Label ID="cIsuFine" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuFine") %>'></asp:Label>


                                                                        </div>
                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label13" Width="150px" runat="server" Text="LbrAmt"></asp:Label>
                                                                            <asp:Label ID="cIsuLbrAmt" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuLbrAmt") %>'></asp:Label>

                                                                            <asp:Label ID="Label10" Width="150px" runat="server" Text="OthAmt"></asp:Label>
                                                                            <asp:Label ID="cIsuOthAmt" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuOthAmt") %>'></asp:Label>


                                                                        </div>
                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label17" Width="150px" runat="server" Text="Mrp"></asp:Label>
                                                                            <asp:Label ID="cIsuMrp" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuMrp") %>'></asp:Label>

                                                                            <asp:Label ID="Label20" Width="150px" runat="server" Text="Total Amt    "></asp:Label>
                                                                            <asp:Label ID="cIsuTotAmt" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cIsuTotAmt") %>'></asp:Label>
                                                                        </div>

                                                                        <div class="sectiondtl">
                                                                            <asp:Button ID="btnIsuDelete" CssClass="ynbtn" runat="server" Text="Delete" CommandName="IsuRowDelete" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="True" UseSubmitBehavior="False" />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="cIsuSrNo" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>


                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <%-- ========================== Recive panal =========================--%>
                                        <asp:Panel ID="WHRecive" runat="server" class="Paneliconline">
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">Item Name</label>
                                                    <asp:TextBox ID="tRecItCode" onkeyup="RECITCODECOUNT()" CssClass="textbox" Width="20%" runat="server" onfocus="this.select();" autocomplete="off"></asp:TextBox>
                                                    <asp:TextBox ID="tRecItName" CssClass="textbox" Width="53%" runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">Pcs </label>
                                                    <asp:TextBox ID="nRecPcs" CssClass="textbox" TextMode="Number" onfocus="this.select();" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">GrWt </label>
                                                    <asp:TextBox ID="nRecGrWt" CssClass="textbox" TextMode="Number" runat="server" onfocus="this.select();" AutoPostBack="true" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">OthWt </label>
                                                    <asp:TextBox ID="nRecOthWt" CssClass="textbox" TextMode="Number" runat="server" onfocus="this.select();" AutoPostBack="true" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">NetWt </label>
                                                    <asp:TextBox ID="nRecNetwt" CssClass="textbox" TextMode="Number" runat="server" onfocus="this.select();" AutoPostBack="true" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">Touch </label>
                                                    <asp:TextBox ID="nRecTouch" CssClass="textbox" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">West% </label>
                                                    <asp:TextBox ID="nRecWestPrc" CssClass="Midtextbox" TextMode="Number" onfocus="this.select();" AutoPostBack="true" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <label class="reclbl">Fine </label>
                                                    <asp:TextBox ID="nRecFine" CssClass="Midtextbox" TextMode="Number" onfocus="this.select();" runat="server" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <asp:Button ID="BtnRecGridFill" CssClass="textbox" runat="server" Text="Rec Add Item" />
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                </div>
                                            </div>
                                            <div class="Panelicon">
                                                <div class="Panelmainline">
                                                    <div class="oth-main">
                                                        <asp:GridView ID="RecDGV" runat="server" ShowFooter="True" AutoGenerateColumns="False" BorderColor="white" Width="95%" ShowHeaderFilterButton="true" HeaderStyle-Font-Bold="true" Font-Bold="False" AutoPostBack="true" Font-Italic="False">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label11" Width="150px" runat="server" Text="SrNO"></asp:Label>
                                                                            <asp:Label CssClass="VCHNO" Width="150px" ID="cRecSrNo" runat="server" Text='<%# Bind("cRecSrNo") %>'></asp:Label>

                                                                        </div>

                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label12" Width="150px" runat="server" Text="ItName"></asp:Label>
                                                                            <asp:Label ID="cRecItName" CssClass="VCHNO" runat="server" Text='<%# Bind("cRecItName") %>'></asp:Label>


                                                                        </div>
                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label5" Width="150px" runat="server" Text="It Code"></asp:Label>
                                                                            <asp:Label CssClass="VCHNO" Width="150px" ID="cRecItCode" runat="server" Text='<%# Bind("cRecItCode") %>'></asp:Label>

                                                                            <asp:Label ID="Label4" Width="150px" runat="server" Text="Pcs"></asp:Label>
                                                                            <asp:Label ID="cRecPcs" Width="150px" Height="20px" CssClass="VCHDATE" runat="server" Text='<%# Bind("cRecPcs") %>'></asp:Label>
                                                                        </div>

                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label7" Width="150px" runat="server" Text="GrWt"></asp:Label>
                                                                            <asp:Label ID="cRecGrWt" Width="150px" CssClass="UserName" runat="server" Text='<%# Bind("cRecGrWt") %>'></asp:Label>

                                                                            <asp:Label ID="Label8" Width="150px" runat="server" Text="OthWt"></asp:Label>
                                                                            <asp:Label ID="cRecOthWt" Width="150px" CssClass="EditUser" runat="server" Text='<%# Bind("cRecOthWt") %>'></asp:Label>
                                                                        </div>


                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label9" Width="150px" runat="server" Text="NetWt"></asp:Label>
                                                                            <asp:Label ID="cRecNetwt" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cRecNetwt") %>'></asp:Label>

                                                                            <asp:Label ID="Label14" Width="150px" runat="server" Text="Touch"></asp:Label>
                                                                            <asp:Label ID="cRecTouch" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cRecTouch") %>'></asp:Label>
                                                                        </div>


                                                                        <div class="sectiondtl">
                                                                            <asp:Label ID="Label16" Width="150px" runat="server" Text="West%"></asp:Label>
                                                                            <asp:Label ID="cRecWestPrc" Width="150px" CssClass="EditRem" runat="server" Text='<%# Bind("cRecWestPrc") %>'></asp:Label>

                                                                            <asp:Label ID="Label18" Width="150px" runat="server" Text="Fine"></asp:Label>
                                                                            <asp:Label ID="cRecFine" CssClass="EditRem" runat="server" Text='<%# Bind("cRecFine") %>'></asp:Label>
                                                                        </div>

                                                                        <%--<div class="sectiondtl">
                                                                                    <asp:Button ID="btnUSERYES" CssClass="ynbtn" runat="server" Text="Accept" CommandName="Accept" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="True" UseSubmitBehavior="False" />
                                                                                    <asp:Button ID="btnUSERNO" CssClass="ynbtn" runat="server" Text="Reject" CommandName="Reject" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="True" UseSubmitBehavior="False" />
                                                                                </div>--%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="cIsuSrNo" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="IRicon">
                                    <div class="IRmainline">
                                        <label class="acclbl">IsuFine </label>
                                        <asp:TextBox ID="nTotFineDr" CssClass="textbox" Width="27%" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>

                                        <label class="Midacclbl">RecFine </label>
                                        <asp:TextBox ID="nTotFineCr" CssClass="Midtextbox" Width="27%" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="IRicon">
                                    <div class="IRmainline">
                                        <label class="acclbl">IsuAmt </label>
                                        <asp:TextBox ID="nTotAmtDr" CssClass="textbox" Width="27%" pattern="[0-9]+([\.,][0-9]+)?" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>

                                        <label class="Midacclbl">RecAmt </label>
                                        <asp:TextBox ID="nTotAmtCr" CssClass="Midtextbox" Width="27%" runat="server" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="IRicon">
                                    <div class="IRmainline">
                                        <asp:Button ID="btnSave" CssClass="textbox" runat="server" Text="SAVE" />
                                    </div>
                                </div>
                                <div class="IRicon">
                                    <div class="IRmainline">
                                        <asp:Button ID="btnCancle" CssClass="textbox" runat="server" Text="Cancle" />
                                    </div>
                                </div>
                                <div class="IRicon">
                                    <div class="IRmainline">
                                        <asp:Button ID="btnPrint" CssClass="textbox" runat="server" Text="Print" />
                                    </div>
                                </div>
                                <div class="IRicon">
                                    <div class="IRmainline">
                                        <asp:Button ID="btnDelete" CssClass="textbox" runat="server" Text="Delete" />
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


                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <!--===================Acc Help Popup==================-->
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="Label1" PopupControlID="modalpan" runat="server">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="modalpan" runat="server" Style="width: 900px; height: 350px; position: relative; margin-top: -31%;">
                    <div style="overflow: scroll; background-color: white; padding: 2px;">
                        <div class="d-searchbox">
                            <asp:TextBox ID="btnPartyMasterSearch" onfocus="this.setSelectionRange(this.value.length, this.value.length);" MaxLength="15" onkeyup="myFunction()" CssClass="serch-input" Width="70%" runat="server" placeholder="SEARCH  NAME - MOBILE" class="serch-input" type="text" Text="SEARCH  NAME - MOBILE" autocomplete="off"></asp:TextBox>

                            <%--<input id="btnPartyMasterSearch1" onkeyup="myFunction()" placeholder="SEARCH  NAME - MOBILE" width="100%" class="serch-input" type="text" text="SEARCH  NAME - MOBILE" />--%>
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
                            <%--                            <input id="ItmNameSearch" onkeyup="itmSearch()" placeholder="SERCH ITEM NAME" width="100%" class="serch-input" type="text" text="SERCH ITEM NAME" />--%>
                            <asp:TextBox ID="ItmNameSearch" onfocus="this.setSelectionRange(this.value.length, this.value.length);" MaxLength="15" onkeyup="itmSearch()" CssClass="serch-input" Width="70%" runat="server" placeholder="SERCH ITEM NAME" class="serch-input" type="text" Text="SERCH ITEM NAME" autocomplete="off"></asp:TextBox>

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

                <!--====================Vch Recall Help Search Popup =====================-->

                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                <ajaxToolkit:ModalPopupExtender ID="ModalVchNoHelp" TargetControlID="Label3" PopupControlID="VchNoHelp" runat="server">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="VchNoHelp" runat="server">
                    <div style="overflow: scroll; background-color: white; padding: 2px;">
                        <div class="d-searchbox">
                            <%--                            <input id="ItmNameSearch" onkeyup="itmSearch()" placeholder="SERCH ITEM NAME" width="100%" class="serch-input" type="text" text="SERCH ITEM NAME" />--%>
                            <asp:TextBox ID="TextBox1" onfocus="this.setSelectionRange(this.value.length, this.value.length);" MaxLength="15" onkeyup="itmSearch()" CssClass="serch-input" Width="70%" runat="server" placeholder="SERCH ITEM NAME" class="serch-input" type="text" Text="SERCH ITEM NAME" autocomplete="off"></asp:TextBox>

                        </div>
                        <div class="hlp-main">
                            <div class="hlpgrid">
                                <div class="hlp-gv">
                                    <asp:GridView ID="VchNoHelpDGV" runat="server" AutoGenerateColumns="false" ShowHeaderFilterButton="true" HeaderStyle-Font-Bold="true" Font-Bold="False" AutoPostBack="true" Font-Italic="False">
                                        <Columns>
                                            <asp:BoundField DataField="VCH_NO" HeaderText="VCH NO" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="VCH_DATE" HeaderText="VCH DATE" ItemStyle-Width="250" />
                                            <asp:BoundField DataField="AC_NAME" HeaderText="AC NAME" ItemStyle-Width="550" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <script>
                    function myFunction() {
                        var B = document.getElementById("btnPartyMasterSearch").value.length;
                        if (B < 1) {
                            document.getElementById("<%= btnITMFIRE.ClientID %>").click();
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
                <script>
                    function itmSearch() {
                        var A = document.getElementById("ItmNameSearch").value.length;
                        if (A < 1) {
                            document.getElementById("<%= btnITMFIRE.ClientID %>").click();
                        }
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
                <script type="text/javascript">
                    function ACCODECOUNT() {
                        var i = document.getElementById("tAcCode").value.length;

                        if (i == 2) {
                            document.getElementById("<%= btnACFIRE.ClientID %>").click();
                        }
                    }
                </script>

                <script type="text/javascript">
                    function ISUITCODECOUNT() {
                        var A = document.getElementById("tIsuItCode").value.length;


                        if (A == 2) {
                            document.getElementById("<%= btnITMFIRE.ClientID %>").click();
                        }

                    }
                </script>
                <script type="text/javascript">
                    function RECITCODECOUNT() {

                        var B = document.getElementById("tRecItCode").value.length;


                        if (B == 2) {
                            document.getElementById("<%= btnITMFIRE.ClientID %>").click();
                        }
                    }
                </script>

                <asp:Button ID="btnACFIRE" CssClass="btnFireAcCode" BackColor="White" Width="0px" runat="server" Text="" Visible="true" />
                <asp:Button ID="btnITMFIRE" CssClass="btnFireAcCode" BackColor="White" Width="0px" runat="server" Text="" Visible="true" />


            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="tIsuTagNo" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
</body>
</html>

