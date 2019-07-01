<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Customer.aspx.cs" Inherits="FCC_ClientApp.Customer" Title="Customer Info" %>



<asp:Content ID="Customer" ContentPlaceHolderID="MainContent" runat="server" ClientIDMode="Static">

    
      <%--added css to asp.net server controls--%>   
    <link href="Content/style.css" rel="stylesheet" />

    <script src="Scripts/Js/CustomerJs.js"></script>
   
    <div>
<fieldset>    
    <legend style="font-family: Arial Black;background-color:blue; color:white; font-size:larger;font-style: oblique">Customer's Information</legend>   
                <table  align="center">    
                    <tr>    
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtCustomerNo" runat="server" placeholder="Enter Customer NO.." ></asp:TextBox>    
                        </td>    
                    </tr>    
                    <tr>    
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtCustomerName" runat="server" placeholder="Enter Cutomer name.."></asp:TextBox>    
                        </td>    
                    </tr>    
                   
                         <tr>    
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter email .."></asp:TextBox>    
                        </td>    
                    </tr> 
                         <tr>    
                        <td style="text-align:center">    
                            <asp:TextBox ID="txtMobile" runat="server" placeholder="Enter mobile .." MaxLength="10"></asp:TextBox>    
                        </td>    
                    </tr> 
                     <tr>    
                        <td align="center">    
                               <asp:DropDownList ID="ddlLanguageCode" runat="server">
                                <asp:ListItem Text="Select Language" Value="0"></asp:ListItem>
                                <asp:ListItem Text="English" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Hindi" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                        </td>    
                    </tr>    
                      <tr>    
                        <td align="center">    
                           <asp:DropDownList ID="ddlSubcription" runat="server">
                                <asp:ListItem Text="Select Subscription" Value="0"></asp:ListItem>
                                <asp:ListItem Text="SMS" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Email" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                        </td>    
                    </tr>   
                         <tr>    
                        <td align="center" style="display:none">    
                          <asp:DropDownList ID="ddlActive" runat="server">
                                <asp:ListItem Text="Select active" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="True" Value="true"></asp:ListItem>
                                <asp:ListItem Text="False" Value="false"></asp:ListItem>
                                </asp:DropDownList>
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
                        <td align="center" colspan="2" style="background-color:yellowgreen;width: 100%;">  
                            <span style="font-family: Arial Black;color:white;background-color:blue;font-size:larger;font-style: oblique">Customer's Records</span>  
                            <br />    
                        </td>    
                    </tr>    
                    <tr>   
                        <td colspan="2">    
                            <%--added gridview style layout and functionality  here--%>  
                            <asp:GridView ID="Customergrid" runat="server" AllowPaging="true" CellPadding="2" EnableModelValidation="True"    
                                        ForeColor="red" GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!" AutoGenerateColumns="false" Width="1100px"    
                                HeaderStyle-ForeColor="blue">    
                                <HeaderStyle CssClass="DataGridFixedHeader" />    
                                <RowStyle CssClass="grid_item" />    
                                <AlternatingRowStyle CssClass="grid_alternate" />    
                                <FooterStyle CssClass="DataGridFixedHeader" />   
                                <Columns>    
                                    <asp:TemplateField HeaderText="CustomerNO">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                        <ItemTemplate>    
                                            <asp:Label ID="lblCustomerNo" runat="server" Text='<%#Eval("CUSTOMER_NO")%>'>    
                                            </asp:Label>    
                                            <asp:Label ID="lblCustomerId" runat="server" Visible="false" Text='<%#Eval("CUSTOMER_ID")%>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>    
                                    <asp:TemplateField HeaderText="CustomerName">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                        <ItemTemplate>                                         
                                            <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CUSTOMER_NAME") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>    
                                    <asp:TemplateField HeaderText="Email">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("EmailID") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>   
                                        <asp:TemplateField HeaderText="Mobile">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>                                              
                                            <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile") %>'>    
                                            </asp:Label>    
                                        </ItemTemplate>    
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Edit">   
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />    
                                        <ItemTemplate>    
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CausesValidation="false"    
        
    CommandArgument='    
                                                <%#Eval("CUSTOMER_ID") %>' OnCommand="lnkEdit_Command" ToolTip="Edit" />    
                                            </ItemTemplate>    
                                        </asp:TemplateField>    
                                        <asp:TemplateField HeaderText="Delete">    
                                        <HeaderStyle HorizontalAlign="Left" />    
                                        <ItemStyle HorizontalAlign="Left" />   
                                            <ItemTemplate>    
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CausesValidation="false"    
        
    CommandArgument='    
                                                    <%#Eval("CUSTOMER_ID") %>' CommandName="Delete" OnCommand="lnkDelete_Command"    
        
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
