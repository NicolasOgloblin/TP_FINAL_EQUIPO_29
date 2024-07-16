<%@ Page Title="Gestión de Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="TpFinalEquipo29.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Gestión de Pedidos</h2>
        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="Id" OnRowCommand="gvPedidos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Pedido ID" />
                <asp:BoundField DataField="UsuarioNombre" HeaderText="Usuario" />
                <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="MontoTotal" HeaderText="Monto Total" DataFormatString="{0:C}" />
                <asp:BoundField DataField="EstadoPedido" HeaderText="Estado" />
                <asp:BoundField DataField="EnvioPedido" HeaderText="Envio" />
                <asp:BoundField DataField="MetodoPago.Nombre" HeaderText="Método de Pago" />
                <asp:TemplateField HeaderText="Entregado">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkPagado" runat="server" Checked='<%# Eval("Entregado") %>' />
                        <asp:Button ID="btnActualizar" runat="server" CommandName="Entregado" CommandArgument='<%# Eval("UsuarioId") %>' Text="Actualizar" CssClass="btn btn-success btn-sm ml-2" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Despachado">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDespachado" runat="server" Checked='<%# Eval("Despachado") %>' />
                        <asp:Button ID="btnActualizarDesp" runat="server" CommandName="Despachado" CommandArgument='<%# Eval("UsuarioId") %>' Text="Actualizar" CssClass="btn btn-success btn-sm ml-2" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
