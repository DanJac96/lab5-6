<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="Laboratorio5_6.Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:GridView ID="GridCarro"
            runat="server"
            BackColor="#DEBA84"
            BorderColor="#DEBA84"
            BorderStyle="None"
            BorderWidth="1px"
            CellPadding="3"
            CellSpacing="2"
            DataKeyNames="idCarro"
            OnRowCommand="GridCarro_RowCommand"
            OnRowEditing="GridCarro_RowEditing"
            OnRowCancelingEdit="GridCarro_RowCancelingEdit"
            OnRowUpdating="GridCarro_RowUpdating"
            OnRowDeleting="GridCarro_RowDeleting"
            ShowHeaderWhenEmpty="false"
            ShowFooter="true"
            AutoGenerateColumns="false"
            >


            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />

            <Columns>
                <asp:TemplateField HeaderText="Numero de Carro">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("idCarro") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCarro" Text='<%# Eval("idCarro")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCarroPie" Text='<%# Eval("idCarro")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Marca de Carro">
                        <ItemTemplate>
                             <asp:Label Text='<%# Eval("Marca")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox ID="txtMarca" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                             <asp:TextBox ID="txtMarcaPie" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="Modelo de Carro">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Modelo")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModelCarro" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtModelCarroPie" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="Pais del Carro">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Pais")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPaisCarro" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPaisCarroPie" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="Precio del Carro">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Costo")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecioCarro" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPrecioCarroPie" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                 </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                           <asp:ImageButton ImageUrl="~/Imagenes/editar.png"  runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Imagenes/basura.png" runat="server" CommandName="Delete" ToolTip="Borrar" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Imagenes/salvar.png" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Imagenes/cerrar.png" runat="server" CommandName="Cancel" ToolTip="Cancelar" Width="20px" Height="20px" />                           
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Imagenes/nuevo.png"  runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />                           
                        </FooterTemplate>
                </asp:TemplateField>
                </Columns>
        </asp:GridView>

            <br/>
            <br/>
            <asp:Label runat="server" ID="lblExito" ForeColor="Green"></asp:Label>
            <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
         </div>
    </form>
</body>
</html>
