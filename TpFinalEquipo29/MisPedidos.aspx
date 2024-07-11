<%@ Page Title="MisPedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="TpFinalEquipo29.DatosTarjeta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mis pedidos realizados</h2>
    <p>Este es el historial de pedidos asociados a tu cuenta.</p>
    <asp:GridView ID="gvHistorialCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
           
            <asp:BoundField DataField="FechaPedido" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="MontoTotal" HeaderText="Total" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("Envio")) ? "Pedido Entregado" : "En Proceso" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Artículos">
                <ItemTemplate>
                    <asp:Repeater ID="rptArticulos" runat="server" DataSource='<%# Eval("Detalles") %>'>
                        <ItemTemplate>
                            <div class="articulo">
                                <div class="info-articulo">
                                    <asp:Label ID="lblNombreArticulo" runat="server" Text='<%# Eval("NombreArticulo") %>'></asp:Label><br />
                                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label> unidad(es) -
                                    <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Eval("PrecioUnitario", "{0:C}") %>'></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ver">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkVerDetalle" runat="server" Text="Ver +" NavigateUrl='<%# "~/DetalleCompra.aspx?PedidoId=" + Eval("Id") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
