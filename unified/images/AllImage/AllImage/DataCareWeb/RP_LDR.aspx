<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RP_LDR.aspx.vb" Inherits="DcRemainder.RP_LDR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LDR Report</title>
    <link href="assets/CSS/RP_LDR.css" rel="stylesheet" />

</head>
<body>
    <form runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server" >
                </asp:ScriptManager>
                <div class="card">
                    <div class="mid">
                        <div class="iconline">
                            <div class="icon">
                                <div class="top">
                                    <label class="toplbl">LDR Report </label>
                                </div>
                            </div>
                            <div class="icon">
                                <div class="serchtab">
                                    <div class="d-searchbox">
                                        <%--<input id="btnPartyMasterSearch" oninput="updateResult(this.value)" onkeyup="myFunction()" placeholder="Search  Name - Mobile" width="100%" class="serchinput" type="text" text="SEARCH  NAME - MOBILE" />--%>
                                        <asp:TextBox ID="PartyMasterSearch" onfocus="this.setSelectionRange(this.value.length, this.value.length);" onkeyup="myFunction()" runat="server" autocomplete="off" placeholder="Search  Name - Mobile" Width="100%" class="serchinput" type="text"></asp:TextBox>

                                        <asp:DropDownList ID="cboAcGrCode" CssClass="drop" runat="server" AutoPostBack="True"
                                            DataTextField="AC_CITY" DataValueField="AC_CITY" AppendDataBoundItems="true">
                                        </asp:DropDownList>


                                        <asp:DropDownList ID="cboCity" CssClass="drop" runat="server" AutoPostBack="True"
                                            DataTextField="AC_CITY" DataValueField="AC_CITY" AppendDataBoundItems="true">
                                        </asp:DropDownList>

                                        <asp:Label ID="Label1" Width="210px" CssClass="Searchlbl" runat="server" Text="With Zero"></asp:Label>
                                        <asp:CheckBox ID="WithZero" CssClass="Chekbox" runat="server" AutoPostBack="true" />

                                    </div>
                                </div>
                            </div>

                            <asp:GridView ID="LDRDGV" runat="server" AutoGenerateColumns="False" BorderColor="white" Width="100%" OnRowCommand="NotiDGV_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="sectiondtl">
                                                <asp:Label ID="Label1" Width="180px" runat="server" Text="Ac Name"></asp:Label>
                                                <asp:Label CssClass="ACNAME" ID="cAcName" runat="server" Text='<%# Bind("AC_NAME") %>'></asp:Label>
                                            </div>

                                            <div class="sectiondtl acspace">
                                                <asp:Label ID="Label5" Width="180px" runat="server" Text="AC Code"></asp:Label>
                                                <asp:Label CssClass="VCHNO" ID="AC_CODE" runat="server" Text='<%# Bind("AC_CODE") %>'></asp:Label>
                                            </div>

                                            <div class="sectiondtl ">
                                                <asp:Label ID="Label2" Width="180px" runat="server" Text="Mobile"></asp:Label>
                                                <asp:Label ID="AC_MOBILE" CssClass="VCHNO" runat="server" Text='<%# Bind("AC_MOBILE") %>'></asp:Label>
                                            </div>

                                            <div class="sectiondtl">
                                                <asp:Label ID="Label4" Width="180px" runat="server" Text="DrAmt"></asp:Label>
                                                <asp:Label ID="DrAmt"  Width="210px" CssClass="VCHDATE" runat="server" Text='<%# Bind("DrAmt") %>'></asp:Label>

                                                 <asp:Label ID="Label7" Width="180px" runat="server" Text="CrAmt"></asp:Label>
                                                <asp:Label ID="CrAmt"  Width="210px" CssClass="UserName" runat="server" Text='<%# Bind("CrAmt") %>'></asp:Label>
                                            </div>

                                            <div class="sectiondtl">
                                                <asp:Label ID="Label8" Width="180px" runat="server" Text="DrGold"></asp:Label>
                                                <asp:Label ID="DrGold" Width="210px" CssClass="EditUser" runat="server" Text='<%# Bind("DrGold") %>'></asp:Label>
                                            
                                            <asp:Label ID="Label9" Width="180px" runat="server" Text="CrGold"></asp:Label>
                                                <asp:Label ID="CrGold" Width="210px" CssClass="EditRem" runat="server" Text='<%# Bind("CrGold") %>'></asp:Label>
                                            </div>


                                            <div class="sectiondtl">
                                                <asp:Label ID="Label3" Width="180px" runat="server" Text="DrSilver"></asp:Label>
                                                <asp:Label ID="DrSilver"  Width="210px" CssClass="Rtype" runat="server" Text='<%# Bind("DrSilver") %>'></asp:Label>

                                                <asp:Label ID="Label6" Width="180px" runat="server" Text="CrSilver"></asp:Label>
                                                <asp:Label ID="CrSilver" Width="210px" CssClass="Rtype" runat="server" Text='<%# Bind("CrSilver") %>'></asp:Label>
                                            </div>
                                            

                                            <%--<div class="sectiondtl">
                                                <asp:Button ID="btnWhatsapp" CssClass="ynbtn" runat="server" Text="Whatsapp" CommandName="WP" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="True" UseSubmitBehavior="False" />
                                                <asp:Button ID="btnCall" CssClass="ynbtn" runat="server" Text="Call" CommandName="Call" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="True" UseSubmitBehavior="False" />
                                            </div>--%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cIsuSrNo" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>


                <script>
                    function myFunction() {

                        var i = document.getElementById("PartyMasterSearch").value.length;

                        if (i > 0) {
                            document.getElementById("<%= btnNameSrc.ClientID %>").click();
                        }

                    }
                </script>
                <script type="text/javascript">
                    function ShareOnWhatsApp(id, name, country) {
                        window.open('wa.me/send?phone= '+id+ 'text=Reg No.: ' + id + ',Name: ' + name + ',Country: ' + country + '');
                        return false;
                    }
                </script>

                <asp:Button ID="btnNameSrc" CssClass="btnFireAcCode" BackColor="White" Width="0px" runat="server" Text="" Visible="true" />

            </ContentTemplate>

        </asp:UpdatePanel>
    </form>

</body>
</html>
