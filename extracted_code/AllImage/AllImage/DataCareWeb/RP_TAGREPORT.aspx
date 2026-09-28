<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RP_TAGREPORT.aspx.vb" Inherits="DcRemainder.RP_TAGREPORT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tag Stock Report</title>
    <link href="assets/CSS/RP_TAGREPORT.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="top">
                <label class="toplbl">Tag Stock Report </label>
            </div>
            <section class="section" id="portfolio">
                <div class="container">
                    <div class="filter-row">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </div>
                    <div class="grid">
                        <div class="grid-item">

                            <asp:GridView ID="TagReport" runat="server" CssClass="GridTag" EmptyDataText="No Result found !!! Plese Try Again....." AutoGenerateColumns="False" BorderColor="white">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="sectiondtl">
                                                
                                                    <asp:Image ID="Tag_Image"
                                                        Style="width: 22rem; height: 250px; overflow-x: hidden; box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px, rgba(10, 37, 64, 0.35) 0px -2px 6px 0px inset; border-radius: 30PX; margin: auto; overflow-y: hidden"
                                                        runat="server" ImageUrl='<%#Eval("ImgPath")%>'></asp:Image>
                                                
                                            </div>
                                            <div class="sectiondtl acspace">
                                                <asp:Label ID="Label5" Width="180px" runat="server" Text="TagNo"></asp:Label>
                                                <asp:Label CssClass="VCHNO" ID="AC_CODE" Width="100PX" runat="server" Text='<%# Bind("TagNo") %>'></asp:Label>
                                            </div>
                                            <div class="sectiondtl acspace">
                                                <asp:Label ID="Label1" Width="180px" runat="server" Text="ItName"></asp:Label>
                                                <asp:Label CssClass="VCHNO" Width="180px" Height="10px" ID="Label2" runat="server" Text='<%# Bind("ItName") %>'></asp:Label>
                                            </div>
                                            <div class="sectiondtl acspace">
                                                <asp:Label ID="Label3" Width="180px" runat="server" Text="ItName"></asp:Label>
                                                <asp:Label CssClass="VCHNO"  ID="Label4" runat="server" Text='<%# Bind("Pcs") %>'></asp:Label>
                                            </div>
                                            <div class="sectiondtl acspace">
                                                <asp:Label ID="Label6" Width="180px" runat="server" Text="Pcs"></asp:Label>
                                                <asp:Label CssClass="VCHNO" ID="Label7" runat="server" Text='<%# Bind("Grwt") %>'></asp:Label>
                                            </div>
                                            <div class="sectiondtl acspace">
                                                <asp:Label ID="Label8" Width="180px" runat="server" Text="GrWt"></asp:Label>
                                                <asp:Label CssClass="VCHNO" ID="Label9" runat="server" Text='<%# Bind("NetWt") %>'></asp:Label>
                                            </div>

                                        </ItemTemplate>
                                        <ItemStyle CssClass="cIsuSrNo" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>

                    </div>


                </div>
            </section>
            <div class="bottom">
                <asp:ImageButton ID="btnMsHome" class="left-buttom" src="assets/image/home.png" runat="server" />
                <asp:ImageButton ID="btnMsNoti" class="mid-buttom" src="assets/image/email.png" runat="server" />
                <asp:ImageButton ID="btnMsUs" class="right-buttom" src="assets/image/user.png" runat="server" />
            </div>
        </div>

    </form>
</body>
</html>
