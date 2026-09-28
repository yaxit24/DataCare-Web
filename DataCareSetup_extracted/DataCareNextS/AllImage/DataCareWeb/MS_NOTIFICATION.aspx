<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MS_NOTIFICATION.aspx.vb" Inherits="DcRemainder.MS_NOTIFICATION" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/CSS/MS_NOTIFICATION.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="card">
            <div class="mid">
                <div class="iconline">
                    <div class="icon">
                        <div class="top">
                            <label class="toplbl">Notification </label>
                        </div>
                    </div>
                    <asp:GridView ID="NotiDGV" runat="server"  AutoGenerateColumns="False" BorderColor="white" Width="100%"  OnRowCommand="NotiDGV_RowCommand" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="sectiondtl">
                                        <asp:Label ID="Label1"  Width="210px" runat="server" Text="Ac Name"></asp:Label>
                                        <asp:Label CssClass="ACNAME" ID="cAcName" runat="server" Text='<%# Bind("AC_NAME") %>'></asp:Label>
                                    </div>

                                    <div class="sectiondtl acspace">
                                        <asp:Label ID="Label5"  Width="210px" runat="server" Text="Book Name"></asp:Label>
                                        <asp:Label CssClass="VCHNO" ID="BOOK_NAME" runat="server" Text='<%# Bind("BOOK_NAME") %>'></asp:Label>
                                    </div>

                                    <div class="sectiondtl ">
                                        <asp:Label ID="Label2" Width="210px"  runat="server" Text="Vch No"></asp:Label>
                                        <asp:Label ID="VCH_NO" CssClass="VCHNO" runat="server" Text='<%# Bind("VCH_NO") %>'></asp:Label>
                                    </div>

                                    <div class="sectiondtl">
                                        <asp:Label ID="Label4" Width="210px" runat="server" Text="Vch Date"></asp:Label>
                                        <asp:Label ID="VCHDATE" CssClass="VCHDATE" runat="server" Text='<%# Bind("VCH_DATE") %>'></asp:Label>
                                    </div>

                                    <div class="sectiondtl">
                                        <asp:Label ID="Label7" Width="210px" runat="server" Text="User Name"></asp:Label>
                                        <asp:Label ID="UserName" CssClass="UserName" runat="server" Text='<%# Bind("USER_NAME") %>'></asp:Label>
                                    </div>

                                    <div class="sectiondtl">
                                        <asp:Label ID="Label8" Width="210px" runat="server" Text="Edit User"></asp:Label>
                                        <asp:Label ID="EditUser" CssClass="EditUser" runat="server" Text='<%# Bind("EDIT_USER") %>'></asp:Label>
                                    </div>

                                    <div class="sectiondtl">
                                        <asp:Label ID="Label9" Width="210px" runat="server" Text="Remark"></asp:Label>
                                        <asp:Label ID="EditRem" CssClass="EditRem" runat="server" Text='<%# Bind("EDIT_RMARK") %>'></asp:Label>
                                    </div>

                                    <div class="sectiondtl">
                                        <asp:Label ID="Label3" Width="210px" runat="server" Text="RType"></asp:Label>
                                        <asp:Label ID="Rtype" CssClass="Rtype" runat="server" Text='<%# Bind("RType") %>'></asp:Label>
                                        <asp:Label ID="CO_BOOK" CssClass="Rtype" runat="server" Text='<%# Bind("CO_BOOK") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="MAIN_BOOK" CssClass="Rtype" runat="server" Text='<%# Bind("MAIN_BOOK") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="BOOK_TBL_NAME" CssClass="Rtype" runat="server" Text='<%# Bind("BOOK_TBL_NAME") %>' Visible="false"></asp:Label>
                                    </div>

                                    <div class="sectiondtl"> 
                                        <asp:Button ID="btnUSERYES" CssClass="ynbtn"  runat="server" Text="Accept" CommandName="Accept" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="True" UseSubmitBehavior="False"  />
                                        <asp:Button ID="btnUSERNO" CssClass="ynbtn"  runat="server" Text="Reject" CommandName="Reject" CommandArgument="<%# Container.DataItemIndex %>" CausesValidation="True" UseSubmitBehavior="False"  />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle CssClass="cIsuSrNo" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
