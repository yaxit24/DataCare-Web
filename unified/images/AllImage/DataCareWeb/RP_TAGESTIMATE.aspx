    <%@ Page Language="vb" AutoEventWireup="true" CodeBehind="RP_TAGESTIMATE.aspx.vb" Inherits="DcRemainder.RP_TAGESTIMATE" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TAG ESTIMATE</title>
    <link href="assets/CSS/RP_TAGESTIMATE.css" rel="stylesheet" />

</head>
<body>

    <form id="form1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="card">
                    <div class="mid">
                        <div class="iconline">
                            <div class="icon">
                                <div class="top">
                                    <label class="toplbl">Tag Estimate </label>
                                </div>
                            </div>

                            <div class="icon">
                                <div class="iconinline">
<%--                                    <div id="imgContainer" runat="server" style="width: 45rem; margin:auto; border-radius:20PX; box-shadow: 0 0 50px #ccc; outline: none; border: none; height: 500px; overflow: auto; border:none; padding: 10px; margin-bottom: 5px;">--%>
                                        <asp:Image ID="Or_Image"
                                            Style="width: 45rem; height: 480px; overflow-x:hidden; box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px, rgba(10, 37, 64, 0.35) 0px -2px 6px 0px inset;  border-radius:30PX; margin:auto; overflow-y:hidden"
                                            runat="server"></asp:Image>
                                        <%-- <%--<img id="Or_Image"  style="width: 700px; height: 700px;" runat="server" />--%>
                                    <%--</div>--%>
                                </div>
                            </div>
                           
                            <div class="icon">
                                <div class="iconinline">
                                    <asp:Label ID="Label1" Width="200PX" runat="server" CssClass="acclbl" Text="TagNo: "></asp:Label>
                                    <asp:TextBox ID="tDesignNo" CssClass="textbox" runat="server" AutoPostBack="true"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="icon">
                                <br />
                                <div class="iconinline">
                                     <asp:Label ID="Label3" Width="200PX" runat="server" CssClass="leftlbl ItemName" Text="Item Name: "></asp:Label>
                                    <asp:Label ID="tItName" runat="server"  CssClass="Detaillbl ItemName" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label2" Width="200PX" runat="server" CssClass="leftlbl TagNo" Text="TagNo: "></asp:Label>
                                    <asp:Label ID="tTagNo" runat="server" CssClass="Detaillbl TagNo" ></asp:Label>
                                    <br />
                                    <br />
                                   
                                    <asp:Label ID="Label6" Width="200PX" runat="server" CssClass="leftlbl TagNo" Text="Pcs: "></asp:Label>
                                    <asp:Label ID="nPcs" runat="server"  CssClass="Detaillbl TagNo" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label4" Width="200PX" runat="server" CssClass="leftlbl TagNo" Text="Gr Wt: "></asp:Label>
                                    <asp:Label ID="nGrWt" runat="server"  CssClass="Detaillbl TagNo" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label5" Width="200PX" runat="server" CssClass="leftlbl TagNo" Text="Net Wt: "></asp:Label>
                                    <asp:Label ID="nNetWt" runat="server"  CssClass="Detaillbl TagNo" ></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label8" Width="200PX" runat="server" CssClass="leftlbl Rate" Text="Item Rate: "></asp:Label>
                                    <asp:Label ID="nItemRate" runat="server"  CssClass="Detaillbl Rate" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label10" Width="200PX" runat="server" CssClass="leftlbl Rate" Text="Item Amt: "></asp:Label>
                                    <asp:Label ID="nItemAmt" runat="server"  CssClass="Detaillbl Rate" ></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label12" Width="200PX" runat="server" CssClass="leftlbl Lbr" Text="Lbr %: "></asp:Label>
                                    <asp:Label ID="nLbrPrc" runat="server"  CssClass="Detaillbl Lbr" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label14" Width="200PX" runat="server" CssClass="leftlbl Lbr" Text="Lbr Rate: "></asp:Label>
                                    <asp:Label ID="nLbrRate" runat="server"  CssClass="Detaillbl Lbr" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label16" Width="200PX" runat="server" CssClass="leftlbl Lbr" Text="Lbr Type: "></asp:Label>
                                    <asp:Label ID="tLbrType" runat="server"  CssClass="Detaillbl Lbr" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label18" Width="200PX" runat="server" CssClass="leftlbl Lbr" Text="Lbr Amt: "></asp:Label>
                                    <asp:Label ID="nLbrAmt" runat="server"  CssClass="Detaillbl Lbr" ></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label20" Width="200PX" runat="server" CssClass="leftlbl Rate" Text="Other Amt: "></asp:Label>
                                    <asp:Label ID="nOthAmt" runat="server"  CssClass="Detaillbl Rate" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label22" Width="200PX" runat="server" CssClass="leftlbl Rate" Text="Disc Amt: "></asp:Label>
                                    <asp:Label ID="nDiscAmt" runat="server"  CssClass="Detaillbl Rate" ></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label24" Width="200PX" runat="server" CssClass="leftlbl" Text="Net Amt: "></asp:Label>
                                    <asp:Label ID="nNetAmt" runat="server"  CssClass="Detaillbl TagNo" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label26" Width="200PX" runat="server" CssClass="leftlbl" Text="Tax Amt: "></asp:Label>
                                    <asp:Label ID="nTaxAmt" runat="server"  CssClass="Detaillbl TagNo" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label28" Width="200PX" runat="server" CssClass="leftlbl" Text="Total Amt: "></asp:Label>
                                    <asp:Label ID="nTotalAmt" runat="server"  CssClass="Detaillbl TagNo" ></asp:Label>
                                    <asp:Button ID="btnGeneratePDF" runat="server" Text="Button" />
<%--                                   
    <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server" AutoPostBack="true"></asp:TextBox>--%>
                                </div>
                            </div>
                            
                            
                        </div>
                    </div>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
        
    </form>
</body>
</html>
