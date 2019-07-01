<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Customer Product Info" CodeBehind="Customer_Product.aspx.cs" Inherits="FCC_ClientApp.Customer_Product" %>



<asp:Content ID="Custom_Product" ContentPlaceHolderID="MainContent" runat="server" ClientIDMode="Static">

    
      <%--added css to asp.net server controls--%>   
    <link href="Content/style.css" rel="stylesheet" />

    <script src="Scripts/Js/Customer_Product.js"></script>
   
    <div>
<fieldset>    
    <legend style="font-family: Arial Black;background-color:blue; color:white; font-size:larger;font-style: oblique">Product's Information</legend>   
                <table  align="Left">    
                    <tr>    
                        <td style="width: 752px">Customer Name :</td>
                        <td style="text-align:center">    
                                
                           <asp:DropDownList ID="ddlCustomer" runat="server"></asp:DropDownList>
                        </td>    
                    </tr>    
                    <tr>    
                        <td style="width: 752px"> Product Name:  </td>
                        <td style="text-align:center">    
                              
                             <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "OnSelectedIndexChanged"></asp:DropDownList>
                        </td>    
                    </tr>    
                   
                         <tr>  
                             <td style="width: 752px"> Product Quantity:</td>  
                        <td style="text-align:center">    
                               
                            <asp:TextBox ID="txtProductQuantity" runat="server" placeholder="Enter Avail quantity .." ReadOnly="true"></asp:TextBox>    
                        </td>    
                    </tr> 
                     <tr>    
                         <td style="width: 752px"> Bought Amount:</td>
                        <td style="text-align:center">    
                           <asp:TextBox ID="txtBoughtPrduct" runat="server" placeholder="Enter bought amount" onblur="javascript:myFunction()" ></asp:TextBox>    
                        </td>    
                    </tr> 
                         <tr>  
                             <td style="width: 752px">Balance Product Qty</td>  
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtProductBalance" runat="server" placeholder="Product balance" ReadOnly="true"></asp:TextBox>    
                        </td>    
                    </tr> 
                 
                    <tr>    
                       <td align="center" style="width: 752px">    
                            <asp:Button ID="btnSubmit" runat="server" class="button button4" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="javascript:return validation();" />    
                         
                        </td>    
                    </tr>    
                    <tr>    
                        <td align="center" style="width: 752px">    
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
                            <asp:GridView ID="CustomerProductgrid" runat="server" AllowPaging="true" CellPadding="2" EnableModelValidation="True"    
                                        ForeColor="red" GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!" AutoGenerateColumns="false" Width="1100px"    
                                HeaderStyle-ForeColor="blue">    
                                <HeaderStyle CssClass="DataGridFixedHeader" />    
                                <RowStyle CssClass="grid_item" />    
                                <AlternatingRowStyle CssClass="grid_alternate" />    
                                <FooterStyle CssClass="DataGridFixedHeader" />   
                                <Columns>    
                                    <asp:TemplateField HeaderText="Customer NO">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                        <ItemTemplate>    
                                            <asp:Label ID="lblCustomerNo" runat="server" Text='<%#Eval("Customer_no")%>'>    
                                            </asp:Label>    
                                            <%--<asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%#Eval("PRODUCTID")%>'>    
                                            </asp:Label>    --%>
                                        </ItemTemplate>    
                                    </asp:TemplateField>    
                                    <asp:TemplateField HeaderText="Customer Name">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                        <ItemTemplate>                                         
                                            <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("Customer_Name") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>    
                                    <asp:TemplateField HeaderText="Product No">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblProductNo" runat="server" Text='<%#Eval("Product_No") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>   
                                    <asp:TemplateField HeaderText="Product Name">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("Product_Name") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField> 

                                  <%--   <asp:TemplateField HeaderText="Total Product Qty.">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblTotalP" runat="server" Text='<%#Eval("Quantity") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField> --%>

                                    <asp:TemplateField HeaderText="Bought Quantity">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblBoughtQty" runat="server" Text='<%#Eval("Bought_Qty") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField> 

                                      <asp:TemplateField HeaderText="Balance Qty.">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblBalance" runat="server" Text='<%#Eval("Balance_Qty") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField> 




                                        
                                    <%--<asp:TemplateField HeaderText="Edit">   
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
                                            </asp:TemplateField> --%>   
                                        </Columns>    
                                    </asp:GridView>    
                            <%--added gridview style layout and functionality  here--%>  
                                </td>    
                            </tr>    
                    </table>    
            </fieldset>   

    
    </div>
 
</asp:Content>