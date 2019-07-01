<%@ Page Language="C#" Title="Product Info"  AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Product.aspx.cs" Inherits="FCC_ClientApp.Product" %>

<asp:Content ID="Product" ContentPlaceHolderID="MainContent" runat="server" ClientIDMode="Static">

    
      <%--added css to asp.net server controls--%>   
    <link href="Content/style.css" rel="stylesheet" />

    <script src="Scripts/Js/ProductJs.js"></script>
   
    <div>
<fieldset>    
    <legend style="font-family: Arial Black;background-color:blue; color:white; font-size:larger;font-style: oblique">Product's Information</legend>   
                <table  align="center">    
                    <tr>    
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtProductNo" runat="server" placeholder="Enter Product NO.." ></asp:TextBox>    
                        </td>    
                    </tr>    
                    <tr>    
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtProductName" runat="server" placeholder="Enter Product name.."></asp:TextBox>    
                        </td>    
                    </tr>    
                   
                         <tr>    
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtQuantity" runat="server" placeholder="Enter product quantity .."></asp:TextBox>    
                        </td>    
                    </tr> 
                 
                    <tr>    
                       <td align="center">    
                            <asp:Button ID="btnSubmit" runat="server" class="button button4" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="javascript:return validation();" />    
                            <asp:Button ID="btnCancel" runat="server" class="button button4" Text="Cancel" OnClick="btnCancel_Click" />    
                        </td>    
                    </tr>    
                    <tr>    
                        <td align="center">    
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>    
                        </td>    
                    </tr>    
                    <tr>    
                        <td align="center" colspan="2" style="background-color:deepskyblue;width: 100%;">  
                            <span style="font-family: Arial Black;color:white;background-color:blue;font-size:larger;font-style: oblique">Product's Records</span>  
                            <br />    
                        </td>    
                    </tr>    
                    <tr>   
                        <td colspan="2">    
                            <%--added gridview style layout and functionality  here--%>  
                            <asp:GridView ID="Productgrid" runat="server" AllowPaging="true" CellPadding="2" EnableModelValidation="True"    
                                        ForeColor="red" GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!" AutoGenerateColumns="false" Width="1100px"    
                                HeaderStyle-ForeColor="blue">    
                                <HeaderStyle CssClass="DataGridFixedHeader" />    
                                <RowStyle CssClass="grid_item" />    
                                <AlternatingRowStyle CssClass="grid_alternate" />    
                                <FooterStyle CssClass="DataGridFixedHeader" />   
                                <Columns>    
                                    <asp:TemplateField HeaderText="ProductNO">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                        <ItemTemplate>    
                                            <asp:Label ID="lblProductNo" runat="server" Text='<%#Eval("PRODUCT_NO")%>'>    
                                            </asp:Label>    
                                            <asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%#Eval("PRODUCTID")%>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>    
                                    <asp:TemplateField HeaderText="Product Name">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                        <ItemTemplate>                                         
                                            <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("PRODUCT_NAME") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>    
                                    <asp:TemplateField HeaderText="Email">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("QUANTITY") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>   
                                        
                                    <asp:TemplateField HeaderText="Edit">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>    
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CausesValidation="false"    
        
    CommandArgument='    
                                                <%#Eval("PRODUCTID") %>' OnCommand="lnkEdit_Command" ToolTip="Edit" />    
                                            </ItemTemplate>    
                                        </asp:TemplateField>    
                                        <asp:TemplateField HeaderText="Delete">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                            <ItemTemplate>    
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CausesValidation="false"    
        
    CommandArgument='    
                                                    <%#Eval("PRODUCTID") %>' CommandName="Delete" OnCommand="lnkDelete_Command"    
        
    OnClientClick="return confirm('Are you sure you want to delete?')" ToolTip="Delete" />    
                                                </ItemTemplate>    
                                            </asp:TemplateField>    
                                        </Columns>    
                                    </asp:GridView>    
                            <%--added gridview style layout and functionality  here--%>  
                                </td>    
                            </tr>    
                    </table>    
            </fieldset>   

    
    </div>
 
</asp:Content>