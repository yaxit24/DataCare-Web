<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PT_WHSALE.aspx.vb" Inherits="DcRemainder.PT_WHSALE" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/CSS/PT_WHSALE.css" rel="stylesheet" />
</head>
<body bgcolor="FFFFFF" topmargin="19">
    <form id="form1" style="width:90mm" runat="server">
        <div class="HeadName" style="text-align: center; padding-bottom: 20px;">Wh Sales Bill</div>
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
            <div class="codetail" style="width: 100mm; text-align: left; margin-top: 50px;">
                <asp:Label ID="Label8" CssClass="IRItem" runat="server" Text="Isu Item"></asp:Label>
                <asp:GridView ID="PTISUGRID" runat="server" ShowFooter="true"  FooterStyle-BackColor="WhiteSmoke" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" Font-Bold="True" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuSrNo" CssClass="VCHNO" runat="server" Text='<%# Bind("SR_NO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuPrName" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_REMARK") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="30%" />
                            <FooterTemplate>
                                <asp:Label ID="FTcIsuPrName" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pcs">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuPcs" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_PCS") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            <FooterTemplate>
                                <asp:Label ID="FTcIsuPcs" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GrWt">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuGwt" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_GWT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcIsuGwt" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NtWt">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuNwt" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_NWT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcIsuNwt" CssClass="VCHNO" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Touch">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuTouch" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_TOUCH") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="West%">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuWestPrc" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_WEST_PRC") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Fine">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuFine" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_FINE") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcIsuFine" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amt">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cIsuNetAmt" CssClass="VCHNO" runat="server" Text='<%# Bind("NET_AMT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcIsuNetAmt" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="line" style="width: 90mm; margin: auto; margin-top: 50px;">
            <div class="codetail" style="width: 100mm; text-align: left; margin-top: 50px;">
                <asp:Label ID="RECLBL" CssClass="IRItem" runat="server" Text="Recive Item"></asp:Label>
                <asp:GridView ID="PTRECGRID" runat="server" ShowFooter="true" FooterStyle-HorizontalAlign="Right" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" Font-Bold="True" />
                            <ItemTemplate>
                                <asp:Label ID="cRecSrNo" CssClass="VCHNO" runat="server" Text='<%# Bind("SR_NO") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecPrName" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_REMARK") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="30%" />
                            <FooterTemplate>
                                <asp:Label ID="FTcRecPrName" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pcs">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecPcs" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_PCS") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            <FooterTemplate>
                                <asp:Label ID="FTcRecPcs" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GrWt">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecGwt" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_GWT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcRecGwt" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NtWt">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecNwt" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_NWT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcRecNwt" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Touch">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecTouch" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_TOUCH") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="West%">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecWestPrc" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_WEST_PRC") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Fine">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecFine" CssClass="VCHNO" runat="server" Text='<%# Bind("ITM_FINE") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcRecFine" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amt">
                            <HeaderStyle BackColor="Silver" BorderColor="Black" />
                            <ItemTemplate>
                                <asp:Label ID="cRecNetAmt" CssClass="VCHNO" runat="server" Text='<%# Bind("NET_AMT") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Label ID="FTcRecNetAmt" CssClass="VCHNO" runat="server" ></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <div class="line">
            <div class="AcDetile">
                <div>
                    <asp:Label ID="Label17" runat="server" Text="TOTAL FINE CR:"></asp:Label>
                    <asp:Label ID="nTot_Fine_Cr" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label11" runat="server" Text="TOTAL FINE DR:"></asp:Label>
                    <asp:Label ID="nTot_Fine_Dr" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label10" runat="server" Text="TOTAL Amt CR:"></asp:Label>
                    <asp:Label ID="nTot_Amt_Cr" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label15" runat="server" Text="TOTAL Amt DR:"></asp:Label>
                    <asp:Label ID="nTot_Amt_Dr" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ForeColor="Red" ID="Label12" runat="server" Text="BILL Fine OS:"></asp:Label>
                    <asp:Label ID="n_Tot_Fine_OS" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ForeColor="Red" ID="Label18" runat="server" Text="BILL Amt OS:"></asp:Label>
                    <asp:Label ID="n_Tot_Amt_OS" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

        <asp:Button ID="btnPrintExit" CssClass="btnExit" runat="server" Text="....Click Heare to Back...." />
    </form>
</body>
</html>
